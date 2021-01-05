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
    }, {
        classId: 4,
        className: "成本类",
    }, {
        classId: 5,
        className: "损益类",
    }
]
var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

$(function () {
    $("#clases").combobox({
        data: clases,
        onSelect: function (e) {
            page.currentPage = 1
            getList(e.classId);
        },
        valueField: 'classId',
        textField: 'className'
    })
})

//根据类别id获取表格信息
function getList(classId) {
    if (classId == undefined) {
        classId = $("#clases").combobox('getValue')
    }
    $.ajax({
        type: 'Post',
        url: "web_service/accounting.asmx/getList",
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
            financePageJson: JSON.stringify(page),
            classId: classId
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

                $('#new').window({
                    title: "新增",
                    width: 800,
                    height: 550,
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
                        clearNew();
                    }
                });

                $("#grade-list1").datalist({
                    height: 300,
                    data: clases,
                    valueField: "classId",
                    textField: 'className',
                    onClickRow: function (rowIndex, rowData) {
                        $.ajax({
                            type: 'Post',
                            url: "web_service/accounting.asmx/getListOfGrade",
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
                                classId: rowData.classId,
                                grade: 1,
                                code: 0
                            },
                            dataType: "xml",
                            success: function (data) {
                                var result = getJson(data);
                                if (result.code == 200) {
                                    $("#grade-list2").datalist('loadData', result.data)
                                    setCode(1, 0, result.data.length == 0, rowData.className)
                                }
                                
                            },
                            error: function (err) {
                                alert("错误！")
                                console.log(err)
                            }
                        })
                    }
                });

                $("#grade-list2").datalist({
                    height: 300,
                    valueField: "code",
                    textField: 'name',
                    onClickRow: function (rowIndex, rowData) {
                        $.ajax({
                            type: 'Post',
                            url: "web_service/accounting.asmx/getListOfGrade",
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
                                classId: $("#grade-list1").datagrid('getSelected').classId,
                                grade: 2,
                                code: rowData.code
                            },
                            dataType: "xml",
                            success: function (data) {
                                var result = getJson(data);
                                console.log(result)
                                if (result.code == 200) {
                                    $("#grade-list3").datalist('loadData', result.data)
                                    setCode(2, rowData.code,result.data.length==0, $("#grade-list1").datagrid('getSelected').className)
                                }
                            },
                            error: function (err) {
                                alert("错误！")
                                console.log(err)
                            }
                        })
                    }
                });

                $("#grade-list3").datalist({
                    height: 300,
                    valueField: "code",
                    textField: 'name',
                    onClickRow: function (rowIndex, rowData) {
                        $.ajax({
                            type: 'Post',
                            url: "web_service/accounting.asmx/getListOfGrade",
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
                                classId: $("#grade-list1").datagrid('getSelected').classId,
                                grade: 3,
                                code: rowData.code
                            },
                            dataType: "xml",
                            success: function (data) {
                                var result = getJson(data);
                                console.log(result)
                                if (result.code == 200) {
                                    var isNull = result.data.length == 0
                                    if (isNull) {
                                        setCode(3, rowData.code, isNull, $("#grade-list1").datagrid('getSelected').className)
                                    } else {
                                        var code = 0
                                        for (var i = 0; i < result.data.length; i++) {
                                            code = result.data[i].code > code  ? result.data[i].code : code
                                        }
                                        setCode(3, code+1, isNull, $("#grade-list1").datagrid('getSelected').className)
                                    }
                                }
                            },
                            error: function (err) {
                                alert("错误！")
                                console.log(err)
                            }
                        })
                    }
                });
            }
        },'-',{
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
        frozenColumns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'rownum', align: 'center', title: '序号', width: 50 },
        ]],
        columns: [[
            { field: 'calss', align: 'center', title: '科目类别', width: 100, hidden: true },
		    { field: 'code', align: 'center', title: '科目代码', width: 100 },
		    { field: 'name', align: 'center', title: '科目名称', width: 200 },
            { field: 'grade', align: 'center', title: '科目等级', width: 70 },
            { field: 'fullName', align: 'center', title: '科目全称', width: 300 },
            {
                field: 'direction', align: 'center', title: '方向', width: 70, formatter: function (value, row, index) {
                    if (value) {
                        return '借';
                    } else {
                        return '贷';
                    }
                }
            },
            { field: 'money', align: 'center', title: '借贷合计', width: 100 },
            { field: 'detail', align: 'center', title: '明细', width: 70 },
            { field: 'load', align: 'center', title: '年初借金', width: 110 },
            { field: 'borrowed', align: 'center', title: '年初贷金', width: 110 }
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

//平衡验证
function balanceBtn() {
    $.ajax({
        type: 'Post',
        url: "web_service/accounting.asmx/balanceCheck",
        beforeSend: function () {
            $.messager.progress({
                title: '提示',
                msg: '正在验证',
                text: ''
            });
        },
        complete: function () {
            $.messager.progress('close');
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                if (result.data.check) {
                    $.messager.show({
                        title: '验证成功',
                        msg: '借贷相差' + result.data.num,
                        style: {
                            right: '',
                            top: document.body.scrollTop + document.documentElement.scrollTop,
                            bottom: ''
                        }
                    });
                } else {
                    $.messager.show({
                        title: '验证失败',
                        msg: '借贷相差' + result.data.num,
                        style: {
                            right: '',
                            top: document.body.scrollTop + document.documentElement.scrollTop,
                            bottom: ''
                        }
                    });
                }
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
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

//删除方法
function del(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    $.ajax({
        type: 'Post',
        url: "web_service/accounting.asmx/delAccounting",
        data: {
            idJson: JSON.stringify(ids)
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
            console.log(err)
        }
    })
}

//确认修改
function toUpd() {
    var updatePwdForm = $('#updateForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    if (checkUpd(params)) {
        var item = getSelected()[0]
        item.code = params.code;
        item.name = params.name;
        item.load = params.load;
        item.borrowed = params.borrowed;
        $.ajax({
            type: 'Post',
            url: "web_service/accounting.asmx/updAccounting",
            data: {
                itemJson: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                console.log(result);
                alert(result.msg);
                if (result.code == 200) {
                    $('#update').window('close');
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

//清空修改框
function toReset() {
    $("#updateForm").form('reset');
}

//修改表单验证
function checkUpd(params) {
    if (params.code == "") {
        alert("请输入科目代码")
        return false;
    } else if (params.name == "") {
        alert("请输入科目名称")
        return false;
    } else if (params.load == "") {
        alert("请输入年初借金")
        return false;
    } else if (params.borrowed == "") {
        alert("请输入年初贷金")
        return false;
    }
    return true;
}

//设置
function setCode(grade, choiceCode, isNull, className) {
    var code = 0;
    switch (parseInt(grade)) {
        case 1:
            if (isNull) {
                code = 1001
            } else {
                var data = $("#grade-list2").datalist('getData')
                for (var i = 0; i < data.rows.length; i++) {
                    code = data.rows[i].code > code ? data.rows[i].code : code
                }
                code += 1;
            }
            $("#newTextGrade").text("当前" + className + "一级项目，科目代码：")
            break;
        case 2:
            if (isNull) {
                code = parseInt(choiceCode + "01")
            } else {
                var data = $("#grade-list3").datalist('getData')
                for (var i = 0; i < data.rows.length; i++) {
                    code = data.rows[i].code > code ? data.rows[i].code : code
                }
                code += 1
            }
            $("#newTextGrade").text("当前" + className + "二级项目，科目代码：")
            break;
        case 3:
            if (isNull) {
                code = parseInt(choiceCode + "01")
            } else {
                code = choiceCode
                $("#newTextGrade").text("当前" + className + "三级项目，科目代码：")
            }
            break;
    }
    $("#newTextCode").text(code)
}

//选择
function choiceCode() {
    code = $("#newTextCode").text()
    if (code == "") {
        alert('请选择科目代码')
    } else {
        $("#new-accordion").accordion('select', '科目基本信息')
        $("#newCode").val(code)
    }
}

function toResetNew() {
    clearNew();
    $("#new-accordion").accordion('select', '选择科目代码')
}

function clearNew() {
    $("#grade-list2").datalist('loadData', { rows: [] })
    $("#grade-list3").datalist('loadData', { rows: [] })
    $("#newTextGrade").text('');
    $("#newTextCode").text('');
    $("#newForm").form('reset');
}

function toNew() {
    var updatePwdForm = $('#newForm').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updatePwdForm, true)))
    var code = $("#newCode").val();
    params.code = code
    if (checkNew(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/accounting.asmx/newAccounting",
            data: {
                itemJson: JSON.stringify({
                    code: params.code,
                    name: params.name,
                    direction: params.direction==1,
                    load: params.load,
                    borrowed: params.borrowed
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg)
                if (result.code == 200) {
                    $('#new').window('close')
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

function checkNew(params) {
    if (params.code == "") {
        alert("请选择科目代码")
        toResetNew();
        return false;
    } else if (params.name == "") {
        alert("请输入科目名称")
        return false;
    } else if (params.direction == undefined) {
        alert("请选择借贷方向")
        return false;
    } else if (params.load == "") {
        alert("请输入年初借金")
        return false;
    } else if (params.borrowed == "") {
        alert("请输入年初贷金")
        return false;
    }
    return true;
}