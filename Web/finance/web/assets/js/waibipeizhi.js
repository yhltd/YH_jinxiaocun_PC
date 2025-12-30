var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
}

$(function () {
    getList();
})

function getList() {
    var huilv = $("#huilv").val();  // 修改：获取汇率
    var bizhong = $("#bizhong").val();  // 修改：获取币种

    $.ajax({
        type: 'Post',
        url: "web_service/waibipeizhi.asmx/getList",
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
            huilv: huilv,  // 修改：传汇率参数
            bizhong: bizhong  // 修改：传币种参数
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
        columns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'huilv', align: 'center', title: '汇率', width: 150 },
            { field: 'bizhong', align: 'center', title: '币种', width: 150 }
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
    $('#upd-waibi-window').window({  // 修改：窗口ID
        title: "修改外币配置",
        width: 500,
        height: 300,
        top: 20,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true
    });

    $('#upd-waibi-form').form('load', rowItem);  // 修改：表单ID
}


function toUpd() {
    var updForm = $('#upd-waibi-form').serialize();  // 修改：表单ID
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];

        // 修改：构建正确的更新数据对象
        var updateData = {
            id: item.id,
            huilv: params.huilv,
            bizhong: params.bizhong
        };

        $.ajax({
            type: 'Post',
            url: "web_service/waibipeizhi.asmx/upd",
            data: {
                updInfo: JSON.stringify(updateData)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-waibi-window').window('close');  // 修改：窗口ID
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
    $('#add-waibi-window').window({  // 修改：窗口ID
        title: "新增外币配置",
        width: 500,
        height: 300,
        top: 50,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true,
        onClose: function () {
            toReset('add-waibi-form');  // 修改：表单ID
        }
    });
}


function toAdd() {
    var addForm = $('#add-waibi-form').serialize();  // 修改：表单ID
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/waibipeizhi.asmx/add",
            data: {
                simpleDataJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-waibi-window').window('close');  // 修改：窗口ID
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
    if (!params.huilv || params.huilv == "") {
        alert("请输入汇率")
        return false;
    } else if (!params.bizhong || params.bizhong == "") {
        alert("请输入币种")
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
        url: "web_service/waibipeizhi.asmx/del",
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
    var huilv = $("#huilv").val();  // 修改：获取汇率
    var bizhong = $("#bizhong").val();  // 修改：获取币种

    $.ajax({
        type: 'Post',
        url: "web_service/waibipeizhi.asmx/getAllList",
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
            huilv: huilv,  // 修改：传汇率参数
            bizhong: bizhong  // 修改：传币种参数
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        huilv: array[i].huilv,  // 修改：字段名
                        bizhong: array[i].bizhong  // 修改：字段名
                    }
                    header.push(body)
                }
                title = ['汇率', '币种']  // 修改：表头
                JSONToExcelConvertor(header, "外币配置报表", title)
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
    var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;

    var excel = "<table>";

    //设置表头  
    var row = "<tr>";

    if (title) {
        for (var i in title) {
            row += "<th align='center'>" + title[i] + '</th>';
        }

    }
    else {
        for (var i in arrData[0]) {
            row += "<th align='center'>" + i + '</th>';
        }
    }

    excel += row + "</tr>";

    //设置数据  
    for (var i = 0; i < arrData.length; i++) {
        var row = "<tr>";

        for (var index in arrData[i]) {
            if (filter) {
                if (filter.indexOf(index) == -1) {
                    var value = arrData[i][index] == null ? "" : arrData[i][index];
                    row += '<td>' + value + '</td>';
                }
            }
            else {
                var value = arrData[i][index] == null ? "" : arrData[i][index];
                if (index === 'jine' && value) {
                    value = '¥' + parseFloat(value).toFixed(2);
                }
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

