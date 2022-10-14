<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="Region.aspx.cs" Inherits="Books.Pages.Region1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Css1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--中部开始-->
        <div>
            <div style="border:1px solid #CCCCCC;height:300px;padding:30px 100px">
                <table>
                    <tr>
                        <td colspan="2">
                            <img src="/Content/Images/regisTitle.png" />
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">用户名</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_UserName"  type="text" /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">昵称</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_UserNick"  type="text"  /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">email</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_Email"  type="text"  /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">密码</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_Password"  type="password" /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">密码确认</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_repPassword"  type="password"  /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">QQ</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_QQ" type="text"  /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr style="height:30px">
                        <td style="text-align:right">手机</td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:TextBox runat="server" ID="Txt_Tel"  type="text"  /><font color="red">(必填)</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right"></td>
                        <td style="text-align:left;padding-left:10px">
                            <asp:ImageButton runat="server" type="button" ID="Btn_DoRegist" OnClick="Btn_DoRegist_Click" src="/Content/Images/regisBtn.png" style="border-width:0px;" />
                        </td>
                    </tr>
                </table>
            </div>

        </div>
        <!--中部结束-->
</asp:Content>
