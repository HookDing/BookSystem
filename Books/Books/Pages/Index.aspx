<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Books.Pages.WebForm1" %>

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
        <div class="redAll" style="float: right; width: 100%">
            <div class="redTitle" style="float: right; width: 725px">秒杀专区</div>
            <!--Rep秒杀-->
            <asp:Repeater runat="server" ID="Rep_Sale" OnItemCommand="Rep_Sale_ItemCommand">
                <ItemTemplate>
                    <div style="float: left; margin: 5px 5px; overflow: hidden">
                        <div style="width: 135px; text-align: center">
                            <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                                <img src="/BookImages/<%#Eval("ISBN") %>.jpg" style="border: 1px solid #CDCECE; width: 80px; height: 110px" />
                            </a>
                        </div>
                        <div style="height: 25px; line-height: 15px; text-align: center">
                            <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                                <p style="width: 120px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis;"><%# Eval("BookTitle") %></p>
                            </a>
                        </div>
                        <div style="height: 15px; line-height: 15px; text-align: center">
                            <font style="text-decoration: line-through"><%#Eval("BookPrice") %></font>
                        </div>
                        <div style="height: 15px; line-height: 15px; text-align: center">
                            <font color="#FF7126" style="font-weight: bold"><%#Eval("BookMoney") %></font>
                        </div>
                        <div style="text-align: center">
                            <asp:ImageButton runat="server" src="/Content/Images/goumaismall.jpg" style="cursor: pointer" CommandName="Buy" CommandArgument='<%# Eval("BookID") %>'/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!--End Rep秒杀-->
        </div>
        <div style="clear: both"></div>
        <p></p>
        <div class="redAll" style="float: right; width: 100%">
            <div class="redTitle" style="float: right; width: 725px">热门推荐</div>
            <!--Rep热门-->
            <asp:Repeater runat="server" ID="Rep_Hot" OnItemCommand="Rep_Hot_ItemCommand">
                <ItemTemplate>
                    <div style="float: left; margin: 5px 5px; overflow: hidden">
                        <div style="width: 135px; text-align: center">
                            <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                                <img src="/BookImages/<%#Eval("ISBN") %>.jpg" style="border: 1px solid #CDCECE; width: 80px; height: 110px" />
                            </a>
                        </div>
                        <div style="height: 25px; line-height: 15px; text-align: center">
                            <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                                <p style="width: 120px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis;"><%# Eval("BookTitle") %></p>
                            </a>
                        </div>
                        <div style="height: 15px; line-height: 15px; text-align: center">
                            <font style="text-decoration: line-through"><%#Eval("BookPrice") %></font>
                        </div>
                        <div style="height: 15px; line-height: 15px; text-align: center">
                            <font color="#FF7126" style="font-weight: bold"><%#Eval("BookMoney") %></font>
                        </div>
                        <div style="text-align: center">
                            <asp:ImageButton runat="server" src="/Content/Images/goumaismall.jpg" style="cursor: pointer" CommandName="Buy" CommandArgument='<%# Eval("BookID") %>'/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!--End Rep热门-->
        </div>
    </div>
    <!--中部结束-->
</asp:Content>
