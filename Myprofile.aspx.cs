using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using KBE.RESTFull;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;
using KBE.Models;

namespace KBE
{
    public partial class Myprofile : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST UpRestCls = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        UpdateREST URest = new UpdateREST();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SecQ1DDL.Items.Insert(0, "Select Question"); SecQ1DDL.SelectedItem.Text = "Select Question";
                SecQ2DDL.Items.Insert(0, "Select Question"); SecQ2DDL.SelectedItem.Text = "Select Question";
                SecQ3DDL.Items.Insert(0, "Select Question"); SecQ3DDL.SelectedItem.Text = "Select Question";
                SecQ4DDL.Items.Insert(0, "Select Question"); SecQ4DDL.SelectedItem.Text = "Select Question";
                this.CXInfo();
                this.LoadDropDowns(Session["Lang"].ToString());
                this.Get_BeneficiaryList();
                                
                this.DynamicLang_Values("Send OTP");
                CounterSpan.Visible = false;
                if (Session["CID_Expiry_S"].ToString().ToLower() == "yes")
                    CIVDUDiv.Visible = true;
                else
                    CIVDUDiv.Visible = false;
                if (Session["DocsUpload_S"].ToString().ToLower() == "yes")
                    SupDocBtn.Visible = true;
                else
                    SupDocBtn.Visible = false;
            }

            if (this.SecQuestionAnswer1Txt.Text.Trim().Length > 0)
                this.SecQuestionAnswer1Txt.Attributes.Add("value", this.SecQuestionAnswer1Txt.Text);

            if (this.SecQuestionAnswer2Txt.Text.Trim().Length > 0)
                this.SecQuestionAnswer2Txt.Attributes.Add("value", this.SecQuestionAnswer2Txt.Text);

            if (this.SecQuestionAnswer3Txt.Text.Trim().Length > 0)
                this.SecQuestionAnswer3Txt.Attributes.Add("value", this.SecQuestionAnswer3Txt.Text);

            if (this.SecQuestionAnswer4Txt.Text.Trim().Length > 0)
                this.SecQuestionAnswer4Txt.Attributes.Add("value", this.SecQuestionAnswer4Txt.Text);

            this.LoadLanguage();
            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.SubmitBtn));
            this.OTPSendBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.OTPSendBtn));
        }

        public void CXInfo()
        {
            DataTable CxDt = new DataTable();
            CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
            if (CxDt.Rows.Count > 0)
            {
                DataRow dr = CxDt.Rows[0];
                CXNamelbl.Text = dr["CUST_NAME_E"].ToString() + " " + dr["CUST_NAME_A"].ToString();
                EmailIDlbl.Text = dr["CUST_EMAIL"].ToString();
                MobileNolbl.Text = dr["CUST_TEL"].ToString();
                CIDTxt.Text = dr["CUST_ID"].ToString() + "<br/>"+CommCls.Messages_Eng_Arabic("Dateofexpiry", Session["Lang"].ToString())+": " + Convert.ToDateTime(dr["CUST_ID_EXP"].ToString()).ToString("dd-MMM-yyyy");
                Addresslbl.Text = "FLAT: " + dr["FLAT_NUM"].ToString() + ", FLOOR: " + dr["FLOOR_NUM"].ToString() + ", BLDG: " +
                    dr["BUILD_NUM"].ToString() + ",<br/> STREET: " + dr["STREET"].ToString() + ", BLOCK: " + dr["BLOCK_NUM"].ToString() + ",<br/>" +
                    dr["CUST_CITY"].ToString() + ", " + dr["CUST_ADDR"].ToString();
                DOBlbl.Text = Convert.ToDateTime(dr["CUST_DOB"].ToString()).ToString("dd-MMM-yyyy");
                Sponsorlbl.Text = dr["SPONSOR_DETAIL"].ToString();
                Salarylbl.Text = dr["SALARY_RANGE"].ToString();
            }
        }
        public void Get_BeneficiaryList()
        {
            string Fav_BenfStr = "";
            DataTable BenfDt = new DataTable();
            BenfDt = RestCls.BeneficiaryList(Session["LoginID_CX"].ToString());
            if (BenfDt.Rows.Count > 0)
            {
                DataTable BenfFilterDt = new DataTable();
                DataView BenfDv = new DataView(BenfDt);
                BenfDv.RowFilter = "FAV_BNF = 1 AND ENABLED_BNF=1";
                BenfFilterDt = BenfDv.ToTable();
                if (BenfFilterDt.Rows.Count > 0)
                {
                    int BCNT = 1;
                    for (int i = 0; i < BenfFilterDt.Rows.Count; i++)
                    {
                        DataRow bdr = BenfFilterDt.Rows[i];
                        if (BCNT <= 2)
                        {
                            Fav_BenfStr += bdr["BEN_NAME"].ToString() + "<br/>";
                            BCNT++;
                        }
                    }
                }
            }
            FavBenfNamelbl.Text = Fav_BenfStr.ToString();

        }
        
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            MyProfilelbl_P.Text = rm.GetString("MyProfile", ci);
            civilidlbl.Text = rm.GetString("CivilID", ci);
            addresslbl_P.Text = rm.GetString("Address", ci);
            favoritebeneflbl_P.Text = rm.GetString("Favoritebeneficiary", ci);
            dateofbirthlbl.Text = rm.GetString("DateOfBirth", ci);
            Loyalitypointslbl.Text = rm.GetString("Balanceloyalitypoints", ci);
            SecQHeadlbl.Text = rm.GetString("SecurityQuestion", ci);
            SubmitBtn.Text = rm.GetString("Update", ci);
            SMSRadlbl.InnerText = rm.GetString("SendOTPMobile", ci);
            EmailRadlbl.InnerText = rm.GetString("SendOTPEmail", ci);
            OTPTxt.Attributes.Add("placeholder", rm.GetString("EnterOTP", ci));

            UploadCIDlbl.InnerText = rm.GetString("UploadCID", ci);
            SupDocBtn.InnerText = rm.GetString("Uploadsupportingdocs", ci);

            this.Validation_Messages(Session["Lang"].ToString());
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
                    string QID1 = "", QID2 = "", QID3 = "", QID4 = "";
                    string QAns1 = "", QAns2 = "", QAns3 = "", QAns4 = "";
                    QID1 = SecQ1DDL.SelectedValue;
                    QID2 = SecQ2DDL.SelectedValue;
                    QID3 = SecQ3DDL.SelectedValue;
                    QID4 = SecQ4DDL.SelectedValue;
                    QAns1 = SecQuestionAnswer1Txt.Text.Trim();
                    QAns2 = SecQuestionAnswer2Txt.Text.Trim();
                    QAns3 = SecQuestionAnswer3Txt.Text.Trim();
                    QAns4 = SecQuestionAnswer4Txt.Text.Trim();
                    string SecResult1 = await URest.SecurityQuestionUpdate(LoginID, QID1, QAns1);
                    string SecResult2 = await URest.SecurityQuestionUpdate(LoginID, QID2, QAns2);
                    string SecResult3 = await URest.SecurityQuestionUpdate(LoginID, QID3, QAns3);
                    string SecResult4 = await URest.SecurityQuestionUpdate(LoginID, QID4, QAns4);

                    string FResult = "";
                    try
                    {
                        FResult = SecResult1.Substring(0, 5).ToUpper();
                    }
                    catch (Exception sdf) { }

                    if (FResult == "ERROR")
                    {
                        MessageBox_Error(SecResult1);
                    }
                    else
                    {
                        SMSRad.Checked = false;
                        EmailRad.Checked = false;
                        OTPTxt.Text = "";                        
                        this.DynamicLang_Values("Send OTP");
                        CounterSpan.Visible = false;
                        this.MessageBox_OK(CommCls.Messages_Eng_Arabic("MSG_SecurityQAupdatedsuccessfully", Session["Lang"].ToString()));
                    }
                }

            }
            catch (Exception dfgd)
            {
                this.MessageBox_Error(dfgd.ToString());
            }




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

        public void MessageBox_OK(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>SuccessMsg('" + msg + "');</script>", false);
        }
        public void MessageBox_Error(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>ErrorMsg('" + msg + "');</script>", false);
        }

        public void ValidateSecurity(string PageNameStr)
        {
            if (Session["SecQuestionValidated_S"].ToString() == "")
            {
                Session["GoBackPage_S"] = PageNameStr;
                Response.Redirect("Validate");
            }
        }
        public void LoadDropDowns(string LangType)
        {
            //Security Q1
            SecQ1DDL.Items.Clear();
            SecQ1_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ1DDL.DataTextField = "QUESTION";
            else
                SecQ1DDL.DataTextField = "QUESTION_AR";
            SecQ1DDL.DataValueField = "QUES_ID";
            SecQ1DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ1DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

            //Security Q2
            SecQ2DDL.Items.Clear();
            SecQ1_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ2DDL.DataTextField = "QUESTION";
            else
                SecQ2DDL.DataTextField = "QUESTION_AR";
            SecQ2DDL.DataValueField = "QUES_ID";
            SecQ2DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ2DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

            //Security Q3
            SecQ3DDL.Items.Clear();
            SecQ2_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ3DDL.DataTextField = "QUESTION";
            else
                SecQ3DDL.DataTextField = "QUESTION_AR";
            SecQ3DDL.DataValueField = "QUES_ID";
            SecQ3DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ3DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

            //Security Q4
            SecQ4DDL.Items.Clear();
            SecQ2_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ4DDL.DataTextField = "QUESTION";
            else
                SecQ4DDL.DataTextField = "QUESTION_AR";
            SecQ4DDL.DataValueField = "QUES_ID";
            SecQ4DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ4DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

        }
        public void Validation_Messages(string LangType)
        {
            SecQ1DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ1DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ1Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);

            SecQ2DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ2DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ2Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);
            SecQ2DDL_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestion1and2shouldnotbesame", LangType);

            SecQ3DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ3DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ3Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);

            SecQ4DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ4DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ4Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);
            SecQ4DDL_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestion3and4shouldnotbesame", LangType);

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
    }
}