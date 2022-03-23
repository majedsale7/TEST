using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBE.RESTFull;
using System.Data;
using KBE.Models;

namespace KBE
{
    public partial class Password : System.Web.UI.Page
    {
        RESTClass RestCls = new RESTClass();
        UpdateREST UPRestCls = new UpdateREST();
        CommonClass ComCls = new CommonClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Lang"] == null)
                {
                    Session["Lang"] = "en-US";
                }
                PWDTxt.Focus();
                this.LoadLanguage();
            }

        }

        protected async void LoginBtn_Click(object sender, EventArgs e)
        {
            string Result = "";
            string[] CXInfo = new string[10];
            Session["CID_Expiry_S"] = "";
            Session["PopupMsg_S"] = "";
            Session["DocsUpload_S"] = "";

            Result = await UPRestCls.ValidateCX(Session["LoginID_CX"].ToString(), PWDTxt.Text.Trim());
            CXInfo = Result.Split('|');

            string LoginStr = "", CXNameStr = "", LastLoginTimeStr = "", CIDExpiryStr = "", PopupMsg = "", DocsUploadStr = "";

            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    string[] Split_S = CXInfo[i].Split('=');

                    if (Split_S[0].ToString() == "SUCCESS")
                        LoginStr = Split_S[1].ToString();
                    if (Split_S[0].ToString() == "NAME")
                        CXNameStr = Split_S[1].ToString();
                    if (Split_S[0].ToString() == "DATETIME")
                        LastLoginTimeStr = Split_S[1].ToString();
                    if (Split_S[0].ToString() == "CIVIL_ID_EXPIRED")
                        CIDExpiryStr = Split_S[1].ToString();
                    if (Split_S[0].ToString() == "POPUP_MSG")
                        PopupMsg = Split_S[1].ToString();
                    if (Split_S[0].ToString() == "DOC_UPLOAD_ENABLED")
                        DocsUploadStr = Split_S[1].ToString();
                }
                catch (Exception dfg) { }

            }


            if (LoginStr == "1")
            {

                string LLUpsts = await UPRestCls.LastLoginUpdate(Session["LoginID_CX"].ToString());
                Session["CxName_S"] = CXNameStr.ToString();
                Session["LastLogin_S"] = LastLoginTimeStr.ToString();
                Session["CX_CURR_CODE_S"] = "";
                DataTable CxDt = new DataTable();
                CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
                if (CxDt.Rows.Count > 0)
                {
                    DataRow dr = CxDt.Rows[0];
                    Session["CX_CURR_CODE_S"] = dr["CURR_CODE"].ToString();
                }

                Session["CID_Expiry_S"] = CIDExpiryStr.ToString();
                Session["PopupMsg_S"] = PopupMsg.ToString();
                Session["DocsUpload_S"] = DocsUploadStr.ToString();                

                Session["UserSessionID_S"] = HttpContext.Current.Session.SessionID;
                Session["UserMachineIP_S"] = ComCls.GetIPAddress();

                string LoginTrackSts = await UPRestCls.LoginSessionTracking(Session["LoginID_CX"].ToString(), Session["UserSessionID_S"].ToString(), Session["UserMachineIP_S"].ToString());

                Response.Redirect("Dashboard");
            }
            else
            {
                Errorlbl.Text = CXInfo[0].ToString();                
            }
        }

        protected void LanguageBtn_Click(object sender, EventArgs e)
        {
            if (LanguageBtn.InnerText != "English")
            {
                LanguageBtn.InnerText = "English";
                Session["Lang"] = "ar-KW";
                LanguageBtn.Style.Add("class", "dropdown-toggle button inline-block bg-theme-1 text-white");
            }
            else if (LanguageBtn.InnerText == "English")
            {
                LanguageBtn.InnerText = "عربى";
                Session["Lang"] = "en-US";
                LanguageBtn.Style.Add("class", "dropdown-toggle button inline-block bg-theme-1 text-white language_ar");
            }
            this.LoadLanguage();
        }
        public void LoadLanguage()
        {
            if (Session["Lang"].ToString() == "en-US")
                LanguageBtn.InnerText = "عربى";
            else
                LanguageBtn.InnerText = "English";
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            Signinlbl.Text = rm.GetString("Signin", ci);
            LoginBtn.Text = rm.GetString("Login", ci);
            ForgotPwdlbl.Text = rm.GetString("ForgotPasswordQ", ci);
            PWDTxt.Attributes.Add("placeholder", rm.GetString("Password", ci));

            Signintolbl.Text = rm.GetString("Signintoyouraccount", ci);
            Manageyourremmilbl.Text = rm.GetString("Manageyourremittances", ci);
        }

        public void MessageBox_OK(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>SuccessMsg('" + msg + "');</script>", false);
        }
        public void MessageBox_Error(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>ErrorMsg('" + msg + "');</script>", false);
        }
    }
}