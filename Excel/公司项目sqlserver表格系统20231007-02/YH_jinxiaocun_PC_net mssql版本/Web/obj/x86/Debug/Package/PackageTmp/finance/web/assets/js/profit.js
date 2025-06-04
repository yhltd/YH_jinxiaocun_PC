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
            getList()
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