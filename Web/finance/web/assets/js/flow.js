var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        year: '',
        month: ''
    }
}

$(function () {
    getList();
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
    page.selectParamsMap.year = $("#year").textbox('getText');
    page.selectParamsMap.month = $("#month").textbox('getText');
    getList();
}

function getList() {
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
            setTable(result.data)
        }
    });
}

function setTable(data) {
    $('#data-table').datagrid({
        fitColumns: false,
        data: data.pageList,
        height: 470,
        columns: [[
            { field: 'expenditure', align: 'center', title: '项目名称', width: 300 },
		    { field: 'money_month', align: 'center', title: '本月合计', width: 230 },
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