using Books.BLL;
using Books.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class BooksAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
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
        /// 数据初始化
        /// </summary>
        public void Bind()
        {
            //绑定下拉框
            //大类别
            Bll_BLCategory BLBll = new Bll_BLCategory();
            Ddl_BLID.DataSource = BLBll.GetAllModel();
            Ddl_BLID.DataValueField = "BLID";
            Ddl_BLID.DataTextField = "BLName";
            Ddl_BLID.DataBind();
            Ddl_BLID.Items.Insert(0, new ListItem("全部", "-1"));

            //小类别
            Bll_BSCategory BSBll = new Bll_BSCategory();
            List<Mod_BSCategory> list = new List<Mod_BSCategory> ();
            list.Insert(0, new Mod_BSCategory { BSName = "请选择大类别", BSID = -1 });
            Ddl_BSID.DataSource = list;
            Ddl_BSID.DataTextField = "BSName";
            Ddl_BSID.DataValueField = "BSID";
            Ddl_BSID.DataBind();
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
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            #region 非空验证
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
            if (string.IsNullOrEmpty(File_ISBN.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请上传ISBN！')", true);
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
            #endregion
            //获取新BookID，用于重命名封面
            int AllCount = new Bll_Books().GetCount();
            //接收传值
            View_Books mod = new View_Books();
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
            mod.ISBN = AllCount.ToString();
            mod.BookIsBuy = false;
            mod.BookIsHot = false;
            mod.BookIsDelete = false;
            mod.BookSale = 0;
            //执行
            Bll_Books Bll = new Bll_Books();
            if (Bll.Add(mod))
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
                            fileName = AllCount + ".jpg";
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
        /// <summary>
        /// 保存并继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Save_Continue_Click(object sender, EventArgs e)
        {

            #region 非空验证
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
            if (string.IsNullOrEmpty(File_ISBN.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请上传ISBN！')", true);
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
            #endregion
            //获取新BookID，用于重命名封面
            int AllCount = new Bll_Books().GetCount();
            //接收传值
            View_Books mod = new View_Books();
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
            mod.BookIsBuy = false;
            mod.BookIsHot = false;
            mod.BookIsDelete = false;
            mod.BookSale = 0;
            mod.ISBN = AllCount.ToString();
            //执行
            Bll_Books Bll = new Bll_Books();
            if (Bll.Add(mod))
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
                            fileName = AllCount + ".jpg";
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
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('添加失败！')", true);
            }
        }
    }
}