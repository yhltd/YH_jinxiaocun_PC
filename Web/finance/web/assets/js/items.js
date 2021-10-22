var pageFinancingExpenditure = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageFinancingIncome = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageInvestmentExpenditure = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageInvestmentIncome = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageManagementExpenditure = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageManagementIncome = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageVoucherWord = {
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
            if (quanxian.kzxm_select == "是") {
                getListFinancingExpenditure();
                getListFinancingIncome();
                getListInvestmentExpenditure();
                getListInvestmentIncome();
                getListManagementExpenditure();
                getListManagementIncome();
                getListVoucherWord();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });

    
})

/*
    经营收入
**/
function getListFinancingExpenditure() {
    ajaxUtil({
        url: "web_service/financing.asmx/getExpenditureList",
        loading: true,
        data: {
            financePageJson: JSON.stringify(pageFinancingExpenditure)
        }
    }, function (result) {
        if (result.code == 200) {
            setTableFinancingExpenditure(result.data)
        }
    });
}

function setTableFinancingExpenditure(data) {
    var editRow;
    $('#data-table-financingExpenditure').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-financingExpenditure-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-financingExpenditure').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-financingExpenditure-window').window({
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
                                $("#upd-financingExpenditure-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-financingExpenditure').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delFinancingExpenditure(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'financingExpenditure1', align: 'center', title: '经营收入', width: 300 },
        ]]
    })

    $("#data-page-financingExpenditure").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageFinancingExpenditure.currentPage = pageNumber;
            pageFinancingExpenditure.pageSize = pageSize;
            getListFinancingExpenditure()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageFinancingExpenditure.currentPage = pageNumber;
            pageFinancingExpenditure.pageSize = pageSize;
        }
    })
}

function updFinancingExpenditure() {
    var form_ = $('#upd-financingExpenditure-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.financingExpenditure1 != "") {
        var item = $('#data-table-financingExpenditure').datagrid("getSelections")[0];
        item.financingExpenditure1 = params.financingExpenditure1;

        ajaxUtil({
            url: "web_service/financing.asmx/updExpenditure",
            loading: true,
            data: {
                newExpenditure: JSON.stringify(item)
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#upd-financingExpenditure-window').window('close');
                getListFinancingExpenditure();
            }
        });
    } else {
        alert("请输入项目名称")
    }
}

function addFinancingExpenditure() {
    var form_ = $('#add-financingExpenditure-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.financingExpenditure1 != "") {
        
        ajaxUtil({
            url: "web_service/financing.asmx/addExpenditure",
            loading: true,
            data: {
                expenditureJson: JSON.stringify({
                    id: 0,
                    financingExpenditure1: params.financingExpenditure1,
                    company: ''
                })
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#add-financingExpenditure-form').form('reset');
                $('#add-financingExpenditure-window').window('close');
                getListFinancingExpenditure();
            }
        });
    } else {
        alert("请输入项目名称")
    }
}

function delFinancingExpenditure(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/financing.asmx/delExpenditure",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        alert(result.msg);
        if (result.code == 200) {
            getListFinancingExpenditure();
        }
    });
}



/*
    经营支出
**/
function getListFinancingIncome() {
    
    ajaxUtil({
        url: "web_service/financing.asmx/getIncomeList",
        loading: true,
        data: {
            financePageJson: JSON.stringify(pageFinancingIncome)
        }
    }, function (result) {
        if (result.code == 200) {
            setTableFinancingIncome(result.data)
        }
    });
}

function setTableFinancingIncome(data) {
    var editRow;
    $('#data-table-financingIncome').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-financingIncome-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-financingIncome').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-financingIncome-window').window({
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
                                $("#upd-financingIncome-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-financingIncome').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delFinancingIncome(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'financingIncome1', align: 'center', title: '经营支出', width: 300 },
        ]]
    })

    $("#data-page-financingIncome").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageFinancingIncome.currentPage = pageNumber;
            pageFinancingIncome.pageSize = pageSize;
            getListFinancingIncome()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageFinancingIncome.currentPage = pageNumber;
            pageFinancingIncome.pageSize = pageSize;
        }
    })
}

