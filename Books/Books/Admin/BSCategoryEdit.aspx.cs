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
    public partial class BSCategoryEdit : System.Web.UI.Page
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
                //接收主键ID
                int BSID = int.Parse(Request.QueryString["BSID"]);
                //输入框
                Bll_BSCategory BSbll = new Bll_BSCategory();
                input_BSName.Text = BSbll.GetModel(BSID).BSName;
                //下拉框
                Bll_BLCategory BLbll = new Bll_BLCategory();
                Ddl_BLCG.DataSource = BLbll.GetAllModel();
                Ddl_BLCG.DataTextField = "BLName";
                Ddl_BLCG.DataValueField = "BLID";
                Ddl_BLCG.DataBind();
                Ddl_BLCG.SelectedValue = BSbll.GetModel(BSID).BLID.ToString();
            }
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Cancle_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            //验证不能为空
            if (string.IsNullOrEmpty(input_BSName.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('小类别不能为空！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Ddl_BLCG.SelectedValue) || Ddl_BLCG.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请选择大类别！')", true);
                return;
            }
            //赋值
            Mod_BSCategory m = new Mod_BSCategory
            {
                BSID= int.Parse(Request.QueryString["BSID"]),
                BSName = input_BSName.Text,
                BLID = int.Parse(Ddl_BLCG.SelectedValue),
            };

            //执行&反馈
            Bll_BSCategory bll = new Bll_BSCategory();
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