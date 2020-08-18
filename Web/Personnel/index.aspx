<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.Personnel.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link href="css/index2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <%--<script type="text/javascript" src="../Myadmin/js/index.js"></script>--%>
    <title></title>
</head>
<%--<script lang="script">
    function a() {
        window.open('page.html', 'newwindow', 'height=100,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')
    }
</script>--%>
<body  style="    margin: 0;">
    <script type="text/javascript">
        function a(e,f) {
            $("#Iframe2").attr("src", e);
            document.getElementById("daohang").innerHTML = f;
        }
    </script>
    <div>
        <iframe id="Iframe1" class="Iframe1" name="ifrMain" frameborder="0" scrolling="no" src="../Personnel/head.aspx" style="height: 21%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
    </div>
    <form id="form1" runat="server">
        <div class="leftNav" style="background-color: #20222A;">
                <a href=" " target="_blank" class="leftNav_li_header" id="daohang">
                    导航栏
                </a>
                <ul class="left_ul">
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/kaoqin.aspx','考勤')">考勤</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/renyuanxinxi.aspx','人员信息管理')">人员信息管理</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gongzimingxi.aspx','工资明细')">工资明细</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/kaoqinjilu.aspx','考勤记录')">考勤记录</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/peizhi.aspx','配置表')">配置表</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/baopan.aspx','报盘')">报盘</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/baoshui.aspx','报税')">报税</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/bumenhuizong.aspx','部门汇总')">部门汇总</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/shebao.aspx','社保')">社保</a></li> 
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gerenxinxi.aspx','个人信息')">个人信息</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gerensuode.aspx','个人所得税')">个人所得税</a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gongzitiao.aspx','工资条')">工资条</a></li> 
                </ul>
            </div>
        <div class="div_iframe">
            <iframe id="Iframe2" class="Iframe" name="ifrMain" src="" ></iframe>
        </div>
        </form>
</body>
</html>

