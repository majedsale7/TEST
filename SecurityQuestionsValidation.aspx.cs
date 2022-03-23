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
using System.Text;
using KBE.Models;

namespace KBE
{
    public partial class SecurityQuestionsValidation : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["SQ_Level1"] = "";
                ViewState["SQ_Level2"] = "";
                this.Get_SecurityQuestions();
                this.LoadLanguage();
            }         
        }
        public void Get_SecurityQuestions()
        {
            string SecQues = "";
            string SecAnswer = "";
            SecQuestionAnswerTxt.Text = "";
                        
            var random = new Random();
            DataTable SecQDt = new DataTable();            
            if (ViewState["SQ_Level1"].ToString() == "" && ViewState["SQ_Level2"].ToString() == "")
                SecQDt = RestCls.SecurityQnAToValidate(Session["LoginID_CX"].ToString(), "1");
            if (ViewState["SQ_Level1"].ToString() != "" && ViewState["SQ_Level2"].ToString() == "")
                SecQDt = RestCls.SecurityQnAToValidate(Session["LoginID_CX"].ToString(), "2");

            int RndNum = random.Next(0, 2);

            if (SecQDt.Rows.Count > 0)
            {
                try
                {
                    DataRow Secdr = SecQDt.Rows[RndNum];
                    if (Session["Lang"].ToString() == "en-US")
                        SecQues = Secdr["QUES_DESC"].ToString();
                    else
                        SecQues = Secdr["QUES_DESC_AR"].ToString();
                    SecAnswer = Secdr["QUES_ANS"].ToString();
                    SecQuestionlbl.InnerText = SecQues;
                    Session["SecQuestionAnswer2Validate_S"] = SecAnswer.ToString();
                    SecQuestionAnswerTxt.Focus();
                }
                catch (Exception dfgd)
                {
                    DataRow Secdr = SecQDt.Rows[0];
                    if (Session["Lang"].ToString() == "en-US")
                        SecQues = Secdr["QUES_DESC"].ToString();
                    else
                        SecQues = Secdr["QUES_DESC_AR"].ToString();
                    SecAnswer = Secdr["QUES_ANS"].ToString();
                    SecQuestionlbl.InnerText = SecQues;
                    Session["SecQuestionAnswer2Validate_S"] = SecAnswer.ToString();
                    SecQuestionAnswerTxt.Focus();
                }

                if (ViewState["SQ_Level1"].ToString() == "" && ViewState["SQ_Level2"].ToString() == "")
                    SecurityLevellbl.InnerText = CommCls.Messages_Eng_Arabic("Securityquestion1of2", Session["Lang"].ToString());
                if (ViewState["SQ_Level1"].ToString() != "" && ViewState["SQ_Level2"].ToString() == "")
                    SecurityLevellbl.InnerText = CommCls.Messages_Eng_Arabic("Securityquestion2of2", Session["Lang"].ToString());
            }
            else
            {
                SecQuestionlbl.InnerText = CommCls.Messages_Eng_Arabic("MSG_Cantreadsecurityquestionpleaserefreshpage", Session["Lang"].ToString());
                Session["SecQuestionAnswer2Validate_S"] = "";
            }



        }
        protected void SecValidateBtn_Click(object sender, EventArgs e)
        {
            if (Session["SecQuestionAnswer2Validate_S"].ToString().ToLower() == SecQuestionAnswerTxt.Text.Trim().ToLower())
            {
                if (ViewState["SQ_Level1"].ToString() == "")
                {
                    ViewState["SQ_Level1"] = "Done";
                    this.Get_SecurityQuestions();
                }
                else if (ViewState["SQ_Level1"].ToString() != "" && ViewState["SQ_Level2"].ToString() == "")
                {
                    ViewState["SQ_Level2"] = "Done";
                    Session["SecQuestionValidated_S"] = "Validated";
                    Response.Redirect(Session["GoBackPage_S"].ToString());
                }
            }
            else
            {
                SecQuestionAnswerTxt.Text = "";
                MessageBox_Error("Invalid Security Answer");
                this.Get_SecurityQuestions();
            }
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            IdentifyHlbl.InnerText = rm.GetString("Identityverification", ci);
            SecValidateBtn.Text = rm.GetString("Validate", ci);
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