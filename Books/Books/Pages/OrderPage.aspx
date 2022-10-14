<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Share/Main.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="Books.Pages.OrderPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>
        <p></p>
        <div style="background-color: #F6F6F6; color: Black; font-weight: bold; font-size: 14px; height: 30px; line-height: 30px; padding: 3px 10px">已购买书籍列表</div>
        <p></p>
        <asp:GridView runat="server" DataKeyNames="BookID" OnRowCommand="GV_Orders_RowCommand" OnRowDataBound="GV_Orders_RowDataBound"
            AutoGenerateColumns="False" ID="GV_Orders" class="table table-bordered table-striped table-hover" Width="98%">
            <Columns>
                <asp:TemplateField HeaderText="书籍图片" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <a href="BooksPage.aspx?BookID=<%# Eval("BookID") %>">
                            <img src="/BookImages/<%#Eval("ISBN") %>.jpg" style="border: 0px; width: 50px; height: 50px" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="BookTitle" HeaderText="书籍名" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="BookPrice" HeaderText="价格" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ODCount" HeaderText="数量" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="OrderState" HeaderText="状态" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="Btn_Edit" Text="评价" CommandName="DoEdit" CommandArgument='<%#Eval("ODID") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Wrap="False"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p></p>
        <div style="text-align: right; width: 98%">
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
