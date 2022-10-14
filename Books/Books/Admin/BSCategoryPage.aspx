<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSCategoryPage.aspx.cs" Inherits="Books.Admin.BSCategoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>小类别管理</title>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>
    <script type="text/javascript">
        function ShowAdd() {
            layer.open({
                type: 2,
                title: "添加小类别",
                content: ["BSCategoryAdd.aspx", "no"],
                area: ["600px", "400px"],
                offset: "150px",
                scrollbars: true
            });
        }
        function ShowEdit(id) {
            layer.open({
                type: 2,
                title: "编辑小类别",
                content: ["BSCategoryEdit.aspx?BSID=" + id, "no"],
                area: ["600px", "400px"],
                offset: "150px",
                scrollbars: true

            })
        }
    </script>
</head>
<body style="margin: 10px">
    <form runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍小类别管理</strong></div>
        <table style="margin: 10px 0px; padding: 5px 2px">
            <tr>
                <td align="right" nowrap="nowrap">所属大类别：</td>
                <td>
                    <asp:DropDownList runat="server" ID="Ddl_BLCG"></asp:DropDownList>
                </td>
                <td>&nbsp;&nbsp;<asp:Button runat="server" Text="查询" ID="Btn_Search"  OnClick="Btn_Search_Click" class="btn btn-info" /></td>
            </tr>
        </table>
        <a href="javascript:ShowAdd()" class="btn btn-info">新增小类别</a>
        <p />
        <asp:GridView runat="server" DataKeyNames="BSID" AutoGenerateColumns="False" 
            ID="GV_BSCG" OnRowDeleting="GV_BSCG_RowDeleting"
            class="table table-bordered table-striped table-hover" style="width:90%">
            <Columns>
                <asp:BoundField DataField="BSID" HeaderText="编号" Visible="False" />
                <asp:BoundField DataField="BSName" HeaderText="小类别名称" />
                <asp:BoundField DataField="BLName" HeaderText="所属大类别" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href="javascript:ShowEdit(<%#Eval("BSID") %>)" class="btn btn-info">编辑</a>
                        <asp:LinkButton Cssclass="btn btn-info" Text="删除" ID="lkbtn_del" runat="server" OnClientClick="return confirm('删除？')"  CommandName="delete" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </form>
</body>
</html>
