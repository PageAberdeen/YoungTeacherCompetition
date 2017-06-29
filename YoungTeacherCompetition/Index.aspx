<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ComputerBS.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="main w1000">
        <div class="active_content mgt30 clearfix">
            <div class="left fl">
                <h2 class="tit"><a href="javascript:;" class="more fr">更多</a><span>活动动态</span></h2>
                <div class="wrap clearfix">
                    <div class="slide fl">
                        <%--<asp:Repeater runat="server" ID="pic">
                                <ItemTemplate>
                                    <a href="#"><img src="<%#Eval("PicPath")%>"/></a>
                                </ItemTemplate>
                            </asp:Repeater>--%>
                        <ul class="pic" id="Pic" runat="server">
                            <%--<li><a href="javascript:;">
                                    <img src="../Image/3.jpg"/></a></li>
                                <li><a href="javascript:;">
                                    <img src="../Image/4.jpg"/></a></li>--%>
                            <!--<li><a href="javascript:;"><img src="../area/450200/images/liuzhou_active/slide.png"></a></li>-->
                        </ul>
                        <ol class="btn">
                            <%-- <a href="javascript:;" class="active"></a>
                                                    <a href="javascript:;"></a>
                                                    <a href="javascript:;"></a>--%>
                        </ol>
                    </div>
                    <div class="QA fl">
                        <h5 class="tit"><a href="Active.aspx">第十七届中学青年教师汇报课评比活动</a></h5>
                       
                        <div>
                            <a href="index.php?r=activity/Activityhdpb/zhinan">&nbsp;&nbsp;&nbsp;&nbsp;为了更好地实施柳州教育改革工程，探索课堂教学有效性策略，努力造就一支业务精湛、高素质的专业化教师队伍，进一步引导广大青年教师自觉加强学习，提高教学水平，促进我市中学青年教师专业成长，经研究，柳州市教育局、柳州市总工会将联合举行柳州市第十七届中学青年教师汇报课评比活动</a>
                        </div>
                        
                        <p><i></i><em></em>2017年6月1日</p>
                        <%--<asp:Repeater runat="server" ID="ActiveInfoList">
                            <ItemTemplate>
                                <asp:Label runat="server" CssClass="fr"><%#Eval("InfoTime") %></asp:Label><a href="ShowInfo.aspx?ID=<%#Eval("InfoID") %>"><%#Eval("InfoText") %></a>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                        <ul>
                                <%--<li><span class="fr">03-07</span><a href="javascript:;">关于举办第十七届全国中小学电脑制作活动培训班的通知</a></li>--%>
                                <%--<li><span class="fr">06-07</span><a href="Notice.aspx">【参赛教师条件】参赛教师参加本次活动必备条件</a></li>--%>
                                <li><span class="fr">06-07</span><a href="javascript:;">【比赛办法】比赛流程及细则</a></li>
                                <li><span class="fr">03-07</span><a href="index.php?r=activity/Activityhdpb/set">【评分要求】评分要素及格式要求</a></li>
                                <%--<li><span class="fr">03-07</span><a href="javascript:;">关于举办第十六届电脑制作活动夏令营的通知</a></li>--%>
                            </ul>
                    </div>
                </div>
            </div>
            <div class="right fr">
                <h2 class="tit"><i></i>参赛条件</h2>
                <p>1.年龄不超过40岁（即1977年1月1日以后出生）。</br>
                    2.有三年以上教龄，师德好，教学能力强的教师。</br>
                    3.柳州市各中学正式教师。</br>
                    4.在历届“柳州市青年教师汇报课评比活动”中已获一、二等奖的教师不再参加。</br>
                </p>
                <p>欢迎广大教师用户对微课作品进行点赞和评论。</p>
            </div>
        </div>
        <div name="tab1">
            <div class="cap_tit special" name="tabTit"><h2 class="on"><a href="#">活动帮助视频</a></h2></div>
            <ul class="fy_list clearfix" name="tabCon" >
						                <li>
                    <a href="index.php?r=activity/Activityhdpb/pinxuaninfo&amp;id=188" class="fy_pic">
                        <dl>
                            <dt><img src="Image/loding.gif"></dt>
                        </dl>
                    </a>
                    <a href="index.php?r=activity/Activityhdpb/pinxuaninfo&amp;id=188" class="fy_name">报名操作步骤微视频</a>
                </li>
			                <li>
                    <a href="index.php?r=activity/Activityhdpb/pinxuaninfo&amp;id=83" class="fy_pic">
                        <dl>
                            <dt><img src="Image/loding.gif"></dt>
                        </dl>
                    </a>
                    <a href="index.php?r=activity/Activityhdpb/pinxuaninfo&amp;id=83" class="fy_name">微课视频转码</a>
                </li>
			                <li style="margin-right: 0px;">
                    <a href="index.php?r=activity/Activityhdpb/pinxuaninfo&amp;id=150" class="fy_pic">
                        <dl>
                            <dt><img src="Image/loding.gif"></dt>
                        </dl>
                    </a>
                    <a href="index.php?r=activity/Activityhdpb/pinxuaninfo&amp;id=150" class="fy_name">评审步骤微视频</a>
                </li>
							
            </ul>
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
    <script src="../JS/jquery.js"></script>
    <script src="../JS/fun.js"></script>
        <script>
            $(".qjf_seleautodiv").SeleautoBox();
        </script>
    <script>
        //图片轮播 start
        var Roll = function () {
            this.wrap = $('.slide');
            this.pic = $('.slide .pic');
            this.subPicWidth = $('.slide .pic img:first').width();
            this.subPicLength = $('.slide .pic img').length;
            this.btnWrap = $('.slide .btn');
            this.iNum = 0;
            this.timer = '';

            this.init = function () {
                this.setBtn();
                this.setPicWidth();
                this.picTab();
                this.autoPlay();
                this.startStop();
            };
        }

        Roll.prototype.setBtn = function () {
            for (var i = 0; i < this.subPicLength; i++) {
                this.btnWrap.append('<a href="javascript:void(0)"></a>');
            }
            this.btn = this.btnWrap.find('a');
            this.btn.eq(0).addClass('active');

            //居中
            this.btnWrap.css('right', (this.wrap.width() - this.btnWrap.width()) / 2 - 3);
        };

        Roll.prototype.setPicWidth = function () {
            this.pic.css('width', this.subPicWidth * this.subPicLength);
        };

        Roll.prototype.picTab = function () {
            _this = this;
            this.btn.mouseover(function () {
                _this.iNum = $(this).index();
                _this.tab();
            });
        };

        Roll.prototype.autoPlay = function () {
            _this = this;
            _this.timer = setInterval(function () {
                _this.iNum++;
                if (_this.iNum >= _this.subPicLength) {
                    _this.iNum = 0;
                }
                _this.tab();
            }, 3000);
        };

        Roll.prototype.tab = function () {
            _this.btn.eq(_this.iNum).addClass('active').siblings().removeClass('active');
            _this.pic.stop(true, false).animate({
                'left': -_this.subPicWidth * _this.iNum
            });
        };

        Roll.prototype.startStop = function () {
            _this = this;
            this.wrap.mouseover(function () {
                clearInterval(_this.timer);
            }).mouseout(function () {
                _this.timer = setInterval(function () {
                    _this.iNum++;
                    if (_this.iNum >= _this.subPicLength) {
                        _this.iNum = 0;
                    }
                    _this.tab();
                }, 3000);
            });
        };

        (function () {
            var roll = new Roll();
            roll.init();

            getInfo()
        })();

        //获取用户信息
        function getInfo() {
            var currentHost = 'http://' + window.location.host;
            var clientPath = "http://lzyun.doule.net/index.php?r=portal/user/login&service=" + currentHost + "/UpFile.aspx";
            $.get(clientPath, function (data, status) {
                alert("Data: " + data + "nStatus: " + status);
            });
            //alert(currentHost);
        }
        //图片轮播 over

    </script>
</asp:Content>
