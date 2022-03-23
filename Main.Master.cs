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
    public partial class Main : System.Web.UI.MasterPage
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.GetUserActiveSessionID();
                this.GetAdded2CartList();
                this.Notifications_Unread();
            }
            this.LoadLanguage();

            this.ActiveMenu();
            this.CartCheckoutBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.CartCheckoutBtn));

            try
            {
                string stest = Session["LoginID_CX"].ToString();
            }
            catch (Exception sdf) { Response.Redirect("login"); }

        }
        public void ActiveMenu()
        {
            string url = this.Request.Url.AbsolutePath;
            url = url.Substring(url.LastIndexOf('/') + 1, url.Length - 1 - url.LastIndexOf('/'));

            dash_M.Attributes.Add("class", "side-menu");
            benefadd_M.Attributes.Add("class", "side-menu");
            benef_M.Attributes.Add("class", "side-menu");
            exch_M.Attributes.Add("class", "side-menu");
            trans_M.Attributes.Add("class", "side-menu");
            sendmoney_M.Attributes.Add("class", "side-menu");
            branch_M.Attributes.Add("class", "side-menu");
            promo_M.Attributes.Add("class", "side-menu");
            faq_M.Attributes.Add("class", "side-menu");
            contact_M.Attributes.Add("class", "side-menu");



            switch (url)
            {
                case "Dashboard":
                    dash_M.Attributes.Add("class", "side-menu side-menu--active");
                    break;
                case "Beneficiary":
                    benefadd_M.Attributes.Add("class", "side-menu side-menu--active");
                    this.ValidateSecurity("Beneficiary");
                    break;
                case "Beneficiaries":
                    benef_M.Attributes.Add("class", "side-menu side-menu--active");
                    this.ValidateSecurity("Beneficiaries");
                    break;
                case "Beneficiarries":
                    benef_M.Attributes.Add("class", "side-menu side-menu--active");
                    this.ValidateSecurity("Beneficiarries");
                    break;
                case "Exchange":
                    exch_M.Attributes.Add("class", "side-menu side-menu--active");
                    break;
                case "Transactions":
                    trans_M.Attributes.Add("class", "side-menu side-menu--active");
                    this.ValidateSecurity("Transactions");
                    break;
                case "Sendmoney":
                    trans_M.Attributes.Add("class", "side-menu side-menu--active");
                    this.ValidateSecurity("Sendmoney");
                    break;
                case "Branches":
                    branch_M.Attributes.Add("class", "side-menu side-menu--active");
                    break;
                case "Promotions":
                    promo_M.Attributes.Add("class", "side-menu side-menu--active");
                    break;
                case "FAQ":
                    faq_M.Attributes.Add("class", "side-menu side-menu--active");
                    break;
                case "Contact":
                    contact_M.Attributes.Add("class", "side-menu side-menu--active");
                    break;
                default:
                    dash_M.Attributes.Add("class", "side-menu");
                    break;
            }

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
        protected void CartCheckoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout");
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
        }
        public void ValidateSecurity(string PageNameStr)
        {
            if (Session["SecQuestionValidated_S"].ToString() == "")
            {
                Session["GoBackPage_S"] = PageNameStr;
                Response.Redirect("Validate");
            }
        }

        public void GetUserActiveSessionID()
        {
            string ActiveSessionID = "";
            DataTable SessionDT = new DataTable();
            SessionDT = RestCls.GetUserActiveSessionID(Session["LoginID_CX"].ToString());

            if (SessionDT.Rows.Count > 0)
            {
                DataRow dr_s = SessionDT.Rows[0];
                ActiveSessionID = dr_s["SESSION_ID"].ToString();
            }

            if (ActiveSessionID.ToString() != "" && ActiveSessionID.ToString() != Session["UserSessionID_S"].ToString())
                Response.Redirect("login");
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