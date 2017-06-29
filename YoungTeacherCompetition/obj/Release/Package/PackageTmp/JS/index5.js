// JavaScript Document
/*首页的自动播放动画*/
var indexAnimate = {
	onoffAnimate : supportCss3('animation'),
	init:function(){
		if(this.onoffAnimate){
			this.screenAnimate();
		}else{
			$('.trends-rect').FnManth('','','ul','li',6,3,6,true);
			indexAnimate.MantleFn();
			$('div[name="animate-rect"]').eq(3).find('.nummber').NumScroll(60,true);
		}
		this.bannerFn();
		$('div[name="animate-rect"]').eq(2).find('.allNum .nummber').NumScroll(36,true);
		$('div[name="animate-rect"]').eq(2).find('.roleNun .nummber').NumScroll(24,true)
	},
	bannerFn:function(){//banner动画
		var oBanner = $('.m_banner');
		var oLi = oBanner.find('ul').eq(0).find('li');
		var oPageLi = oBanner.find('ul').eq(1).find('li');
		var oPagePre = oBanner.find('.pre-btn');
		var oPageNext = oBanner.find('.next-btn');
		var inow = 0;
		var iold = 0;
		var Time = null;
		var Time2 = null;
		var onoff = true;
		
		bannerAniamte(0);
		
		if(oLi.length<=1)oPageLi.hide();
		into();
		
		oPagePre.click(function(){
			if(!onoff||oLi.length<=1)return false;
			onoff = false;
			inow--
			if(inow ==-1)inow = oLi.length - 1;
			bannerAniamte(inow,iold);
			iold = inow;
			return false;
		});
		
		oPageNext.click(function(){
			if(!onoff||oLi.length<=1)return false;
			onoff = false;
			inow++
			inow %=oLi.length;
			bannerAniamte(inow,iold);
			iold = inow;
			return false;
		});
		
		oPageLi.click(function(){
			if(!onoff||oLi.length<=1)return false;
			onoff = false;
			inow = $(this).index();
			bannerAniamte(inow,iold);
			iold = inow;
		});
		
		//当只有一张banner图的时候此处屏蔽
		oBanner.hover(function(){
			clearInterval(Time);
			oBanner.find(".banner_btn").stop().show();
		},function(){
			oBanner.find(".banner_btn").stop().hide();
			into();
			
		});
		
		//鼠标移上
		oBanner.mouseover(function(){
			clearInterval(oBanner.timer);
			oBanner.find("p").find("span").stop().fadeIn("slow");
		})
		function into(){
			Time = setInterval(function(){//自动播放
			if(!onoff||oLi.length<=1)return false;
			onoff = false;
			inow++
			inow %=oLi.length;
			bannerAniamte(inow,iold);
			iold = inow;
			},5000);
		}
		function bannerAniamte(inow,iold){
			oLi.find('p').hide();
			oLi.eq(inow).fadeIn(600,function(){
				$(this).find('p').each(function(){
					var _this=$(this);
					setTimeout(function(){_this.show();},300);
					addClassFn($(this));
				});
				if(Time2){clearTimeout(Time2)};
				Time2 = setTimeout(function(){onoff = true;},1000)
			});
			oPageLi.eq(iold)&&oPageLi.eq(iold).removeClass('active')
			oLi.eq(iold)&&oLi.eq(iold).fadeOut(500),
			oLi.eq(iold).find('p')&&oLi.eq(iold).find('p').each(function(){
				removeClassFn($(this));
			});
			oPageLi.eq(inow).addClass('active');
			oPageLi.eq(iold).removeClass('active');
		}
		
		function addClassFn(obj){
			obj.addClass('animated '+obj.attr('data-animateName'));
		}
		function removeClassFn(obj){
			obj.removeClass('animated '+obj.attr('data-animateName'));
		}
	},
	screenAnimate:function(){//随屏滚动动画
		var oScreenRect = $('div[name="animate-rect"]');
		var aAutoObj = [];
		var aT2 = [];
		var animate = [
			function(){//行一屏动画
				var aLi = oScreenRect.eq(0).find('li');
				aLi.each(function(){
					$(this).addClass('animated '+$(this).attr('data-animateName'));
				})
			},
			function(){//二屏动画
				var oLeft = oScreenRect.eq(1).find('.m_spaceHome');
				var oRight = oScreenRect.eq(1).find('.m_spaceNews');
				oLeft.addClass('animated fast '+oLeft.attr('data-animateName'));
				oRight.addClass('animated fast '+oRight.attr('data-animateName'));
				
				oRight[0].addEventListener('webkitAnimationEnd',function(){
					if(!$('.trends-rect').attr('onoff'))$('.trends-rect').FnManth('','','ul','li',6,3,6,true);
				},false);//空间动态的动画运动完了之后再执行列表向上滚；
				oRight[0].addEventListener('animationend',function(){
					if(!$('.trends-rect').attr('onoff'))$('.trends-rect').FnManth('','','ul','li',6,3,6,true)
				},false);
			},
			function(){//四屏动画
				var oLeft = oScreenRect.eq(2).find('.mantle');
				var oRight = oScreenRect.eq(2).find('.m_appJk');
				oLeft.addClass('animated fast '+oLeft.attr('data-animateName'));
				oLeft[0].addEventListener('webkitAnimationEnd',function(){
					if(!$('#mantle').attr('onoff'))indexAnimate.MantleFn()
				},false);//焦点图的入场动画完成之后再执行点击滚动
				oLeft[0].addEventListener('animationend',function(){
					if(!$('#mantle').attr('onoff'))indexAnimate.MantleFn()
				},false);//焦点图的入场动画完成之后再执行点击滚动
				//oRight.addClass('animated fast '+oRight.attr('data-animateName'));
			},
			function(){//三屏动画
			var oTith = oScreenRect.eq(3).find('.w_tit h2');
			var oTitp = oScreenRect.eq(3).find('.w_tit .other_p');
			oTith.addClass('animated '+oTith.attr('data-animateName'));
			oTitp.addClass('animated '+oTitp.attr('data-animateName'));
			oTith[0].addEventListener('webkitAnimationEnd',function(){
				$('div[name="animate-rect"]').eq(3).find('.nummber').NumScroll(60);
			},false);
			oTith[0].addEventListener('animationend',function(){
				$('div[name="animate-rect"]').eq(3).find('.nummber').NumScroll(60);
			},false);
			
			function otherscroll(){
				if(oScreenRect.eq(3).offset().top+oScreenRect.eq(1).height()/2-$(window).scrollTop()<$(window).height()){
					var oBotimg = oScreenRect.eq(3).find('.bot_img');
					var oBtn = oScreenRect.eq(3).find('.w_btn');
					var oCont = oScreenRect.eq(3).find('.w_cont').find("li");
					
					oBotimg.addClass('animated '+oBotimg.attr('data-animateName'))
					oBtn.addClass('animated '+oBtn.attr('data-animateName'))
					oCont.each(function(){
						$(this).addClass('animated '+$(this).attr('data-animateName'));
					})	
				}	
			}
			$(window).scroll(function(){
				otherscroll()
			})
				otherscroll()	
			}
		]
		setTimeout(function(){
			oScreenRect.each(function(i){//初始化
			if($(this).offset().top-$(window).scrollTop()<$(window).height()){
				var inum = oScreenRect.index($(this));
				aAutoObj.push($(this));
				animate[inum]&&animate[inum]();
				
			}
			aT2.push($(this).offset().top);
			})
			for(var i=0; i<aAutoObj.length; i++){
				aAutoObj[i].addClass('animateOn');
			}
		},300)
		$(window).scroll(function(){
			var inum = MoveNav($(window).scrollTop(),aT2);
			if($(window).scrollTop()/($(document).outerHeight()-$(window).height()-$(window).height()/2)>=0.8){
				oScreenRect.each(function(i){
				if(i>oScreenRect.length-1)return false;
				if(oScreenRect.eq(i).hasClass('animateOn'))return true;
					oScreenRect.eq(i).addClass('animateOn');
					animate[i]&&animate[i]();
				});
			}else{
				if(oScreenRect.eq(inum).hasClass('animateOn'))return false;
				oScreenRect.eq(inum).addClass('animateOn');
				animate[inum]&&animate[inum]();
			}
			
		});
	},
	MantleFn:function(){//成功展示动画
		$('#mantle').attr('onoff',true);
		var oCaseBox = $('#mantle');
		var oCaseul = oCaseBox.find('.pig_img');
		var oCaseLi = oCaseul.find('li');
		var oPrevBtn = oCaseBox.find('.prev');
		var oNextBtn = oCaseBox.find('.next');
		var iW = oCaseul.find('li').innerWidth(true);
		var ilen = oCaseul.find('li').length;
		var onOff = true;
		var oClick = oCaseBox.find('.pageList');
		var str = '';
		var iOld = 0;
		var iNow = 0;
		var timer = null;
		
		oCaseul.css({width:iW*ilen});
		
		if(ilen<=1)return false;
		var timer = null;
		init();
		oCaseBox.hover(function(){
			clearInterval(timer);
		},function(){
			init();
		})
		
		for(var i=0; i<ilen; i++){
			str += "<li></li>"
		}

		oClick.append(str);
		var oClickLi = oClick.find('li');
		oClickLi.eq(0).addClass('cur');
		
		oClick.find('li').click(function(){
			iNow = $(this).index();
			if(iNow==iOld)return false;
			fnScroll(iOld,iNow);
			iOld = iNow;
		});
		
		oNextBtn.click(function(){
			iNow++
			if(iNow>=ilen){
				iNow = 0;
			} 
			fnScroll(iOld,iNow);
			iOld = iNow;
			return false;
		});
		
		oPrevBtn.click(function(){
			iNow--
			if(iNow<=-1){
				iNow = ilen-1;
			} 
			fnScroll(iOld,iNow);
			iOld = iNow;
			return false;
		});
		
		function init(){
			if(timer)clearInterval(timer);
			timer = setInterval(function(){
				iNow++
				if(iNow>=ilen){
					iNow = 0;
				} 
				fnScroll(iOld,iNow);
				iOld = iNow;
			},5000)
		}
		
		function fnScroll(old,now){
			oClickLi.eq(now).attr({'class':'cur'}).siblings().attr({'class':''});
			if(now>old){
				oCaseLi.eq(now).insertAfter(oCaseLi.eq(old));
				oCaseul.stop(true,false).animate({'left':-iW},function(){
						oCaseul.css({'left':'0'});
						oCaseLi.eq(now).prependTo(oCaseul);
					})
			}else{
				oCaseLi.eq(now).insertBefore(oCaseLi.eq(old));
				oCaseul.css({left:-iW});
				oCaseul.stop(true,false).animate({left:0})
			}
		}
	}
}
indexAnimate.init();

