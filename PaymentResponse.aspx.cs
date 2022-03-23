using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.fss.plugin;
using System.Data;
using KBE.Models;
using System.Data.SqlClient;
using System.Configuration;
using KBE.RESTFull;
using System.Threading.Tasks;

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
using System.IO;

namespace KBE
{
    public partial class PaymentResponse : System.Web.UI.Page
    {
        private SqlConnection cn;
        private SqlCommand cmd1, cmd2;
        CommonClass CommCls = new CommonClass();
        UpdateREST URest = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        string CS = ConfigurationManager.ConnectionStrings["KBECS"].ConnectionString;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string trandata = "", errorTxt = "";
                string paymentID = "", PayResult = "", postdate = "", tranid = "", auth = "", trackid = "", refr = "", udf1 = "", udf2 = "", udf3 = "", udf4 = "", udf5 = "";
                string Password = "", approvalNum = "", KnetLang = "", Paidamt = "", PaidCurrency = "";
                string ReferenceCode = "", ErrorCode = "", ErrorText = "", ActionStr = "";
                int result = 0;

                iPayPipe pipe = new iPayPipe();
                pipe.setResourcePath(@"C:\\HostingSpaces\\onlinekbe\\onlinekbe.onlinekbe.com\\wwwroot\\Resource\\");
                pipe.setKeystorePath(@"C:\\HostingSpaces\\onlinekbe\\onlinekbe.onlinekbe.com\\wwwroot\\Resource\\");
                pipe.setAlias("kbe");
                try
                {
                    trandata = Request.Form["trandata"].ToString();
                }
                catch (Exception yh) { Response.Write("TranData Error : " + yh.ToString()); }

                
                try
                {
                    result = pipe.parseEncryptedRequest(trandata);
                    paymentID = pipe.getPaymentId();
                    PayResult = pipe.getResult();
                    postdate = pipe.getDate();
                    tranid = pipe.getTransId();
                    auth = pipe.getAuth();
                    refr = pipe.getRef();
                    trackid = pipe.getTrackId();
                    udf1 = pipe.getUdf1();
                    udf2 = pipe.getUdf2();
                    udf3 = pipe.getUdf3();
                    udf4 = pipe.getUdf4();
                    udf5 = pipe.getUdf5();

                    Password = pipe.getIvrPassword();
                    KnetLang = pipe.getLanguage();
                    approvalNum = pipe.getAuth();
                    Paidamt = pipe.getAmt();
                    PaidCurrency = pipe.getCurrency();
                    ReferenceCode = pipe.getResponseCode();
                    ErrorCode = pipe.getError();
                    ErrorText = pipe.getError_text();
                    try
                    {
                        ActionStr = pipe.getAction();
                    }
                    catch (Exception dfgd) { ActionStr = dfgd.ToString(); }



                    Response.Write("<br/>result:" + result);
                    Response.Write("<br/>paymentID:" + paymentID);
                    Response.Write("<br/>Password:" + Password);
                    Response.Write("<br/>ActionStr:" + ActionStr);
                    Response.Write("<br/>Paidamt:" + Paidamt);
                    Response.Write("<br/>PaidCurrency:" + PaidCurrency);
                    Response.Write("<br/>KnetLang:" + KnetLang);
                    Response.Write("<br/>ReferenceCode:" + ReferenceCode);
                    Response.Write("<br/>PayResult:" + PayResult);
                    Response.Write("<br/>ErrorCode:" + ErrorCode);
                    Response.Write("<br/>ErrorText:" + ErrorText);
                    Response.Write("<br/>udf1:" + udf1);
                    Response.Write("<br/>udf2:" + udf2);
                    Response.Write("<br/>udf3:" + udf3);
                    Response.Write("<br/>udf4:" + udf4);
                    Response.Write("<br/>udf5:" + udf5);
                }
                catch (Exception dfg) { }

