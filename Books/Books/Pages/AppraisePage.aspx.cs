using Books.BLL;
using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Pages
{
    public partial class AppraisePage1 : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["User"] == null)
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            int ODID = int.Parse(Request.QueryString["ODID"].ToString());
            Mod_BookAppraise info = new Mod_BookAppraise();
            info.ODID = ODID;
            info.BAPoint = int.Parse(Ddl_Point.SelectedValue);
            info.BADesc = Txt_Appraise.Text;
            info.BADate = DateTime.Now;
            if (new Bll_BookAppraise().Add(info))
            {
                //成功
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('评价成功！')", true);
                Response.Redirect("OrderPage.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('评价失败！')", true);
            }
        }

        protected void Btn_Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }
    }
}