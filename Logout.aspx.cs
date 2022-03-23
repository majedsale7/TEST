using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KBE
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Cur_Lang = Session["Lang"].ToString();
            Session.RemoveAll();
            Session.Clear();
            Session["Lang"] = Cur_Lang;
            Response.Redirect("login");
        }
    }
}