using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.fss.plugin;
using System.Data;
using KBE.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace KBE
{
    public partial class Payment : System.Web.UI.Page
    {
        private SqlConnection cn;
        private SqlCommand cmd1, cmd2;
        CommonClass CommonBL = new CommonClass();
        string CS = ConfigurationManager.ConnectionStrings["KBECS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iPayPipe pipe = new iPayPipe();

                string total;
                total = Request.QueryString["PaidAmt"];

                pipe.setTrackId(Session["TrackIDSession"].ToString());
                pipe.setAlias("kbe");
                pipe.setResourcePath(@"C:\\HostingSpaces\\onlinekbe\\onlinekbe.onlinekbe.com\\wwwroot\\Resource\\");
                if (Session["Lang"].ToString() == "ar-KW")
                    pipe.setLanguage("AR");
                else
                    pipe.setLanguage("EN");
                pipe.setAction("1");
                pipe.setAmt(total.ToString());
                pipe.setCurrency("414");
                pipe.setUdf1(Session["LoginID_CX"].ToString());
                pipe.setUdf2(Convert.ToDouble(total).ToString("0.000"));
                pipe.setUdf3(Session["Lang"].ToString());
                pipe.setUdf4(Session["PayRemarksSession"].ToString());
                pipe.setUdf5(Session["CxName_S"].ToString());
                pipe.setKeystorePath(@"C:\\HostingSpaces\\onlinekbe\\onlinekbe.onlinekbe.com\\wwwroot\\Resource\\");
                pipe.setResponseURL("https://onlinekbe.com/PaymentResponse.aspx");
                pipe.setErrorURL("https://onlinekbe.com/PaymentError.aspx");
                pipe.setTransId(Session["TrackIDSession"].ToString());
                pipe.setType("D");

                int TransVal = -1;
                string varPaymentID, varPaymentPage, varErrorMsg, varRawResponse;


                try
                {
                    TransVal = pipe.performPaymentInitializationHTTP();
                }
                catch (Exception dgd) { }

                varRawResponse = pipe.getRawResponse();
                varPaymentID = pipe.getPaymentId();
                varPaymentPage = pipe.getPaymentPage();
                varErrorMsg = pipe.getError_text();

                SqlTransaction sqltrans = null;
                cn = new SqlConnection(CS);
                cmd1 = new SqlCommand("TransactionsInit_Master_I", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@LoginID_S", SqlDbType.VarChar).Value = Session["LoginID_CX"].ToString();
                cmd1.Parameters.Add("@TrackID_S", SqlDbType.VarChar).Value = Session["TrackIDSession"].ToString();
                cmd1.Parameters.Add("@TransactionDate_S", SqlDbType.Date).Value = CommonBL.TimeZoneDateTime().ToString("yyyy-MM-dd");
                cmd1.Parameters.Add("@TransactionTime_S", SqlDbType.VarChar).Value = CommonBL.TimeZoneDateTime().ToString("hh:mm:ss tt");
                cmd1.Parameters.Add("@TransactionDateTime_S", SqlDbType.DateTime).Value = CommonBL.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
                cmd1.Parameters.Add("@PayRemarks_S", SqlDbType.NVarChar).Value = "";
                cmd1.Parameters.Add("@PaidAmount_S", SqlDbType.Decimal).Value = total;
                cmd1.Parameters.Add("@ResponseResult_S", SqlDbType.VarChar).Value = "Initialized";
                cmd1.Parameters.Add("@ResponseAt_S", SqlDbType.DateTime).Value = CommonBL.TimeZoneDateTime().ToString("yyyy-MM-dd hh:mm:ss tt");
                cn.Open();
                sqltrans = cn.BeginTransaction();
                cmd1.Transaction = sqltrans;
                int result1 = int.Parse(cmd1.ExecuteNonQuery().ToString());
                if (result1 == 1)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
                cn.Close();
                cn.Dispose();                

                if (TransVal == 0)
                {
                    Response.Redirect(pipe.getWebAddress());
                }
                else
                {
                    Response.Redirect(pipe.getErrorURL());
                }

            }
        }
    }
}