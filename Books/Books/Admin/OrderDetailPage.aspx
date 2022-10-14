<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailPage.aspx.cs" Inherits="Books.Admin.OrderDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单详细信息</title>
    <%= Styles.Render("~/bundles/UICss")%>
</head>
<body style="margin: 10px">
    <form runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>订单详细信息</strong></div>
        <div style="height: 600px; overflow: auto;">
            <table class="table table-bordered" style="width: 98%">
                <tr style="height: 30px">
                    <td colspan="4">
                        <strong>订单信息</strong>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单编号：</td>
                    <td>
                        <asp:Label runat="server" ID="Lbl_OrderNum" /></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单时间：</td>
                    <td><asp:Label runat="server" ID="Lbl_OrderDate" /></td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单总金额：</td>
                    <td><asp:Label runat="server" ID="Lbl_Money" /></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单状态：</td>
                    <td><asp:Label runat="server" ID="Lbl_State" /></td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="4">
                        <strong>购物人信息</strong>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">登录账号：</td>
                    <td><asp:Label runat="server" ID="Lbl_UserName" /></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">收货人：</td>
                    <td><asp:Label runat="server" ID="Lbl_AMUser" /></td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">联系电话：</td>
                    <td><asp:Label runat="server" ID="Lbl_AMTel" /></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">收货地址：</td>
                    <td><asp:Label runat="server" ID="Lbl_AMAddress" /></td>
                </tr>
            </table>
            <p></p>
            <strong>订单详细信息</strong>

            <asp:GridView ID="GV_Books" runat="server" AutoGenerateColumns="False" class="table table-bordered table-striped table-hover"
                Width="98%" >
                <Columns>
                    <asp:BoundField HeaderText="书籍名" DataField="BookTitle" />
                    <asp:BoundField HeaderText="单价" DataField="BookMoney" />
                    <asp:BoundField HeaderText="数量" DataField="ODCount" />
                    <asp:BoundField HeaderText="总金额" DataField="ODMoney" />
                </Columns>

            </asp:GridView>
            <asp:Button runat="server" ID="Btn_Back" OnClick="Btn_Back_Click" type="button" Text="返回" class="btn btn-info" />
            <div style="height: 100px"></div>
        </div>
    </form>
</body>
</html>
