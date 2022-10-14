using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Pages
{
    public partial class OrderPage1 : System.Web.UI.Page
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
            BindGrid(1);
        }
        private void BindGrid(int index)
        {
            Select_Order info = new Select_Order();
            if (ViewState["select"] != null)
            {
                info = (Select_Order)ViewState["select"];
            }
            info.PageIndex = index;
            info.PageSize = 5;
            Bll_Orders Bll = new Bll_Orders();
            GV_Orders.DataSource = Bll.GetBooksByPage(info);
            GV_Orders.DataBind();

            //计算总页数
            int pageCount = (info.DataCount + info.PageSize - 1) / info.PageSize;
            //当前页
            Lab_NowPage.Text = index.ToString();
            //总页数
            Lab_AllPage.Text = pageCount.ToString();
            ViewState["Index"] = index;
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
                if (e.Row.Cells[4].Text == "1"){e.Row.Cells[4].Text = "待确定";}
                if (e.Row.Cells[4].Text == "2"){e.Row.Cells[4].Text = "已确定";}
                if (e.Row.Cells[4].Text == "3"){e.Row.Cells[4].Text = "待发货";}
                if (e.Row.Cells[4].Text == "4"){e.Row.Cells[4].Text = "已完成";}
            }
        }
        /// <summary>
        /// 操作集：评价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_Orders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                Response.Redirect("AppraisePage.aspx?ODID=" + e.CommandArgument);
            }

        }
    }
}