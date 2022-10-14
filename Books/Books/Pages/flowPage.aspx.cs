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
    public partial class flowPage1 : System.Web.UI.Page
    {
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="e"></param>
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
            if (Session["flow"] != null)
            {
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                List<Mod_Books> list = new Bll_Books().GetBooksByIDS(dic);
                //加载GridView数据
                GV_Books.DataSource = list;
                GV_Books.DataBind();
                //查询价格提示
                float money = 0;
                float price = 0;
                if (list != null)
                {
                    foreach (Mod_Books item in list)
                    {
                        int count = dic[(int)item.BookID];
                        money += count * (float)item.BookMoney;
                        price += count * (float)item.BookPrice;
                    }
                }
                //加载价格提示
                Lbl_Price.Text = string.Format("{0:C}", price);
                Lbl_Money.Text = string.Format("{0:C}", money);
                Lbl_Save.Text = string.Format("{0:C}", price - money);
            }
        }

        protected void GV_Books_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
            int index = int.Parse(e.CommandArgument.ToString());
            int BookID = (int)GV_Books.DataKeys[index].Value;
            //数量+1
            if (e.CommandName == "Count_Increase")
            {
                dic[BookID] += 1;
                Label Lbl_Count = GV_Books.Rows[index].FindControl("Lbl_Count") as Label;
                Lbl_Count.Text = dic[BookID].ToString();
            }
            //数量-1
            if (e.CommandName == "Count_Reduce")
            {
                if (dic[BookID] > 0)
                {
                    dic[BookID] -= 1;
                    Label Lbl_Count = GV_Books.Rows[index].FindControl("Lbl_Count") as Label;
                    Lbl_Count.Text = dic[BookID].ToString();
                    //购买数量为0时删除本行
                    if (dic[BookID] <= 0)
                    {
                        dic.Remove(BookID);
                        //书本数量为0时删除Session
                        if (dic.Count == 0)
                        {
                            Session["flow"] = null;
                            Response.Redirect("flowPage.aspx");
                        }
                    }
                }
            }
            //移除书籍
            if (e.CommandName == "Count_Del")
            {
                dic.Remove(BookID);
            }
            Session["flow"] = dic;
            Bind();
        }
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_ClearCar_Click(object sender, EventArgs e)
        {
            Session["flow"] = null;
            Response.Redirect("flowPage.aspx");
        }

        protected void GV_Books_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
            {
                //取得价格和售价
                float money = float.Parse(e.Row.Cells[1].Text);
                float price = float.Parse(e.Row.Cells[2].Text);
                //在价格前添加￥
                e.Row.Cells[1].Text = money.ToString("C");
                e.Row.Cells[2].Text = price.ToString("C");
                //获取购买数量
                int id = (int)GV_Books.DataKeys[e.Row.RowIndex].Value;
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                int count = dic[id];
                //获取前台控件
                Label Lbl_Count = e.Row.FindControl("Lbl_Count") as Label;
                Label Lbl_Subtotal = e.Row.FindControl("Lbl_Subtotal") as Label;
                //给控件赋值
                Lbl_Count.Text = count.ToString();
                Lbl_Subtotal.Text = string.Format("{0:C}", price * count);

            }
        }
    }
}