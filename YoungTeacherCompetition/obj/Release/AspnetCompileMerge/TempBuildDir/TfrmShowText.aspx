<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="TfrmShowText.aspx.cs" Inherits="ComputerBS.TfrmShowText" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="frame">
         <asp:Literal runat="server" ID="ReplaceByIframe"></asp:Literal>
    </div>

    <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/btnToggle.js"></script>
    <div class="g_footer" data="widgets/portal/portal_template/views/commonfooter.php">
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
                <a href="http://www.cnzz.com/stat/website.php?web_id=1256284353" target="_blank" title="站长统计">站长统计</a>&nbsp;|
		<a href="http://lzyun.doule.net/index.php?r=portal/support/help&amp;type=1&amp;fenlei=1">帮助中心</a>
            </div>
        </div>
    </div>
</asp:Content>
