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
    public partial class BeneficiaryList : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Get_BeneficiaryList("0");
                this.LoadLanguage();
                this.LoadFilterData();
            }

        }
        public void Get_BeneficiaryList(string FType)
        {
            DataTable BenfDt = new DataTable();
            BenfDt = RestCls.BeneficiaryList(Session["LoginID_CX"].ToString());            
            DataView BenDv = new DataView(BenfDt);
            if (FType.ToString() == "2")
                BenDv.RowFilter = "ENABLED_BNF=1";
            else if (FType.ToString() == "1")
                BenDv.RowFilter = "FAV_BNF=1 AND ENABLED_BNF=1 ";
            else if (FType.ToString() == "3")
                BenDv.RowFilter = "ENABLED_BNF=0";
            DataTable BenfDt_F = new DataTable();
            BenfDt_F = BenDv.ToTable();
            if (BenfDt_F.Rows.Count > 0)
            {
                string LangType = Session["Lang"].ToString();
                BenefGV.Columns[0].HeaderText = CommCls.Messages_Eng_Arabic("Sno", LangType);
                BenefGV.Columns[1].HeaderText = CommCls.Messages_Eng_Arabic("BeneficiaryName", LangType);
                BenefGV.Columns[2].HeaderText = CommCls.Messages_Eng_Arabic("TransferType", LangType);
                BenefGV.Columns[3].HeaderText = CommCls.Messages_Eng_Arabic("AccountNumber", LangType);
                BenefGV.Columns[4].HeaderText = CommCls.Messages_Eng_Arabic("Bankname", LangType);
                BenefGV.Columns[5].HeaderText = CommCls.Messages_Eng_Arabic("BankBranch", LangType);
                BenefGV.Columns[6].HeaderText = CommCls.Messages_Eng_Arabic("Lastusedon", LangType);
                BenefGV.Columns[7].HeaderText = CommCls.Messages_Eng_Arabic("Action", LangType);
                if (BenfDt_F.Rows.Count == 0)
                    BenefGV.EmptyDataText = CommCls.Messages_Eng_Arabic("MSG_Nobeneficiarylistavailable", Session["Lang"].ToString());
                BenefGV.DataSource = BenfDt_F;
                BenefGV.DataBind();
            }
            else
            {
                BenefGV.DataSource = null;
                BenefGV.DataBind();
                BenefGV.EmptyDataText = CommCls.Messages_Eng_Arabic("MSG_Nobeneficiarylistavailable", Session["Lang"].ToString());
            }

        }
        public void LoadFilterData()
        {
            FilterDDL.Items.Add(new ListItem("All", "0"));
            FilterDDL.Items.Add(new ListItem("Favorite", "1"));
            FilterDDL.Items.Add(new ListItem("Active", "2"));
            FilterDDL.Items.Add(new ListItem("In Active", "3"));
            FilterDDL.SelectedValue = "0";
        }
        protected void BenefGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton FavBtn = (LinkButton)e.Row.FindControl("FavBtn");
                LinkButton EnableBtn = (LinkButton)e.Row.FindControl("EnableBtn");
                LinkButton SendBtn = (LinkButton)e.Row.FindControl("SendBtn");
                Label Benef_Statuslbl = (Label)e.Row.FindControl("Benef_Statuslbl");

                string Status_Benf = ((DataRowView)e.Row.DataItem)["APPROVAL_STATUS"].ToString();
                string FavSts = ((DataRowView)e.Row.DataItem)["FAV_BNF"].ToString();
                string EnabledSts = ((DataRowView)e.Row.DataItem)["ENABLED_BNF"].ToString();

                if (Status_Benf.ToString().ToLower() == "dft")
                {
                    FavBtn.Visible = false;
                    EnableBtn.Visible = false;
                    SendBtn.Visible = false;
                    Benef_Statuslbl.Visible = true;
                    Benef_Statuslbl.Text = CommCls.Messages_Eng_Arabic("MSG_Waitingforapproval", Session["Lang"].ToString());
                }
                else
                {
                    FavBtn.Visible = true;
                    EnableBtn.Visible = true;
                    SendBtn.Visible = true;
                    Benef_Statuslbl.Visible = false;
                    Benef_Statuslbl.Text = "";

                    if (EnabledSts.ToString() == "0")
                    {
                        FavBtn.Enabled = false;
                        SendBtn.Enabled = false;
                        FavBtn.CssClass = "flex items-center mr-3 tooltip";
                        SendBtn.CssClass = "flex items-center mr-3 tooltip";
                        EnableBtn.CssClass = "flex items-center mr-3 tooltip";
                        EnableBtn.ToolTip = "Enable";
                    }
                    if (FavSts.ToString() == "1" && EnabledSts.ToString() == "1")
                    {
                        FavBtn.CssClass = "flex items-center mr-3 text-theme-9 tooltip";
                        FavBtn.ToolTip = "Unfavorite";
                    }
                    else
                    {
                        FavBtn.CssClass = "flex items-center mr-3 tooltip";
                        FavBtn.ToolTip = "Favorite";
                    }
                }
            }
        }
        protected async void BenefGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Favorite
            string BenefCustNo_S = BenefGV.DataKeys[e.RowIndex].Values["CUST_NO"].ToString();
            string CustCID_S = BenefGV.DataKeys[e.RowIndex].Values["CUST_ID"].ToString();
            string FavSts = BenefGV.DataKeys[e.RowIndex].Values["FAV_BNF"].ToString();
            string APPSecKey_S = "123", SetFavNew_S = "", SetBenefOper_S = "BNF_FAVORITE", SetBenDisabled_S = "0";
            string LoginID_S = Session["LoginID_CX"].ToString();
            if (FavSts.ToString() == "1")
                SetFavNew_S = "0";
            else
                SetFavNew_S = "1";

            UpdateREST URest = new UpdateREST();
            string RegResult = await URest.BeneficiarySettingsUpdate(APPSecKey_S, LoginID_S, CustCID_S, BenefCustNo_S, SetBenefOper_S,
                SetFavNew_S, SetBenDisabled_S);

            string FResult = "";
            try
            {
                FResult = RegResult.Substring(0, 5).ToUpper();
            }
            catch (Exception sdf) { }

            if (FResult == "ERROR")
            {
                MessageBox_Error(RegResult);
            }
            else
            {
                MessageBox_OK(RegResult);
                this.Get_BeneficiaryList(FilterDDL.SelectedValue);
            }


        }

        protected void BenefGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Send Money
            string BenefCustNo_S = BenefGV.DataKeys[e.RowIndex].Values["CUST_NO"].ToString();
            string ApprSts = BenefGV.DataKeys[e.RowIndex].Values["APPROVAL_STATUS"].ToString();
            if (ApprSts.ToString().ToLower() == "app")
            {
                Session["Benef_CUST_NO_S"] = BenefCustNo_S.ToString();
                Response.Redirect("Sendmoney");
            }
            else
            {
                this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_beneficiarywaitingforappoval", Session["Lang"].ToString()));
            }
        }

        protected async void BenefGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Enable
            string EnabledSts = BenefGV.DataKeys[e.NewEditIndex].Values["ENABLED_BNF"].ToString();
            string BenefCustNo_S = BenefGV.DataKeys[e.NewEditIndex].Values["CUST_NO"].ToString();
            string CustCID_S = BenefGV.DataKeys[e.NewEditIndex].Values["CUST_ID"].ToString();
            string FavSts = BenefGV.DataKeys[e.NewEditIndex].Values["FAV_BNF"].ToString();
            string APPSecKey_S = "123", SetDisableStsNew_S = "", SetBenefOper_S = "BNF_DISABLED";
            string LoginID_S = Session["LoginID_CX"].ToString();
            if (EnabledSts.ToString() == "1")
                SetDisableStsNew_S = "0";
            else
                SetDisableStsNew_S = "1";

            UpdateREST URest = new UpdateREST();
            string RegResult = await URest.BeneficiarySettingsUpdate(APPSecKey_S, LoginID_S, CustCID_S, BenefCustNo_S, SetBenefOper_S,
                FavSts, SetDisableStsNew_S);




            string FResult = "";
            try
            {
                FResult = RegResult.Substring(0, 5).ToUpper();
            }
            catch (Exception sdf) { }

            if (FResult == "ERROR")
            {
                MessageBox_Error(RegResult);
            }
            else
            {
                MessageBox_OK(RegResult);
                this.Get_BeneficiaryList(FilterDDL.SelectedValue);
            }

        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            BenefListlbl.Text = rm.GetString("BeneficiariesList", ci);
            AddNewBeneflbl.Text = rm.GetString("AddNewBeneficiary", ci);
        }
        protected void FilterDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Get_BeneficiaryList(FilterDDL.SelectedValue);
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