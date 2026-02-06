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
    var renming = $("#renming").val();
    var beizhu = $("#beizhu").val();

    $.ajax({
        type: 'Post',
        url: "web_service/gongzimingxi.asmx/getList",
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
            renming: renming,
            beizhu: beizhu
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                setTable(result.data)
            } else {
                alert("查询失败: " + result.msg);
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
    // 处理数据，计算字段
    if (data.pageList && data.pageList.length > 0) {
        data.pageList = data.pageList.map(function (item) {
            // 计算工资：gongzi = kkqgongzi - koukuan
            if (item.kkqgongzi != null && item.koukuan != null) {
                item.gongzi = parseFloat(item.kkqgongzi) - parseFloat(item.koukuan);
            }

            // 计算未付：weifu = gongzi - yifu
            var gongzi = item.gongzi || 0;
            var yifu = item.yifu || 0;
            item.weifu = gongzi - yifu;

            return item;
        });
    }

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
            { field: 'id', checkbox: true, align: 'center', title: 'ID', width: 50 },
            { field: 'renming', align: 'center', title: '姓名', width: 100 },
            {
                field: 'shijian', align: 'center', title: '时间', width: 120,
                formatter: function (value) {
                    if (value) {
                        if (typeof value === 'string' && value.indexOf('/Date(') === 0) {
                            // 提取毫秒数
                            var milliseconds = parseInt(value.replace(/[^0-9]/g, ''));
                            return new Date(milliseconds).toLocaleDateString();
                        }
                        // 如果是ISO格式或其他格式
                        return new Date(value).toLocaleDateString();
                    }
                    return '';
                }
            },
            {
                field: 'kkqgongzi', align: 'center', title: '工资', width: 100,
                formatter: function (value) {
                    return value ? '¥' + parseFloat(value).toFixed(2) : '¥0.00';
                }
            },
            {
                field: 'koukuan', align: 'center', title: '扣款', width: 100,
                formatter: function (value) {
                    return value ? '¥' + parseFloat(value).toFixed(2) : '¥0.00';
                }
            },
            {
                field: 'gongzi', align: 'center', title: '应付', width: 100,
                formatter: function (value, row) {
                    var gongzi = 0;
                    if (row.kkqgongzi != null && row.koukuan != null) {
                        gongzi = parseFloat(row.kkqgongzi) - parseFloat(row.koukuan);
                    } else if (value != null) {
                        gongzi = parseFloat(value);
                    }
                    return '¥' + gongzi.toFixed(2);
                }
            },
            {
                field: 'yifu', align: 'center', title: '已付', width: 100,
                formatter: function (value) {
                    return value ? '¥' + parseFloat(value).toFixed(2) : '¥0.00';
                }
            },
            {
                field: 'weifu', align: 'center', title: '未付', width: 100,
                formatter: function (value, row) {
                    var weifu = 0;
                    if (row.kkqgongzi != null && row.koukuan != null && row.yifu != null) {
                        var gongzi = parseFloat(row.kkqgongzi) - parseFloat(row.koukuan);
                        weifu = gongzi - parseFloat(row.yifu);
                    } else if (row.gongzi != null && row.yifu != null) {
                        weifu = parseFloat(row.gongzi) - parseFloat(row.yifu);
                    }
                    return '¥' + weifu.toFixed(2);
                }
            },
            { field: 'yinhangzhanghu', align: 'center', title: '银行账户', width: 150 },
            { field: 'beizhu', align: 'center', title: '备注', width: 150 }
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
    $('#upd-gongzi-window').window({
        title: "修改工资明细",
        width: 500,
        height: 500,
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

    // 处理日期字段
    var formData = Object.assign({}, rowItem);

    // 如果使用EasyUI的datebox
    if (formData.shijian) {
        var date = null;

        if (typeof formData.shijian === 'string') {
            if (formData.shijian.indexOf('/Date(') === 0) {
                var milliseconds = parseInt(formData.shijian.replace(/[^0-9]/g, ''));
                date = new Date(milliseconds);
            } else {
                date = new Date(formData.shijian);
            }
        } else if (formData.shijian instanceof Date) {
            date = formData.shijian;
        }

        if (date && !isNaN(date.getTime())) {
            // 对于EasyUI的datebox，可以直接传递Date对象或格式化的字符串
            formData.shijian = $.fn.datebox.defaults.formatter.call(this, date);
        }
    }

    // 加载表单数据
    $('#upd-gongzi-form').form('load', formData);

    // 或者如果使用EasyUI的datebox，也可以单独设置日期框
    // $('#upd-gongzi-form').find('[name="shijian"]').datebox('setValue', formData.shijian);
}

function toUpd() {
    var updForm = $('#upd-gongzi-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(updForm, true)))
    if (checkForm(params)) {
        var item = $('#data-table').datagrid("getSelections")[0];

        // 构建更新数据对象
        var updateData = {
            id: item.id,
            renming: params.renming,
            shijian: params.shijian,
            kkqgongzi: parseFloat(params.kkqgongzi),
            koukuan: parseFloat(params.koukuan),
            yifu: parseFloat(params.yifu),
            yinhangzhanghu: params.yinhangzhanghu,
            beizhu: params.beizhu
        };

        $.ajax({
            type: 'Post',
            url: "web_service/gongzimingxi.asmx/upd",
            data: {
                updInfo: JSON.stringify(updateData)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#upd-gongzi-window').window('close');
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
    $('#add-gongzi-window').window({
        title: "新增工资明细",
        width: 500,
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
        onClose: function () {
            toReset('add-gongzi-form');
        }
    });
}

function toAdd() {
    var addForm = $('#add-gongzi-form').serialize();
    var params = JSON.parse(formToJson(decodeURIComponent(addForm, true)))
    if (checkForm(params)) {
        $.ajax({
            type: 'Post',
            url: "web_service/gongzimingxi.asmx/add",
            data: {
                simpleDataJson: JSON.stringify(params)
            },
            dataType: "xml",
            success: function (data) {
                var result = getJson(data);
                alert(result.msg);
                if (result.code == 200) {
                    $('#add-gongzi-window').window('close');
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
    if (!params.renming || params.renming == "") {
        alert("请输入姓名")
        return false;
    } else if (!params.shijian || params.shijian == "") {
        alert("请选择时间")
        return false;
    } else if (!params.kkqgongzi || params.kkqgongzi == "") {
        alert("请输入工资")
        return false;
    } else if (!params.koukuan || params.koukuan == "") {
        alert("请输入扣款金额")
        return false;
    } else if (!params.yifu || params.yifu == "") {
        alert("请输入已付金额")
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
        url: "web_service/gongzimingxi.asmx/del",
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
    var renming = $("#renming").val();
    var beizhu = $("#beizhu").val();

    $.ajax({
        type: 'Post',
        url: "web_service/gongzimingxi.asmx/getAllList",
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
            renming: renming,
            beizhu: beizhu
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200) {
                var array = result.data
                var header = []
                for (var i = 0; i < array.length; i++) {
                    // 计算工资和未付
                    var gongzi = 0;
                    var weifu = 0;

                    if (array[i].kkqgongzi != null && array[i].koukuan != null) {
                        gongzi = parseFloat(array[i].kkqgongzi) - parseFloat(array[i].koukuan);
                    }

                    if (array[i].yifu != null) {
                        weifu = gongzi - parseFloat(array[i].yifu);
                    } else {
                        weifu = gongzi;
                    }

                    var body = {
                        姓名: array[i].renming,
                        时间: array[i].shijian ? new Date(array[i].shijian).toLocaleDateString() : '',
                        工资: array[i].kkqgongzi ? parseFloat(array[i].kkqgongzi).toFixed(2) : '0.00',
                        扣款: array[i].koukuan ? parseFloat(array[i].koukuan).toFixed(2) : '0.00',
                        应付: gongzi.toFixed(2),
                        已付: array[i].yifu ? parseFloat(array[i].yifu).toFixed(2) : '0.00',
                        未付: weifu.toFixed(2),
                        银行账户: array[i].yinhangzhanghu,
                        备注: array[i].beizhu
                    }
                    header.push(body)
                }
                title = ['姓名', '时间', '工资', '扣款', '应付', '已付', '未付', '银行账户', '备注']
                JSONToExcelConvertor(header, "工资明细报表", title)
            }
        },
        error: function (err) {
            alert("错误！")
            console.log(err)
        }
    })
}

function toReset(id) {
    $('#' + id).form('reset')
}