<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="AppraisePage.aspx.cs" Inherits="Books.Pages.AppraisePage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">书籍评价</div>
    <p></p>
    <table class="dataTable" style="width:98%">
        <tr>
            <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">评分</td>
            <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                <asp:DropDownList runat="server" ID="Ddl_Point">
                    <asp:ListItem Text="5分" Value="5"/>
                    <asp:ListItem Text="4分" Value="4" />
                    <asp:ListItem Text="3分" Value="3" />
                    <asp:ListItem Text="2分" Value="2" />
                    <asp:ListItem Text="1分" Value="1" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">评价</td>
            <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                <asp:TextBox runat="server" ID="Txt_Appraise"  TextMode="MultiLine" style="height:150px;width:90%"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
            <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                <asp:Button Text="确定" runat="server" ID="Btn_Save" OnClick="Btn_Save_Click" />&nbsp;
                <asp:Button Text="关闭" runat="server" ID="Btn_Close" OnClick="Btn_Close_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
