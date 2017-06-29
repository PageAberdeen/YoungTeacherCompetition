<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ShowCase.aspx.cs" Inherits="ComputerBS.ShowCase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <asp:ScriptManager ID="sm_test" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="main w1000">
                <!--main.start-->
                <div class="w960 pdtb30 clearfix">
                    <dl class="cap_area mgt10 clearfix">
                        <dt>学段：</dt>
                        <dd id="type1">
                            <%--<asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="UpDate1">
                    <ContentTemplate>
                        <asp:Button ID="btnSelectAll" runat="server" Text="全部" CssClass="btnSelectBT " />
                        <asp:Button ID="btnSelectX" runat="server" Text="小学组" />
                        <asp:Button ID="btnSelectC" runat="server" Text="初中组" />
                        <asp:Button ID="btnSelectG" runat="server" Text="高中组" />
                        <asp:Button ID="btnSelectZ" runat="server" Text="中职组" />
                        <%--<a class="on" id="btnSelectAll" value="0" >全部</a>
                        <a id="btnSelectX" value="1"/>小学组</a>
                        <a id="btnSelectC" value="2"/>初中组</a>
                        <a id="btnSelectG" value="3"/>高中组</a>
                        <a id="btnSelectZ" value="4"/>中职组</a>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                            <div class="left" style="margin-top: 6px">
                                <%--<ul class="clearfix" id="menu">
                        <li style="display:inline"><asp:DropDownList</li>
                        <li style="display:inline"><a href="javascript:" value="0" class="on" onclick="Test1" runat="server">全部</a></li>
                        <li style="display:inline"><a href="javascript:" value="1" onclick="Test(1)" runat="server">小学组</a></li>
                        <li style="display:inline"><a href="javascript:" value="2" onclick="Test(2)" runat="server">初中组</a></li>
                        <li style="display:inline"><a href="javascript:" value="3" onclick="Test(3)" runat="server">高中组</a></li>
                        <li style="display:inline"><a href="javascript:" value="4" onclick="Test(4)" runat="server">中职组</a></li>
                    </ul>--%>


                                <asp:DropDownList runat="server" ID="ChangeType" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ChangeType_SelectedIndexChanged">
                                    <asp:ListItem Text="全部" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="小学组" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="初中组" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="高中组" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="中职组" Value="4"></asp:ListItem>
                                </asp:DropDownList>


                                <%--<script type="text/javascript">
                        $('#type1 a').bind('click', function () {
                            var avalue = $(this).attr('value');
                            $('#type1 a').removeClass('on');
                            $(this).addClass('on');
                            //th.action = "/*.do?name=" + id;
                            //$("#inputValue").val(avalue);
                            //$("#inputValue").attr("value", avalue);
                           <%-- var c = "<%=GetWorksInfo("+'avalue'+")%>";
                            alert(c);
                            alert(avalue);
                        });
                    </script>--%>
                            </div>
                        </dd>

                    </dl>

                    <div class="cap_wrap clearfix mgt10">

                        <div class=" clearfix" style="margin-top: -15px;">
                            <%--<asp:Repeater runat="server" ID="Works">
                    <ItemTemplate>
                        <div class="cap_list clearfix">
                            <div class="cap_picWrap" style="margin-top: 5px;">
                            <a href="#" class="cap_pic">
                                <img src="Image/pic1.jpg"></a><a class="cap_wordWrap" href="#">奇妙颜色</a>
                        </div>
                        <a href="#" class="fy_name">奇妙颜色</a><p class="cap_writer"><a href="#"><%#Eval("GroupName")%></a><i>|</i></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>--%>
                            <ul class="cap_list clearfix" id="list">
                                <asp:Repeater runat="server" ID="Works">
                                    <ItemTemplate>
                                        <li>
                                            <div class="cap_picWrap">
                                                <a href="ShowWork.aspx?wid=<%#Eval("WID")%>" class="cap_pic">
                                                    <img src="Image/pic1.jpg"></a><a class="cap_wordWrap" href="ShowWork.aspx?wid=<%#Eval("WID")%>"><%#Eval("WName")%></a></div>
                                            <a href="ShowWork.aspx?wid=<%#Eval("WID")%>" class="fy_name"><%#Eval("WName")%></a><p class="cap_writer"><a href="ShowWork.aspx?wid=<%#Eval("WID")%>"><%#Eval("WUserName")%></a><i>|</i></p>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            
                            <div class="turnPage t_c mgt20">
                                <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton>
                                <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>
                                <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>
                                <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">页尾</asp:LinkButton><br />
                                第<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server" Text="Label"></asp:Label>页
                            </div>
                        </div>
                    </div>
                </div>
                <!--main.end-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        var type1 = 0;
        var page = 1;
        //$('#type1 a').bind('click', function () {
        //    var avalue = $(this).attr('value');
        //    $('#type1 a').removeClass('on');
        //    $(this).addClass('on');
        //});

        function getpage(a, b) {
            page = a;
            ajaxlist();
        }
        function bu_to() {
            page = $('#num_text').val();
            ajaxlist();
        }
        $(document).ready(function () {
            document.onkeydown = function (e) {
                //捕捉回车事件
                var ev = (typeof event != 'undefined') ? window.event : e;
                if (ev.keyCode == 13) {
                    return false;
                }
            }
            ajaxlist();
        })
    </script>
    <script>
        $('.cap_list li:nth-child(4n)').css('margin-right', 0);
        $('.fy_list li:nth-child(4n)').css('margin-right', 0);
        $(".qjf_seleautodiv").SeleautoBox();//新版的下拉使用

        $(function () {
            $('.menuA').each(function () {
                var name = $(this).html();
                if ($.trim(name) == '活动')
                    $(this).addClass('on');
            });

            document.title = "柳州教育资源公共服务平台-活动";
        })

    </script>
    <!--  -->
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