function updFinancingIncome() {
    var form_ = $('#upd-financingIncome-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.financingIncome1 != "") {
        var item = $('#data-table-financingIncome').datagrid("getSelections")[0];
        item.financingIncome1 = params.financingIncome1;

        ajaxUtil({
            url: "web_service/financing.asmx/updIncome",
            loading: true,
            data: {
                newIncome: JSON.stringify(item)
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#upd-financingIncome-window').window('close');
                getListFinancingIncome();
            }
        });
    } else {
        alert("请输入项目名称")
    }
}

function addFinancingIncome() {
    var form_ = $('#add-financingIncome-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.financingIncome1 != "") {

        ajaxUtil({
            url: "web_service/financing.asmx/addIncome",
            loading: true,
            data: {
                incomeJson: JSON.stringify({
                    id: 0,
                    financingIncome1: params.financingIncome1,
                    company: ''
                })
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#add-financingIncome-form').form('reset');
                $('#add-financingIncome-window').window('close');
                getListFinancingIncome();
            }
        });
    } else {
        alert("请输入项目名称")
    }
}

function delFinancingIncome(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/financing.asmx/delIncome",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        alert(result.msg);
        if (result.code == 200) {
            getListFinancingIncome();
        }
    });
}



/*
    筹资支出
**/
function getListInvestmentExpenditure() {
    
    ajaxUtil({
        url: "web_service/investment.asmx/getExpenditureList",
        loading: true,
        data: {
            financePageJson: JSON.stringify(pageInvestmentExpenditure)
        }
    }, function (result) {
        if (result.code == 200) {
            setTableInvestmentExpenditure(result.data)
        }
    });
}

function setTableInvestmentExpenditure(data) {
    var editRow;
    $('#data-table-investmentExpenditure').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-investmentExpenditure-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-investmentExpenditure').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-investmentExpenditure-window').window({
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
                                $("#upd-investmentExpenditure-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-investmentExpenditure').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delInvestmentExpenditure(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'investmentExpenditure1', align: 'center', title: '筹资支出', width: 300 },
        ]]
    })

    $("#data-page-investmentExpenditure").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageInvestmentExpenditure.currentPage = pageNumber;
            pageInvestmentExpenditure.pageSize = pageSize;
            getListInvestmentExpenditure()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageInvestmentExpenditure.currentPage = pageNumber;
            pageInvestmentExpenditure.pageSize = pageSize;
        }
    })
}

function updInvestmentExpenditure() {
    var form_ = $('#upd-investmentExpenditure-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.investmentExpenditure1 != "") {
        var item = $('#data-table-investmentExpenditure').datagrid("getSelections")[0];
        item.investmentExpenditure1 = params.investmentExpenditure1;

        ajaxUtil({
            url: "web_service/investment.asmx/updExpenditure",
            loading: true,
            data: {
                newExpenditure: JSON.stringify(item)
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#upd-investmentExpenditure-window').window('close');
                getListInvestmentExpenditure();
            }
        });
    } else {
        alert("请输入项目名称")
    }
}

function addInvestmentExpenditure() {
    var form_ = $('#add-investmentExpenditure-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.investmentExpenditure1 != "") {
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/investment.asmx/addExpenditure",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                expenditureJson: JSON.stringify({
                    id: 0,
                    investmentExpenditure1: params.investmentExpenditure1,
                    company: ''
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-investmentExpenditure-form').form('reset');
                    $('#add-investmentExpenditure-window').window('close');
                    getListInvestmentExpenditure();
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
    } else {
        alert("请输入项目名称")
    }
}

