var page = {
    currentPage: 1,
    pageSize: 20,
    total: 0,
    pageList: [],
    selectParamsMap: {
        project: '',
    }
}

// 存储税率配置数据
var taxRates = [];
var taxThresholds = [];

// 计算弹窗相关变量
var currentCalculationType = 'receivable';

// 下拉选项变化事件
$(function () {
    $('#calculation-type').combobox({
        onSelect: function (record) {
            // 延迟执行，确保组件完全初始化
            setTimeout(function () {
                autoFillCalculationValue(record.value);
            }, 50);
        }
    });
});



// 存储应收应付配置数据
var ysyfData = [];

// 获取应收应付配置
function getYSYFConfig(projectName, type) {
    var sum = 0;

    // 查找对应项目名称和类型的配置
    ysyfData.forEach(function (item) {
        if (item.xiangmumingcheng === projectName && item.ysyf === type) {
            // 解析金额字符串，如 "2,3,1" 或 "3,4,5"
            var amounts = item.jine.split(',');
            amounts.forEach(function (amountStr) {
                var amount = parseFloat(amountStr.trim());
                if (!isNaN(amount)) {
                    sum += amount;
                }
            });
        }
    });

    return sum;
}

// 加载应收应付配置
function loadYSYFConfig() {
    $.ajax({
        type: 'Post',
        url: "web_service/ysyfpz.asmx/getList",
        data: {
            financePageJson: JSON.stringify(page),
            ysyf: '',
            xiangmumingcheng: ''

        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200 && result.data && result.data.pageList) {
                ysyfData = result.data.pageList;
                console.log('应收应付配置加载成功:', ysyfData);
            }
        },
        error: function (err) {
            console.error("获取应收应付配置错误:", err);
        }
    });
}

// 通用获取表单值的方法
function getFormValue(selector) {
    var $element = $(selector);
    if ($element.length === 0) {
        return '';
    }

    try {
        // 尝试使用 EasyUI 方法
        if ($element.hasClass('easyui-textbox') || $element.data('textbox')) {
            return $element.textbox('getValue') || '';
        } else if ($element.hasClass('easyui-numberbox') || $element.data('numberbox')) {
            return $element.numberbox('getValue') || '';
        } else {
            // 普通输入框
            return $element.val() || '';
        }
    } catch (e) {
        console.warn('使用EasyUI方法失败，使用备用方案:', e);
        return $element.val() || '';
    }
}

// 统一设置值的方法
function setFormValue(selector, value) {
    var $element = $(selector);
    if ($element.length === 0) {
        console.warn('元素不存在:', selector);
        return false;
    }

    try {
        if ($element.hasClass('easyui-numberbox')) {
            $element.numberbox('setValue', value);
        } else if ($element.hasClass('easyui-textbox')) {
            $element.textbox('setValue', value);
        } else if ($element.data('numberbox')) {
            $element.numberbox('setValue', value);
        } else if ($element.data('textbox')) {
            $element.textbox('setValue', value);
        } else {
            $element.val(value);
        }

        // 触发变化事件
        $element.trigger('change');
        return true;
    } catch (e) {
        console.error('设置值失败，使用备用方案:', e);
        $element.val(value);
        $element.trigger('change');
        return false;
    }
}

function setReceivableValueUltimate() {
    console.log('===== 开始计算应收=====');

    var projectName = $('#add-simpleData-form input[name="project"]').val();
    console.log('项目名称:', projectName);

    if (!projectName || projectName.trim() === '') {
        var projectName = $('#upd-simpleData-form input[name="project"]').val();
    }

    if (!projectName || projectName.trim() === '') {
        $.messager.alert('提示', '请先填写项目名称', 'warning');
        return;
    }

    var sum = getYSYFConfig(projectName, '应收');
    console.log('应收金额:', sum);

    if (sum <= 0) {
        $.messager.alert('提示', '未找到项目 "' + projectName + '" 对应的应收配置', 'warning');
        return;
    }

    // 直接找到EasyUI numberbox并设置值
    addyingshou('#add-simpleData-form input[name="receivable"]', sum);

    $.messager.show({
        title: '计算成功',
        msg: '应收金额: ' + sum + '元',
        timeout: 2000
    });
}

