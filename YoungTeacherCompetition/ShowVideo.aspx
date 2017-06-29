<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowVideo.aspx.cs" Inherits="ComputerBS.ShowVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <input id="inPutValue" type="hidden" runat="server" />
        <script src="JS/video.js" type="text/javascript"></script>
        <script type="text/javascript">            
            player("<%=GetWork()%>", 720, 475, 1, "start.jpg");
        </script>
        <%--<div id="a1" style="width:700px;height:465px;overflow:hidden"></div>--%>
        <script type="text/javascript" src="/ckplayer/ckplayer.js" charset="utf-8"></script>     
    </form>
</body>
</html>
