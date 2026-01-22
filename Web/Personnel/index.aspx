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
                    $("#userFun_div").animate( 200, "swing");
                },
                function () {
                    $("#userFun_div").animate( 200, "swing", function () {
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

        function setmarqueetext(text) {
            var marqueetext = document.getElementById("marqueeText");
            if (marqueetext) {
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

        function yinClick() {
            console.log("jinrufangfa :");
            document.querySelector('.carousel-container').classList.add('hidden');  // 隐藏顶部元素
        }
        function tanClick() {
            document.querySelector('.carousel-index').classList.add('hidden');  // 隐藏弹窗元素
        }



        // 直接使用全局变量 pushNewsData
        function displayNewsData() {
            if (typeof pushNewsData !== 'undefined' && pushNewsData.length > 0) {
                pushnewsarr = pushNewsData
                textboxValue = pushnewsarr[0].textbox;
                jsonData = pushnewsarr[0].tptop1;
                tankuan = pushnewsarr[0].xuankuan;
                dinggao = pushnewsarr[0].topgao || "100";

                if (pushnewsarr[0].beizhu3 && pushnewsarr[0].beizhu3.trim() !== "") {
                    var headerTitle = document.querySelector('.logo');
                    if (headerTitle) {
                        headerTitle.textContent = pushnewsarr[0].beizhu3.trim();
                    }
                }

                if (pushnewsarr[0].beizhu2 && pushnewsarr[0].beizhu2.trim() !== "") {
                    var logoImage = "data:image/jpg;base64," + pushnewsarr[0].beizhu2;
                    var logoImg = document.querySelector('a[href="http://www.yhocn.cn"] img.logo1');

                    if (logoImg) {
                        logoImg.src = logoImage;
                        console.log("Logo图片已替换为base64图片");
                    } else {
                        console.log("未找到目标logo图片元素");
                    }
                }

                if (pushnewsarr && pushnewsarr.length > 0 && pushnewsarr[0].beizhu1 && pushnewsarr[0].beizhu1.trim() === "隐藏广告" || !pushnewsarr || pushnewsarr.length === 0) {

                    // 隐藏两个div
                    var carouselContainer = document.querySelector('.carousel-container');
                    var carouselIndex = document.querySelector('.carousel-index');

                    if (carouselContainer) carouselContainer.style.display = 'none';
                    if (carouselIndex) carouselIndex.style.display = 'none';

                    // 直接返回，不执行后续逻辑
                    return;
                }


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
                        url: images[0].tptop2,
                        alt: "图1"
                    },
                    {
                        url: images[1].tptop3,
                        alt: "图2"
                    },
                    {
                        url: images[2].tptop4,
                        alt: "图3"
                    },
                    {
                        url: images[3].tptop5,
                        alt: "图4"
                    },
                    {
                        url: images[4].tptop6,
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

                setmarqueetext(textboxValue);

                var targetImg = document.querySelector('.index-images img');

                if (targetImg && xuantu[0].tptop1) {
                    targetImg.src = xuantu[0].tptop1;
                }

                document.documentElement.style.setProperty('--tankuan', tankuan + "px");
                document.documentElement.style.setProperty('--dinggao', dinggao + "px")
            } else {
                console.warn("没有获取到数据或数据为空");
            }
        }

        if (window.addEventListener) {
            window.addEventListener('DOMContentLoaded', displayNewsData, false);
        } else if (window.attachEvent) {
            window.attachEvent('onload', displayNewsData);
        }


    </script>
    <style>
        #userFun_div
        {
            /*display: flex;
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
            border-radius: 2px;*/
            display: none; /* 添加这行 */
            position: absolute;
            width: 120px;
            height: 150px;
            right: 50px;
            background-color: white;
            z-index: 9999;
            box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04);
            flex-direction: column;
            justify-content: center;
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
            /*height: 100%;*/
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
                max-width: 30%; /* 移除最大宽度限制 */
                overflow: hidden;
                margin: 0 10px;
                position: relative;
                height: 36px; /* 增加高度 */
                background: linear-gradient(
                    135deg, 
                    rgba(46, 139, 87, 0.3) 0%, 
                    rgba(60, 179, 113, 0.3) 30%, 
                    rgba(79, 206, 123, 0.3) 70%, 
                    rgba(102, 217, 143, 0.3) 100%
                );
                border-radius: 18px; /* 增加圆角 */
                padding: 0 15px;
                display: flex;
                align-items: center;
                box-shadow: 0 2px 8px rgba(46, 139, 87, 0.2);
                border: 1px solid rgba(255, 255, 255, 0.2);
            }

            .marquee-content {
                color: white;
                white-space: nowrap;
                position: absolute;
                animation: marquee 25s linear infinite; /* 减慢速度 */
                font-size: 14px;
                font-weight: 500;
                text-shadow: 0 1px 2px rgba(0, 0, 0, 0.3);
                padding-right: 50px; /* 增加右侧内边距 */
                min-width: max-content; /* 确保内容完整显示 */
            }

            @keyframes marquee {
                0% { transform: translateX(100%); }
                100% { transform: translateX(-100%); }
            }

            .scrolling-container {
                width: 200px; /* 增加宽度 */
                height: 36px; /* 增加高度 */
                overflow: hidden;
                white-space: nowrap;
                background: linear-gradient(
                    135deg, 
                    rgba(46, 139, 87, 0.25) 0%, 
                    rgba(60, 179, 113, 0.25) 100%
                );
                border-radius: 18px; /* 增加圆角 */
                position: relative;
                float: center;
                box-shadow: 0 2px 6px rgba(46, 139, 87, 0.15);
                border: 1px solid rgba(255, 255, 255, 0.15);
            }

            .scrolling-text {
                position: absolute;
                right: 0;
                color: white;
                font-weight: 500;
                padding: 8px 15px; /* 增加内边距 */
                text-shadow: 0 1px 2px rgba(0, 0, 0, 0.3);
                white-space: nowrap;
                animation: scroll-text 10s linear infinite; /* 添加动画 */
            }

            @keyframes scroll-text {
                0% { transform: translateX(100%); }
                100% { transform: translateX(-100%); }
            }


        #Iframe1 {
            height:100%;
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
        .hidden {
            display: none;
        }

        .header_login_info_con {
            background: linear-gradient(to right, #160a8d 0%, #3b4dcb 50%, #5a5fdd 100%);
            box-shadow: 0 4px 12px rgba(46, 139, 87, 0.2);
        }

        .bt-in {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white !important;
            text-decoration: none;
            padding: 8px 16px;
            border-radius: 20px;
            font-weight: 500;
            font-size: 14px;
            transition: all 0.3s ease;
            box-shadow: 0 2px 6px rgba(46, 139, 87, 0.3);
            border: 1px solid rgba(255, 255, 255, 0.3);
            margin-right: 15px;
            min-width: 100px;
            text-align: center;
        }

        .bt-in:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            transform: translateY(-2px);
            box-shadow: 0 4px 10px rgba(46, 139, 87, 0.4);
            color: white !important;
            text-decoration: none;
        }

        .bt-in:active {
            transform: translateY(0);
            box-shadow: 0 1px 3px rgba(46, 139, 87, 0.3);
        }

        /* 响应式调整 */
        @media (max-width: 768px) {
            .bt-in {
                margin-right: 10px;
                margin-bottom: 8px;
                padding: 6px 12px;
                min-width: 80px;
                font-size: 13px;
            }
        }

      

    </style>
     <div class="carousel-container">
            <button type="button" class="clean-btn-div" onclick="yinClick()">×</button>
            <div class="carousel-images" id="carouselImages"></div>
        </div>

        <div class="carousel-index">
            <button type="button" class="index-btn-div" onclick="tanClick()">×</button>
            <div class="index-images">
                <div class="index-item" id="Div1">
                    <img src="" alt="图5">
                </div>
            </div>
         </div>
    <form id="form1" runat="server" style="height:100%">
        
        <div class="header_login_info_con">
            <div style="width:23%">
                <a href="http://www.yhocn.cn" target="_blank"> 
                    <img class="logo1" src="../Personnel/images/tm_logo.png" style="float: left; margin-top: -1%; height: 67px;" />
                </a>
                <div class="logo" style="color:white">云合人事管理系统</div>
            </div>
            <div class="marquee-container">
                <div class="marquee-content" id="marqueeText">
                    这是一段需要循环滚动的长文本内容，当文本完全滚动出容器后，会从右侧重新开始滚动...
                </div>
            </div>
            <div style="margin-left:1%">
                <a style="color:white;margin-right:20px" href="../Personnel/downloadApp.aspx" class="fl welcome_info bt-in">
                    <svg viewBox="0 0 1024 1024" version="1.1" class="bt_toptp" width="20" height="20">
                    <path d="M755.8 0H268.2C214.4 0 170.7 45.8 170.7 102.4v819.2c0 56.6 43.7 102.4 97.5 102.4h487.6c53.8 0 97.5-45.8 97.5-102.4V102.4C853.3 45.8 809.6 0 755.8 0zM512 972.8a52.1 52.1 0 0 1-51.2-51.2c0-28.2 24.2-51.2 51.2-51.2s51.2 23 51.2 51.2a52.1 52.1 0 0 1-51.2 51.2zm243.8-153.6H268.2V102.4h487.6v716.8z" fill="#dbdbdb"></path>
                </svg>
                    &nbsp;下载APP</a>
                <a style="color:white" href="../Personnel/downloadExcel.aspx" class="fl welcome_info bt-in">
                <svg viewBox="0 0 1024 1024" version="1.1" class="bt_toptp"  width="20" height="20"> <path d="M913.6 16H172c-47.2 0-85.6 38.4-85.6 85.6v176H76c-28.8 0-52 23.2-52 52v323.2c0 28 23.2 51.2 52 51.2h10.4v196.8c0 47.2 38.4 85.6 85.6 85.6h551.2v-64H172c-11.2 0-21.6-9.6-21.6-21.6V704h248c28.8 0 52-23.2 52-52V329.6c0-28.8-23.2-52-52-52h-248v-176C150.4 90.4 160 80 172 80h741.6c11.2 0 21.6 9.6 21.6 21.6V496h64V101.6c-0.8-47.2-38.4-85.6-85.6-85.6z m-712 380.8l35.2 45.6 36-45.6h80c-0.8 2.4-2.4 4.8-4 7.2l-71.2 91.2 69.6 89.6h-81.6l-28.8-37.6-29.6 37.6h-80.8l24-31.2 45.6-59.2-45.6-59.2-24.8-32c-1.6-1.6-2.4-4-4-6.4h80z" fill="#e6e6e6"></path> <path d="M863.2 356h-280c-17.6 0-32-14.4-32-32s14.4-32 32-32h280c17.6 0 32 14.4 32 32s-14.4 32-32 32z m0 172h-280c-17.6 0-32-14.4-32-32s14.4-32 32-32h280c17.6 0 32 14.4 32 32s-14.4 32-32 32z m-144 171.2h-136c-17.6 0-32-14.4-32-32s14.4-32 32-32h136c17.6 0 32 14.4 32 32s-14.4 32-32 32z" fill="#e6e6e6"></path> <path d="M1016 793.6H902.4V594.4H783.2v199.2H669.6l172.8 192z" fill="#e6e6e6"></path> </svg>

                    &nbsp;下载Excel</a>
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
            <div class="leftNav1">
                <ul class="left1_ul">
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/kaoqin.aspx','考勤')" title="1-31代表每个月的天数，&#10;“卡”代表当天打卡，&#10;“休”代表当天休息，&#10;“假”代表当天请假。">考勤<img src="../Personnel/images/kaoqinjilu.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/renyuanxinxi.aspx','人员信息管理')">人员信息管理<img src="../Personnel/images/renyuanxinxiguanli.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/gongzimingxi.aspx','工资明细')" title="加班费=加班时间*配置表加班费,缺勤扣款=缺勤天数*配置表缺勤扣款,迟到扣款=迟到*配置表迟到扣款,个人医疗=基本工资*配置表个人医疗,个人公积金=基本工资*配置表个人公积金,个人年金=基本工资*配置表个人年金,企业养老=基本工资*配置表企业养老,企业失业=基本工资*配置表企业失业,企业医疗=基本工资*配置表企业医疗,企业工伤=基本工资*配置表企业工伤,企业生育=基本工资*配置表企业生育,企业公积金=基本工资*配置表企业公积金,企业年金=基本工资*配置表企业年金,个人养老=基本工资*配置表个人养老,个人失业=基本工资*配置表个人失业,税前工资=基本工资+绩效工资,税率小于等于5000为0.1,应税工资 =税前工资 -税前工资 * 税率,代扣个人所得税 = 税前工资* 税率,个人小计 = 基本工资 +绩效工资 + 个人医疗 + 个人生育+ 个人公积金 + 个人年金4% + 个人养老 + 个人失业,企业小计 = 企业养老+ 企业失业 + 企业医疗 + 企业工伤 +企业生育 +企业公积金 + 企业年金,实发工资 = 应税工资-基本工资 + 绩效工资 + 个人医疗 + 个人生育 + 个人公积金 + 个人年金4% + 个人养老 + 个人失业,应发工资 = 实发工资">工资明细<img src="../Personnel/images/gongzimingxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/kaoqinjilu.aspx','考勤记录')">考勤记录<img src="../Personnel/images/kaoqinjilu.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/peizhi.aspx','配置表')">配置表<img src="../Personnel/images/shezhi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/baopan.aspx','报盘')">报盘<img src="../Personnel/images/baopan.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/shenpi.aspx','审批记录')">审批记录<img src="../Personnel/images/baopan.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/baoshui.aspx','报税')">报税<img src="../Personnel/images/baoshui.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/bumenhuizong.aspx','部门汇总')" title="根据部门名称计算每一列的和">部门汇总<img src="../Personnel/images/bumenhuizong.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/shebao.aspx','社保')" title="根据部门计算每个列的和 ">社保<img src="../Personnel/images/shebao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/gerenxinxi.aspx','员工档案')">员工档案<img src="../Personnel/images/gerenxinxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/birthday.aspx','生日提醒')">生日提醒<img src="../Personnel/images/gerenxinxi.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/gerensuode.aspx','个人所得税')" title="计税工资=(应税工资*税率)的和,记录该条数据有几条,个人所得税=(代扣个人所得税*税率)的和">个人所得税<img src="../Personnel/images/gerensuodeshui.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/gongzitiao.aspx','工资条')">工资条<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/jianli.aspx','简历管理')">简历管理<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/mianshiguanli.aspx','面试管理')">面试管理<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/jianlishenpi.aspx','简历审批')">简历审批<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/lizhishenpi.aspx','离职审批')">离职审批<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/lizhishenqing.aspx','离职申请')">离职申请<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/qingjiashenpi.aspx','请假审批')">请假审批<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/dongtaigzmingxi.aspx','动态工资明细')">动态工资明细<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/gongzuoshijian.aspx','工作时间')">工作时间<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/qiandao.aspx','签到')">签到<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/tongjitu.aspx','统计图')">统计图<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                    <li><a href="#" class="leftNav1_li" onclick="a('../Personnel/shuomingshu.aspx','使用说明')">下载使用说明<img src="../Personnel/images/gongzitiao.png" style="float: right;height: 50%;" /></a></li>
                </ul>
            </div>
        
            <div class="div_iframe">
                <iframe id="Iframe2" class="Iframe" name="ifrMain" src="../Personnel/wuquanxian.aspx?1" ></iframe>
            </div>
        </div>
        
        </form>
</body>
</html>

