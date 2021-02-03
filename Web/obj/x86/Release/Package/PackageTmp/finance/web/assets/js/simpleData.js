var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        project: ''
    }
}

$(function () {
    getList();
})

function selectBtn() {
    page.selectParamsMap.project = $("#project").textbox('getText');
    getList();
}

function getList() {
    $.ajax({
        type: 'Post',
        url: "web_service/simpleData.asmx/getSimpleDataList",
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
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
                add();
            }
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                var sels = $('#data-table').datagrid("getSelections");
                if (sels.length > 1 || sels.length == 0) {
                    alert('请选择一行数据');
                } else {
                    update(sels[0])
                }
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-remove',
            handler: function (e) {
                var sels = $('#data-table').datagrid("getSelections");
                if (sels.length == 0) {
                    alert('请至少选择一行数据');
                } else {
                    del(sels)
                }
            }
        }],
        data: data.pageList,
        height: 470,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'project', align: 'center', title: '项目名称', width: 300 },
            { field: 'receivable', align: 'center', title: '应收', width: 100 },
		    { field: 'receipts', align: 'center', title: '实收', width: 100 },
            {
                field: 'uncollected', align: 'center', title: '未收', width: 100, formatter: function (value, row, index) {
                    return row.receivable - row.receipts;
                }
            },
		    { field: 'cope', align: 'center', title: '应付', width: 100 },
            { field: 'payment', align: 'center', title: '实付', width: 100 },
		    {
		        field: 'paid', align: 'center', title: '未付', width: 100, formatter: function (value, row, index) {
		            return row.cope - row.payment;
		        }
		    },
            { field: 'accounting', align: 'center', title: '科目', width: 220 }
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

function update(rowItem) {
    $('#upd-simpleData-window').window({
        title: "修改",
        width: 600,
        height: 400,
        top: 20,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true,
        onBeforeOpen: function () {
            $("#upd-accounting").combobox({
                valueField: 'accounting',
                textField: 'accounting',
                width: 318,
                height: 38
            })
            getAccounting('upd-accounting');
        }
    });

    $('#upd-simpleData-form').form('load', rowItem);
}

function toUpd() {
    var updForm = $('#upd-simpleData-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];
        item.accounting = params.accounting;
        item.project = params.project;
        item.receivable = params.receivable;
        item.receipts = params.receipts;
        item.cope = params.cope;
        item.payment = params.payment;
        $.ajax({
            type: 'Post',
            url: "web_service/simpleData.asmx/updSimpleData",
            data: {
                newSimpleData: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-simpleData-window').window('close');
                    getList();
                }
            },
            error: function (err) {
                alert("错误！")
                console.log(err)
            }
        })
    }
}

function add() {
    $('#add-simpleData-window').window({
        title: "新增",
        width: 600,
        height: 500,
        top: 50,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true,
        onBeforeOpen: function () {
            $("#add-accounting").combobox({
                valueField: 'accounting',
                textField: 'accounting',
                width: 318,
                height: 38
            })
            getAccounting('add-accounting');
        },
        onClose: function () {
            toReset('add-simpleData-form');
        }
    });
}

function toAdd() {
    var addForm = $('#add-simpleData-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/simpleData.asmx/addSimpleData",
            data: {
                simpleDataJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-simpleData-window').window('close');
                    getList();
                }
            },
            error: function (err) {
                alert("错误！")
                console.log(err)
            }
        })
    }
}

function del(rows) {
    var ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    $.ajax({
        type: 'Post',
        url: "web_service/simpleData.asmx/delSimpleData",
        data: {
            idsJson: JSON.stringify(ids)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            alert(result.msg);
            if (result.code == 200) {
                getList();
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}

function checkForm(params) {
    if (params.accounting == "") {
        alert("请选择科目")
        return false;
    } else if (params.project == "") {
        alert("请输入项目名称")
        return false;
    } else if (params.receivable == "") {
        alert("请输入应收")
        return false;
    }
    else if (params.receipts == "") {
        alert("请输入实收")
        return false;
    }
    else if (params.cope == "") {
        alert("请输入应付")
        return false;
    }
    else if (params.payment == "") {
        alert("请输入实付")
        return false;
    }
    return true;
}

function toReset(id) {
    $('#' + id).form('reset')
}

function getAccounting(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/simpleAccounting.asmx/getList",
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