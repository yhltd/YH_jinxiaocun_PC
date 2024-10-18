var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

$(function () {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.bmsz_select == "是") {
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
})

function getList() {
    ajaxUtil({
        url: "web_service/department.asmx/getList",
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

function sel() {
    dep = $("#dep").textbox('getValue')
    ajaxUtil({
        url: "web_service/department.asmx/getList2",
        loading: true,
        data: {
            financePageJson: JSON.stringify(page),
            dep:dep
        }
    }, function (result) {
        $(function () {
            ajaxUtil({
                url: "web_service/user_management.asmx/quanxianGet",
                loading: true,
            }, function (result) {
                if (result.code == 200) {
                    quanxian = result.data
                    if (quanxian.bmsz_select == "是") {
                        if (result.code == 200) {
                            setTable(result.data)
                        }
                    } else {
                        $.messager.alert('Warning', '无权限');
                    }
                }
            });

        })
      //  if (result.code == 200) {
       //     setTable(result.data)
//}
    });
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
                        if (quanxian.bmsz_add == "是") {
                            ajaxUtil({
                                url: "web_service/user_management.asmx/quanxianGet",
                                loading: true,
                            }, function (result) {
                                if (result.code == 200) {
                                    quanxian = result.data
                                    if (quanxian.bmsz_add == "是") {
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
                                    } else {
                                        $.messager.alert('Warning', '无权限');
                                    }
                                }
                            });
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
                        if (quanxian.bmsz_update == "是") {
                            var sels = getSelected();
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
                        if (quanxian.bmsz_delete == "是") {
                            var sels = getSelected();
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
        //height: 800,
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

        ajaxUtil({
            url: "web_service/department.asmx/update",
            loading: true,
            data: {
                newDepartmentJson: JSON.stringify(item)
            }
        }, function (result) {
            if (result.code == 200) {
                alert(result.msg)
                $('#update').window('close');
                getList();
            }
        });
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

    ajaxUtil({
        url: "web_service/department.asmx/delete",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        if (result.code == 200) {
            alert(result.msg);
            getList();
        }
    });
}

function toResetNew() {
    $("#newForm").form('reset');
}

function toNew() {
    var updatePwdForm = $('#newForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)));
    if (checkForm(params)) {

        ajaxUtil({
            url: "web_service/department.asmx/add",
            loading: true,
            data: {
                departmentJson: JSON.stringify(params)
            }
        }, function (result) {
            if (result.code == 200) {
                alert(result.msg);
                $('#new').window('close');
                getList();
            }
        });
    }
}

