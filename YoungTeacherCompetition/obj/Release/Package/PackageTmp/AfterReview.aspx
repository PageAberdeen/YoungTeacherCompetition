<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="AfterReview.aspx.cs" Inherits="ComputerBS.AfterReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="main w1000">
	<div class="Expert-review-after mgt30 clearfix">
    	<h2 class="tit"><span>专家评审</span><span class="small"><asp:Label runat="server" ID="GroupType"></asp:Label>-<em>评选项目</em>-<asp:Label runat="server" ID="CateType"></asp:Label></span></h2>
    	<div class="Download_works" style="padding-top:23px">
             <%--Width="283px" Height="57px" Font-Size="24px" BackColor="#4a99eb"--%>
            <asp:Button runat="server" ID="DownFile" BorderStyle="Dotted" Width="283px" Height="57px" Font-Size="24px" BackColor="#4a99eb"  Text="下载作品" OnClick="DownFile_Click" />
        	<%--<a href="javascript:;" class="btn_load"><i></i>下载作品</a>--%>
            <%--<p>作品为压缩包文件</p>--%>
		</div> 
        <div class="Work_score mgb25">
        	<i class="gold"></i><em>最终得分：</em><span class="c_red"><i>99</i>分</span>
        </div>   
        <h2 class="tit"><span>专家评论</span></h2>
        <div class="review_list">
            <ul>
                <asp:Repeater runat="server" ID="AllReview">
                    <ItemTemplate>
                        <li class="clearfix">
                            <a href="javascript:;" class="fl">
                                <img src="../area/450200/images/liuzhou_active/head.png"></a>
                            <div class="content">
                                <h2><a href="javascript:;"><%#Eval("SetExpertID") %></a></h2>
                                <p><%#Eval("SetExpertName") %></p>
                                <span><em><%#Eval("ScorceDate") %></em></span>
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
        	<%--<ul>
            	<li class="clearfix">
                	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/head.png"></a>
                    <div class="content">
                    	<h2><a href="javascript:;">韩梅梅</a></h2>
                        <p>3月12日植树节到来之际，市第八小学少先队员们在辅导员老师的带领下，走出校门来到安康社区进行“保护环境，清理白色垃圾”环保主题教育实践活动活动。</p>
                        <span>今天<em>08:39:08 </em></span>
                    </div>
                </li>
                <li class="clearfix">
                	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/head.png"></a>
                    <div class="content">
                    	<h2><a href="javascript:;">韩梅梅</a></h2>
                        <p>3月12日植树节到来之际，市第八小学少先队员们在辅导员老师的带领下，走出校门来到安康社区进行“保护环境，清理白色垃圾”环保主题教育实践活动活动。</p>
                        <span>今天<em>08:39:08 </em></span>
                    </div>
                </li>
                <li class="clearfix">
                	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/head.png"></a>
                    <div class="content">
                    	<h2><a href="javascript:;">韩梅梅</a></h2>
                        <p>3月12日植树节到来之际，市第八小学少先队员们在辅导员老师的带领下，走出校门来到安康社区进行“保护环境，清理白色垃圾”环保主题教育实践活动活动。</p>
                        <span>今天<em>08:39:08 </em></span>
                    </div>
                </li>
                <li class="clearfix">
                	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/head.png"></a>
                    <div class="content">
                    	<h2><a href="javascript:;">韩梅梅</a></h2>
                        <p>3月12日植树节到来之际，市第八小学少先队员们在辅导员老师的带领下，走出校门来到安康社区进行“保护环境，清理白色垃圾”环保主题教育实践活动活动。</p>
                        <span>今天<em>08:39:08 </em></span>
                    </div>
                </li>
                <div class="turnPage t_c mgt10"><span><a href="#">首页</a><a href="#">上五页</a><a href="#">2</a><a href="#">3</a><a href="#">4</a><span class="on">5</span><a href="#">下五页</a></span><span class="mglr15 txt">共 100 页</span><span class="txt">去第</span><div class="mglr5 page_num_wrap t_l"><input type="text" value="" class="num_text"><p class="anim"><input type="button" value="确定" class="cfm"><span class="txt">页</span></p></div></div>
            </ul>--%>
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
        桂ICP备05004853号 桂公网安备 45020202000075号      </p>
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
	for(var i = 0; i < this.subPicLength; i++) {
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
		if(_this.iNum >= _this.subPicLength) {
			_this.iNum = 0;	
		}
		_this.tab();
	}, 3000);
};

Roll.prototype.tab = function () {
	_this.btn.eq(_this.iNum).addClass('active').siblings().removeClass	('active');
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
			if(_this.iNum >= _this.subPicLength) {
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
