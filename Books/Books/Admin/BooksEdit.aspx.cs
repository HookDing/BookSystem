using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class BooksEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //大类别
                Bll_BLCategory BLBll = new Bll_BLCategory();
                Ddl_BLID.DataSource = BLBll.GetAllModel();
                Ddl_BLID.DataValueField = "BLID";
                Ddl_BLID.DataTextField = "BLName";
                Ddl_BLID.DataBind();
                Ddl_BLID.Items.Insert(0, new ListItem("全部", "-1"));
                //给控件加载数据
                //接收传值
                int BookID = int.Parse(Request.QueryString["BookID"].ToString().Trim());
                //查数据
                Bll_Books Bll = new Bll_Books();
                View_Books mod = Bll.GetModel(BookID);
                //填数据
                Txt_BookAuthor.Text = mod.BookAuthor;
                Txt_BookCount.Text = mod.BookCount.ToString();
                Txt_BookDeport.Text = mod.BookDeport.ToString();
                Txt_BookMoney.Text = mod.BookMoney.ToString();
                Txt_BookPrice.Text = mod.BookPrice.ToString();
                Txt_BookPublish.Text = mod.BookPublish;
                Txt_BookTitle.Text = mod.BookTitle;
                Ddl_BSID.SelectedValue = mod.BSID.ToString();

                //小类别
                Bll_BSCategory BSBll = new Bll_BSCategory();
                int BLID = int.Parse(mod.BLID.ToString());
                string sql = BLID > 0 ? $"select BSName,BSID from BSCategory where BLID={BLID}" : "select BSName,BSID from BSCategory";
                Ddl_BSID.DataSource = BSBll.GetDataTable(sql);
                Ddl_BSID.DataTextField = "BSName";
                Ddl_BSID.DataValueField = "BSID";
                Ddl_BSID.DataBind();

                Ddl_BLID.SelectedValue = mod.BLID.ToString();
                Txt_BookDesc.Value = mod.BookDesc.ToString();
                Txt_BookAuthorDesc.Value = mod.BookAuthorDesc.ToString();
                Txt_BookComm.Value = mod.BookComm.ToString();
                Txt_BookContent.Value = mod.BookContent.ToString();
                Img_ISBN.ImageUrl = "\\BookImages\\" + mod.ISBN.ToString()+".jpg";
                //End 给控件加载数据


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
        /// 大类别下拉框联动小类别下拉框
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            //非空验证
            if (string.IsNullOrEmpty(Txt_BookTitle.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入书籍名称！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookAuthor.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入作者！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookPublish.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入出版社！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Ddl_BSID.SelectedValue) || Ddl_BSID.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请选择小类别！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookPrice.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入标价！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookMoney.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入售价！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookCount.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入字数！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookDeport.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入初始库存！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookDesc.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入书籍介绍！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookAuthorDesc.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入作者介绍！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookComm.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入推荐内容！')", true);
                return;
            }
            if (string.IsNullOrEmpty(Txt_BookContent.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入书籍名称！')", true);
                return;
            }
            //接收数据 & 装载数据
            View_Books mod = new View_Books();
            mod.BookID = int.Parse(Request.QueryString["BookID"].ToString().Trim());
            mod.BookAuthor = Txt_BookAuthor.Text;
            mod.BookCount = Convert.ToInt32(Txt_BookCount.Text);
            mod.BookDeport = Convert.ToInt32(Txt_BookDeport.Text);
            mod.BookMoney = Convert.ToDecimal(Txt_BookMoney.Text);
            mod.BookPrice = Convert.ToDecimal(Txt_BookPrice.Text);
            mod.BookPublish = Txt_BookPublish.Text;
            mod.BookTitle = Txt_BookTitle.Text;
            mod.BSID = Convert.ToInt32(Ddl_BSID.SelectedValue);
            mod.BookDesc = Txt_BookDesc.Value;
            mod.BookAuthorDesc = Txt_BookAuthorDesc.Value;
            mod.BookComm = Txt_BookComm.Value;
            mod.BookContent = Txt_BookContent.Value;
            mod.ISBN = Request.QueryString["BookID"].ToString().Trim();
            mod.BookIsBuy = false;
            mod.BookIsHot = false;
            mod.BookIsDelete = false;
            mod.BookSale = 0;
            //执行 & 反馈
            Bll_Books Bll = new Bll_Books();
            if (Bll.Update(mod))
            {
                #region 保存图片
                string fileName = File_ISBN.FileName;
                //判断上传控件是否选择的上传文件
                if (!string.IsNullOrEmpty(fileName))
                {
                    //判断控件是否包含上传文件
                    if (File_ISBN.HasFile)
                    {
                        //判断文件格式
                        if (fileName.EndsWith(".jpeg") || fileName.EndsWith(".jpg") || fileName.EndsWith(".png"))
                        {
                            //截取字符串，获取上传文件的扩展名 && 重命名
                            fileName = mod.ISBN + ".jpg";
                            //获取服务器保存的绝对路径
                            string fielUrl = Server.MapPath(@"~\Content\BookImages\" + fileName);
                            //保存文件
                            File_ISBN.SaveAs(fielUrl);
                        }
                        else
                        {
                            Response.Write("<script>alert('图片格式不正确')</script>");
                        }
                    }
                }
                else
                {

                    if (String.IsNullOrEmpty(mod.ISBN))
                    {
                        //在新增的时候验证图片上传
                        Response.Write("<script>alert('请上传图片')</script>");
                        return;
                    }
                }
                #endregion
                Response.Write("<script>window.parent.location.reload();var index=parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('添加失败！')", true);
            }
        }
    }
}