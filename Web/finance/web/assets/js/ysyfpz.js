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
    var ysyf = $("#ysyf").combobox('getValue');
    var xiangmumingcheng = $("#xiangmumingcheng").val();

    $.ajax({
        type: 'Post',
        url: "web_service/ysyfpz.asmx/getList",
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
            ysyf: ysyf,
            xiangmumingcheng: xiangmumingcheng
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
            { field: 'ysyf', align: 'center', title: '应收应付', width: 120 },
            { field: 'xiangmumingcheng', align: 'center', title: '项目名称', width: 200 },
            { field: 'jine', align: 'center', title: '金额', width: 200 },
            { field: 'ysyfkemu', align: 'center', title: '应收应付科目', width: 250 }
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
    $('#upd-ysyf-window').window({
        title: "修改应收应付配置",
        width: 500,
        height: 400,
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

    $('#upd-ysyf-form').form('load', rowItem);
}

function toUpd() {
    var updForm = $('#upd-ysyf-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];

        // 构建更新数据对象
        var updateData = {
            id: item.id,
            ysyf: params.ysyf,
            xiangmumingcheng: params.xiangmumingcheng,
            jine: params.jine,
            ysyfkemu: params.ysyfkemu
        };

        $.ajax({
            type: 'Post',
            url: "web_service/ysyfpz.asmx/upd",
            data: {
                updInfo: JSON.stringify(updateData)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-ysyf-window').window('close');
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
    $('#add-ysyf-window').window({
        title: "新增应收应付配置",
        width: 500,
        height: 400,
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
            toReset('add-ysyf-form');
        }
    });
}

function toAdd() {
    var addForm = $('#add-ysyf-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/ysyfpz.asmx/add",
            data: {
                simpleDataJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-ysyf-window').window('close');
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
    if (!params.ysyf || params.ysyf == "") {
        alert("请选择应收应付类型")
        return false;
    } else if (!params.xiangmumingcheng || params.xiangmumingcheng == "") {
        alert("请输入项目名称")
        return false;
    } else if (!params.jine || params.jine == "") {
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
        url: "web_service/ysyfpz.asmx/del",
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
    var ysyf = $("#ysyf").combobox('getValue');
    var xiangmumingcheng = $("#xiangmumingcheng").val();

    $.ajax({
        type: 'Post',
        url: "web_service/ysyfpz.asmx/getAllList",
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
            ysyf: ysyf,
            xiangmumingcheng: xiangmumingcheng
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    var body = {
                        ysyf: array[i].ysyf,
                        xiangmumingcheng: array[i].xiangmumingcheng,
                        jine: array[i].jine,
                        ysyfkemu: array[i].ysyfkemu
                    }
                    header.push(body)
                }
                title = ['应收应付', '项目名称', '金额', '应收应付科目']
                JSONToExcelConvertor(header, "应收应付配置报表", title)
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

