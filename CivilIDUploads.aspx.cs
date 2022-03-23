using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Net;
using System.Drawing.Imaging;
using System.Drawing.Text;
using KBE.Models;
using KBE.RESTFull;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace KBE
{
    public partial class CivilIDUploads : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST URest = new UpdateREST();
        UpdateREST UpRestCls = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        ResourceManager rm;
        CultureInfo ci;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CID_Expiry_S"].ToString().ToLower() != "yes")
                    Response.Redirect("Dashboard");

                CIDMsglbl.Text = Session["PopupMsg_S"].ToString();
                this.LoadLanguage();
            }
        }
        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());

            FrontCIDUploadlbl.InnerText = rm.GetString("Frontcivilidupload", ci);
            BackCIDUplaodlbl.InnerText = rm.GetString("Backcivilidupload", ci);
            UploadCIDHeadlbl.InnerText = rm.GetString("UploadCID", ci);

            UploadBtn.Text = rm.GetString("UploadCID", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }

        protected async void UploadBtn_Click(object sender, EventArgs e)
        {
            string CIDExtn1 = System.IO.Path.GetExtension(FUCID1.PostedFile.FileName);
            string CIDFName1 = Session["LoginID_CX"].ToString() + "_Front" + CIDExtn1;
            int lastSlash1 = CIDFName1.LastIndexOf("\\");
            string trailingPath1 = CIDFName1.Substring(lastSlash1 + 1);
            string fullPath1 = Server.MapPath(" ") + "\\CIDTemp\\" + trailingPath1;

            string CIDExtn2 = System.IO.Path.GetExtension(FUCID2.PostedFile.FileName);
            string CIDFName2 = Session["LoginID_CX"].ToString() + "_Back" + CIDExtn2;
            int lastSlash2 = CIDFName2.LastIndexOf("\\");
            string trailingPath2 = CIDFName2.Substring(lastSlash2 + 1);
            string fullPath2 = Server.MapPath(" ") + "\\CIDTemp\\" + trailingPath2;

            MemoryStream stream1 = new MemoryStream(FUCID1.FileBytes);
            this.GenerateThumbnails(0.5, stream1, fullPath1);

            MemoryStream stream2 = new MemoryStream(FUCID2.FileBytes);
            this.GenerateThumbnails(0.5, stream2, fullPath2);

            //FTP Server URL. 
            string ftp = "ftp://168.187.116.75/";
            byte[] fileBytes1 = File.ReadAllBytes(fullPath1);
            byte[] fileBytes2 = File.ReadAllBytes(fullPath2);


            string CustIDStr = "", InqrTypeStr = "", InqrSubjectStr = "", InqrtTextStr = "";

            CustIDStr = Session["LoginID_CX"].ToString();
            InqrTypeStr = "CIVIL_ID_UPLOAD";
            InqrSubjectStr = "CIVIL ID UPLOAD";
            InqrtTextStr = "Civil Id is uploaded Successfully";
            string Result = await URest.UserEnquiryUpdate(CustIDStr, InqrTypeStr, InqrSubjectStr, InqrtTextStr);
           

            if (Result == "")
            {
                MessageBox_Error(Result);
            }
            else
            {
                MessageBox_OK(CommCls.Messages_Eng_Arabic("MSG_Yourciviliduploadedsuccessfully", Session["Lang"].ToString()));

                try
                {                 
                    using (SftpClient sftpClient1 = new SftpClient(getSftpConnection("168.187.116.75", "user", 22, Server.MapPath(" ") + "\\SFTPKey\\id_rsa")))
                    {
                        Console.WriteLine("Connect to server");
                        sftpClient1.Connect();
                        Console.WriteLine("Creating FileStream object to stream a file");
                        using (FileStream fs1 = new FileStream(fullPath1, FileMode.Open))
                        {                            
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

            }



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

        public void Validation_Messages(string LangType)
        {
            FUCID1_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Frontcivilidphotorequired", LangType);
            FUCID2_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Backcivildiphotorequired", LangType);

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