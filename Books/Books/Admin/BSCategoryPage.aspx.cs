using Books.BLL;
using Books.Model;
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
    public partial class BSCategoryPage : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载下拉框数据
                Bll_BLCategory BLbll = new Bll_BLCategory();
                Ddl_BLCG.DataSource = BLbll.GetAllModel();
                Ddl_BLCG.DataTextField = "BLName";
                Ddl_BLCG.DataValueField = "BLID";
                Ddl_BLCG.DataBind();
                Ddl_BLCG.Items.Insert(0, new ListItem("全部", "0"));
                Bind();

            }

        }
        /// <summary>
        /// 加载表格数据
        /// </summary>
        protected void Bind()
        {
            Bll_BSCategory BSbll = new Bll_BSCategory();
            GV_BSCG.DataSource = BSbll.GetDataTable("select BSID,a.BLID,BSName,BLName from BSCategory a,BLCategory b where a.BLID=b.BLID ");
            GV_BSCG.DataBind();
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string BLID = Ddl_BLCG.SelectedValue;
            if (string.IsNullOrEmpty(BLID) || BLID == "0")
            {
                Bind();
            }
            else
            {
                Bll_BSCategory BSbll = new Bll_BSCategory();
                SqlParameter parameter = new SqlParameter("@BLID", SqlDbType.Int, 4) { Value = BLID };
                string sql = "select BSID,a.BLID,BSName,BLName from BSCategory a,BLCategory b where a.BLID=b.BLID and a.BLID = @BLID";
                this.GV_BSCG.DataSource = BSbll.GetDataTable(sql, parameter);
                this.GV_BSCG.DataBind();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_BSCG_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //获取主键
            int BSID = (int)GV_BSCG.DataKeys[e.RowIndex].Value;
            //操作&反馈
            bool res = new Bll_BSCategory().Delete(BSID);
            if (res)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除成功')", true);
                Bind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除失败')", true);
            }

        }
    }
}