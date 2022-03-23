using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using iTextSharp.tool.xml;
using java.awt.print;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Design;
using System.Data;
using KBE.RESTFull;
using KBE.Models;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace KBE
{
    public partial class PaymentResult : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintBtn.Attributes.Add("onClick", "window.focus();window.print();");

            if (!Page.IsPostBack)
            {
                string PaymentID = "", PayResult = "", PostDate = "", TransID = "", AuthNum = "", Reference = "", TrackID = "", AMT = "", DoneAt = "";              

                try
                {
                    PaymentID = Session["PAYID_RV"].ToString();
                }
                catch (Exception dfg) { PaymentID = "ERROR"; }
                try
                {
                    PayResult = Session["PAYResult_RV"].ToString();
                }
                catch (Exception dfg) { }
                try
                {
                    PostDate = Session["PostDate_RV"].ToString();
                }
                catch (Exception fdgfd) { }
                try
                {
                    TransID = Session["TransID_RV"].ToString();
                }
                catch (Exception dgdg) { }
                try
                {
                    AuthNum = Session["AuthNo_RV"].ToString();
                }
                catch (Exception fhgf) { }
                try
                {
                    Reference = Session["ReferNo_RV"].ToString();
                }
                catch (Exception dfgh) { }
                try
                {
                    TrackID = Session["TrackID_RV"].ToString();
                }
                catch (Exception dg) { }
                try
                {
                    AMT = Session["PaidAMT_RV"].ToString();
                }
                catch (Exception dfgdg) { }
                try
                {
                    DoneAt = Session["DoneAT_RV"].ToString();
                }
                catch (Exception dfgd) { }

                PaymentIDlbl2.Text = PaymentID;
                PostDatelbl2.Text = PostDate;
                TransNolbl2.Text = TransID;
                AuthNolbl2.Text = AuthNum;
                TrackIDlbl2.Text = TrackID;
                ReferenceNolbl2.Text = Reference;
                PaidAmtlbl2.Text = AMT;
                PayResultlbl2.Text = PayResult;
                PaidAtlbl2.Text = DoneAt;
                if (PayResult.ToString() == "CAPTURED")
                {
                    PayResultlbl2.ForeColor = System.Drawing.Color.DarkGreen;
                    EmailBtn.Disabled = false;
                }
                else
                {
                    PaidAmtlbl2.Text = "0.000";
                    PayResultlbl2.ForeColor = System.Drawing.Color.Red;
                    EmailBtn.Disabled = true;
                }
                this.LoadLanguage();

                Session.Remove("PAYID_RV");
                Session.Remove("PAYResult_RV");
                Session.Remove("PostDate_RV");
                Session.Remove("TransID_RV");
                Session.Remove("AuthNo_RV");
                Session.Remove("ReferNo_RV");
                Session.Remove("TrackID_RV");
                Session.Remove("PaidAMT_RV");
                Session.Remove("DoneAT_RV");
            }

            this.EmailBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.EmailBtn));

        }
        protected void CloseBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard");
        }
        protected void EmailBtn_Click(object sender, EventArgs e)
        {
            string CXName_Str = "", CXEmail_Str = "";
            DataTable CxDt = new DataTable();
            CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
            if (CxDt.Rows.Count > 0)
            {
                DataRow dr = CxDt.Rows[0];
                CXName_Str = dr["CUST_NAME_E"].ToString() + " " + dr["CUST_NAME_A"].ToString();
                CXEmail_Str = dr["CUST_EMAIL"].ToString();
            }
            if (CXEmail_Str.ToString() == "")
            {
                Msglbl.Text = CommCls.Messages_Eng_Arabic("MSG_Noregisteredemailfoundtosendreceipt", Session["Lang"].ToString());
            }
            else
            {


                string BaseDir1 = AppDomain.CurrentDomain.BaseDirectory;
                var inlineLogo = new LinkedResource(BaseDir1 + "\\images\\logo.png");
                inlineLogo.ContentId = Guid.NewGuid().ToString();

                string htmlbody = "";
                htmlbody += "<html> <title></title>";
                htmlbody += "<head>";
                htmlbody += "</head>";
                htmlbody += "<body style='width:100%;margin:auto;'>";
                htmlbody += string.Format(@"<img alt='KBE' width='100%' src=""cid:{0}"" />", inlineLogo.ContentId);
                htmlbody += "<br/><p>Dear " + Session["CxName_S"].ToString() + ",</p>";
                htmlbody += "<p>Kindly check the attached document for the payment Receipt.<br/>";
                htmlbody += "Thank you for using KBE online services.</p>";
                htmlbody += "";
                htmlbody += "";
                htmlbody += "<p>Sincerely,<br/>";
                htmlbody += "Kuwait Bahrain Exchange Team</p>";
                htmlbody += "</body>";
                htmlbody += "</html>";

                string from = "appadmin@kbe.com.kw";
                string to = CXEmail_Str.ToLower().ToString();
                
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from, "KBE - Kuwait ", System.Text.Encoding.UTF8);
                message.To.Add(to);
                message.Subject = "KBE Online EFT Receipt";
                message.Body = htmlbody;
                message.IsBodyHtml = true;
                var view = AlternateView.CreateAlternateViewFromString(htmlbody, null, "text/html");
                view.LinkedResources.Add(inlineLogo);
                message.AlternateViews.Add(view);
                                
                string SMTPUser = "appadmin@kbe.com.kw";
                string SMTPPwd = "P@ss2019";

                SmtpClient client = new SmtpClient();

                DataTable EFTInfoDt = new DataTable();
                EFTInfoDt = RestCls.Get_EFT_BY_PaymentID(Session["LoginID_CX"].ToString(), PaymentIDlbl2.Text.Trim());
                if (EFTInfoDt.Rows.Count > 0)
                {
                    for (int i = 0; i < EFTInfoDt.Rows.Count; i++)
                    {
                        string EFTNoStr = "", TransDateStr = "", BenfName = "", BenfAcctNoStr = "", BenfBankStr = "", BranchCodeStr = "";
                        string ForiegnAmtStr = "", LocalAmtStr = "", CommissionStr = "", LocalAmtTotalStr = "", CurrencyStr = "", CurrRateStr = "", BenefMobNoStr = "";
                        string BankBranchStr = "", BankBracnAddressStr = "", CustIDStr = "", CustNameStr = "", CustMobileStr = "";
                        string DestiCountryStr = "", PayMethodStr = "", PaidStatusStr = "", DiscountStr = "";

                        DataRow dr = EFTInfoDt.Rows[i];
                        EFTNoStr = dr["DDTT_NO"].ToString();
                        TransDateStr = dr["TRAN_DATE"].ToString();
                        BenfName = dr["BEN_NAME"].ToString();
                        BenfAcctNoStr = dr["BEN_ACT"].ToString();
                        BenfBankStr = dr["BANK_NAME_EN"].ToString();
                        BranchCodeStr = dr["BEN_BRN_CODE"].ToString();
                        ForiegnAmtStr = dr["FC_AMOUNT"].ToString();
                        LocalAmtStr = dr["LC_AMOUNT"].ToString();
                        CommissionStr = dr["COMMISSION"].ToString();
                        LocalAmtTotalStr = dr["LC_AMOUNT_TOTAL"].ToString();
                        CurrencyStr = dr["CURR_ABBR_EN"].ToString();
                        CurrRateStr = dr["CURR_RATE"].ToString();
                        BenefMobNoStr = dr["BEN_TEL1"].ToString();
                        BankBranchStr = dr["BEN_BRN_NAME"].ToString();
                        BankBracnAddressStr = dr["BEN_BANK_BRN_ADDR1"].ToString();
                        CustIDStr = dr["CUST_ID"].ToString();
                        CustNameStr = dr["CUST_NAME"].ToString();
                        CustMobileStr = dr["CUST_TEL"].ToString();
                        DestiCountryStr = dr["DEST_COUNTRY_NAME"].ToString();
                        PayMethodStr = dr["PAYMENT_METHOD"].ToString();
                        PaidStatusStr = "Online Paid";
                        DiscountStr = "0.000";

                        
                        StringBuilder sb = new StringBuilder();
                        Document pdfDoc = new Document(PageSize.A4);
                        StringReader sr = new StringReader(sb.ToString());

                        PdfPTable table = new PdfPTable(3);

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                            pdfDoc.Open();

                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

                            string imageFilePath = HttpContext.Current.Server.MapPath(@"~/images/EFTRV_bg.jpg");
                            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
                            jpg.ScaleToFit(1550, 850);
                            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
                            jpg.SetAbsolutePosition(0, 0);
                            pdfDoc.Add(jpg);

                            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11);

                            //Trans Details
                            Phrase Td_Date = new Phrase(Convert.ToDateTime(TransDateStr).ToString("dd/MM/yyyy"), font);
                            PdfContentByte cb_TD = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_TD, Element.ALIGN_CENTER, Td_Date, 190, 622, 0); 

                            Phrase Td_To = new Phrase(DestiCountryStr, font);
                            PdfContentByte cb_TTO = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_TTO, Element.ALIGN_CENTER, Td_To, 375, 622, 0);

                            Phrase Td_TNo = new Phrase(EFTNoStr, font);
                            PdfContentByte cb_TNO = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_TNO, Element.ALIGN_CENTER, Td_TNo, 530, 622, 0);

                            //Sender Details
                            Phrase Td_SDN = new Phrase(CustNameStr, font);
                            PdfContentByte cb_SDN = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_SDN, Element.ALIGN_CENTER, Td_SDN, 320, 550, 0);

                            Phrase Td_SDC = new Phrase(CustIDStr, font);
                            PdfContentByte cb_SDC = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_SDC, Element.ALIGN_CENTER, Td_SDC, 320, 532, 0);

                            Phrase Td_SDMO = new Phrase(CustMobileStr, font);
                            PdfContentByte cb_SDMO = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_SDMO, Element.ALIGN_CENTER, Td_SDMO, 320, 517, 0);

                            //Beneficiary Info
                            Phrase Td_BN = new Phrase(BenfName, font);
                            PdfContentByte cb_BN = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_BN, Element.ALIGN_CENTER, Td_BN, 320, 430, 0);

                            Phrase Td_BAC = new Phrase(BenfAcctNoStr, font);
                            PdfContentByte cb_BAC = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_BAC, Element.ALIGN_CENTER, Td_BAC, 320, 414, 0);

                            Phrase Td_BBN = new Phrase(BenfBankStr, font);
                            PdfContentByte cb_BBN = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_BBN, Element.ALIGN_CENTER, Td_BBN, 320, 400, 0);

                            Phrase Td_BBR = new Phrase(BankBracnAddressStr, font);
                            PdfContentByte cb_BBR = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_BBR, Element.ALIGN_CENTER, Td_BBR, 320, 385, 0);

                            //Trans amount Info                
                            Phrase Td_FC = new Phrase(ForiegnAmtStr + " " + CurrencyStr, font);
                            PdfContentByte cb_FC = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_FC, Element.ALIGN_CENTER, Td_FC, 320, 297, 0);

                            Phrase Td_ER = new Phrase(CurrRateStr, font);
                            PdfContentByte cb_ER = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_ER, Element.ALIGN_CENTER, Td_ER, 320, 281, 0);

                            Phrase Td_KD = new Phrase(LocalAmtStr, font);
                            PdfContentByte cb_KD = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_KD, Element.ALIGN_CENTER, Td_KD, 320, 267, 0);

                            Phrase Td_TF = new Phrase(CommissionStr, font);
                            PdfContentByte cb_TF = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_TF, Element.ALIGN_CENTER, Td_TF, 320, 252, 0);

                            Phrase Td_PD = new Phrase(DiscountStr, font);
                            PdfContentByte cb_PD = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_PD, Element.ALIGN_CENTER, Td_PD, 320, 237, 0);

                            Phrase Td_TKD = new Phrase(LocalAmtTotalStr, font);
                            PdfContentByte cb_TKD = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_TKD, Element.ALIGN_CENTER, Td_TKD, 320, 222, 0);

                            Phrase Td_PM = new Phrase(PayMethodStr, font);
                            PdfContentByte cb_PM = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_PM, Element.ALIGN_CENTER, Td_PM, 320, 208, 0);

                            Phrase Td_STS = new Phrase(PaidStatusStr, font);
                            PdfContentByte cb_STS = writer.DirectContent;
                            ColumnText.ShowTextAligned(cb_STS, Element.ALIGN_CENTER, Td_STS, 320, 192, 0);

                            pdfDoc.Close();

                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();
                                                        

                            try
                            {
                                message.Attachments.Add(new Attachment(new MemoryStream(bytes), EFTNoStr + "_EFT.pdf"));
                            }
                            catch (Exception dg)
                            { }
                        }
                    }
                }

                client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPwd);
                client.Port = 587;
                client.Host = "smtp.office365.com";
                client.EnableSsl = true;
                try
                {
                    client.Send(message);

                    Msglbl.Text = CommCls.Messages_Eng_Arabic("MSG_Emailhasbeensentwitheftattachment", Session["Lang"].ToString());
                    Msglbl.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception gsdf)
                {

                    Msglbl.Text = CommCls.Messages_Eng_Arabic("MSG_Errorwhilesendingemail", Session["Lang"].ToString());
                    Msglbl.ForeColor = System.Drawing.Color.Red;
                }
                

            }

        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            Payreceiptheadlbl.InnerText = rm.GetString("Paymentreceipt", ci);
            PaymentIDlbl1.Text = rm.GetString("Paymentid", ci);
            PostDatelbl1.Text = rm.GetString("Postdate", ci);
            TransNolbl1.Text = rm.GetString("Transactionno", ci);
            AuthNolbl1.Text = rm.GetString("Authorizationno", ci);
            TrackIDlbl1.Text = rm.GetString("Trackid", ci);
            ReferenceNolbl1.Text = rm.GetString("Referenceno", ci);
            PaidAmtlbl1.Text = rm.GetString("Paidamount", ci);
            PaidAtlbl1.Text = rm.GetString("Paidat", ci);
            PayResultlbl1.Text = rm.GetString("Result", ci);            

        }

    }
}