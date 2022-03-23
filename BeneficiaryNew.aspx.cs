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
using System.Threading.Tasks;

namespace KBE
{
    public partial class BeneficiaryNew : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST URest = new UpdateREST();
        UpdateREST UpRestCls = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {              
                if (Session["CID_Expiry_S"].ToString().ToLower() == "yes")
                {
                    Response.Redirect("CIDUpload");
                }
                this.DynamicLang_Values("Send OTP");
                CounterSpan.Visible = false;
                this.LoadLanguage();
                this.Load_DropDowns(Session["Lang"].ToString());

                CountryDDL.Focus();
            }

            if (this.OTPTxt.Text.Trim().Length > 0)
                this.OTPTxt.Attributes.Add("value", this.OTPTxt.Text.Trim());

            AnyBranchlbl.InnerText = CommCls.Messages_Eng_Arabic("Enteranykeywordtosearch", Session["Lang"].ToString());
            Searchbankbranchlbl.Text = CommCls.Messages_Eng_Arabic("Searchbankbranch", Session["Lang"].ToString());
            BranchSearchBtn.Text = CommCls.Messages_Eng_Arabic("Search", Session["Lang"].ToString());

            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.SubmitBtn));
            this.ClearBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.ClearBtn));
            this.BranchSearchBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.BranchSearchBtn));            
        }

        protected void CountryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Currency
            CurrencyDDL.Items.Clear();            
            if (CountryDDL.SelectedItem.Text != "")
                CurrencyBS_ODS.SelectParameters[0].DefaultValue = CountryDDL.SelectedValue.ToString();
            else
                CurrencyBS_ODS.SelectParameters[0].DefaultValue = "0";
            CurrencyBS_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                CurrencyDDL.DataTextField = "CURR_NAME_EN";
            else
                CurrencyDDL.DataTextField = "CURR_NAME_AR";
            CurrencyDDL.DataValueField = "CURR_ID";
            //CurrencyDDL.Items.Insert(0, "Currency"); CurrencyDDL.SelectedItem.Text = "Currency";
            CurrencyDDL.Items.Insert(0, ""); CurrencyDDL.SelectedItem.Text = "";

            //Transfer Type
            TransferTypeDDL.Items.Clear();
            TransferTypeBS_ODS.SelectParameters[0].DefaultValue = "0";
            TransferTypeBS_ODS.SelectParameters[1].DefaultValue = "0";
            TransferTypeBS_ODS.DataBind();
            //TransferTypeDDL.Items.Insert(0, "Transfer Type"); TransferTypeDDL.SelectedItem.Text = "Transfer Type";
            TransferTypeDDL.Items.Insert(0, ""); TransferTypeDDL.SelectedItem.Text = "";
        }

        protected void CurrencyDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Account Types
            AccountTypeDDL.Items.Clear();            
            if (CurrencyDDL.SelectedItem.Text != "")
                AccountType_ODS.SelectParameters[0].DefaultValue = CurrencyDDL.SelectedValue.ToString();
            else
                AccountType_ODS.SelectParameters[0].DefaultValue = "0";
            AccountType_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                AccountTypeDDL.DataTextField = "TYPE_DESC";
            else
                AccountTypeDDL.DataTextField = "TYPE_DESC_AR";
            AccountTypeDDL.DataValueField = "TYPE_ID";            
            AccountTypeDDL.Items.Insert(0, ""); AccountTypeDDL.SelectedItem.Text = "";


            //Transfer Type
            TransferTypeDDL.Items.Clear();            
            if (CurrencyDDL.SelectedItem.Text != "" && CountryDDL.SelectedItem.Text != "")
            {
                TransferTypeBS_ODS.SelectParameters[0].DefaultValue = CountryDDL.SelectedValue.ToString();
                TransferTypeBS_ODS.SelectParameters[1].DefaultValue = CurrencyDDL.SelectedValue.ToString();
            }
            else
            {
                TransferTypeBS_ODS.SelectParameters[0].DefaultValue = "0";
                TransferTypeBS_ODS.SelectParameters[1].DefaultValue = "0";
            }
            TransferTypeBS_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                TransferTypeDDL.DataTextField = "DESC_E";
            else
                TransferTypeDDL.DataTextField = "DESC_A";
            TransferTypeDDL.DataValueField = "LOOKUP_ID";            
            TransferTypeDDL.Items.Insert(0, ""); TransferTypeDDL.SelectedItem.Text = "";


        }
        protected void TransferTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bank List
            BankDDL.Items.Clear();            
            if (CurrencyDDL.SelectedItem.Text != "" && TransferTypeDDL.SelectedItem.Text != "")
            {
                Banks_ODS.SelectParameters[0].DefaultValue = CountryDDL.SelectedValue.ToString();
                Banks_ODS.SelectParameters[1].DefaultValue = CurrencyDDL.SelectedValue.ToString();
                Banks_ODS.SelectParameters[2].DefaultValue = TransferTypeDDL.SelectedValue.ToString();
            }
            else
            {
                Banks_ODS.SelectParameters[0].DefaultValue = "0";
                Banks_ODS.SelectParameters[1].DefaultValue = "0";
                Banks_ODS.SelectParameters[2].DefaultValue = "0";
            }
            Banks_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                BankDDL.DataTextField = "BANK_NAME_EN";
            else
                BankDDL.DataTextField = "BANK_NAME_AR";
            BankDDL.DataValueField = "BANK_ID";            
            BankDDL.Items.Insert(0, ""); BankDDL.SelectedItem.Text = "";
            BankBranchTxt.Text = "";

            if (TransferTypeDDL.SelectedValue == "CASH")
            {
                AccountNoTxt.ReadOnly = true;
                AccountNoTxt.Text = " ";

                AccountTypeDDL.Items.Clear();                
                if (CurrencyDDL.SelectedItem.Text != "")
                    AccountType_ODS.SelectParameters[0].DefaultValue = CurrencyDDL.SelectedValue.ToString();
                else
                    AccountType_ODS.SelectParameters[0].DefaultValue = "0";
                AccountType_ODS.DataBind();
                if (Session["Lang"].ToString() == "en-US")
                    AccountTypeDDL.DataTextField = "TYPE_DESC";
                else
                    AccountTypeDDL.DataTextField = "TYPE_DESC_AR";
                AccountTypeDDL.DataValueField = "TYPE_ID";                

                AccountTypeDDL.SelectedValue = "3";
                AccountTypeDDL.Attributes.Add("disabled", "true");
            }
            else
            {
                AccountNoTxt.ReadOnly = false;
                AccountNoTxt.Text = "";

                AccountTypeDDL.Items.Clear();
                if (CurrencyDDL.SelectedItem.Text != "")
                    AccountType_ODS.SelectParameters[0].DefaultValue = CurrencyDDL.SelectedValue.ToString();
                else
                    AccountType_ODS.SelectParameters[0].DefaultValue = "0";
                AccountType_ODS.DataBind();

                if (Session["Lang"].ToString() == "en-US")
                    AccountTypeDDL.DataTextField = "TYPE_DESC";
                else
                    AccountTypeDDL.DataTextField = "TYPE_DESC_AR";
                AccountTypeDDL.DataValueField = "TYPE_ID";
                AccountTypeDDL.DataBind();

                AccountTypeDDL.Items.Insert(0, ""); AccountTypeDDL.SelectedItem.Text = "";

                AccountTypeDDL.Items.Remove(AccountTypeDDL.Items.FindByValue("3")); //Remove Cash Credit

                AccountTypeDDL.Attributes.Remove("disabled");
            }
        }
        protected void BankDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bank Branches           
            ViewState["BankBranchCode_V"] = "";
            BankBranchTxt.Text = "";
            BankBranchTxt.Focus();
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            this.ClearFields();
        }
        protected async void SubmitBtn_Click(object sender, EventArgs e)
        {
            string LoginID = Session["LoginID_CX"].ToString();

            string Result_OTP = "", OTPType = "";
            if (SMSRad.Checked == true)
                OTPType = "MB";
            else if (EmailRad.Checked == true)
                OTPType = "EM";


            Result_OTP = await UpRestCls.ValidateOTP(LoginID, OTPType, ViewState["OTPSent_V"].ToString());

            if (Result_OTP != "1")
            {
                this.MessageBox_Error(Result_OTP);
            }
            else
            {
                string LoginID_S = "", CountryID_S = "", BenefName_S = "", TransferType_S = "", BankAcctNo_S = "";
                string CurrencyID_S = "", BankID_S = "", BankBranch_S = "", AccountType_S = "", Nationality_S = "";
                string BenefCIDNo_S = "", MobileNo_S = "", Address1_S = "", Address2_S = "", CityStr_S = "", Relationship_S = "";

                LoginID_S = Session["LoginID_CX"].ToString();
                CountryID_S = CountryDDL.SelectedValue;
                BenefName_S = BenefNameTxt.Text.Trim();
                TransferType_S = TransferTypeDDL.SelectedValue;
                BankAcctNo_S = AccountNoTxt.Text.Trim();
                CurrencyID_S = CurrencyDDL.SelectedValue;
                BankID_S = BankDDL.SelectedValue;                
                BankBranch_S = ViewState["BankBranchCode_V"].ToString();
                AccountType_S = AccountTypeDDL.SelectedValue;
                Nationality_S = NationalityDDL.SelectedValue;
                BenefCIDNo_S = BenefIDNoTxt.Text.Trim();
                MobileNo_S = MobileNoTxt.Text.Trim();
                Address1_S = Address1Txt.Text.Trim();
                Address2_S = Address2Txt.Text.Trim();
                CityStr_S = CityTxt.Text.Trim();
                Relationship_S = RelationDDL.SelectedValue;

                string Result = await URest.NewBeneficiary(LoginID_S, CountryID_S, BenefName_S, TransferType_S, BankAcctNo_S,
                    CurrencyID_S, BankID_S, BankBranch_S, AccountType_S, Nationality_S, BenefCIDNo_S, MobileNo_S, Address1_S,
                    Address2_S, CityStr_S, Relationship_S);                

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
                    this.ClearFields();

                }
            }

        }
        public void ClearFields()
        {
            CountryDDL.SelectedIndex = 0;
            CurrencyDDL.SelectedIndex = 0;
            BenefNameTxt.Text = "";
            TransferTypeDDL.SelectedIndex = 0;
            AccountNoTxt.Text = "";
            NationalityDDL.SelectedIndex = 0;
            BenefIDNoTxt.Text = "";
            MobileNoTxt.Text = "";
            Address1Txt.Text = "";
            Address2Txt.Text = "";
            CityTxt.Text = "";
            RelationDDL.SelectedIndex = 0;


            CurrencyDDL.Items.Clear();
            CurrencyBS_ODS.SelectParameters[0].DefaultValue = "0";
            CurrencyBS_ODS.DataBind();            
            CurrencyDDL.Items.Insert(0, ""); CurrencyDDL.SelectedItem.Text = "";

            AccountTypeDDL.Items.Clear();
            AccountType_ODS.SelectParameters[0].DefaultValue = "0";
            AccountType_ODS.DataBind();            
            AccountTypeDDL.Items.Insert(0, ""); AccountTypeDDL.SelectedItem.Text = "";
            AccountTypeDDL.Attributes.Remove("disabled");

            BankDDL.Items.Clear();
            Banks_ODS.SelectParameters[0].DefaultValue = "0";
            Banks_ODS.SelectParameters[1].DefaultValue = "0";
            Banks_ODS.DataBind();            
            BankDDL.Items.Insert(0, ""); BankDDL.SelectedItem.Text = "";

            BankBranchTxt.Text = "";            

            SMSRad.Checked = false;
            EmailRad.Checked = false;
            OTPTxt.Text = "";            
            this.DynamicLang_Values("Send OTP");
            OTPTxt.Attributes.Add("disabled", "false");
            CounterSpan.Visible = false;
            this.OTPTxt.Attributes.Add("value", "");
            OTPSendBtn.Visible = true;
            OTPTxt.Attributes.Remove("disabled");
        }
        protected void BranchSearchBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>SetSearchKey();</script>", false);
            string SearchKey = BankBranchSearchKey_HD.Value;
            DataTable BranchDt = new DataTable();
            BranchDt = RestCls.BanksBranchList_BenefBySearch(BankDDL.SelectedValue, SearchKey);            
            BranchListGV.DataSource = BranchDt;
            BranchListGV.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>ShowBranchSearch();</script>", false);
        }
        protected void BranchListGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string BranchCodeStr = BranchListGV.DataKeys[e.RowIndex].Values["BEN_BRN_CODE"].ToString();
            string BranchNameStr = BranchListGV.DataKeys[e.RowIndex].Values["BRN_NAME"].ToString();
            BankBranchTxt.Text = BranchNameStr.ToString();            
            ViewState["BankBranchCode_V"] = BranchCodeStr.ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>HideBranchSearch();</script>", false);
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            AddBeneflbl.Text = rm.GetString("AddBeneficiary", ci);
            countrylbl.InnerText = rm.GetString("CountryName", ci) + "*";

            currencylbl.InnerText = rm.GetString("Currency", ci) + "*";
            benefnamelbl.InnerText = rm.GetString("BeneficiaryName", ci) + "*";
            transfertypelbl.InnerText = rm.GetString("TransferType", ci) + "*";
            accountnolbl.InnerText = rm.GetString("AccountNumber", ci) + "*";
            accounttypelbl.InnerText = rm.GetString("BankAccountType", ci) + "*";
            banknamelbl.InnerText = rm.GetString("Bank", ci) + "*";
            branchlbl.InnerText = rm.GetString("BankBranch", ci) + "*";
            nationalitylbl.InnerText = rm.GetString("Nationality", ci) + "*";
            beneifidnolbl.InnerText = rm.GetString("BeneficiaryIDNo", ci);
            mobilenolbl.InnerText = rm.GetString("MobileNo", ci);
            address1lbl.InnerText = rm.GetString("Address", ci) + " 1";
            address2lbl.InnerText = rm.GetString("Address", ci) + " 2";
            citylbl.InnerText = rm.GetString("City", ci);
            relationshipbeneflbl.InnerText = rm.GetString("Relationshiptobeneficiary", ci) + "*";

            SMSRadlbl.InnerText = rm.GetString("SendOTPMobile", ci);
            EmailRadlbl.InnerText = rm.GetString("SendOTPEmail", ci);
            OTPTxt.Attributes.Add("placeholder", rm.GetString("EnterOTP", ci));

            ClearBtn.Value = rm.GetString("Clear", ci);
            SubmitBtn.Value = rm.GetString("Submit", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }
        public void Load_DropDowns(string LangType)
        {
            //Country
            CountryDDL.Items.Clear();
            CountryBS_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                CountryDDL.DataTextField = "COUN_NAME";
            else
                CountryDDL.DataTextField = "COUN_NAME_AR";
            CountryDDL.DataValueField = "COUN_CODE3";
            //CountryDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectcountry", LangType)); CountryDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectcountry", LangType);
            CountryDDL.Items.Insert(0, ""); CountryDDL.SelectedItem.Text = "";

            //CurrencyDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Currency", LangType)); CurrencyDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Currency", LangType);
            CurrencyDDL.Items.Insert(0, ""); CurrencyDDL.SelectedItem.Text = "";

            //Account Type
            //AccountTypeDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Select", LangType)); AccountTypeDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Select", LangType);            
            AccountTypeDDL.Items.Clear();
            if (CurrencyDDL.SelectedItem.Text != "")
                AccountType_ODS.SelectParameters[0].DefaultValue = CurrencyDDL.SelectedValue.ToString();
            else
                AccountType_ODS.SelectParameters[0].DefaultValue = "0";
            AccountType_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                TransferTypeDDL.DataTextField = "DESC_E";
            else
                TransferTypeDDL.DataTextField = "DESC_A";
            TransferTypeDDL.DataValueField = "LOOKUP_ID";

            AccountTypeDDL.Items.Insert(0, ""); AccountTypeDDL.SelectedItem.Text = "";

            // AccountTypeDDL.DataBind();


            //Bank 
            //BankDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectbank", LangType)); BankDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectbank", LangType);
            BankDDL.Items.Insert(0, ""); BankDDL.SelectedItem.Text = "";

            //Nationality
            NationalityDDL.Items.Clear();
            Country_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                NationalityDDL.DataTextField = "COUN_NAME";
            else
                NationalityDDL.DataTextField = "COUN_NAME_AR";
            NationalityDDL.DataValueField = "COUN_CODE3";
            NationalityDDL.Items.Insert(0, ""); NationalityDDL.SelectedItem.Text = "";


            //Transfer Type
            TransferTypeDDL.Items.Clear();
            TransferTypeBS_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                TransferTypeDDL.DataTextField = "DESC_E";
            else
                TransferTypeDDL.DataTextField = "DESC_A";
            TransferTypeDDL.DataValueField = "LOOKUP_ID";
            //TransferTypeDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("TransferType", LangType)); TransferTypeDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("TransferType", LangType);
            TransferTypeDDL.Items.Insert(0, ""); TransferTypeDDL.SelectedItem.Text = "";

            //Relation
            RelationDDL.Items.Clear();
            Relations_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                RelationDDL.DataTextField = "DESC_E";
            else
                RelationDDL.DataTextField = "DESC_A";
            RelationDDL.DataValueField = "LOOKUP_ID";
            //RelationDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Select", LangType)); RelationDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Select", LangType);
            RelationDDL.Items.Insert(0, ""); RelationDDL.SelectedItem.Text = "";
        }
        public void Validation_Messages(string LangType)
        {
            BenefNameTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Beneficiaryrequired", LangType);
            BenefNameTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidbenefname", LangType);

            CountryDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Countryrequired", LangType);
            //CountryDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectcountry", LangType);

            CurrencyDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Currencyrequired", LangType);
            //CurrencyDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Currency", LangType);

            TransferTypeDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Transfertyperequired", LangType);
            //TransferTypeDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("TransferType", LangType);

            AccountTypeDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Accounttyperequired", LangType);
            //AccountTypeDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Select", LangType);

            BankDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Banknamerequired", LangType);
            //BankDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectbank", LangType);

            BankBranchTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Branchnamerequired", LangType);

            NationalityDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Nationalityrequired", LangType);
            NationalityDDL_ReqF.InitialValue = "";

            //RelationDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Select", LangType);
            RelationDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_BenefRelationRequired", LangType);

            OTPTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_OTPRequired", LangType);
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
                ViewState["OTPSent_V"] = "";

                string Result = "", OTPType = "";
                if (SMSRad.Checked == true)
                    OTPType = "MB";
                else if (EmailRad.Checked == true)
                    OTPType = "EM";
                try
                {
                    Result = await UpRestCls.GetOTP(Session["LoginID_CX"].ToString(), OTPType);
                    ViewState["OTPSent_V"] = Result.ToString();

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
        protected void OTPTxt_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["OTPSent_V"].ToString() == "")
            {
                OTPinvalidlbl.Text = CommCls.Messages_Eng_Arabic("MSG_PleaseclickonsendOTptoreceiveOTP", Session["Lang"].ToString());
            }
            else if (OTPTxt.Text.Trim() != ViewState["OTPSent_V"].ToString())
            {
                OTPTxt.Text = "";
                this.OTPTxt.Attributes.Add("value", "");
                OTPinvalidlbl.Text = CommCls.Messages_Eng_Arabic("MSG_InvalidOTP", Session["Lang"].ToString());
            }
            else if (OTPTxt.Text.Trim() == ViewState["OTPSent_V"].ToString())
            {
                InitiSecs_HD.Value = "0";
                Counterlbl.InnerText = "0";
                CounterSpan.Visible = false;
                OTPinvalidlbl.Text = "";
                OTPSendBtn.Visible = false;

                OTPTxt.Attributes.Add("disabled", "true");
                CounterSpan.Style.Add("display", "none");
                
            }
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