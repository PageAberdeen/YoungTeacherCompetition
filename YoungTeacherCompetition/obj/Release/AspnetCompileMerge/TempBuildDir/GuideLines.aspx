<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="GuideLines.aspx.cs" Inherits="ComputerBS.GuideLines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="main w1000">
        <div class="works_upload mgt30 clearfix">
            <h2 class="tit"><span>报名操作步骤</span></h2>
            <div class="">
                <div class="video-content">
                    <img src="Image/vLoding.gif" alt="报名操作步骤加载图" />
                </div>
            </div>
            <h2 class="tit"><span>评审步骤</span></h2>
            <div class="">
                <div class="video-content">
                    <img src="Image/loding.gif" alt="报名操作步骤加载图"  />
                </div>
            </div>
            <h2 class="tit"><span>微课视频转码工具及参数设定</span></h2>
            <div class="">
                <div class="img-content">
                    <img src="Image/qescape.gif" alt="报名操作步骤加载图" style="width:100%" />
                </div>
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
