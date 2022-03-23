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
    public partial class FAQPage : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadFAQs(Session["Lang"].ToString());
            }
            this.LoadLanguage();
        }

        public void LoadFAQs(string LangType)
        {
            DataTable FaqDt = new DataTable();
            FaqDt = RestCls.FAQList();

            if (FaqDt.Rows.Count > 0)
            {
                for (int i = 0; i < FaqDt.Rows.Count; i++)
                {
                    DataRow fdr = FaqDt.Rows[i];

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    dynD1.ID = "dynDiv1" + i.ToString();
                    dynD1.Attributes["class"] = "accordion__pane border border-gray-200 dark:border-dark-5 p-4";

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD2 = new System.Web.UI.HtmlControls.HtmlGenericControl("a");
                    dynD2.ID = "dynDiv2" + i.ToString();
                    dynD2.Attributes["class"] = "accordion__pane__toggle font-medium block";
                    if (LangType.ToString() == "en-US")
                        dynD2.InnerHtml = fdr["FAQ_QUES"].ToString();
                    else
                        dynD2.InnerHtml = fdr["FAQ_QUES_AR"].ToString();
                    dynD1.Controls.Add(dynD2);

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD3 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    dynD3.ID = "dynDiv3" + i.ToString();
                    dynD3.Attributes["class"] = "accordion__pane__content mt-3 text-gray-700 dark:text-gray-600 leading-relaxed";
                    dynD3.Style.Add(HtmlTextWriterStyle.Display, "none");
                    if (LangType.ToString() == "en-US")
                        dynD3.InnerHtml = fdr["FAQ_ANS"].ToString();
                    else
                        dynD3.InnerHtml = fdr["FAQ_ANS_AR"].ToString();
                    dynD1.Controls.Add(dynD3);

                    MainDiv.Controls.Add(dynD1);

                }
            }
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            FaqHeadlbl.Text = rm.GetString("FAQ", ci);

        }
    }
}