function delInvestmentExpenditure(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/investment.asmx/delExpenditure",
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
                getListInvestmentExpenditure();
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


/*
    筹资收入
**/
function getListInvestmentIncome() {
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/investment.asmx/getIncomeList",
        beforeSend: function () {
            $.messager.progress({
                top: 150,
                title: '提示',
                msg: '正在加载',
                text: ''
            });
        },
        data: {
            financePageJson: JSON.stringify(pageInvestmentIncome)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                setTableInvestmentIncome(result.data)
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

function setTableInvestmentIncome(data) {
    var editRow;
    $('#data-table-investmentIncome').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-investmentIncome-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-investmentIncome').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-investmentIncome-window').window({
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
                                $("#upd-investmentIncome-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-investmentIncome').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delInvestmentIncome(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'investmentIncome1', align: 'center', title: '筹资收入', width: 300 },
        ]]
    })

    $("#data-page-investmentIncome").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageInvestmentIncome.currentPage = pageNumber;
            pageInvestmentIncome.pageSize = pageSize;
            getListInvestmentIncome()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageInvestmentIncome.currentPage = pageNumber;
            pageInvestmentIncome.pageSize = pageSize;
        }
    })
}

function updInvestmentIncome() {
    var form_ = $('#upd-investmentIncome-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.investmentIncome1 != "") {
        var item = $('#data-table-investmentIncome').datagrid("getSelections")[0];
        item.investmentIncome1 = params.investmentIncome1;
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/investment.asmx/updIncome",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                newIncome: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-investmentIncome-window').window('close');
                    getListInvestmentIncome();
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
    } else {
        alert("请输入项目名称")
    }
}

function addInvestmentIncome() {
    var form_ = $('#add-investmentIncome-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.investmentIncome1 != "") {
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/investment.asmx/addIncome",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                incomeJson: JSON.stringify({
                    id: 0,
                    investmentIncome1: params.investmentIncome1,
                    company: ''
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-investmentIncome-form').form('reset');
                    $('#add-investmentIncome-window').window('close');
                    getListInvestmentIncome();
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
    } else {
        alert("请输入项目名称")
    }
}

function delInvestmentIncome(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/investment.asmx/delIncome",
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
                getListInvestmentIncome();
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


/*
    投资收入
**/
function getListManagementExpenditure() {
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/management.asmx/getExpenditureList",
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
            financePageJson: JSON.stringify(pageManagementExpenditure)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                setTableManagementExpenditure(result.data)
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

function setTableManagementExpenditure(data) {
    var editRow;
    $('#data-table-managementExpenditure').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-managementExpenditure-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-managementExpenditure').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-managementExpenditure-window').window({
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
                                $("#upd-managementExpenditure-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-managementExpenditure').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delManagementExpenditure(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'managementExpenditure1', align: 'center', title: '投资收入', width: 300 },
        ]]
    })

    $("#data-page-managementExpenditure").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageManagementExpenditure.currentPage = pageNumber;
            pageManagementExpenditure.pageSize = pageSize;
            getListManagementExpenditure()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageManagementExpenditure.currentPage = pageNumber;
            pageManagementExpenditure.pageSize = pageSize;
        }
    })
}

function updManagementExpenditure() {
    var form_ = $('#upd-managementExpenditure-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.managementExpenditure1 != "") {
        var item = $('#data-table-managementExpenditure').datagrid("getSelections")[0];
        item.managementExpenditure1 = params.managementExpenditure1;
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/management.asmx/updExpenditure",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                newExpenditure: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-managementExpenditure-window').window('close');
                    getListManagementExpenditure();
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
    } else {
        alert("请输入项目名称")
    }
}

function addManagementExpenditure() {
    var form_ = $('#add-managementExpenditure-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.managementExpenditure1 != "") {
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/management.asmx/addExpenditure",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                expenditureJson: JSON.stringify({
                    id: 0,
                    managementExpenditure1: params.managementExpenditure1,
                    company: ''
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-managementExpenditure-form').form('reset');
                    $('#add-managementExpenditure-window').window('close');
                    getListManagementExpenditure();
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
    } else {
        alert("请输入项目名称")
    }
}

