<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksAdd.aspx.cs" Inherits="Books.Admin.BooksAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>书籍添加</title>
    <%= Styles.Render("~/bundles/UICss")%>
    <%= Scripts.Render("~/bundles/UIJS")%>
    <script>
        function Close() {
            window.parent.location.reload();
            var index = parent.layer.getFrameIndex(window.name);
            parent.layer.close(index);
        }
    </script>
            
</head>
<body style="margin: 10px">
    <form runat="server">
        <div style="height: 800px; overflow: auto;">
            <table class="table table-bordered" style="width: 98%">
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">书籍名称：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" class="span4" ID="Txt_BookTitle" />
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">作者：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" class="span4" ID="Txt_BookAuthor"/>

                    </td>
                </tr>
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">出版社：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" class="span4" ID="Txt_BookPublish" />

                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">ISBN：</td>
                    <td>
                        <asp:FileUpload runat="server" ID="File_ISBN"  />
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">大类别：</td>
                    <td>
                        <asp:DropDownList runat="server" class="span2" Style="height: 25px" ID="Ddl_BLID" AutoPostBack="true" OnSelectedIndexChanged="Ddl_BLID_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">小类别：</td>
                    <td>
                        <asp:DropDownList runat="server" class="span2" Style="height: 25px" ID="Ddl_BSID"></asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">标价：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" TextMode="Number" class="span2" ID="Txt_BookPrice" />

                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">售价：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" TextMode="Number" class="span2" ID="Txt_BookMoney" />

                    </td>
                </tr>
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">字数：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" TextMode="Number" class="span2" ID="Txt_BookCount" />

                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">初始库存：</td>
                    <td>
                        <asp:TextBox runat="server" name="input" type="text" TextMode="Number" class="span2" ID="Txt_BookDeport" />

                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">书籍介绍：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea runat="server" style="width: 95%; height: 80px" id="Txt_BookDesc" ></textarea>

                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">作者介绍：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea runat="server" style="width: 95%; height: 80px" id="Txt_BookAuthorDesc"></textarea>

                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">推荐内容：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea runat="server" style="width: 95%; height: 80px" id="Txt_BookComm"></textarea>

                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">内容简介：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea runat="server" style="width: 95%; height: 80px" id="Txt_BookContent"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button runat="server" type="button" Text="确定" class="btn btn-info" ID="Btn_Save" OnClick="Btn_Save_Click" />
                        <asp:Button runat="server" type="button" Text="保存并继续" class="btn btn-info" ID="Btn_Save_Continue" OnClick="Btn_Save_Continue_Click" />
                        <asp:Button runat="server" type="button" Text="取消" class="btn btn-info" ID="Btn_Cancel" OnClientClick="Javascript:Close()" />
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
