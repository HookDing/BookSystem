<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Books.Admin.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>哔卟书城后台管理系统</title>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>

    <style type="text/css">
        .active {
            background-color: #38A3D5;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("div a").click(function () {
                $("div a").removeClass("active");
                var url = $(this).attr("url");
                $("#page").attr("src", url + "?" + Math.random());
                $(this).addClass("active");
            });
        });
        function ShowChangePwd() {
            layer.open({
                type: 2,
                title: "添加大类别",
                content: ["BLCategoryAdd.aspx", "no"],
                area: ["500px", "200px"],
                offset: "100px"
            });
        }
    </script>
</head>
<body>
    <div class="header">
        <form runat="server">
            <div class="logo" style="color: white; font-size: 28px; font-weight: bold; font-family: 'Microsoft YaHei UI'; padding: 20px 20px">哔卟书城后台管理系统</div>

            <div class="header-right" style="padding: 0px 0px">
               
                <asp:LinkButton runat="server" ID="Btn_LogOut" OnClick="Btn_LogOut_Click" role="button">注销</asp:LinkButton>
                <%-- <i class="icon-question-sign icon-white"></i><a href="#">帮助</a> <i class="icon-off icon-white"></i>
                    <a href="javascript:ShowChangePwd()" role="button" data-toggle="modal">修改密码</a>
                    <asp:LinkButton runat="server" ID="Btn_LogOut" OnClick="Btn_LogOut_Click" role="button">注销</asp:LinkButton>--%>
            </div>

        </form>
    </div>
    <!-- 顶部 -->

    <div id="middle">
        <div class="left">
            <div id="my_menu" class="sdmenu">
                <div>
                    <span>基础数据管理</span>
                    <a href="#" url="BLCategoryPage.aspx">书籍大类别管理</a>
                    <a href="#" url="BSCategoryPage.aspx">书籍小类别管理</a>
                    <a href="#" url="BooksPage.aspx">书籍管理</a>
                </div>
                <div>
                    <span>单据管理</span>
                    <a href="#" url="OrderPage.aspx">订单管理</a>
                </div>
            </div>

        </div>
        <div class="Switch"></div>
        <script type="text/javascript">
            $(document).ready(function (e) {
                $(".Switch").click(function () {
                    $(".left").toggle();

                });
            });
        </script>

        <div class="right" id="mainFrame">
            <iframe id="page" name="page" scrolling="auto" frameborder="0" src="Main.aspx" style="width: 98%; height: 99%"></iframe>
        </div>
    </div>

</body>
</html>
