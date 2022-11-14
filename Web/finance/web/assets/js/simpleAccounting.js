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
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.jjzz_select == "是") {
                $("#kehu").combobox({
                    valueField: 'kehu',
                    textField: 'kehu',
                })
                getKehuPeizhi('kehu');
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
})

function selectBtn() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.jjzz_select == "是") {
                page.selectParamsMap.accounting = $("#accounting").textbox('getText');
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}

function getList() {
    var kehu = $('#kehu').val();
    var project = $('#project').val();
    $.ajax({
        type: 'Post',
        url: "web_service/simpleAccounting.asmx/getZongZhang",
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
            project: project,
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
            { field: 'kehu', align: 'center', title: '客户/供应商', width: 250 },
            { field: 'project', align: 'center', title: '项目', width: 250 },
            { field: 'receivable', align: 'center', title: '应收', width: 150 },
            { field: 'receipts', align: 'center', title: '实收', width: 150 },
            {
                field: 'uncollected', align: 'center', title: '未收', width: 150, formatter: function (value, row, index) {
                    return row.receivable - row.receipts;
                }
            },
            { field: 'cope', align: 'center', title: '应付', width: 150 },
            { field: 'payment', align: 'center', title: '实付', width: 150 },
            {
                field: 'paid', align: 'center', title: '未付', width: 100, formatter: function (value, row, index) {
                    return row.cope - row.payment;
                }
            },
        ]]
    })

    $("#data-page").pagination({
        total: data.total,
        pageSize: data.pageSize,
        onSelectPage: function (pageNumber, pageSize) {
            page.currentPage = pageNumber;
            page.pageSize = pageSize;
            getList()
        },
        onRefresh: function (pageNumber, pageSize) {
            page.currentPage = pageNumber;
            page.pageSize = pageSize;
        }
    })
}

function toExcel() {
    var kehu = $('#kehu').val();
    var project = $('#project').val();
    $.ajax({
        type: 'Post',
        url: "web_service/simpleAccounting.asmx/getZongZhang",
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
            project: project,
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
                        receivable: array[i].receivable,
                        receipts: array[i].receipts,
                        uncollected: array[i].receivable - array[i].receipts,
                        cope: array[i].cope,
                        payment: array[i].payment,
                        paid: array[i].cope - array[i].payment,
                    }
                    header.push(body)
                }
                console.log(header)
                title = ['客户/供应商', '项目', '应收', '实收', '未收', '应付', '实付', '未付']
                JSONToExcelConvertor(header, "极简总账", title)
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

