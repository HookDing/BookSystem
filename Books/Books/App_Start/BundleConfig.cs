using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Books
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // 若要使这些文件正常工作，采用适当的顺序是非常重要的；这些文件具有显式依赖关系
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // 使用要用于开发和学习的 Modernizr 开发版本。然后，在准备好进行生产时，
            // 准备生产时，使用 https://modernizr.com 中的生成工具仅选择所需的测试
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/UICss").Include(
                            "~/content/css/bootstrap.css",
                            "~/content/css/css.css"));

            bundles.Add(new ScriptBundle("~/bundles/UICss1").Include(
                            "~/content/css/bootstrap.css",
                            "~/content/css/css1.css"));

            bundles.Add(new ScriptBundle("~/bundles/UIJS").Include(
                            "~/content/js/jquery1.9.0.min.js",
                            "~/content/js/bootstrap.min.js",
                            "~/content/js/sdmenu.js",
                            "~/content/js/layer/layer.js"));
        }
    }
}