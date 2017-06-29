<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="AllReview.aspx.cs" Inherits="ComputerBS.AllReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="main w1000">
	<div class="Expert-review mgt30 clearfix">
    	<h2 class="tit"><span>专家评审</span></h2>
        <div class="sel">
            <em>作品类型筛选：</em>
            <asp:DropDownList ID="ddlt_Area" runat="server" AutoPostBack="True" Width="150px" Height="25px" OnSelectedIndexChanged="ddlt_Area_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlt_T_zptype" Width="150px" Height="25px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlt_T_zptype_SelectedIndexChanged">
            </asp:DropDownList>
            <%--<span class="qjf_seleautodiv" style="width:146px; margin-right:10px">
                <span class="qjf_seleautocur">
                    <p>默认值请在a标签列表上加class="active"</p>
                    <input type="hidden" class="selRes" id="hi" value="1" />
                </span> 
                <span class="qjf_seleautodrop"  style="width: 106px;">
                    
                    <%--<a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#" value="2">第2个选项</a> <a href="#" value="3">第3个选项</a> <a href="#" class="active" value="4">第4个选项</a> <a href="#" value="5">第5个选项</a> <a href="#" value="6">第6个选项</a> <a href="#" value="7">第7个选项</a> <a href="#" value="8">第8个选项</a>--%>
            <%--</span>
            </span>--%>
            <%--<span class="qjf_seleautodiv" style="width:146px; margin-right:10px">
                <span class="qjf_seleautocur">
                    <p>默认值请在a标签列表上加class="active"</p>
                    <input type="hidden" class="selRes" value="1" />
                </span> 
                <span class="qjf_seleautodrop" style="width:106px;"> 
                    <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#"  value="2">第2个选项</a> <a href="#"  value="3">第3个选项</a> <a href="#"  class="active"  value="4">第4个选项</a> <a href="#"  value="5">第5个选项</a> <a href="#"  value="6">第6个选项</a> <a href="#"  value="7">第7个选项</a> <a href="#"  value="8">第8个选项</a> 
                </span>
            </span>
            <span class="qjf_seleautodiv" style="width:146px; margin-right:10px">
                <span class="qjf_seleautocur">
                    <p>默认值请在a标签列表上加class="active"</p>
                    <input type="hidden" class="selRes" value="1" />
                </span> 
                <span class="qjf_seleautodrop" style="width:106px;"> 
                    <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#"  value="2">第2个选项</a> <a href="#"  value="3">第3个选项</a> <a href="#"  class="active"  value="4">第4个选项</a> <a href="#"  value="5">第5个选项</a> <a href="#"  value="6">第6个选项</a> <a href="#"  value="7">第7个选项</a> <a href="#"  value="8">第8个选项</a> 
                </span>
            </span>
            <span class="qjf_seleautodiv" style="width:146px; margin-right:10px">
                <span class="qjf_seleautocur">
                    <p>默认值请在a标签列表上加class="active"</p>
                    <input type="hidden" class="selRes" value="1" />
                </span> 
                <span class="qjf_seleautodrop" style="width:106px;"> 
                    <a href="#" value="1">第一个选项第一个选项第一个选项</a> <a href="#"  value="2">第2个选项</a> <a href="#"  value="3">第3个选项</a> <a href="#"  class="active"  value="4">第4个选项</a> <a href="#"  value="5">第5个选项</a> <a href="#"  value="6">第6个选项</a> <a href="#"  value="7">第7个选项</a> <a href="#"  value="8">第8个选项</a> 
                </span>
            </span>--%>
        </div>
        <%--<div class="panel-body">

                <div class="bs-example" data-example-id="inline-code">
                <label for="groupType">作品类型筛选：</label>
            </div>

            
            <div class="col-sm-5 col-md-5 col-xs-5 col-lg-5">
                  <select class="form-control col-sm-2 col-md-2 col-lg-2" id="groupType">
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
              </div>
                
        </div>--%>
        <ul>
            <asp:Repeater ID="ReviewDataWorks" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="grade fr">
                            <p>你的打分：<em><%#Eval("ScorceNub") %></em></p>
                            <p class="c_red">最终得分：<em><%#Eval("ScorceNub") %></em></p>
                        </div>
                        <a href="javascript:;" class="fl">
                            <img src="Image/4.jpg" class="imgzp"></a>
                        <div class="introduction">
                            <h2 class="b_tit"><a href="ShowWork.aspx?wid=<%#Eval("WID") %>"><%#Eval("WUserName") %></a></h2>
                            <p class="group"><span>评选项目</span><span><%#Eval("WName") %><span></p>
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
            第<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server" Text="Label"></asp:Label>页
        </div>
        
        <%--<ul>
        	<li class="clearfix">
            	<div class="grade fr">
                	<p>你的打分：<em>80</em></p>
                    <p class="c_red">最终得分：<em>90</em></p>
                </div>
                <a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
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
            	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
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
            	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
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
            	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
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
            	<a href="javascript:;" class="fl"><img src="../area/450200/images/liuzhou_active/book.png" class="img"></a>
                <div class="introduction">
                	<h2 class="b_tit"><a href="javascript:;">创意三维设计（维飞机）</a></h2>
                    <p class="group"><span>小学组</span><span>评选项目</span><span>电脑绘画<span></p>
                </div>
            </li>
        </ul>--%>
        <%--<div class="turnPage"><span><a>当前页:</a><a runat="server" id="NowPage">1</a><a runat="server">首页</a><a runat="server">上一页</a><a runat="server">下一页</a><a href="#">尾页</a></span><span class="mglr15 txt">共 100 页</span><span class="txt">去第</span>
                    <div class="mglr5 page_num_wrap t_l">
                        <input type="text" value="" class="num_text"/>
                        <p class="anim">
                            <input type="button" value="确定" class="cfm"/>
                            <span class="txt">页</span></p>
                    </div>
                </div>--%>
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

