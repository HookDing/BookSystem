<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksPage.aspx.cs" Inherits="Books.Admin.BooksPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>书籍管理</title>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>
    <script type="text/javascript">
        function ShowAdd() {
            layer.open({
                type: 2,
                title: "添加书籍",
                content: ["BooksAdd.aspx"],
                area: ["90%", "90%"],
                offset: "5%",
                shadeClose: true,
                move: false,
                scrollbar: true,
            });
        }
        function ShowEdit(id) {
            layer.open({
                type: 2,
                title: "书籍信息编辑",
                content: ["BooksEdit.aspx?BookID=" + id],
                area: ["90%", "90%"],
                offset: "5%",
                shadeClose: true,
                move: false,
                scrollbar: true,
            })
        }
    </script>
</head>
<body style="margin: 10px">
    <form runat="server">

        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍管理</strong></div>
        <table style="width: 700px; margin: 10px 0px; padding: 5px 2px">
            <tr>
                <td align="right" nowrap="nowrap">书籍名称：</td>
                <td>
                    <asp:TextBox runat="server" ID="Txt_BookTitle" type="text" Text="" class="span2" /></td>
                <td align="right" nowrap="nowrap">大类别：</td>
                <td>
                    <asp:DropDownList runat="server" class="span2" Style="height: 25px" ID="Ddl_BLID" AutoPostBack="true" OnSelectedIndexChanged="Ddl_BLID_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td align="right" nowrap="nowrap">小类别：</td>
                <td>
                    <asp:DropDownList runat="server" class="span2" Style="height: 25px" ID="Ddl_BSID"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">出版社：</td>
                <td>
                    <asp:TextBox runat="server" ID="Txt_BookPublish" type="text" class="span2" /></td>
                <td align="right" nowrap="nowrap">是否秒杀：</td>
                <td>
                    <asp:DropDownList runat="server" class="span2" Style="height: 25px" ID="Ddl_BookIsBuy">
                    </asp:DropDownList>
                </td>
                <td align="right" nowrap="nowrap">是否热门：</td>
                <td>
                    <asp:DropDownList runat="server" class="span2" Style="height: 25px" ID="Ddl_BookIsHot">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button runat="server" type="button" Text="查询" class="btn btn-info" ID="Btn_Search" OnClick="Btn_Search_Click" /></td>
            </tr>
        </table>
        <input type="button" value="新增书籍" class="btn btn-info" onclick="javascript:ShowAdd()" />
        <p />
        <asp:GridView runat="server" ID="GV_Books" OnRowDataBound="GV_Books_RowDataBound" AutoGenerateColumns="False"
            class="table table-bordered table-striped table-hover" Width="98%" OnRowDeleting="GV_Books_RowDeleting" DataKeyNames="BookID">
            <Columns>
                <asp:BoundField HeaderText="书籍名" DataField="BookTitle" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="true">
                    <ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="大类别" DataField="BLName" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="小类别" DataField="BSName" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="出版社" DataField="BookPublish" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="true">
                    <ItemStyle HorizontalAlign="Center" Wrap="True"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="标价" DataField="BookPrice" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="售价" DataField="BookMoney" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="销售数量" DataField="BookSale" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="库存数量" DataField="BookDeport" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="是否秒杀" DataField="BookIsBuy" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="是否热门" DataField="BookIsHot" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <a href="javascript:ShowEdit(<%# Eval("BookID") %>)" class="btn btn-info">编辑</a>
                        <asp:LinkButton Text="删除" ID="Btn_Delte" CssClass="btn btn-danger" OnClientClick="return confirm('删除？')" CommandName="delete" runat="server" />
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

        <div style="text-align: left; width: 90%">
            <asp:Button runat="server" type="button" Text="首页" class="btn btn-info" ID="Btn_FirstPage" OnClick="Btn_FirstPage_Click" />
            <asp:Button runat="server" type="button" Text="上一页" class="btn btn-info" ID="Btn_UpPage" OnClick="Btn_UpPage_Click" />
            <asp:Button runat="server" type="button" Text="下一页" class="btn btn-info" ID="Btn_DownPag" OnClick="Btn_DownPag_Click" />
            <asp:Button runat="server" type="button" Text="尾页" class="btn btn-info" ID="Btn_LastPage" OnClick="Btn_LastPage_Click" />
            &nbsp;当前页/总页数：
            <asp:Label runat="server" ID="Lab_NowPage" />
            /<asp:Label runat="server" ID="Lab_AllPage" />
        </div>
    </form>
</body>
</html>
