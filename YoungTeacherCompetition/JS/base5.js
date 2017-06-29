// JavaScript Document
$.fn.extend({
	FnManth:function(PrevBtn,NextBtn,scrollobj,scrollChildtag,num,dir,time,auto){//轮播滚动
		$(this).each(function(){
			$(this).attr('onoff',true)
			var oBox = $(this);
			var oPrevBtn = PrevBtn&&oBox.find(PrevBtn);
			var oNextBtn = NextBtn&&oBox.find(NextBtn);
			var oUl = oBox .find(scrollobj);
			var aLi = oUl.find(scrollChildtag);
			var dirNew = dir==1||dir==2?'left':'top';
			var iscale = dirNew=='left'?aLi.eq(0).outerWidth(true):aLi.eq(0).outerHeight(true);
			var timer = null;
			
			oUl.css({dirNew:aLi.length*iscale});
			var inum = aLi.length/num;
			if(inum<1)return false;
			
			oBox.hover(function(){
				oPrevBtn&&oPrevBtn.add(oNextBtn).fadeIn();
				clearInterval(timer);
			},function(){
				oPrevBtn&&oPrevBtn.add(oNextBtn).fadeOut();
				auto&&initFn();
			});
			
			oPrevBtn&&oPrevBtn.click(function(){
				fnScroll(1);
				return false;
			});
			oPrevBtn&&oNextBtn.click(function(){
				fnScroll(2);
				return false;
			});
			
			auto&&initFn();
			
			function initFn(){
				if(timer)clearInterval(timer);
				timer = setInterval(function(){
					fnScroll(dirNew=='left'?2:4);
				},3000)
			}
			function fnScroll(dir){
				onOff = false;
				if(dir==1){
					oBox.find(scrollChildtag+':last').prependTo(oBox.find(scrollobj));
					oBox.find(scrollobj).css({'left':-iscale}).stop(true,false).animate({'left':'0'},time*100,function(){
						onOff = true;
					});
				}
				else if(dir == 2){
					oBox.find(scrollobj).stop(true,false).animate({'left':-iscale},time*100,function(){
						oBox.find(scrollChildtag+':first').appendTo(oBox.find(scrollobj));
						$(this).css({'left':'0'});
						onOff = true;
					})
				}else if(dir== 3){
					oBox.find(scrollChildtag+':last').prependTo(oBox.find(scrollobj));
					oBox.find(scrollobj).css({'top':-iscale}).stop(true,false).animate({'top':'0'},time*100,function(){
						onOff = true;
					});
				}else{
					oBox.find(scrollobj).stop(true,false).animate({'top':-iscale},time*100,function(){
						oBox.find(scrollChildtag+':first').appendTo(oBox.find(scrollobj));
						$(this).css({'top':'0'});
						onOff = true;
					});
				}
			}
		})
	},
	 //选项卡.start
	tabControl:function(tab,con,mor){
		$(this).each(function(){
			var _method=this;
            $(this).find(tab).each(function(i){
                $(this).click(function(){
				if(this.className=='more'){return false;}
				$(this).addClass('on').siblings().removeClass('on');
				$(_method).find(con).addClass('dis_none').hide();;
                $(_method).find(con).eq(i).fadeIn(600);
				return false;
				});
         	});                                               
			$(this).find(mor).click(function(){
				window.location.href=$(this).attr('href');
			});
		});
	},
	NumScroll:function(ih,start){//数字滚动
		this.each(function(){
			var That = $(this);
			var inum = That.attr('data-num');
			var oUl = That.next('ul');
			var len = inum.length%3
			ceartLi();
			
			function ceartLi(){
				var aLi = oUl.find('li');
				var str = '';
				oUl.html('');
				for(var i=0; i<inum.length; i++){
					//var text = ((i+1)%3==len&&i!=inum.length-1)?",":""
					//var className = ((i+1)%3==len&&i!=inum.length-1)?"dou":""
					str +='<li><div class="numbox"><p>0</p><p>1</p><p>2</p><p>3</p><p>4</p><p>5</p><p>6</p><p>7</p><p>8</p><p>9</p></div></li>';
				}
				oUl.append(str);
				That.remove();
				if(!start){
					move(inum);
				}else{
					$(window).scroll(function(){
						if(oUl.offset().top+oUl.width()<=$(window).scrollTop()+$(window).height()){
							move(inum);
						}
					});
				}
			}
			
			function move(inum) {
				var $ScrollLi = oUl.find('li');
				$ScrollLi.each(function(i){
					var This = $(this).find('.numbox');
					This.stop(true,false).animate({'top':-inum.split('')[i]*ih},1000);
				});
			}
			
		})
	}
});


//发送短信组件
function sentMsg(obj){
	var time=60;
	var timer1=null;
	$(obj).on("click",function(){
		var that=$(this);
		that.hide().siblings(".re_send").show();
		if(time!=60){
			return;	
		}
		time--;
		that.siblings(".re_send").find("em").html(time);

		if(timer1){
			clearInterval(timer1);
		}
		timer1=setInterval(function(){
			time--;
			if(time==0){
				clearInterval(timer1);
				that.show().siblings(".re_send").hide();
				time=60;
			}
			else{
				that.siblings(".re_send").find("em").html(time);
			}
		},1000);
	})
}

