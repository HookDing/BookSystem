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
    public partial class SelectPage1 : System.Web.UI.Page
    {
        private List<Mod_BSCategory> bsList;
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
                List<Mod_BLCategory> list = new Bll_BLCategory().GetAllModel();
                bsList = new Bll_BSCategory().GetAllModel();
                //加载左侧类别
                repLeft.DataSource = list;
                repLeft.DataBind();
                //加载销售排行榜
                Rep_Top_Sale.DataSource = new Bll_Books().GetHotBooks().Take(5).ToList();
                Rep_Top_Sale.DataBind();
                BindTable(1);

            }
        }
        protected void BindTable(int index)
        {
            string Search = Request.QueryString["Search"].ToString();
            //RepTable绑定数据
            Select_Book info = new Select_Book();
            info.BookTitle = Server.UrlDecode(Search);
            info.PageIndex = index;
            info.PageSize = 4;
            Bll_Books Bll = new Bll_Books();
            rep_Table.DataSource = Bll.GetModelListByPage(info);
            rep_Table.DataBind();

            //计算总页数
            int pageCount = (info.DataCount + info.PageSize - 1) / info.PageSize;
            //当前页
            Lab_NowPage.Text = index.ToString();
            //总页数
            Lab_AllPage.Text = pageCount.ToString();
            ViewState["Index"] = index;
        }
        //ItemDataBound生成每项时触发的事件
        protected void repLeft_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("repInter") as Repeater;
                int blID = (e.Item.DataItem as Mod_BLCategory).BLID;
                rep.DataSource = bsList.Where(n => n.BLID == blID);
                rep.DataBind();
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_FirstPage_Click(object sender, EventArgs e)
        {
            BindTable(1);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_UpPage_Click(object sender, EventArgs e)
        {
            int index = int.Parse(ViewState["Index"].ToString());
            BindTable(index == 1 ? index : index - 1);
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
            BindTable(index == allPages ? allPages : index + 1);
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_LastPage_Click(object sender, EventArgs e)
        {
            int allPages = int.Parse(Lab_AllPage.Text.ToString());
            BindTable(allPages);
        }

        protected void rep_Table_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buy")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Dictionary<int, int> flow = new Dictionary<int, int>();
                if (Session["flow"] != null)
                {
                    flow = Session["flow"] as Dictionary<int, int>;
                }
                if (flow.ContainsKey(id))
                {
                    flow[id] += 1;
                }
                else
                {
                    flow.Add(id, 1);
                }
                Session["flow"] = flow;
                //判断库存
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                List<Mod_Books> list = new Bll_Books().GetBooksByIDS(dic);
                foreach (var books in list)
                {
                    foreach (var bookid in dic.Keys)
                    {
                        if (bookid == books.BookID && dic[bookid] > books.BookDeport)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('库存就这么多了！')", true);
                            if (dic[bookid] > 0)
                            {
                                dic[bookid] -= 1;
                                //购买数量为0时删除本行
                                if (dic[bookid] <= 0)
                                {
                                    dic.Remove(bookid);
                                    //书本数量为0时删除Session
                                    if (dic.Count == 0)
                                    {
                                        Session["flow"] = null;
                                    }
                                }
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}