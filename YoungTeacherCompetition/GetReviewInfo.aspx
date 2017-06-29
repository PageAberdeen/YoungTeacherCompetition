<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="GetReviewInfo.aspx.cs" Inherits="ComputerBS.GetReviewInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <link href="css/mend.css" rel="stylesheet" />
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="main w1000">
                <div class="Expert-review-after mgt30 clearfix">
                    <h2 class="tit"><span>专家评审</span><span class="small"><asp:Label runat="server" ID="GroupType"></asp:Label>-<em>评选项目</em>-<asp:Label runat="server" ID="CateType"></asp:Label></span></h2>
                    <div class="Download_works">
                        <asp:Button runat="server" CssClass="down-btn" ID="DownFileY" Text="下载作品" OnClick="DownFileY_Click" />
                        <p>作品为压缩包文件</p>
                    </div>
                    <div class="Work_score ">
                        <table class="tab-review">
                            <thead>
                                <tr>
                                    <th>评分标准</th>
                                    <th>评分</th>
                                    <th>总分</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1.理想性，科学性，规范性</td>
                                    <td>
                                        <input type="text" runat="server" id="input1" />

                                    </td>
                                    <td>15分</td>
                                </tr>
                                <tr>
                                    <td>2.创新性，主题和表达新，内容原创，构思创意，想象及个性</td>
                                    <td>
                                        <input type="text" runat="server" id="input2" />

                                    </td>
                                    <td>30分</td>
                                </tr>
                                <tr>
                                    <td>3.艺术性</td>
                                    <td>
                                        <input type="text" runat="server" id="input3" />

                                    </td>
                                    <td>30分</td>
                                </tr>
                                <tr>
                                    <td>4.技术性</td>
                                    <td>
                                        <input type="text" runat="server" id="input4" />

                                    </td>
                                    <td>25分</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td></td>
                                    <td class="js-score">当前得分：<asp:Label runat="server" ID="CountSum"></asp:Label></td>
                                    <td>共计（100分）</td>
                                </tr>
                            </tfoot>
                        </table>
                        <div class="sub-grade"><em>作品评分：</em><span><%--<a href="javascript:;" class="btn_score" name="popbtn3">点击评分</a>--%><input id="tGetScorce" class="t1t" runat="server" type="text" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" /></span><span class="c_red"><i></i>分</span></div>
                    </div>
                    <div class="w633 fl xy_ldetail xy_ldetail2 xy_ldetail3">
                        <div class=" clearfix">
                            <div class="grade_wrap fl">
                                <input type="hidden" id="gradeVal2" value="0" />
                            </div>
                        </div>
                        <div class="stu_fbbox FaceBox" id="Smohan_FaceBoxbq">
                            <p style="font-size: 14px; color: red;">评语：</p>
                            <p>
                                <textarea name="textbq" class="z_textarea stu_textarea Smohan_text" cols="30" rows="10" id="Smohan_textbq" runat="server"></textarea>
                            </p>

                            <div class="qjf_facebox">
                                <p class="z_word_right mgt10 pdl5">
                                    <a href="javascript:;" class="faceicon_fb fl" name="bq"></a>
                                    <asp:Button runat="server" Text="提交评语" ID="ConfirmValue" OnClick="ConfirmValue_Click" />
                                </p>
                            </div>
                        </div>
                        <ul class="z_list_1">
                            <asp:Repeater runat="server" ID="CanGetReview">
                                <ItemTemplate>
                                    <li>
                                        <a href="#" class="z_l_img">
                                            <img src="Image/book.png" alt="" /></a>
                                        <div class="z_r_txt">
                                            <div class="clearfix">
                                                <em class="fr"><%#Eval("ScorceDate")%></em>
                                                <a href="#" class="z_name"><%#Eval("SetExpertName") %></a>
                                            </div>
                                            <p class="mgt10"><%#Eval("WExpertNote") %></p>
                                        </div>
                                    </li>
                                </ItemTemplate>

                            </asp:Repeater>
                        </ul>
                        <div class="turnPage t_c mgt20">
                            <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton>
                            <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>
                            <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">页尾</asp:LinkButton><br />
                            第<asp:Label ID="labPage" runat="server" Text="0"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server" Text="0"></asp:Label>页
                        </div>
                        <%--<div class="turnPage t_c mgt10">
                    <span><a href="#">首页</a><a href="#">上五页</a><a href="#">2</a><a href="#">3</a><a href="#">4</a><span class="on">5</span><a href="#">下五页</a></span><span class="mglr15 txt">共 100 页</span><span class="txt">去第</span><div class="mglr5 page_num_wrap t_l">
                        <input type="text" value="" class="num_text"><p class="anim">
                            <input type="button" value="确定" class="cfm"><span class="txt">页</span>
                        </p>
                    </div>
                </div>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="ConfirmValue" />--%>
            <asp:PostBackTrigger ControlID="DownFileY" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="dialogcont1" class="pd10" style="display: none;">
        <div class="dia_content">
            <label class=" clearfix">
                <em class="fl">作品评分：</em>
                <sapn class="pingf fl clearfix">
                <input id="GetSValue" type="text" /><input type="button" id="InsertBt" class="pingf_b fl" value="提交评分" onoff = "true" />
                </span>
            </label>
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
    <script>
        $(".tab-review").on("keyup", "input", function () {
            var sum = 0;
            $(".tab-review input[type='text']").each(function () {
                if (isNaN(parseInt($(this).val()))) {
                    return;
                }
                if ($(this).val() > parseInt($(this).parent().next().text())) {
                    alert('所给分数不能超过该项总分');
                   
                    return;
                }
                sum += parseInt($(this).val());
           
            });
            $('.js-score').text('当前得分：' + sum);
            $('.t1t').val(sum);
        })
    </script>
</asp:Content>