function setCopeValueUltimate() {
    console.log('===== 开始计算应付=====');

    var projectName = $('#add-simpleData-form input[name="project"]').val();
    console.log('项目名称:', projectName);


    if (!projectName || projectName.trim() === '') {
        var projectName = $('#upd-simpleData-form input[name="project"]').val();
    }

    if (!projectName || projectName.trim() === '') {
        $.messager.alert('提示', '请先填写项目名称', 'warning');
        return;
    }

    var sum = getYSYFConfig(projectName, '应付');
    console.log('应付金额:', sum);

    if (sum <= 0) {
        $.messager.alert('提示', '未找到项目 "' + projectName + '" 对应的应付配置', 'warning');
        return;
    }

    addyingfu('#add-simpleData-form input[name="cope"]', sum);

    $.messager.show({
        title: '计算成功',
        msg: '应付金额: ' + sum + '元',
        timeout: 2000
    });
}

// 终极解决方案：直接操作EasyUI numberbox内部显示
function addyingshou(selector, value) {
    var $input = $(selector);
    if ($input.length === 0) {
        console.warn('输入框不存在:', selector);
        return false;
    }

    console.log('开始设置:', selector, '值:', value);

    // 获取是从哪个窗口打开的计算弹窗
    var fromWindow = $('#tax-calculator-window').data('fromWindow');

    if (fromWindow === 'add') {
        $('#add-receivable').numberbox('setValue', value);
        console.log('应用到新增窗口的应收金额:', value);
    } else if (fromWindow === 'upd') {
        // 应用到修改窗口的纳税金额字段
        $('#upd-receivable').numberbox('setValue', value);
        console.log('应用到修改窗口的应收金额:', value);
    } else {
        // 默认情况下两个都尝试设置
        $('#add-receivable, #upd-receivable').numberbox('setValue', value);
        console.log('默认应用到两个窗口的应收金额:', value);
    }

    // 给用户反馈
    $.messager.show({
        title: '提示',
        msg: '应收金额已应用到表单',
        timeout: 2000,
        showType: 'slide'
    });

    // 关闭窗口
    setTimeout(function () {
        $('#tax-calculator-window').window('close');
    }, 500);
}

// 终极解决方案：直接操作EasyUI numberbox内部显示
function addyingfu(selector, value) {
    var $input = $(selector);
    if ($input.length === 0) {
        console.warn('输入框不存在:', selector);
        return false;
    }

    console.log('开始设置:', selector, '值:', value);

    // 获取是从哪个窗口打开的计算弹窗
    var fromWindow = $('#tax-calculator-window').data('fromWindow');

    if (fromWindow === 'add') {
        $('#add-cope').numberbox('setValue', value);
        console.log('应用到新增窗口的应付金额:', value);
    } else if (fromWindow === 'upd') {
        // 应用到修改窗口的纳税金额字段
        $('#upd-cope').numberbox('setValue', value);
        console.log('应用到修改窗口的应付金额:', value);
    } else {
        // 默认情况下两个都尝试设置
        $('#add-cope, #upd-cope').numberbox('setValue', value);
        console.log('默认应用到两个窗口的应付金额:', value);
    }

    // 给用户反馈
    $.messager.show({
        title: '提示',
        msg: '应付金额已应用到表单',
        timeout: 2000,
        showType: 'slide'
    });

    // 关闭窗口
    setTimeout(function () {
        $('#tax-calculator-window').window('close');
    }, 500);
}


// 调试函数：检查EasyUI组件结构
function debugEasyUIStructure(selector) {
    var $input = $(selector);
    console.log('===== 调试EasyUI结构 =====');
    console.log('选择器:', selector);
    console.log('输入框:', $input);
    console.log('类名:', $input.attr('class'));
    console.log('是否有numberbox类:', $input.hasClass('easyui-numberbox'));
    console.log('data-numberbox:', $input.data('numberbox'));

    var textbox = $input.next('.textbox');
    console.log('textbox容器:', textbox.length > 0 ? '找到' : '未找到');

    if (textbox.length) {
        console.log('textbox HTML:', textbox[0].outerHTML);

        var textboxValue = textbox.find('.textbox-value');
        console.log('textbox-value:', textboxValue.length > 0 ? '找到' : '未找到', '值:', textboxValue.val());

        var textboxText = textbox.find('.textbox-text');
        console.log('textbox-text:', textboxText.length > 0 ? '找到' : '未找到', '值:', textboxText.val(), '文本:', textboxText.text());
    }
}


