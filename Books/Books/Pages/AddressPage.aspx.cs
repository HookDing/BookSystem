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
    public partial class AddressPage1 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void Bind()
        {
            //加载地址列表
            int userid = (Session["User"] as Mod_Users).UserID;
            Rep_AddressList.DataSource = new Bll_AddressManager().GetModelList($" UserID={userid}");
            Rep_AddressList.DataBind();
            //初始化添加输入框
            Txt_Add_AMUser.Text = "";
            Txt_Add_AMAdress.Text = "";
            Txt_Add_AMTel.Text = "";

        }
        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            //非空验证
            if (string.IsNullOrEmpty(Txt_Add_AMUser.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('收货人姓名不能为空！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Add_AMTel.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('联系电话不能为空！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Add_AMAdress.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('收货地址不能为空！')", true);
                return;
            }
            //初始化模型 && 赋值
            Mod_AddressManager info = new Mod_AddressManager();
            info.UserID = (Session["User"] as Mod_Users).UserID;
            info.AMUser = Txt_Add_AMUser.Text;
            info.AMAddress = Txt_Add_AMAdress.Text;
            info.AMTel = Txt_Add_AMTel.Text;
            info.AMMark = true;

            Bll_AddressManager BLL = new Bll_AddressManager();
            int UserID = ((Mod_Users)Session["User"]).UserID;

            //添加并设置为默认地址
            if (BLL.SetDefalut(UserID) && BLL.Add(info))
            {
                //成功
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('添加成功！')", true);
                Bind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('添加失败！')", true);
            }

        }

        protected void Rep_AddressList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //初始化模型 && 赋值
            Mod_AddressManager info = new Mod_AddressManager();
            info.UserID = ((Mod_Users)Session["User"]).UserID;
            info.AMID = int.Parse(e.CommandArgument.ToString());
            info.AMUser = (e.Item.FindControl("Txt_AMUser") as TextBox).Text.Trim();
            info.AMAddress = (e.Item.FindControl("Txt_AMTel") as TextBox).Text.Trim();
            info.AMTel = (e.Item.FindControl("Txt_AMAdress") as TextBox).Text.Trim();
            info.AMMark = false;
            //修改
            if (e.CommandName == "Save")
            {
                if (new Bll_AddressManager().Update(info))
                {
                    //成功
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('更改成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('更改失败！')", true);
                }
            }
            //设置默认地址
            if (e.CommandName == "SetDefault")
            {
                info.AMMark = true;
                Bll_AddressManager BLL = new Bll_AddressManager();
                int UserID = ((Mod_Users)Session["User"]).UserID;
                if (BLL.SetDefalut(UserID) && BLL.Update(info))
                {
                    //成功
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('更改成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('更改失败！')", true);
                }
            }
            //删除
            if (e.CommandName == "Delete")
            {
                if (new Bll_AddressManager().GetModel(info.AMID).AMMark == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('不能删除默认地址！')", true);
                    return;
                }
                if (new Bll_AddressManager().Delete(info.AMID))
                {
                    //成功
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除失败！')", true);
                }
            }
            Bind();
        }
    }
}