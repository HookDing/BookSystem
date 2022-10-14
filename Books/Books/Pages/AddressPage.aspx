<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="AddressPage.aspx.cs" Inherits="Books.Pages.AddressPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>
        <p></p>
        <div style="background-color: #F6F6F6; color: Black; font-weight: bold; font-size: 14px; height: 30px; line-height: 30px; padding: 3px 10px">地址管理</div>
        <p></p>
        <table class="dataTable" style="width: 98%">
            <tr>
                <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px; width: 150px">收货人姓名(必填)：</td>
                <td style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                    <asp:TextBox runat="Server" ID="Txt_Add_AMUser" type="text" Text="" />
                </td>
                <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px; width: 150px">联系电话(必填)：</td>
                <td style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                    <asp:TextBox runat="Server" ID="Txt_Add_AMTel" type="text" Text="" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px; width: 150px">收货地址(必填)：</td>
                <td colspan="3" style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                    <asp:TextBox runat="server" ID="Txt_Add_AMAdress" type="text" Style="width: 471px;" Text="" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px">&nbsp;</td>
                <td colspan="3" style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                    <asp:Button runat="server" ID="Btn_Add" OnClick="Btn_Add_Click" type="button" Text="新增地址" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <p></p>
        <strong>地址列表</strong>
        <hr />
        <asp:Repeater runat="server" ID="Rep_AddressList" OnItemCommand="Rep_AddressList_ItemCommand">
            <ItemTemplate>
                <table class="dataTable" style="width: 98%">
                    <tr>
                        <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px; width: 150px">收货人姓名(必填)：</td>
                        <td style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                            <asp:TextBox runat="Server" ID="Txt_AMUser" type="text" Text='<%# Eval("AMUser") %>' />
                        </td>
                        <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px; width: 150px">联系电话(必填)：</td>
                        <td style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                            <asp:TextBox runat="server" ID="Txt_AMTel" type="text" Text='<%# Eval("AMTel") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px; width: 150px">收货地址(必填)：</td>
                        <td colspan="3" style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                            <asp:TextBox runat="server" ID="Txt_AMAdress" type="text" Style="width: 471px;" Text='<%# Eval("AMAddress") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 30px; line-height: 30px; padding: 0px 8px">&nbsp;</td>
                        <td colspan="3" style="text-align: left; height: 30px; line-height: 30px; padding: 0px 8px">
                            <asp:Button runat="server" CommandName="Save" CommandArgument='<%# Eval("AMID") %>' type="button" Text="保存修改" />&nbsp;&nbsp;
                            <asp:Button runat="server" CommandName="SetDefault" CommandArgument='<%# Eval("AMID") %>' type="button" Text="设置为默认地址" />&nbsp;&nbsp;
                            <asp:Button runat="server" CommandName="Delete" CommandArgument='<%# Eval("AMID") %>' type="button" Text="删除" />
                        </td>
                    </tr>
                </table>
                <p></p>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <!--中部结束-->
</asp:Content>
