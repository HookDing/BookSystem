using Books.BLL;
using Books.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Pages
{
    public partial class BooksPage1 : System.Web.UI.Page
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
        public int BSID = 0;
        public int BLID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定左侧类别
                bsList = new Bll_BSCategory().GetAllModel();
                List<Mod_BLCategory> list = new Bll_BLCategory().GetAllModel();
                repLeft.DataSource = list;
                repLeft.DataBind();

                Rep_Top_Sale.DataSource = new Bll_Books().GetHotBooks().Take(5).ToList();
                Rep_Top_Sale.DataBind();
                //书籍信息
                int BookID = int.Parse(Request.QueryString["BookID"].ToString());
                Rep_Book.DataSource = new Bll_Books().GetModelList($" BookID={BookID}").Take(1).ToList();
                Rep_Book.DataBind();

                //设置传值
                //根据书籍查小类别ID
                BSID = (int)new Bll_Books().GetModel(BookID).BSID;
                //根据小类别查询大类别
                BLID = new Bll_BLCategory().GetModel((int)new Bll_BSCategory().GetModel(BSID).BLID).BLID;


                //层级菜单
                if (BLID != 0)
                {
                    Lbl_BLName.Text = new Bll_BLCategory().GetModel((int)BLID).BLName;
                }
                if (BSID != 0)
                {
                    Lbl_BSName.Text = new Bll_BSCategory().GetModel(BSID).BSName;
                    Lbl_BLName.Text = new Bll_BLCategory().GetModel((int)new Bll_BSCategory().GetModel(BSID).BLID).BLName;
                }

                //评价
                string sql = $@"select UserNick,BADate,BAPoint,BADesc,BookID from Orders,OrderDetail,BookAppraise,Users 
where BookAppraise.ODID=OrderDetail.ODID and Users.UserID=Orders.UserID and Orders.OrderID=OrderDetail.OrderID and OrderDetail.BookID={BookID}";
                Rep_BookAppraise.DataSource = new Bll_BookAppraise().GetModelListBySqlStr(sql);
                Rep_BookAppraise.DataBind();

            }
        }
        //ItemDataBound生成每项时触发的事件
        protected void repLeft_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //通过控件ID查找内层的Repeater控件
                Repeater rep = e.Item.FindControl("repInter") as Repeater;
                //获取当前绑定项对应的绑定数据
                int blID = (e.Item.DataItem as Mod_BLCategory).BLID;
                //根据大类别的ID查询出对应的小类别，并绑定到内层Repeater中
                //在页面加载时查询所有的小类别，并定义为全局变量
                //每次绑定内层Repeater时，不需要每个大类别都查询一次数据库，而是从内存中检索数据
                rep.DataSource = bsList.Where(n => n.BLID == blID);
                rep.DataBind();
            }
        }

        protected void Rep_Book_ItemCommand(object source, RepeaterCommandEventArgs e)
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