//(function () {
//    var roll = new Roll();
//    roll.init();

//    //组别级联下拉框
//    var group = $("#groupType");
//    var uid = "test";
//    //var testType = $("#zpType");
//    //testType.change(function () {
//    //    $.ajax({
//    //        url: "AllReview.aspx/bindGroup",
//    //            //方法传参的写法一定要对，与后台一致，区分大小写，不能为数组等，str1为形参的名字,str2为第二个形参的名字 
//    //            data: "{}",
//    //            type: 'post',
//    //            contentType: "application/json; charset=utf-8",
//    //            datatype: 'json',
//    //            success: function (data) {
//    //                alert("ok");
//    //            }
//    //    });
//    //});
//    //alert(testType.val());
//    $.ajax({
//        url: "AllReview.aspx/bindGroup",
//        //方法传参的写法一定要对，与后台一致，区分大小写，不能为数组等，str1为形参的名字,str2为第二个形参的名字 
//        data: "{'userid':'" + uid + "'}",
//        type: 'post',
//        contentType: "application/json; charset=utf-8",
//        datatype: 'json',
//        success: function (data) {
//            //ajax请求成功之后返回的数据
//            var jsonS = $.parseJSON(data.d);
//            //如果返回的json数据是有数据的，那么将数据中的省份加载到select控件中
//            if (jsonS.length > 0) {
//                $('#groupType').append("<option value=''>--请选择组别--</option>");
//                //循环json数据，分解json中的数据到定义的变量中，并拼接option项到select中
//                for (var i = 0; i < jsonS.length; i++) {
//                    var json = jsonS[i];
//                    var groupid = json.GroupID;
//                    var groupname = json.GroupName;
//                    //html = html + "<option value='" + groupid + "'>" + groupname + "</option>"
//                    //group.append(html);//添加option
//                    //$("<option value='" + groupid + "'>" + groupname + "</option>").appendTo("#groupType");
//                    $('#groupType').append("<option value=" + groupid + ">" + groupname + "</option>");
//                }
//                //使用js的html函数为控件id为province的控件设置html内容option项
//                //group.append(html);//添加option
//                //group.html(html);
//                //给控件id为province的控件注册change事件，在事件中做所属城市的级联
                
