<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ShowInfo.aspx.cs" Inherits="ComputerBS.ShowInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="main w1000">
        <div class="active_content mgt30 clearfix">
            <div>
                <%--<asp:Label runat="server" CssClass="public_tit" ID="LabelTitle">
                <%#Eval("InfoText") %>
                </asp:Label>--%>
                <%#Eval("InfoText") %>
            </div>
            
            <asp:Label runat="server" ID="Text">
                <%#Eval("InfoValue") %>
            </asp:Label>
        </div>
    </div>
    <div class="g_footer">
        <div class="m_wrap clearfix">
            <div class="copyright fl">
                <p class="f14">
                    技术运营支持：<a href="http://www.huijiaoyun.com/" class="linkc" target="_blank">广西迈联科技有限公司</a>    主办方：柳州市教育局 柳州市教育科学研究所  柳州市电化教育站         
                </p>
                <p class="mgt10">
                    Copyright©2017 lzyun.doule.net All rights reserved&nbsp;&nbsp;&nbsp;&nbsp;
        桂ICP备05004853号 桂公网安备 45020202000075号     
                </p>
            </div>


            <div class="bot_nav f14 fr">
                <a href="#" target="_blank" title="站长统计">站长统计</a>&nbsp;|<a href="#">帮助中心</a>
            </div>
        </div>
    </div>
</asp:Content>
