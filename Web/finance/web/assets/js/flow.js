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
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/voucherSummary.asmx/getFlowList",
        beforeSend: function () {
            $.messager.progress({
                top: 150,
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
        },
        complete: function (XMLHttpRequest, status) {
            $.messager.progress('close');
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
    })
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