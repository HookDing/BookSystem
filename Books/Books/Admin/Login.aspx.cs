using BLL;
using Books.BLL;
using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Lbtn_Login_Click(object sender, EventArgs e)
        {

            //非空验证
            if (string.IsNullOrEmpty(this.Txt_Name.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入用户名！')", true);
                return;
            }
            if (string.IsNullOrEmpty(this.Txt_Pwd.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入密码！')", true);
                return;
            }
            if (string.IsNullOrEmpty(this.Txt_Code.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入验证码！')", true);
                return;
            }
            //接收输入值
            string username = this.Txt_Name.Text;
            string pwd = MD5Service.GetMD5CodeToString(this.Txt_Pwd.Text);
            string valicode = this.Txt_Code.Text;
            //验证验证码
            if (valicode != Session["valicode"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('验证码错误！')", true);
                return;
            }
            //查询用户
            Mod_Admins m = new Mod_Admins
            {
                AdminUser = username,
                AdminPwd = pwd,
            };
            if (new Bll_Admins().Login(m))
            {
                Session["Admin"] = m;
                Response.Redirect("index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('用户名或密码错误！')", true);
            }

        }
    }
}