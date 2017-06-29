$(function(){
	$('#search_nav').click(function(){//头部搜索
	$(this).find('dd').show();
	return false;
	});

	$('#search_nav dd a').click(function(){//头部搜索
		$('#search_nav').find('dt').html($(this).html());
		$('#search_nav').find('dd').hide();
		return false;
	});
	
	$(document).click(function(){//头部搜索
		$('#top_search').find('dd').hide();
	});
	
	(function(){//导航效果
		var oHeader = $('.g_header');
		var iMaxh = 80;
		var orRect = oHeader.find('.r_rect');
		var onoff = true;
		var it = 0;
		var ocloseHeader = $('<div style="width:100%; height:80px"></div>')
		headerFn($(window));
		$(window).scroll(function(){
			if(!oHeader[0])return false;
			headerFn($(this));
		});
		
		function headerFn(obj){
			it = obj.scrollTop();
			if(it>=iMaxh){
				if(!onoff) return;
				onoff = false;
				oHeader.addClass('fixed');
				if(!ocloseHeader[0])ocloseHeader.prependTo($('body'))
			}else{
				oHeader.removeClass('fixed');
				ocloseHeader.remove();
				onoff = true;
			}
		}
		
		//不兼容
		/*$(document).bind('mousewheel',function(event,delta){
			if(delta==1){
				orRect.hide();
				orRect.eq(0).show();
			}
			else{
				orRect.hide();
				orRect.eq(1).show();
			}
			$('#search_nav').find('dd').hide();
		})*/
		if(orRect.eq(1).length <= 0) return;
		$(document).on("mousewheel DOMMouseScroll", function (e) {
			var delta = (e.originalEvent.wheelDelta && (e.originalEvent.wheelDelta > 0 ? 1 : -1)) ||  (e.originalEvent.detail && (e.originalEvent.detail > 0 ? -1 : 1)); 
			if (delta > 0) {
				orRect.eq(1).hide();
				orRect.eq(0).show();
			} else if (delta < 0) {
				orRect.eq(0).hide();
				orRect.eq(1).show();
			}
		});
		
	})();
	/*跑马灯 begin*/
	(function(){
		var wrap = $('.m_homeTips');
		if(!wrap[0])return false;
		if(wrap.size() != 0){
			var inform = wrap.find('.txt');
			var em = inform.find('em');
			inform.css({width:em.width()*2});
			em.clone().appendTo(inform);
			var timer = setInterval(function(){
				inform.css('left','-='+1);
				if(-inform.position().left >= inform.width()/2){
					inform.css('left',1100);
					inform.find('em:first').appendTo(inform);
				};
			},20);
		};
	})();
});