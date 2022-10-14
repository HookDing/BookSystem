using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class BooksPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定下拉框
                //数据源：是否秒杀&是否热门
                Dictionary<int, string> Dic_Ddl_BookIsBuy = new Dictionary<int, string>();
                Dic_Ddl_BookIsBuy.Add(-1, "全部");
                Dic_Ddl_BookIsBuy.Add(1, "是");
                Dic_Ddl_BookIsBuy.Add(0, "否");
                //大类别
                Bll_BLCategory BLBll = new Bll_BLCategory();
                Ddl_BLID.DataSource = BLBll.GetAllModel();
                Ddl_BLID.DataValueField = "BLID";
                Ddl_BLID.DataTextField = "BLName";
                Ddl_BLID.DataBind();
                Ddl_BLID.Items.Insert(0, new ListItem("全部", "-1"));
                //小类别
                Bll_BSCategory BSBll = new Bll_BSCategory();  //从数据库获取全部小类别 List<BSCategoryMod> list = BSBll.GetAllModel();
                //初始加载不加载小类别
                List<Mod_BSCategory> list = new List<Mod_BSCategory>();
                list.Insert(0, new Mod_BSCategory { BSName = "全部", BSID = -1 });
                Ddl_BSID.DataSource = list;
                Ddl_BSID.DataTextField = "BSName";
                Ddl_BSID.DataValueField = "BSID";
                Ddl_BSID.DataBind();
                //是否秒杀
                Ddl_BookIsBuy.DataSource = Dic_Ddl_BookIsBuy;
                Ddl_BookIsBuy.DataValueField = "Key";
                Ddl_BookIsBuy.DataTextField = "Value";
                Ddl_BookIsBuy.DataBind();
                //是否热门
                Ddl_BookIsHot.DataSource = Dic_Ddl_BookIsBuy;
                Ddl_BookIsHot.DataValueField = "Key";
                Ddl_BookIsHot.DataTextField = "Value";
                Ddl_BookIsHot.DataBind();
                //End 绑定下拉框

                BindGrid(1);
            }
        }
        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["Admin"] == null)
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
        }
        /// <summary>
        /// 加载表格数据
        /// </summary>
        /// <param name="index">当前页</param>
        protected void BindGrid(int index)
        {
            //GridView绑定数据
            Select_Book info = new Select_Book();
            if (ViewState["select"] != null)
            {
                info = ViewState["select"] as Select_Book;
            }
            info.PageIndex = index;
            info.PageSize = 10;
            Bll_Books Bll = new Bll_Books();
            GV_Books.DataSource = Bll.GetModelListByPage(info);
            GV_Books.DataBind();
            //计算总页数
            int pageCount = (info.DataCount + info.PageSize - 1) / info.PageSize;
            //当前页
            Lab_NowPage.Text = index.ToString();
            //总页数
            Lab_AllPage.Text = pageCount.ToString();
            ViewState["Index"] = index;
        }
        /// <summary>
        /// 替换表格字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_Books_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Cells[8].Text = bool.Parse(e.Row.Cells[8].Text) ? "是" : "否";
                e.Row.Cells[9].Text = bool.Parse(e.Row.Cells[9].Text) ? "是" : "否";
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            Select_Book select = new Select_Book();
            select.BookTitle = Txt_BookTitle.Text;
            select.BLID = Convert.ToInt32(Ddl_BLID.SelectedValue);
            select.BSID = Convert.ToInt32(Ddl_BSID.SelectedValue);
            select.BookPublish = Txt_BookPublish.Text;
            select.BookIsBuy = Convert.ToInt32(Ddl_BookIsBuy.SelectedValue);
            select.BookIsHot = Convert.ToInt32(Ddl_BookIsHot.SelectedValue);
            ViewState["select"] = select;
            BindGrid(1);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_Books_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //获取主键
            int BookID = (int)GV_Books.DataKeys[e.RowIndex].Value;
            //操作&反馈
            bool res = new Bll_Books().Delete(BookID);
            if (res)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除成功')", true);
                BindGrid(1);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除失败')", true);
            }
        }

        /// <summary>
        /// 大类别绑定小类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_BLID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bll_BSCategory BSBll = new Bll_BSCategory();
            int BLID = int.Parse(Ddl_BLID.SelectedValue);
            string sql = BLID > 0 ? $"select BSName,BSID from BSCategory where BLID={BLID}" : "select BSName,BSID from BSCategory";
            Ddl_BSID.DataSource = BSBll.GetDataTable(sql);
            Ddl_BSID.DataTextField = "BSName";
            Ddl_BSID.DataValueField = "BSID";
            Ddl_BSID.DataBind();
            Ddl_BSID.Items.Insert(0, new ListItem("全部", "-1"));
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

    }
}