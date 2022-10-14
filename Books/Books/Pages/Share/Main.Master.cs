using Books.BLL;
using Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Pages.Share
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private List<Mod_BSCategory> bsList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bsList = new Bll_BSCategory().GetAllModel();

                List<Mod_BLCategory> list = new Bll_BLCategory().GetAllModel();
                //绑定头部大类别
                repHead.DataSource = list;
                repHead.DataBind();
                if (Session["Search"]!=null)
                {
                Txt_Search.Text = Session["Search"].ToString();

                }
            }
        }

        protected void Btn_Logout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("index.aspx");
        }


        protected void Btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            string Search = "";
            Search = Txt_Search.Text;
            Session["Search"] = Search;
            Response.Redirect("SelectPage.aspx?Search=" + Server.UrlEncode(Search));
        }
    }
}