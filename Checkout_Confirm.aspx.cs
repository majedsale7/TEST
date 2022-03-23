using KBE.RESTFull;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBE.Models;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace KBE
{
    public partial class Checkout_Confirm : System.Web.UI.Page
    {
        RESTClass RestCls = new RESTClass();
        CommonClass CommCls = new CommonClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ValidateSecurity("Checkout");
                this.Get_Added2CartList();
            }
            this.LoadLanguage();
            this.ClearBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.ClearBtn));
            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.SubmitBtn));
        }
        public void Get_Added2CartList()
        {
            DataTable Add2Dt = new DataTable();
            Add2Dt = RestCls.AddedToCartList(Session["LoginID_CX"].ToString());
            if (Add2Dt.Rows.Count > 0)
            {
                PaidKD_HD.Value = "0";
                CheckGV.DataSource = Add2Dt;
                CheckGV.DataBind();

                if (Add2Dt.Rows.Count == 1) //If One Payment Let go Direct Knet Page
                {
                    if (Convert.ToDecimal(PaidKD_HD.Value) <= 3000)
                    {
                        Session["TrackIDSession"] = CommCls.TimeZoneDateTime().ToString("ddMMyyyyhhmmss");
                        Session["PayRemarksSession"] = "";
                        Response.Redirect("Payment.aspx?PaidAmt=" + PaidKD_HD.Value);
                    }
                    else
                    {
                        Session["PayingAmt_OTP_S"] = PaidKD_HD.Value;
                        Response.Redirect("OTP");
                    }
                }
            }
            else
            {
                CheckGV.DataSource = null;
                CheckGV.DataBind();
                SubmitBtn.Disabled = true;
            }

        }

        public void Get_Added2CartList_AfterRemove()
        {
            DataTable Add2Dt = new DataTable();
            Add2Dt = RestCls.AddedToCartList(Session["LoginID_CX"].ToString());
            if (Add2Dt.Rows.Count > 0)
            {
                PaidKD_HD.Value = "0";
                CheckGV.DataSource = Add2Dt;
                CheckGV.DataBind();
            }
            else
            {
                CheckGV.DataSource = null;
                CheckGV.DataBind();
                SubmitBtn.Disabled = true;
            }

        }


        protected void CheckGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string LocKD = ((DataRowView)e.Row.DataItem)["LC_AMT"].ToString();
                string Commi = ((DataRowView)e.Row.DataItem)["COMMISSION"].ToString();
                string OtherCh = ((DataRowView)e.Row.DataItem)["OTHER_CHARGES"].ToString();
                decimal TotalKD = Convert.ToDecimal(LocKD) + Convert.ToDecimal(Commi) + Convert.ToDecimal(OtherCh);
                e.Row.Cells[3].Text = TotalKD.ToString("F3");
                PaidKD_HD.Value = (Convert.ToDecimal(PaidKD_HD.Value) + TotalKD).ToString("F3");
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total KD: ";
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].Text = PaidKD_HD.Value;
            }
        }

        protected async void CheckGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Cust_ID = Session["LoginID_CX"].ToString();
            string Cust_No = CheckGV.DataKeys[e.RowIndex].Values["CUST_NO"].ToString();
            string EFT_Num = CheckGV.DataKeys[e.RowIndex].Values["EFT_NUM"].ToString();
            decimal FC_Amt = Convert.ToDecimal(CheckGV.DataKeys[e.RowIndex].Values["FC_AMT"].ToString());

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
                this.Get_Added2CartList_AfterRemove();
                (this.Master as Main).GetAdded2CartList();
            }


        }
        protected void PayBtn_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(PaidKD_HD.Value) <= 3000)
            {
                Session["TrackIDSession"] = CommCls.TimeZoneDateTime().ToString("ddMMyyyyhhmmss");
                Session["PayRemarksSession"] = "";
                Response.Redirect("Payment.aspx?PaidAmt=" + PaidKD_HD.Value);
            }
            else
            {
                Session["PayingAmt_OTP_S"] = PaidKD_HD.Value;
                Response.Redirect("OTP");
            }
        }
        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard");
        }

        public void ValidateSecurity(string PageNameStr)
        {
            if (Session["SecQuestionValidated_S"].ToString() == "")
            {
                Session["GoBackPage_S"] = PageNameStr;
                Response.Redirect("Validate");
            }
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            Checkoutlbl.Text = rm.GetString("Checkout", ci).ToUpper();
            ClearBtn.Value = rm.GetString("Back", ci);
            SubmitBtn.Value = rm.GetString("Proceedtopay", ci);


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