<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="Web.frmMain" %>

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
        var pushnewsarr = []
        var textboxValue = ""
        var dinggao = "100"
        var tankuan = "300"
        var images = [
            {
                tptop2: ""
            },
            {
                tptop3: ""
            },
            {
                tptop4: ""
            },
            {
                tptop5: ""
            },
            {
                tptop6: ""
            }

        ]
        var xuantu = [
             {
                 tptop1: ""
             }
        ]
        $(document).ready(function () {
            getPushNews();
            setMarqueeText(textboxValue);
        });

        function getPushNews() {
            $.ajax({
                type: "POST",
                url: "frmMain.aspx/GetPushNewsData",
                data: JSON.stringify({}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result && result.d) {
                        console.log("接收到的数据:", result.d);
                        setList(result.d);
                        pushnewsarr = result.d;

                        if (pushnewsarr && pushnewsarr.length > 0) {
                            // 获取第一个元素的 textbox 值
                            textboxValue = pushnewsarr[0].textbox;
                            jsonData = pushnewsarr[0].tptop1;
                            tankuan = pushnewsarr[0].xuankuan;
                            dinggao = pushnewsarr[0].topgao || "100";
                            if (pushnewsarr[0].tptop1 && pushnewsarr[0].tptop1.trim() !== "") {
                                xuantu[0].tptop1 = "data:image/jpg;base64," + pushnewsarr[0].tptop1;
                            } else {
                                xuantu[0].tptop1 = "";
                            }
                            if (pushnewsarr[0].tptop2 && pushnewsarr[0].tptop2.trim() !== "") {
                                images[0].tptop2 = "data:image/jpg;base64," + pushnewsarr[0].tptop2;
                            } else {
                                images[0].tptop2 = "";
                            }
                            if (pushnewsarr[0].tptop3 && pushnewsarr[0].tptop3.trim() !== "") {
                                images[1].tptop3 = "data:image/jpg;base64," + pushnewsarr[0].tptop3;
                            } else {
                                images[1].tptop3 = "";
                            }
                            if (pushnewsarr[0].tptop4 && pushnewsarr[0].tptop4.trim() !== "") {
                                images[2].tptop4 = "data:image/jpg;base64," + pushnewsarr[0].tptop4;
                            } else {
                                images[2].tptop4 = "";
                            }
                            if (pushnewsarr[0].tptop5 && pushnewsarr[0].tptop5.trim() !== "") {
                                images[3].tptop5 = "data:image/jpg;base64," + pushnewsarr[0].tptop5;
                            } else {
                                images[3].tptop5 = "";
                            }
                            if (pushnewsarr[0].tptop6 && pushnewsarr[0].tptop6.trim() !== "") {
                                images[4].tptop6 = "data:image/jpg;base64," + pushnewsarr[0].tptop6;
                            } else {
                                images[4].tptop6 = "";
                            }
                           
                            images = [
                                {
                                    url: images[0].tptop2 || "https://picsum.photos/id/10/800/500",
                                    alt: "图1"
                                },
                                {
                                    url: images[1].tptop3 || "https://picsum.photos/id/11/800/500",
                                    alt: "图2"
                                },
                                {
                                    url: images[2].tptop4 || "https://picsum.photos/id/12/800/500",
                                    alt: "图3"
                                },
                                {
                                    url: images[3].tptop5 || "https://picsum.photos/id/10/800/500",
                                    alt: "图4"
                                },
                                {
                                    url: images[4].tptop6 || "https://picsum.photos/id/12/800/500",
                                    alt: "图5"
                                }
                            ];


                            var currentIndex = 0;
                            var totalItems = images.length;
                            var interval;

                            // 初始化轮播图
                            function initCarousel() {
                                var carouselImages = $("#carouselImages");
                                carouselImages.empty();

                                // 根据数组动态生成轮播项
                                for (var i = 0; i < images.length; i++) {
                                    var item = $("<div>").addClass("carousel-item").attr("id", "img" + (i + 1));
                                    var img = $("<img>").attr("src", images[i].url).attr("alt", images[i].alt);
                                    item.append(img);
                                    carouselImages.append(item);
                                }
                            }

                            function switchImage(imgId) {
                                $(".carousel-item").removeClass("active");
                                $("#" + imgId).addClass("active");

                                var index = parseInt(imgId.replace('img', '')) - 1;
                                $(".carousel-images").css("transform", "translateX(-" + (index * 100) + "%)");
                            }

                            function autoSwitch() {
                                currentIndex = (currentIndex + 1) % totalItems;
                                var imgId = "img" + (currentIndex + 1);
                                switchImage(imgId);
                            }

                            $(document).ready(function () {
                                initCarousel();
                                interval = setInterval(autoSwitch, 3000);
                                switchImage('img1');

                                $(".carousel-container").hover(
                                    function () { clearInterval(interval); },
                                    function () { interval = setInterval(autoSwitch, 3000); }
                                );
                            });

                            setMarqueeText(textboxValue);
                            var targetImg = document.querySelector('.index-images img');
                            if (targetImg && xuantu[0].tptop1) {
                                targetImg.src = xuantu[0].tptop1;
                            }
                            document.documentElement.style.setProperty('--tankuan', tankuan)
                            document.documentElement.style.setProperty('--dinggao', dinggao)
                        } else {
                            console.log(" 返回数据为空或未定义");
                        }

                    } else {
                        console.log("没有数据或数据格式错误");
                        setList([]);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("请求失败:", error);
                    setList([]);
                }
            });
        }

        function setMarqueeText(text) {
            var marqueeText = document.getElementById("marqueeText");
            if (marqueeText) {
                marqueeText.textContent = text;
            }
        }






        function setList(data) {
            console.log("setList接收到的数据:", data);
            if (data && data.length > 0) {
                data.forEach(function (item) {
                    //console.log("项目ID:", item.id, "内容:", item.textbox);
                });
            } else {
                //console.log("没有数据可显示");
            }
        }



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
        function yinClick() {
            document.querySelector('.carousel-container').classList.add('hidden');  // 隐藏顶部元素
        }
        function tanClick() { 
            document.querySelector('.carousel-index').classList.add('hidden');  // 隐藏弹窗元素
        }
        
        function daoyinClick() {
            document.querySelector('.leftNav').classList.add('hidden');  // 隐藏导航元素
            var button = document.querySelector('button[onclick="daoyinClick()"]');
            if (button) {
                // 替换onclick事件
                button.setAttribute('onclick', 'daoxianClick()');

                // 替换文本内容
                button.textContent = '>';
            }
        }
        
        function daoxianClick() {
            document.querySelector('.leftNav').classList.remove('hidden'); // 显示导航元素
            var button = document.querySelector('button[onclick="daoxianClick()"]');
            if (button) {
                // 替换onclick事件
                button.setAttribute('onclick', 'daoyinClick()');

                // 替换文本内容
                button.textContent = '<';
            }

        }
        function toggleMenu(e) {
            e.preventDefault();
            var link = e.target.closest('.nav-link');
            var menuItem = link.parentElement;
            var submenu = link.nextElementSibling;
            var arrow = link.querySelector('.arrow');

            // 关闭其他打开的菜单
            var allItems = document.querySelectorAll('.nav-item');
            for (var i = 0; i < allItems.length; i++) {
                if (allItems[i] !== menuItem && allItems[i].classList.contains('active')) {
                    allItems[i].classList.remove('active');
                    var otherArrow = allItems[i].querySelector('.arrow');
                    if (otherArrow) otherArrow.classList.remove('rotate');
                }
            }

            // 切换当前菜单
            menuItem.classList.toggle('active');
            if (arrow) arrow.classList.toggle('rotate');
        }


    </script>


    <style type="text/css">

       * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Microsoft YaHei', Arial, sans-serif;
        }
        
        body {
            background-color: #f5f7fa;
            color: #333;
        }
        li {
            width:160px;
        }
        ul {
            width:160px;
        }

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
            min-height: 70px;
            border-bottom: 1px solid #e0e6ed;
            z-index: 20;
            display: flex;
            align-items: center;
            justify-content: space-between;
            background: linear-gradient(135deg, #3d566e 0%, #2c3e50 100%);
            height: 70px;
            padding: 0 20px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.15);
        }
        .time_top
        {
            margin-left: 20px;
            font-size: 15px;
        }
         .function_top {
            display: flex;
            align-items: center;
            margin-left: 15px;
            position: relative;
        }
        
        .bt_top {
            font-size: 15px;
            display: flex;
            justify-content: center;
            cursor: pointer;
            color: #e0f7fa !important;
            text-decoration: none;
            padding: 8px 12px;
            border-radius: 4px;
            transition: all 0.3s ease;
            margin: 0 5px;
        }
        
        .bt_top:hover {
            background-color: rgba(78, 187, 177, 0.2);
            color: #4ebbb1 !important;
            transform: translateY(-2px);
        }
        
        .bt_toptp {
            display: flex;
            margin-bottom: 0;
            margin-right: 8px;
            justify-content: center;
            cursor: pointer;
            color: #e0f7fa;
            transition: all 0.3s ease;
            padding: 6px;
            border-radius: 50%;
            background: rgba(255, 255, 255, 0.1);
        }
        
        .bt_toptp:hover {
            color: #4ebbb1 !important;
            background: rgba(78, 187, 177, 0.2);
            transform: scale(1.1);
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
            height:100%;
            display: flex;
            z-index: 20;
            /*position: absolute;*/
            top: 61px;
            bottom: 0;
        }
        .top_tu {
            width:100%;
            height:100px;
            background-color:#4ebbb1
        }
        .hidden {
            display: none;
        }
        .itu {
            width:100%;
            height:100%
        }
        .btn-div_top {
            width:100%;
            display:flex;
            justify-content:center;
        }
        .clean-btn-div {
             background-color: transparent;
            color: white;
            width: 20px;
            height: 20px;
            border: 1px solid white;
            font-size: 13px;
            border-radius: 50%;
            position: absolute; 
            z-index: 9999;
            top: 0;            
            right: 0;           
            text-align: center;
            margin: 10px;       
            transform: none;   
        }

        .index-btn-div {
            background-color: transparent;
            color: white;
            width: 20px;
            height: 20px;
            border: 1px solid white;
            font-size: 13px;
            border-radius: 50%;
            position: absolute; 
            z-index: 9999;
            top: 0;            
            right: 0;           
            text-align: center;
            margin: 10px;       
            transform: none;   
        }
            
        .index-btn-div:hover {
            cursor: pointer;
        }

        .clean-btn-div:hover {
            cursor: pointer;
        }

         .carousel-container {
            width: 100%;
            height: var(--dinggao);
            position: relative;
            overflow: hidden;
            margin-bottom:5px;
        }
        .carousel-images {
            display: flex;
            width: 300%;
            height: 100%;
            transition: transform 0.5s ease-in-out;
        }

        .carousel-item {
            min-width: 100%;
            height: 100%;
            position: relative;
        }

        .carousel-item img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }
     
        .carousel-index {
            width: var(--tankuan);
            height: 200px;
            position: fixed;
            z-index: 9998;
            box-shadow: 0 0 30px rgba(0,0,0,0.6);
            border: 3px solid white;
            border-radius: 15px;
            animation: smooth-drift 40s infinite ease-in-out;
            transform: translateZ(0);
            will-change: transform; 
        }

        @keyframes smooth-drift {
            0%, 100% { 
                transform: translate(5vw, 20vh); 
            }
            25% {
                transform: translate(40vw, 1vh);
            }
            50% {
                transform: translate(65vw, 30vh);
            }
            75% {
                transform: translate(30vw, 50vh);
            }
        }

        .index-item img {
            width: 100%;
            height: 100%;
            object-fit: cover;
            border-radius: 15px;
            backface-visibility: hidden;
        }

         .marquee-container {
            flex: 1;
            max-width: 40%;
            overflow: hidden;
            margin: 0 20px;
            position: relative;
            height: 30px;
            background: rgba(255, 255, 255, 0.1);
            border-radius: 4px;
            padding: 0 10px;
            display: flex;
            align-items: center;
        }

        .marquee-content {
            color: #e0f7fa;
            white-space: nowrap;
            position: absolute;
            animation: marquee 15s linear infinite;
            font-size: 14px;
        }
        
        @keyframes marquee {
            0% { transform: translateX(100%); }
            100% { transform: translateX(-100%); }
        }
        .scrolling-container {
            width: 100px; 
            height: 30px;
            overflow: hidden;
            white-space: nowrap;
            border: 1px solid #ccc;
            position: relative;
            float:center;
        }
        .scrolling-text {
            position: absolute;
            right: 0;
        }


        #Iframe1 {
            height:100%;
        }




        
        /* 导航容器 */
        .vertical-nav {
            width: 220px;
            background-color: #2c3e50;
        }
        
        /* 一级导航项 */
        .nav-item {
            position: relative;
            border-bottom: 1px solid #34495e;
        }
        
        /* 导航链接基础样式 */
        .nav-link {
            display: block;
            padding: 14px 20px;
            color: #ecf0f1;
            text-decoration: none;
            transition: all 0.3s;
        }
        
        .nav-link:hover {
            background-color: #34495e;
        }
        
        /* 二级导航容器 */
        .sub-nav {
            list-style: none;
            display: none;
            background-color: #34495e;
        }
        
        /* 三级导航容器 */
        .sub-sub-nav {
            list-style: none;
            display: none;
            background-color: #3d566e;
        }
        
        /* 当前激活的导航项 */
        .active > .nav-link {
            background-color: #3498db;
        }
        
        /* 显示子菜单的箭头图标 */
        .has-submenu > .nav-link:after {
            content: ">";
            float: right;
            transform: rotate(90deg);
        }
        
        /* 悬停显示子菜单 */
        .nav-item:hover > .sub-nav {
            display: block;
        }
        
        .sub-nav-item:hover > .sub-sub-nav {
            display: block;
        }
        
        /* 二级菜单项样式 */
        .sub-nav-item {
            position: relative;
            border-bottom: 1px solid #3d566e;
        }
        
        .sub-nav .nav-link {
            padding-left: 30px;
        }
        
        /* 三级菜单项样式 */
        .sub-sub-nav-item {
            border-bottom: 1px solid #4b6988;
        }
        
        .sub-sub-nav .nav-link {
            padding-left: 40px;
        }


        .daohang {
            display:flex;
            background-color:white;
        }
        .anniu {
            width:15px;
            display:flex;
            align-items: center;
        }
        .bt_dao {
            height:40px;
            color:white;
            font-size:20px;
            border:none;
            border-radius:3px;
            background-color:#4ebbb1;
        }
        .bt_dao:hover {
            cursor: pointer;
            background-color:#30a99e;
        }



    </style>

