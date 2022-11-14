var pageAccounting = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageKehu = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

var pageInvoice = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: []
}

$(function () {
    getListAccounting();
    getListKehu();
    getListInvoice();
})

/*
    科目
**/
function getListAccounting() {
    ajaxUtil({
        url: "web_service/simplePeizhi.asmx/getAccounting",
        loading: true,
        data: {
            financePageJson: JSON.stringify(pageAccounting)
        }
    }, function (result) {
        if (result.code == 200) {
            setTableAccounting(result.data)
        }
    });
}

function setTableAccounting(data) {
    var editRow;
    $('#data-table-accounting').datagrid({
        title: '科目',
        fitColumns: false,
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
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
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                var sels = $('#data-table-accounting').datagrid("getSelections");
                if (sels.length > 1 || sels.length == 0) {
                    alert('请选择一行数据');
                } else {
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
                    $("#upd-accounting-form").form('load', sels[0]);
                }
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-remove',
            handler: function (e) {
                var sels = $('#data-table-accounting').datagrid("getSelections");
                if (sels.length == 0) {
                    alert('请至少选择一行数据');
                } else {
                    delAccounting(sels)
                }
            }
        }],
        data: data.pageList,
        //height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'accounting', align: 'center', title: '科目', width: 300 },
        ]]
    })

    $("#data-page-accounting").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageAccounting.currentPage = pageNumber;
            pageAccounting.pageSize = pageSize;
            getListAccounting()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageAccounting.currentPage = pageNumber;
            pageAccounting.pageSize = pageSize;
        }
    })
}

function addAccounting() {
    var form_ = $('#add-accounting-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.accounting != "") {

        ajaxUtil({
            url: "web_service/simplePeizhi.asmx/addAccounting",
            loading: true,
            data: {
                addJson: JSON.stringify({
                    id: 0,
                    accounting: params.accounting,
                    company: ''
                })
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#add-accounting-form').form('reset');
                $('#add-accounting-window').window('close');
                getListAccounting();
            }
        });
    } else {
        alert("请输入项目名称")
    }
}

function updAccounting() {
    var form_ = $('#upd-accounting-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.accounting != "") {
        var item = $('#data-table-accounting').datagrid("getSelections")[0];
        item.accounting = params.accounting;
        ajaxUtil({
            url: "web_service/simplePeizhi.asmx/updAccounting",
            loading: true,
            data: {
                updJson: JSON.stringify(item)
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#upd-accounting-window').window('close');
                getListAccounting();
            }
        });
    } else {
        alert("请输入科目名称")
    }
}

function delAccounting(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/simplePeizhi.asmx/delAccounting",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        alert(result.msg);
        if (result.code == 200) {
            getListAccounting();
        }
    });
}



/*
    客户/供应商
**/
function getListKehu() {
    ajaxUtil({
        url: "web_service/simplePeizhi.asmx/getKehu",
        loading: true,
        data: {
            financePageJson: JSON.stringify(pageKehu)
        }
    }, function (result) {
        if (result.code == 200) {
            setTableKehu(result.data)
        }
    });
}

function setTableKehu(data) {
    var editRow;
    $('#data-table-kehu').datagrid({
        title: '客户/供应商/往来单位',
        fitColumns: false,
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
                $('#add-kehu-window').window({
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
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                var sels = $('#data-table-kehu').datagrid("getSelections");
                if (sels.length > 1 || sels.length == 0) {
                    alert('请选择一行数据');
                } else {
                    $('#upd-kehu-window').window({
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
                    $("#upd-kehu-form").form('load', sels[0]);
                }
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-remove',
            handler: function (e) {
                var sels = $('#data-table-kehu').datagrid("getSelections");
                if (sels.length == 0) {
                    alert('请至少选择一行数据');
                } else {
                    delKehu(sels)
                }
            }
        }],
        data: data.pageList,
        //height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'kehu', align: 'center', title: '客户/供应商/往来单位', width: 300 },
        ]]
    })

    $("#data-page-kehu").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageKehu.currentPage = pageNumber;
            pageKehu.pageSize = pageSize;
            getListKehu()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageKehu.currentPage = pageNumber;
            pageKehu.pageSize = pageSize;
        }
    })
}

