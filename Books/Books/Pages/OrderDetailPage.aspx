<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="OrderDetailPage.aspx.cs" Inherits="Books.Pages.OrderDetailPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--中部开始-->
        <div>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">收货人信息</div>
            <p></p>
            <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货人姓名：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">张三</td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">联系电话：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">138374736</td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货地址：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        湖南省长沙市河西枫林三路涉外国际公馆
                    </td>
                </tr>
            </table>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">购物清单</div>
            <p></p>
            <table class="dataTable" cellspacing="0" border="1" style="width:98%;border-collapse:collapse">
                <tr>
                    <th align="center" scope="col" style="height:30px;">商品名称</th>
                    <th align="center" scope="col">售价</th>
                    <th align="center" scope="col">折扣价</th>
                    <th align="center" scope="col">购买数量</th>
                    <th align="center" scope="col">小计</th>
                </tr>
                <tr>
                    <td align="center" style="height:30px;">
                        <a href="BooksPage" target="_blank">C#入门经典</a>
                    </td>
                    <td align="center" style="height:30px;">
                        ￥85.00元
                    </td>
                    <td align="center">
                        ￥72.00元
                    </td>
                    <td align="center">
                        1
                    </td>
                    <td align="center">
                        ￥72.00元
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height:30px;">
                        <a href="BooksPage" target="_blank">C#高级编程</a>
                    </td>
                    <td align="center" style="height:30px;">
                        ￥102.00元
                    </td>
                    <td align="center">
                        ￥89.00元
                    </td>
                    <td align="center">
                        2
                    </td>
                    <td align="center">
                        ￥178.00元
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:right;height:40px">
                        <font color="#FF7126" style="font-weight:bold;font-size:20px">￥260.00元</font>&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <!--中部结束-->
</asp:Content>
