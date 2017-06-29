<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="ComputerBS.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="600" border="0" align="center" cellpadding="1" cellspacing="0">
                <tr>
                    <td class="table_bgcolor" style="height: 138px">
                        <table width="100%" border="1" cellpadding="5" cellspacing="0" class="table_bordercolor">
                            <tr bgcolor="#e4e4e4">
                                <td class="table_title" style="height: 22px"><strong><font color="red">发生问题：</font></strong></td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td height="22">
                                                <asp:Label ID="lblMsg" runat="server" Width="100%" ForeColor="Red" ></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 22px">
                                    <div align="center">
                                        <asp:Button ID="Button1" Text="返 回" Style="width: 100p" runat="server" OnClick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
