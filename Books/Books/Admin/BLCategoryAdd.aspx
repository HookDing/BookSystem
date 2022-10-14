<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLCategoryAdd.aspx.cs" Inherits="Books.Admin.BLCategoryAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>大类别添加</title>
    <%= Styles.Render("~/bundles/UICss")%>
</head>
<body style="margin: 10px">
    <form runat="server" >
        <table class="table table-bordered" style="width: 95%">
            <tr>
                <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">大类别名称：</td>
                <td>
                    <asp:TextBox runat="server" name="input_BLCG" type="text" class="span1" ID="input_BLCG" Style="width: 200px"/>
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <asp:Button Type="button" ID="Btn_save" name="cmt" Text="确定" runat="server" class="btn btn-info" OnClick="Btn_save_Click" />
            <asp:Button Type="button" ID="Btn_cancel" name="ccl" Text="取消" runat="server" class="btn btn-info" OnClick="Btn_cancel_Click" />
        </div>
    </form>
</body>
</html>
