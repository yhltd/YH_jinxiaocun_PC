﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.finance.web.view.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>云合未来财务系统</title>
    <link rel="shortcut icon" href="../../../Images/yhltd.ico">
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/demo/demo.css"/>
    <script type="text/javascript" src="../assets/js/Jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#north").css({
                "height": height * 0.1 + "px"
            })
        })
    </script>
    <script type="text/javascript" src="../assets/js/EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/locale/easyui-lang-zh_CN.js"></script>
    
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/index.css"/>
    <script type="text/ecmascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/index.js"></script>

    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
    <script type="text/javascript" src="../assets/js/update_user.js"></script>
</head>
<body>
    </script>
    <div id="main" class="easyui-layout">
        <div id="north" data-options="region:'north'" style="height: 68.9px;background:url(../assets/img/caiwu_daohanglan.jpg);">
            <div class="north-left" style="color:white">
                <a href="http://www.yhocn.cn" >
                <img src="../assets/img/tm_logo.png" style="height: 55px;"/>
                </a>
                云合未来财务系统
            </div>
            <img src="../assets/img/animat-diamond-color.gif"/ style="height: 100%;margin-left:30%">
            <div id="Div1" class="north-left" style="color:white">
                <a style="color:white;margin-right:20px" href="./downloadApp.aspx" class="leftNav_li">下载APP</a>
                <a style="color:white" href="./downloadExcel.aspx" class="leftNav_li">下载Excel</a>
            </div>
            <div id="north-right" class="north-left north-right" style="color:white">
                <img src="../assets/img/touxiang.png" style="width: 32px;height: 32px;margin-right: 10px;" />
                我的&nbsp;&or;
            </div>
        </div>
        <div class="north-right-float">
            <div id="update-pwd-btn" class="north-right-float-item">
                修改登陆密码
            </div>
            <div id="update-do-btn" class="north-right-float-item">
                修改操作密码
            </div>
            <div id="sign-out-btn" class="north-right-float-item">
                退出系统
            </div>

            <%--<div id="new-user-btn" class="north-right-float-item">
                新建用户账号
            </div>--%>
        </div>
        <div id="west" data-options="region:'west'" style="width:202px">
            <div class="easyui-sidemenu" data-options="data:left_data,onSelect:tolink"></div>
        </div>
        <div id="center" data-options="region:'center'">
            <iframe id="main-iframe" style="height: 99%;width: 100%"></iframe>
        </div>
    </div>

    <div id="update_pwd">
        
    </div>
    <div id="update_do">
        
    </div>
    <div id="new_user">
        
    </div>

    <iframe src="invalid.aspx" style="display: none"></iframe>

    <div id="instruction-dialog" style="padding: 40px;display: none;">
        <div style="font-weight: bold">云合未来财务系统-使用说明</div>
    </div>

    <div id="alert" class="alert">
        <div class="alert-close">X</div>
    </div>
</body>
</html>
