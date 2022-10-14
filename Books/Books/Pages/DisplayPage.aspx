<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="DisplayPage.aspx.cs" Inherits="Books.Pages.DisplayPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- 头结束 -->
        <!--中部开始-->
        <div>

            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">完成订单</div>
            <p></p>
            <div style="text-align:center"><font style="font-size:20px;font-weight:bold">订单号：<asp:Label ID="labNum" runat="server" Text=""></asp:Label></font></div>
        </div>
        <!--中部结束-->
</asp:Content>
