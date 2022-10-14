using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class index1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["Admin"]==null)
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
        }

        protected void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session["Admin"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Btn_ChangePwd_Click(object sender, EventArgs e)
        {

        }
    }
}