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
    public partial class Dashboard : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Get_BeneficiaryList();
                if (Session["CIDPopup_S"] == null)
                    this.Show_CivilID_Popup();
                else
                    Session["CIDPopup_S"] = "NoExpiry";

                if (Session["PromShow_S"] == null && Session["CIDPopup_S"].ToString() != "Showed")
                {
                    this.Get_Promotions();
                    Session["PromShow_S"] = "Showed";
                }              

                this.LoadLanguage();
            }
        }
        
        public async void Get_BeneficiaryList()
        {
            DataTable BenfDt = new DataTable();
            BenfDt = await RestCls.BeneficiaryList_Async(Session["LoginID_CX"].ToString());
            if (BenfDt.Rows.Count > 0)
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

                DataView BenfDv = new DataView(BenfDt);
                BenfDv.RowFilter = "FAV_BNF = 1 AND ENABLED_BNF=1";
                if (BenfDv.ToTable().Rows.Count == 0)
                    BenefGV.EmptyDataText = CommCls.Messages_Eng_Arabic("MSG_Nobeneficiarylistavailable", Session["Lang"].ToString());
                BenefGV.DataSource = BenfDv.ToTable();
                BenefGV.DataBind();
            }
            else
            {
                BenefGV.EmptyDataText = CommCls.Messages_Eng_Arabic("MSG_Nobeneficiarylistavailable", Session["Lang"].ToString());
                BenefGV.DataSource = null;
                BenefGV.DataBind();

            }

        }


        public void Get_Promotions()
        {
            CommCls = new CommonClass();
            DataTable PromDt = new DataTable();
            PromDt = RestCls.PromotionBanners();
            if (PromDt.Rows.Count > 0)
            {
                Prom1Img.Visible = false;
                Prom2Img.Visible = false;
                Prom3Img.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>ShowPromotions();</script>", false);
                for (int i = 0; i < PromDt.Rows.Count; i++)
                {
                    DataRow PromDr = PromDt.Rows[i];
                    if (i == 0)
                    {
                        Prom1Img.Visible = true;
                        Prom1Img.Src = "data:image/png;base64," + PromDr["PROMO_CLOB"].ToString();
                        Prom1Img.Alt = PromDr["PROMO_DESC"].ToString();
                    }
                    if (i == 1)
                    {
                        Prom2Img.Visible = true;
                        Prom2Img.Src = "data:image/png;base64," + PromDr["PROMO_CLOB"].ToString();
                        Prom2Img.Alt = PromDr["PROMO_DESC"].ToString();
                    }
                    if (i == 2)
                    {
                        Prom3Img.Visible = true;
                        Prom3Img.Src = "data:image/png;base64," + PromDr["PROMO_CLOB"].ToString();
                        Prom3Img.Alt = PromDr["PROMO_DESC"].ToString();
                    }
                }
            }
        }
        public void Show_CivilID_Popup()
        {
            Session["CIDPopup_S"] = "NoExpiry";
            UploadLinkBtn.Visible = false;
            if (Session["CID_Expiry_S"].ToString().ToLower() == "yes" || Session["PopupMsg_S"].ToString() != "")
            {
                if (Session["CID_Expiry_S"].ToString().ToLower() == "yes")
                    UploadLinkBtn.Visible = true;
                PopupMsglbl.Text = Session["PopupMsg_S"].ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "KBE", "<script type='text/javascript'>CID_Message();</script>", false);
                Session["CIDPopup_S"] = "Showed";
            }
        }
        protected void BenefGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton FavBtn = (LinkButton)e.Row.FindControl("FavBtn");
                LinkButton SendBtn = (LinkButton)e.Row.FindControl("SendBtn");

                string FavSts = ((DataRowView)e.Row.DataItem)["FAV_BNF"].ToString();

                if (FavSts.ToString() == "1")
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
                this.MessageBox_Error(RegResult);
            }
            else
            {
                this.MessageBox_OK(RegResult);
                this.Get_BeneficiaryList();
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
       
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            Remittancelbl_DB.Text = rm.GetString("Remittance", ci);
            MyTranslbl_DB.Text = rm.GetString("MyTransfers", ci);
            Beneficirieslbl_DB.Text = rm.GetString("Beneficiaries", ci);
            ExchRatelbl_DB.Text = rm.GetString("ExchRate", ci);

            Trustedsecurelbl.Text = rm.GetString("Trustedsecurefast", ci);
            Historypastlbl.Text = rm.GetString("Historypast6months", ci);
            Vieweditlbl.Text = rm.GetString("Vieweditadd", ci);
            Viewrateslbl.Text = rm.GetString("Viewratessetalerts", ci);            
            FavBeneflbl.Text = rm.GetString("Favoritebenef", ci);
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