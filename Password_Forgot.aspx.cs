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
using System.Data;

namespace KBE
{
    public partial class Password_Forgot : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST UpRestCls = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        CultureInfo ci;
        ResourceManager rm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Lang"] == null)
                {
                    Session["Lang"] = "en-US";
                }
                if (Session["LoginID_CX"].ToString() != null)
                    LoginIDTxt.Text = Session["LoginID_CX"].ToString();
                else
                    LoginIDTxt.Focus();
                SMSRad.Checked = false;
                EmailRad.Checked = false;
                OTPTxt.Text = "";
                CounterSpan.Visible = false;
                Counterlbl.InnerText = "0";
                this.LoadLanguage();
                this.DynamicLang_Values("Send OTP");
            }

            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.SubmitBtn));
            this.OTPSendBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.OTPSendBtn));
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

            Forgotpwdlbl.Text = rm.GetString("ForgotPassword", ci);
            Loginlbl.Text = rm.GetString("Login", ci);
            SubmitBtn.Text = rm.GetString("Submit", ci);
            Signintolbl.Text = rm.GetString("Signintoyouraccount", ci);
            Manageyourremmilbl.Text = rm.GetString("Manageyourremittances", ci);
            SMSRadlbl.InnerText = rm.GetString("SendOTPMobile", ci);
            EmailRadlbl.InnerText = rm.GetString("SendOTPEmail", ci);

            OTPTxt.Attributes.Add("placeholder", rm.GetString("EnterhereceivedOTP", ci));

            this.Validation_Messages(Session["Lang"].ToString());
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
        protected async void SubmitBtn_Click(object sender, EventArgs e)
        {
            string LoginID = Session["LoginID_CX"].ToString();

            string Result = "", OTPType = "";
            if (SMSRad.Checked == true)
                OTPType = "MB";
            else if (EmailRad.Checked == true)
                OTPType = "EM";
            try
            {
                Result = await UpRestCls.ValidateOTP(LoginID, OTPType, OTPTxt.Text.Trim());
                
                if (Result != "1")
                {
                    this.MessageBox_Error(Result);
                }
                else
                {
                    try
                    {
                        Result = await UpRestCls.ResetPassword(LoginIDTxt.Text.Trim(), NewPwdTxt.Text.Trim(), ConfirmPwdTxt.Text.Trim());

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

                            SubmitBtn.Enabled = false;
                            SMSRad.Checked = false;
                            EmailRad.Checked = false;
                            OTPTxt.Text = "";                            
                            this.DynamicLang_Values("Send OTP");
                            CounterSpan.Visible = false;
                        }

                    }
                    catch (Exception dfgd)
                    {
                        this.MessageBox_Error(dfgd.ToString());
                    }
                }
            }
            catch (Exception dfg) { this.MessageBox_Error(dfg.ToString()); }
        }
        protected async void OTPSendBtn_Click(object sender, EventArgs e)
        {
            if (InitiSecs_HD.Value != "")
            {

            }
            else if (OTPTxt.Text.Trim() == "" && SMSRad.Checked == false && EmailRad.Checked == false)
            {
                this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_PleasechoosemethodtoreceiveOTP", Session["Lang"].ToString()));
            }
            else if (OTPTxt.Text.Trim() != "" && SMSRad.Checked == false && EmailRad.Checked == false)
            {
                this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_PleasechoosemethodyoureceivedOTP", Session["Lang"].ToString()));
            }
            else if (OTPTxt.Text.Trim() == "" && (SMSRad.Checked == true || EmailRad.Checked == true)) //Send OTP
            {

                string Result = "", OTPType = "";
                if (SMSRad.Checked == true)
                    OTPType = "MB";
                else if (EmailRad.Checked == true)
                    OTPType = "EM";
                try
                {
                    Result = await UpRestCls.GetOTP(Session["LoginID_CX"].ToString(), OTPType);                    

                    bool IsDigitSts;
                    IsDigitSts = CommCls.IsDigitsOnly(Result);

                    if (IsDigitSts == false)
                    {
                        this.MessageBox_Error(Result);
                    }
                    else
                    {
                        if (OTPType.ToString() == "MB")
                        {
                            string CXMobileNo = "";
                            DataTable CxDt = new DataTable();
                            CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
                            if (CxDt.Rows.Count > 0)
                            {
                                DataRow dr = CxDt.Rows[0];
                                CXMobileNo = "965" + dr["CUST_TEL"].ToString();
                            }

                            string SMSResult = "", SMSMsg = "", LangIDStr = "";

                            if (Session["Lang"].ToString() == "en-US")
                                LangIDStr = "1";
                            else
                                LangIDStr = "2";

                            if (LangIDStr.ToString() == "1")
                            {
                                SMSMsg += "Dear KBE Customer,\n";
                                SMSMsg += "OTP: " + Result + "\n";
                                SMSMsg += "Please DO NOT DISCLOSE this OTP to anyone.\n";
                                SMSMsg += "Thank you for using KBE Online Services.\n";
                                SMSMsg += CommCls.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
                            }
                            else
                            {
                                SMSMsg += "\n عزيزي عميل KBE ،";
                                SMSMsg += "\n " + Result + " :OTP ";
                                SMSMsg += "\n يرجى عدم الكشف عن كلمة المرور لمرة واحدة لأي شخص.";
                                SMSMsg += "\n شكرا لك على استخدام خدمات KBE. ";
                                SMSMsg += CommCls.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
                            }
                            SMSResult = RestCls.SendSMS(LangIDStr, CXMobileNo, SMSMsg);                            

                            string Result_SMS = "";
                            try
                            {
                                Result_SMS = SMSResult.Substring(0, 2).ToUpper();
                            }
                            catch (Exception sdf) { }

                            if (Result_SMS.ToString() == "OK")
                            {
                                this.MessageBox_OK(CommCls.Messages_Eng_Arabic("MSG_SMShasbeensenttoyourregmobileno", Session["Lang"].ToString()));
                            }
                            else
                            {
                                this.MessageBox_Error(SMSResult);
                            }
                        }
                        else
                        {
                            this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_emailhasbeensenttoyourregemailid", Session["Lang"].ToString()));
                        }
                        
                        this.DynamicLang_Values("Resend OTP");
                        CounterSpan.Visible = true;
                        Counterlbl.InnerText = "0";
                        InitiSecs_HD.Value = "120";

                    }

                }
                catch (Exception dfgd)
                {
                    this.MessageBox_Error(dfgd.ToString());
                }
            }
        }
        public void Validation_Messages(string LangType)
        {
            NewPwdTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordnewrequired", LangType);
            NewPwdTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordvalidation", LangType);
            NewPwdTxt_PasswordStrength.TextStrengthDescriptions = CommCls.Messages_Eng_Arabic("REQ_Passwordstrength", LangType);

            ConfirmPwdTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordconfirmrequired", LangType);
            ConfirmPwdTxt_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordconfirmnotmatching", LangType);

            OTPTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_OTPRequired", LangType);
        }
        public void DynamicLang_Values(string OTPBtnValue)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            if (OTPBtnValue.ToString() == "Send OTP")
                OTPSendBtn.Text = rm.GetString("SendOTP", ci);
            else if (OTPBtnValue.ToString() == "Resend OTP")
                OTPSendBtn.Text = rm.GetString("ResendOTP", ci);
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