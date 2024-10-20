﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.Personnel.index" %>

<!DOCTYPE html>

<html id="html" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link href="css/index2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <%--<script type="text/javascript" src="../Myadmin/js/index.js"></script>--%>
    <title>云合人事管理系统</title>
    <link rel="shortcut icon" href="../Images/yhltd.ico">
</head>
<body  style="    margin: 0;">
    <script type="text/javascript">
        //自动加载
        $(function () {
            $("#userFun_div").hide();
            $("#xiala").toggle(
                function () {
                    $("#userFun_div").show();
                    $("#userFun_div").animate({ top: "70px" }, 200, "swing");
                },
                function () {
                    $("#userFun_div").animate({ top: "-100px" }, 200, "swing", function () {
                        $("#userFun_div").hide();
                    })
                }
            )

            $(".userFun_item").click(function () {
                $(".userFun_div").css("display", "none")
                var item = $.trim($(this).text())
                if (item == "修改密码") {
                    $("#Iframe2").attr("src", "../Personnel/changepwd.aspx");
                    $("#userFun_div").hide();
                } else if (item == "退出登录") {
                    window.location.href = "/Myadmin/Login.aspx"
                }
            })
        })
        function a(e, f) {
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
    <style>
        #userFun_div
        {
            display: flex;
            position: fixed;
            width: 90px;
            height: 100px;
            right: 10px;
            top: -100px;
            background-color: white;
            z-index: 19;
            box-shadow: 0 2px 4px rgba(0,0,0,.12),0 0 6px rgba(0,0,0,.04);
            flex-direction: column;
            justify-content: center;
            align-items: center;
            border-radius: 2px;
        }
        .userFun_item
        {
            width: 100%;
            text-align: center;
            height: 34%;
            line-height: 50px;
            cursor : pointer;
            font-size:14px
        }
        .userFun_item:hover
        {
            width: 100%;
            text-align: center;
            height: 34%;
            line-height: 50px;
            background-color: #f2f2f2;
            font-size:14px
        }
        .bt_top
        {
            font-size: 15px;
            width: 190px;
            height: 60px;
            display: flex;
            justify-content: center;
            cursor: pointer;
            line-height: 10px;
        }
        .bt_top:hover
        {
            font-size: 15px;
            width: 190px;
            height: 55px;
            display: flex;
            justify-content: center;
            cursor: pointer;
            border-top: 5px solid #f2f2f2;
            line-height: 49px;
        }
        .function_top
        {
            display: flex;
            justify-content: space-between;
            align-items: flex-end;
            width: 170px;
            margin-right: 25px;
            height: 100%;
        }
    </style>
    <form id="form1" runat="server" style="height:100%">
        <div class="header_login_info_con">
            <div style="width:33%">
                <a href="http://www.yhocn.cn" target="_blank"> 
                    <img src="../Personnel/images/tm_logo.png" style="float: left; margin-top: -1%; height: 67px;" />
                </a>
                <div class="logo" style="color:white">云合人事管理系统</div>
            </div>
            
            <div style="margin-left:10%">
                <a style="color:white;margin-right:20px" href="../Personnel/downloadApp.aspx" class="fl welcome_info">下载APP</a>
                <a style="color:white" href="../Personnel/downloadExcel.aspx" class="fl welcome_info">下载Excel</a>
            </div>
            <img src="../Personnel/images/animat-lightbulb-color.gif" style="height:100px;width:100px;" />
            <%--<img src="../Personnel/images/animat-pencil-color.gif" style="height:100px;width:100px;margin-right:-30%" />--%>
            <div style="width:18%" >
                <span class="fl welcome_info" style="color:white;font-weight:bold;font-size:20px;float:right">你好！</span>
                <img src="../Personnel/images/用户.png" style="height:28px;width:28px;margin-right:-20px" />
                <span id="xiala" class="fl welcome_info" style="color:white;font-weight:bold;font-size:20px"><%=Session["username"] %></span>
                <%--<div class="bt_top" id="goUserManager" >你好！</div>--%>
                <%--<div class="bt_top" runat="server" id="userName"><img src="../Personnel/images/用户.png" style="height:22px;width:22px;margin-right:-35px" /><%=Session["username"] %></div>--%>
                
                <%--<span id="myspan" runat="server" type="hidden" class="fr">
                    <a class="header_nav" href="#"></a>
                    <a class="tuichu" href="#" onclick="top.location.href='/Myadmin/login.aspx'" style="font-size:16px;color:white;font-weight:bold">
                        退出登录
                    </a>
                </span>--%>
            </div>
        </div>

        <div id="userFun_div">
            <div class="userFun_item">
                <%--<img src="Images/维修.png" style="height:15px;width:15px;margin-bottom:-3px"/>--%>修改密码
            </div>
            <div class="userFun_item">
                <%--<img src="Images/退出登录.png" style="height:15px;width:15px;margin-bottom:-3px"/>--%>退出登录
            </div>
        </div>
        <%--<div  class="function_top">
            <div class="bt_top" id="Div1" >你好！</div>
            <div class="bt_top" runat="server" id="Div2">
                <img src="../Personnel/images/用户.png" style="height:22px;width:22px;margin-right:-35px" /><%=Session["username"] %>
            </div>
            <div id="userFun_div">
                <div class="userFun_item">
                    <img src="Images/维修.png" style="height:15px;width:15px;margin-bottom:-3px"/>修改密码
                </div>
                <div class="userFun_item">
                    <img src="Images/退出登录.png" style="height:15px;width:15px;margin-bottom:-3px"/>退出登录
                </div>
            </div>
        </div>--%>

        <div class="bottomDiv">
            <div class="leftNav">
                <ul class="left_ul">
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/kaoqin.aspx','考勤')" title="1-31代表每个月的天数，&#10;“卡”代表当天打卡，&#10;“休”代表当天休息，&#10;“假”代表当天请假。">考勤<img src="../Personnel/images/kaoqinjilu.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/renyuanxinxi.aspx','人员信息管理')">人员信息管理<img src="../Personnel/images/renyuanxinxiguanli.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gongzimingxi.aspx','工资明细')" title="加班费=加班时间*配置表加班费,缺勤扣款=缺勤天数*配置表缺勤扣款,迟到扣款=迟到*配置表迟到扣款,个人医疗=基本工资*配置表个人医疗,个人公积金=基本工资*配置表个人公积金,个人年金=基本工资*配置表个人年金,企业养老=基本工资*配置表企业养老,企业失业=基本工资*配置表企业失业,企业医疗=基本工资*配置表企业医疗,企业工伤=基本工资*配置表企业工伤,企业生育=基本工资*配置表企业生育,企业公积金=基本工资*配置表企业公积金,企业年金=基本工资*配置表企业年金,个人养老=基本工资*配置表个人养老,个人失业=基本工资*配置表个人失业,税前工资=基本工资+绩效工资,税率小于等于5000为0.1,应税工资 =税前工资 -税前工资 * 税率,代扣个人所得税 = 税前工资* 税率,个人小计 = 基本工资 +绩效工资 + 个人医疗 + 个人生育+ 个人公积金 + 个人年金4% + 个人养老 + 个人失业,企业小计 = 企业养老+ 企业失业 + 企业医疗 + 企业工伤 +企业生育 +企业公积金 + 企业年金,实发工资 = 应税工资-基本工资 + 绩效工资 + 个人医疗 + 个人生育 + 个人公积金 + 个人年金4% + 个人养老 + 个人失业,应发工资 = 实发工资">工资明细<img src="../Personnel/images/gongzimingxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/kaoqinjilu.aspx','考勤记录')">考勤记录<img src="../Personnel/images/kaoqinjilu.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/peizhi.aspx','配置表')">配置表<img src="../Personnel/images/shezhi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/baopan.aspx','报盘')">报盘<img src="../Personnel/images/baopan.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/shenpi.aspx','审批记录')">审批记录<img src="../Personnel/images/baopan.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/baoshui.aspx','报税')">报税<img src="../Personnel/images/baoshui.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/bumenhuizong.aspx','部门汇总')" title="根据部门名称计算每一列的和">部门汇总<img src="../Personnel/images/bumenhuizong.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/shebao.aspx','社保')" title="根据部门计算每个列的和 ">社保<img src="../Personnel/images/shebao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gerenxinxi.aspx','员工档案')">员工档案<img src="../Personnel/images/gerenxinxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/birthday.aspx','生日提醒')">生日提醒<img src="../Personnel/images/gerenxinxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gerensuode.aspx','个人所得税')" title="计税工资=(应税工资*税率)的和,记录该条数据有几条,个人所得税=(代扣个人所得税*税率)的和">个人所得税<img src="../Personnel/images/gerensuodeshui.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/gongzitiao.aspx','工资条')">工资条<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav_li" onclick="a('../Personnel/shuomingshu.aspx','使用说明')">下载使用说明<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                </ul>
            </div>
        
            <div class="div_iframe">
                <iframe id="Iframe2" class="Iframe" name="ifrMain" src="../Personnel/wuquanxian.aspx?1" ></iframe>
            </div>
        </div>
        
        </form>
</body>
</html>

