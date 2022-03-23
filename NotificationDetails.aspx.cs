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
    public partial class NotificationDetails : System.Web.UI.Page
    {
        UpdateREST UpRestCls = new UpdateREST();
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadNotifications();
                this.UpdateReadStatus();
            }
            this.LoadLanguage();
            this.ClearBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.ClearBtn));
        }

        public void LoadNotifications()
        {
            DataTable NotifyDt = new DataTable();
            NotifyDt = RestCls.NotificationsList(Session["LoginID_CX"].ToString());

            if (NotifyDt.Rows.Count > 0)
            {
                for (int i = 0; i < NotifyDt.Rows.Count; i++)
                {
                    DataRow fdr = NotifyDt.Rows[i];

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    dynD1.ID = "dynDiv1" + i.ToString();
                    dynD1.Attributes["class"] = "intro-y  p-5 box mt-8";

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD2 = new System.Web.UI.HtmlControls.HtmlGenericControl("h3");
                    dynD2.ID = "dynDiv2" + i.ToString();
                    dynD2.Attributes["class"] = "intro-y font-medium text-xl sm:text-1xl";
                    dynD2.InnerHtml = fdr["NF_TITLE"].ToString();
                    dynD1.Controls.Add(dynD2);

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD3 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    dynD3.ID = "dynDiv3" + i.ToString();
                    dynD3.Attributes["class"] = "intro-y text-justify leading-relaxed mt-2";
                    dynD1.Controls.Add(dynD3);

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD4 = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                    dynD4.ID = "dynDiv4" + i.ToString();
                    dynD4.InnerHtml = fdr["NF_MSG"].ToString();
                    dynD1.Controls.Add(dynD4);

                    System.Web.UI.HtmlControls.HtmlGenericControl dynD5 = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                    dynD5.ID = "dynDiv5" + i.ToString();
                    dynD5.InnerHtml = Convert.ToDateTime(fdr["CREATED_ON"].ToString()).ToString("dd-MMM-yyyy, hh:mm tt");
                    dynD1.Controls.Add(dynD5);

                    MainDiv.Controls.Add(dynD1);

                }
            }

        }
        public async void UpdateReadStatus()
        {
            string Result = "";
            try
            {
                Result = await UpRestCls.NotificationReadUpdate(Session["LoginID_CX"].ToString(), "VIEWED");
            }
            catch (Exception dfg) { }

        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            Notificationslbl.Text = rm.GetString("Notifications", ci);
            ClearBtn.Text = rm.GetString("Clearnotifications", ci);
        }

        protected async void ClearBtn_Click(object sender, EventArgs e)
        {
            string Result = "";
            try
            {
                Result = await UpRestCls.NotificationReadUpdate(Session["LoginID_CX"].ToString(), "INACTIVE");
            }
            catch (Exception dfg) { }
            this.LoadNotifications();
        }
    }
}