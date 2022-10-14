using Books.BLL;
using Books.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class BLCategoryPage : System.Web.UI.Page
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
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGV();
            }
        }
        /// <summary>
        /// 加载表格数据
        /// </summary>
        protected void BindGV()
        {
            Bll_BLCategory Bll = new Bll_BLCategory();
            GV_BLCG.DataSource = Bll.GetAllModel();
            GV_BLCG.DataBind();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_BLCG_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //获取主键
            int BLID = (int)GV_BLCG.DataKeys[e.RowIndex].Value;
            //操作&反馈
            bool res = new Bll_BLCategory().Delete(BLID);
            if (res)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除成功')", true);
                BindGV();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('删除失败')", true);
            }
        }
    }
}