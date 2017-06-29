<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ShowBestWorks.aspx.cs" Inherits="ComputerBS.ShowBestWorks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <link href="css/mend.css" rel="stylesheet" />
    <%-- <ContentTemplate>--%>
       <%-- <ContentTemplate>--%>
            <div class="main w1000">
                <ul class="menu-box clearfix">
                     <li><span class="menu-box-title">区属：</span><asp:DropDownList ID="DropList_District" runat="server" class="menu-box-select" >
                         </asp:DropDownList>
                     </li>
                     <li><span class="menu-box-title">学校：</span><asp:DropDownList ID="DropList_School" runat="server" class="menu-box-select">
                         </asp:DropDownList>
                     </li>
                     <li><span class="menu-box-title">学段：</span><asp:DropDownList ID="DropList_SchoolGroup" runat="server" class="menu-box-select">
                         </asp:DropDownList>
                     </li>
                     <li><span class="menu-box-title">学科：</span><asp:DropDownList ID="DropList_Subject" runat="server" class="menu-box-select">
                         </asp:DropDownList>
                     </li>
                     <li><span class="menu-box-title">状态：</span><asp:DropDownList ID="DropList_AuditStatus" runat="server" class="menu-box-select">
                         <asp:ListItem>全部</asp:ListItem>
                         <asp:ListItem Value="1">已审核</asp:ListItem>
                         <asp:ListItem Value="0">未审核</asp:ListItem>
                         </asp:DropDownList>
                     </li>
                     <li>
                         <input type="text" runat="server" id="inputtext" name="search" value=" " class="inp"/><input class="button blue" id="names" runat="server"  value="搜索" type="button" style="height:29px;cursor:pointer;"/>
                     </li>
                    <li><asp:Button ID="But_outdata" class="download-btn" runat="server" OnClick="But_outdata_Click" Text="导出数据" />
                     </li>
                 </ul>
                <div>
                    <br />
                   </div>                                
            </div>

    
                           
        
        <asp:GridView ID="GridViewData" CssClass="content" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridViewData_PageIndexChanging" OnRowDataBound="GridViewData_RowDataBound">
                            <Columns >
                                <asp:BoundField DataField="EnrollID" HeaderText="序号" >
                                    <ItemStyle  />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFormatString="ShowWork.aspx?EnrollID={0}" HeaderText="评奖作品" DataNavigateUrlFields="EnrollID" DataTextField="EntriesName" >
                                <HeaderStyle Width="300px" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="EnrolName" HeaderText="作者" >
                                    <ItemStyle  />
                                </asp:BoundField>
                                <asp:BoundField DataField="DistrictName" HeaderText="区属">
                                    <ItemStyle  />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolName" HeaderText="学校" >
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolGroupName" HeaderText="学段" >
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubjectName" HeaderText="学科" />
                                <asp:BoundField DataField="EntriesTime" HeaderText="上传时间" />
                                <asp:BoundField DataField="EnrolScore" HeaderText="市级得分" />
                                <asp:BoundField DataField="AuditStatus" HeaderText="状态" />
                                <asp:BoundField DataField="EnrolTime" HeaderText="审核时间" />
                                                               
                            </Columns>
                            <RowStyle HorizontalAlign="Center"></RowStyle>
                            <HeaderStyle  />
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
