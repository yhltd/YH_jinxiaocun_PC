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
    $.ajax({
        type: 'Post',
        url: "web_service/simpleAccounting.asmx/getSimpleAccountingList",
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
                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.jjzz_add == "是") {
                            add();
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.jjzz_update == "是") {
                            var sels = $('#data-table').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                update(sels[0])
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-remove',
            handler: function (e) {
                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.jjzz_delete == "是") {
                            var sels = $('#data-table').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                del(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 470,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'accounting', align: 'center', title: '科目名称', width: 250 },
            { field: 'receivable', align: 'center', title: '应收', width: 250 },
            { field: 'receipts', align: 'center', title: '实收', width: 250 },
            { field: 'notget1', align: 'center', title: '未收', width: 250 },
            { field: 'cope', align: 'center', title: '应付', width: 250 },
            { field: 'payment', align: 'center', title: '实付', width: 250 },
            { field: 'notget2', align: 'center', title: '未付', width: 250 },


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
    $('#upd-accounting-window').window({
        title: "修改",
        width: 400,
        height: 150,
        top: 100,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true
    });
    $('#upd-accounting-form').form('load', rowItem);
}

function toUpd() {
    var updForm = $('#upd-accounting-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];
        item.accounting = params.accounting;
        $.ajax({
            type: 'Post',
            url: "web_service/simpleAccounting.asmx/updSimpleAccounting",
            data: {
                newSimpleAccounting: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-accounting-window').window('close');
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
    $('#add-accounting-window').window({
        title: "新增",
        width: 400,
        height: 150,
        top: 100,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true
    });
}

function toAdd() {
    var addForm = $('#add-accounting-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/simpleAccounting.asmx/addSimpleAccounting",
            data: {
                simpleAccountingJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-accounting-window').window('close');
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
        url: "web_service/simpleAccounting.asmx/delSimpleAccounting",
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
        alert("请输入科目名称")
        return false;
    }
    return true;
}

function toReset(id) {
    $('#' + id).form('reset')
}