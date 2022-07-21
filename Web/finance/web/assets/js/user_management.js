var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}
var quanxian_id;

$(function () {
    getCha();
})

function getList() {
    var a = 1;
    ajaxUtil({
        url: "web_service/user_management.asmx/getList",
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



function getCha() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.zhgl_select == "是") {
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
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
                        if (quanxian.zhgl_add == "是") {
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
                        if (quanxian.zhgl_update == "是") {

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
                        if (quanxian.zhgl_delete == "是") {
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
        }, '-', {
            text: '权限',
            iconCls: 'icon-edit',
            handler: function (e) {

                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.zhgl_update == "是") {
                            var sels = getSelected();
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                quan_load(sels[0])
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
            { field: 'rownum', align: 'center', title: '序号', width: 100 },
            { field: 'name', align: 'center', title: '账号', width: 300 },
		    { field: 'pwd', align: 'center', title: '密码', width: 300 },
            { field: 'do', align: 'center', title: '操作密码', width: 300 },
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


function del(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/user_management.asmx/delete",
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

function getSelected() {
    return $('#data-table').datagrid("getSelections");
}

function update(rowItem) {
    $('#update').window({
        title: "修改",
        width: 600,
        height: 600,
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
    $("#updateForm").form('load', rowItem );
}

    //确认修改
function toUpd() {
    var updatePwdForm = $('#updateForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    if (checkForm(params)) {
        var item = getSelected()[0]
        item.name = params.name;
        item.pwd = params.pwd;
        item.do = params.do;

        ajaxUtil({
            url: "web_service/user_management.asmx/update",
            loading: true,
            data: {
                newUserJson: JSON.stringify(item)
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

function checkForm(params) {
    if (params.name == "") {
        alert("请输入账号")
        return false;
    } else if (params.pwd == "") {
        alert("请输入密码")
        return false;
    } else if (params.do == "") {
        alert("请输入操作密码")
        return false;
    }
    return true;
}


function toResetNew() {
    $("#newForm").form('reset');
}

function toNew() {
    var updatePwdForm = $('#newForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)));
    if (checkForm(params)) {
        ajaxUtil({
            url: "web_service/user_management.asmx/add",
            loading: true,
            data: {
                userJson: JSON.stringify(params)
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

function quan_load(rowItem) {

    ajaxUtil({
        url: "web_service/user_management.asmx/getquanxian",
        loading: true,
        data: {
            quanxianJson: JSON.stringify(rowItem)
        }
    }, function (result) {
        if (result.code == 200) {
            quanxian_id = result.data.id
            $('#qxupdate').window({
                title: "修改",
                width: 1200,
                height: 500,
                top: 70,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                closable: true,
                draggable: true,
                resizable: false,
                shadow: false,
                modal: true
            });
            $("#qxForm").form('load', result.data);
        }
    });
}


function qxUpd() {
    var updateQXForm = $('#qxForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updateQXForm, true)))
    var item = getSelected()[0]
    var bianhao = item.bianhao
    ajaxUtil({
        url: "web_service/user_management.asmx/updateQX",
        loading: true,
        data: {
            bianhao: bianhao,
            quanxian: JSON.stringify(params)
        }
    }, function (result) {
        if (result.code == 200) {
            alert(result.msg)
            $('#qxupdate').window('close');
            getList();
        }
    });
}

//清空修改框
function toReset() {
    $("#updateForm").form('reset');
}

//查询
function sel() {
    var username = $("#username").val();
    ajaxUtil({
        url: "web_service/user_management.asmx/queryList",
        loading: true,
        data: {
            financePageJson: JSON.stringify(page),
            username: username,
        }
    }, function (result) {
        if (result.code == 200) {
            setTable(result.data)
        }
    });
}