//开关
function switches(wrap,circle){
	var oRemmberMe = $(wrap);
	var oSpan = oRemmberMe.children(circle);
	var onoff = true;
	$(".c_greenBtn").addClass("c_grayBtn").on("click",function(event){
		event.preventDefault()
	})
	oRemmberMe.click(function(){
		if(onoff){
			onoff = false;
			oSpan.animate({marginRight:2},200);
			oSpan.parent().addClass('on');
			$(".c_greenBtn").removeClass("c_grayBtn").off()
		}else{
			onoff = true;
			oSpan.animate({marginRight:17},200);
			oSpan.parent().removeClass('on');
			$(".c_greenBtn").addClass("c_grayBtn").on("click",function(event){
				event.preventDefault()
			})
		}
	})
};
//V2相册
var PhotoAlbum = function(options){
	var opt = {
		wrap:'.photoAlbum',
		bigImg:'.album_bigImg',
		fullscreenBtn:'.album_fullscreenBtn',
		fullscreen:'.album_fullscreen',
		fullscreenImg:'.fullscreen_img',
		fullscreenPrev:'.fullscreen_prev',
		fullscreenNext:'.fullscreen_next',
		fullscreenExit:'.album_fullscreen_exit',
		showPrev:'.album_show_prev',
		showNext:'.album_show_next',
		viewBox:'.album_list_view',
		list:'.album_list_area',
		listPrev:'.album_list_prev',
		listNext:'.album_list_next',
		listItem:'.album_list_item',
		smallImgBox:'.album_list_img',
		smallImg:'.album_smallImg',
		currentBox:'.album_current'
	};
	$.extend(opt,options || {});
	this.wrap = $(opt.wrap);
	this.bigImg = this.wrap.find(opt.bigImg);
	this.fullscreenBtn = this.wrap.find(opt.fullscreenBtn);
	this.fullscreen = this.wrap.find(opt.fullscreen);
	this.fullscreenImg = this.wrap.find(opt.fullscreenImg);
	this.fullscreenPrev = this.wrap.find(opt.fullscreenPrev);
	this.fullscreenNext = this.wrap.find(opt.fullscreenNext);
	this.fullscreenExit = this.wrap.find(opt.fullscreenExit);
	this.showPrev = this.wrap.find(opt.showPrev);
	this.showNext = this.wrap.find(opt.showNext);
	this.viewBox = this.wrap.find(opt.viewBox);
	this.list = this.wrap.find(opt.list);
	this.listPrev = this.wrap.find(opt.listPrev);
	this.listNext = this.wrap.find(opt.listNext);
	this.listItem = this.wrap.find(opt.listItem);
	this.smallImgBox = this.wrap.find(opt.smallImgBox);
	this.smallImg = this.wrap.find(opt.smallImg);
	this.currentBox = this.wrap.find(opt.currentBox);
	var vari = {
		viewBox_w:this.viewBox.width(),
		listItem_len:this.listItem.size(),
		listItem_w:this.listItem.outerWidth(true),
		listItem_m:this.listItem.outerWidth(true)-this.listItem.outerWidth(),
		list_w:0,
		view_len:0,
		index:this.listItem.filter('.active').index(),
		flag:true
	};
	vari.view_len = (vari.viewBox_w+vari.listItem_m)/vari.listItem_w;
	vari.list_w = vari.listItem_len*vari.listItem_w;
	var self = this;
	this.init = function(){
		this.layout();
		if(vari.listItem_len <= vari.view_len){
			this.listPrev.add(this.listNext).hide();
			if(vari.listItem_len < vari.view_len){
				this.list.addClass('notover');
			};
		}else{
			this.listBtnFn();
		};
		this.changeFn();
		this.fullscreenFn();
	}
	this.layout = function(){
		this.list.width(vari.list_w);
		this.currentBox.html(function(index){
			return index+1+'/'+vari.listItem_len;
		});
		this.bigImg.attr('src',this.smallImg.eq(vari.index).attr('data-middle'));
	}
	this.listBtnFn = function(){
		this.listPrev.on('click',function(){slide('prev');});
		this.listNext.on('click',function(){slide('next');});
		function slide(dir){
			if(!vari.flag) return;
			var _dis = vari.view_len*vari.listItem_w;
			var _left = parseInt(self.list.css('left')) || 0;
			if(dir == 'prev'){
				_left = _left+_dis > 0 ? 0 : _left+_dis;
			}else if(dir == 'next'){
				_left = _left-_dis < -vari.list_w+_dis ? -vari.list_w+_dis : _left-_dis;
			};
			self.list.animate({left:_left},400,function(){
				vari.flag = true;
			})
		};
	}
	this.changeFn = function(){
		this.list.on('click',opt.smallImgBox,function(){
			vari.index = $(this).parents(opt.listItem).index();
			self.move();
		});
		this.showPrev.on('click',function(){
			vari.index = vari.index<=0 ? 0 : vari.index-1;
			self.move();
		});
		this.showNext.on('click',function(){
			vari.index = vari.index>=vari.listItem_len-1 ? vari.listItem_len-1 : vari.index+1;
			self.move();
		});
	}
	this.fullscreenFn = function(){
		this.fullscreenBtn.on('click',function(){
			self.fullscreen.show();
			$('body').css('overflow','hidden');
			if($.browser.msie && parseInt($.browser.version) == 7){
				$('html').css('overflow','hidden');
			};
			self.setImgSrc(self.fullscreenImg, self.smallImg.eq(vari.index).attr('data-large'));
		});
		this.fullscreenPrev.on('click',function(){
			if(vari.index <= 0) return;
			vari.index--;
			self.setImgSrc(self.fullscreenImg, self.smallImg.eq(vari.index).attr('data-large'));
			self.move();
		});
		this.fullscreenNext.on('click',function(){
			if(vari.index >= vari.listItem_len-1) return;
			vari.index++;
			self.setImgSrc(self.fullscreenImg, self.smallImg.eq(vari.index).attr('data-large'));
			self.move();
		});
		this.fullscreenExit.on('click',exitFullscreen);
		this.fullscreen.on('click',function(e){
			if(e.target === this){
				exitFullscreen();
			};
		});
		$(document).on('keyup',function(e){
			if(e.keyCode == 27 && self.fullscreen.is(':visible')){
				exitFullscreen();
			};
		});
		function exitFullscreen(){
			self.fullscreen.hide();
			$('body').css('overflow','');
			if($.browser.msie && parseInt($.browser.version) == 7){
				$('html').css('overflow','');
			};
		};
	}
	this.setImgSrc = function(ele,src){
		ele.attr('src','').attr('src',src);
	}
	this.move = function(){
		self.listItem.removeClass('active').eq(vari.index).addClass('active');
		this.setImgSrc(self.bigImg,self.smallImg.eq(vari.index).attr('data-middle'))
		var _dNum = Math.floor(vari.view_len/2);
		var _left;
		if(vari.listItem_len <= vari.view_len) return;
		if(vari.index <= 3){
			_left = 0;
		}else if(vari.index >= vari.listItem_len-4){
			_left = -vari.list_w+vari.view_len*vari.listItem_w;
		}else{
			_left = -(vari.index-3)*vari.listItem_w;
		};
		self.list.stop().animate({left:_left},200);
	}
	this.init();
};

