


$(function () {
    clearCss("panel-tool")
    $(".layout-panel-west > div").css({
        "height": height*0.9-1 + "px" 
    })

    $("#north-right").click(function () {
        $(".north-right-float").toggle(200);
    })

    $("#center").css({
        "height": height * 0.9 - 1 + "px"
    })

    $(".layout-panel-west > div").css({
        "height": height * 0.9 - 1 + "px"
    })

    $(".accordion").css({
        "border": "none"
    })
    $("#north").css({
        "border-top": "none",
        "border-left": "none",
        "border-right": "none"
    })

    $("#update-pwd-btn").click(function () {
        $('#update_pwd').window({
            title: "修改密码",
            href: "update_pwd.aspx",
            width: 600,
            height: 400,
            top: 100,
            collapsible: false,
            minimizable: false,
            maximizable: false,
            closable: true,
            draggable: true,
            resizable: false,
            shadow: false,
            modal: true
        });
        $(".north-right-float").hide();
    })
    $("#update-do-btn").click(function () {
        $('#update_do').window({
            title: "修改操作密码",
            href: "update_do.aspx",
            width: 600,
            height: 400,
            top: 100,
            collapsible: false,
            minimizable: false,
            maximizable: false,
            closable: true,
            draggable: true,
            resizable: false,
            shadow: false,
            modal: true
        });
        $(".north-right-float").hide();
    })
    $("#new-user-btn").click(function () {
        $('#new_user').window({
            title: "新增用户",
            href: "new_user.aspx",
            width: 600,
            height: 400,
            top: 100,
            collapsible: false,
            minimizable: false,
            maximizable: false,
            closable: true,
            draggable: true,
            resizable: false,
            shadow: false,
            modal: true
        });
        $(".north-right-float").hide();
    })
    $("#sign-out-btn").click(function () {
        //window.open('../../../Myadmin/login.aspx')
        window.location.href = "../../../Myadmin/login.aspx";
    })

    tolink({
        url: 'chart.aspx'
    })
})

var left_data = [{
    text: '基本信息',
    iconCls: 'icon-jibenxinxi',
    children: [{
        text: '科目总账',
        iconCls: 'icon-kemuzongzhang',
        url: 'subject_ledger.aspx',
    }, {
        text: '开支项目',
        iconCls: 'icon-kaizhixiangmu',
        url: 'items.aspx'
    }, {
        text: '部门设置',
        iconCls: 'icon-bumenshezhi',
        url: 'department.aspx'
    }, {
        text: '账号管理',
        iconCls: 'icon-zhanghaoguanli',
        url: 'user_management.aspx'
    }]
}, {
    text: '凭证处理',
    iconCls: 'icon-pingzhengchuli',
    state: 'open',
    children: [{
        text: '凭证汇总',
        iconCls: 'icon-pingzhenghuizong',
        url: 'voucherSummary.aspx',
    }, {
        text: '智能看板',
        iconCls: 'icon-zhinengkanban',
        url: 'chart.aspx',
        selected: true
    }]
}, {
    text: '各类报表',
    iconCls: 'icon-geleibaobiao',
    children: [{
        text: '现金流量',
        iconCls: 'icon-xianjinliuliang',
        url: 'flow.aspx'
    }, {
        text: '资产负债',
        iconCls: 'icon-zichanfuzhai',
        url: 'liabilities.aspx'
    }, {
        text: '利益损益',
        iconCls: 'icon-liyisunyi',
        url: 'profit.aspx'
    }]
}, {
    text: '极简财务',
    iconCls: 'icon-jijiancaiwu',
    children: [{
        text: '极简配置',
        iconCls: 'icon-jijiantaizhang',
        url: 'simplePeizhi.aspx'
    }, {
        text: '极简台账',
        iconCls: 'icon-jijiantaizhang',
        url: 'simpleData.aspx'
    }, {
        text: '极简总账',
        iconCls: 'icon-jijianzongzhang',
        url: 'simpleAccounting.aspx'
    }, {
        text: '发票',
        iconCls: 'icon-jijianzongzhang',
        url: 'invoice.aspx'
    }, {
        text: '报表',
        iconCls: 'icon-jijianzongzhang',
        url: 'nianbao.aspx'
    }, {
        text: '应收明细账',
        iconCls: 'icon-jijianzongzhang',
        url: 'kehuSubLedger.aspx'
    }, {
        text: '应付明细账',
        iconCls: 'icon-jijianzongzhang',
        url: 'gysSubLedger.aspx'
    }, {
        text: '利润',
        iconCls: 'icon-jijianzongzhang',
        url: 'lirun.aspx'
    }, {
        text: '应收报表',
        iconCls: 'icon-jijianzongzhang',
        url: 'YingShou.aspx'
    }, {
        text: '应付报表',
        iconCls: 'icon-jijianzongzhang',
        url: 'YingFu.aspx'
    }, {
        text: '使用说明',
        iconCls: 'icon-shiyongshuoming',
        url: 'instructions.aspx'
    }, {
        text: '数据空间',
        iconCls: 'icon-shujukongjian',
        url: 'space.aspx'
    }]
}];


function tolink(e) {
    if (e.text == "使用说明") {
        $("#instruction-dialog").dialog({
            title: '提示',
            width: 350,
            model: false,
            toolbar: [{
                text: '下载',
                iconCls: 'icon-ok',
                handler: function () {
                    $("#main-iframe").attr("src", e.url);
                }
            }]
        })
    }else if (e.text != '数据空间') {
        $("#main-iframe").attr("src", e.url);
    } else {
        getInstruction();
    }
}

function getInstruction() {
    ajaxUtil({
        url: "web_service/space.asmx/getSpace",
        loading: true
    }, function (result) {
        if (result.code == 200) {
            alert(result.msg);
        }
    })
}


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
    setmarqueetext(textboxValue);

});

function getPushNews() {
    var savedCompany = localStorage.getItem('savedCompany') || '';

    $.ajax({
        type: "POST",
        url: "web_service/space.asmx/GetPushNewsData",
        data: JSON.stringify({
            companyName: savedCompany  // 传递公司名称参数
        }),
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
                    console.log(" 返回数据tankuan", tankuan);
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

                    if (pushnewsarr && pushnewsarr.length > 0 && pushnewsarr[0].beizhu1 && pushnewsarr[0].beizhu1.trim() === "隐藏广告") {

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
    document.querySelector('.carousel-container').classList.add('hidden');  // 隐藏顶部元素
}
function tanClick() {
    document.querySelector('.carousel-index').classList.add('hidden');  // 隐藏弹窗元素
}
