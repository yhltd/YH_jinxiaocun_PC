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
    var benqi_ks = $("#ks").datebox('getText');
    var benqi_js = $("#js").datebox('getText');
    var bennian_ks = "";
    var bennian_js = "";

    if (benqi_ks == "") {
        benqi_ks = myDate.getFullYear() + "-01-01";
        bennian_ks = myDate.getFullYear() + "-01-01";
    }
    else {
        bennian_ks = benqi_ks.split("-")[0] + "-01-01";
    }
    if (benqi_js == "") {
        benqi_js = myDate.getFullYear() + "-12-31";
        bennian_js = myDate.getFullYear() + "-12-31";
    } else {
        bennian_js = benqi_js.split("-")[0] + "-12-31";
    }

    if (benqi_js.split("-")[0] != benqi_ks.split("-")[0]) {
        alert("不允许跨年查询！")
        return;
    }

    $.ajax({
        type: 'Post',
        url: "web_service/lirun.asmx/getList",
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
            benqi_ks:benqi_ks,
            benqi_js:benqi_js,
            bennian_ks:bennian_ks,
            bennian_js: bennian_js,
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                setTable(result.data)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}


function setTable(data, weishou, weifu) {
    $('#data-table').datagrid({
        fitColumns: false,
        data: data,
        height: 470,
        columns: [[
            { field: 'accounting', align: 'center', title: '项目/科目', width: 400 },
            { field: 'benqi', align: 'center', title: '本期金额', width: 200 },
            { field: 'bennian', align: 'center', title: '本年累计', width: 200 },
		    { field: 'shangqi', align: 'center', title: '上期金额', width: 200 },
        ]]
    })
}


function toExcel() {
    var myDate = new Date;
    var benqi_ks = $("#ks").datebox('getText');
    var benqi_js = $("#js").datebox('getText');
    var bennian_ks = "";
    var bennian_js = "";

    if (benqi_ks == "") {
        benqi_ks = myDate.getFullYear() + "-01-01";
        bennian_ks = myDate.getFullYear() + "-01-01";
    }
    else {
        bennian_ks = benqi_ks.split("-")[0] + "-01-01";
    }
    if (benqi_js == "") {
        benqi_js = myDate.getFullYear() + "-12-31";
        bennian_js = myDate.getFullYear() + "-12-31";
    } else {
        bennian_js = benqi_js.split("-")[0] + "-12-31";
    }

    if (benqi_js.split("-")[0] != benqi_ks.split("-")[0]) {
        alert("不允许跨年查询！")
        return;
    }

    $.ajax({
        type: 'Post',
        url: "web_service/lirun.asmx/getList",
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
            benqi_ks: benqi_ks,
            benqi_js: benqi_js,
            bennian_ks: bennian_ks,
            bennian_js: bennian_js,
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        accounting: array[i].accounting,
                        benqi: array[i].benqi,
                        bennian: array[i].bennian,
                        shangqi: array[i].shangqi,
                    }
                    header.push(body)
                }
                console.log(header)
                title = ['项目/科目', '本期金额', '本年累计', '上期金额']
                JSONToExcelConvertor(header, "利润", title)
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