(function(f,h,$){var a="placeholder" in h.createElement("input"),d="placeholder" in h.createElement("textarea"),i=$.fn,c=$.valHooks,k,j;if(a&&d){j=i.placeholder=function(){return this};j.input=j.textarea=true}else{j=i.placeholder=function(){var l=this;l.filter((a?"textarea":":input")+"[placeholder]").not(".placeholder").bind({"focus.placeholder":b,"blur.placeholder":e}).data("placeholder-enabled",true).trigger("blur.placeholder");return l};j.input=a;j.textarea=d;k={get:function(m){var l=$(m);return l.data("placeholder-enabled")&&l.hasClass("placeholder")?"":m.value},set:function(m,n){var l=$(m);if(!l.data("placeholder-enabled")){return m.value=n}if(n==""){m.value=n;if(m!=h.activeElement){e.call(m)}}else{if(l.hasClass("placeholder")){b.call(m,true,n)||(m.value=n)}else{m.value=n}}return l}};a||(c.input=k);d||(c.textarea=k);$(function(){$(h).delegate("form","submit.placeholder",function(){var l=$(".placeholder",this).each(b);setTimeout(function(){l.each(e)},10)})})}function g(m){var l={},n=/^jQuery\d+$/;$.each(m.attributes,function(p,o){if(o.specified&&!n.test(o.name)){l[o.name]=o.value}});return l}function b(m,n){var l=this,o=$(l);if(l.value==o.attr("placeholder")&&o.hasClass("placeholder")){if(o.data("placeholder-password")){o=o.hide().next().show().attr("id",o.removeAttr("id").data("placeholder-id"));if(m===true){return o[0].value=n}o.focus()}else{l.value="";o.removeClass("placeholder");l==h.activeElement&&l.select()}}}function e(){var q,l=this,p=$(l),m=p,o=this.id;if(l.value==""){if(l.type=="password"){if(!p.data("placeholder-textinput")){try{q=p.clone().attr({type:"text"})}catch(n){q=$("<input>").attr($.extend(g(this),{type:"text"}))}q.removeAttr("name").data({"placeholder-password":true,"placeholder-id":o}).bind("focus.placeholder",b);p.data({"placeholder-textinput":q,"placeholder-id":o}).before(q)}p=p.removeAttr("id").hide().prev().attr("id",o).show()}p.addClass("placeholder");p.attr("isInit",true);p[0].value=p.attr("placeholder")}else{p.removeClass("placeholder")}}}(this,document,jQuery));$(function(){$("input, textarea").placeholder();if(!window.addEventListener){$(document).ajaxStop(function(){var inputs=$("input, textarea");inputs.each(function(index){if(!$(this).attr("isInit")&&!$(this).data("placeholder-enabled")){$(this).placeholder()}})})}});