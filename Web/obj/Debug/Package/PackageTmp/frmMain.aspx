﻿<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="Web.frmMain" %>

<%--<!DOCTYPE html>--%>

<html id="main_html" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="images/uploadify.css" />
    <link href="images/style.css" rel="stylesheet" type="text/css">
    <script src="/Myadmin/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Myadmin/js/json2.js" type="text/javascript"></script>
    <script src="Scripts/main_js.js" type="text/javascript"></script>
    <style type="text/css">
    </style>
    <title>云合未来进销存管理系统</title>
    <link rel="shortcut icon" href="Images/yhltd.ico">
    <script type="text/javascript">
        //自动加载
        var panduan = false
        $(function () {
            var windowHeight = window.innerHeight
            $(".left_ul").css("height", windowHeight * 0.85 + "px")

            $("#r_k").removeClass("leftNav_li");
            $("#r_k").addClass("leftNav_li_active");

            $("#userFun_div").hide();

            $("#goUserManager").click(function () {
                var items = $(".leftNav_li_active");
                for (var i = 0; i < items.length; i++) {
                    var id = items[i].id
                    $("#" + id).removeClass("leftNav_li_active")
                    $("#" + id).addClass("leftNav_li");
                }
                if (true) {
                    $("#Iframe1").attr("src", "Myadmin/HouTai/YongHuGuanli.aspx");
                } else {
                    alert("您没有权限")
                }
            })

            $("#userName").toggle(
                function () {
                    $("#userFun_div").show();
                    $("#userFun_div").animate({ top: "70px" }, 200, "swing");
                    panduan = true
                },
                function () {
                    $("#userFun_div").animate({ top: "-100px" }, 200, "swing", function () {
                        $("#userFun_div").hide();
                    })
                }
            )

            $("html").on('click', function (e) {
                if (panduan) {
                    $("#userName").click();
                    panduan = false
                }
            })

            window.onblur = function () {
                if (panduan) {
                    $("#userName").click();
                    panduan = false
                }
            }


            $(".userFun_item").click(function () {
                $(".userFun_div").css("display", "none")
                var item = $.trim($(this).text())
                if (item == "修改密码") {
                    $("#Iframe1").attr("src", "Myadmin/changepassword.aspx");
                } else if (item == "退出登录") {
                    window.location.href = "/Myadmin/Login.aspx"
                }
            })
        })

        function add_li(e, url) {
            var items = $(".leftNav_li_active");
            for (var i = 0; i < items.length; i++) {
                var id = items[i].id
                $("#" + id).removeClass("leftNav_li_active")
                $("#" + id).addClass("leftNav_li");
            }
            $("#" + e).removeClass("leftNav_li");
            $("#" + e).addClass("leftNav_li_active");
            $("#Iframe1").attr("src", url);
        }

    </script>

    <style type="text/css">
        #ul_tj li {
            float: left;
            margin-right: 0.1%;
            background-color: #e0ecff;
            width: 98px;
            height: 31px;
            border-radius: 11px 11px 32px 5px;
        }

        .a_lj {
            color: white;
            font-size: 118%;
            position: relative;
            left: 6%;
            top: 17%;
        }
        .left_ul {
            height: 500px;
            padding-top: -20px
        }
        .window_iframe {
            height: 100%;
            width: 99%;
            background-color: white;
        }
        .top_div {
            width: 100%;
            min-height: 60px;
            border-bottom: 1px solid #dcdfe6;
            z-index: 20;
            display: flex;
            align-items: center;
            justify-content: space-between;
            background-color: #ffffff;
            height: 60px;
            background: url('Images/daohang4.jpeg')top center no-repeat; 
            background-size:cover;
        }
        .time_top
        {
            margin-left: 20px;
            font-size: 15px;
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
        .bt_top
        {
            font-size: 15px;
            width: 95px;
            height: 60px;
            display: flex;
            justify-content: center;
            cursor: pointer;
            line-height: 60px;
        }
        .bt_top:hover
        {
            font-size: 15px;
            width: 95px;
            height: 55px;
            display: flex;
            justify-content: center;
            cursor: pointer;
            border-top: 5px solid #f2f2f2;
            line-height: 49px;
        }
        #userFun_div
        {
            display: flex;
            position: fixed;
            width: 120px;
            height: 150px;
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
        }
        .userFun_item:hover
        {
            width: 100%;
            text-align: center;
            height: 34%;
            line-height: 50px;
            background-color: #f2f2f2;
        }
        .main-div
        {
            width: 100%;
            display: flex;
            z-index: 20;
            position: absolute;
            top: 61px;
            bottom: 0;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="top_div">
            <a href="http://www.yhocn.cn" target="_blank" class="leftNav_li_header" style="color:white">
                <img class="logo" src="Personnel/images/tm_logo.png"/>
                云合未来进销存
            </a>

            <div class="function_top" style="margin-left:50%">
                <a style="color:white;margin-right:20px" href="./jxc_app.aspx" class="bt_top" style="color:white">下载APP</a>
                <a style="color:white" href="./jxc_excel.aspx" class="bt_top" style="color:white">下载Excel</a>
            </div>

            <div class="function_top">
                <div class="bt_top" id="goUserManager" style="color:white" >用户管理</div>
                <img class="bt_top" src="Images/user.png" style="height:25px;width:25px;padding-bottom: 15px;"/>
                <div class="bt_top" runat="server" id="userName" style="color:white">
                    
                </div>
            </div>
        </div>
        <div class="main-div">
            <div class="leftNav" style="background-color: #20222A;">
                <ul class="left_ul">
                    <li><a href="#" id="r_k" class="leftNav_li" onclick="add_li('r_k','ru_ku.aspx')" title="入库单双击入库可以添加一行,此表是根据明细表合计来查询的">入库单</a></li>
                    <li><a href="#" id="c_k" class="leftNav_li" onclick="add_li('c_k','chu_ku.aspx')" title="出库单双击出库可以添加一行,此表是根据明细表合计来查询的">出库单</a></li>
                    <li><a href="#" id="q_c" class="leftNav_li" onclick="add_li('q_c','qi_chu.aspx')" title="期初数双击序号可以添加一行">期初数</a></li>
                    <li><a href="#" id="m_x" class="leftNav_li" onclick="add_li('m_x','ming_xi.aspx')" title="明细双击序号可以添加一行">明细</a></li>
                    <li><a href="#" id="j_x" class="leftNav_li" onclick="add_li('j_x','jin_xiao_cun.aspx')" title="明细双击序号可以添加一行,此表是根据明细表来判断期初，入库，出库，结存结果相加来查询">进销存</a></li>
                    <li><a href="#" id="j_c" class="leftNav_li" onclick="add_li('j_c','sp_rc_ku_select.aspx')">商品进出查询</a></li>
                    <li><a href="#" id="c_h" class="leftNav_li" onclick="add_li('c_h','kh_ming_xi_selcet.aspx')">客户/供应商查询</a></li>
                    <li><a href="#" id="z_l" class="leftNav_li" onclick="add_li('z_l','ji_chu_zi_liao_page.aspx')" title="基础资料双击序号可以添加一行">基础资料</a></li>
                    <li><a href="#" id="k_h" class="leftNav_li" onclick="add_li('k_h','kehu.aspx')" title="客户资料双击序号可以添加一行">客户资料</a></li>
                    <li><a href="#" id="g_y" class="leftNav_li" onclick="add_li('g_y','gongyingshang.aspx')" title="供应商资料双击序号可以添加一行">供应商资料</a></li>
                    <li><a href="#" id="l_l" class="leftNav_li" onclick="add_li('l_l','zheng_li_page.aspx')" title="笔记双击序号可以添加一行">笔记</a></li> 
                    <li><a href="#" id="s_m" class="leftNav_li" onclick="add_li('s_m','jxc_shuoming.aspx')">下载使用说明</a></li> 
                </ul>
            </div>
            <div class="mainCon1">
                <div class="rightContentfrmain">
                    <iframe id="Iframe1" name="ifrMain" frameborder="0" scrolling="yes" src="/wqx1.aspx" class="window_iframe"></iframe>
                </div>
            </div>

            <div id="userFun_div">
                <div class="userFun_item">
                    <img src="Images/维修.png" style="height:15px;width:15px;margin-bottom:-3px"/>修改密码
                </div>
                <div class="userFun_item">
                    <img src="Images/退出登录.png" style="height:15px;width:15px;margin-bottom:-3px"/>退出登录
                </div>
            </div>
        </div>
    </form>
</body>
</html>