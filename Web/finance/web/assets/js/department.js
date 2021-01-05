var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

$(function () {
    getList();
})

function getList() {
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/department.asmx/getList",
        beforeSend: function () {
            $.messager.progress({
                top: 150,
                title: '提示',
                msg: '正在加载',
                text: ''
            });
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

//设置表格信息
function setTable(data) {
    $('#data-table').datagrid({
        fitColumns: false,
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
                $('#new').window({
                    title: "新增",
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
                    onClose: function () {
                        toResetNew();
                    }
                });
            }
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                var sels = getSelected();
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
                var sels = getSelected();
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
            { field: 'rownum', align: 'center', title: '序号', width: 100 },
            { field: 'department1', align: 'center', title: '部门', width: 300 },
		    { field: 'man', align: 'center', title: '制表人', width: 300 },
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

//获取表格选中行
function getSelected() {
    return $('#data-table').datagrid("getSelections");
}

//修改方法
function update(rowItem) {
    $('#update').window({
        title: "修改",
        width: 600,
        height: 400,
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
    $("#updateForm").form('load', rowItem);
}

//确认修改
function toUpd() {
    var updatePwdForm = $('#updateForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    if (checkForm(params)) {
        var item = getSelected()[0]
        item.department1 = params.department1;
        item.man = params.man;
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/department.asmx/update",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                newDepartmentJson: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#update').window('close');
                    getList();
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
}

//清空修改框
function toReset() {
    $("#updateForm").form('reset');
}

//修改表单验证
function checkForm(params) {
    if (params.department1 == "") {
        alert("请输入部门名称")
        return false;
    } else if (params.man == "") {
        alert("请输入审核人")
        return false;
    }
    return true;
}

//删除方法
function del(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/department.asmx/delete",
        beforeSend: function () {
            $.messager.progress({
                top: 150,
                title: '提示',
                msg: '正在加载',
                text: ''
            });
        },
        data: {
            idsJson: JSON.stringify(ids)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                alert(result.msg);
                getList();
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

function toResetNew() {
    $("#newForm").form('reset');
}

function toNew() {
    var updatePwdForm = $('#newForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/department.asmx/add",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                departmentJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg)
                if (result.code == 200) {
                    $('#new').window('close')
                    getList();
                } else if (result.code == 401) {
                    window.location.href = "../../view/invalid.aspx"
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
}

