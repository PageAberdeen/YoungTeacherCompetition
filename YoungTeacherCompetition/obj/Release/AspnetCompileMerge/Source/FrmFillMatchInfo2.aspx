
<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="FrmFillMatchInfo2.aspx.cs" Inherits="ComputerBS.FrmFillMatchInfo2"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server" >
    <%--<form id="form1" runat="server">--%>
    <div class="content">
        <div class="modal" runat="server" id="showMyInfo" style="display:none">
            <div class="moadl-dialog" >
                <ul>
                    <li>该申报账号所属城区/区县为:<span class="msg-box js-county"><%=DistrictName2%></span></li>
                    <li>该申报账号所属学校为:<span class="msg-box js-school"><%=SchoolName2%></span></li>
                    <li class="danger-tip">*请认真核实申报人账户信息如有误差请致电：</li>
                    <li class="msg-box">13633345678</li>
                    <li>
                        <%--<input type="button" name="name" runat="server" onclick="Btn_MyInfoOK_Click" class="btn clear-modal" value="信息确认无误"/>--%>
                        <p><asp:Button ID="BtnMyInfoOK" runat="server" OnClick="Btn_MyInfoOK_Click" Text="信息确认无误" class="btn clear-modal"  /></p>
         
                    </li>
                </ul> 
            </div>
        </div>
        <div class="msg-content">
           <p><asp:Label ID="Label1" runat="server" Text="申报人填写参赛信息" class="msg-title"></asp:Label></p>
           <p><span class="regForm-item-tit">学校：</span><asp:DropDownList runat="server" ID="DropList_School" AutoPostBack="false" class="select-box mb20"></asp:DropDownList><br/></p>
           <p><span class="regForm-item-tit">姓名：</span><asp:TextBox ID="Tbx_Name" runat="server" class="mb20"></asp:TextBox><br/></p>
            <p> <span class="regForm-item-tit">性别：</span><asp:DropDownList runat="server" ID="DropList_Sex" AutoPostBack="false" class="select-box mb20" >
            <asp:ListItem Value="1">男</asp:ListItem>
            <asp:ListItem Value="2">女</asp:ListItem>
        </asp:DropDownList></p>
      
       <p> <span class="regForm-item-tit">出生年月：</span><asp:TextBox ID="Tbx_Birthday" runat="server" class="mb20"></asp:TextBox></p>
       <p><span class="regForm-item-tit">职称：</span><asp:TextBox ID="Tbx_Title" runat="server" class="mb20"></asp:TextBox></p>
       <p><span class="regForm-item-tit">学科:</span> <asp:DropDownList runat="server" ID="DropList_Subject" AutoPostBack="false" class="select-box mb20"></asp:DropDownList></p>
        <p><span class="regForm-item-tit">任教年龄：</span><asp:TextBox ID="Tbx_WorkYear" runat="server" class="mb20" ></asp:TextBox></p>
        <p><span class="regForm-item-tit">联系电话：</span><asp:TextBox ID="Tbx_Tel" runat="server" class="mb20"></asp:TextBox></p>
        <p style="position:relative;height:30px;"><asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="保存报名信息" class="btn msg-btn"  />
            <asp:Button style="position:absolute;top:0;left:0;display:none;"  ID="Btn_Update" runat="server"  OnClick="Btn_Update_Click" Text="修改教师信息" class="btn msg-btn"  />
        </p>
        </div>
        
        
        <asp:GridView ID="GridViewData" CssClass="content" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridViewData_PageIndexChanging">
                            <Columns >
                                <asp:BoundField DataField="EnrollID" HeaderText="序号" >
                                    <ItemStyle  />
                                </asp:BoundField>
                                <asp:BoundField DataField="EnrolName" HeaderText="姓名" >
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EnrolSex" HeaderText="性别" >
                                    <ItemStyle  />
                                </asp:BoundField>
                                <asp:BoundField DataField="EnrolBirthday" HeaderText="出生年月">
                                    <ItemStyle  />
                                </asp:BoundField>
                                <asp:BoundField DataField="EnrolWorkYear" HeaderText="教龄" >
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EnrolTel" HeaderText="联系电话" >
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="EnrolTeacherTitle" HeaderText="职称" />
                                <asp:BoundField DataField="SubjectName" HeaderText="学科" />
                                <asp:BoundField DataField="SchoolName" HeaderText="所属学校" />
                                 <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton_Edit" Text="编辑" runat="server"  OnClick="updateEnroll"/>                               
                                <asp:LinkButton ID="LinkButton_delete" Text="删除" runat="server" OnClick="deleteEnroll"/>
                            </ItemTemplate>
                        </asp:TemplateField>                             
                               
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
    </div>
        
  <%--  </form>--%>
        <div class="g_footer" data="widgets/portal/portal_template/views/commonfooter.php">
        <div class="m_wrap clearfix">
            <div class="copyright fl">
                <p class="f14">
                    技术运营支持：<a href="#" class="linkc" target="_blank">广西迈联科技有限公司</a>    主办方：柳州市教育局 柳州市教育科学研究所  柳州市电化教育站         
                </p>
                <p class="mgt10">
                    Copyright?2017 lzyun.doule.net All rights reserved&nbsp;&nbsp;&nbsp;&nbsp;
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