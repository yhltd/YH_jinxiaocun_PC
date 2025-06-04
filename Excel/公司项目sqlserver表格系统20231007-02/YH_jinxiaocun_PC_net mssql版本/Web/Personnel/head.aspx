<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="head.aspx.cs" Inherits="Web.Personnel.head" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    </script>
</head>
<body  style="    margin: 0;">
    <form id="form1" runat="server">
        <%--<div class="logo">
            <a href="http://www.yhocn.cn" target="_blank">
                <img src="images/top_bg.jpg" alt="Logo" style="width: 100%" height="40px" title="管理系统" />
            </a>
        </div>--%>
        <%--<div class="header_logo">
            <div class="header_logo_con" style="margin-left: 2%;">
                <img src="images/tm_logo.png" style="float: left; margin-top: -1%; height: 67px;" />
                <h1 class="h1_logo">云合人事管理</h1>
            </div>
        </div>--%>
        <div class="header_login_info">
            <div class="header_login_info_con">

                <span class="fl welcome_info">你好         ！　　你的账号：<%=Session["username"] %></span>
                <span id="myspan" runat="server" type="hidden" class="fr"><a class="header_nav" href="#"></a><a href="#" onclick="top.location.href='/Myadmin/login.aspx'" style="font-size:15px">退出登录</a></span>

            </div>
        </div>
    </form>
</body>



</html>
