<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Books.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>哔卟书城后台管理系统</title>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>
    <style type="text/css">
        body {
            background: #0066A8 url(../Content/images/login_bg.png) no-repeat center 0px;
        }

        .tit {
            margin: auto;
            margin-top: 170px;
            text-align: center;
            width: 350px;
            padding-bottom: 20px;
        }

        .login-wrap {
            width: 220px;
            padding: 30px 50px 0 330px;
            height: 220px;
            background: #fff url(../Content/images/20221011103204.png) no-repeat 30px 42px;
            margin: auto;
            overflow: hidden;
        }

        .login_input {
            display: block;
            width: 210px;
        }

        .login_user {
            background: url(../Content/images/input_icon_1.png) no-repeat 200px center;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
        }

        .login_password {
            background: url(../Content/images/input_icon_2.png) no-repeat 200px center;
            font-family: "Courier New", Courier, monospace;
        }

        .btn-login {
            background: #40454B;
            box-shadow: none;
            text-shadow: none;
            color: #fff;
            border: none;
            height: 35px;
            line-height: 26px;
            font-size: 14px;
            font-family: "microsoft yahei";
        }

            .btn-login:hover {
                background: #333;
                color: #fff;
            }

        .copyright {
            margin: auto;
            margin-top: 10px;
            text-align: center;
            width: 370px;
            color: #CCC;
        }

        @media (max-height: 700px) {
            .tit {
                margin: auto;
                margin-top: 100px;
            }
        }

        @media (max-height: 500px) {
            .tit {
                margin: auto;
                margin-top: 50px;
            }
        }
    </style>
    <script>
        function showCode(my) {
            my.src = "Validate.aspx?data=" + Math.random();
        }
    </script>
</head>

<body>
    <div class="tit" style="color: white; font-size: 28px; font-weight: bold; font-family: 'Microsoft YaHei UI'">哔卟书城管理系统</div>
    <div class="login-wrap">
        <form runat="server">

            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="23" valign="bottom">用户名：</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="Txt_Name" type="text" class="login_input login_user" /></td>
                </tr>
                <tr>
                    <td height="23" valign="bottom">密  码：</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="Txt_Pwd" type="password" class="login_input login_password"/></td>
                </tr>
                <tr>
                    <td height="23" valign="bottom">验证码：</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="Txt_Code" type="password" class="input-small" />&nbsp;&nbsp;
                    <img src="Validate.aspx" style="cursor: pointer;" onclick="showCode(this)"/>
                    </td>
                </tr>
                <tr>
                    <td height="40" valign="bottom">
                        <asp:Button Type="button" runat="server" CssClass="btn btn-block btn-login" Text="登录" ID="Lbtn_Login" OnClick="Lbtn_Login_Click" />

                    </td>
                </tr>

            </table>
        </form>
    </div>
    <div class="copyright">建议使用IE8以上版本或谷歌浏览器</div>
</body>
</html>
