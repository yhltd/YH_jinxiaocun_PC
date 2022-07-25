var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
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
        if (riqi.split("-")[1] == "04" || riqi.split("-")[1] == "06" || riqi.split("-")[1] == "09" || riqi.split("-")[1] == "11")
        {
            ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
            js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-30";
        }
        else if (riqi.split("-")[1] == "02") {
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


function toExcel() {
    var myDate = new Date;
    var type = $("#type").val();
    var riqi = $("#riqi").datebox('getText');
    var ks = "";
    var js = "";
    if (riqi == "") {
        var ks = myDate.getFullYear() + "-01-01";
        var js = myDate.getFullYear() + "-12-31";
    } else {
        if (type == "年") {
            ks = riqi.split("-")[0] + "-01-01";
            js = riqi.split("-")[0] + "-12-31";
        }
        else if (type == "月") {
            if (riqi.split("-")[1] == "04" || riqi.split("-")[1] == "06" || riqi.split("-")[1] == "09" || riqi.split("-")[1] == "11") {
                ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
                js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-30";
            }
            else if (riqi.split("-")[1] == "02") {
                ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
                js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-28";
            }
            else {
                ks = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-01";
                js = riqi.split("-")[0] + "-" + riqi.split("-")[1] + "-31";
            }
        }
        else if (type == "日") {
            ks = riqi;
            js = riqi;
        }
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
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        zhaiyao1: array[i].zhaiyao1,
                        kehu1: array[i].kehu1,
                        receivable: array[i].receivable,
                        zhaiyao2: array[i].zhaiyao2,
                        kehu2: array[i].kehu2,
                        cope: array[i].cope,
                    }
                    header.push(body)
                }
                console.log(header)
                title = ['摘要', '客户/供应商', '未收', '摘要', '客户/供应商', '未付']
                JSONToExcelConvertor(header, "报表", title)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}

function JSONToExcelConvertor(JSONData, FileName, title, filter) {
    if (!JSONData)
        return;
    //转化json为object
    var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;

    var excel = "<table>";

    //设置表头  
    var row = "<tr>";

    if (title) {
        //使用标题项
        for (var i in title) {
            row += "<th align='center'>" + title[i] + '</th>';
        }

    }
    else {
        //不使用标题项
        for (var i in arrData[0]) {
            row += "<th align='center'>" + i + '</th>';
        }
    }

    excel += row + "</tr>";

    //设置数据  
    for (var i = 0; i < arrData.length; i++) {
        var row = "<tr>";

        for (var index in arrData[i]) {
            //判断是否有过滤行
            if (filter) {
                if (filter.indexOf(index) == -1) {
                    var value = arrData[i][index] == null ? "" : arrData[i][index];
                    row += '<td>' + value + '</td>';
                }
            }
            else {
                var value = arrData[i][index] == null ? "" : arrData[i][index];
                row += "<td align='center'>" + value + "</td>";
            }
        }

        excel += row + "</tr>";
    }

    excel += "</table>";

    var excelFile = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>";
    excelFile += '<meta http-equiv="content-type" content="application/vnd.ms-excel; charset=UTF-8">';
    excelFile += '<meta http-equiv="content-type" content="application/vnd.ms-excel';
    excelFile += '; charset=UTF-8">';
    excelFile += "<head>";
    excelFile += "<!--[if gte mso 9]>";
    excelFile += "<xml>";
    excelFile += "<x:ExcelWorkbook>";
    excelFile += "<x:ExcelWorksheets>";
    excelFile += "<x:ExcelWorksheet>";
    excelFile += "<x:Name>";
    excelFile += "{worksheet}";
    excelFile += "</x:Name>";
    excelFile += "<x:WorksheetOptions>";
    excelFile += "<x:DisplayGridlines/>";
    excelFile += "</x:WorksheetOptions>";
    excelFile += "</x:ExcelWorksheet>";
    excelFile += "</x:ExcelWorksheets>";
    excelFile += "</x:ExcelWorkbook>";
    excelFile += "</xml>";
    excelFile += "<![endif]-->";
    excelFile += "</head>";
    excelFile += "<body>";
    excelFile += excel;
    excelFile += "</body>";
    excelFile += "</html>";


    var uri = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(excelFile);

    var link = document.createElement("a");
    link.href = uri;

    link.style = "visibility:hidden";
    link.download = FileName + ".xls";

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}