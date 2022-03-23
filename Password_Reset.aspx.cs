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
using KBE.Models;
using System.Text.RegularExpressions;

namespace KBE
{
    public partial class Password_Reset : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST UpRestCls = new UpdateREST();
        ResourceManager rm;
        CultureInfo ci;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoginIDTxt.Text = Session["LoginID_CX"].ToString();
                NewPwdTxt.Focus();
            }
            this.LoadLanguage();            

            if (this.NewPwdTxt.Text.Trim().Length > 0)
                this.NewPwdTxt.Attributes.Add("value", this.NewPwdTxt.Text);

            if (this.ConfirmPwdTxt.Text.Trim().Length > 0)
                this.ConfirmPwdTxt.Attributes.Add("value", this.ConfirmPwdTxt.Text);

            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.SubmitBtn));
            this.CancelBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.CancelBtn));
        }
        protected async void SubmitBtn_Click(object sender, EventArgs e)
        {
            string Result = "";
            try
            {
                Result = await UpRestCls.ResetPassword(Session["LoginID_CX"].ToString(), NewPwdTxt.Text.Trim(), ConfirmPwdTxt.Text.Trim());

                string FResult = "";
                try
                {
                    FResult = Result.Substring(0, 5).ToUpper();
                }
                catch (Exception sdf) { }

                if (FResult == "ERROR")
                {
                    this.MessageBox_Error(Result);
                }
                else
                {
                    this.MessageBox_OK(Result);                    
                    this.NewPwdTxt.Text = "";
                    this.ConfirmPwdTxt.Text = "";
                }

            }
            catch (Exception dfgd)
            {
                this.MessageBox_Error(dfgd.ToString());
            }
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            Resetpasswordlbl.Text = rm.GetString("Resetpassword", ci).ToUpper();
            LoginIDlbl.Text = rm.GetString("LoginID", ci);
            ConfirmPwdlbl.Text = rm.GetString("ConfirmPassword", ci) + "*";
            NewPasswordlbl.Text = rm.GetString("NewPassword", ci) + "*";           

            SubmitBtn.Text = rm.GetString("Submit", ci);
            CancelBtn.Text = rm.GetString("Cancel", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }
        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard");
        }

        public void Validation_Messages(string LangType)
        {
            NewPwdTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordnewrequired", LangType);
            NewPwdTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordvalidation", LangType);
            NewPwdTxt_PasswordStrength.TextStrengthDescriptions = CommCls.Messages_Eng_Arabic("REQ_Passwordstrength", LangType);

            ConfirmPwdTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordconfirmrequired", LangType);
            ConfirmPwdTxt_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordconfirmnotmatching", LangType);
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