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
    public partial class BeneficiaryFormView : System.Web.UI.Page
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

            BenefRepeat.DataSource = BenfDt_F;
            BenefRepeat.DataBind();
        }
        public void LoadFilterData()
        {
            FilterDDL.Items.Add(new ListItem("All", "0"));
            FilterDDL.Items.Add(new ListItem("Favorite", "1"));
            FilterDDL.Items.Add(new ListItem("Active", "2"));
            FilterDDL.Items.Add(new ListItem("In Active", "3"));
            FilterDDL.SelectedValue = "0";
        }
        protected async void BenefRepeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case ("Delete"): //Favorite
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string BenefCustNo_S = commandArgs[0];
                    string CustCID_S = commandArgs[1];
                    string FavSts = commandArgs[2];
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
                    break;

                case ("Edit"): //Enable/ Disable
                    string[] commandArgs_Dis = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string EnabledSts_Dis = commandArgs_Dis[0];
                    string BenefCustNo_S_Dis = commandArgs_Dis[1];
                    string CustCID_S_Dis = commandArgs_Dis[2];
                    string FavSts_Dis = commandArgs_Dis[3];
                    string APPSecKey_S_Dis = "123", SetDisableStsNew_S_Dis = "", SetBenefOper_S_Dis = "BNF_DISABLED";
                    string LoginID_S_Dis = Session["LoginID_CX"].ToString();
                    if (EnabledSts_Dis.ToString() == "1")
                        SetDisableStsNew_S_Dis = "0";
                    else
                        SetDisableStsNew_S_Dis = "1";

                    UpdateREST URest_Dis = new UpdateREST();
                    string RegResult_Dis = await URest_Dis.BeneficiarySettingsUpdate(APPSecKey_S_Dis, LoginID_S_Dis, CustCID_S_Dis, BenefCustNo_S_Dis, SetBenefOper_S_Dis,
                        FavSts_Dis, SetDisableStsNew_S_Dis);

                    string FResult_Dis = "";
                    try
                    {
                        FResult_Dis = RegResult_Dis.Substring(0, 5).ToUpper();
                    }
                    catch (Exception sdf) { }

                    if (FResult_Dis == "ERROR")
                    {
                        MessageBox_Error(RegResult_Dis);
                    }
                    else
                    {
                        MessageBox_OK(RegResult_Dis);
                        this.Get_BeneficiaryList(FilterDDL.SelectedValue);
                    }
                    break;

                case ("Update"): //Send Money
                    string[] commandArgs_Send = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string BenefCustNo_S_SendM = commandArgs_Send[0];
                    string ApprSts = commandArgs_Send[1];
                    if (ApprSts.ToString().ToLower() == "app")
                    {
                        Session["Benef_CUST_NO_S"] = BenefCustNo_S_SendM.ToString();
                        Response.Redirect("Sendmoney", false);
                    }
                    else
                    {
                        this.MessageBox_Error(CommCls.Messages_Eng_Arabic("MSG_beneficiarywaitingforappoval", Session["Lang"].ToString()));
                    }
                    break;
                default:
                    break;
            }
        }
        protected void BenefRepeat_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            string BenefN = ((DataRowView)e.Item.DataItem)["BEN_NAME"].ToString();
            LinkButton FavBtn = (LinkButton)e.Item.FindControl("FavBtn");
            LinkButton EnableBtn = (LinkButton)e.Item.FindControl("EnableBtn");
            LinkButton SendBtn = (LinkButton)e.Item.FindControl("SendBtn");
            Label Benef_Statuslbl = (Label)e.Item.FindControl("Benef_Statuslbl");

            string Status_Benf = ((DataRowView)e.Item.DataItem)["APPROVAL_STATUS"].ToString();
            string FavSts = ((DataRowView)e.Item.DataItem)["FAV_BNF"].ToString();
            string EnabledSts = ((DataRowView)e.Item.DataItem)["ENABLED_BNF"].ToString();

            string LangType = Session["Lang"].ToString();
            Label BenfNamelbl_H = (Label)e.Item.FindControl("BenfNamelbl_H");
            Label TransTypelbl_H = (Label)e.Item.FindControl("TransTypelbl_H");
            Label AcctNolbl_H = (Label)e.Item.FindControl("AcctNolbl_H");
            Label BankNamelbl_H = (Label)e.Item.FindControl("BankNamelbl_H");
            Label BranchNamelbl_H = (Label)e.Item.FindControl("BranchNamelbl_H");
            Label Lastusedlbl_H = (Label)e.Item.FindControl("Lastusedlbl_H");

            BenfNamelbl_H.Text = CommCls.Messages_Eng_Arabic("BeneficiaryName", LangType);
            TransTypelbl_H.Text = CommCls.Messages_Eng_Arabic("TransferType", LangType);
            AcctNolbl_H.Text = CommCls.Messages_Eng_Arabic("AccountNumber", LangType);
            BankNamelbl_H.Text = CommCls.Messages_Eng_Arabic("Bankname", LangType);
            BranchNamelbl_H.Text = CommCls.Messages_Eng_Arabic("BankBranch", LangType);
            Lastusedlbl_H.Text = CommCls.Messages_Eng_Arabic("Lastusedon", LangType);

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
                    FavBtn.Attributes.Add("class", "tooltip");
                    SendBtn.Attributes.Add("class", "tooltip");
                    EnableBtn.Attributes.Add("class", "tooltip");

                    EnableBtn.ToolTip = "Enable";
                }
                else if (FavSts.ToString() == "1" && EnabledSts.ToString() == "1")
                {
                    FavBtn.Attributes.Add("class", "tooltip text-theme-9");
                    EnableBtn.Attributes.Add("class", "tooltip text-theme-9");
                    SendBtn.Attributes.Add("class", "tooltip text-theme-9");
                    FavBtn.ToolTip = "Unfavorite";
                }
                else if (FavSts.ToString() == "0" || FavSts.ToString() == "")
                {
                    FavBtn.Attributes.Add("class", "tooltip");
                    EnableBtn.Attributes.Add("class", "tooltip text-theme-9");
                    SendBtn.Attributes.Add("class", "tooltip text-theme-9");
                    FavBtn.ToolTip = "Favorite";
                }
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