                if (result == 0)
                {
                    udf5 = udf5.Replace('+', ' ');
                    PayResult = PayResult.Replace('+', ' ');

                    Session["LoginID_CX"] = udf1.ToString();
                    Session["CxName_S"] = udf5.ToString();
                    Session["Lang"] = udf3.ToString();

                    this.PrepareCXSessions();

                    if (PayResult.ToString() == "CAPTURED")
                        this.Send_Email(udf1.ToString(), paymentID);                    
                    await UpdateKNETDetails(paymentID, Password, ActionStr, Paidamt, PaidCurrency, trackid, tranid, refr, auth, KnetLang, postdate, ReferenceCode, ErrorCode, ErrorText, PayResult, udf1, udf2, udf3, udf4, udf5);

                    Session["PAYID_RV"] = paymentID;
                    Session["PAYResult_RV"] = PayResult;
                    Session["PostDate_RV"] = postdate;
                    Session["TransID_RV"] = tranid;
                    Session["AuthNo_RV"] = auth;
                    Session["ReferNo_RV"] = refr;
                    Session["TrackID_RV"] = trackid;
                    Session["PaidAMT_RV"] = Paidamt;
                    Session["DoneAT_RV"] = CommCls.TimeZoneDateTime().ToString("dd-MMM-yyyy, hh:mm tt");

                    Response.Redirect("https://onlinekbe.com/Receipt", false);
                }

            }
        }

        public void PrepareCXSessions()
        {
            Session["LastLogin_S"] = CommCls.TimeZoneDateTime().ToString("dd/MM/yyyy hh:mm tt");
            Session["SecQuestionValidated_S"] = "Yes";
            Session["CID_Expiry_S"] = "";
            Session["PopupMsg_S"] = "";
            Session["UserMachineIP_S"] = CommCls.GetIPAddress();
            Session["PayingAmt_OTP_S"] = "";
            Session["PromShow_S"] = "Showed";
            Session["CIDPopup_S"] = "NoExpiry";
            Session["DocsUpload_S"] = "";

            Session["CX_CURR_CODE_S"] = "";
            DataTable CxDt = new DataTable();
            CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
            if (CxDt.Rows.Count > 0)
            {
                DataRow dr = CxDt.Rows[0];
                Session["CX_CURR_CODE_S"] = dr["CURR_CODE"].ToString();
            }

            string ActiveSessionID = "";
            DataTable SessionDT = new DataTable();
            SessionDT = RestCls.GetUserActiveSessionID(Session["LoginID_CX"].ToString());
            if (SessionDT.Rows.Count > 0)
            {
                DataRow dr_s = SessionDT.Rows[0];
                ActiveSessionID = dr_s["SESSION_ID"].ToString();
                Session["UserSessionID_S"] = ActiveSessionID.ToString();
            }
        }

        public async Task<string> UpdateKNETDetails(string paymentid, string password, string action, string amount, string currencyid, string trackid,
        string transid, string refid, string authno, string lang, string postdate, string refencecode, string errorcode, string errortext,
            string status, string udf1, string udf2, string udf3, string udf4, string udf5)
        {

            if (password == "")
                password = " ";
            if (action == "")
                action = " ";
            if (currencyid == "")
                currencyid = " ";
            if (lang == "")
                lang = " ";
            if (refencecode == "")
                refencecode = " ";
            if (errorcode == "")
                errorcode = " ";
            if (errortext == "")
                errortext = " ";
            if (udf4 == "")
                udf4 = " ";
            if (authno == "")
                authno = " ";
            if (transid == "")
                transid = " ";
            if (refid == "")
                refid = " ";
            if (postdate == "")
                postdate = " ";

            string ErroRemarks = "";

            string Result = await URest.KNETUpdate(paymentid, password, action, amount, currencyid, trackid, transid, refid, authno, lang,
           postdate, refencecode, errorcode, errortext, status, udf1, udf2, udf3, udf4, udf5);

            ErroRemarks = ErroRemarks + Result;

            if (status.ToString() == "CAPTURED")
            {
                DataTable Add2Dt = new DataTable();
                Add2Dt = RestCls.AddedToCartList(udf1.ToString());

                if (Add2Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Add2Dt.Rows.Count; i++)
                    {
                        DataRow dr = Add2Dt.Rows[i];
                        string EFTNum = dr["EFT_NUM"].ToString();
                        string EFTAmt = dr["LC_AMT"].ToString();

                        string EFTResult = await URest.EFTPaylinkUpdate(udf1, EFTNum, paymentid, EFTAmt, amount);
                        ErroRemarks = ErroRemarks + " EFT ERRO: " + EFTResult;
                    }
                }
            }

            SqlTransaction sqltrans = null;
            cn = new SqlConnection(CS);
            cmd1 = new SqlCommand("Transactions_KNetMaster_I", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@LoginID_S", SqlDbType.NVarChar).Value = udf1.ToString();
            cmd1.Parameters.Add("@TrackID_S", SqlDbType.NVarChar).Value = trackid.ToString();
            cmd1.Parameters.Add("@PaymentID_S", SqlDbType.NVarChar).Value = paymentid.ToString();
            cmd1.Parameters.Add("@TransactionID_S", SqlDbType.NVarChar).Value = transid.ToString();
            cmd1.Parameters.Add("@AutherizationNum_S", SqlDbType.NVarChar).Value = authno.ToString();
            cmd1.Parameters.Add("@ReferenceNum_S", SqlDbType.NVarChar).Value = refid.ToString();
            cmd1.Parameters.Add("@PostDate_S ", SqlDbType.NVarChar).Value = postdate.ToString();
            cmd1.Parameters.Add("@UDF1_S", SqlDbType.NVarChar).Value = udf1.ToString();
            cmd1.Parameters.Add("@UDF2_S", SqlDbType.NVarChar).Value = udf2.ToString();
            cmd1.Parameters.Add("@UDF3_S", SqlDbType.NVarChar).Value = udf3.ToString();
            cmd1.Parameters.Add("@UDF4_S", SqlDbType.NVarChar).Value = udf4.ToString();
            cmd1.Parameters.Add("@UDF5_S", SqlDbType.NVarChar).Value = udf5.ToString();
            cmd1.Parameters.Add("@PaidAmount_S", SqlDbType.Decimal).Value = amount;
            cmd1.Parameters.Add("@PayResult_S", SqlDbType.NVarChar).Value = status;
            cmd1.Parameters.Add("@TransactionDoneAt_S", SqlDbType.DateTime).Value = CommCls.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
            cmd1.Parameters.Add("@ErrorRemrks_S", SqlDbType.NVarChar).Value = ErroRemarks;
            cn.Open();
            sqltrans = cn.BeginTransaction();
            cmd1.Transaction = sqltrans;
            int result1 = int.Parse(cmd1.ExecuteNonQuery().ToString());
            if (result1 == 1)
            {
                sqltrans.Commit();
            }
            else
            {
                sqltrans.Rollback();
            }
            cn.Close();
            cn.Dispose();

            return Result;
        }

        public void Send_Email(string LoginIDStr, string RefNoStr)
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
            if (CXEmail_Str.ToString() != "")
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
                htmlbody += "<br/><p>Dear " + CXName_Str.ToString() + ",</p>";
                htmlbody += "<p>Your transaction has been successfully approved with the Track Number#: " + RefNoStr + ".<br/><br/>";
                htmlbody += "Thank you for using KBE online services.<br/>";
                htmlbody += "</p>";
                htmlbody += "<p>Sincerely,<br/>";
                htmlbody += "Kuwait Bahrain Exchange Team</p>";
                htmlbody += "</body>";
                htmlbody += "</html>";

                string from = "appadmin@kbe.com.kw";
                string to = CXEmail_Str.ToLower().ToString();
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from, "KBE - Online ", System.Text.Encoding.UTF8);
                message.To.Add(to);
                message.Subject = "KBE Online Transaction";
                message.Body = htmlbody;
                message.IsBodyHtml = true;
                var view = AlternateView.CreateAlternateViewFromString(htmlbody, null, "text/html");
                view.LinkedResources.Add(inlineLogo);
                message.AlternateViews.Add(view);

                //string url = "outlook.office.com";
                string SMTPUser = "appadmin@kbe.com.kw";
                string SMTPPwd = "P@ss2019";
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPwd);
                client.Port = 587;
                client.Host = "smtp.office365.com";
                client.EnableSsl = true;
                try
                {
                    client.Send(message);
                }
                catch (Exception gsdf)
                { }

            }
        }
    }
}