// 获取税率配置
function getTaxConfig() {
    $.ajax({
        type: 'Post',
        url: "web_service/shuilvpeihzi.asmx/getList",
        beforeSend: function () {
            $.messager.progress({
                title: '提示',
                msg: '正在加载税率配置',
                text: ''
            });
        },
        complete: function () {
            $.messager.progress('close');
        },
        data: {
            financePageJson: JSON.stringify(page),
            shuilv: '',
            linjiezhi: ''
        },
        dataType: "xml",
        success: function (data) {
            var result = getJson(data);
            if (result.code == 200 && result.data && result.data.pageList) {
                taxRates = [];
                taxThresholds = [];
                result.data.pageList.forEach(function (item) {
                    taxRates.push(parseFloat(item.shuilv) || 0);
                    taxThresholds.push(parseFloat(item.linjiezhi) || 0);
                });
                console.log('税率配置加载成功:', taxRates, taxThresholds);
            }
        },
        error: function (err) {
            console.error("获取税率配置错误:", err);
            // 使用默认税率配置
            taxRates = [2, 5];
            taxThresholds = [500, 2000];
        }
    });
}

// 计算应交税金额
function calculateTax(amount) {
    if (!amount || amount <= 0) return 0;

    var tax = 0;
    var remainingAmount = amount;

    // 按税率阶梯计算
    for (var i = taxThresholds.length - 1; i >= 0; i--) {
        if (remainingAmount > taxThresholds[i]) {
            var taxableAmount = remainingAmount - taxThresholds[i];
            tax += taxableAmount * (taxRates[i] / 100);
            remainingAmount = taxThresholds[i];
        }
    }

    return parseFloat(tax.toFixed(2));
}

// 打开计算弹窗
function openTaxCalculator(type) {
    currentCalculationType = type || 'receivable';

    // 先清空表单
    $('#tax-calculator-form').form('clear');

    // 打开窗口
    $('#tax-calculator-window').window({
        title: "计算应交税金额",
        width: 450,
        height: 380,
        modal: true,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        onOpen: function () {
            // 使用简化的combobox初始化
            $('#calculation-type').combobox({
                valueField: 'value',
                textField: 'text',
                data: [{
                    "value": "receivable",
                    "text": "应收"
                }, {
                    "value": "receipts",
                    "text": "实收"
                }, {
                    "value": "profit",
                    "text": "利润"
                }],
                editable: false,
                onSelect: function (record) {
                    currentCalculationType = record.value;
                    // 直接调用获取值
                    getFormValueForCalculation(currentCalculationType);
                }
            });

            // 设置默认值
            $('#calculation-type').combobox('setValue', currentCalculationType);
            // 获取值
            getFormValueForCalculation(currentCalculationType);
        }
    }).window('open');
}

// 获取表单值用于计算
function getFormValueForCalculation(type) {
    var value = 0;

    if (type === 'receivable') {
        // 尝试从添加窗口获取
        var addVal = $('#add-simpleData-form input[name="receivable"]').val();
        // 尝试从修改窗口获取
        var updVal = $('#upd-simpleData-form input[name="receivable"]').val();
        value = parseFloat(addVal || updVal || 0);
    } else if (type === 'receipts') {
        var addVal = $('#add-simpleData-form input[name="receipts"]').val();
        var updVal = $('#upd-simpleData-form input[name="receipts"]').val();
        value = parseFloat(addVal || updVal || 0);
    } else if (type === 'profit') {
        var receivableAdd = $('#add-simpleData-form input[name="receivable"]').val();
        var receivableUpd = $('#upd-simpleData-form input[name="receivable"]').val();
        var copeAdd = $('#add-simpleData-form input[name="cope"]').val();
        var copeUpd = $('#upd-simpleData-form input[name="cope"]').val();

        var receivable = parseFloat(receivableAdd || receivableUpd || 0);
        var cope = parseFloat(copeAdd || copeUpd || 0);
        value = receivable - cope;
    }

    $('#calculation-value').numberbox('setValue', value);
}

