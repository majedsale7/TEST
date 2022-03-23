using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBE.RESTFull;
using System.Data;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;
using KBE.Models;

namespace KBE
{
    public partial class Exchange_Rate : System.Web.UI.Page
    {
        RESTClass RestCls = new RESTClass();
        CommonClass CommCls = new CommonClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                ExRate_ODS.DataBind();
                ExRateDDL.Items.Clear();
                ExRateDDL.DataBind();

                ExRateDDLTEMP.Items.Clear();
                ExRateDDLTEMP.DataBind();

                if (Session["CX_CURR_CODE_S"].ToString() == null)
                {
                    this.GetCXCurrenyID();
                }
                ExRateDDLTEMP.SelectedValue = Session["CX_CURR_CODE_S"].ToString();
                ExRateDDL.SelectedValue = ExRateDDLTEMP.SelectedItem.Text;
                FMoneylbl.Text = ExRateDDL.SelectedItem.Text;
                ExchangeTxt.Text = Convert.ToDecimal(ExRateDDL.SelectedValue).ToString();
            }

            this.LoadLanguage();
        }
        protected void KDAmtTxt_TextChanged(object sender, EventArgs e)
        {
            decimal EXRate = 0, KDAmt = 0, FMoney = 0;
            if (ExRateDDL.SelectedItem.Text != "")
            {
                try
                {
                    EXRate = Convert.ToDecimal(ExRateDDL.SelectedValue);
                    ExchangeTxt.Text = EXRate.ToString();
                }
                catch (Exception dfg) { }

            }
            if (KDAmtTxt.Text.Trim() != "")
            {
                try
                {
                    KDAmt = Convert.ToDecimal(KDAmtTxt.Text.Trim());
                }
                catch (Exception dfg1) { }
            }

            try
            {
                FMoney = EXRate * KDAmt;
            }
            catch (Exception fgf) { }
                        
            FMoneyTxt.Text = Convert.ToDouble(FMoney).ToString("N0") + ".00";
            KDAmtTxt.Text = Convert.ToDouble(KDAmt).ToString("N3");
            FMoneylbl.Text = ExRateDDL.SelectedItem.Text;
        }

        protected void FMoneyTxt_TextChanged(object sender, EventArgs e)
        {
            decimal EXRate = 0, KDAmt = 0, FMoney = 0;
            if (ExRateDDL.SelectedItem.Text != "")
            {
                try
                {
                    EXRate = Convert.ToDecimal(ExRateDDL.SelectedValue);
                    ExchangeTxt.Text = EXRate.ToString();
                }
                catch (Exception dfg) { }
            }
            if (FMoneyTxt.Text.Trim() != "")
            {
                try
                {
                    FMoney = Convert.ToDecimal(FMoneyTxt.Text.Trim());
                }
                catch (Exception dfg1) { }
            }
            try
            {
                KDAmt = FMoney / EXRate;
            }
            catch (Exception fgf) { }           

            KDAmtTxt.Text = Convert.ToDouble(KDAmt).ToString("N3");
            FMoneyTxt.Text = Convert.ToDouble(FMoney).ToString("N0") + ".00";
        }
        protected void ExRateDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal EXRate = 0, KDAmt = 0, FMoney = 0;
            if (ExRateDDL.SelectedItem.Text != "")
            {
                try
                {
                    EXRate = Convert.ToDecimal(ExRateDDL.SelectedValue);
                    ExchangeTxt.Text = EXRate.ToString();
                }
                catch (Exception dfg) { }
            }
            if (KDAmtTxt.Text.Trim() != "")
            {
                try
                {
                    KDAmt = Convert.ToDecimal(KDAmtTxt.Text.Trim());
                }
                catch (Exception dfg1) { }
            }

            try
            {
                FMoney = EXRate * KDAmt;
            }
            catch (Exception fgf) { }
                        
            FMoneyTxt.Text = Convert.ToDouble(FMoney).ToString("N0") + ".00";
            KDAmtTxt.Text = Convert.ToDouble(KDAmt).ToString("N3");

            FMoneylbl.Text = ExRateDDL.SelectedItem.Text;
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            ExchRatelbl_P.Text = rm.GetString("ExchRate", ci);
            selectcurrencylbl.InnerText = rm.GetString("Selectcurrency", ci);
            yousendlbl.InnerText = rm.GetString("Yousend", ci);
            youreceivelbl.InnerText = rm.GetString("Youreceive", ci);

            Exchangeratelbl.InnerText = rm.GetString("ExchRate", ci);
        }

        public void GetCXCurrenyID()
        {
            DataTable CxDt = new DataTable();
            CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
            if (CxDt.Rows.Count > 0)
            {
                DataRow dr = CxDt.Rows[0];
                Session["CX_CURR_CODE_S"] = dr["CURR_CODE"].ToString();
            }
        }

    }
}