//            }

//            //                            for(var i in memberList){
//            //                                var memberMap = memberList[i];
//            //                                var prime=memberMap['prime'];
//            //                                var name=memberMap['name'];
//            //                                var option=$('<option value="' + prime + '">' + name + '</option>');
//            //                                $('#select_member').append(option);
//            //                            }
//            //bootstraptable
//            //                            $.bootstrapTable('load',memberList);
//            //                            if(provinceMap.length>0)
//            //                            {
//            //                                data[]
//            //                                var dd = data.trim();
//            //                                var jsonData = eval("("+dd+")");
//            //                                //遍历添加选项
//            //                                var html = "<option>--请选择省份--</option>";
//            //                                for(var i=0;i<jsonData.length;i++)
//            //                                {
//            //                                    html += "<option value='"+jsonData[i].prime+"'>"+jsonData[i].name+"</option>";
//            //                                }
//            //                                provin.html(html);
//            //                            }
//        }
//    })
//    group.change(function () {
//        var selgroupid = $(this).val();
//        //console.log(selgropid);
//        var zptype = $("#zpType");
//        $.ajax({
//            url: "AllReview.aspx/bindZpType",
//            //方法传参的写法一定要对，与后台一致，区分大小写，不能为数组等，str1为形参的名字,str2为第二个形参的名字 
//            data: "{'GroupID':1}",
//            type: 'post',
//            contentType: "application/json; charset=utf-8",
//            datatype: 'json',
//            success: function (data) {
//                //ajax请求成功之后返回的数据
//                var jsonS = $.parseJSON(data.d);
//                //如果返回的json数据是有数据的，那么将数据中的省份加载到select控件中
//                if (jsonS.length > 0) {
//                    //清空作品类型下拉框的option
//                    zptype.html('');
//                    //循环json数据，分解json中的数据到定义的变量中，并拼接option项到select中
//                    for (var i = 0; i < jsonS.length; i++) {
//                        var json = jsonS[i];
//                        var CategoryID = json.CategoryID;
//                        var CategoryName = json.CategoryName;
//                        //html = html + "<option value='" + groupid + "'>" + groupname + "</option>"
//                        //group.append(html);//添加option
//                        //$("<option value='" + groupid + "'>" + groupname + "</option>").appendTo("#groupType");
//                        $('#zptype').append("<option value=" + CategoryID + ">" + CategoryName + "</option>");
//                    }
//                    //使用js的html函数为控件id为province的控件设置html内容option项
//                    //group.append(html);//添加option
//                    //group.html(html);
//                    //给控件id为province的控件注册change事件，在事件中做所属城市的级联

//                }

//                //                            for(var i in memberList){
//                //                                var memberMap = memberList[i];
//                //                                var prime=memberMap['prime'];
//                //                                var name=memberMap['name'];
//                //                                var option=$('<option value="' + prime + '">' + name + '</option>');
//                //                                $('#select_member').append(option);
//                //                            }
//                //bootstraptable
//                //                            $.bootstrapTable('load',memberList);
//                //                            if(provinceMap.length>0)
//                //                            {
//                //                                data[]
//                //                                var dd = data.trim();
//                //                                var jsonData = eval("("+dd+")");
//                //                                //遍历添加选项
//                //                                var html = "<option>--请选择省份--</option>";
//                //                                for(var i=0;i<jsonData.length;i++)
//                //                                {
//                //                                    html += "<option value='"+jsonData[i].prime+"'>"+jsonData[i].name+"</option>";
//                //                                }
//                //                                provin.html(html);
//                //                            }
//            }
//        });
//    });
//})();
//图片轮播 over

</script>
</asp:Content>
