using BLL;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["User"] != null)
            {
                Response.Write("<script>window.location.href='Index.aspx';</script>");
            }
        }
        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            //非空验证
            if (string.IsNullOrEmpty(Txt_UserName.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入用户名！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Password.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入密码！')", true);
                return;
            }
            //赋值
            Mod_Users User = new Mod_Users();
            User.UserName = Txt_UserName.Text;
            User.UserPwd = MD5Service.GetMD5CodeToString(Txt_Password.Text);
            //查询&反馈
            if (new Bll_Users().Login(User))
            {
                Session["User"] = new Bll_Users().GetModelList($" UserName='{Txt_UserName.Text}'")[0];
                Response.Redirect("index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('用户名或密码错误！')", true);
                return;
            }
        }
    }
}