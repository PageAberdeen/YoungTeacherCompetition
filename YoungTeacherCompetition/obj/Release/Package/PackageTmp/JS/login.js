// JavaScript Document
//登录浮层
var Login = {
	oBtn:$('#login_btn'),
	oMask: $('#m_mask'),
	oDialog:$('#m_login'),
	oClose: $('#m_close'),
	oTab: $('.logoCaseTab'), 
	oPwd: $('.passWord-case'),
	oSml: $('.smLoing-rect'),
	oSmc: $('.sm-case'),
	oSmi: $('.sm-invalid'),
	//弹出浮层
	toggleDialog: function () {
		var _this = this;
		var oInp =_this.oDialog.find(".text").eq(0);
		_this.oMask.stop().addClass("m_mask_show").animate({'opacity':0.7},'fast');
		_this.oDialog.stop().addClass("m_login_show").animate({'opacity':1,'top':'50%'},'slow');
		setTimeout(function () { oInp.focus()}, 350);
		_this.oPwd.show();
		_this.oSml.hide();
		_this.oSmc.show();
		_this.oSmi.hide();
		_this.oTab.removeClass('CaseTab2');
	},
	btnClick:function(){
		var _this = this;
		var oInp =_this.oDialog.find(".text").eq(0);
		_this.oBtn.on("click",function(event){
			_this.toggleDialog();
			event.stopPropagation();
		})
	},
	clickClose:function(){
		var _this = this;
		_this.oClose.on("mousedown",function(){
			_this.oMask.removeClass("m_mask_show").animate({'opacity':0},'fast');
			_this.oDialog.animate({'opacity':0,'top':'0%'},'slow',function(){_this.oDialog.removeClass("m_login_show")});
		})
	},
	documentClick:function(){
		var _this = this;
		$(document).on("click",function(event){ 
			if(event.which==3){
				 event.stopPropagation();
			}
			else{
				
			}
		})
		_this.oDialog.on("click",function(event){
			event.stopPropagation();
		})	
		_this.oMask.on("click",function(event){
			_this.oMask.removeClass("m_mask_show").stop().animate({'opacity':0},'fast');
			_this.oDialog.stop().animate({'opacity':0,'top':'0%'},'slow',function(){_this.oDialog.removeClass("m_login_show")});
		})	

	},
	//回车键登录
	bindEnterKey: function () { 
	var _this=this;
		var aInp =_this.oDialog.find(".text");
		var oSubmit =_this.oDialog.find(".submit").eq(0);
		
		for(var i =0; i < aInp.length; i++) {
			aInp.eq(i).on("keydown",function(ev){
				var oEvent = ev || event;
				if(oEvent.keyCode == 13) {
					oSubmit.click();
				}	
			})	
		}
	},
	//登录框焦点
	inputFocusBlur:function(){
		var _this=this;
		_this.oDialog.find('input[type!="button"]').on({
			focus:function(){
				$(this).parent().addClass('acitve');
			},
			blur:function(){
				$(this).parent().removeClass('acitve');
			}
		});	
	},
	//登录记住我
	rememberMe:function(){
		var _this=this;
		var oRemmberMe = _this.oDialog.find('.rememberMe');
		var oSpan = oRemmberMe.find('span');
		var onoff = true;
		oRemmberMe.click(function(){
			if(onoff){
				onoff = false;
				oSpan.stop().animate({marginRight:2},200);
				oSpan.parent().addClass('on');
			}else{
				onoff = true;
				oSpan.stop().animate({marginRight:17},200);
				oSpan.parent().removeClass('on');
			}
		})
		//点击关闭错误提示
		
		setTimeout(function () { _this.oDialog.find('.err-tips').hide()}, 3000);
		_this.oDialog.find('.err-tips .close').click(function(){
			$(this).parent().hide();
		})	
	},
	init: function () {
		this.btnClick();
		this.clickClose();
		this.documentClick();
		this.bindEnterKey();
		this.inputFocusBlur();
		this.rememberMe();
	},
	autoinit: function () {
		this.toggleDialog();
		this.clickClose();
		this.documentClick();
		this.bindEnterKey();
		this.inputFocusBlur();
		this.rememberMe();
	}
}


