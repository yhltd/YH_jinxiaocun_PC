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

    tolink({
        url: 'chart.aspx'
    })
})

var left_data = [{
    text: '基本信息',
    children: [{
        text: '科目总账',
        url: 'subject_ledger.aspx'
    }, {
        text: '开支项目',
        url: 'items.aspx'
    }, {
        text: '部门设置',
        url: 'department.aspx'
    }, {
        text: '账号管理',
        url: 'user_management.aspx'
    }]
}, {
    text: '凭证处理',
    state: 'open',
    children: [{
        text: '凭证汇总',
        url: 'voucherSummary.aspx',
    }, {
        text: '智能看板',
        url: 'chart.aspx',
        selected: true
    }]
}, {
    text: '各类报表',
    children: [{
        text: '现金流量',
        url: 'flow.aspx'
    }, {
        text: '资产负债',
        url: 'liabilities.aspx'
    }, {
        text: '利益损益',
        url: 'profit.aspx'
    }]
}, {
    text: '极简财务',
    children: [{
        text: '极简台账',
        url: 'simpleData.aspx'
    }, {
        text: '极简总账',
        url: 'simpleAccounting.aspx'
    }, {
        text: '使用说明',
        url: 'instructions.aspx'
    }, {
        text: '数据空间',
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