using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class OrderPage : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BindGrid(1);
            }
        }
        private void BindGrid(int index)
        {
            Select_Order info = new Select_Order();
            if (ViewState["select"] != null)
            {
                info = (Select_Order)ViewState["select"];
            }
            info.PageIndex = index;
            info.PageSize = 10;
            Bll_Orders Bll = new Bll_Orders();
            GV_Orders.DataSource = Bll.GetOrdersByPage(info);
            GV_Orders.Attributes.Add("style ", "table-layout:fixed ");
            GV_Orders.DataBind();

            //计算总页数
            int pageCount = (info.DataCount + info.PageSize - 1) / info.PageSize;
            //当前页
            Lab_NowPage.Text = index.ToString();
            //总页数
            Lab_AllPage.Text = pageCount.ToString();
            ViewState["Index"] = index;
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Select_Order info = new Select_Order();
            info.OrderID = Convert.ToInt32(Txt_OrderID.Text == "" ? "0" : Txt_OrderID.Text);
            info.UserName = Txt_UserName.Text;
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo { ShortDatePattern = "yyyy/MM/dd" };
            info.OrderDateStart = Convert.ToDateTime(Calendar1.Text == "" ? new DateTime().ToString() : Calendar1.Text, dtFormat);
            info.OrderDateEnd = Convert.ToDateTime(Calendar2.Text == "" ? new DateTime().ToString() : Calendar2.Text, dtFormat);
            info.OrderState = Convert.ToInt32(Ddl_OrderState.SelectedValue);
            ViewState["select"] = info;
            BindGrid(1);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_FirstPage_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_UpPage_Click(object sender, EventArgs e)
        {
            int index = int.Parse(ViewState["Index"].ToString());
            BindGrid(index == 1 ? index : index - 1);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_DownPag_Click(object sender, EventArgs e)
        {
            int index = int.Parse(ViewState["Index"].ToString());
            int allPages = int.Parse(Lab_AllPage.Text.ToString());
            BindGrid(index == allPages ? allPages : index + 1);
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_LastPage_Click(object sender, EventArgs e)
        {
            int allPages = int.Parse(Lab_AllPage.Text.ToString());
            BindGrid(allPages);
        }
        /// <summary>
        /// 替换GridView数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_Orders_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "1")
                {
                    e.Row.Cells[4].Text = "待确定";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "确定";
                }
                if (e.Row.Cells[4].Text == "2")
                {
                    e.Row.Cells[4].Text = "已确定";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "发货";
                }
                if (e.Row.Cells[4].Text == "3")
                {
                    e.Row.Cells[4].Text = "待发货";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "完成";
                }
                if (e.Row.Cells[4].Text == "4")
                {
                    e.Row.Cells[4].Text = "完成";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "";
                }
            }
        }
        /// <summary>
        /// 操作集：编辑 & 查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_Orders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                var b = new Bll_Orders().GetModel(int.Parse(e.CommandArgument.ToString()));
                b.OrderState += 1;
                if (new Bll_Orders().Update(b))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('操作成功！')", true);
                    BindGrid(1);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('操作失败！')", true);
                }
            }
            if (e.CommandName=="GoDetail")
            {
                Response.Redirect("OrderDetailPage.aspx?OrderID="+e.CommandArgument.ToString());
            }

        }
    }
}