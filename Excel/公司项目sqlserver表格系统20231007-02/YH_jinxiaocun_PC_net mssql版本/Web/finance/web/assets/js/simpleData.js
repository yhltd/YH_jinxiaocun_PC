var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        project: '',
    }
}

function getKehuPeizhi(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/getKehuPeizhi",
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

$(function () {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.jjtz_select == "是") {
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
            if (quanxian.jjtz_select == "是") {
                page.selectParamsMap.project = $("#project").textbox('getText');
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}

function getList() {
    var start_date = $("#start_date").datebox('getText');
    var stop_date = $("#stop_date").datebox('getText');
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
            financePageJson: JSON.stringify(page),
            start_date:start_date,
            stop_date:stop_date
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
                        if (quanxian.jjtz_add == "是") {
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
                        if (quanxian.jjtz_update == "是") {
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
                        if (quanxian.jjtz_delete == "是") {
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
        //height: 470,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            {
                field: 'insert_date', align: 'center', title: '日期', width: 300, formatter: function (value, row, index) {
                    if (value != "") {
                        var localstring = value.replace("/Date(", "").replace(")/", "");
                        row.voucherDate = formatDate(parseInt(localstring), "yyyy-MM-dd HH:mm");
                        return row.voucherDate
                    }
                    return value
                }
            },
            { field: 'kehu', align: 'center', title: '客户/供应商', width: 300 },
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
            { field: 'accounting', align: 'center', title: '科目', width: 220 },
            { field: 'zhaiyao', align: 'center', title: '摘要', width: 220 }
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
        height: 500,
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

            $("#upd_kehu").combobox({
                valueField: 'kehu',
                textField: 'kehu',
                width: 318,
                height: 38
            })

            var insert_date = formatDate(rowItem.insert_date, 'MM/dd/yyyy HH:mm:ss')
            $('#insert_date').datetimebox({
                panelWidth: 318,
                panelHeight: 280,
                width: 318,
                height: 38,
                value: insert_date
            });

            getAccounting('upd-accounting');
            getKehuPeizhi('upd_kehu');
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
        item.insert_date = params.insert_date;
        item.kehu = params.kehu;
        item.zhaiyao = params.zhaiyao;
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
            $("#add-accounting").combobox({
                valueField: 'accounting',
                textField: 'accounting',
                width: 318,
                height: 38
            });

            $("#add_kehu").combobox({
                valueField: 'kehu',
                textField: 'kehu',
                width: 318,
                height: 38
            });

            $('#add_insert_date').datetimebox({
                okText: '确定',
                closeText: '关闭',
                currentText: '当前时间',
                panelWidth: 318,
                panelHeight: 280,
                width: 318,
                height: 38
            });
            
            getAccounting('add-accounting');
            getKehuPeizhi('add_kehu');
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
        url: "web_service/invoice.asmx/getAccountingPeizhi",
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


function toExcel() {
    var start_date = $("#start_date").datebox('getText');
    var stop_date = $("#stop_date").datebox('getText');
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.jjtz_select == "是") {
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
                        financePageJson: JSON.stringify(page),
                        start_date: start_date,
                        stop_date:stop_date,
                    },
                    dataType: "xml",
                    success: function (data) {
                        var result = getJson(data);
                        if (result.code == 200) {
                            console.log(result.data.pageList)
                            var array = result.data.pageList
                            var header = []
                            for (var i = 0; i < array.length; i++) {
                                var uncollected = array[i].receivable - array[i].receipts
                                var paid = array[i].cope - array[i].payment
                                var insert_date = array[i].insert_date
                                var localstring = insert_date.replace("/Date(", "").replace(")/", "");
                                var insert_date = voucherDate = formatDate(parseInt(localstring), "yyyy-MM-dd HH:mm");

                                var body = {
                                    project: array[i].project,
                                    insert_date: insert_date,
                                    kehu:array[i].kehu,
                                    receivable: array[i].receivable,
                                    receipts: array[i].receipts,
                                    uncollected: uncollected,
                                    cope: array[i].cope,
                                    payment: array[i].payment,
                                    paid: paid,
                                    accounting: array[i].accounting,
                                    zhaiyao: array[i].zhaiyao,
                                }
                                header.push(body)
                            }
                            console.log(header)
                            title = ['项目名称','日期','客户', '应收', '实收', '未收', '应付', '实付', '未付', '科目','摘要']
                            JSONToExcelConvertor(header, "极简台账", title)
                        }
                    },
                    error: function (err) {
                        alert("错误！")
                        console.log(err)
                    }
                })
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}


function JSONToExcelConvertor(JSONData, FileName, title, filter) {
    if (!JSONData)
        return;
    //转化json为object
    var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;

    var excel = "<table>";

    //设置表头  
    var row = "<tr>";

    if (title) {
        //使用标题项
        for (var i in title) {
            row += "<th align='center'>" + title[i] + '</th>';
        }

    }
    else {
        //不使用标题项
        for (var i in arrData[0]) {
            row += "<th align='center'>" + i + '</th>';
        }
    }

    excel += row + "</tr>";

    //设置数据  
    for (var i = 0; i < arrData.length; i++) {
        var row = "<tr>";

        for (var index in arrData[i]) {
            //判断是否有过滤行
            if (filter) {
                if (filter.indexOf(index) == -1) {
                    var value = arrData[i][index] == null ? "" : arrData[i][index];
                    row += '<td>' + value + '</td>';
                }
            }
            else {
                var value = arrData[i][index] == null ? "" : arrData[i][index];
                row += "<td align='center'>" + value + "</td>";
            }
        }

        excel += row + "</tr>";
    }

    excel += "</table>";

    var excelFile = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>";
    excelFile += '<meta http-equiv="content-type" content="application/vnd.ms-excel; charset=UTF-8">';
    excelFile += '<meta http-equiv="content-type" content="application/vnd.ms-excel';
    excelFile += '; charset=UTF-8">';
    excelFile += "<head>";
    excelFile += "<!--[if gte mso 9]>";
    excelFile += "<xml>";
    excelFile += "<x:ExcelWorkbook>";
    excelFile += "<x:ExcelWorksheets>";
    excelFile += "<x:ExcelWorksheet>";
    excelFile += "<x:Name>";
    excelFile += "{worksheet}";
    excelFile += "</x:Name>";
    excelFile += "<x:WorksheetOptions>";
    excelFile += "<x:DisplayGridlines/>";
    excelFile += "</x:WorksheetOptions>";
    excelFile += "</x:ExcelWorksheet>";
    excelFile += "</x:ExcelWorksheets>";
    excelFile += "</x:ExcelWorkbook>";
    excelFile += "</xml>";
    excelFile += "<![endif]-->";
    excelFile += "</head>";
    excelFile += "<body>";
    excelFile += excel;
    excelFile += "</body>";
    excelFile += "</html>";


    var uri = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(excelFile);

    var link = document.createElement("a");
    link.href = uri;

    link.style = "visibility:hidden";
    link.download = FileName + ".xls";

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}


function getKehuPeizhi(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/getKehuPeizhi",
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