using KBE.Models;
using KBE.RESTFull;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KBE
{
    public partial class OTPValidate : System.Web.UI.Page
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
                PayingAmtTxt.Text = Session["PayingAmt_OTP_S"].ToString();
                CounterSpan.Visible = false;
                this.DynamicLang_Values("Send OTP");                
                this.LoadLanguage();
            }
            this.OTPValidateBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.OTPValidateBtn));
            this.OTPSendBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.OTPSendBtn));
        }

        protected async void OTPValidateBtn_Click(object sender, EventArgs e)
        {
            string Result = "", OTPType = "";
            if (SMSRad.Checked == true)
                OTPType = "MB";
            else if (EmailRad.Checked == true)
                OTPType = "EM";
            try
            {
                Result = await UpRestCls.ValidateOTP(Session["LoginID_CX"].ToString(), OTPType, OTPTxt.Text.Trim());

                if (Result != "1")
                {
                    this.MessageBox_Error(Result);
                }
                else
                {
                    Session["TrackIDSession"] = CommCls.TimeZoneDateTime().ToString("ddMMyyyyhhmmss");
                    Session["PayRemarksSession"] = "";
                    Response.Redirect("Payment.aspx?PaidAmt=" + PayingAmtTxt.Text.Trim());
                }

            }
            catch (Exception dfgd)
            {
                this.MessageBox_Error(dfgd.ToString());
            }

        }
        protected async void OTPSendBtn_Click(object sender, EventArgs e)
        {
            string Result = "", OTPType = "";
            if (SMSRad.Checked == true)
                OTPType = "MB";
            else if (EmailRad.Checked == true)
                OTPType = "EM";

            if (InitiSecs_HD.Value != "")
            {

            }
            else if (SMSRad.Checked == false && EmailRad.Checked == false)
            {
                this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_PleasechoosemethodtoreceiveOTP", Session["Lang"].ToString()));
            }
            else
            {
                try
                {
                    Result = await UpRestCls.GetOTP(Session["LoginID_CX"].ToString(), OTPType);

                    bool IsDigitSts = false;
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

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            OTPSendBtn.Text = rm.GetString("SendOTP", ci);
            OTPValidateBtn.InnerText = rm.GetString("Submit", ci);
            OtpHlbl.InnerText = rm.GetString("OTPVerificationforPayment", ci);
            sourceofincomelbl.InnerText = rm.GetString("Totalpayingamtkd", ci) + "*";
            SMSRadlbl.InnerText = rm.GetString("SendOTPMobile", ci);
            EmailRadlbl.InnerText = rm.GetString("SendOTPEmail", ci);

            OTPTxt.Attributes.Add("placeholder", rm.GetString("EnterhereceivedOTP", ci));

            this.Validation_Messages(Session["Lang"].ToString());
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

        public void Validation_Messages(string LangType)
        {
            OTPTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_PleaseenterOTP", LangType);
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