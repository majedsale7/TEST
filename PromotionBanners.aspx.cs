using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KBE.RESTFull;
using KBE.Models;
using System.Data;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace KBE
{
    public partial class PromotionBanners : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Get_Promotions();
            }
            this.LoadLanguage();
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

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            PromotionsHeadlbl.Text = rm.GetString("Promotions", ci);            

        }
    }
}