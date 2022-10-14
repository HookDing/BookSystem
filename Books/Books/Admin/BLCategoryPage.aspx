<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLCategoryPage.aspx.cs" Inherits="Books.Admin.BLCategoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>书籍大类别管理</title>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>
    <script type="text/javascript">
        function ShowAdd() {
            layer.open({
                type: 2,
                title: "添加大类别",
                content: ["BLCategoryAdd.aspx", "no"],
                area: ["500px", "200px"],
                offset: "100px"
            });
        }
        function ShowEdit(id) {
            layer.open({
                type: 2,
                title: "编辑大类别",
                content: ["BLCategoryEdit.aspx?BLID="+ id , "no"],
                area: ["500px", "200px"],
                offset: "100px"
                
            })
        }
    </script>

</head>
<body style="margin: 10px" runat="server">
    <form runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍大类别管理</strong></div>
        <a href="javascript:ShowAdd()" class="btn btn-info">新增大类别</a>
        <p />

        <asp:GridView runat="server" ID="GV_BLCG" AutoGenerateColumns="False" DataKeyNames="BLID"
            OnRowDeleting="GV_BLCG_RowDeleting"
            class="table table-bordered table-striped table-hover" style="width:400px">
            <Columns>
                <asp:BoundField DataField="BLID" HeaderText="大类别编号" />
                <asp:BoundField DataField="BLName" HeaderText="大类别名称" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a href="javascript:ShowEdit(<%#Eval("BLID") %>)" class="btn btn-info">编辑</a>
                        <asp:LinkButton ID="lkbtn_del" CssClass="btn btn-info" runat="server" OnClientClick="return confirm('删除？')" CommandName="delete" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
