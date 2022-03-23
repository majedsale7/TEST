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
    public partial class DocumentsUploads : System.Web.UI.Page
    {
        CommonClass CommCls = new CommonClass();
        UpdateREST UpRestCls = new UpdateREST();
        RESTClass RestCls = new RESTClass();
        UpdateREST URest = new UpdateREST();
        ResourceManager rm;
        CultureInfo ci;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["DocsUpload_S"].ToString().ToLower() != "yes")
                    Response.Redirect("Dashboard");

                this.LoadDropDowns(Session["Lang"].ToString());
                this.LoadLanguage();

            }
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["Lang"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["Lang"].ToString());
            rm = new ResourceManager("KBE.App_GlobalResources.Lang", Assembly.GetExecutingAssembly());
            ci = CultureInfo.CreateSpecificCulture(Session["Lang"].ToString());
            UploadSupDocHeadlbl.InnerText = rm.GetString("Uploadsupportingdocs", ci);
            SuppDocTypelbl.InnerText = rm.GetString("Supportingdoctype", ci);
            ChooseSuppDoclbl.InnerText = rm.GetString("Choosesupportingdoc", ci);
            UploadBtn.Text = rm.GetString("Uploaddocument", ci);

            this.Validation_Messages(Session["Lang"].ToString());
        }
        public void LoadDropDowns(string LangType)
        {
            SuppDocDDL.Items.Clear();
            SuppDocList_ODS.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                SuppDocDDL.DataTextField = "DESC_E";
            else
                SuppDocDDL.DataTextField = "DESC_A";
            SuppDocDDL.DataValueField = "LOOKUP_ID";
            SuppDocDDL.Items.Insert(0, CommCls.Messages_Eng_Arabic("Select", LangType)); SuppDocDDL.SelectedItem.Text = CommCls.Messages_Eng_Arabic("Select", LangType);
        }
        public void Validation_Messages(string LangType)
        {
            SuppDocDDL_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Securityquestionrequired", LangType);
            SuppDocDDL_ReqF.InitialValue = CommCls.Messages_Eng_Arabic("Select", LangType);

            FUSuppDoc_ReqF.ErrorMessage = CommCls.Messages_Eng_Arabic("REQ_Suppdocrequired", LangType);

        }
        protected async void UploadBtn_Click(object sender, EventArgs e)
        {
            string DocExtn = System.IO.Path.GetExtension(FUSuppDoc.PostedFile.FileName);
            string DocCategory = SuppDocDDL.SelectedItem.Text;
            string DocFName = "Doc_" + DocCategory + "_" + Session["LoginID_CX"].ToString() + DocExtn;
            int lastSlash1 = DocFName.LastIndexOf("\\");
            string trailingPath1 = DocFName.Substring(lastSlash1 + 1);
            string fullPath1 = Server.MapPath(" ") + "\\CIDTemp\\" + trailingPath1;

            if (DocExtn.ToString() == ".pdf" || DocExtn.ToString() == ".doc" || DocExtn.ToString() == ".docx")
            {
                FUSuppDoc.SaveAs(fullPath1);               
            }
            else
            {
                MemoryStream stream1 = new MemoryStream(FUSuppDoc.FileBytes);
                this.GenerateThumbnails(0.5, stream1, fullPath1);
            }
            //FTP Server URL. 
           // string ftp = "ftp://168.187.116.75/";
            byte[] fileBytes1 = File.ReadAllBytes(fullPath1);

            string CustIDStr = "", InqrTypeStr = "", InqrSubjectStr = "", InqrtTextStr = "";

            CustIDStr = Session["LoginID_CX"].ToString();
            InqrTypeStr = "APP_DOC_CATG";
            InqrSubjectStr = "Document Upload";
            InqrtTextStr = "Dear Sir, The requested document " + DocCategory + " is uploaded";
            string Result = await URest.UserEnquiryUpdate(CustIDStr, InqrTypeStr, InqrSubjectStr, InqrtTextStr);            
                       
            if (Result == "")
            {
                MessageBox_Error(Result);
            }
            else
            {               
                MessageBox_OK(Result);

                try
                {
                    using (SftpClient sftpClient = new SftpClient(getSftpConnection("168.187.116.75", "user", 22, Server.MapPath(" ") + "\\SFTPKey\\id_rsa")))
                    {
                        Console.WriteLine("Connect to server");
                        sftpClient.Connect();
                        Console.WriteLine("Creating FileStream object to stream a file");
                        using (FileStream fs = new FileStream(fullPath1, FileMode.Open))
                        {                            
                            sftpClient.BufferSize = 2048;
                            sftpClient.UploadFile(fs, Path.GetFileName(fullPath1));
                        }
                        sftpClient.Dispose();
                    }

                }
                catch (WebException ex)
                {
                    throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
                }

                SuppDocDDL.SelectedIndex = 0;
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