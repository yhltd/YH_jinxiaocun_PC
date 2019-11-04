<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNav.aspx.cs" Inherits="Web.frmNav" %>--%>

<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmNav.aspx.cs" Inherits="Web.frmNav" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="images/style.css" rel="stylesheet" type="text/css">
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //function setSize() {

        //    var myHeight = 200;     //窗口高度
        //    var myWidth = 960;     //窗口宽度
        //    window.resizeTo(myWidth, myHeight);
        //    window.moveTo((window.screen.availWidth - myWidth) / 2, (window.screen.availHeight - myHeight) / 2);
        //}
        //  top.location.href = '/Myadmin/logout.aspx';


    </script>
</head>
<%--onload="setSize()"--%>
<body>
    <form id="form1" runat="server">
        <div class="logo">
            <a href="http://www.yhocn.com" target="_blank">
                <img src="/Myadmin/images/top_bg.jpg" alt="Logo" style="width: 100%" height="40px" title="管理系统" />
            </a>
        </div>
        <div class="header_logo">
            <div class="header_logo_con" style="margin-left: 2%;">
                <img src="Myadmin/images/tm_logo.png" style="float: left;margin-top: -1%;height: 67px;" />
                <h1 class="h1_logo">云合进销存</h1>
            </div>
        </div>
        <div class="header_login_info">
            <div class="header_login_info_con">
                 
                <span class="fl welcome_info">你好         ！　　你的账号：<%=Session["username"] %></span>
                <%--<span class="fr"><a class="header_nav" href="#"></a><a class="header_nav" href="UserPassUp.asp">修改密码</a>　　　<a class="header_nav" href="/Myadmin/logout.aspx">退出登录</a></span>--%>
                <span id="myspan" runat="server" type="hidden" class="fr"><a class="header_nav" href="#"></a><a class="header_nav" href="/Myadmin/changepassword.aspx">修改密码</a>　　　<a href="#" onclick="top.location.href='/Myadmin/login.aspx'">退出登录</a></span>
                <span id="myspan2" runat="server" type="hidden" class="fr"><a class="header_nav_a" href="#"></a><a class="header_nav_a" href="#" onclick="top.location.href='frmUserManger.aspx'">用户管理</a> <a class="header_nav_a" onclick="top.location.href='/Myadmin/changepassword.aspx'">修改密码</a>　　　<a href="#" class="header_nav_a" onclick="top.location.href='/Myadmin/login.aspx'">退出登录</a> &nbsp<a class="header_nav_a" href="#" onclick="top.location.href='frmMain.aspx'">主页</a></span>

            </div>
        </div>
    </form>
</body>



</html>
