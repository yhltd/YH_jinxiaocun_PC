var directions = [
    {
        direction: 0,
        text: "支出",
        selected: true
    }, {
        direction: 1,
        text: "收入",
    }
]
var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        direction: 0,
        year: '',
        month: ''
    }
}

$(function () {
    $("#directions").combobox({
        data: directions,
        onSelect: function (e) {
            page.currentPage = 1
            page.selectParamsMap.direction = e.direction
            ajaxUtil({
                url: "web_service/user_management.asmx/quanxianGet",
                loading: true,
            }, function (result) {
                if (result.code == 200) {
                    quanxian = result.data
                    if (quanxian.lysy_select == "是") {
                        getList()
                    } else {
                        $.messager.alert('Warning', '无权限');
                    }
                }
            });
            
        },
        valueField: 'direction',
        textField: 'text'
    })
})

function getYearAndMonth() {
    var date_ = new Date();
    var yearNum = date_.getFullYear();
    var monthNum = date_.getMonth() + 1;
    $("#year").textbox('setText', yearNum);
    $("#month").textbox('setText', monthNum);
    page.selectParamsMap.year = yearNum;
    page.selectParamsMap.month = monthNum;
}

function selectBtn() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.lysy_select == "是") {
                page.selectParamsMap.year = $("#year").textbox('getText');
                page.selectParamsMap.month = $("#month").textbox('getText');
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}

function getList() {
    if (page.selectParamsMap.year == '' || page.selectParamsMap.month == '') {
        getYearAndMonth();
    }
    $.ajax({
        type: 'Post',
        url: "web_service/accounting.asmx/getProfitList",
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
            financePageJson: JSON.stringify(page)
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
        fitColumns: false,
        data: data.pageList,
        height: 470,
        columns: [[
            { field: 'name', align: 'center', title: '科目名称', width: 300 },
		    { field: 'sum_month', align: 'center', title: '本月合计', width: 230 },
		    { field: 'sum_year', align: 'center', title: '本年合计', width: 230 },
        ]]
    })

    $("#data-page").pagination({
        total: data.total,
        pageSize: data.pageSize,
        onSelectPage: function (pageNumber, pageSize) {
            page.currentPage = pageNumber;
            page.pageSize = pageSize;
            getList()
        }
    })
}

function toExcel() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.lysy_select == "是") {
                if (page.selectParamsMap.year == '' || page.selectParamsMap.month == '') {
                    getYearAndMonth();
                }
                $.ajax({
                    type: 'Post',
                    url: "web_service/accounting.asmx/getProfitList",
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
                        financePageJson: JSON.stringify(page)
                    },
                    dataType: "xml",
                    success: function (data) {
                        var result = getJson(data);
                        if (result.code == 200) {
                            console.log(result.data.pageList)
                            var array = result.data.pageList
                            var header = []
                            for (var i = 0; i < array.length; i++) {
                                var body = {
                                    name: array[i].name,
                                    sum_month: array[i].sum_month,
                                    sum_year: array[i].sum_year,
                                }
                                header.push(body)
                            }
                            console.log(header)
                            title = ['科目名称', '本月合计', '本年合计']
                            JSONToExcelConvertor(header, "利益损益", title)
                        }
                    },
                    error: function (err) {
                        alert("错误！")
                        console.log(err)
                    }
                })
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
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