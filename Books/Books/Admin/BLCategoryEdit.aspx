<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLCategoryEdit.aspx.cs" Inherits="Books.Admin.BLCategoryEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>大类别编辑</title>
    <%= Styles.Render("~/bundles/UICss")%>
</head>
<body style="margin:10px">
    <form runat="server" >

    <table class="table table-bordered" style="width:95%">
        <tr>
            <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">大类别名称：</td>
            <td><asp:textbox runat="server" ID="input" name="input" type="text" class="span1" style="width:200px" value="类别1" /></td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:button runat="server" ID="Btn_save" type="button" Text="确定" class="btn btn-info" OnClick="Btn_save_Click"/>
        <asp:button runat="server" ID="Btn_cancel" type="button" Text="取消" class="btn btn-info" OnClick="Btn_cancel_Click"/>
    </div>
    </form>
</body>
</html>