// 自动填充计算值 - 直接获取表单值，不检查窗口状态
function autoFillCalculationValue(type) {
    var value = 0;

    if (type === 'receivable') {
        // 获取应收值 - 直接获取，不检查窗口状态
        var receivableInput = $('#add-simpleData-form input[name="receivable"], #upd-simpleData-form input[name="receivable"]');
        value = parseFloat(receivableInput.val()) || 0;
    } else if (type === 'receipts') {
        // 获取实收值 - 直接获取，不检查窗口状态
        var receiptsInput = $('#add-simpleData-form input[name="receipts"], #upd-simpleData-form input[name="receipts"]');
        value = parseFloat(receiptsInput.val()) || 0;
    } else if (type === 'profit') {
        // 计算利润：应收 - 应付
        var receivableInput = $('#add-simpleData-form input[name="receivable"], #upd-simpleData-form input[name="receivable"]');
        var copeInput = $('#add-simpleData-form input[name="cope"], #upd-simpleData-form input[name="cope"]');
        var receivable = parseFloat(receivableInput.val()) || 0;
        var cope = parseFloat(copeInput.val()) || 0;
        value = receivable - cope;
    }

    // 如果获取到的值无效，设置为0
    if (isNaN(value) || value <= 0) {
        value = 0;
    }

    $('#calculation-value').numberbox('setValue', value);
}


// 执行计算
function performCalculation() {
    var type = $('#calculation-type').combobox('getValue');
    var value = parseFloat($('#calculation-value').numberbox('getValue')) || 0;

    if (value <= 0) {
        $.messager.alert('提示', '计算数值必须大于0，请检查表单是否已填写', 'warning');

        // 如果值为0，重新获取一次
        getFormValueForCalculation(type);
        value = parseFloat($('#calculation-value').numberbox('getValue')) || 0;

        if (value <= 0) {
            return;
        }
    }

    var taxAmount = calculateTax(value);
    $('#calculated-tax').numberbox('setValue', taxAmount);

    // 显示计算成功提示
    $.messager.show({
        title: '计算成功',
        msg: '计算纳税金额: ' + taxAmount + '元<br>计算基础: ' + value + '元',
        timeout: 3000,
        showType: 'slide'
    });
}

