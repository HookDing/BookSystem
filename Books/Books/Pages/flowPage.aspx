<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="flowPage.aspx.cs" Inherits="Books.Pages.flowPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>

        <%{
                //判断是否有订单
                if (Session["flow"] == null)
                {
        %>
        <div style="height: 100px">
            <h1 style="text-align: center;margin-top:5%">这里还没有东西哦~</h1>
        </div>
        <%
            }
            else
            {%>
        <div style="background-color: #F6F6F6; color: Black; font-weight: bold; font-size: 14px; height: 30px; line-height: 30px; padding: 3px 10px">购物车 商品列表</div>
        <p></p>
        <div>
            <asp:GridView ID="GV_Books" runat="server" OnRowDataBound="GV_Books_RowDataBound" DataKeyNames="BookID" OnRowCommand="GV_Books_RowCommand" class="dataTable" border="1" Style="width: 98%; border-collapse: collapse" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="商品名称" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="BookPrice" HeaderText="售价" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="BookMoney" HeaderText="折扣价" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="购买数量" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button Text="-" runat="server" CommandName="Count_Reduce" CommandArgument="<%# Container.DataItemIndex%>" />
                            <asp:Label ID="Lbl_Count" Text="1" runat="server" />
                            <asp:Button Text="+" runat="server" CommandName="Count_Increase" CommandArgument="<%# Container.DataItemIndex%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="小计" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="Lbl_Subtotal" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button Text="删除" runat="server" CommandName="Count_Del" CommandArgument="<%# Container.DataItemIndex%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <p></p>

        <table class="dataTable" style="width: 98%">
            <tr>

                <td style="width: 400px; text-align: left; padding: 0 5px; height: 30px; line-height: 30px">购物金额小计： 
                    <font color="#FF7126" style="font-weight: bold"><asp:Label ID="Lbl_Money" Text="0.00" runat="server" /> 元</font>
                    比售价<asp:Label ID="Lbl_Price" Text="0.00" runat="server" />
                    元 节省了 <asp:Label ID="Lbl_Save" Text="0.00" runat="server" />元
                </td>
                <td style="padding: 0 5px; height: 30px; line-height: 30px; text-align: right">
                    <asp:Button runat="server" ID="Btn_ClearCar" type="submit" Text="清空购物车" OnClick="Btn_ClearCar_Click" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <% }
            }%>
        <p></p>
        <table style="width: 98%">
            <tr>
                <td style="text-align: left">
                    <a href="index.aspx">
                        <img src="/Content/Images/goShop.png" style="border: 0px" />
                    </a>
                </td>
                <td style="text-align: right">
                    <a href="BalancePage.aspx">
                        <img src="/Content/Images/goOrder.png" style="border: 0px" />
                    </a>
                </td>
            </tr>
        </table>

    </div>
    <!--中部结束-->
</asp:Content>
