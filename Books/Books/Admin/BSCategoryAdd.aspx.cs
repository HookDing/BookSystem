using Books.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Books.Model;

namespace Books.Admin
{
    public partial class BSCategoryAdd : System.Web.UI.Page
    {
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

                Bll_BLCategory BLbll = new Bll_BLCategory();
                Ddl_BSCG.DataSource = BLbll.GetAllModel();
                Ddl_BSCG.DataTextField = "BLName";
                Ddl_BSCG.DataValueField = "BLID";
                Ddl_BSCG.DataBind();
                Ddl_BSCG.Items.Insert(0, new ListItem("请选择", "0"));
            }
        }
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            //验证不能为空
            if (string.IsNullOrEmpty(input_BSName.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('小类别不能为空！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Ddl_BSCG.SelectedValue) || Ddl_BSCG.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请选择大类别！')", true);
                return;
            }
            //赋值
            Mod_BSCategory m = new Mod_BSCategory
            {
                BSName = input_BSName.Text,
                BLID = int.Parse(Ddl_BSCG.SelectedValue),
            };

            //执行&反馈
            Bll_BSCategory bll = new Bll_BSCategory();
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
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            //重定向到主页面
            Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }
    }
}