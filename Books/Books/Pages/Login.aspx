<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Books.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>
        <div style="border: 1px solid #CCCCCC; height: 400px">
            <div style="float: left; margin: 10px 10px; width: 330px">
                <table>
                    <tr>
                        <td colspan="2">
                            <img src="/Content/Images/login.png" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="text-align: right">用户名</td>
                        <td style="padding-left: 5px">
                            <asp:TextBox runat="server" type="text" ID="Txt_UserName" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="text-align: right">密码</td>
                        <td style="padding-left: 5px">
                            <asp:TextBox runat="server" type="password" ID="Txt_Password" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td></td>
                        <td>
                            <asp:Button runat="server" Type="Button" src="/Content/Images/logBtn.png" Style="cursor: pointer; border-width: 0px; width: 130px; height: 42px; background-image: url(/Content/Images/logBtn.png); background-repeat: no-repeat" ID="Btn_Login" OnClick="Btn_Login_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: right; margin: 10px 10px">
                <table>
                    <tr>
                        <td>
                            <img src="/Content/Images/regis.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>如果您不是会员，请注册</strong>
                            <p />

                            <strong class="f4">友情提示：</strong><p />

                            不注册为会员也可在本店购买商品<p />

                            但注册之后您可以：<p />

                            1. 保存您的个人资料<p />

                            2. 收藏您关注的商品<p />

                            3. 享受会员积分制度<p />

                            4. 订阅本店商品信息 
                                    <p />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="Region.aspx">
                                <img src="/Content/Images/regisBtn.png" style="border: 0px" /></a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>
    <!--中部结束-->

</asp:Content>
