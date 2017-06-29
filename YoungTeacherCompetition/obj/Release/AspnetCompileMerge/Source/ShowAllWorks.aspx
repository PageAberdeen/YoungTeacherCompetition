<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ShowAllWorks.aspx.cs" Inherits="ComputerBS.ShowAllWorks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <link href="css/mend.css" rel="stylesheet" />
    <%--<asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpDatePanel1">--%>
       <%-- <ContentTemplate>--%>
            <div class="main w1000">
                <div class="active_content mgt30 clearfix">
                    <div class="tab-top">
                        <table>
                            <tr>
                                <td>选择类型：</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="GetGroup" OnSelectedIndexChanged="GetGroup_SelectedIndexChanged" AutoPostBack="true" Width="80px"></asp:DropDownList></td>
                                <%--<td><asp:TextBox runat="server"></asp:TextBox></td>--%>
                                <td>请选择活动：</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="CategoryIdList"></asp:DropDownList></td>
                                <%--<td><asp:TextBox runat="server"></asp:TextBox></td>--%>
                                <td>是否评审：</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="SelectReview">
                                        <asp:ListItem Text="请选择" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="已评审" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="未评审" Value="0"></asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>选择序号:</td>
                                <td><asp:TextBox runat="server" ID="StartText" Width="30px"></asp:TextBox>-<asp:TextBox runat="server" ID="StopText"  Width="30px"></asp:TextBox></td>
                                <td><asp:Button runat="server" ID="Select" Text="查询" OnClick="Select_Click" Width="100px" /></td>
                                <td><%--<asp:LinkButton runat="server" ID="CheckDown" Text="下载选中" OnClick="CheckDown_Click" Visible="false";></asp:LinkButton>--%></td>
                                <td><a href="AllReview.aspx" runat="server">评审作品</a></td>
                            </tr>
                        </table>
                    </div>
                    <div class="tab-main">
                        <%--CssClass="js-table"--%>
                        <asp:GridView ID="GridViewData" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCreated="GridViewData_RowCreated" AllowSorting="True" OnPageIndexChanging="GridViewData_PageIndexChanging"  OnRowDataBound="GridViewData_RowDataBound" DataKeyNames="WID" OnRowCommand="GridViewData_RowCommand" >
                            <Columns>
                               <%-- <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckThis" onclick="javascript:CCA(this);" runat="server" />
                                    </ItemTemplate>
                                    <ControlStyle Width="30px"></ControlStyle>
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="WID" HeaderText="作品编号" ItemStyle-Width="80px">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="WName" HeaderText="作品名称" ItemStyle-Width="120px">
                                    <ItemStyle Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GroupName" HeaderText="学段" ItemStyle-Width="120px">
                                    <ItemStyle Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CategoryName" HeaderText="活动名称" ItemStyle-Width="150px">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                 <asp:ButtonField ButtonType="Button" HeaderText="下载" Text="下载" CommandName="DownSingleFile" ItemStyle-Width="80px" />
                                <asp:BoundField DataField="bz" HeaderText="状态" ItemStyle-Width="80px">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFormatString="ShowWork.aspx?wid={0}" HeaderText="操作" Text="审核" DataNavigateUrlFields="WID" ItemStyle-Width="80px">
                                    <ItemStyle Width="80px" Font-Italic="True" ForeColor="Red" />
                                </asp:HyperLinkField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center"></RowStyle>
                            <HeaderStyle Width="80px" />
                            <PagerTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="center">第<asp:Label ID="lblPageIndex" runat="server" Text='<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>'></asp:Label>页
                            &nbsp;共<asp:Label ID="lblPageCount" runat="server" Text='<%#((GridView)Container.Parent.Parent).PageCount %>'></asp:Label>页
                            &nbsp;每页<asp:Label ID="Label1" runat="server" Text='<%#((GridView)Container.Parent.Parent).PageSize %>'></asp:Label>条
                            &nbsp;<asp:LinkButton Text="首页" ID="btnFirst" runat="server" CausesValidation="false"
                                CommandArgument="First" CommandName="Page" />
                                            &nbsp;<asp:LinkButton Text="上一页" ID="btnPre" runat="server" CausesValidation="false"
                                                CommandArgument="Prev" CommandName="Page" />
                                            &nbsp;<asp:LinkButton Text="下一页" ID="btnNext" runat="server" CausesValidation="false"
                                                CommandArgument="Next" CommandName="Page" />
                                            &nbsp;<asp:LinkButton Text="尾页" ID="btnLast" runat="server" CausesValidation="false"
                                                CommandArgument="Last" CommandName="Page" />
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
       <%-- </ContentTemplate>
        <Triggers>
           <asp:PostBackTrigger ControlID="CheckDown" />
        </Triggers>
    </asp:UpdatePanel>--%>
    <div class="g_footer" data="widgets/portal/portal_template/views/commonfooter.php">
        <div class="m_wrap clearfix">
            <div class="copyright fl">
                <p class="f14">
                    技术运营支持：<a href="#" class="linkc" target="_blank">广西迈联科技有限公司</a>    主办方：柳州市教育局 柳州市教育科学研究所  柳州市电化教育站         
                </p>
                <p class="mgt10">
                    Copyright©2017 lzyun.doule.net All rights reserved&nbsp;&nbsp;&nbsp;&nbsp;
        桂ICP备05004853号 桂公网安备 45020202000075号     
                </p>
            </div>


            <div class="bot_nav f14 fr">
                <a href="http://www.cnzz.com/stat/website.php?web_id=1256284353" target="_blank" title="站长统计">站长统计</a>&nbsp;|
		<a href="http://lzyun.doule.net/index.php?r=portal/support/help&amp;type=1&amp;fenlei=1">帮助中心</a>
            </div>
        </div>
    </div>
</asp:Content>