//登录框交互
function loginJH(obj,fn){
	var oLoginBox = $(obj);
	var oLoginTabTit = oLoginBox.find('.logoCaseTab');
	var oLoginTip = oLoginBox.find('.logoTips');
	var oLoginCont = oLoginBox.find('div[name="LoginRect"]');
	var oErrorTip = oLoginBox.find('.err-tips .close');
	var time1 = null;
	var time2 = null;
	var onoff = false;
	init();
	function init(){
		if(time1)clearTimeout(time1);
		if(time2)clearTimeout(time2);
		oLoginCont.eq(1).hide();
		oLoginCont.eq(1).find('.sm-case').show().removeClass('no-tips');;
		oLoginCont.eq(1).find('.sm-invalid').hide();
		oLoginCont.eq(0).fadeIn(300);
		oLoginTip.find('span').html('扫码登录更安全');
		onoff = false;
	}
	
	oLoginBox.hover(function(){oLoginTip.fadeIn(300)},function(){oLoginTip.fadeOut(300)});
	oLoginTabTit.click(function(){
		if($(this).hasClass('CaseTab2')){
			$(this).removeClass('CaseTab2');
			init();
		}else{
			$(this).addClass('CaseTab2');
			oLoginCont.eq(0).hide();
			oLoginCont.eq(1).fadeIn(300);
			oLoginTip.find('span').html('密码登录在这里');
			
			if(time1)clearTimeout(time1);
			time1 =  setTimeout(function(){
				oLoginCont.eq(1).find('.sm-case').addClass('no-tips');
				onoff = true;
			},5000);
		}
	});
	oLoginCont.eq(1).find('.sm-case').hover(function(){
		if(!onoff)return false;
		$(this).removeClass('no-tips');
	},function(){
		if(!onoff)return false;
		$(this).addClass('no-tips');
	});
	
	oErrorTip.click(function(){
		$(this).parent().hide();
	})
	
}

//仿京东
//规则6到10位的单数字 单字母均为弱
//11到20位的单数字 单字母均为中
//字母,数字,特殊字符中,任意2中混合6-10位 强度中
//字母,数字,特殊字符中,任意2中混合11-20位 强度强
//字母,数字.特殊字符.3中混合 6-20位 强度强
function checkPwdStrong(bindName) { 
	$(bindName).keyup(function(){
		var inpVal = $(this).val(); 
		var len =inpVal.length;
		if(/[\u4E00-\u9FA5\s]/.test(inpVal)) {
		    $(this).val($(this).val().replace(/[\u4E00-\u9FA5\s]+$/,""));
            return;
		}//去掉空格
		if(len<6||len>20) $(".stren_i").removeClass("on");//长度超出或长度不够没有样式

	    var hint = $(".stren_i");
	    if (inpVal.length >= 6) {
	        var level = null; 
	        var pattern_1 = /^.*([\W_])+.*$/i; //匹配任何非单词字符。等价于 '[^A-Za-z0-9_]'并且支持下划线_。 
		    var pattern_2 = /^.*([a-zA-Z])+.*$/i;//英文字母 
		    var pattern_3 = /^.*([0-9])+.*$/i;//数字 
		    var level = 0;
		    if (inpVal.length > 10) level++;
		    if (pattern_1.test(inpVal)) level++; 
		    if (pattern_2.test(inpVal)) level++; 
		    if (pattern_3.test(inpVal)) level++; 
		    if (level > 3) level = 3;
	        switch (level) { 
	            case 1: hint.eq(0).addClass("on").siblings().removeClass("on");break; //弱
	            case 2: hint.eq(1).addClass("on").prev().addClass('on');hint.eq(2).removeClass('on');break; //中
	            case 3: hint.addClass("on");break; //强
	            default: break; 
	        } 
	    }else{
	    	$(".stren_i").removeClass("on");
	    }
	})
}

