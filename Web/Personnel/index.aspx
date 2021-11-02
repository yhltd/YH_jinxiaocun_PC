<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.Personnel.index" %>

<!DOCTYPE html>

<html id="html" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link href="css/index2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <%--<script type="text/javascript" src="../Myadmin/js/index.js"></script>--%>
    <title>云合人事管理系统</title>
</head>
<body  style="    margin: 0;">
    <script type="text/javascript">
        function a(e,f) {
            $("#Iframe2").attr("src", e);
            for (var i = 0; i < $(".leftNav_li").length; i++) {
                if ($(".leftNav_li:eq(" + i + ")").text() == f) {
                    $(".leftNav_li:eq(" + i + ")").css("background-color", "#009688")
                    $(".leftNav_li:eq(" + i + ")").css("color", "rgba(255,255,255,1)")
                } else {
                    $(".leftNav_li:eq(" + i + ")").css("background-color", "#20222A")
                    $(".leftNav_li:eq(" + i + ")").css("color", "rgba(255,255,255,0.7)")
                }
            }
        }
        $(function () {
            $("#html").css("height", "100%")
        })
    </script>
    <form id="form1" runat="server" style="height:100%">
        <div class="header_login_info_con">
            <div style="width:33%">
                <a href="http://www.yhocn.cn" target="_blank"> 
                    <img src="../Personnel/images/tm_logo.png" style="float: left; margin-top: -1%; height: 67px;" />
                </a>
                <div class="logo">云合人事管理系统</div>
            </div>
            <div style="width:23%">
                <span class="fl welcome_info">你好         ！　　你的账号：<%=Session["username"] %></span>
                <span id="myspan" runat="server" type="hidden" class="fr">
                    <a class="header_nav" href="#"></a>
                    <a class="tuichu" href="#" onclick="top.location.href='/Myadmin/login.aspx'" style="font-size:15px">
                        退出登录
                    </a>
                </span>
            </div>
            
        </div>
        <div class="bottomDiv">
            <div class="leftNav">
                <ul class="left_ul">
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/kaoqin.aspx','考勤')">考勤<img src="../Personnel/images/kaoqinjilu.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/renyuanxinxi.aspx','人员信息管理')">人员信息管理<img src="../Personnel/images/renyuanxinxiguanli.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gongzimingxi.aspx','工资明细')">工资明细<img src="../Personnel/images/gongzimingxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/kaoqinjilu.aspx','考勤记录')">考勤记录<img src="../Personnel/images/kaoqinjilu.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/peizhi.aspx','配置表')">配置表<img src="../Personnel/images/shezhi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/baopan.aspx','报盘')">报盘<img src="../Personnel/images/baopan.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/baoshui.aspx','报税')">报税<img src="../Personnel/images/baoshui.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/bumenhuizong.aspx','部门汇总')">部门汇总<img src="../Personnel/images/bumenhuizong.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/shebao.aspx','社保')">社保<img src="../Personnel/images/shebao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gerenxinxi.aspx','个人信息')">个人信息<img src="../Personnel/images/gerenxinxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gerensuode.aspx','个人所得税')">个人所得税<img src="../Personnel/images/gerensuodeshui.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gongzitiao.aspx','工资条')">工资条<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/shuomingshu.aspx','使用说明')">使用说明下载<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                </ul>
            </div>
        
            <div class="div_iframe">
                <iframe id="Iframe2" class="Iframe" name="ifrMain" src="../Personnel/wuquanxian.aspx?1" ></iframe>
            </div>
        </div>
        
        </form>
</body>
</html>

