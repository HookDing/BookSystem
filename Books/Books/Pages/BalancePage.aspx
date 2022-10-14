<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="BalancePage.aspx.cs" Inherits="LossionBook.BalancePage" %>
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
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货人姓名(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">联系电话(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货地址(必填)：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtAdd" runat="server" style="width:471px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Button ID="btnDefault" runat="server" Text="使用默认地址" OnClick="btnDefault_Click" />&nbsp;
                        <asp:Button ID="btnNew" runat="server" Text="保存为新地址" OnClick="btnNew_Click" />&nbsp;
                        <input type="button" value="地址管理" onclick="javascript: window.location.href = 'AddressPage.aspx'" />
                    </td>
                </tr>
            </table>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">付款方式</div>
            <p></p>
            <div>
                <input type="radio" name="money"  checked="checked" />支付宝&nbsp;&nbsp;
                <input type="radio" name="money" />网银&nbsp;&nbsp;
                <input type="radio" name="money" />微信</div>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">购物清单</div>
            <p></p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:98%;border-collapse:collapse" CssClass="dataTable" DataKeyNames="BookID" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="商品名称" />
                    <asp:BoundField DataField="BookPrice" HeaderText="原价" />
                    <asp:BoundField DataField="BookMoney" HeaderText="折扣价" />
                    <asp:BoundField HeaderText="购买数量" />
                    <asp:BoundField HeaderText="小计" />
                </Columns>
            </asp:GridView>
            <div style="text-align:right;padding-top:20px">
                <font color="#FF7126" style="font-weight:bold;font-size:20px"><asp:Label ID="labSum" runat="server" Text="0"></asp:Label>元</font>&nbsp;&nbsp;
                <asp:Button ID="btnEnter" runat="server" Text="提交订单" OnClick="btnEnter_Click" />        
            </div>
        </div>
        <!--中部结束-->
</asp:Content>
