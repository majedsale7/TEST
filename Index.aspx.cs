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

namespace KBE
{

    public partial class Index : System.Web.UI.Page
    {
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SecQuestionValidated_S"] = "";
            if (Page.IsPostBack == false)
            {
                if (Session["Lang"] == null)
                {
                    Session["Lang"] = "en-US";
                }
                else
                {
                    if (Session["Lang"].ToString() != "en-US")
                    {
                        LanguageBtn.InnerText = "English";
                        Session["Lang"] = "ar-KW";
                        LanguageBtn.Style.Add("class", "dropdown-toggle button inline-block bg-theme-1 text-white");
                    }
                    else if (Session["Lang"].ToString() == "en-US")
                    {
                        LanguageBtn.InnerText = "عربى";
                        Session["Lang"] = "en-US";
                        LanguageBtn.Style.Add("class", "dropdown-toggle button inline-block bg-theme-1 text-white language_ar");
                    }
                }

                CIDTxt.Focus();
                this.LoadLanguage();
            }

        }



        protected void SignupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup");
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            Signinlbl.Text = rm.GetString("Signin", ci);
            NextBtn.Text = rm.GetString("Next", ci);
            SignupBtn.Text = rm.GetString("Signup", ci);
            Supportlbl.Text = rm.GetString("TheSupport", ci);
            Needhelplbl.Text = rm.GetString("Needhelp", ci);
            Incaseanylbl.Text = rm.GetString("Incaseofany", ci);
            Manageyourlbl.Text = rm.GetString("Manageyourremittances", ci);
            Manageyourremmilbl.Text = rm.GetString("Manageyourremittances", ci);
            Signintolbl.Text = rm.GetString("Signintoyouraccount", ci);
            CIDTxt.Attributes.Add("placeholder", rm.GetString("CivilID", ci));

            if (Session["Lang"].ToString() == "ar-KW")
                Supportlbl.Font.Size = 20;
            else
                Supportlbl.Font.Size = 11;
        }

        protected void LanguageBtn_Click(object sender, EventArgs e)
        {
            if (LanguageBtn.InnerText != "English")
            {
                LanguageBtn.InnerText = "English";
                Session["Lang"] = "ar-KW";
                LanguageBtn.Style.Add("class", "dropdown-toggle button inline-block bg-theme-1 text-white");
            }
            else if (LanguageBtn.InnerText == "English")
            {
                LanguageBtn.InnerText = "عربى";
                Session["Lang"] = "en-US";
                LanguageBtn.Style.Add("class", "dropdown-toggle button inline-block bg-theme-1 text-white language_ar");
            }
            this.LoadLanguage();
        }

        protected async void NextBtn_Click(object sender, EventArgs e)
        {
            string Result = "";
            Result = await RestCls.ValidateCXID(CIDTxt.Text.Trim());
            if (Result.ToString() == "1")
            {
                Session["LoginID_CX"] = CIDTxt.Text.Trim();
                Response.Redirect("Password");
            }
            else
            {                
                Errorlbl.Text = Result.ToString();
                CIDTxt.Focus();
            }
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