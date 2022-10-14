using Books.BLL;
using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class BLCategoryEdit : System.Web.UI.Page
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
                Bll_BLCategory bll = new Bll_BLCategory();
                int BLID = int.Parse(Request.QueryString["BLID"].ToString().Trim());
                input.Text = bll.GetModel(BLID).BLName;
            }
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_save_Click(object sender, EventArgs e)
        {
            //非空验证
            if (string.IsNullOrEmpty(input.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('不能为空！')", true);
                return;
            }
            //声明对象 & 装载
            Bll_BLCategory bll = new Bll_BLCategory();
            Mod_BLCategory m = new Mod_BLCategory();
            m.BLName = input.Text;
            m.BLID = int.Parse(Request.QueryString["BLID"].ToString().Trim());
            //执行&反馈
            if (bll.Update(m))
            {
                Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('修改失败！')", true);
            }
        }
    }
}