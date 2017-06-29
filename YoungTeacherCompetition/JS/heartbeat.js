/*
 * 心跳js
 * 2014-05-14
 *
*/
function GetHeartbeat(obj){
		if(obj!=undefined){
			if(obj.code !='000000' && obj.msg!=undefined && obj.msg != ''){
					art.dialog({
						id: 'hearbeat_dialog',
						lock: true,
						padding: '10px 0px',
						title:'登录超时！',
						content:obj.msg,
						width:394,
						height:214,
						initialize:function(){
							var That = this;
							var btnTue = $('.d-dialog').find('input[onoff=true]');
							btnTue.click(function(){
								if(obj.url!=undefined)location.href = obj.url; 
							});
						},
						beforeunload:function(){
							if(obj.url!=undefined)location.href=obj.url;
						}
					});
			}
		}
	}
function SetHeartbeat(){
	var arg=getUrlArg();
	var js_url=arg['url'];
	if(js_url!="" && typeof(js_url) != "undefined"){
		js_url=decodeURIComponent(js_url);
	}
	else {
		return false;
	}
	var url=encodeURIComponent(window.location.href);
	$.ajax({
        url: js_url+'/index.php?r=widgets/heartbeat/Heartbeat/Index',
        type: 'GET',
        data:{url:url},
        dataType: 'JSONP',
        jsonpCallback:'GetHeartbeat',
        success: function (data) {}
    });
}
function getUrlArg(){
	var len=$("script").length;
	var reg=/widgets\/heartbeat\/js\/heartbeat.js/;
	for(var i=0;i<=len;i++){
		if($("script").eq(i).attr("src")!=undefined){
			var url=$("script").eq(i).attr("src").toString();
			if(reg.test(url)){
				var u = url.split("?");
				if(typeof(u[1]) == "string"){
					u = u[1].split("&");
					var get = {};
					for(var i in u){
						var j = u[i].split("=");
						get[j[0]] = j[1];
					}
					return get;
				} else {
					return {};
				}
			}
		}
	}
}

$(document).ready(function() {	
	try {
        if (typeof(app_heartbeat) == "undefined") {
        	SetHeartbeat();
        } else {
           
        }
    } catch(e) {}
	
	setInterval(SetHeartbeat,40000);
});