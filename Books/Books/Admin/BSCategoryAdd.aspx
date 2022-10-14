<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSCategoryAdd.aspx.cs" Inherits="Books.Admin.BSCategoryAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>小类别添加</title>
    <%= Styles.Render("~/bundles/UICss")%>
</head>
<body style="margin: 10px">
    <form runat="server">
        <table class="table table-bordered" style="width: 95%">
            <tr>
                <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">小类别名称：</td>
                <td>
                    <asp:TextBox runat="server" name="input" type="text" class="span2" ID="input_BSName" /></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">所属大类别：</td>
                <td>
                    <asp:DropDownList runat="server" ID="Ddl_BSCG"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <asp:Button Type="button" runat="server" Text="确定" class="btn btn-info" ID="Btn_Save" OnClick="Btn_Save_Click" />
            <asp:Button Type="button" runat="server" Text="取消" class="btn btn-info" ID="Btn_Cancel" OnClick="Btn_Cancel_Click" />
        </div>
    </form>
</body>
</html>
