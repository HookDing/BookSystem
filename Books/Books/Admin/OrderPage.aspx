<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="Books.Admin.OrderPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单管理</title>
    <script src="../Content/laydate/laydate.js"></script>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>
</head>
<body style="margin: 10px">
    <form runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>订单管理</strong></div>
        <table style="width: 98%; margin: 10px 0px; padding: 5px 2px">
            <tr>
                <td align="right" nowrap="nowrap">订单编号：</td>
                <td>
                    <asp:TextBox runat="server" type="text" class="span2" ID="Txt_OrderID" /></td>
                <td align="right" nowrap="nowrap">客户姓名：</td>
                <td>
                    <asp:TextBox runat="server" type="text" class="span2" ID="Txt_UserName" />
                </td>
                <td align="right" nowrap="nowrap">订单状态：</td>
                <td>
                    <asp:DropDownList runat="server" ID="Ddl_OrderState">
                        <asp:ListItem Text="全部" Value="0" />
                        <asp:ListItem Text="待确定" Value="1" />
                        <asp:ListItem Text="已确认" Value="2" />
                        <asp:ListItem Text="已发货" Value="3" />
                        <asp:ListItem Text="完成" Value="4" />
                    </asp:DropDownList>
                </td>
                <td align="right" nowrap="nowrap">订单时间：</td>
                <td>
                    <asp:TextBox ID="Calendar1" runat="server" class="laydate-icon span1-1" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    至
                    <asp:TextBox ID="Calendar2" runat="server" class="laydate-icon span1-1" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                    <asp:CheckBox runat="server" type="checkbox" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" type="button" Text="查询" class="btn btn-info" ID="Btn_Search" OnClick="Btn_Search_Click" /></td>
            </tr>
        </table>
        <p />
        <asp:GridView runat="server" DataKeyNames="OrderID" OnRowCommand="GV_Orders_RowCommand" OnRowDataBound="GV_Orders_RowDataBound"
            AutoGenerateColumns="False" ID="GV_Orders" class="table table-bordered table-striped table-hover" Width="98%">
            <Columns>
                <asp:TemplateField HeaderText="订单编号" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton Text='<%#Eval("OrderNum") %>' runat="server" ID="Lkb_GoDetail" CommandName="GoDetail" CommandArgument='<%#Eval("OrderID") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="客户姓名" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="OrderDate" HeaderText="订单时间" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="OrderMoney" HeaderText="总金额" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="OrderState" HeaderText="状态" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="Btn_Edit" Text="操作" CommandName="DoEdit" CommandArgument='<%#Eval("OrderID") %>' />
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="text-align: right; width: 90%">
            <asp:Button runat="server" type="button" Text="首页" class="btn btn-info" ID="Btn_FirstPage" OnClick="Btn_FirstPage_Click" />
            <asp:Button runat="server" type="button" Text="上一页" class="btn btn-info" ID="Btn_UpPage" OnClick="Btn_UpPage_Click" />
            <asp:Button runat="server" type="button" Text="下一页" class="btn btn-info" ID="Btn_DownPag" OnClick="Btn_DownPag_Click" />
            <asp:Button runat="server" type="button" Text="尾页" class="btn btn-info" ID="Btn_LastPage" OnClick="Btn_LastPage_Click" />
            &nbsp;当前页/总页数：
            <asp:Label runat="server" ID="Lab_NowPage" />
            /<asp:Label runat="server" ID="Lab_AllPage" />
        </div>
    </form>
    <script>
        !function () {
            laydate.skin('molv');
            laydate({ elem: '#Calendar1' });
            laydate.skin('molv');
            laydate({ elem: '#Calendar2' });
        }();
    </script>
</body>
</html>