function delManagementExpenditure(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/management.asmx/delExpenditure",
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
                getListManagementExpenditure();
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



/*
    投资支出
**/
function getListManagementIncome() {
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/management.asmx/getIncomeList",
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
            financePageJson: JSON.stringify(pageManagementIncome)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                setTableManagementIncome(result.data)
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

function setTableManagementIncome(data) {
    var editRow;
    $('#data-table-managementIncome').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-managementIncome-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-managementIncome').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-managementIncome-window').window({
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
                                $("#upd-managementIncome-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-managementIncome').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delManagementIncome(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'managementIncome1', align: 'center', title: '投资支出', width: 300 },
        ]]
    })

    $("#data-page-managementIncome").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageManagementIncome.currentPage = pageNumber;
            pageManagementIncome.pageSize = pageSize;
            getListManagementIncome()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageManagementIncome.currentPage = pageNumber;
            pageManagementIncome.pageSize = pageSize;
        }
    })
}

function updManagementIncome() {
    var form_ = $('#upd-managementIncome-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.managementIncome1 != "") {
        var item = $('#data-table-managementIncome').datagrid("getSelections")[0];
        item.managementIncome1 = params.managementIncome1;
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/management.asmx/updIncome",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                newIncome: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-managementIncome-window').window('close');
                    getListManagementIncome();
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
    } else {
        alert("请输入项目名称")
    }
}

function addManagementIncome() {
    var form_ = $('#add-managementIncome-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.managementIncome1 != "") {
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/management.asmx/addIncome",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                incomeJson: JSON.stringify({
                    id: 0,
                    managementIncome1: params.managementIncome1,
                    company: ''
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-managementIncome-form').form('reset');
                    $('#add-managementIncome-window').window('close');
                    getListManagementIncome();
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
    } else {
        alert("请输入项目名称")
    }
}

function delManagementIncome(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/management.asmx/delIncome",
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
                getListManagementIncome();
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


/*
    凭证字
**/
function getListVoucherWord() {
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/voucherWord.asmx/getVoucherWordList",
        beforeSend: function () {
            $.messager.progress({
                top: 150,
                title: '提示',
                msg: '正在加载',
                text: ''
            });
        },
        data: {
            financePageJson: JSON.stringify(pageVoucherWord)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                setTableVoucherWrod(result.data)
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

function setTableVoucherWrod(data) {
    var editRow;
    $('#data-table-voucherWord').datagrid({
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
                        if (quanxian.kzxm_add == "是") {
                            $('#add-voucherWord-window').window({
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
                        if (quanxian.kzxm_update == "是") {
                            var sels = $('#data-table-voucherWord').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                $('#upd-voucherWord-window').window({
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
                                $("#upd-voucherWord-form").form('load', sels[0]);
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
                        if (quanxian.kzxm_delete == "是") {
                            var sels = $('#data-table-voucherWord').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请至少选择一行数据');
                            } else {
                                delVoucherWord(sels)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }],
        data: data.pageList,
        height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'word', align: 'center', title: '凭证字', width: 300 },
        ]]
    })

    $("#data-page-voucherWord").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageVoucherWord.currentPage = pageNumber;
            pageVoucherWord.pageSize = pageSize;
            getListVoucherWord()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageVoucherWord.currentPage = pageNumber;
            pageVoucherWord.pageSize = pageSize;
        }
    })
}

function updVoucherWord() {
    var form_ = $('#upd-voucherWord-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.word != "") {
        var item = $('#data-table-voucherWord').datagrid("getSelections")[0];
        item.word = params.word;
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/voucherWord.asmx/updVoucherWord",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                newVoucherWord: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-voucherWord-window').window('close');
                    getListVoucherWord();
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
    } else {
        alert("请输入凭证字")
    }
}

function addVoucherWord() {
    var form_ = $('#add-voucherWord-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.word != "") {
        
        $.ajax({
            type: 'Post',
            timeout: 5000,
            url: "web_service/voucherWord.asmx/addVoucherWord",
            beforeSend: function () {
                $.messager.progress({
                    top: 150,
                    title: '提示',
                    msg: '正在加载',
                    text: ''
                });
            },
            data: {
                wordJson: JSON.stringify({
                    id: 0,
                    word: params.word,
                    company: ''
                })
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-voucherWord-form').form('reset');
                    $('#add-voucherWord-window').window('close');
                    getListVoucherWord();
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
    } else {
        alert("请输入凭证字")
    }
}

function delVoucherWord(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    
    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/voucherWord.asmx/delVoucherWord",
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
                getListVoucherWord();
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