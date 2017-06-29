//将form转为AJAX提交
function ajaxSubmit(frm, fn) {
    var dataPara = getFormJson(frm);
    $.ajax({
        url: frm.action,
        type: frm.method,
        data: dataPara,
        dataType: "json",
        success: fn
    });
}
//将form中的值转换为键值对。
function getFormJson(frm) {
    var o = {};
    var a = $(frm).serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
}

/**
 * form的ajax提交
 * 新增a的ajax操作
 */
function ajax_submit(frm){
 	if($(frm).attr('href')!=undefined){
		frm.action = $(frm).attr('href')
		if(frm.method == '' || frm.method == undefined){
			frm.method = 'get'
		}
	}
	ajaxSubmit(frm, function(data){
		if(data.content!=undefined && data.content!=''){
			var obj = data;
		}else{
			var obj = {
				content:$(data).contents('.zz_changePage').find('.wd').text(),
				type :2,
				time:1000
			}
		}
		
		if(obj.content=='schooltp_redirect_jump'){  
                //延迟跳转页面
                setTimeout(function(){
                    //如果设置了跳转页面，就跳转，没有设置页面不跳转，不刷新
                    if(obj.url!='' && obj.url!=undefined){
                        if(obj.url==1)window.location.reload();
                        else location.href = obj.url;
                    }
                    flag = true;
                },obj.time);
                return false;
        }
		
		//指定显示信息
		var message_id = $(frm).attr('message_id')
		if(message_id!=undefined && message_id!=''){
			$('#'+message_id).html(obj.content);
			var a = obj.callback;	
			if(a!=''){
				if(typeof a == 'function'){
					a();
				}else{
					eval(a);
				}
			}
		}else{ 
			//显示提示信息
			 art.tips({
				content:obj.content,
				type:obj.type,
				time:obj.time,
				callback:obj.callback
			})
		}
		//延迟跳转页面
		setTimeout(function(){
			//如果设置了跳转页面，就跳转，没有设置页面不跳转，不刷新
			if(obj.url!='' && obj.url!=undefined){
				if(obj.url==1)window.location.reload();
				else location.href = obj.url;
			}
			flag = true;
		},obj.time);
	});
		return false;
}

	/**
	 * form的ajax提交
	 * 新增a的ajax操作
	 * 在ajax_submit基础上避免重复提交    --去重
	 */
	function ajax_submit_qc(frm, btn){
	
		$(btn).addClass('input_bg_gray');
		$(btn).attr("disabled","disabled");

	 	if($(frm).attr('href')!=undefined){
			frm.action = $(frm).attr('href')
			if(frm.method == '' || frm.method == undefined){
				frm.method = 'get'
			}
		}
		ajaxSubmit(frm, function(data){
   		
			if(data.content!=undefined && data.content!=''){
				var obj = data;
			}else{
				var obj = {
					content:$(data).contents('.zz_changePage').find('.wd').text(),
					type :2,
					time:1000
				}
			}
			//指定显示信息
			var message_id = $(frm).attr('message_id')
			if(message_id!=undefined && message_id!=''){
				$('#'+message_id).html(obj.content);
				var a = obj.callback;	
				if(a!=''){
					if(typeof a == 'function'){
						a();
					}else{
						eval(a);
					}
				}
			}else{ 
				//显示提示信息
				 art.tips({
					content:obj.content,
					type:obj.type,
					time:obj.time,
					callback:obj.callback
				})
			}
			$(btn).removeClass('input_bg_gray');
			$(btn).removeAttr("disabled");
			//延迟跳转页面
			setTimeout(function(){
				//如果设置了跳转页面，就跳转，没有设置页面不跳转，不刷新
				if(obj.url!='' && obj.url!=undefined){
					if(obj.url==1)window.location.reload();
					else location.href = obj.url;
				}
				flag = true;
			},obj.time);
		});
			return false;
	} 

//显示提示信息
function showTips(obj){
	 art.tips({
		content:obj.content,
		type:obj.type,
		time:obj.time,
		callback:obj.callback
	})
}


//显示提示信息
function show(obj){
	 art.tips({
		content:obj.content,
		type:obj.type,
		time:obj.time,
		callback:obj.callback
	})
}

var edu = {
	report:function(obj){//举报弹出框

		var objectid = $(obj).attr('objectid');
		var objecttype = $(obj).attr('objecttype');
		
		if (getCookie("IsSubmit")=="YES" && objectid==getCookie("object")) {
			alert("您已经举报过了！!");
		} else{
			setCookie("IsSubmit","YES");  
			setCookie("object",objectid);
			art.load({
						id:'report',
						title:'举报',
						content:'index.php?r=common/report/show'+'&objectid='+objectid+'&objecttype='+objecttype
					})
		}	
	}
}
function setCookie(name,value)
{
    var Days = 1;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days*60*60*1000);
    document.cookie = name + "="+ escape (value);
}
function getCookie(name)
{
    var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
    if(arr=document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
} 


