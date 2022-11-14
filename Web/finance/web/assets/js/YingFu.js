var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        accounting: ''
    }
}

$(function () {
    $("#kehu").combobox({
        valueField: 'kehu',
        textField: 'kehu',
    })
    getKehuPeizhi('kehu');
    var list = {};
    setTable(list);
})

function getList() {
    var kehu = $('#kehu').val();
    var ks = $("#ks").datebox('getText');
    var js = $("#js").datebox('getText');
    if (ks == "") {
        ks = "1900/1/1"
    }
    if (js == "") {
        js = "2200/1/1"
    }
    $.ajax({
        type: 'Post',
        url: "web_service/shouFuBaoBiao.asmx/getYF",
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
            kehu: kehu,
            ks: ks,
            js: js,
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

//设置表格信息
function setTable(data) {
    $('#data-table').datagrid({
        data: data,
        //height: 470,
        columns: [[
            { field: 'kehu', align: 'center', title: '往来单位', width: 150 },
            { field: 'project', align: 'center', title: '项目', width: 150 },
            { field: 'zhaiyao', align: 'center', title: '摘要', width: 150 },
            { field: 'jine1', align: 'center', title: '应付', width: 150 },
            //{ field: '', align: 'center', title: '', width: 30 },
            { field: 'unit', align: 'center', title: '往来单位', width: 150 },
            { field: 'invoice_type', align: 'center', title: '发票种类', width: 150 },
            { field: 'invoice_no', align: 'center', title: '发票号', width: 150 },
            { field: 'jine2', align: 'center', title: '金额', width: 150 },
        ]]
    })
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

function toExcel() {
    var kehu = $('#kehu').val();
    var ks = $("#ks").datebox('getText');
    var js = $("#js").datebox('getText');
    if (ks == "") {
        ks = "1900/1/1"
    }
    if (js == "") {
        js = "2200/1/1"
    }
    $.ajax({
        type: 'Post',
        url: "web_service/shouFuBaoBiao.asmx/getYF",
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
            kehu: kehu,
            ks: ks,
            js: js,
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        kehu: array[i].kehu,
                        project: array[i].project,
                        zhaiyao: array[i].zhaiyao,
                        jine1: array[i].jine1,
                        unit: array[i].unit,
                        invoice_type: array[i].invoice_type,
                        invoice_no: array[i].invoice_no,
                        jine2: array[i].jine2,
                    }
                    header.push(body)
                }
                console.log(header)
                title = ['往来单位', '项目', '摘要', '应付', '往来单位', '发票种类', '发票号', '金额']
                JSONToExcelConvertor(header, "应付报表", title)
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
