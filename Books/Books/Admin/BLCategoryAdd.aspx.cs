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
    public partial class BLCategoryAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_save_Click(object sender, EventArgs e)
        {
            //验证不能为空
            if (string.IsNullOrEmpty(input_BLCG.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('不能为空！')", true);
                return;
            }
            //声明对象
            Bll_BLCategory bll = new Bll_BLCategory();
            Mod_BLCategory m = new Mod_BLCategory();
            //赋值
            m.BLName = input_BLCG.Text;
            //执行&反馈
            if (bll.Add(m))
            {
                Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('添加失败！')", true);
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_cancel_Click(object sender, EventArgs e)
        {
            //使用JavaScript重定向到主页面
            Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }
    }
}