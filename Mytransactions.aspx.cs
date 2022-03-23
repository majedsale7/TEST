using KBE.Models;
using KBE.RESTFull;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.Text;
using iTextSharp.tool.xml;
using java.awt.print;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Design;
using System.Net.Mail;

namespace KBE
{
    public partial class Mytransactions : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FromDateTxt.Text = CommCls.TimeZoneDateTime().ToString("01/MM/yyyy");
                ToDateTxt.Text = CommCls.TimeZoneDateTime().ToString("dd/MM/yyyy");
                this.LoadLanguage();
            }

            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.SubmitBtn));         
        }
        public void GetTransactionsHistory()
        {
            CultureInfo ci = new CultureInfo("sl-SI", true);
            ci.DateTimeFormat.DateSeparator = "/";
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            DateTime FromDCUL = DateTime.Parse(FromDateTxt.Text.Trim(), ci);
            DateTime ToDCUL = DateTime.Parse(ToDateTxt.Text.Trim(), ci);
            string QRY = "";

            DataTable TransDt = new DataTable();
            TransDt = RestCls.TransactionsHistory(Session["LoginID_CX"].ToString());
            DataView TransDv = new DataView(TransDt);
            if (TransDt != null)
            {
                try
                {
                    if (BeneficiaryNameTxt.Text.Trim() != "")
                        QRY += "BEN_NAME LIKE '%" + BeneficiaryNameTxt.Text.Trim() + "%' AND ";
                    QRY += "TRAN_DATE >= '" + Convert.ToDateTime(FromDCUL).ToString("yyyy-MM-dd") + "' AND TRAN_DATE <= '" + Convert.ToDateTime(ToDCUL).ToString("yyyy-MM-dd") + "' ";
                    TransDv.RowFilter = QRY;
                    TransDv.Sort = "TRAN_DATE ASC";
                }
                catch (Exception sdfg) { }

                if (TransDv.ToTable().Rows.Count > 0)
                {
                    string LangType = Session["Lang"].ToString();
                    TransGV.Columns[0].HeaderText = CommCls.Messages_Eng_Arabic("Sno", LangType);
                    TransGV.Columns[1].HeaderText = CommCls.Messages_Eng_Arabic("Date", LangType);
                    TransGV.Columns[2].HeaderText = CommCls.Messages_Eng_Arabic("EFTNo", LangType);
                    TransGV.Columns[3].HeaderText = CommCls.Messages_Eng_Arabic("BeneficiaryName", LangType);
                    TransGV.Columns[4].HeaderText = CommCls.Messages_Eng_Arabic("AccountNumber", LangType);
                    TransGV.Columns[5].HeaderText = CommCls.Messages_Eng_Arabic("Bankname", LangType);
                    TransGV.Columns[6].HeaderText = CommCls.Messages_Eng_Arabic("Foreignamount", LangType);
                    TransGV.Columns[7].HeaderText = CommCls.Messages_Eng_Arabic("Currency", LangType);
                    TransGV.Columns[8].HeaderText = CommCls.Messages_Eng_Arabic("KD", LangType);
                    TransGV.Columns[9].HeaderText = CommCls.Messages_Eng_Arabic("Action", LangType);
                }

                if (TransDv.ToTable().Rows.Count == 0)
                    TransGV.EmptyDataText = CommCls.Messages_Eng_Arabic("MSG_Notransactionshistoryavailable", Session["Lang"].ToString());
                TransGV.DataSource = TransDv.ToTable();
                TransGV.DataBind();
            }
            else
            {
                TransGV.EmptyDataText = CommCls.Messages_Eng_Arabic("MSG_Notransactionshistoryavailable", Session["Lang"].ToString());
                TransGV.DataSource = null;
                TransGV.DataBind();
            }
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            Mytranslbl.Text = rm.GetString("Mytransactions", ci);
            beneficiarynamelbl.InnerText = rm.GetString("BeneficiaryName", ci);
            Fromdatelbl.InnerText = rm.GetString("Fromdate", ci);
            Todatelbl.InnerText = rm.GetString("Todate", ci);            
            ExportBtn.Text = rm.GetString("Export", ci);
            SubmitBtn.Text = rm.GetString("Search", ci);
            Excellbl.InnerText = rm.GetString("Excel", ci);
            PDFlbl.InnerText = rm.GetString("PDF", ci);

            BeneficiaryNameTxt.Attributes.Add("placeholder", rm.GetString("Entersearchingname", ci));
        }
        public void MessageBox_OK(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>SuccessMsg('" + msg + "');</script>", false);
        }
        public void MessageBox_Error(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>ErrorMsg('" + msg + "');</script>", false);
        }

        protected void TransGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string _EFTNoStr = TransGV.DataKeys[e.RowIndex].Values["EFT#"].ToString();
            string _TransDateStr = TransGV.DataKeys[e.RowIndex].Values["TRAN_DATE"].ToString();
            string _CurrencyStr = TransGV.DataKeys[e.RowIndex].Values["CURR_CODE"].ToString();
            string _ForiegnAmtStr = String.Format("{0:n2}", Convert.ToDouble(TransGV.DataKeys[e.RowIndex].Values["TRF_AMOUNT"].ToString()).ToString("N2"));
            string _LocalamtStr = String.Format("{0:n3}", Convert.ToDouble(TransGV.DataKeys[e.RowIndex].Values["LC_AMOUNT"].ToString()).ToString("N3"));
            string _CommisionStr = Convert.ToDouble(TransGV.DataKeys[e.RowIndex].Values["COMMISSION"].ToString()).ToString("N3");
            string _LocalAmtTotalStr = String.Format("{0:n3}", Convert.ToDouble(TransGV.DataKeys[e.RowIndex].Values["LC_AMOUNT_TOTAL"].ToString()).ToString("N3"));
            string _BenfNameStr = TransGV.DataKeys[e.RowIndex].Values["BEN_NAME"].ToString();
            string _BenfAcctNoStr = TransGV.DataKeys[e.RowIndex].Values["BEN_ACT"].ToString();
            string _BenfBankStr = TransGV.DataKeys[e.RowIndex].Values["BEN_BANK"].ToString();
            string _BranchCodeStr = TransGV.DataKeys[e.RowIndex].Values["BEN_BRN_CODE"].ToString();
            string _CurrRateStr = TransGV.DataKeys[e.RowIndex].Values["CURR_RATE"].ToString();
            string _BenfMobNoStr = TransGV.DataKeys[e.RowIndex].Values["BEN_TEL1"].ToString();
            string _BranchNameStr = TransGV.DataKeys[e.RowIndex].Values["BEN_BRN_NAME"].ToString();
            string _BranchAddressStr = TransGV.DataKeys[e.RowIndex].Values["BEN_BRN_NAME"].ToString();

            string _CustIDStr = TransGV.DataKeys[e.RowIndex].Values["CUST_ID"].ToString();
            string _CustNameStr = TransGV.DataKeys[e.RowIndex].Values["CUST_NAME"].ToString();
            string _CustMobileStr = TransGV.DataKeys[e.RowIndex].Values["CUST_TEL"].ToString();
            string _DestiCountryStr = TransGV.DataKeys[e.RowIndex].Values["DEST_COUNTRY_NAME"].ToString();
            string _PayMethodStr = TransGV.DataKeys[e.RowIndex].Values["PAYMENT_METHOD"].ToString();
            string _PaidStatusStr = TransGV.DataKeys[e.RowIndex].Values["PAID_STATUS"].ToString();
            string _DiscountStr = Convert.ToDouble(TransGV.DataKeys[e.RowIndex].Values["DISCOUNT"].ToString()).ToString("N3");

            this.HTMLPrint(_EFTNoStr, _TransDateStr, _BenfNameStr, _BenfAcctNoStr, _BenfBankStr, _BranchCodeStr, _ForiegnAmtStr, _LocalamtStr,
               _CommisionStr, _LocalAmtTotalStr, _CurrencyStr, _CurrRateStr, _BenfMobNoStr, _BranchNameStr, _BranchAddressStr, _CustIDStr, _CustNameStr, _CustMobileStr,
                _DestiCountryStr, _PayMethodStr, _PaidStatusStr, _DiscountStr);
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            this.GetTransactionsHistory();
        }
        protected void ExportBtn_Click(object sender, EventArgs e)
        {
            if (ExcelRad.Checked == false && PDFRad.Checked == false)
            {
                this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_Pleasechooserequiredformattodownload", Session["Lang"].ToString()));
            }
            else if ((ExcelRad.Checked == true || PDFRad.Checked == true) && TransGV.Rows.Count == 0)
            {
                this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_Notransactionsavailabletoexport", Session["Lang"].ToString()));
            }
            else if (ExcelRad.Checked == true)
            {
                CultureInfo ci = new CultureInfo("sl-SI", true);
                ci.DateTimeFormat.DateSeparator = "/";
                ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                DateTime FromDCUL = DateTime.Parse(FromDateTxt.Text.Trim(), ci);
                DateTime ToDCUL = DateTime.Parse(ToDateTxt.Text.Trim(), ci);

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=KBE_Transactions.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);                    
                    TransGV.AllowPaging = false;

                    this.GetTransactionsHistory();
                    TransGV.HeaderRow.BackColor = System.Drawing.Color.Black;
                    TransGV.HeaderRow.ForeColor = System.Drawing.Color.White;

                    foreach (TableCell cell in TransGV.HeaderRow.Cells)
                    {
                        cell.BackColor = TransGV.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in TransGV.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = TransGV.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = TransGV.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    TransGV.Columns[9].Visible = false;
                    
                    string LogoUrl = "https://onlinekbe.com/images/Exp_logo.jpg";                    
                    string TransInfo = "";
                    TransInfo = "( " + CommCls.Messages_Eng_Arabic("Transactionsbetween", Session["Lang"].ToString()) + " \"" + Convert.ToDateTime(FromDCUL).ToString("dd - MM - yyyy") + " & " + Convert.ToDateTime(ToDCUL).ToString("dd - MM - yyyy") + "\" )";

                    string headerTable = @"<table align='center' width='100%'><tr><td></td><td align='center'><img width='650' height='150' src='" + LogoUrl + "' \\></td></tr>    ";
                    headerTable += @"<tr><td></td><td></td></tr> <tr><td></td><td></td></tr>";
                    headerTable += @"<tr><td></td><td></td></tr> <tr><td></td><td></td></tr>";
                    headerTable += @"<tr><td></td><td></td></tr> <tr><td></td><td></td></tr>";
                    headerTable += @"<tr><td></td><td></td></tr> ";
                    headerTable += @" </table>";
                    headerTable += @" <table align='center'><tr><td colspan='9' align='center' style='color:BLACK; font-size:12f'>" + TransInfo + "</td></tr></table>";
                    Response.Write(headerTable);

                    TransGV.RenderControl(hw);                    
                    string style = @"<style> .textmode { mso-number-format:\@;} </style>";
                    Response.Write(style);

                    Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");

                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else if (PDFRad.Checked == true)
            {
                if (Session["Lang"].ToString() == "en-US")
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            CultureInfo ci = new CultureInfo("sl-SI", true);
                            ci.DateTimeFormat.DateSeparator = "/";
                            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                            DateTime FromDCUL = DateTime.Parse(FromDateTxt.Text.Trim(), ci);
                            DateTime ToDCUL = DateTime.Parse(ToDateTxt.Text.Trim(), ci);

                            if (TransGV.Rows.Count > 0)
                            {
                                TransGV.HeaderRow.BackColor = System.Drawing.Color.Black;
                                TransGV.HeaderRow.ForeColor = System.Drawing.Color.White;
                            }
                            foreach (TableCell cell in TransGV.HeaderRow.Cells)
                            {
                                cell.BackColor = TransGV.HeaderStyle.BackColor;

                            }
                            foreach (GridViewRow row in TransGV.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = TransGV.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = TransGV.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }
                            TransGV.Columns[9].Visible = false;
                            TransGV.RenderControl(hw);

                            StringReader sr = new StringReader(sw.ToString());
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();

                            string BaseDir1 = AppDomain.CurrentDomain.BaseDirectory;                            
                            string LogoUrl = BaseDir1 + "\\images\\Exp_logo.jpg";

                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(LogoUrl);
                            img.ScaleAbsolute(600, 125);
                            pdfDoc.Add(img);

                            string TransInfo = "";
                            TransInfo = "                                 ( " + CommCls.Messages_Eng_Arabic("Transactionsbetween", Session["Lang"].ToString()) + " \"" + Convert.ToDateTime(FromDCUL).ToString("dd - MM - yyyy") + "\" & \"" + Convert.ToDateTime(ToDCUL).ToString("dd - MM - yyyy") + "\" )";

                            iTextSharp.text.Font georgia = FontFactory.GetFont("georgia", 12f, BaseColor.BLACK);
                            Chunk c1 = new Chunk(TransInfo, georgia);
                            Phrase p2 = new Phrase();
                            p2.Add(c1);
                            pdfDoc.Add(p2);


                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=KBE_Transactions.pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            string style = @"<style> .textmode {mso-number-format:\@; } </style>";
                            Response.Write(style);
                            Response.Write(pdfDoc);
                            Response.End();
                        }
                    }
                }
                else
                {
                    //Arabic

                    CultureInfo ci = new CultureInfo("sl-SI", true);
                    ci.DateTimeFormat.DateSeparator = "/";
                    ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                    DateTime FromDCUL = DateTime.Parse(FromDateTxt.Text.Trim(), ci);
                    DateTime ToDCUL = DateTime.Parse(ToDateTxt.Text.Trim(), ci);

                    BaseFont bf = BaseFont.CreateFont(Server.MapPath(" ") + "\\Fonts\\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(TransGV.Columns.Count - 1);                    
                    for (int x = 0; x < TransGV.Columns.Count - 1; x++)
                    {                        
                        string cellText = Server.HtmlDecode(TransGV.HeaderRow.Cells[x].Text);                     
                        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);                        
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));                        
                        cell.BackgroundColor = BaseColor.BLACK;                        
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table.AddCell(cell);
                    }
                    
                    int RowCNT = 0;
                    for (int i = 0; i < TransGV.Rows.Count; i++)
                    {                       
                        if (TransGV.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            
                            for (int j = 0; j < TransGV.Columns.Count - 1; j++)
                            {

                                string cellText = Server.HtmlDecode(TransGV.Rows[i].Cells[j].Text);

                                if (j == 0 && cellText == "")
                                {
                                    RowCNT++;
                                    cellText = RowCNT.ToString();
                                }                                
                                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);                                
                                iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));                                
                                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                                table.AddCell(cell);
                            }
                        }
                    }

                    string BaseDir1 = AppDomain.CurrentDomain.BaseDirectory;                    
                    string LogoUrl = BaseDir1 + "\\images\\Exp_logo.jpg";

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(LogoUrl);
                    img.ScaleAbsolute(600, 125);                    

                    iTextSharp.text.pdf.PdfPTable table_t = new iTextSharp.text.pdf.PdfPTable(1);
                    string TransInfo = "";
                    TransInfo = "                                 ( " + CommCls.Messages_Eng_Arabic("Transactionsbetween", Session["Lang"].ToString()) + " \"" + Convert.ToDateTime(FromDCUL).ToString("dd - MM - yyyy") + "\" & \"" + Convert.ToDateTime(ToDCUL).ToString("dd - MM - yyyy") + "\" ) ";
                    TransInfo += " ";

                    iTextSharp.text.Font font_t = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    iTextSharp.text.pdf.PdfPCell cell_t = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, TransInfo, font_t));
                    cell_t.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell_t.BorderColor = BaseColor.WHITE;
                    table_t.AddCell(cell_t);

                    Phrase phrase1 = new Phrase(Environment.NewLine);
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    pdfDoc.Add(img);
                    pdfDoc.Add(table_t);
                    pdfDoc.Add(phrase1);
                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=KBE_Transactions.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();



                }






            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {            
        }
        public void HTMLPrint(string EFTNoStr, string TransDateStr, string BenfName, string BenfAcctNoStr, string BenfBankStr, string BranchCodeStr,
        string ForiegnAmtStr, string LocalAmtStr, string CommissionStr, string LocalAmtTotalStr, string CurrencyStr, string CurrRateStr, string BenefMobNoStr,
        string BankBranchStr, string BankBracnAddressStr, string CustIDStr, string CustNameStr, string CustMobileStr, string DestiCountryStr, string PayMethodStr,
        string PaidStatusStr, string DiscountStr)
        {
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
                ColumnText.ShowTextAligned(cb_TD, Element.ALIGN_CENTER, Td_Date, 190, 622, 0); //x=190 y=622 rotation angel=0

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

                /////Test 
                //string htmlbody = "";
                //htmlbody += "Pleae check the attched document";
                //string SentStatus = "";
                //string from = "appadmin@kbe.com.kw";
                ////string to = CustomerEmailIDStr.ToLower().ToString();
                //string to = "munna1116s@gmail.com";
                //MailMessage message = new MailMessage();
                //message.From = new MailAddress(from, "KBE - Kuwait ", System.Text.Encoding.UTF8);
                //message.To.Add(to);
                //message.Subject = "KBE Online EFT Receipt";
                //message.Body = htmlbody;
                //message.IsBodyHtml = true;

                ////string url = "outlook.office.com";
                //string SMTPUser = "appadmin@kbe.com.kw";
                //string SMTPPwd = "P@ss2019";

                //SmtpClient client = new SmtpClient();
                //try
                //{                   
                //    message.Attachments.Add(new Attachment(new MemoryStream(bytes), EFTNoStr + "_EFT.pdf"));                   
                //}
                //catch (Exception dg)
                //{ }
                //client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPwd);
                //client.Port = 587;
                //client.Host = "smtp.office365.com";
                //client.EnableSsl = true;
                //try
                //{
                //    client.Send(message);
                //    SentStatus = "Success";
                //}
                //catch (Exception gsdf)
                //{
                //    SentStatus = "Failure";
                //}
                ////Test              


                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + EFTNoStr + "_EFT.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Buffer = true;
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();

            }
        }

        protected void TransGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
               
            }
        }

       
    }
}