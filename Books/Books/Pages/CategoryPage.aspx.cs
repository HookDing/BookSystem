using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Pages
{
    public partial class CategoryPage1 : System.Web.UI.Page
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
        //声明公共参数：传入值
        public int BLID = 0;
        public int BSID = 0;
        //
        private List<Mod_BSCategory> bsList;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置传值
                if (Request.QueryString.Count != 0)
                {
                    //传入小类别
                    if (Request.QueryString.AllKeys[0] == "BSID")
                    {
                        BSID = int.Parse(Request.QueryString["BSID"].ToString().Trim());
                        //根据小类别查询大类别
                        BLID = new Bll_BLCategory().GetModel((int)new Bll_BSCategory().GetModel(BSID).BLID).BLID;
                    }
                    //传入大类别
                    else if (Request.QueryString.AllKeys[0] == "BLID")
                    {
                        BLID = int.Parse(Request.QueryString["BLID"].ToString().Trim());
                    }
                }
                List<Mod_BLCategory> list = new Bll_BLCategory().GetAllModel();

                bsList = new Bll_BSCategory().GetAllModel();
                //绑定左侧类别
                //List<Mod_BLCategory> list = new Bll_BLCategory().GetAllModel();
                repLeft.DataSource = list;
                repLeft.DataBind();


                bsList = new Bll_BSCategory().GetAllModel();
                Rep_Top_Sale.DataSource = new Bll_Books().GetHotBooks().Take(5).ToList();
                Rep_Top_Sale.DataBind();
                //绑定数据
                BindTable(1);
            }
        }
        /// <summary>
        /// 绑定表格数据
        /// </summary>
        /// <param name="index"></param>
        protected void BindTable(int index)
        {
            //RepTable绑定数据
            Select_Book info = new Select_Book();
            if (BLID != 0) info.BLID = BLID;
            if (BSID != 0) info.BSID = BSID;
            info.PageIndex = index;
            info.PageSize = 4;
            Bll_Books Bll = new Bll_Books();
            rep_Table.DataSource = Bll.GetModelListByPage(info);
            rep_Table.DataBind();

            //层级菜单
            //传入大类别
            if (BLID != 0)
            {
                Lbl_BLName.Text = new Bll_BLCategory().GetModel((int)BLID).BLName;
            }
            //传入小类别
            if (BSID != 0)
            {
                Lbl_BSName.Text = new Bll_BSCategory().GetModel(BSID).BSName;
                Lbl_BLName.Text = new Bll_BLCategory().GetModel((int)new Bll_BSCategory().GetModel(BSID).BLID).BLName;
            }

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