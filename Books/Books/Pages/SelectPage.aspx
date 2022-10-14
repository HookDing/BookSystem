<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="SelectPage.aspx.cs" Inherits="Books.Pages.SelectPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 左边开始 -->
    <div id="leftDiv">
        <div class="redAll">
            <div class="redTitle">所有书籍类别</div>
            <div style="background-color: #F5F5F5">
                <asp:Repeater ID="repLeft" runat="server" OnItemDataBound="repLeft_ItemDataBound">
                    <ItemTemplate>
                        <div style="color: Black; font-weight: bold; padding: 0 5px; height: 25px; line-height: 25px; clear: both">
                            <a href="CategoryPage.aspx?BLID=<%# Eval("BLID") %>"><%# Eval("BLName") %></a>
                        </div>
                        <asp:Repeater ID="repInter" runat="server">
                            <ItemTemplate>
                                <div style="padding: 0 5px; height: 25px; line-height: 25px; float: left;">
                                    <a href="CategoryPage.aspx?BSID=<%# Eval("BSID") %>"><%# Eval("BSName") %></a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <hr style="width: 90%; border: 1px dashed #DDDDDD; clear: both" />
                    </ItemTemplate>
                </asp:Repeater>
                <hr style="width: 90%; border: 1px dashed #DDDDDD; clear: both" />
            </div>
        </div>
        <p></p>
        <div class="redAll">
            <div class="redTitle">畅销商品排行榜</div>
            <div style="padding: 5px 5px">
                <asp:Repeater runat="server" ID="Rep_Top_Sale">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td rowspan="3" style="width: 20px; vertical-align: text-top; text-align: center">
                                    <img src="/Content/Images/Top_1.gif" />
                                </td>
                                <td rowspan="3" style=" width: 54px; height: 72px">
                                    <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                                        <img src="/BookImages/<%#Eval("ISBN") %>.jpg" style="border: 0px; width: 48px; height: 72px" />
                                    </a>
                                </td>
                                <td style="height: 15px; line-height: 15px">
                                    <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>"><%#Eval("BookTitle") %></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 15px; line-height: 15px">
                                    <font style="text-decoration: line-through"><%#Eval("BookPrice") %></font>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 15px; line-height: 15px">
                                    <font color="#FF7126" style="font-weight: bold"><%# Eval("BookMoney") %></font>
                                </td>
                            </tr>
                        </table>
                        <hr style="width: 90%; border: 1px dashed #DDDDDD; clear: both" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <p></p>
    </div>
    <!-- 左边结束 -->
    <!--中部开始-->
    <div id="mainDiv">
        <asp:Repeater runat="server" ID="rep_Table" OnItemCommand="rep_Table_ItemCommand">
            <ItemTemplate>
                <table style="width: 100%">
                    <tr>
                        <td rowspan="5" style="width: 140px">
                            <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                                <img style="width: 120px; height: 160px" src="/BookImages/<%# Eval("ISBN") %>.jpg" /></a>
                        </td>
                        <td><a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>"><%# Eval("BookTitle") %></a></td>
                    </tr>
                    <tr>
                        <td>作者：<%# Eval("BookAuthor") %></td>
                    </tr>
                    <tr>
                        <td>出版社：<%# Eval("BookPublish") %></td>
                    </tr>
                    <tr>
                        <td>已销售数量：<%# Eval("BookSale") %>&nbsp;&nbsp;库存数量：<%# Eval("BookDeport") %>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font style="text-decoration: line-through">￥<%# Eval("BookPrice") %></font>&nbsp;&nbsp;
                        <font color="#FF7126" style="font-weight: bold">￥<%# Eval("BookMoney") %></font>&nbsp;&nbsp;
                            <asp:ImageButton runat="server" src="/Content/Images/goumaismall.jpg" Style="cursor: pointer; margin-bottom: -6px;" CommandName="Buy" CommandArgument='<%# Eval("BookID") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><%# Eval("BookDesc") %></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr style="width: 100%" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <div style="text-align: right">
            <asp:Button runat="server" type="button" Text="首页" class="btn btn-info" ID="Btn_FirstPage" OnClick="Btn_FirstPage_Click" />
            <asp:Button runat="server" type="button" Text="上一页" class="btn btn-info" ID="Btn_UpPage" OnClick="Btn_UpPage_Click" />
            <asp:Button runat="server" type="button" Text="下一页" class="btn btn-info" ID="Btn_DownPag" OnClick="Btn_DownPag_Click" />
            <asp:Button runat="server" type="button" Text="尾页" class="btn btn-info" ID="Btn_LastPage" OnClick="Btn_LastPage_Click" />
            &nbsp;当前页/总页数：
            <asp:Label runat="server" ID="Lab_NowPage" />
            /<asp:Label runat="server" ID="Lab_AllPage" />
        </div>
    </div>
    <!--中部结束-->
</asp:Content>
