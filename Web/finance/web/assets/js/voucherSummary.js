var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    excelist: [],
    selectParamsMap: {
        word: "",
        start_date: "",
        stop_date: ""
    }
}

var choiceCodeId = '';

$(function () {
    
    $('#word').combobox({
        valueField: 'id',
        textField: 'word'
    });
    getWord("word");
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.pzhz_select == "是") {
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
})

function getWord(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/voucherWord.asmx/getWordList",
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

function getDepartment(id) {
    $.ajax({
        type: 'Post',
        url: "web_service/department.asmx/getDepartmentList",
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

function getList() {
    $.ajax({
        type: 'Post',
        url: "web_service/voucherSummary.asmx/getVoucherSummaryList",
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
            financePageJson: JSON.stringify(page)
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                console.log(result)
                console.log(result.data.pageList)
                setTable(result.data)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}

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
                        if (quanxian.pzhz_add == "是") {
                            addVoucherSummary();
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
                        if (quanxian.pzhz_update == "是") {
                            var sels = $('#data-table').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                updateVoucherSummary(sels[0])
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
                        if (quanxian.pzhz_delete == "是") {
                            var sels = $('#data-table').datagrid("getSelections");
                            if (sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                var ids = []
                                for (var i = 0; i < sels.length; i++) {
                                    ids.push(sels[i].id)
                                }
                                delVoucherSummary(ids)
                            }
                        } else {
                            $.messager.alert('Warning', '无权限');
                        }
                    }
                });
                
            }
        }, '-', {
            text: '审核',
            iconCls: 'icon-ok',
            handler: function (e) {
                
                ajaxUtil({
                    url: "web_service/user_management.asmx/quanxianGet",
                    loading: true,
                }, function (result) {
                    if (result.code == 200) {
                        quanxian = result.data
                        if (quanxian.pzhz_update == "是") {
                            var sels = $('#data-table').datagrid("getSelections");
                            if (sels.length > 1 || sels.length == 0) {
                                alert('请选择一行数据');
                            } else {
                                //updateVoucherSummary(sels[0])
                                examineVoucherSummary();
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
        frozenColumns: [[
            { field: 'id', checkbox: true, type: 'combobox', align: 'center', title: 'ID', width: 50 },
            { field: 'rownum', align: 'center', title: '序号', width: 50 },
        ]],
        columns: [[
            { field: 'word', align: 'center', title: '凭证字', width: 100 },
		    { field: 'no', align: 'center', title: '凭证号', width: 150 },
		    {
		        field: 'voucherDate', align: 'center', title: '录入时间', width: 200, formatter: function (value, row, index) {
		            if (value != "") {
		                var localstring = value.replace("/Date(", "").replace(")/", "");
		                row.voucherDate = formatDate(parseInt(localstring), "yyyy-MM-dd HH:mm");
		                return row.voucherDate
		            }
		            return value
		        }
		    },
            { field: 'abstract', align: 'center', title: '摘要', width: 120 },
            { field: 'code', align: 'center', title: '科目代码', width: 120 },
            { field: 'fullName', align: 'center', title: '科目名称', width: 300 },
            { field: 'load', align: 'center', title: '借方金额', width: 100 },
            { field: 'borrowed', align: 'center', title: '贷方金额', width: 100 },
            { field: 'department', align: 'center', title: '部门', width: 110 },
            { field: 'expenditure', align: 'center', title: '开支项目', width: 110 },
            { field: 'note', align: 'center', title: '备注', width: 110 },
            { field: 'man', align: 'center', title: '审核人', width: 110 },
            { field: 'money', align: 'center', title: '应收/付', width: 110 },
            { field: 'real', align: 'center', title: '实收/付', width: 110 },
            {
                field: 'not_get', align: 'center', title: '未收/付', width: 110, formatter: function (value, row, index) {
                        return row.money - row.real
                    }
            }
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

function selectBtn1() {
    // 清空三个输入框的内容
    $("#start_date").datebox('setValue', '');
    $("#stop_date").datebox('setValue', '');
    $("#word").combobox('setValue', '');

    selectBtn();
}

function selectBtn() {

    var startDate = $("#start_date").datebox('getText');
    var stopDate = $("#stop_date").datebox('getText');

    // 检查是否两个日期都选择了
    if (startDate && stopDate) {
        // 将日期字符串转换为Date对象进行比较
        var start = new Date(startDate.replace(/-/g, '/'));
        var stop = new Date(stopDate.replace(/-/g, '/'));

        // 检查开始时间是否大于结束时间
        if (start > stop) {
            $.messager.alert('Warning', '开始时间不能大于结束时间！');
            return false; // 停止执行
        }
    } else if (startDate || stopDate) {
        // 如果只选择了一个日期
        $.messager.alert('Warning', '请同时选择开始时间和结束时间！');
        return false;
    }


    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.pzhz_select == "是") {
                page.selectParamsMap.word = $("#word").combobox('getText');
                page.selectParamsMap.start_date = $("#start_date").datebox('getText');
                page.selectParamsMap.stop_date = $("#stop_date").datebox('getText');
                getList();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}


function updateVoucherSummary(rowItem) {
    $('#upd-voucherSummary-window').window({
        title: "修改",
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
            $("#upd-word").combobox({
                valueField: 'word',
                textField: 'word',
                width: 318,
                height: 38
            })
            getWord("upd-word")

            var voucherDate_ = formatDate(rowItem.voucherDate, 'MM/dd/yyyy HH:mm:ss')
            $('#upd-voucherDate').datetimebox({
                panelWidth: 318,
                panelHeight: 280,
                width: 318,
                height: 38,
                value: voucherDate_
            });
            
            $('#upd-department').combobox({
                valueField: 'department1',
                textField: 'department1',
                width: 318,
                height: 38
            });
            getDepartment('upd-department')
        }
    });
    
    $("#upd-voucherSummary-form").form('load', rowItem);
}

function toUpdVoucherSummary() {
    var updForm = $('#upd-voucherSummary-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];
        item.word = params.word;
        item.no = params.no;
        item.voucherDate = params.voucherDate;
        item.abstract = params.abstract;
        item.code = params.code;
        item.money = params.money;
        item.department = params.department;
        item.expenditure = params.expenditure;
        item.note = params.note;
        item.real = params.real;
        $.ajax({
            type: 'Post',
            url: "web_service/voucherSummary.asmx/updVoucherSummary",
            data: {
                newVoucherSummary: JSON.stringify(item)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-voucherSummary-window').window('close');
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
    if (params.word == "") {
        alert("请选择凭证字")
        return false;
    } else if (params.no == "") {
        alert("请输入凭证号")
        return false;
    } else if (params.voucherDate == "") {
        alert("请选择录入时间")
        return false;
    } else if (params.code == "") {
        alert("请选择科目代码")
        return false;
    } else if (params.money == "") {
        alert("请输入借贷金额")
        return false;
    } else if (params.department == "") {
        alert("请选择部门")
        return false;
    } else if (params.expenditure == "") {
        alert("请输入开支项目")
        return false;
    } else if (params.real == "") {
        alert("请输入实收/付")
        return false;
    } 
    return true;
}

function FormQK(params) {
    params.word == ""
    params.no == ""
    params.voucherDate == ""
    params.code == ""
    params.money == ""
    params.department == ""
    params.expenditure == ""
    params.real == ""
}

function toResetUpdVoucherSummary() {
    $('#upd-voucherSummary-form').form('reset')
}


//打开选择科目代码窗口
function openSubject(id) {
    choiceCodeId = id
    $('#subject-window').window({
        title: "选择科目代码",
        width: 600,
        height: 400,
        top: 100,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: true,
        modal: true,
        onBeforeOpen: function () {
            $("#clases").combobox({
                data: [
                    {
                        classId: 1,
                        className: "资产类",
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
                ],
                valueField: 'classId',
                textField: 'className',
                onSelect: function (e) {
                    var grade = $("#grades").combobox('getValue')
                    if (grade!='') {
                        setSubjectList(e.classId, grade, 'subject-list')
                    }
                }
            })

            $("#grades").combobox({
                data: [
                    {
                        grade: 1,
                        text: "一级",
                    }, {
                        grade: 2,
                        text: "二级",
                    }, {
                        grade: 3,
                        text: "三级",
                    }
                ],
                valueField: 'grade',
                textField: 'text',
                onSelect: function (e) {
                    var classId = $("#clases").combobox('getValue')
                    if (classId!='') {
                        setSubjectList(classId, e.grade, 'subject-list')
                    }
                }
            })

            $("#subject-list").datalist({
                valueField: "code",
                textField: 'name',
                height: 200,
                width: 548,
                onClickRow: function (rowIndex, rowData) {
                    $("#choiceCode").text(rowData.code);
                }
            })
        },
    });
}

//获取科目集合
function setSubjectList(classId,grade,id) {
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
            classId: classId,
            grade: grade,
            code: 0
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                $("#" + id).datalist('loadData', result.data)
            }

        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}

//提交科目代码
function submitCode() {
    var code = $("#choiceCode").text();
    $("#" + choiceCodeId).val(code)
    $("#subject-window").window('close')
}


function addVoucherSummary() {
    $('#add-voucherSummary-window').window({
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
            $("#add-word").combobox({
                valueField: 'word',
                textField: 'word',
                width: 318,
                height: 38
            })

            $('#add-voucherDate').datetimebox({
                okText: '确定',
                closeText: '关闭',
                currentText: '当前时间',
                panelWidth: 318,
                panelHeight: 280,
                width: 318,
                height: 38
            });
            getWord("add-word")

            $('#add-department').combobox({
                valueField: 'department1',
                textField: 'department1',
                width: 318,
                height: 38
            });
            getDepartment('add-department')
        }
    });
}

function toAddVoucherSummary() {
    var addForm = $('#add-voucherSummary-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/voucherSummary.asmx/addVoucherSummary",
            data: {
                voucherSummaryJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    toResetAddVoucherSummary();
                    addVoucherSummary();
                    $('#add-voucherSummary-window').window('close');
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

function toResetAddVoucherSummary() {
    $('#add-voucherSummary-form').form('reset')
}


function delVoucherSummary(ids) {
    $.ajax({
        type: 'Post',
        url: "web_service/voucherSummary.asmx/delVoucherSummary",
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

function examineVoucherSummary() {
    $('#examine-voucherSummary-window').window({
        title: "审核",
        width: 600,
        height: 200,
        top: 100,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        draggable: true,
        resizable: false,
        shadow: false,
        modal: true,
        onClose: function () {
            $('#examine-voucherSummary-form').form('reset');
        }
    });
}

function toExamineVoucherSummary() {
    var examineForm = $('#examine-voucherSummary-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(examineForm, true)))
    if (checkExamineForm(params)) {
        var sels = $('#data-table').datagrid("getSelections");
        var ids = [];
        for (var i = 0; i < sels.length; i++) {
            ids.push(sels[i].id)
        }

        $.ajax({
            type: 'Post',
            url: "web_service/voucherSummary.asmx/examineVoucherSummary",
            data: {
                idsJson: JSON.stringify(ids),
                do: params.do,
                //examineName: params.examineName
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#examine-voucherSummary-window').window('close');
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

function checkExamineForm(params) {

    if (params.do == "") {
        alert("请输入操作密码")
        return false;
    }
    //} else if (params.examineName == "") {
    //    alert("请输入审核人姓名")
    //    return false;
    //}
    return true;
}

function toExcel() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.pzhz_select == "是") {
                $.ajax({
                    type: 'Post',
                    url: "web_service/voucherSummary.asmx/getVoucherSummaryList",
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
                        financePageJson: JSON.stringify(page)
                    },
                    dataType: "xml",
                    success: function (data) {
                        var result = getJson(data);
                        if (result.code == 200) {
                            var array = result.data.pageList
                            console.log(result.data.pageList)
                            var header = []
                            for (var i = 0; i < array.length; i++) {
                                var body = {
                                    rownum: array[i].rownum,
                                    word: array[i].word,
                                    no: array[i].no,
                                    voucherDate: new Date(parseInt(array[i].voucherDate.substr(6, 13))).toLocaleString(),
                                    abstract: array[i].abstract,
                                    code: array[i].code,
                                    fullName: array[i].fullName,
                                    load: array[i].load,
                                    borrowed: array[i].borrowed,
                                    department: array[i].department,
                                    expenditure: array[i].expenditure,
                                    note: array[i].note,
                                    man: array[i].man,
                                    money: array[i].money,
                                    real: array[i].real,
                                    not_get: array[i].money - array[i].real
                                }
                                header.push(body)
                            }
                            console.log(header)
                            title = ['序号', '凭证字', '凭证号', '录入时间', '摘要', '科目代码', '科目名称', '借方金额', '贷方金额', '市场部', '开支项目', '备注', '审核人', '应收/付', '实收/付', '未收/付']
                            JSONToExcelConvertor(header, "voucherSummary", title)


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