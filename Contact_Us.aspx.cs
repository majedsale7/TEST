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
    public partial class Contact_Us : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        RESTClass RestCls = new RESTClass();
        UpdateREST URest = new UpdateREST();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ContactUsInfo(Session["Lang"].ToString());
                this.CXInfo();
                this.LoadLanguage();
                this.Load_DropDowns(Session["Lang"].ToString());
            }

            this.SubmitBtn.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.SubmitBtn));
        }

        public void CXInfo()
        {
            DataTable CxDt = new DataTable();
            CxDt = RestCls.CXInfo(Session["LoginID_CX"].ToString());
            if (CxDt.Rows.Count > 0)
            {
                DataRow dr = CxDt.Rows[0];
                NameTxt.Text = dr["CUST_NAME_E"].ToString() + " " + dr["CUST_NAME_A"].ToString();
                EmailTxt.Text = dr["CUST_EMAIL"].ToString();
                PhoneNoTxt.Text = dr["CUST_TEL"].ToString();                
            }
        }

        public void ContactUsInfo(string LangType)
        {
            DataTable ContDt = new DataTable();
            ContDt = RestCls.ContactUs();
            if (ContDt.Rows.Count > 0)
            {
                for (int i = 0; i < ContDt.Rows.Count; i++)
                {
                    DataRow dr = ContDt.Rows[i];
                    if (dr["TITLE"].ToString() == "Corporate Address")
                    {
                        if (LangType == "en-US")
                            CoprAdd.InnerText = dr["CONT_INFO"].ToString();
                        else
                            CoprAdd.InnerText = dr["CONT_INFO_AR"].ToString();
                    }
                    if (dr["TITLE"].ToString() == "Phone")
                    {
                        if (LangType == "en-US")
                            ContactNolbl.Text = dr["CONT_INFO"].ToString();
                        else
                            ContactNolbl.Text = dr["CONT_INFO_AR"].ToString();
                    }
                    if (dr["TITLE"].ToString() == "Email")
                    {
                        if (LangType == "en-US")
                            emailIDTxt.Text = dr["CONT_INFO"].ToString();
                        else
                            emailIDTxt.Text = dr["CONT_INFO_AR"].ToString();
                    }
                }
            }
        }

        protected async void SubmitBtn_Click(object sender, EventArgs e)
        {
            string CustIDStr = "", InqrTypeStr = "", InqrSubjectStr = "", InqrtTextStr = "";

            CustIDStr = Session["LoginID_CX"].ToString();
            InqrTypeStr = EnquiryDDL.SelectedValue;
            InqrSubjectStr = SubjectTxt.Text.Trim();
            InqrtTextStr = CommentsTxt.Text.Trim();
            string Result = await URest.UserEnquiryUpdate(CustIDStr, InqrTypeStr, InqrSubjectStr, InqrtTextStr);

            string FResult = "";
            try
            {
                FResult = Result.Substring(0, 5).ToUpper();
            }
            catch (Exception sdf) { }

            if (FResult == "ERROR")
            {
                MessageBox_Error(Result);
            }
            else
            {
                MessageBox_OK(Result);
                this.ClearFields();
            }
        }
               
        public void ClearFields()
        {
            EnquiryDDL.SelectedIndex = 0;
            NameTxt.Text = "";
            EmailTxt.Text = "";
            PhoneNoTxt.Text = "";
            SubjectTxt.Text = "";
            CommentsTxt.Text = "";
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            ContactusHeadlbl.Text = rm.GetString("Contactus", ci);
            Contactformlbl.Text = rm.GetString("Contactform", ci);
            Namelbl.Text = rm.GetString("Name", ci) + "*";
            Emaillbl.Text = rm.GetString("Email", ci);
            PhoneNolbl.Text = rm.GetString("Phone", ci) + "*";
            Subjectlbl.Text = rm.GetString("Subject", ci) + "*";
            Enquirylbl.Text = rm.GetString("Enquiryfor", ci) + "*";
            Commentslbl.Text = rm.GetString("Comments", ci);
            SubmitBtn.Text = rm.GetString("Submit", ci);

            Corporateaddresslbl.InnerText = rm.GetString("Corporateaddress", ci);
            Contactatlbl.InnerText = rm.GetString("Contactat", ci);
            Operationofficelbl.InnerText = rm.GetString("Operationoffice", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }
        public void Load_DropDowns(string LangType)
        {
            EnquiryDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectenquirytype", LangType)); EnquiryDDL.SelectedValue = CommCls.Messages_Eng_Arabic("Selectenquirytype", LangType);
        }
        public void Validation_Messages(string LangType)
        {
            NameTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Namerequired", LangType);
            EmailTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidemailid", LangType);
            PhoneNoTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Mobilenorequired", LangType);
            SubjectTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Subjectrequired", LangType);
            EnquiryDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Enquirytyperequired", LangType);
            EnquiryDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectenquirytype", LangType);
            CommentsTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Commentsrequired", LangType);
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