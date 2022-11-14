var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
}

$(function () {
    $("#kehu").combobox({
        valueField: 'kehu',
        textField: 'kehu',

    })
    getKehuPeizhi('kehu');

    var arr = {};
    setTable(arr)
})

function getList() {
    var myDate = new Date;
    var ks = $("#ks").datebox('getText');
    var js = $("#js").datebox('getText');
    var kehu = $("#kehu").val();
    if (ks == "") {
        ks="1900-1-1"
    }
    if (js == "") {
        js="2200-1-1"
    }
    $.ajax({
        type: 'Post',
        url: "web_service/subLedger.asmx/getKehuList",
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
            js: js,
            kehu:kehu,
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

function setTable(data) {
    $('#data-table').datagrid({
        fitColumns: false,
        data: data,
        //height: 470,
        columns: [[
            { field: 'insert_date', align: 'center', title: '日期', width: 200 },
            { field: 'kehu', align: 'center', title: '客户', width: 200 },
            { field: 'accounting', align: 'center', title: '科目', width: 200 },
		    { field: 'project', align: 'center', title: '项目', width: 200 },
            { field: 'ying', align: 'center', title: '应收', width: 115 },
            { field: 'shi', align: 'center', title: '实收', width: 115 },
            { field: 'wei', align: 'center', title: '未收', width: 115 },
        ]]
    })
}


function toExcel() {
    var myDate = new Date;
    var ks = $("#ks").datebox('getText');
    var js = $("#js").datebox('getText');
    var kehu = $("#kehu").val();
    if (ks = "") {
        ks = "1900-1-1"
    }
    if (js == "") {
        js = "2200-1-1"
    }

    $.ajax({
        type: 'Post',
        url: "web_service/subLedger.asmx/getKehuList",
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
            js: js,
            kehu: kehu,
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        insert_date: array[i].insert_date,
                        kehu: array[i].kehu,
                        accounting: array[i].accounting,
                        project: array[i].project,
                        ying: array[i].ying,
                        shi: array[i].shi,
                        wei: array[i].wei,
                    }
                    header.push(body)
                }
                console.log(header)
                title = ['日期', '客户', '科目', '项目', '应收', '实收','未收']
                JSONToExcelConvertor(header, "应收明细帐", title)
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

function getKehuPeizhi(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/getKehuPeizhi",
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                $('#' + id).combobox('loadData', result.data);
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}