var items = [
    {
        text: "录入模块",
        hid: true,
        item: [
            { text: "考勤表", src: "../Personnel/kaoqin.aspx", choice: false },
            { text: "人员信息管理", src: "../Personnel/renyuanxinxi.aspx", choice: false },
            { text: "工资明细", src: "../Personnel/gongzimingxi.aspx", choice: false },
            { text: "考勤记录", src: "../Personnel/kaoqinjilu.aspx", choice: false }
        ]
    },
    {
        text: "配置模块",
        hid: true,
        item: [
            { text: "配置表", src: "../Personnel/peizhi.aspx", choice: false }
        ]
    },
    {
        text: "输入模块",
        hid: true,
        item: [
            { text: "报盘", src: "../Personnel/baopan.aspx", choice: false },
            { text: "报税", src: "../Personnel/baoshui.aspx", choice: false },
            { text: "部门汇总", src: "../Personnel/bumenhuizong.aspx", choice: false },
            { text: "社保", src: "../Personnel/shebao.aspx", choice: false },
            { text: "个人信息", src: "../Personnel/gerenxinxi.aspx", choice: false },
            { text: "个人所得税", src: "../Personnel/gerensuode.aspx", choice: false },
            { text: "工资条", src: "../Personnel/gongzitiao.aspx", choice: false }
        ]
    }
]

$(function () {
    append()
})

function append() {
    var insert = "";
    for (var i = 0; i < items.length; i++) {
        insert += "<div class='items'>"
        insert += "<div class = 'items_header'><a class='items_a' rel=" + i + ">" + items[i].text + "</a></div>";
        insert += "<div class='item_div' style='display:none'>"
        for (var j = 0; j < items[i].item.length; j++) {
            insert += "<div class='item_out' name='item'><a rel='" + i + ":" + items[i].item[j].src + ":" + j + "'>" + items[i].item[j].text + "</a></div>"
        }
        insert += "</div></div>"

        $(".firstdiv").append(insert)
        insert = "";
    }

    $(".items .items_header").click(function () {
        var index = $(this).children("a").attr("rel")
        var hid = items[index].hid;
        if (hid) {
            $(".item_div").not($(this).next()).css("display", "none")
            for (var i = 0; i < items.length; i++) {
                items[i].hid = true
            }
            $(this).next().css("display", "block")
            items[index].hid = false
        } else {
            $(this).next().css("display", "none")
            items[index].hid = true
        }

    })

    $(".items .items_header").mouseover(function () {
        $(this).css("cursor", "pointer")
    })

    $(".items .items_header").mouseout(function () {
        $(this).css("cursor", "default ")
    })

    $("[name='item'] a").mouseover(function () {
        var resArr = $(this).attr("rel").split(":")
        var items_index = resArr[0]
        var index = resArr[2]
        if (items[items_index].item[index].choice) {
            return;
        }
        $(this).parent().attr("class", "item_over")
    })

    $("[name='item'] a").mouseout(function () {
        var resArr = $(this).attr("rel").split(":")
        var items_index = resArr[0]
        var index = resArr[2]
        if (items[items_index].item[index].choice) {
            return;
        }
        $(this).parent().attr("class", "item_out")
    })

    $("[name='item'] a").click(function () {
        var resArr = $(this).attr("rel").split(":")
        var items_index = resArr[0]
        var url = resArr[1]
        var index = resArr[2]

        $("[name='item']").not($(this).parent()).attr("class", "item_out")
        for (var i = 0; i < items.length; i++) {
            for (var j = 0; j < items[i].item.length; j++) {
                items[i].item[j].choice = false
            }
        }
        $(this).parent().attr("class", "item_choice")
        items[items_index].item[index].choice = true;

        $("#Iframe2").attr("src", url)
    })
}