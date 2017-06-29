<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ShowWork.aspx.cs" Inherits="ComputerBS.ShowWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <link href="css/mend.css" rel="stylesheet" />
    <div class="main w1000">
         <div class="container clearfix">
            <div class="cap-title" style="font-size:18px;color:#222">
                作品名称：<span class="big-text"><asp:Label runat="server" ID="EntriesName"></asp:Label></span>
                </div>
            <div class="cap-main clearfix">
                <div class="cap-left">
                    <div class="frame">
                        <asp:Literal runat="server" ID="ReplaceByIframe"></asp:Literal>                        
                    </div>
                    <div class="cap-vadio clearfix" style="padding-left:10px">
                        <div style="font-size:16px;margin-right:20px;">
                           <asp:Button ID="Btn_up" CssClass="btn-prev" runat="server" OnClick="Btn_up_Click" Text="查看上一个作品" />
                            <asp:Button ID="Btn_next" CssClass="btn-next" runat="server" OnClick="Btn_next_Click" Text="查看下一个作品" />
                        </div>
                        
                    </div>
                </div>
                <div class="cap-right">
                    <div class="cap-title fs18">作品信息</div>
                    <div class="cap-right-top">
                        <p class="fs14-c22">作者：<asp:Label runat="server" ID="EnrolName"></asp:Label></p>
                        <p class=" fs14-c22">区属：<asp:Label runat="server" ID="DistrictName"></asp:Label></p>
                        <p class="js-ad-time fs14-c22">学校：<asp:Label ID="SchoolName" runat="server"> </asp:Label></p>
                        <p class="fs14-c22">学段：<asp:Label ID="SchoolGroupName" runat="server"></asp:Label></p>
                        <p class="fs14-c22">学科：<asp:Label ID="SubjectName" runat="server"></asp:Label></p>
                        <p class="fs14-c22">上传时间：<asp:Label ID="EntriesTime" runat="server"></asp:Label></p>
                        <%-- <li class="t-ar"><a href="#" class="download-btn" runat="server" onclick="$('.alt-msg').show(60);$('body').css('overflow','hidden')">确认提交</a></li>--%>
                        <p class="fs14-c22"><asp:Label ID="AuditStatus" runat="server"></asp:Label></p>
                        <%-- <li class="t-ar"><a href="#" class="download-btn" runat="server" onclick="$('.alt-msg').show(60);$('body').css('overflow','hidden')">确认提交</a></li>--%><%-- <li class="t-ar"><a href="#" class="download-btn" runat="server" onclick="$('.alt-msg').show(60);$('body').css('overflow','hidden')">确认提交</a></li>--%>
                    

                       </div>
                    
                   </div>
                <div class="cap-footer clearfix">
                    <ul runat="server" id="pingshen">
                        <li><span class="fs14-c22">作品得分：</span><input class="remark-text" runat="server" id="Score" type="text" name="name" value=" " /></li>
                        <li><span class="fs14-c22">评语：</span></li>
                        <li>
                            <textarea class="remark-box" runat="server" id="Comment"></textarea>
                        </li>
                       <%-- <li class="t-ar"><a href="#" class="download-btn" runat="server" onclick="$('.alt-msg').show(60);$('body').css('overflow','hidden')">确认提交</a></li>--%>
                        <li class="t-ar">
                            <asp:Button ID="Btn_Submit" runat="server" class="download-btn" OnClick="Btn_Submit_Click" Text="确认提交" />
                            
                    </ul>
                    <ul>
                        <li class="review-list">
                            <dl runat="server" id="pingshen1">
                                <dt>
                                    <img src="Image/bussiness-man.png" alt="Alternate Text" />
                                    <span>评审人名字：<asp:Label ID="Lab_UserID1" runat="server" Text="1"></asp:Label></span>
                                </dt>
                                <dd class="pd20">评分：</dd>
                                <asp:Label ID="Lab_EnrolScore1" runat="server" Text="80"></asp:Label>
                                &nbsp;<p class="fs14-c22">审核时间：<asp:Label ID="EnrolTime1" runat="server"></asp:Label></p>
                                <dd>评语：<asp:Label ID="Lab_EnrolComment1" runat="server" Text="很好"></asp:Label>
                                </dd>
                            </dl>
                            <dl runat="server" id="pingshen2">
                                <dt>
                                    <img src="Image/bussiness-man.png" alt="Alternate Text" />
                                    <span>评审人名字：<asp:Label ID="Lab_UserID2" runat="server" Text="1"></asp:Label></span>
                                </dt>
                                <dd class="pd20">评分：</dd>
                                <asp:Label ID="Lab_EnrolScore2" runat="server" Text="80"></asp:Label>
                                &nbsp;<p class="fs14-c22">审核时间：<asp:Label ID="EnrolTime2" runat="server"></asp:Label></p>
                                <dd>评语：<asp:Label ID="Lab_EnrolComment2" runat="server" Text="很好"></asp:Label>
                                </dd>
                            </dl>
                            <dl runat="server" id="pingshen3">
                                <dt>
                                    <img src="Image/bussiness-man.png" alt="Alternate Text" />
                                    <span>评审人名字：<asp:Label ID="Lab_UserID3" runat="server" Text="1"></asp:Label></span>
                                </dt>
                                <dd class="pd20">评分：</dd>
                                <asp:Label ID="Lab_EnrolScore3" runat="server" Text="80"></asp:Label>
                                &nbsp;<p class="fs14-c22">审核时间：<asp:Label ID="EnrolTime3" runat="server"></asp:Label></p>
                                <dd>评语：<asp:Label ID="Lab_EnrolComment3" runat="server" Text="很好"></asp:Label>
                                </dd>
                            </dl>
                        </li>
                    </ul>
             </div>

             <div class="alt-msg">
                 <h1 class="alt-msg-title">评审成功！</h1>
                 <a href="ShowBestWorks.aspx" class="back-btn">返回评审页面</a>
                 <a href="#" class="next-btn ml40">评审下一作品</a>
                 <span class="clear-btn" onclick="$('.alt-msg').hide();$(body).css('overflow','auto')">&times;</span>
             </div>
            </div>
        </div>
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
