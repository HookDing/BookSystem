using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class OrderDetailPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["Admin"] == null)
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int a = int.Parse(Request.QueryString["OrderID"].ToString());
            Bll_OrderDetail Bll = new Bll_OrderDetail();
            View_OrderDetail m = Bll.GetView_OrderDetails(a);
            Lbl_AMAddress.Text = m.AMAddress;
            Lbl_AMTel.Text = m.AMTel;
            Lbl_AMUser.Text = m.AMUser;
            Lbl_Money.Text = m.OrderMoney.ToString();
            Lbl_OrderDate.Text = m.OrderDate.ToString();
            Lbl_OrderNum.Text = m.OrderNum.ToString();
            switch (m.OrderState)
            {
                case 1: Lbl_State.Text = "待确定"; break;
                case 2: Lbl_State.Text = "已确定"; break;
                case 3: Lbl_State.Text = "已发货"; break;
                case 4: Lbl_State.Text = "完成"; break;
            }
            Lbl_UserName.Text = m.UserName;

            GV_Books.DataSource = Bll.GetView_ODBooks(a);
            DataBind();
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }
    }
}