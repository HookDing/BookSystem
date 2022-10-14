using Books.BLL;
using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook
{
    public partial class BalancePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            if (Session["flow"] != null)
            {
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                List<Mod_Books> list = new Bll_Books().GetBooksByIDS(dic);
                GridView1.DataSource = list;
                GridView1.DataBind();
                float money = 0;
                foreach (Mod_Books item in list)
                {
                    int count = dic[(int)item.BookID];
                    money += count * (float)item.BookMoney;
                }
                labSum.Text = string.Format("{0:C}", money);
            }
            else
            {
                Response.Write("<script>alert('您还没有选择商品，点击确认前去挑选');location.href='Index.aspx';</script>");
            }
        }

        protected void btnDefault_Click(object sender, EventArgs e)
        {
            //获取当前用户的默认地址
            Mod_Users user = Session["user"] as Mod_Users;
            List<Mod_AddressManager> list = new Bll_AddressManager().GetDefaultAddress((int)user.UserID);
            if (list.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('当前用户没有默认地址')", true);
                btnDefault.CommandArgument = "";
                return;
            }
            Mod_AddressManager info = list[0];
            txtName.Text = info.AMUser;
            txtTel.Text = info.AMTel;
            txtAdd.Text = info.AMAddress;
            btnDefault.CommandArgument = info.AMID.ToString();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            //添加新地址
            Mod_Users info = Session["user"] as Mod_Users;
            if (string.IsNullOrEmpty(txtName.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入收货姓名')", true); return; }
            if (string.IsNullOrEmpty(txtAdd.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入联系电话')", true); return; }
            if (string.IsNullOrEmpty(txtTel.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入收货地址')", true); return; }
            Mod_AddressManager add = new Mod_AddressManager();
            add.AMUser = txtName.Text.Trim();
            add.AMTel = txtTel.Text.Trim();
            add.AMAddress = txtAdd.Text.Trim();
            add.UserID = info.UserID;
            add.AMMark = false;
            int id = new Bll_AddressManager().Insert(add);
            //将新增的地址ID存储起来，便于提交订单时使用
            btnDefault.CommandArgument = id.ToString();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
            {
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                //根据书籍ID获取书籍数量
                int num = dic[int.Parse(GridView1.DataKeys[e.Row.RowIndex].Value.ToString())];
                e.Row.Cells[3].Text = num.ToString();
                e.Row.Cells[4].Text = string.Format("{0:C}", num * float.Parse(e.Row.Cells[2].Text));
                e.Row.Cells[1].Text = string.Format("{0:C}", e.Row.Cells[1].Text);
                e.Row.Cells[2].Text = string.Format("{0:C}", e.Row.Cells[2].Text);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnDefault.CommandArgument))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请填写好收货地址')", true);
                return;
            }
            Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
            if (dic.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请选择要购买的商品')", true);
                return;
            }
            Mod_Users user = Session["User"] as Mod_Users;
            Mod_Orders info = new Mod_Orders();
            info.UserID = user.UserID;
            info.AMID = int.Parse(btnDefault.CommandArgument);
            info.OrderState = 1;
            info.OrderDate = DateTime.Now;
            string num = new Bll_Orders().CreateOrder(info, dic);
            Response.Redirect("DisplayPage.aspx?num=" + num);
            Response.End();
        }
    }
}