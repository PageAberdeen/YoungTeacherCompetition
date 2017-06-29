<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="UpFile.aspx.cs" Inherits="ComputerBS.UpFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <asp:ScriptManager ID="sm_test" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="main w1000">
                <div class="works_upload mgt30 clearfix">
                    <h2 class="tit"><span>作品上传</span></h2>
                    <div class="content clearfix">
                        <div  style="font-size:14px;width:144px;margin:0 auto;position:relative">
                            <label>
                                <img src="/Image/upfile.jpg" alt="Alternate Text" style="width:140px;"/>
                                <asp:FileUpload ID="FileUp1" runat="server" style="width:140px;height:140px;position:absolute;top:0;opacity:0;z-index:3;cursor:pointer;" />
                                <span style="font-size:12px;">点击上方图标上传参赛视频</span>
                            </label>
                            <label>
                                <asp:Button runat="server" Text="立即上传" class="btn upfile-btn" ID="btUpFile" OnClick="btUpFile_Click"></asp:Button>
                                <%--<a class="upload_now" runat="server" onclick="FileUp()">立即上传</a>--%>
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btUpFile" />
        </Triggers>
    </asp:UpdatePanel>
    <!--请登录后来抽奖-->
    <div class="dia_share dis_none" name="tipWarn2">
        <div class="ico_warn"></div>
        <div class="word">
            <p>上传失败，请重新上传</p>
        </div>
    </div>
    <div id="screen"></div>
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
    <%--<script src="../common/js/jquery.js"></script>
    <script src="../common/js/fun.js"></script>
    <script type="text/javascript" src="../common/js/jquery.artDialog.js"></script>
    <script type="text/javascript" src="../common/js/jquery.artDialog.plugins.js"></script>--%>
    <script>
        function sub() {
            if (!$("#AddName").val()) {
                msg('请填写姓名', 0);
            } else if (!$("input[name='cls']").val()) {
                msg('请填写学校班级', 0);
            } else if (!$("input[name='work_name']").val()) {
                msg('请填写作品名称', 0);
            } else if (!$("input[name='zp']").val()) {
                msg('请上传作品文件', 0);
            } else {
                $('#profile_form').submit();
            }
        }
        /*今日未登录弹窗*/
        function open() {
            $("div[name='tipWarn2']").jumpBox(true);
            setTimeout(function () {
                $("div[name='tipWarn2']").hide(),
                $('#screen').hide()
            }, 3000)
        }
        //$(".qjf_seleautodiv").SeleautoBox();
        //function msg(ms, flag) {
        //    $('.word p').html(ms);
        //    $("div[name='tipWarn2']").jumpBox(true);
        //    setTimeout(function () {
        //        $("div[name='tipWarn2']").hide(),
        //		$('#screen').hide();
        //        if (flag == 1) {
        //            userLogin('/index.php?r=activity/Activitydnds/upload');
        //        }
        //    }, 3000)

        //}
        //msg('请先登录', 1);
    </script>
    <%--<script>
        /*今日未登录弹窗*/
        $(".upload_now").click(function () {
            $("div[name='tipWarn2']").jumpBox(true);
            setTimeout(function () {
                $("div[name='tipWarn2']").hide(),
                $('#screen').hide()
            }, 3000)
        })

        $(".qjf_seleautodiv").SeleautoBox();

    </script>--%>
</asp:Content>