function MoveNav(Scroll,aDlh) {
	var n = aDlh.length;
	var max = 0;
	var min = 0;
	if (Scroll<=0) {
		Scroll = 1;
	}
	if (Scroll>aDlh[n-1]) {
		Scroll = aDlh[n-1];
	}
	for (var i = 0; i<n; i++) {
		max = aDlh[i];
		min = aDlh[i-1];
		if(!min){min=0}
		
		if (Scroll<=max && Scroll>min) {
			return i;
		}
	}
}

function supportCss3(style) { 
	var prefix = ['webkit', 'Moz', 'ms', 'o'], 
	i, 
	humpString = [], 
	htmlStyle = document.documentElement.style, 
	_toHumb = function (string) { 
	return string.replace(/-(\w)/g, function ($0, $1) { 
	return $1.toUpperCase(); 
	}); 
	}; 
	 
	for (i in prefix) 
	humpString.push(_toHumb(prefix[i] + '-' + style)); 
	 
	humpString.push(_toHumb(style)); 
	 
	for (i in humpString) 
	if (humpString[i] in htmlStyle) return true; 
	 
	return false; 
}



//中间banner
(function(e) {
	e.fn.bannerShow = function(c) {
		c = jQuery.extend({
			autotime: 10E3,
			isAuto: true,
			cur: 0,
			timer: null
		},
		c || {});
		return this.each(function() {
			function d(a) {
				var b = e(".sideShow li").eq(a).find("a"); ! b.attr("src") && b.attr("data-src") && b.attr("src", b.attr("data-src"));
				e(".sideShow li").css({
					"z-index": 0
				}).fadeOut(1E3);
				e(".sideShow li").eq(a).css({
					"z-index": 1
				}).fadeIn(1E3)
			}
			
			var circlenum = "<div class='circle'><ul>";
			for(var i=0; i < e(".sideShow li").length; i++) {
				circlenum += "<li></li>";				
			}
			circlenum += "</ul></div>";	
			e("#midBannerShow").append(circlenum);
			if(e(".sideShow li").length == 1) {
				$('.xy_banner .circle').hide();
			}
			d(c.cur);			
			var g = e(".circle", this),
			f = e("li", g);		
			f.first().addClass("on");								
			e(this).click(function() {
				c.isAuto = false
			},
			function() {
				c.isAuto = true
			});
			f.each(function(a, b) {
				e(b).click(function() {
					c.cur = a;						
					f.removeClass().eq(c.cur).addClass("on");					
					d(c.cur)
				})
			});
			c.timer = setInterval(function() {
				if(e(".sideShow li").length == 1) {
					c.isAuto = false;
				}
				if (!c.isAuto) return false;
				c.cur == f.size() - 1 ? c.cur = 0 : c.cur += 1;
				d(c.cur);
				f.removeClass().eq(c.cur).addClass("on")
			},
			c.autotime);
		})
	}
})(jQuery);

$(function() {
	$("#midBannerShow").bannerShow();
	var c = function() {};
});
$("#midBannerShow a").mousemove(function(){
	$(this).stop().animate();
})