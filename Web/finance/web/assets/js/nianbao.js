var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    //selectParamsMap: {
    //    project: '',
    //}
}

$(function () {
    getList();
})

function getList() {
    var myDate = new Date;
    var ks = myDate.getFullYear() + "-01-01";
    var js = myDate.getFullYear() + "-12-31";

    $.ajax({
        type: 'Post',
        url: "web_service/nianbao.asmx/getList",
        beforeSend: function () {
            $.messager.progress({
                title: '提示',
                msg: '正在加载',
                text: ''
            });
        },
        complete: function () {
            $.messager.progress('close');
        },
        data: {
            financePageJson: JSON.stringify(page),
            ks: ks,
            js: js
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var weishou = 0;
                var weifu = 0;
                var list = result.data;
                for (var i = 0; i < list.length; i++) {
                    weishou += list[i].receivable;
                    weifu += list[i].cope;
                }
                setTable(result.data, weishou, weifu)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}

function queryList() {
    var myDate = new Date;
    var type = $("#type").val();
    var riqi = $("#riqi").datebox('getText');
    if (riqi == "")
    {
        getList();
        return;
    }
    var ks = "";
    var js = "";
    if (type == "年")
    {
        ks = riqi.split("-")[0] + "-01-01";
        js = riqi.split("-")[0] + "-12-31";
    }
    else if (type == "月")
    {
        if (riqi.split("-")[1] == "4" || riqi.split("-")[1] == "6" || riqi.split("-")[1] == "9" || riqi.split("-")[1] == "11")
        {
            ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
            js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-30";
        }
        else if (riqi.split("-")[1] == "2") {
            ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
            js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-28";
        }
        else
        {
            ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
            js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-31";
        }
    }
    else if (type == "日")
    {
        ks = riqi;
        js = riqi;
    }
    ks = ks + " 00:00:00.000";
    js = js + " 23:59:59.000";
    $.ajax({
        type: 'Post',
        url: "web_service/nianbao.asmx/getList",
        beforeSend: function () {
            $.messager.progress({
                title: '提示',
                msg: '正在加载',
                text: ''
            });
        },
        complete: function () {
            $.messager.progress('close');
        },
        data: {
            financePageJson: JSON.stringify(page),
            ks: ks,
            js: js
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var weishou = 0;
                var weifu = 0;
                var list = result.data;
                for (var i = 0; i < list.length; i++)
                {
                    weishou += list[i].receivable;
                    weifu += list[i].cope;
                }
                setTable(result.data,weishou,weifu)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}



function setTable(data,weishou,weifu) {
    $('#data-table').datagrid({
        title: "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;未收合计：" + weishou + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;未付合计:" + weifu,
        fitColumns: false,
        data: data,
        height: 470,
        columns: [[
            { field: 'zhaiyao1', align: 'center', title: '摘要', width: 200 },
            { field: 'kehu1', align: 'center', title: '客户/供应商', width: 200 },
            { field: 'receivable', align: 'center', title: '未收', width: 115 },
		    { field: 'zhaiyao2', align: 'center', title: '摘要', width: 200 },
            { field: 'kehu2', align: 'center', title: '客户/供应商', width: 200 },
            { field: 'cope', align: 'center', title: '未付', width: 115 }
        ]]
    })

}