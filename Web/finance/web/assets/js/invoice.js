var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
}

$(function () {
    $("#unit").combobox({
        valueField: 'kehu',
        textField: 'kehu',
    })
    getKehuPeizhi('unit');
    getList();

})



function getList() {
    var ks = $("#ks").datebox('getText');
    var js = $("#js").datebox('getText');
    var unit = $("#unit").val();
    if (ks == "") {
        ks="1900-01-01"
    }
    if (js == "") {
        js="2200-01-01"
    }
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/getList",
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
            ks: ks,
            js: js,
            unit:unit,
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
        //height: 470,
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'type', align: 'center', title: '类型', width: 120 },
            { field: 'riqi', align: 'center', title: '日期', width: 120 },
            { field: 'zhaiyao', align: 'center', title: '摘要', width: 250 },
		    { field: 'unit', align: 'center', title: '往来单位', width: 200 },
		    { field: 'invoice_type', align: 'center', title: '发票种类', width: 120 },
            { field: 'invoice_no', align: 'center', title: '发票号码', width: 200 },
            { field: 'jine', align: 'center', title: '金额', width: 120 },
            { field: 'remarks', align: 'center', title: '备注', width: 250 }
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
    $('#upd-invoice-window').window({
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
            $("#upd_invoice_type").combobox({
                valueField: 'invoice_type',
                textField: 'invoice_type',
                width: 318,
                height: 38
            })
            $("#upd_unit").combobox({
                valueField: 'kehu',
                textField: 'kehu',
                width: 318,
                height: 38
            })
            getInvoicePeizhi('upd_invoice_type');
            getKehuPeizhi('upd_unit');
        }
    });

    $('#upd-invoice-form').form('load', rowItem);
}

function toUpd() {
    var updForm = $('#upd-invoice-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];
        item.type = params.type;
        item.riqi = params.riqi;
        item.zhaiyao = params.zhaiyao;
        item.unit = params.unit;
        item.invoice_type = params.invoice_type;
        item.invoice_no = params.invoice_no;
        item.jine = params.jine;
        item.remarks = params.remarks;
        $.ajax({
            type: 'Post',
            url: "web_service/invoice.asmx/upd",
            data: {
                updInfo: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-invoice-window').window('close');
                    $('#unit').val("");
                    $('#ks').val("");
                    $('#js').val("");
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
    $('#add-invoice-window').window({
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
            $("#add_invoice_type").combobox({
                valueField: 'invoice_type',
                textField: 'invoice_type',
                width: 318,
                height: 38
            })
            $("#add_unit").combobox({
                valueField: 'kehu',
                textField: 'kehu',
                width: 318,
                height: 38
            })
            getInvoicePeizhi('add_invoice_type');
            getKehuPeizhi('add_unit');
        },
        onClose: function () {
            toReset('add-invoice-form');
        }
    });
}

function toAdd() {
    var addForm = $('#add-invoice-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/invoice.asmx/add",
            data: {
                simpleDataJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-invoice-window').window('close');
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

function checkForm(params) {
    if (params.type == "") {
        alert("请选择类型")
        return false;
    } else if (params.riqi == "") {
        alert("请输入日期")
        return false;
    } else if (params.unit == "") {
        alert("请输入往来单位")
        return false;
    }
    else if (params.invoice_type == "") {
        alert("请输入发票种类")
        return false;
    }
    else if (params.invoice_no == "") {
        alert("请输入发票号码")
        return false;
    }
    else if (params.jine == "") {
        alert("请输入金额")
        return false;
    }
    return true;
}

function del(rows) {
    var ids = []
    for (var i = 0 ; i < rows.length; i++) {
        ids.push(rows[i].id)
    }
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/del",
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


function toExcel() {
    var unit = $("#unit").val();
    var ks = $("#ks").datebox('getText');
    var js = $("#js").datebox('getText');
    if (ks == "") {
        ks = "1900-01-01"
    }
    if (js == "") {
        js = "2200-01-01"
    }
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/getList",
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
            ks: ks,
            js: js,
            unit:unit,
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                console.log(result.data.pageList)
                var array = result.data.pageList
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        type: array[i].type,
                        riqi: array[i].riqi,
                        zhaiyao: array[i].zhaiyao,
                        unit: array[i].unit,
                        invoice_type: array[i].invoice_type,
                        invoice_no: array[i].invoice_no,
                        jine: array[i].jine,
                        remarks: array[i].remarks,
                    }
                    header.push(body)
                }
                console.log(header)
                title = ['类型', '日期', '摘要', '往来单位', '发票种类', '发票号码', '金额', '备注']
                JSONToExcelConvertor(header, "发票", title)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
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

function toReset(id) {
    $('#' + id).form('reset')
}


function getInvoicePeizhi(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/invoice.asmx/getInvoicePeizhi",
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

