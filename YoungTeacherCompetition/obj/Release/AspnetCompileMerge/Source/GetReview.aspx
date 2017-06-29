<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="GetReview.aspx.cs" Inherits="ComputerBS.GetReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpData">
        <ContentTemplate>
            <div class="main w1000">
                <div class="Expert-review mgt30 clearfix">
                    <h2 class="tit"><span>专家评审</span></h2>
                    <div class="sel">
                        <em>作品类型筛选：</em>
                        <asp:DropDownList runat="server" ID="GetGroup" AutoPostBack="true" OnSelectedIndexChanged="GetGroup_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="CategoryIdList" AutoPostBack="true" OnSelectedIndexChanged="CategoryIdList_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%--<span class="qjf_seleautodiv" style="width: 146px; margin-right: 10px">
                    <span class="qjf_seleautocur">
                        <p>默认值请在a标签列表上加class="active"</p>
                        <input type="hidden" class="selRes" value="1" />
                    </span>
                    <span class="qjf_seleautodrop" style="width: 106px;">
                        <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#" value="2">第2个选项</a> <a href="#" value="3">第3个选项</a> <a href="#" class="active" value="4">第4个选项</a> <a href="#" value="5">第5个选项</a> <a href="#" value="6">第6个选项</a> <a href="#" value="7">第7个选项</a> <a href="#" value="8">第8个选项</a>
                    </span>
                </span>
                <span class="qjf_seleautodiv" style="width: 146px; margin-right: 10px">
                    <span class="qjf_seleautocur">
                        <p>默认值请在a标签列表上加class="active"</p>
                        <input type="hidden" class="selRes" value="1" />
                    </span>
                    <span class="qjf_seleautodrop" style="width: 106px;">
                        <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#" value="2">第2个选项</a> <a href="#" value="3">第3个选项</a> <a href="#" class="active" value="4">第4个选项</a> <a href="#" value="5">第5个选项</a> <a href="#" value="6">第6个选项</a> <a href="#" value="7">第7个选项</a> <a href="#" value="8">第8个选项</a>
                    </span>
                </span>
                <span class="qjf_seleautodiv" style="width: 146px; margin-right: 10px">
                    <span class="qjf_seleautocur">
                        <p>默认值请在a标签列表上加class="active"</p>
                        <input type="hidden" class="selRes" value="1" />
                    </span>
                    <span class="qjf_seleautodrop" style="width: 106px;">
                        <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#" value="2">第2个选项</a> <a href="#" value="3">第3个选项</a> <a href="#" class="active" value="4">第4个选项</a> <a href="#" value="5">第5个选项</a> <a href="#" value="6">第6个选项</a> <a href="#" value="7">第7个选项</a> <a href="#" value="8">第8个选项</a>
                    </span>
                </span>
                <span class="qjf_seleautodiv" style="width: 146px; margin-right: 10px">
                    <span class="qjf_seleautocur">
                        <p>默认值请在a标签列表上加class="active"</p>
                        <input type="hidden" class="selRes" value="1" />
                    </span>
                    <span class="qjf_seleautodrop" style="width: 106px;">
                        <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#" value="2">第2个选项</a> <a href="#" value="3">第3个选项</a> <a href="#" class="active" value="4">第4个选项</a> <a href="#" value="5">第5个选项</a> <a href="#" value="6">第6个选项</a> <a href="#" value="7">第7个选项</a> <a href="#" value="8">第8个选项</a>
                    </span>
                </span>--%>
                    </div>
                    <ul>
                        <asp:Repeater runat="server" ID="GetDataView">
                            <ItemTemplate>
                                <li class="clearfix">
                                    <div class="grade fr">
                                        <p>你的打分：<em><%#Eval("ScorceNub") %></em></p>
                                        <p class="c_red">最终得分：<em>90</em></p>
                                    </div>
                                    <a href="javascript:;" class="fl">
                                        <img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
                                    <div class="introduction">
                                        <h2 class="b_tit"><a href="javascript:;"><%#Eval("WName") %></a></h2>
                                        <p class="group"><span><%#Eval("GroupName") %></span><span>评选项目</span><span><%#Eval("CategoryName") %><span></p>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--<li class="clearfix">
                            <div class="grade fr">
                                <p>你的打分：<em>80</em></p>
                                <p class="c_red">最终得分：<em>90</em></p>
                            </div>
                            <a href="javascript:;" class="fl">
                                <img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
                            <div class="introduction">
                                <h2 class="b_tit"><a href="javascript:;">创意三维设计（维飞机）</a></h2>
                                <p class="group"><span>小学组</span><span>评选项目</span><span>电脑绘画<span></p>
                            </div>
                        </li>
                        <li class="clearfix">
                            <div class="grade fr">
                                <p>你的打分：<em>80</em></p>
                                <p class="c_red">最终得分：<em>90</em></p>
                            </div>
                            <a href="javascript:;" class="fl">
                                <img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
                            <div class="introduction">
                                <h2 class="b_tit"><a href="javascript:;">创意三维设计（维飞机）</a></h2>
                                <p class="group"><span>小学组</span><span>评选项目</span><span>电脑绘画<span></p>
                            </div>
                        </li>
                        <li class="clearfix">
                            <div class="grade fr">
                                <p>你的打分：<em>80</em></p>
                                <p class="c_red">最终得分：<em>90</em></p>
                            </div>
                            <a href="javascript:;" class="fl">
                                <img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
                            <div class="introduction">
                                <h2 class="b_tit"><a href="javascript:;">创意三维设计（维飞机）</a></h2>
                                <p class="group"><span>小学组</span><span>评选项目</span><span>电脑绘画<span></p>
                            </div>
                        </li>
                        <li class="clearfix">
                            <div class="grade fr">
                                <p>你的打分：<em>80</em></p>
                                <p class="c_red">最终得分：<em>90</em></p>
                            </div>
                            <a href="javascript:;" class="fl">
                                <img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
                            <div class="introduction">
                                <h2 class="b_tit"><a href="javascript:;">创意三维设计（维飞机）</a></h2>
                                <p class="group"><span>小学组</span><span>评选项目</span><span>电脑绘画<span></p>
                            </div>
                        </li>--%>
                    </ul>
                    <div class="turnPage">
                        <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton>
                        <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>
                        <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>
                        <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">页尾</asp:LinkButton><br />
                        第<asp:Label ID="labPage" runat="server" Text="0"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server" Text="0"></asp:Label>页
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
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
