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
        text: '下载APP',
        iconCls: 'icon-shiyongshuoming',
        url: 'downloadApp.aspx'
    }, {
        text: '下载Excel',
        iconCls: 'icon-shiyongshuoming',
        url: 'downloadExcel.aspx'
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