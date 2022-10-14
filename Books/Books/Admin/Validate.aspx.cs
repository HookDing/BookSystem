using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Books.Admin
{
    public partial class Validate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //加载图片
            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("../content/images/vali.jpg"));
            //获取画图工具
            Graphics g=Graphics.FromImage(img);
            //使用Random生成4位随机数
            Random random = new Random();
            int code = random.Next(1000, 10000);
            //保存到Session中
            Session["valicode"]=code;
            //在图片上绘制文字
            g.DrawString(code.ToString(), new Font("宋体", 20), new SolidBrush(Color.Black), 0, 0);
            //保存时使用响应对象的流将图片发送到客户端
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //客户端响应类型
            Response.ContentType = "image/jpeg";
            //结束当前的页面的处理
            Response.End();


        }
    }
}