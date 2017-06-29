<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Active.aspx.cs" Inherits="ComputerBS.Active" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="main w1000">
            <div class="works_upload mgt30 clearfix">
                <h2 class="tit"><span>活动动态</span></h2>
                <%--<div class="active_content clearfix">
                    <asp:Repeater ID="ActiveInfoList" runat="server">
                        <ItemTemplate>
                            <asp:Label runat="server" CssClass="fr"><em class="year"><%#Eval("InfoYear") %></em><em class="time"><%#Eval("InfoTime") %></em></asp:Label><a class="body" href="ShowInfo.aspx?ID=<%#Eval("InfoID") %>"><%#Eval("InfoText") %></a>
                        </ItemTemplate>
                        
                    </asp:Repeater>
                </div>--%>
                <div class="public_content">
                <dl>
                    <dt>一、人员范围</dt>
                    <dd class="text1">全国中小学电脑制作活动 （简称“电脑活动”）的人员范围是：</dd>
                    <dd class="text2">全国小学、初中、高中（中职）在校学生。</dd>
                </dl>
                <dl>
                    <dt>二、项目设置</dt>
                    <dd class="text1">本届电脑活动内容分为“评选项目”、“创客项目”和“竞赛项目”。</dd>
                </dl>
                <dl>
                    <dt>三、“评选项目”项目设置、相关要求、评比指标及办法</dt>
                    <dd class="text1">评选项目”是指使用计算机创作、设计、制作的数字化作品。</dd>
                    <dd class="text2">（一）项目设置</dd>
                    <dd class="text1">小学组：1.电脑绘画2.电脑绘画（“和教育”专项）3.电子板报4.电脑艺术设计（生活创意设计）5.网页设计6.电脑动画7.电脑动画（健康教育专项）8.微视频（英语数码故事创作）9. 计算机程序设计（创意编程）
初中组：1.电脑绘画2.电脑绘画（“和教育”专项）3.电脑艺术设计（生活创意设计）4.网页设计5.电脑动画6.电脑动画（健康教育专项）7.电脑动画（“和教育”手机动漫）8.3D创意设计（创新未来设计）9.3D创意设计（创新三维设计）10.微视频（英语数码故事创作）11. 计算机程序设计（创意编程）</dd>
                    <dd class="text1">普通高中组：1.电脑艺术设计2.网页设计3.电脑动画（二维）4.电脑动画（三维）5.电脑动画（健康教育专项）6.电脑动画（“和教育”手机动漫）7.3D创意设计（创新未来设计）8.3D创意设计（创新三维设计）9.计算机程序设计 10.微视频(微电影)
中职组：1.电脑艺术设计2. 电脑动画（二维）3.电脑动画（三维）4.计算机程序设计</dd>
                    <dd class="text2">（二）相关要求</dd>
                    <dd class="text1">1.作品形态界定</dd>
                    <dd class="text1">（1）电脑绘画</dd>
                    <dd class="text1">①电脑绘画</dd>
                    <dd class="text1">运用各类绘画软件或图形、图像处理软件制作完成的作品。可以是主题性单幅画或表达同一主题的组画、连环画（建议不超过五幅）。</dd>
                    <dd><asp:LinkButton runat="server" Text="下载文件" OnClick="Unnamed_Click" ForeColor="Red"></asp:LinkButton></dd>
                </dl>
            </div>
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
        <script src="../common/js/jquery.js"></script>
        <script src="../common/js/fun.js"></script>
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
            })();
            //图片轮播 over

        </script>
</asp:Content>