function addKehu() {
    var form_ = $('#add-kehu-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.kehu != "") {

        ajaxUtil({
            url: "web_service/simplePeizhi.asmx/addKehu",
            loading: true,
            data: {
                addJson: JSON.stringify({
                    id: 0,
                    kehu: params.kehu,
                    company: ''
                })
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#add-kehu-form').form('reset');
                $('#add-kehu-window').window('close');
                getListKehu();
            }
        });
    } else {
        alert("请输入客户/供应商/往来单位")
    }
}

function updKehu() {
    var form_ = $('#upd-kehu-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.kehu != "") {
        var item = $('#data-table-kehu').datagrid("getSelections")[0];
        item.kehu = params.kehu;
        ajaxUtil({
            url: "web_service/simplePeizhi.asmx/updKehu",
            loading: true,
            data: {
                updJson: JSON.stringify(item)
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#upd-kehu-window').window('close');
                getListKehu();
            }
        });
    } else {
        alert("请输入客户/供应商/往来单位")
    }
}

function delKehu(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/simplePeizhi.asmx/delKehu",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        alert(result.msg);
        if (result.code == 200) {
            getListKehu();
        }
    });
}




/*
    发票种类
**/
function getListInvoice() {
    ajaxUtil({
        url: "web_service/simplePeizhi.asmx/getInvoice",
        loading: true,
        data: {
            financePageJson: JSON.stringify(pageInvoice)
        }
    }, function (result) {
        if (result.code == 200) {
            setTableInvoice(result.data)
        }
    });
}

function setTableInvoice(data) {
    var editRow;
    $('#data-table-invoice').datagrid({
        title: '发票种类',
        fitColumns: false,
        toolbar: [{
            text: '新增',
            iconCls: 'icon-add',
            handler: function () {
                $('#add-invoice-window').window({
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
        }, '-', {
            text: '修改',
            iconCls: 'icon-edit',
            handler: function () {
                var sels = $('#data-table-invoice').datagrid("getSelections");
                if (sels.length > 1 || sels.length == 0) {
                    alert('请选择一行数据');
                } else {
                    $('#upd-invoice-window').window({
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
                    $("#upd-invoice-form").form('load', sels[0]);
                }
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-remove',
            handler: function (e) {
                var sels = $('#data-table-invoice').datagrid("getSelections");
                if (sels.length == 0) {
                    alert('请至少选择一行数据');
                } else {
                    delInvoice(sels)
                }
            }
        }],
        data: data.pageList,
        //height: 480,
        width: 330,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'invoice_type', align: 'center', title: '发票种类', width: 300 },
        ]]
    })

    $("#data-page-invoice").pagination({
        total: data.total,
        pageSize: data.pageSize,
        beforePageText: '当前页',
        afterPageText: '',
        displayMsg: '',
        onSelectPage: function (pageNumber, pageSize) {
            pageInvoice.currentPage = pageNumber;
            pageInvoice.pageSize = pageSize;
            getListInvoice()
        },
        onRefresh: function (pageNumber, pageSize) {
            pageInvoice.currentPage = pageNumber;
            pageInvoice.pageSize = pageSize;
        }
    })
}

function addInvoice() {
    var form_ = $('#add-invoice-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.invoice != "") {

        ajaxUtil({
            url: "web_service/simplePeizhi.asmx/addInvoice",
            loading: true,
            data: {
                addJson: JSON.stringify({
                    id: 0,
                    invoice_type: params.invoice,
                    company: ''
                })
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#add-invoice-form').form('reset');
                $('#add-invoice-window').window('close');
                getListInvoice();
            }
        });
    } else {
        alert("请输入发票种类")
    }
}

function updInvoice() {
    var form_ = $('#upd-invoice-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(form_, true)))
    if (params.invoice != "") {
        var item = $('#data-table-invoice').datagrid("getSelections")[0];
        item.invoice_type = params.invoice;
        ajaxUtil({
            url: "web_service/simplePeizhi.asmx/updInvoice",
            loading: true,
            data: {
                updJson: JSON.stringify(item)
            }
        }, function (result) {
            alert(result.msg);
            if (result.code == 200) {
                $('#upd-invoice-window').window('close');
                getListInvoice();
            }
        });
    } else {
        alert("请输入发票种类")
    }
}

function delInvoice(rows) {
    ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }

    ajaxUtil({
        url: "web_service/simplePeizhi.asmx/delInvoice",
        loading: true,
        data: {
            idsJson: JSON.stringify(ids)
        }
    }, function (result) {
        alert(result.msg);
        if (result.code == 200) {
            getListInvoice();
        }
    });
}