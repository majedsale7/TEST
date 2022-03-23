using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.UI;
using KBE.RESTFull;
using System.Web.Configuration;
using System.Configuration;

namespace KBE
{
    public class Global : System.Web.HttpApplication
    {
        RESTClass RESTCls = new RESTClass();
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteingData(RouteTable.Routes);

            this.GetAuthenticationValues();
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        private void RouteingData(RouteCollection route)
        {

            route.MapPageRoute("", "login", "~/Index.aspx");
            route.MapPageRoute("", "Password", "~/Password.aspx");
            route.MapPageRoute("", "Forgot", "~/Password_Forgot.aspx");
            route.MapPageRoute("", "Reset", "~/Password_Reset.aspx");
            route.MapPageRoute("", "logout", "~/Logout.aspx");
            route.MapPageRoute("", "Signup", "~/Signup.aspx");
            route.MapPageRoute("", "Dashboard", "~/Dashboard.aspx");
            route.MapPageRoute("", "Beneficiary", "~/BeneficiaryNew.aspx");
            route.MapPageRoute("", "Beneficiaries", "~/BeneficiaryList.aspx");
            route.MapPageRoute("", "Beneficiarries", "~/BeneficiaryFormView.aspx");            
            route.MapPageRoute("", "Exchange", "~/Exchange_Rate.aspx");
            route.MapPageRoute("", "Transactions", "~/Mytransactions.aspx");
            route.MapPageRoute("", "Profile", "~/Myprofile.aspx");
            route.MapPageRoute("", "Sendmoney", "~/Send_Money.aspx");
            route.MapPageRoute("", "Checkout", "~/Checkout_Confirm.aspx");
            route.MapPageRoute("", "Validate", "~/SecurityQuestionsValidation.aspx");
            route.MapPageRoute("", "404", "~/PageNotFound.aspx");
            route.MapPageRoute("", "Promotions", "~/PromotionBanners.aspx");
            route.MapPageRoute("", "FAQ", "~/FAQPage.aspx");
            route.MapPageRoute("", "Contact", "~/Contact_Us.aspx");
            route.MapPageRoute("", "Branches", "~/BranchesDetails.aspx");
            route.MapPageRoute("", "Notifications", "~/NotificationDetails.aspx");
            route.MapPageRoute("", "Receipt", "~/PaymentResult.aspx");
            route.MapPageRoute("", "OTP", "~/OTPValidate.aspx");
            route.MapPageRoute("", "CIDUpload", "~/CivilIDUploads.aspx");
            route.MapPageRoute("", "Documents", "~/DocumentsUploads.aspx");
            //route.MapPageRoute("", "Receipt/{PaymentID}/{Result}/{PostDate}/{TranID}/{Auth}/{Ref}/{TrackID}/{AMT}", "~/PaymentResult.aspx");

        }
        private async void GetAuthenticationValues()
        {
            string[] AuthUInfo = new string[2];
            string AuthResult = "";
            AuthResult = await RESTCls.GetAuthenticationValues();
            AuthUInfo = AuthResult.Split('|');
            if (AuthUInfo[0].ToString() != "" && AuthUInfo[1].ToString() != "")
            {
                WebConfigurationManager.AppSettings.Set("AuthUID", AuthUInfo[0].ToString());
                WebConfigurationManager.AppSettings.Set("AuthUPWD", AuthUInfo[1].ToString());

                //Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
                //webConfigApp.AppSettings.Settings["AuthUID"].Value = AuthUInfo[0].ToString();
                //webConfigApp.AppSettings.Settings["AuthUPWD"].Value = AuthUInfo[1].ToString();
                //webConfigApp.Save();         
            }
        }
    }
}