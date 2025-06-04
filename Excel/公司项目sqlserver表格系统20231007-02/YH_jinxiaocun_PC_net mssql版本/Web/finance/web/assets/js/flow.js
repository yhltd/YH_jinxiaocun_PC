var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        start_date: '',
        stop_date: ''
    }
}

$(function () {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.xjll_select == "是") {
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
})

function getYearAndMonth() {
    var date_ = new Date();
    var yearNum = date_.getFullYear();
    var start_date = yearNum + "-1-1"
    var stop_date = yearNum + "-12-31"
    $("#start_date").textbox('setText', start_date);
    $("#stop_date").textbox('setText', stop_date);
    page.selectParamsMap.start_date = start_date;
    page.selectParamsMap.stop_date = stop_date;
}

function selectBtn() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.xjll_select == "是") {
                page.selectParamsMap.start_date = $("#start_date").textbox('getText');
                page.selectParamsMap.stop_date = $("#stop_date").textbox('getText');
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}

function getList() {
    if (page.selectParamsMap.start_date == '' || page.selectParamsMap.stop_date == '') {
        getYearAndMonth();
    }

    var start_date = page.selectParamsMap.start_date.split("-")[0]
    var stop_date = page.selectParamsMap.stop_date.split("-")[0]

    console.log(start_date)
    console.log(stop_date)

    if (start_date != stop_date) {
        $.messager.alert('Warning', '不允许跨年查询');
    } else {
        ajaxUtil({
            url: "web_service/voucherSummary.asmx/getFlowList",
            loading: true,
            data: {
                financePageJson: JSON.stringify(page)
            }
        }, function (result) {
            if (result.code == 200) {
                var money_month = 0
                var money_year = 0
                var list = result.data.pageList
                for (i = 0; i < list.length; i++) {
                    money_month += list[i].money_month
                    money_year += list[i].money_year
                }
                setTable(result.data,money_month,money_year)
            }
        });
    }
}

function setTable(data,money_month,money_year) {
    $('#data-table').datagrid({
        title: "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日期总合计：" + money_month + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;本年总合计:" + money_year,
        fitColumns: false,
        data: data.pageList,
        //height: 470,
        columns: [[
            { field: 'expenditure', align: 'center', title: '项目名称', width: 300 },
		    { field: 'money_month', align: 'center', title: '日期合计', width: 230 },
            { field: 'money_year', align: 'center', title: '本年合计', width: 230 },
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
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.xjll_select == "是") {
                if (page.selectParamsMap.year == '' || page.selectParamsMap.month == '') {
                    getYearAndMonth();
                }
                ajaxUtil({
                    url: "web_service/voucherSummary.asmx/getFlowList",
                    loading: true,
                    data: {
                        financePageJson: JSON.stringify(page)
                    }
                }, function (result) {
                    if (result.code == 200) {
                        var array = result.data.pageList
                        var header = []
                        for (var i = 0; i < array.length; i++) {
                            var body = {
                                expenditure: array[i].expenditure,
                                money_month: array[i].money_month,
                                money_year: array[i].money_year,
                            }
                            header.push(body)
                        }
                        console.log(header)
                        title = ['项目名称', '本月合计', '本年合计']
                        JSONToExcelConvertor(header, "现金流量", title)
                    }
                });
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