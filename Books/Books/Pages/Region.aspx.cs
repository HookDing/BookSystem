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
    public partial class Region1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_DoRegist_Click(object sender, ImageClickEventArgs e)
        {
            //表单验证
            if (string.IsNullOrEmpty(Txt_UserName.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入用户名！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_UserNick.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入昵称！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Email.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入邮箱！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Password.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入密码！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_repPassword.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请再次输入密码！')", true);
                return;
            }
            if (Txt_Password.Text != Txt_Password.Text)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('两次输入的密码不一致！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_QQ.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入QQ！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Tel.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入电话号码！')", true);
                return;
            }
            //接收数据
            Mod_Users User = new Mod_Users();
            User.UserName=Txt_UserName.Text;
            User.UserNick = Txt_UserNick.Text;
            User.UserEmail=Txt_Email.Text;
            User.UserPwd= MD5Service.GetMD5CodeToString( Txt_Password.Text);
            Bll_Users BLL=new Bll_Users ();
            if (BLL.Add(User))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('注册失败！')", true);
            }
        }
    }
}