// 应用计算结果
function applyTaxCalculation() {
    var taxAmount = $('#calculated-tax').numberbox('getValue') || 0;

    if (taxAmount <= 0) {
        $.messager.alert('提示', '请先进行计算', 'warning');
        return;
    }

    // 获取是从哪个窗口打开的计算弹窗
    var fromWindow = $('#tax-calculator-window').data('fromWindow');

    if (fromWindow === 'add') {
        // 应用到新增窗口的纳税金额字段
        $('#add-nashuijine').numberbox('setValue', taxAmount);
        console.log('应用到新增窗口的纳税金额:', taxAmount);
    } else if (fromWindow === 'upd') {
        // 应用到修改窗口的纳税金额字段
        $('#upd-nashuijine').numberbox('setValue', taxAmount);
        console.log('应用到修改窗口的纳税金额:', taxAmount);
    } else {
        // 默认情况下两个都尝试设置
        $('#add-nashuijine, #upd-nashuijine').numberbox('setValue', taxAmount);
        console.log('默认应用到两个窗口的纳税金额:', taxAmount);
    }

    // 给用户反馈
    $.messager.show({
        title: '提示',
        msg: '纳税金额已应用到表单',
        timeout: 2000,
        showType: 'slide'
    });

    // 关闭窗口
    setTimeout(function () {
        $('#tax-calculator-window').window('close');
    }, 500);
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
    // 初始化时获取税率配置
    getTaxConfig();

    // 加载应收应付配置
    loadYSYFConfig();

    // 添加调试按钮（临时使用）
    setTimeout(function () {
        // 在控制台添加调试命令
        window.debugInput = function () {
            debugEasyUIStructure('#add-simpleData-form input[name="receivable"]');
        };

        console.log('调试命令已加载: debugInput()');
    }, 3000);

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
            start_date: start_date,
            stop_date: stop_date
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

// 设置表格信息
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
                    return (row.receivable || 0) - (row.receipts || 0);
                }
            },
            { field: 'cope', align: 'center', title: '应付', width: 100 },
            { field: 'payment', align: 'center', title: '实付', width: 100 },
            {
                field: 'paid', align: 'center', title: '未付', width: 100, formatter: function (value, row, index) {
                    return (row.cope || 0) - (row.payment || 0);
                }
            },
            { field: 'nashuijine', align: 'center', title: '纳税金额', width: 100 },
            { field: 'yijiaoshuijine', align: 'center', title: '已纳税金额', width: 100 },
            {
                field: 'weinashuijine', align: 'center', title: '未纳税金额', width: 100, formatter: function (value, row, index) {
                    return (row.nashuijine || 0) - (row.yijiaoshuijine || 0);
                }
            },
            { field: 'accounting', align: 'center', title: '科目', width: 220 },
            { field: 'zhaiyao', align: 'center', title: '摘要', width: 220 }
        ]]
    });

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
        height: 600,
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
            });

            $("#upd_kehu").combobox({
                valueField: 'kehu',
                textField: 'kehu',
                width: 318,
                height: 38
            });

            var insert_date = formatDate(rowItem.insert_date, 'MM/dd/yyyy HH:mm:ss')
            $('#upd_insert_date').datetimebox({
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
        item.yijiaoshuijine = params.yijiaoshuijine;  // 使用正确的字段名
        item.nashuijine = params.nashuijine;

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
        height: 600,
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
        // 确保字段名正确映射到后端
        var backendParams = {
            insert_date: params.insert_date,
            accounting: params.accounting,
            project: params.project,
            kehu: params.kehu,
            receivable: params.receivable,
            receipts: params.receipts,
            cope: params.cope,
            payment: params.payment,
            yijiaoshuijine: params.yijiaoshuijine,  // 正确的字段名
            nashuijine: params.nashuijine,
            zhaiyao: params.zhaiyao
        };

        $.ajax({
            type: 'Post',
            url: "web_service/simpleData.asmx/addSimpleData",
            data: {
                simpleDataJson: JSON.stringify(backendParams)
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
                        stop_date: stop_date,
                    },
                    dataType: "xml",
                    success: function (data) {
                        var result = getJson(data);
                        if (result.code == 200) {
                            var array = result.data.pageList
                            var header = []
                            for (var i = 0; i < array.length; i++) {
                                var uncollected = (array[i].receivable || 0) - (array[i].receipts || 0);
                                var paid = (array[i].cope || 0) - (array[i].payment || 0);
                                var weinashuijine = (array[i].nashuijine || 0) - (array[i].yijiaoshuijine || 0);
                                var insert_date = array[i].insert_date;
                                var voucherDate = '';
                                if (insert_date && insert_date != "") {
                                    var localstring = insert_date.replace("/Date(", "").replace(")/", "");
                                    voucherDate = formatDate(parseInt(localstring), "yyyy-MM-dd HH:mm");
                                }

                                var body = {
                                    project: array[i].project || '',
                                    insert_date: voucherDate,
                                    kehu: array[i].kehu || '',
                                    receivable: array[i].receivable || 0,
                                    receipts: array[i].receipts || 0,
                                    uncollected: uncollected,
                                    cope: array[i].cope || 0,
                                    payment: array[i].payment || 0,
                                    paid: paid,
                                    yijiaoshuijine: array[i].yijiaoshuijine || 0,
                                    nashuijine: array[i].nashuijine || 0,
                                    weinashuijine: weinashuijine,
                                    accounting: array[i].accounting || '',
                                    zhaiyao: array[i].zhaiyao || '',
                                }
                                header.push(body)
                            }
                            title = ['项目名称', '日期', '客户', '应收', '实收', '未收', '应付', '实付', '未付', '已纳税金额', '纳税金额', '未纳税金额', '科目', '摘要']
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