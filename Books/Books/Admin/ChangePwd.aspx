<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="Books.Admin.ChangePwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--中部开始-->
        <div>
            <div style="border: 1px solid #CCCCCC; padding: 30px 100px; text-align: center">
                <table>
                    <tr style="height: 30px">
                        <td style="text-align: right">旧密码</td>
                        <td style="text-align: left; padding-left: 10px">
                            <input type="text" /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="text-align: right">新密码</td>
                        <td style="text-align: left; padding-left: 10px">
                            <input type="password" /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="text-align: right">新密码确认</td>
                        <td style="text-align: left; padding-left: 10px">
                            <input type="password" /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right"></td>
                        <td style="text-align: left; padding-left: 10px">
                            <input type="button" value="修改密码" />
                        </td>
                    </tr>
                </table>
            </div>

        </div>
        <!--中部结束-->
    </form>
</body>
</html>
