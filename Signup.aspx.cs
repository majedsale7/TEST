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
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace KBE
{
    public partial class Signup : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST URest = new UpdateREST();
        UpdateREST UpRestCls = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
            {
                Session["Lang"] = "en-US";
            }
            if (Page.IsPostBack == false)
            {
                CIDTxt.Focus();
                this.LoadLanguage();
                this.LoadDropDowns(Session["Lang"].ToString());
                ViewState["OTPSent_V"] = "";                
                this.DynamicLang_Values("Send OTP");
                this.Get_TermsNConditions();
                NextBtn0.Attributes.Add("disabled", "true");

                CounterSpan.Visible = false;
            }

            if (this.MobileTxt.Text.Trim().Length > 0)
                this.MobileTxt.Attributes.Add("value", this.MobileTxt.Text);

            if (this.OTPTxt.Text.Trim().Length > 0)
                this.OTPTxt.Attributes.Add("value", this.OTPTxt.Text);

            if (this.PWDTxt.Text.Trim().Length > 0)
                this.PWDTxt.Attributes.Add("value", this.PWDTxt.Text);

            if (this.CPWDTxt.Text.Trim().Length > 0)
                this.CPWDTxt.Attributes.Add("value", this.CPWDTxt.Text);

            if (this.FUCID.FileName.Length > 0)
                this.FUCID.Attributes.Add("value", this.FUCID.FileName);

            if (this.CIDTxt.Text.Trim().Length > 0)
                this.LoginIDTxt.Attributes.Add("value", this.CIDTxt.Text);

            this.btnSubmit.Attributes.Add("onclick", CommCls.DisableWValid(this.Page, this.btnSubmit));
            this.OTPSendBtn.Attributes.Add("onclick", CommCls.DisableWOUTValid(this.Page, this.OTPSendBtn));

            string ImgUrl = "";
            if (Session["FileUpload1"] == null && FUCID.HasFile)
            {
                Session["FileUpload1"] = FUCID;
                ImgUrl = FUCID.FileName;             
            }
            else if (Session["FileUpload1"] != null && (!FUCID.HasFile))
            {
                FUCID = (FileUpload)Session["FileUpload1"];                
                ImgUrl = FUCID.FileName;
            }
            else if (FUCID.HasFile)
            {
                Session["FileUpload1"] = FUCID;                
                ImgUrl = FUCID.FileName;
            }

            string ImgUrl2 = "";
            if (Session["FileUpload2"] == null && FUCID2.HasFile)
            {
                Session["FileUpload2"] = FUCID2;
                ImgUrl2 = FUCID2.FileName;                
            }
            else if (Session["FileUpload2"] != null && (!FUCID2.HasFile))
            {
                FUCID2 = (FileUpload)Session["FileUpload2"];                
                ImgUrl2 = FUCID2.FileName;
            }
            else if (FUCID2.HasFile)
            {
                Session["FileUpload2"] = FUCID2;                
                ImgUrl2 = FUCID2.FileName;
            }

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
            this.DynamicLang_Values("Send OTP");
            this.LoadDropDowns(Session["Lang"].ToString());

            if (ViewState["OTPSent_V"].ToString() != "")
            {
                NextBtn0.Attributes.Remove("disabled");
            }

        }
        public void LoadLanguage()
        {
            if (Session["Lang"].ToString() == "en-US")
                LanguageBtn.InnerText = "عربى";
            else
                LanguageBtn.InnerText = "English";

            ArabicWZ.Visible = false;
            EnglishWZ.Visible = false;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());


            if (Session["Lang"].ToString() == "ar-KW")
                ArabicWZ.Visible = true;
            else
                EnglishWZ.Visible = true;

            CreateNewAcctlbl.Text = rm.GetString("CreateNewAccount", ci);
            civilidlbl.InnerText = rm.GetString("CivilID", ci) + " *";
            enterOTPlbl.InnerText = rm.GetString("EnterOTP", ci) + " *";
            firstnamelbl.InnerText = rm.GetString("FirstName", ci) + " *";
            middlenamelbl.InnerText = rm.GetString("Middlename", ci);
            lastnamelbl.InnerText = rm.GetString("LastName", ci) + " *";
            salarylbl.InnerText = rm.GetString("Salary", ci) + " *";
            sponsorlbl.InnerText = rm.GetString("Sponsor", ci) + " *";
            genderlbl.InnerText = rm.GetString("Gender", ci) + " *";
            nationalitylbl.InnerText = rm.GetString("Nationality", ci) + " *";
            dateofbirthlbl.InnerText = rm.GetString("DateOfBirth", ci) + " *";
            CivilIDExpirylbl.InnerText = rm.GetString("Civilidexpiry", ci) + " *";
            occupationlbl.InnerText = rm.GetString("Occupation", ci);
            mobilenolbl.InnerText = rm.GetString("MobileNo", ci) + " *";
            emaillbl.InnerText = rm.GetString("Email", ci);
            areainkuwaitlbl.InnerText = rm.GetString("AreaInKuwait", ci) + " *";
            blocklbl.InnerText = rm.GetString("Block", ci) + " *";
            streetlbl.InnerText = rm.GetString("Street", ci) + " *";
            buildingnolbl.InnerText = rm.GetString("Building", ci) + " *";
            floornolbl.InnerText = rm.GetString("Floor", ci) + " *";
            flatnolbl.InnerText = rm.GetString("Flat", ci) + " *";

            loginidlbl.InnerText = rm.GetString("LoginID", ci);
            passwordlbl.InnerText = rm.GetString("Password", ci) + " *";
            confirmpasswordlbl.InnerText = rm.GetString("ConfirmPassword", ci) + " *";
            securityquestion1lbl.InnerText = rm.GetString("SecurityQuestion", ci) + " 1 *";
            answer1lbl.InnerText = rm.GetString("Answer", ci) + " *";
            securityquestion2lbl.InnerText = rm.GetString("SecurityQuestion", ci) + " 2 *";
            answer2lbl.InnerText = rm.GetString("Answer", ci) + " *";
            securityquestion3lbl.InnerText = rm.GetString("SecurityQuestion", ci) + " 3 *";
            answer3lbl.InnerText = rm.GetString("Answer", ci) + " *";
            securityquestion4lbl.InnerText = rm.GetString("SecurityQuestion", ci) + " 4 *";
            answer4lbl.InnerText = rm.GetString("Answer", ci) + " *";

            FrontCIDUploadlbl.InnerText = rm.GetString("Frontcivilidupload", ci);
            BackCIDUplaodlbl.InnerText = rm.GetString("Backcivilidupload", ci);
            Imagesizelbl.InnerText = rm.GetString("Imagesizeshouldbe", ci);
            Imagesizelbl2.InnerText = rm.GetString("Imagesizeshouldbe", ci);
            Agreelbl.InnerText = rm.GetString("Iacceptagree", ci);
            Signinlbl.InnerText = rm.GetString("Signininstead", ci);

            ReadtncAnchor.InnerText = rm.GetString("TermsNConditions", ci);

            BackBtn1.Value = rm.GetString("Back", ci);
            BackBtn2.Value = rm.GetString("Back", ci);
            NextBtn1.Value = rm.GetString("Next", ci);
            NextBtn2.Value = rm.GetString("Next", ci);
            btnSubmit.Value = rm.GetString("Submit", ci);
            NextBtn0.Value = rm.GetString("Next", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }
        public void Get_TermsNConditions()
        {
            DataTable TnCDt = new DataTable();
            TnCDt = RestCls.TermsNConditions();
            if (TnCDt.Rows.Count > 0)
            {
                DataRow drTnC = TnCDt.Rows[0];
                TnCPara.Text = drTnC["TERM_TEXT"].ToString();                
            }
        }

        protected async void SubmitBtn_Click(object sender, EventArgs e)
        {

            if (FUCID.HasFile && FUCID2.HasFile)
            {
                string CIDExtn = "", CIDFName = "";
                string CIDExtn2 = "", CIDFName2 = "";

                try
                {
                    CIDFName = FUCID.PostedFile.FileName;
                    CIDExtn = System.IO.Path.GetExtension(CIDFName);

                    CIDFName2 = FUCID2.PostedFile.FileName;
                    CIDExtn2 = System.IO.Path.GetExtension(CIDFName2);
                }
                catch { }

                System.Drawing.Image Cimg = System.Drawing.Image.FromStream(FUCID.PostedFile.InputStream);
                int height = Cimg.Height;
                int width = Cimg.Width;
                decimal Csize = Math.Round(((decimal)FUCID.PostedFile.ContentLength / (decimal)1024), 2);

                System.Drawing.Image Cimg2 = System.Drawing.Image.FromStream(FUCID2.PostedFile.InputStream);
                int height2 = Cimg2.Height;
                int width2 = Cimg2.Width;
                decimal Csize2 = Math.Round(((decimal)FUCID2.PostedFile.ContentLength / (decimal)1024), 2);                

                if (CIDExtn != ".gif" && CIDExtn != ".jpg" && CIDExtn != ".jpeg" && CIDExtn != ".bmp" && CIDExtn != ".png" && CIDExtn != ".JPG")
                {
                    MessageBox(CommCls.Messages_Eng_Arabic("MSG_PleaseuploadJPGPNGformattedimageonly", Session["Lang"].ToString()));
                }                
                if (CIDExtn2 != ".gif" && CIDExtn2 != ".jpg" && CIDExtn2 != ".jpeg" && CIDExtn2 != ".bmp" && CIDExtn2 != ".png" && CIDExtn2 != ".JPG")
                {
                    MessageBox(CommCls.Messages_Eng_Arabic("MSG_PleaseuploadJPGPNGformattedimageonly", Session["Lang"].ToString()));
                }                
                else if (ConfirmCHK.Checked == false)
                {
                    MessageBox(CommCls.Messages_Eng_Arabic("MSG_Pleaseconfirmbycheckingtermsandconditions", Session["Lang"].ToString()));
                }
                else
                {
                    CultureInfo ci = new CultureInfo("sl-SI", true);
                    ci.DateTimeFormat.DateSeparator = "/";
                    ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                    DateTime DOBCul = DateTime.Parse(DOBTxt.Text.Trim(), ci);
                    DateTime CIDExpCul = DateTime.Parse(CIDExpTxt.Text.Trim(), ci);                   

                    string CIDExtn1 = System.IO.Path.GetExtension(FUCID.PostedFile.FileName);
                    string CIDFName1 = CIDTxt.Text.Trim() + "_Front" + CIDExtn1; 
                    int lastSlash1 = CIDFName1.LastIndexOf("\\");
                    string trailingPath1 = CIDFName1.Substring(lastSlash1 + 1);
                    string fullPath1 = Server.MapPath(" ") + "\\CIDTemp\\" + trailingPath1;

                    CIDExtn2 = System.IO.Path.GetExtension(FUCID2.PostedFile.FileName);
                    CIDFName2 = CIDTxt.Text.Trim() + "_Back" + CIDExtn2;
                    int lastSlash2 = CIDFName2.LastIndexOf("\\");
                    string trailingPath2 = CIDFName2.Substring(lastSlash2 + 1);
                    string fullPath2 = Server.MapPath(" ") + "\\CIDTemp\\" + trailingPath2;

                    MemoryStream stream1 = new MemoryStream(FUCID.FileBytes);
                    this.GenerateThumbnails(0.5, stream1, fullPath1);

                    MemoryStream stream2 = new MemoryStream(FUCID2.FileBytes);
                    this.GenerateThumbnails(0.5, stream2, fullPath2);

                    //FTP Server URL. 
                    string ftp = "ftp://168.187.116.75/";
                    byte[] fileBytes1 = File.ReadAllBytes(fullPath1);
                    byte[] fileBytes2 = File.ReadAllBytes(fullPath2);                   


                    Session["UserSessionID_S"] = HttpContext.Current.Session.SessionID;
                    Session["UserMachineIP_S"] = CommCls.GetIPAddress();

                    string CIDStr = "", CustName_E = "", CustName_A = "", CustMiddle_Name, Cust_Nation = "", Gender = "";
                    string CustDOB = "", CustID_Exp = "", Cust_Tel = "", Cust_City = "", CustBlock = "", Cust_Street = "", Cust_Bldg = "";
                    string FloorNo = "", FlatNo = "", CustAdd = "", Cust_Email = "", LoginID = "", LoginPwd = "", Occup = "", Remarks = "";
                    string SalaryRange = "", SponsorName = "", UserIP = "", UserSessionID = "";
                    CIDStr = CIDTxt.Text.Trim();
                    CustName_E = FNameTxt.Text.Trim();
                    CustName_A = LNameTxt.Text.Trim();
                    CustMiddle_Name = MNameTxt.Text.Trim();
                    Cust_Nation = CountryDDL.SelectedValue;
                    Gender = GenderDDL.SelectedValue;
                    CustDOB = Convert.ToDateTime(DOBCul).ToString("dd-MMM-yy");
                    CustID_Exp = Convert.ToDateTime(CIDExpCul).ToString("dd-MMM-yy");
                    if (OccupDDL.SelectedItem.Text != CommCls.Messages_Eng_Arabic("Selectoccupation", Session["Lang"].ToString()))
                        Occup = OccupDDL.SelectedValue;
                    Cust_Tel = ViewState["CXMobileNo_V"].ToString();
                    Cust_City = AreaTxt.Text.Trim();
                    CustBlock = BlockTxt.Text.Trim();
                    Cust_Street = StreetTxt.Text.Trim();
                    Cust_Bldg = BuildingTxt.Text.Trim();
                    FloorNo = FloorTxt.Text.Trim();
                    FlatNo = FlatTxt.Text.Trim();
                    CustAdd = AreaTxt.Text.Trim();
                    Cust_Email = EmailTxt.Text.Trim();
                    LoginID = CIDStr;
                    LoginPwd = PWDTxt.Text.Trim();
                    Remarks = "";
                    SalaryRange = SalaryDDL.SelectedValue;
                    SponsorName = SponsorTxt.Text.Trim();
                    UserIP = Session["UserMachineIP_S"].ToString();
                    UserSessionID = Session["UserSessionID_S"].ToString();

                    string QID1 = "", QID2 = "", QID3 = "", QID4 = "";
                    string QAns1 = "", QAns2 = "", QAns3 = "", QAns4 = "";

                    QID1 = SecQ1DDL.SelectedValue;
                    QID2 = SecQ2DDL.SelectedValue;
                    QID3 = SecQ3DDL.SelectedValue;
                    QID4 = SecQ4DDL.SelectedValue;
                    QAns1 = SecQ1Txt.Text.Trim();
                    QAns2 = SecQ2Txt.Text.Trim();
                    QAns3 = SecQ3Txt.Text.Trim();
                    QAns4 = SecQ4Txt.Text.Trim();                    

                    string RegResult = await URest.CustomerRegister("WEB_APP", "122323", CIDStr, CustName_E, CustName_A, CustMiddle_Name, Cust_Nation,
                        Gender, CustDOB, CustID_Exp, Cust_Tel, Cust_City, CustBlock, Cust_Street, Cust_Bldg, FloorNo,
                        FlatNo, CustAdd, Cust_Email, LoginID, LoginPwd, Occup, Remarks, SalaryRange, SponsorName, UserIP, UserSessionID);

                    string FResult = "";
                    try
                    {
                        FResult = RegResult.Substring(0, 5).ToUpper();
                    }
                    catch (Exception sdf) { }


                    if (FResult == "ERROR")
                    {
                        NextBtn0.Attributes.Remove("disabled");

                        MobileTxt_ReqF.ErrorMessage = "";
                        MobileTxt_RegExp.ErrorMessage = "";

                        OTPTxt_ReqF.ErrorMessage = "";

                        MessageBox(RegResult);
                    }
                    else
                    {
                        string SecResult1 = await URest.SecurityQuestionUpdate(LoginID, QID1, QAns1);
                        string SecResult2 = await URest.SecurityQuestionUpdate(LoginID, QID2, QAns2);
                        string SecResult3 = await URest.SecurityQuestionUpdate(LoginID, QID3, QAns3);
                        string SecResult4 = await URest.SecurityQuestionUpdate(LoginID, QID4, QAns4);                       

                        try
                        {
                            using (SftpClient sftpClient1 = new SftpClient(getSftpConnection("168.187.116.75", "user", 22, Server.MapPath(" ") + "\\SFTPKey\\id_rsa")))
                            {
                                Console.WriteLine("Connect to server");
                                sftpClient1.Connect();
                                Console.WriteLine("Creating FileStream object to stream a file");
                                using (FileStream fs1 = new FileStream(fullPath1, FileMode.Open))
                                {
                                    //sftpClient.BufferSize = 1024;
                                    sftpClient1.BufferSize = 2048;
                                    sftpClient1.UploadFile(fs1, Path.GetFileName(fullPath1));
                                }
                                sftpClient1.Dispose();
                            }
                        }
                        catch (WebException ex)
                        {
                            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
                        }

                        try
                        {                           
                            using (SftpClient sftpClient2 = new SftpClient(getSftpConnection("168.187.116.75", "user", 22, Server.MapPath(" ") + "\\SFTPKey\\id_rsa")))
                            {
                                Console.WriteLine("Connect to server");
                                sftpClient2.Connect();
                                Console.WriteLine("Creating FileStream object to stream a file");
                                using (FileStream fs2 = new FileStream(fullPath2, FileMode.Open))
                                {                                    
                                    sftpClient2.BufferSize = 2048;
                                    sftpClient2.UploadFile(fs2, Path.GetFileName(fullPath2));
                                }
                                sftpClient2.Dispose();
                            }
                        }
                        catch (WebException ex)
                        {
                            throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
                        }
                        
                        this.MessageBox(RegResult);
                        this.ClearFields();
                    }                    

                }
            }
            else
            {
                MessageBox(CommCls.Messages_Eng_Arabic("MSG_Pleasechoosecivilid", Session["Lang"].ToString()));
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
        public void MessageBox(string msg)
        {
            ClientScriptManager script = Page.ClientScript;
            if (!script.IsClientScriptBlockRegistered(this.GetType(), "Alert"))
            {
                script.RegisterClientScriptBlock(this.GetType(), "KBE", "alert('" + msg + "')", true);
            }
        }

        public void ClearFields()
        {
            CIDTxt.Text = "";
            FNameTxt.Text = ""; LNameTxt.Text = "";
            CountryDDL.SelectedIndex = 0;
            GenderDDL.SelectedIndex = 0;
            OccupDDL.SelectedIndex = 0;
            MobileTxt.Text = "";
            AreaTxt.Text = "";
            BlockTxt.Text = "";
            StreetTxt.Text = "";
            BuildingTxt.Text = "";
            FloorTxt.Text = "";
            FlatTxt.Text = "";
            AreaTxt.Text = "";
            EmailTxt.Text = "";
            PWDTxt.Text = "";
            SecQ1DDL.SelectedIndex = 0;
            SecQ2DDL.SelectedIndex = 0;
            SecQ3DDL.SelectedIndex = 0;
            SecQ4DDL.SelectedIndex = 0;
            SecQ1Txt.Text = "";
            SecQ2Txt.Text = "";
            SecQ3Txt.Text = "";
            SecQ4Txt.Text = "";
            CPWDTxt.Text = "";
            LoginIDTxt.Text = "";
            ConfirmCHK.Checked = false;
            DOBTxt.Text = CommCls.TimeZoneDateTime().ToString("dd/MM/yyyy");
            CIDExpTxt.Text = CommCls.TimeZoneDateTime().ToString("dd/MM/yyyy");

            OTPSendBtn.Text = "Send OTP";
            CounterSpan.Visible = false;
            NextBtn0.Attributes.Add("disabled", "true");
            OTPTxt.Text = "";
            OTPSendBtn.Visible = true;

            this.PWDTxt.Attributes.Add("value", "");
            this.CPWDTxt.Attributes.Add("value", "");
            this.LoginIDTxt.Attributes.Add("value", "");
            this.OTPTxt.Attributes.Add("value", "");
            this.MobileTxt.Attributes.Add("value", "");
            ViewState["CXMobileNo_V"] = "";
        }

        protected async void OTPSendBtn_Click(object sender, EventArgs e)
        {
            if (InitiSecs_HD.Value != "" && OTPTxt.Text.Trim() == "")
            {
                OTPinvalidlbl.Text = CommCls.Messages_Eng_Arabic("MSG_PleaseclickonsendOTptoreceiveOTP", Session["Lang"].ToString());
            }
            else if (CIDTxt.Text.Trim() == "")
            {
                CIDErrorlbl.Text = CommCls.Messages_Eng_Arabic("Enteryourcivilidnumber", Session["Lang"].ToString());
            }
            else if (MobileTxt.Text.Trim() == "")
            {
                OTPinvalidlbl.Text = CommCls.Messages_Eng_Arabic("Enteryourmobilenumber", Session["Lang"].ToString());
            }
            else
            {
                if (MobileTxt.Text.Trim().Length == 8)
                {
                    string Mob1StNo = MobileTxt.Text.Trim().Substring(0, 1);
                    if (Mob1StNo.ToString() == "5" || Mob1StNo.ToString() == "6" || Mob1StNo.ToString() == "9")
                    {
                        string x = await this.Send_SMSOTP();
                    }
                }
            }
        }
        protected void OTPTxt_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["OTPSent_V"].ToString() == "")
            {
                OTPinvalidlbl.Text = CommCls.Messages_Eng_Arabic("MSG_PleaseclickonsendOTptoreceiveOTP", Session["Lang"].ToString());
            }
            else if (OTPTxt.Text.Trim() != ViewState["OTPSent_V"].ToString())
            {
                OTPTxt.Text = "";
                OTPinvalidlbl.Text = CommCls.Messages_Eng_Arabic("MSG_InvalidOTP", Session["Lang"].ToString());
                NextBtn0.Attributes.Add("disabled", "true");
            }
            else if (OTPTxt.Text.Trim() == ViewState["OTPSent_V"].ToString())
            {
                NextBtn0.Attributes.Add("disabled", "false");

                InitiSecs_HD.Value = "0";
                CounterSpan.Visible = false;
                OTPinvalidlbl.Text = "";
                OTPSendBtn.Visible = false;
                CIDErrorlbl.Text = "";

                CIDTxt.Attributes.Add("disabled", "true");
                MobileTxt.Attributes.Add("disabled", "true");
                OTPTxt.Attributes.Add("disabled", "true");
            }
        }
        public async Task<string> Send_SMSOTP()
        {
            ViewState["OTPSent_V"] = "";
            string CXMobileNo = "", FinalResult = "";
            CXMobileNo = "965" + MobileTxt.Text.Trim();
            string Result = "", OTPType = "RG";

            Result = await UpRestCls.GetOTP(CIDTxt.Text.Trim(), OTPType);
            ViewState["OTPSent_V"] = Result.ToString();

            string SMSResult = "", SMSMsg = "", LangIDStr = "";

            if (Session["Lang"].ToString() == "en-US")
                LangIDStr = "1";
            else
                LangIDStr = "2";

            if (LangIDStr.ToString() == "1")
            {
                SMSMsg += "Dear KBE Customer,\n";
                SMSMsg += "OTP: " + Result + "\n";
                SMSMsg += "Please DO NOT DISCLOSE this OTP to anyone.\n";
                SMSMsg += "Thank you for using KBE Online Services.\n";
                SMSMsg += CommCls.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
            }
            else
            {
                SMSMsg += "\n عزيزي عميل KBE ،";
                SMSMsg += "\n " + Result + " :OTP ";
                SMSMsg += "\n يرجى عدم الكشف عن كلمة المرور لمرة واحدة لأي شخص.";
                SMSMsg += "\n شكرا لك على استخدام خدمات KBE. ";
                SMSMsg += CommCls.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
            }
            SMSResult = RestCls.SendSMS(LangIDStr, CXMobileNo, SMSMsg);

            string Result_SMS = "";
            try
            {
                try
                {
                    Result_SMS = SMSResult.Substring(0, 2).ToUpper();
                }
                catch (Exception sdf) { }

                if (Result_SMS.ToString() == "OK")
                {
                    FinalResult = "OK";

                    ViewState["CXMobileNo_V"] = MobileTxt.Text.Trim();                    
                    this.DynamicLang_Values("Resend OTP");
                    CounterSpan.Visible = true;
                    Counterlbl.InnerText = "0";
                    InitiSecs_HD.Value = "120";
                    enterOTPlbl.Visible = true;

                    CIDTxt.Attributes.Add("disabled", "true");
                    MobileTxt.Attributes.Add("disabled", "true");

                    NextBtn0.Attributes.Add("disabled", "true");
                }
                else
                {
                    this.MessageBox(SMSResult);
                }
            }
            catch (Exception sdf) { }
            
            return FinalResult;

        }


        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {

                var newWidth = (int)(image.Width * scaleFactor);

                var newHeight = (int)(image.Height * scaleFactor);

                var thumbnailImg = new Bitmap(newWidth, newHeight);

                var thumbGraph = Graphics.FromImage(thumbnailImg);

                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;

                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;

                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);

                thumbGraph.DrawImage(image, imageRectangle);

                thumbnailImg.Save(targetPath, image.RawFormat);
            }

        }

        public void LoadDropDowns(string LangType)
        {
            //Gender
            GenderDDL.Items.Clear();
            GenderDDL.Items.Insert(0, new ListItem(CommCls.Messages_Eng_Arabic("Male", LangType), "M"));
            GenderDDL.Items.Insert(1, new ListItem(CommCls.Messages_Eng_Arabic("Female", LangType), "F"));
            GenderDDL.SelectedIndex = 0;

            //Country
            CountryDDL.Items.Clear();
            Country_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                CountryDDL.DataTextField = "COUN_NAME";
            else
                CountryDDL.DataTextField = "COUN_NAME_AR";
            CountryDDL.DataValueField = "COUN_CODE3";            
            CountryDDL.Items.Insert(0, ""); CountryDDL.SelectedItem.Text = "";

            //Occupation
            OccupDDL.Items.Clear();
            Occup_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                OccupDDL.DataTextField = "DESC_E";
            else
                OccupDDL.DataTextField = "DESC_A";
            OccupDDL.DataValueField = "LOOKUP_ID";
            OccupDDL.Items.Insert(0, ""); OccupDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectoccupation", LangType);

            //salary
            SalaryDDL.Items.Clear();
            Salary_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SalaryDDL.DataTextField = "DESC_E";
            else
                SalaryDDL.DataTextField = "DESC_A";
            SalaryDDL.DataValueField = "LOOKUP_ID";            
            SalaryDDL.Items.Insert(0, ""); SalaryDDL.SelectedItem.Text = "";

            //Security Q1
            SecQ1DDL.Items.Clear();
            SecQ1_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ1DDL.DataTextField = "QUESTION";
            else
                SecQ1DDL.DataTextField = "QUESTION_AR";
            SecQ1DDL.DataValueField = "QUES_ID";
            SecQ1DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ1DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

            //Security Q2
            SecQ2DDL.Items.Clear();
            SecQ1_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ2DDL.DataTextField = "QUESTION";
            else
                SecQ2DDL.DataTextField = "QUESTION_AR";
            SecQ2DDL.DataValueField = "QUES_ID";
            SecQ2DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ2DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

            //Security Q3
            SecQ3DDL.Items.Clear();
            SecQ2_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ3DDL.DataTextField = "QUESTION";
            else
                SecQ3DDL.DataTextField = "QUESTION_AR";
            SecQ3DDL.DataValueField = "QUES_ID";
            SecQ3DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ3DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);

            //Security Q4
            SecQ4DDL.Items.Clear();
            SecQ2_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SecQ4DDL.DataTextField = "QUESTION";
            else
                SecQ4DDL.DataTextField = "QUESTION_AR";
            SecQ4DDL.DataValueField = "QUES_ID";
            SecQ4DDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Selectquestion", LangType)); SecQ4DDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);            
        }
        public void Validation_Messages(string LangType)
        {
            CIDTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Civilidrequired", LangType);
            CIDTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidcivilid", LangType);

            MobileTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Mobilenorequired", LangType);
            MobileTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidmobileno", LangType);

            OTPTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_OTPRequired", LangType);

            FNameTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Firstnamerequired", LangType);
            FNameTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidfirstname", LangType);

            MNameTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidmiddilename", LangType);

            LNameTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Lastnamerequired", LangType);
            LNameTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidlastname", LangType);
                        
            SalaryDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Salaryrequired", LangType);

            SponsorTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Sponsornamerequired", LangType);
            SponsorTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidsponsorname", LangType);

            CountryDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Nationalityrequired", LangType);            

            DOBTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Dateofbirthrequired", LangType);
            DOBTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invaliddateofbirth", LangType);

            CIDExpTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Civilidexpiryrequired", LangType);
            CIDExpTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidcivilidexpiry", LangType);

            EmailTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Invalidemailid", LangType);

            AreaTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Areanamerequired", LangType);
            BlockTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Blocknorequired", LangType);
            StreetTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Streetrequired", LangType);
            BuildingTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Buildingrequired", LangType);
            FloorTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Floorrequired", LangType);
            FlatTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Flatnorequired", LangType);

            PWDTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordrequired", LangType);
            PWDTxt_RegExp.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordvalidation", LangType);
            PWDTxt_PasswordStrength.TextStrengthDescriptions = CommCls.Messages_Eng_Arabic("REQ_Passwordstrength", LangType);

            CPWDTxt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordconfirmrequired", LangType);
            CPWDTxt_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Passwordconfirmnotmatching", LangType);

            SecQ1DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ1DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ1Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);

            SecQ2DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ2DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ2Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);
            SecQ2DDL_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestion1and2shouldnotbesame", LangType);

            SecQ3DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ3DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ3Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);

            SecQ4DDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SecQ4DDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Selectquestion", LangType);
            SecQ4Txt_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityanswerrequired", LangType);
            SecQ4DDL_CompV.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestion3and4shouldnotbesame", LangType);

            FUCID_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Frontcivilidphotorequired", LangType);
            FUCID2_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Backcivildiphotorequired", LangType);

            ConfirmCHK_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Termsandconditionsrequired", LangType);
        }

        public void DynamicLang_Values(string OTPBtnValue)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            if (OTPBtnValue.ToString() == "Send OTP")
                OTPSendBtn.Text = rm.GetString("SendOTP", ci);
            else if (OTPBtnValue.ToString() == "Resend OTP")
                OTPSendBtn.Text = rm.GetString("ResendOTP", ci);
        }

        protected async void CIDTxt_TextChanged(object sender, EventArgs e)
        {
            string Result = "";
            Result = await RestCls.ValidateCXID(CIDTxt.Text.Trim());
            if (Result.ToString() == "1")
            {
                CIDTxt.Text = "";
                NextBtn0.Attributes.Add("disabled", "true");
                CIDErrorlbl.Text = CommCls.Messages_Eng_Arabic("MSG_Useralreadyregistered", Session["Lang"].ToString());
            }
            else
            {
                CIDErrorlbl.Text = "";
            }
        }

        public static ConnectionInfo getSftpConnection(string host, string username, int port, string publicKeyPath)
        {
            return new ConnectionInfo(host, port, username, privateKeyObject(username, publicKeyPath));
        }

        private static AuthenticationMethod[] privateKeyObject(string username, string publicKeyPath)
        {
            PrivateKeyFile privateKeyFile = new PrivateKeyFile(publicKeyPath);
            PrivateKeyAuthenticationMethod privateKeyAuthenticationMethod = new PrivateKeyAuthenticationMethod(username, privateKeyFile);
            return new AuthenticationMethod[] { privateKeyAuthenticationMethod };
        }
    }
}