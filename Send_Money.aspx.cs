using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBE.RESTFull;
using System.Threading.Tasks;
using System.Data;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;
using KBE.Models;
using System.Web.Services;

namespace KBE
{
    public partial class Send_Money : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        UpdateREST URest = new UpdateREST();
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

                if (Session["CID_Expiry_S"].ToString().ToLower() == "yes")
                {
                    Response.Redirect("CIDUpload");
                }

                if (Session["SecQuestionValidated_S"].ToString() == "")
                {
                    Session["GoBackPage_S"] = "Sendmoney";
                    Response.Redirect("Validate");
                }             

                this.Load_DropDowns(Session["Lang"].ToString());

                this.GetBeneficaryList();
                this.Get_TransferPurposes("0", Session["Lang"].ToString());
                this.GetOtherCharges();
                this.Get_TermsNConditions();
                try
                {
                    if (Session["Benef_CUST_NO_S"].ToString() != "")
                    {
                        this.Get_BeneficiaryInfo(Session["Benef_CUST_NO_S"].ToString());
                        BenefListDDL.SelectedValue = Session["Benef_CUST_NO_S"].ToString();
                        KuwaitiDinarsTxt.Focus();
                        Session.Remove("Benef_CUST_NO_S");
                    }
                }
                catch (Exception dfh) { }
                this.GetAdded2CartList();
                this.Notifications_Unread();
                this.LoadLanguage();
            }

            this.AddToCartBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.AddToCartBtn));
            this.PayNowBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.PayNowBtn));

        }
        public void GetBeneficaryList()
        {
            BenefListDDL.Items.Clear();
            BenefList_ODS.SelectParameters[0].DefaultValue = Session["LoginID_CX"].ToString();
            BenefList_ODS.DataBind();
            BenefListDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("REQ_Selectbeneficiary", Session["Lang"].ToString())); BenefListDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("REQ_Selectbeneficiary", Session["Lang"].ToString());
        }        
        public async void GetOtherCharges()
        {
            decimal OtherCharges = 0;
            string LoginID_S = Session["LoginID_CX"].ToString();
            string Result = await RestCls.OtherCharges(LoginID_S);
            OtherCharges = Convert.ToDecimal(Result);
            OtherChargesTxt.Text = OtherCharges.ToString("F3");
            OtherChargeReviewtxt.Text = OtherCharges.ToString("F3");
        }
        public void Get_BeneficiaryInfo(string Cust_NoStr)
        {
            DataTable BenfDt = new DataTable();
            DataTable SingleBenfDt = new DataTable();
            BenfDt = RestCls.BeneficiaryList(Session["LoginID_CX"].ToString());
            if (BenfDt.Rows.Count > 0)
            {
                DataView BenfDv = new DataView(BenfDt);
                try
                {
                    BenfDv.RowFilter = "CUST_NO = " + Cust_NoStr;
                    SingleBenfDt = BenfDv.ToTable();
                }
                catch (Exception fgd) { }
                if (SingleBenfDt.Rows.Count > 0)
                {
                    DataRow dr = SingleBenfDt.Rows[0];
                    BenefNameTxt.Text = dr["BEN_NAME"].ToString();
                    AccountNoTxt.Text = dr["BEN_ACT"].ToString();
                    BankNameTxt.Text = dr["BNF_BANK_CODE_EN"].ToString();
                    BankBranchTxt.Text = dr["BRN_NAME"].ToString();
                    BenefMobileNoTxt.Text = dr["CUST_TEL"].ToString();
                    CurrencyTxt.Text = dr["CURR_CODE"].ToString();

                    CurrID_HD.Value = dr["CURR_ID"].ToString();
                    PayBankID_HD.Value = dr["PAY_BANK_ID"].ToString();
                    BenefCurrlbl.Text = dr["CURR_CODE"].ToString();
                    BenefDetailslbl.Text = dr["BEN_NAME"].ToString() + "<br/>" + dr["BEN_ACT"].ToString() + "<br/>" + dr["BNF_BANK_CODE_EN"].ToString() + "<br/>" + dr["BRN_NAME"].ToString();
                    Benef_Rel_HD.Value = dr["REL_TO_BNF"].ToString();
                    CUST_TEL_HD.Value = dr["CUST_TEL"].ToString();

                    this.GetExchangeRate(CurrID_HD.Value);
                    this.GetCommission(PayBankID_HD.Value, CurrID_HD.Value);
                    this.Get_TransferPurposes(PayBankID_HD.Value, Session["Lang"].ToString());
                }

            }
        }
        public async void GetExchangeRate(string CurrIDStr)
        {
            string ExchRate = await RestCls.GetExchRateOfCurrency(CurrIDStr, "0");
            try
            {
                ExchRateTxt.Text = ExchRate.ToString();
                ExchRateReviewTxt.Text = ExchRate.ToString();
            }
            catch (Exception dfg)
            {
                ExchRateTxt.Text = "";
                ExchRateReviewTxt.Text = "";
            }
        }
        public async void GetCommission(string PayBankIDStr, string CurrencyIDStr)
        {            
            string PayingAmt = "0";
            if (KuwaitiDinarsTxt.Text.Trim() != "")
                PayingAmt = KuwaitiDinarsTxt.Text.Trim();
            string CommiAmt = await RestCls.CommissionCharges(PayBankIDStr, CurrencyIDStr, PayingAmt);
            try
            {
                CommissionKDTxt.Text = Convert.ToDecimal(CommiAmt.ToString()).ToString("F3");
                CommissionReviewTxt.Text = Convert.ToDecimal(CommiAmt.ToString()).ToString("F3");
            }
            catch (Exception dfgd) { CommissionKDTxt.Text = "0.000"; CommissionReviewTxt.Text = "0.000"; }            
        }

        protected void BenefListDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            BenefNameTxt.Text = "";
            AccountNoTxt.Text = "";
            BankNameTxt.Text = "";
            BankBranchTxt.Text = "";
            BenefMobileNoTxt.Text = "";
            ExchRateTxt.Text = "";
            SendMoneyTxt.Text = "";
            KuwaitiDinarsTxt.Text = "";
            CommissionKDTxt.Text = "";
            TotalKDTxt.Text = "";
            TransOtherPurposeTxt.Text = "";            
            BenefMobileNoSendMTxt.Text = "";
            BenefDetailslbl.Text = "";
            YouPayKDReviewTxt.Text = "";
            BenefReceiveReviewTxt.Text = "";
            ExchRateReviewTxt.Text = "";
            CommissionReviewTxt.Text = "";
            OtherChargeReviewtxt.Text = "";
            TotalPayReviewTxt.Text = "";
            CurrencyTxt.Text = "";

            TransPurposeDDL.SelectedIndex = 0;
            this.GetOtherCharges();

            this.BenefReceiveReviewTxt.Attributes.Add("value", "");
            this.YouPayKDReviewTxt.Attributes.Add("value", "");
            this.TotalKDTxt.Attributes.Add("value", "");
            this.TotalPayReviewTxt.Attributes.Add("value", "");

            this.Get_BeneficiaryInfo(BenefListDDL.SelectedValue);

            SendMoneyTxt.Text = ""; BenefReceiveReviewTxt.Text = "";
            KuwaitiDinarsTxt.Text = ""; YouPayKDReviewTxt.Text = "";
            KuwaitiDinarsTxt.Focus();
        }

        protected async void AddToCartBtn_Click(object sender, EventArgs e)
        {
            string AddCResult = await AddToCardUpdate();

            string FResult = "";
            try
            {
                FResult = AddCResult.Substring(0, 5).ToUpper();
            }
            catch (Exception sdf) { }

            if (FResult == "ERROR")
            {
                this.OnErrorKeepSUM();
                MessageBox(AddCResult);
            }
            else
            {
                this.GetAdded2CartList();
                this.ResetFields();
                MessageBox(AddCResult);
            }

        }
        protected async void PayNowBtn_Click(object sender, EventArgs e)
        {
            string AddCResult = await AddToCardUpdate();

            string FResult = "";
            try
            {
                FResult = AddCResult.Substring(0, 5).ToUpper();
            }
            catch (Exception sdf) { }

            if (FResult == "ERROR")
            {
                this.OnErrorKeepSUM();
                MessageBox(AddCResult);
            }
            else
            {
                Response.Redirect("Checkout");
            }
        }
        public void Notifications_Unread()
        {
            NotifyCNTlbl.Text = "";
            NotifyDiv.Visible = false;

            DataTable NotifyDt = new DataTable();
            NotifyDt = RestCls.NotificationsList(Session["LoginID_CX"].ToString());

            try
            {
                DataView NotifyDv = new DataView(NotifyDt);
                NotifyDv.RowFilter = "IsNull(IS_VIEW, '') = ''";

                if (NotifyDv.ToTable().Rows.Count > 0)
                {
                    NotifyCNTlbl.Text = NotifyDv.ToTable().Rows.Count.ToString();
                    NotifyDiv.Visible = true;
                }
            }
            catch (Exception sdf) { }
        }
        protected void CartCheckoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout");
        }
        public void MessageBox_OK(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>SuccessMsg('" + msg + "');</script>", false);
        }
        public void MessageBox_Error(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>ErrorMsg('" + msg + "');</script>", false);
        }
        public void MessageBox(string msg)
        {
            ClientScriptManager script = Page.ClientScript;
            if (!script.IsClientScriptBlockRegistered(this.GetType(), "Alert"))
            {
                script.RegisterClientScriptBlock(this.GetType(), "KBE", "alert('" + msg + "')", true);
            }
        }

        public async Task<string> AddToCardUpdate()
        {
            string _CustNo = "", _SourceOfIncome = "", _CustTel = "", _PurposeTxn = "", _AddlInfo = "", _BenefMobileNo = "";
            string _FC_Amount = "", _ExchRate = "", _LC_Amount = "", _Commission = "", _OtherCharg = "";
            string _Relationship = "", _BenefName = "", _BenefAcctNo = "", _MachineIP = "", _SessionID = "";


            _CustNo = BenefListDDL.SelectedValue;
            _SourceOfIncome = SourceIncomeDDL.SelectedValue;
            _CustTel = CUST_TEL_HD.Value;
            _PurposeTxn = TransPurposeDDL.SelectedValue;
            _BenefMobileNo = BenefMobileNoSendMTxt.Text.Trim();
            _Relationship = Benef_Rel_HD.Value;
            _BenefName = BenefNameTxt.Text.Trim();
            _BenefAcctNo = AccountNoTxt.Text.Trim();
            _MachineIP = Session["UserMachineIP_S"].ToString();
            _SessionID = Session["UserSessionID_S"].ToString();

            try
            {
                _FC_Amount = SendMoneyTxt.Text.Trim();
            }
            catch (Exception dfg) { }
            try
            {
                _ExchRate = ExchRateTxt.Text.Trim();
            }
            catch (Exception fh) { }
            try
            {
                _LC_Amount = KuwaitiDinarsTxt.Text.Trim();
            }
            catch (Exception fgrf) { }
            try
            {
                _Commission = CommissionKDTxt.Text.Trim();
            }
            catch (Exception dfgh) { }
            try
            {
                _OtherCharg = OtherChargesTxt.Text.Trim();
            }
            catch (Exception g) { }
            _AddlInfo = "";

            decimal TotalKDAmtStr = 0, LocAmtKDStr = 0, CommiKDStr = 0, OtherChKDStr = 0;
            try
            {
                LocAmtKDStr = Convert.ToDecimal(_LC_Amount);
            }
            catch (Exception dgf) { }
            try
            {
                CommiKDStr = Convert.ToDecimal(_Commission);
            }
            catch (Exception dgf) { }
            try
            {
                OtherChKDStr = Convert.ToDecimal(_OtherCharg);
            }
            catch (Exception dgf) { }

            TotalKDAmtStr = LocAmtKDStr + CommiKDStr + OtherChKDStr;

            string Result = "";
            string ValidateSending = "";
            string Validate = "";
            Validate += "CUST_ID=" + Session["LoginID_CX"].ToString() + "|";
            Validate += "SENDER_PHONE=" + CUST_TEL_HD.Value + "|BNF_NAME=" + BenefNameTxt.Text.Trim() + "|BNF_ACCOUNT=" + AccountNoTxt.Text.Trim() + "|";
            Validate += "BNF_BANK=" + BankNameTxt.Text.Trim() + "|BNF_BRN=" + BankBranchTxt.Text.Trim() + "|CURR=" + CurrencyTxt.Text.Trim() + "|";
            Validate += "EXCH_RATE=" + ExchRateReviewTxt.Text.Trim() + "|SEND_AMOUNT=" + SendMoneyTxt.Text.Trim() + "|LC_AMOUNT=" + KuwaitiDinarsTxt.Text.Trim() + "|";
            Validate += "COMM_AMOUNT=" + CommissionKDTxt.Text.Trim() + "|SOURCE=" + SourceIncomeDDL.SelectedValue + "|TOTAL=" + Convert.ToDecimal(TotalKDAmtStr).ToString("F3") + "|";

            ValidateSending = await RestCls.SendMoneyValidation(Validate);

            if (ValidateSending.ToString() == "1")
            {
                Result = await URest.AddToCart(_CustNo, _FC_Amount, _ExchRate, _LC_Amount, _Commission,
                   _OtherCharg, _SourceOfIncome, _CustTel, _BenefMobileNo, _PurposeTxn, _Relationship, _AddlInfo,
                   _BenefName, _BenefAcctNo, _MachineIP, _SessionID);
            }
            else
            {
                MessageBox(ValidateSending.ToString());

                Result = ValidateSending.ToString();
            }
            return Result;
        }
        public void ResetFields()
        {
            BenefListDDL.SelectedIndex = 0;
            BenefNameTxt.Text = "";
            AccountNoTxt.Text = "";
            BankNameTxt.Text = "";
            BankBranchTxt.Text = "";
            BenefMobileNoTxt.Text = "";
            ExchRateTxt.Text = "";
            SendMoneyTxt.Text = "";
            KuwaitiDinarsTxt.Text = "";
            CommissionKDTxt.Text = "";
            TotalKDTxt.Text = "";
            TransOtherPurposeTxt.Text = "";            
            BenefMobileNoSendMTxt.Text = "";
            BenefDetailslbl.Text = "";
            YouPayKDReviewTxt.Text = "";
            BenefReceiveReviewTxt.Text = "";
            ExchRateReviewTxt.Text = "";
            CommissionReviewTxt.Text = "";
            OtherChargeReviewtxt.Text = "";
            TotalPayReviewTxt.Text = "";
            CurrencyTxt.Text = "";
            SourceIncomeDDL.SelectedIndex = 0;
            TransPurposeDDL.SelectedIndex = 0;            
            this.GetOtherCharges();

            this.BenefReceiveReviewTxt.Attributes.Add("value", "");
            this.YouPayKDReviewTxt.Attributes.Add("value", "");
            this.TotalKDTxt.Attributes.Add("value", "");
            this.TotalPayReviewTxt.Attributes.Add("value", "");
        }

        public void GetAdded2CartList()
        {
            CartCheckoutBtn.Visible = false;
            BadgeDiv.Visible = false;
            DataTable Add2Dt = new DataTable();
            Add2Dt = RestCls.AddedToCartList(Session["LoginID_CX"].ToString());
            try
            {
                if (Add2Dt.Rows.Count > 0)
                {
                    CartCNTlbl.Text = Add2Dt.Rows.Count.ToString();
                    CartCheckoutBtn.Visible = true;
                    BadgeDiv.Visible = true;
                    PaidKD_HD.Value = "0";
                    CartDV.DataSource = Add2Dt;
                    CartDV.DataBind();
                }
                else
                {
                    CartDV.DataSource = null;
                    CartDV.DataBind();
                }
            }
            catch (Exception dfg)
            {
                CartDV.DataSource = null;
                CartDV.DataBind();
            }
        }
        public void Get_TermsNConditions()
        {
            DataTable TnCDt = new DataTable();
            TnCDt = RestCls.TermsNConditions();
            if (TnCDt.Rows.Count > 0)
            {
                DataRow drTnC = TnCDt.Rows[0];
                TnCPara.Text = drTnC["TERM_TEXT"].ToString();                
            }
        }
        protected void CartDV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string LocKD = ((DataRowView)e.Row.DataItem)["LC_AMT"].ToString();
                string Commi = ((DataRowView)e.Row.DataItem)["COMMISSION"].ToString();
                string OtherCh = ((DataRowView)e.Row.DataItem)["OTHER_CHARGES"].ToString();
                decimal TotalKD = Convert.ToDecimal(LocKD) + Convert.ToDecimal(Commi) + Convert.ToDecimal(OtherCh);
                e.Row.Cells[2].Text = TotalKD.ToString("F3");
                PaidKD_HD.Value = (Convert.ToDecimal(PaidKD_HD.Value) + TotalKD).ToString("F3");
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total KD: ";
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = Convert.ToDouble(PaidKD_HD.Value).ToString("N3");
            }
        }
        protected async void CartDV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Cust_ID = Session["LoginID_CX"].ToString();
            string Cust_No = CartDV.DataKeys[e.RowIndex].Values["CUST_NO"].ToString();
            string EFT_Num = CartDV.DataKeys[e.RowIndex].Values["EFT_NUM"].ToString();
            decimal FC_Amt = Convert.ToDecimal(CartDV.DataKeys[e.RowIndex].Values["FC_AMT"].ToString());

            UpdateREST URest = new UpdateREST();
            string RegResult = await URest.RemoveCartItem(Cust_ID, Cust_No, EFT_Num, FC_Amt);

            string FResult = "";
            try
            {
                FResult = RegResult.Substring(0, 5).ToUpper();
            }
            catch (Exception sdf) { }

            if (FResult == "ERROR")
            {
                this.MessageBox_Error(RegResult);
            }
            else
            {
                this.MessageBox_OK(RegResult);
                this.GetAdded2CartList();

                string Curr_url = this.Request.Url.AbsolutePath;
                if (Curr_url.ToString() == "Checkout")
                {
                    Checkout_Confirm myPage = this.Page as Checkout_Confirm;
                    myPage.Get_Added2CartList_AfterRemove();
                }

            }
        }

        protected void EngBtn_Click(object sender, EventArgs e)
        {
            Session["Lang"] = "en-US";            
            EngDiv.Visible = false;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void ArbBtn_Click(object sender, EventArgs e)
        {
            Session["Lang"] = "ar-KW";            
            AraDiv.Visible = false;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            Dashboardlbl_M.Text = rm.GetString("Dashboard", ci);
            Remittancelbl_M.Text = rm.GetString("Remittance", ci);
            MyTranslbl_M.Text = rm.GetString("MyTransfers", ci);
            ExchnRatelbl_M.Text = rm.GetString("ExchRate", ci);
            Beneflbl_M.Text = rm.GetString("Beneficiaries", ci);
            BenefAddlbl_M.Text = rm.GetString("AddBeneficiary", ci);


            Dashboardlbl_D.Text = rm.GetString("Dashboard", ci);
            Remittancelbl_D.Text = rm.GetString("Remittance", ci);
            MyTranslbl_D.Text = rm.GetString("MyTransfers", ci);
            ExchnRatelbl_D.Text = rm.GetString("ExchRate", ci);
            Beneflbl_D.Text = rm.GetString("Beneficiaries", ci);
            BenefAddlbl_D.Text = rm.GetString("AddBeneficiary", ci);
            Brancheslbl_D.Text = rm.GetString("BranchLocations", ci);
            Promotionslbl_D.Text = rm.GetString("Promotions", ci);
            FAQlbl_D.Text = rm.GetString("FAQ", ci);
            Contactuslbl_D.Text = rm.GetString("Contactus", ci);
                       
            Language2lbl.Text = rm.GetString("Language", ci);

            ProfileMaslbl.InnerText = rm.GetString("Profile", ci);
            MessageMaslbl.InnerText = rm.GetString("Message", ci);
            ResetpwdMaslbl.InnerText = rm.GetString("Resetpassword", ci);
            LogoutMaslbl.InnerText = rm.GetString("Logout", ci);

            Remittancecartlbl.InnerText = rm.GetString("Remittancecart", ci);
            CartCheckoutBtn.Text = rm.GetString("Checkout", ci);

            try
            {
                CXNamelbl.Text = rm.GetString("Welcome", ci) + " " + Session["CxName_S"].ToString();
                Lastloginlbl.Text = rm.GetString("LastLoginDate", ci) + " " + Session["LastLogin_S"].ToString();
                CXNamelbl1.Text = rm.GetString("Welcome", ci) + " " + Session["CxName_S"].ToString();
                Lastloginlbl1.Text = rm.GetString("LastLoginDate", ci) + " " + Session["LastLogin_S"].ToString();
            }
            catch (Exception drfg) { }
            if (Session["Lang"].ToString() == "en-US")
            {
                AraDiv.Visible = true;
            }
            else if (Session["Lang"].ToString() == "ar-KW")
            {
                EngDiv.Visible = true;
            }
                       
            Sendmoneylbl_M.Text = rm.GetString("SendMoney", ci);
            beneficiarieslbl.InnerText = rm.GetString("Beneficiaries", ci) + " *";
            beneficiarynamelbl.InnerText = rm.GetString("BeneficiaryName", ci) + " *";
            accountnolbl.InnerText = rm.GetString("AccountNumber", ci) + " *";
            banknamelbl.InnerText = rm.GetString("Bank", ci) + " *";
            bankbranchlbl.InnerText = rm.GetString("BankBranch", ci) + " *";
            benefmobilenolbl.InnerText = rm.GetString("MobileNo", ci) + " *";
            currencylbl.InnerText = rm.GetString("Currency", ci) + " *";
            exchratelbl.InnerText = rm.GetString("ExchRate", ci) + " *";
            sendmoneyinnerlbl.InnerText = rm.GetString("SendMoney", ci) + " *";
            KDlbl.InnerText = rm.GetString("KD", ci) + " *";
            Commissionlbl.InnerText = rm.GetString("Commission", ci) + " *";
            totallbl.InnerText = rm.GetString("Total", ci) + " *";
            Otherchargeslbl.InnerText = rm.GetString("Othercharges", ci) + " *";

            sourceofincomelbl.InnerText = rm.GetString("SourceOfIncome", ci) + " *";
            exchrate2lbl.InnerText = rm.GetString("ExchRate", ci) + " *";
            commission2lbl.InnerText = rm.GetString("Commission", ci) + " *";
            Purposeoftranslbl.InnerText = rm.GetString("Purposeoftransaction", ci) + " *";
            Purposeoftransifanylbl.InnerText = rm.GetString("Purposeoftransactionifany", ci);
                        
            Benefmobilelbl.InnerText = rm.GetString("Beneficiarymobile", ci);

            Youpaylbl.InnerText = rm.GetString("Yousend", ci);
            Benefreceivedlbl.InnerText = rm.GetString("Beneficiaryreceived", ci);
            Otherchargeprevlbl.InnerText = rm.GetString("Othercharges", ci);
            Totalpaylbl.InnerText = rm.GetString("Totalpay", ci);

            Chargesatreceiverlbl.InnerText = rm.GetString("thechargesatthereceiverend", ci);

            CancelBtn.InnerText = rm.GetString("Cancel", ci);
            NextBtn.InnerText = rm.GetString("Next", ci);
            BackBtn.InnerText = rm.GetString("Back", ci);
            NextBtn2.InnerText = rm.GetString("Next", ci);
            BackBtn2.InnerText = rm.GetString("Back", ci);
            AddToCartBtn.InnerText = rm.GetString("Addtocart", ci);
            PayNowBtn.InnerText = rm.GetString("Paynow", ci);            
            ReadtncAnchor.InnerText = rm.GetString("TermsNConditions", ci);            
            Agreelbl.InnerText = rm.GetString("Iacceptagree", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }
        public void OnErrorKeepSUM()
        {
            decimal SendMoneyAmt = 0, SendKwdAmt = 0, TotalKDAmt = 0, CommissionAmt = 0, OtherChargesAmt = 0;

            SendMoneyAmt = Convert.ToDecimal(SendMoneyTxt.Text.Trim());
            SendKwdAmt = Convert.ToDecimal(KuwaitiDinarsTxt.Text.Trim());
            CommissionAmt = Convert.ToDecimal(CommissionKDTxt.Text.Trim());
            OtherChargesAmt = Convert.ToDecimal(OtherChargesTxt.Text.Trim());

            TotalKDAmt = SendKwdAmt + CommissionAmt + OtherChargesAmt;            

            BenefReceiveReviewTxt.Text = Convert.ToDouble(SendMoneyTxt.Text.Trim()).ToString("N");
            TotalKDTxt.Text = Convert.ToDouble(TotalKDAmt.ToString()).ToString("N3");
            YouPayKDReviewTxt.Text = Convert.ToDouble(KuwaitiDinarsTxt.Text.Trim()).ToString("N3");
            TotalPayReviewTxt.Text = Convert.ToDouble(TotalKDAmt.ToString()).ToString("N3");

            SendMoneyTxt.Text = Convert.ToDouble(SendMoneyAmt).ToString("N");

        }

        protected async void KuwaitiDinarsTxt_TextChanged(object sender, EventArgs e)
        {
            this.Calculate_Money("SendKWD");
        }

        protected async void SendMoneyTxt_TextChanged(object sender, EventArgs e)
        {
            this.Calculate_Money("SendMoney");
        }

        public void Calculate_Money(string InputType)
        {            
            double ExchgRate = 0, SendMoneyAmt = 0, SendKwdAmt = 0, TotalKDAmt = 0, CommissionAmt = 0, OtherChargesAmt = 0;


            try
            {
                ExchgRate = Convert.ToDouble(ExchRateTxt.Text.Trim());
            }
            catch (Exception dgd) { ExchgRate = 0; }
            if (InputType == "SendMoney")
            {
                try
                {
                    SendMoneyAmt = Convert.ToDouble(SendMoneyTxt.Text.Trim());
                }
                catch (Exception dg) { SendMoneyAmt = 0; }
                SendKwdAmt = 0;
            }
            else if (InputType == "SendKWD")
            {
                try
                {
                    SendKwdAmt = Convert.ToDouble(KuwaitiDinarsTxt.Text.Trim());
                }
                catch (Exception dg) { SendKwdAmt = 0; }
                SendMoneyAmt = 0;
            }

            try
            {
                OtherChargesAmt = Convert.ToDouble(OtherChargesTxt.Text.Trim());
            }
            catch (Exception dg) { OtherChargesAmt = 0; }

            if (SendMoneyAmt > 0)
            {
                double CalculateKD = SendMoneyAmt * ExchgRate;
                string KDDec = "0";
                string[] DeciStr = Convert.ToDouble(CalculateKD.ToString()).ToString("N3").Split('.'); //(CalculateKD).toFixed(3)) + "").split(".");

                var LastVal = DeciStr[1].Substring(2, 1);
                var LastBeforeVal = DeciStr[1].Substring(0, 2);

                if (Convert.ToInt32(LastVal) < 3)
                    KDDec = LastBeforeVal + "0";
                else if (Convert.ToInt32(LastVal) >= 3 && Convert.ToInt32(LastVal) <= 8)
                    KDDec = LastBeforeVal + "5";
                else if (Convert.ToInt32(LastVal) >= 9)
                    KDDec = ((Convert.ToInt32(KDDec.ToString()) + 1)).ToString();
                
                SendKwdAmt = Convert.ToDouble(DeciStr[0].ToString() + '.' + KDDec.ToString());
                                
                KuwaitiDinarsTxt.Text = Convert.ToDouble(SendKwdAmt.ToString()).ToString("N3");
            }
            else if (SendKwdAmt > 0)
            {
                SendMoneyAmt = SendKwdAmt / ExchgRate;                
                SendMoneyTxt.Text = Convert.ToDouble(SendMoneyAmt.ToString()).ToString("N0");
            }

            this.GetCommission(PayBankID_HD.Value, CurrID_HD.Value);

            try
            {
                CommissionAmt = Convert.ToDouble(CommissionKDTxt.Text.Trim());
            }
            catch (Exception dgd) { CommissionAmt = 0; }

            TotalKDAmt = SendKwdAmt + CommissionAmt + OtherChargesAmt;            

            BenefReceiveReviewTxt.Text = String.Format("{0:n0}", SendMoneyAmt) + ".00";
            YouPayKDReviewTxt.Text = String.Format("{0:n3}", SendKwdAmt);
            TotalKDTxt.Text = String.Format("{0:n3}", TotalKDAmt);
            TotalPayReviewTxt.Text = String.Format("{0:n3}", TotalKDAmt);
            KuwaitiDinarsTxt.Text = String.Format("{0:n3}", SendKwdAmt);
            SendMoneyTxt.Text = String.Format("{0:n0}", SendMoneyAmt) + ".00";
        }
        public void Get_TransferPurposes(string BankIDStr, string LangType)
        {
            TransPurposeDDL.Items.Clear();
            TransPurposeList_ODS.SelectParameters[0].DefaultValue = BankIDStr;
            TransPurposeList_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                TransPurposeDDL.DataTextField = "PP_DESC";
            else
                TransPurposeDDL.DataTextField = "PP_DESC_AR";
            TransPurposeDDL.DataValueField = "PP_CODE";            
            TransPurposeDDL.Items.Insert(0, ""); TransPurposeDDL.SelectedValue = "";
        }
        public void Load_DropDowns(string LangType)
        {
            SourceIncomeDDL.Items.Clear();
            SourceOfIncome_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SourceIncomeDDL.DataTextField = "DESC_E";
            else
                SourceIncomeDDL.DataTextField = "DESC_A";
            SourceIncomeDDL.DataValueField = "LOOKUP_ID";            
            SourceIncomeDDL.Items.Insert(0, ""); SourceIncomeDDL.SelectedValue = "";
        }
        public void Validation_Messages(string LangType)
        {
            BenefListDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Beneficiaryrequired", LangType);
            BenefListDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("REQ_Selectbeneficiary", LangType);

            KuwaitiDinarsTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("Invalidamount", LangType);
            SendMoneyTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("Invalidamount", LangType);

            TransPurposeDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Transferpurposerequired", LangType);            

            SourceIncomeDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Incomesourcerequired", LangType);            

            ConfirmCHK_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Termsandconditionsrequired", LangType);
        }

    }
}