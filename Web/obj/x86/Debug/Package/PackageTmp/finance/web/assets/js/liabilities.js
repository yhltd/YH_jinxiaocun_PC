var clases = [
    {
        classId: 1,
        className: "资产类",
        selected: true
    }, {
        classId: 2,
        className: "负债类",
    }, {
        classId: 3,
        className: "权益类",
    }
]
var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        classId: 1,
        year: '',
        month: ''
    }
}

$(function () {
    $("#clases").combobox({
        data: clases,
        onSelect: function (e) {
            page.currentPage = 1
            page.selectParamsMap.classId = e.classId
            getList()
        },
        valueField: 'classId',
        textField: 'className'
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
        url: "web_service/accounting.asmx/getLiabilitiesList",
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
		    { field: 'load', align: 'center', title: '年初余额', width: 230 },
		    { field: 'borrowed', align: 'center', title: '年末余额', width: 230 },
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