</head>
<body>
        <form id="form1" runat="server">

        <div class="carousel-container">
            <button type="button" class="clean-btn-div" onclick="yinClick()">×</button>
            <div class="carousel-images" id="carouselImages"></div>
        </div>

        <div class="carousel-index">
            <button type="button" class="index-btn-div" onclick="tanClick()">×</button>
            <div class="index-images">
                <div class="index-item" id="Div1">
                    <img src="https://picsum.photos/id/13/800/500" alt="图5">
                </div>
            </div>
         </div>
        <div class="top_div">
            <a href="http://www.yhocn.cn" target="_blank" class="leftNav_li_header" style="color:white">
                <img class="logo" src="Personnel/images/tm_logo.png"/>
                云合未来进销存
            </a>

            <div class="marquee-container">
                <div class="marquee-content" id="marqueeText">
                    这是一段需要循环滚动的长文本内容，当文本完全滚动出容器后，会从右侧重新开始滚动...
                </div>
            </div>

            <div class="function_top">
                <a  href="./jxc_excel.aspx" >
                <%--<img class="bt_top" src="Images/xiazai.png" style="height:25px;width:25px;padding-bottom: 15px; background-color:#3d566e"/>--%>
                <svg viewBox="0 0 1024 1024" version="1.1" class="bt_toptp" width="32" height="32">
                    <path d="M755.8 0H268.2C214.4 0 170.7 45.8 170.7 102.4v819.2c0 56.6 43.7 102.4 97.5 102.4h487.6c53.8 0 97.5-45.8 97.5-102.4V102.4C853.3 45.8 809.6 0 755.8 0zM512 972.8a52.1 52.1 0 0 1-51.2-51.2c0-28.2 24.2-51.2 51.2-51.2s51.2 23 51.2 51.2a52.1 52.1 0 0 1-51.2 51.2zm243.8-153.6H268.2V102.4h487.6v716.8z" fill="#dbdbdb"></path>
                </svg>
                </a>
                <a style="color:white;margin-right:20px" href="./jxc_app.aspx" class="bt_top" style="color:white">下载APP</a>
            </div>
            <div class="function_top">    
                <a  href="./jxc_excel.aspx" >
                <svg viewBox="0 0 1024 1024" version="1.1" class="bt_toptp"  width="32" height="32"> <path d="M913.6 16H172c-47.2 0-85.6 38.4-85.6 85.6v176H76c-28.8 0-52 23.2-52 52v323.2c0 28 23.2 51.2 52 51.2h10.4v196.8c0 47.2 38.4 85.6 85.6 85.6h551.2v-64H172c-11.2 0-21.6-9.6-21.6-21.6V704h248c28.8 0 52-23.2 52-52V329.6c0-28.8-23.2-52-52-52h-248v-176C150.4 90.4 160 80 172 80h741.6c11.2 0 21.6 9.6 21.6 21.6V496h64V101.6c-0.8-47.2-38.4-85.6-85.6-85.6z m-712 380.8l35.2 45.6 36-45.6h80c-0.8 2.4-2.4 4.8-4 7.2l-71.2 91.2 69.6 89.6h-81.6l-28.8-37.6-29.6 37.6h-80.8l24-31.2 45.6-59.2-45.6-59.2-24.8-32c-1.6-1.6-2.4-4-4-6.4h80z" fill="#e6e6e6"></path> <path d="M863.2 356h-280c-17.6 0-32-14.4-32-32s14.4-32 32-32h280c17.6 0 32 14.4 32 32s-14.4 32-32 32z m0 172h-280c-17.6 0-32-14.4-32-32s14.4-32 32-32h280c17.6 0 32 14.4 32 32s-14.4 32-32 32z m-144 171.2h-136c-17.6 0-32-14.4-32-32s14.4-32 32-32h136c17.6 0 32 14.4 32 32s-14.4 32-32 32z" fill="#e6e6e6"></path> <path d="M1016 793.6H902.4V594.4H783.2v199.2H669.6l172.8 192z" fill="#e6e6e6"></path> </svg>
                </a>
                <a style="color:white" href="./jxc_excel.aspx" class="bt_top" style="color:white">下载Excel</a>
            </div>

            <div class="function_top">
                <svg  class=" bt_toptp" id="goUserManager" viewBox="0 0 1024 1024" version="1.1"  width="32" height="32">
                    <path d="M1021.60182 765.5c-1.3-16.3-4.3-17.8-20.4-16.5-17.8 1.4-32.9-7.5-39.1-23-6.3-15.9-1.7-32.3 12.2-43.7 9.4-7.7 10.5-13.9 2-22.9-12.8-13.5-26.1-26.6-40-38.9-10.8-9.6-15.8-8.3-25 3.2-11.2 14-29 18.2-45.2 10.7-15.2-7.1-22.3-20.1-21.2-38.5 0.8-12.6-2.9-17.1-15.5-18-9.8-0.8-19.7-1.3-28.9-1.9-9.7 1.1-18.8 1.9-27.7 3.1-12.5 1.7-15.3 5.3-14.2 18.2 1.7 19.5-6.5 34.1-22.6 40.8-15.7 6.5-31.9 1.8-44.3-12.7-7.3-8.6-13.7-9.9-21.7-2.2-13.6 12.7-26.9 25.9-39.2 39.8-10.6 11.9-9.4 15.9 2.8 26.1 11.6 9.7 16.6 22.1 13.4 37-3.3 15.2-13 25-28 28.5-5.5 1.3-11.6 0.5-17.5 0.4-7.9-0.1-12.9 3.5-14 11.3-2.9 21.5-3 43.1 0.9 64.6 1.5 8.5 6.1 11.8 14.6 11.2 4.5-0.3 9.1-1.3 13.5-0.9 15.8 1.6 28.2 12.1 32.5 26.8 4.3 14.7-0.8 29.7-13.5 39.9-10.4 8.4-11.6 14.2-2.5 23.9 12.6 13.4 25.6 26.4 39.4 38.5 11.7 10.3 16.2 9.1 26-3.4 13.4-17.2 37.5-19.5 53.9-5.4 11 9.5 14 21.4 12.5 35.3-1.1 10.3 2.7 16.2 11.7 16.3 20.2 0.4 40.5 0.5 60.6-0.7 13.1-0.8 15.7-5.5 14.2-18.7-2.2-19.2 5.9-34.2 22-41.1 16.3-6.9 32.7-2.2 44.8 12.7 7.4 9.1 13.9 10.5 22.2 2.5 13.9-13.2 27.3-26.9 40-41.2 9.2-10.4 7.9-16-3.2-24.4-9.3-7-14.5-16.3-15.2-27.9-1.4-23.6 17.9-41.6 41.8-39.2 12.2 1.2 18.2-2.3 18.5-12.9 0.6-19 0.8-37.9-0.6-56.7zM804.50182 889.9c-52.5-0.6-94.7-43.3-94-95.3 0.7-51.3 43-93.5 93.7-93.3 52.3 0.2 95.5 43.2 94.9 94.7-0.5 52.1-43.2 94.4-94.6 93.9z m0 0" fill="#dbdbdb"></path>
                    <path d="M627.70182 587.5l-58.5-18-61.2-30.6v-69.4s46.2-29.5 52.3-73.1c2.3-0.1 4.7-0.3 7.6-0.7 33.3-4 57.5-85.9 57.5-85.9s1.6-38.3-18.6-38.3c-2.3 0-24.8 0.3-26.7 1l5.1-67.9 0.6-51.8s0.4-141.1-172.2-142.7C234.40182 11.6 268.00182 87.5 268.00182 87.5c0 0.2 0.1 0.3 0.1 0.5-22.3 12.8-33.6 32.5-33.6 72.7 0 87.4 11 118.8 11 118.8l-25.2-8s-28.9 2.9-26.4 36.6c2.5 33.8 30.9 83.5 64.2 87.5 2.5 0.3 4.7 0.5 6.7 0.6 0.1 53.2 46.7 74.5 46.7 74.5l0.4 66.3-62.4 32.2-184.4 58.4S-0.39818 647.3 0.00182 729.9l1.3 101.5h533.2c-1.6-12.1-3.7-24.2-3.7-36.8 0-83.3 38.1-157 96.9-207.1z"  fill="#dbdbdb"></path>
                </svg>
                <div class="bt_top" id="goUserManager" style="color:white" >用户管理</div>
              <%--  <img class="bt_top" src="Images/user.png" style="height:25px;width:25px;padding-bottom: 15px;"/>--%>
             </div>
            <div class="function_top">   
                 <svg viewBox="0 0 1024 1024" version="1.1" id="userName" class="bt_toptp" width="32" height="32">
                    <path d="M512 960c-80 0-160 0.1-240-0.1-25-0.1-50-5-70-20-35-20-55-50-60-90-4-30-2-60 0-90 3-40 10-80 20-120 10-30 25-60 45-85 25-30 60-45 95-50 10-1 20 2 30 8 15 10 30 20 50 30 35 20 75 35 120 35 45-0.5 85-15 125-40 15-8 25-15 40-25 10-8 20-10 35-10 30 4 60 15 85 40 20 20 30 40 45 65 15 35 20 70 25 110 5 40 8 80 7 120-1 35-10 65-30 90-20 20-45 35-70 40-10 2-20 3-35 3C680 960 600 960 512 960z" fill="#dbdbdb"/>
                    <path d="M288 288c-2-120 105-220 225-220 120 0 220 100 220 225-1 120-100 220-225 220C390 510 290 410 288 288z" fill="#dbdbdb"/>
                </svg>
                <div class="bt_top" runat="server" id="userName" style="color:white"></div>
            </div>
        </div>

         <%-- <nav class="vertical-nav">
        <ul>
            <li class="nav-item active">
                <a href="#" class="nav-link">首页</a>
            </li>
            
            <li class="nav-item has-submenu">
                <a href="#" class="nav-link">采购</a>
                <ul class="sub-nav">
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购单</a></li>
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购单</a></li>
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购退货单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购换货单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购明细</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购退货单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购商品统计</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购金额统计</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">采购波动分析</a></li>
                 
                </ul>
            </li>
            
            <li class="nav-item has-submenu">
                <a href="#" class="nav-link">销售</a>
                <ul class="sub-nav">
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售单</a></li>
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售退货单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售换货单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售明细</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售出库单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售产品统计</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售金额统计</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">销售波动分析</a></li>
                </ul>
            </li>
            
            <li class="nav-item has-submenu">
                <a href="#" class="nav-link">库存</a>
                <ul class="sub-nav">
                   <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存数额查询</a></li>
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存调拨单</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">其他入库</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">其他出库</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存费用分摊</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存盘点</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存盘点记录</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存调货统计</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存变动统计</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">库存积压统计</a></li>
                </ul>
            </li>

            <li class="nav-item has-submenu">
                <a href="#" class="nav-link">期初</a>
                <ul class="sub-nav">
                   <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">期初商品数量</a></li>
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">期初商品金额</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">期初应收应付</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">期初收支账户</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">期初资产负债</a></li>
            
                </ul>
            </li>

            <li class="nav-item has-submenu">
                <a href="#" class="nav-link">资料</a>
                <ul class="sub-nav">
                   <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">商品信息</a></li>
                    <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">客户资料</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">供应商资料</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">物流资料</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">员工资料</a></li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">仓库资料</a></li>
                        <li class="sub-nav-item has-submenu">
                        <a href="#" class="nav-link">打印单模板</a>
                        <ul class="sub-sub-nav">
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">采购打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">采购入库打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">采购退货打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">采购换货打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">销售打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">销售退货打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">销售换货打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">库存调拨打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">其他出库打印单</a></li>
                            <li class="sub-sub-nav-item"><a href="#" class="nav-link">其他入库打印单</a></li>
                           
                        </ul>
                    </li>
                     <li class="sub-nav-item has-submenu"><a href="#" class="nav-link">支付方式</a></li>
                </ul>
            </li>

        </ul>
    </nav>--%>


        <div class="main-div">
            <div class="daohang">
                
            <div class="leftNav" >

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
                <div class="anniu">
                    <button type="button" class="bt_dao" onclick="daoyinClick()"><</button>
                </div>
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
