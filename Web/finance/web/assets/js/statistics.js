//// 引入ECharts
//var echarts = null;
//var statisticsData = null;
//var isEChartsLoaded = false;

//$(function () {
//    // 初始化页面
//    initPage();
//});

//function initPage() {
//    // 初始化日期控件
//    initDateControls();
    
//    // 绑定查询事件
//    $("#btnSearch").off('click').on('click', function() {
//        loadStatisticsData();
//    });
    
//    // 添加被动事件监听器
//    addPassiveEventListeners();
    
//    // 页面加载时自动查询（延迟加载，确保DOM已完全加载）
//    setTimeout(function() {
//        loadStatisticsData();
//    }, 500);
//}

//function initDateControls() {
//    // 设置默认日期（当前月）
//    var now = new Date();
//    var firstDay = new Date(now.getFullYear(), now.getMonth(), 1);
//    var lastDay = new Date(now.getFullYear(), now.getMonth() + 1, 0);
    
//    // 格式化日期为 yyyy-MM-dd
//    function formatDate(date) {
//        var year = date.getFullYear();
//        var month = ('0' + (date.getMonth() + 1)).slice(-2);
//        var day = ('0' + date.getDate()).slice(-2);
//        return year + '-' + month + '-' + day;
//    }
    
//    $("#ks").datebox('setValue', formatDate(firstDay));
//    $("#js").datebox('setValue', formatDate(lastDay));
//}

//function addPassiveEventListeners() {
//    // 添加passive事件监听器以提高性能
//    try {
//        var originalAddEventListener = EventTarget.prototype.addEventListener;
//        EventTarget.prototype.addEventListener = function(type, listener, options) {
//            var passive = false;
            
//            // 为滚动事件添加passive选项
//            var passiveEvents = ['touchstart', 'touchmove', 'wheel', 'mousewheel'];
//            if (passiveEvents.indexOf(type) !== -1) {
//                passive = true;
//            }
            
//            if (typeof options === 'boolean') {
//                originalAddEventListener.call(this, type, listener, options);
//            } else if (typeof options === 'object') {
//                originalAddEventListener.call(this, type, listener, {
//                    ...options,
//                        passive: passive || (options && options.passive)
//            });
//        } else {
//            originalAddEventListener.call(this, type, listener, {
//                capture: false,
//                passive: passive
//            });
//        }
//    };
//} catch (e) {
//    console.warn('Unable to add passive event listeners:', e);
//}
//}

//function loadStatisticsData() {
//    var ks = $("#ks").datebox('getText');
//    var js = $("#js").datebox('getText');
    
//    if (!ks || !js) {
//        alert("请选择开始时间和结束时间");
//        return;
//    }
    
//    // 验证日期范围
//    var startDate = new Date(ks);
//    var endDate = new Date(js);
//    if (startDate > endDate) {
//        alert("开始时间不能晚于结束时间");
//        return;
//    }
    
//    $.ajax({
//        type: 'POST',
//        url: "web_service/Statistics.asmx/GetStatisticsData",
//        data: {
//            ks: ks,
//            js: js
//        },
//        dataType: "xml",
//        beforeSend: function () {
//            $.messager.progress({
//                title: '提示',
//                msg: '正在加载统计数据...',
//                text: ''
//            });
//        },
//        complete: function () {
//            $.messager.progress('close');
//        },
//        success: function (data) {
//            try {
//                var result = getJson(data);
//                if (result && result.success) {
//                    statisticsData = result.data;
                    
//                    // 确保ECharts已加载
//                    ensureEChartsLoaded(function() {
//                        renderAllCharts();
//                        updateSummaryInfo();
//                        updateDataTables();
//                    });
//                } else {
//                    var errorMsg = result ? result.message : "未知错误";
//                    alert("加载数据失败: " + errorMsg);
//                }
//            } catch (e) {
//                console.error('解析数据失败:', e);
//                alert("解析数据失败，请检查控制台");
//            }
//        },
//        error: function (err) {
//            console.error('请求错误:', err);
//            alert("请求错误：" + (err.statusText || "未知错误"));
//        }
//    });
//}

//function ensureEChartsLoaded(callback) {
//    if (typeof echarts !== 'undefined' && echarts !== null) {
//        initCharts();
//        if (callback) callback();
//        return;
//    }
    
//    // 加载ECharts库
//    $.ajax({
//        url: "../assets/js/echarts.min.js",
//        dataType: "script",
//        cache: true,
//        success: function() {
//            if (typeof echarts === 'undefined') {
//                console.error('ECharts未正确加载');
//                alert("图表库加载失败，请刷新页面重试");
//                return;
//            }
            
//            isEChartsLoaded = true;
//            initCharts();
//            if (callback) callback();
//        },
//        error: function() {
//            console.error('加载ECharts失败');
//            alert("加载图表库失败，请检查网络连接");
//        }
//    });
//}

//function initCharts() {
//    // 检查容器是否存在
//    if (!checkChartContainers()) {
//        console.warn('图表容器不存在，延迟初始化');
//        setTimeout(initCharts, 500);
//        return;
//    }
    
//    try {
//        // 初始化饼图
//        initPieChart();
//        // 初始化柱状图
//        initBarChart();
//        // 初始化折线图
//        initLineChart();
        
//        console.log('图表初始化完成');
//    } catch (e) {
//        console.error('图表初始化失败:', e);
//    }
//}

//function checkChartContainers() {
//    var pieContainer = document.getElementById('pieChart');
//    var barContainer = document.getElementById('barChart');
//    var lineContainer = document.getElementById('lineChart');
    
//    return pieContainer && barContainer && lineContainer;
//}

//function initPieChart() {
//    var pieContainer = document.getElementById('pieChart');
//    if (!pieContainer) {
//        console.error('饼图容器不存在');
//        return;
//    }
    
//    try {
//        var pieChart = echarts.init(pieContainer, null, {
//            renderer: 'canvas',
//            useDirtyRect: true
//        });
        
//        var option = {
//            title: {
//                text: '科目利润分布',
//                left: 'center'
//            },
//            tooltip: {
//                trigger: 'item',
//                formatter: '{a} <br/>{b}: {c} ({d}%)'
//            },
//            legend: {
//                orient: 'vertical',
//                left: 'left',
//                type: 'scroll'
//            },
//            series: [
//                {
//                    name: '利润分布',
//                    type: 'pie',
//                    radius: '50%',
//                    center: ['50%', '60%'],
//                    data: [],
//                    emphasis: {
//                        itemStyle: {
//                            shadowBlur: 10,
//                            shadowOffsetX: 0,
//                            shadowColor: 'rgba(0, 0, 0, 0.5)'
//                        }
//                    },
//                    label: {
//                        formatter: '{b}: {c} ({d}%)'
//                    }
//                }
//            ]
//        };
        
//        pieChart.setOption(option);
//        window.pieChart = pieChart;
        
//        // 添加resize监听
//        window.addEventListener('resize', function() {
//            pieChart.resize();
//        }, { passive: true });
        
//    } catch (e) {
//        console.error('初始化饼图失败:', e);
//    }
//}

//function initBarChart() {
//    var barContainer = document.getElementById('barChart');
//    if (!barContainer) {
//        console.error('柱状图容器不存在');
//        return;
//    }
    
//    try {
//        var barChart = echarts.init(barContainer, null, {
//            renderer: 'canvas',
//            useDirtyRect: true
//        });
        
//        var option = {
//            title: {
//                text: '月度利润对比',
//                left: 'center'
//            },
//            tooltip: {
//                trigger: 'axis',
//                axisPointer: {
//                    type: 'shadow'
//                }
//            },
//            legend: {
//                data: ['应收', '应付', '利润'],
//                top: 30
//            },
//            grid: {
//                left: '3%',
//                right: '4%',
//                bottom: '3%',
//                containLabel: true
//            },
//            xAxis: {
//                type: 'category',
//                data: []
//            },
//            yAxis: {
//                type: 'value'
//            },
//            series: [
//                {
//                    name: '应收',
//                    type: 'bar',
//                    data: [],
//                    itemStyle: {
//                        color: '#5470c6'
//                    }
//                },
//                {
//                    name: '应付',
//                    type: 'bar',
//                    data: [],
//                    itemStyle: {
//                        color: '#91cc75'
//                    }
//                },
//                {
//                    name: '利润',
//                    type: 'bar',
//                    data: [],
//                    itemStyle: {
//                        color: '#fac858'
//                    }
//                }
//            ]
//        };
        
//        barChart.setOption(option);
//        window.barChart = barChart;
        
//        // 添加resize监听
//        window.addEventListener('resize', function() {
//            barChart.resize();
//        }, { passive: true });
        
//    } catch (e) {
//        console.error('初始化柱状图失败:', e);
//    }
//}

//function initLineChart() {
//    var lineContainer = document.getElementById('lineChart');
//    if (!lineContainer) {
//        console.error('折线图容器不存在');
//        return;
//    }
    
//    try {
//        var lineChart = echarts.init(lineContainer, null, {
//            renderer: 'canvas',
//            useDirtyRect: true
//        });
        
//        var option = {
//            title: {
//                text: '利润趋势分析',
//                left: 'center'
//            },
//            tooltip: {
//                trigger: 'axis'
//            },
//            legend: {
//                data: ['利润', '应收', '应付'],
//                top: 30
//            },
//            grid: {
//                left: '3%',
//                right: '4%',
//                bottom: '3%',
//                containLabel: true
//            },
//            xAxis: {
//                type: 'category',
//                boundaryGap: false,
//                data: []
//            },
//            yAxis: {
//                type: 'value'
//            },
//            series: [
//                {
//                    name: '利润',
//                    type: 'line',
//                    data: [],
//                    smooth: true,
//                    lineStyle: {
//                        color: '#ee6666',
//                        width: 3
//                    }
//                },
//                {
//                    name: '应收',
//                    type: 'line',
//                    data: [],
//                    smooth: true,
//                    lineStyle: {
//                        color: '#5470c6',
//                        width: 2
//                    }
//                },
//                {
//                    name: '应付',
//                    type: 'line',
//                    data: [],
//                    smooth: true,
//                    lineStyle: {
//                        color: '#91cc75',
//                        width: 2
//                    }
//                }
//            ]
//        };
        
//        lineChart.setOption(option);
//        window.lineChart = lineChart;
        
//        // 添加resize监听
//        window.addEventListener('resize', function() {
//            lineChart.resize();
//        }, { passive: true });
        
//    } catch (e) {
//        console.error('初始化折线图失败:', e);
//    }
//}

//function renderAllCharts() {
//    if (!statisticsData || !isEChartsLoaded) {
//        console.warn('数据或图表库未加载');
//        return;
//    }
    
//    // 延迟渲染，确保DOM完全加载
//    setTimeout(function() {
//        try {
//            // 渲染饼图（按科目）
//            renderPieChart();
            
//            // 渲染柱状图（月度对比）
//            renderBarChart();
            
//            // 渲染折线图（趋势分析）
//            renderLineChart();
//        } catch (e) {
//            console.error('渲染图表失败:', e);
//        }
//    }, 100);
//}

//function renderPieChart() {
//    if (!window.pieChart || !statisticsData.accountingData) return;
    
//    var accountingData = statisticsData.accountingData;
//    if (accountingData.length === 0) {
//        window.pieChart.setOption({
//            series: [{
//                data: []
//            }],
//            title: {
//                text: '暂无数据',
//                left: 'center',
//                top: 'center',
//                textStyle: {
//                    color: '#999',
//                    fontSize: 14,
//                    fontWeight: 'normal'
//                }
//            }
//        });
//        return;
//    }
    
//    var pieData = [];
//    var legendData = [];
    
//    // 只显示利润前10的科目
//    var topAccounting = accountingData.slice(0, 10);
    
//    topAccounting.forEach(function(item) {
//        var profit = parseFloat(item.totalProfit || 0);
//        if (Math.abs(profit) > 0.01) { // 过滤掉极小的值
//            pieData.push({
//                name: item.accounting || '未分类',
//                value: profit.toFixed(2)
//            });
//            legendData.push(item.accounting || '未分类');
//        }
//    });
    
//    if (pieData.length === 0) {
//        pieData.push({
//            name: '无利润数据',
//            value: 1
//        });
//        legendData.push('无利润数据');
//    }
    
//    window.pieChart.setOption({
//        legend: {
//            data: legendData
//        },
//        series: [{
//            data: pieData
//        }]
//    }, true);
//}

//function renderBarChart() {
//    if (!window.barChart || !statisticsData.monthlyData) return;
    
//    var monthlyData = statisticsData.monthlyData;
//    if (monthlyData.length === 0) {
//        window.barChart.setOption({
//            xAxis: { data: [] },
//            series: [
//                { data: [] },
//                { data: [] },
//                { data: [] }
//            ]
//        });
//        return;
//    }
    
//    var categories = [];
//    var receivableData = [];
//    var copeData = [];
//    var profitData = [];
    
//    monthlyData.forEach(function(item) {
//        categories.push(item.month);
//        receivableData.push(parseFloat(item.netReceivable || 0));
//        copeData.push(parseFloat(item.netCope || 0));
//        profitData.push(parseFloat(item.monthlyProfit || 0));
//    });
    
//    window.barChart.setOption({
//        xAxis: {
//            data: categories
//        },
//        series: [
//            { data: receivableData },
//            { data: copeData },
//            { data: profitData }
//        ]
//    }, true);
//}

//function renderLineChart() {
//    if (!window.lineChart || !statisticsData.monthlyData) return;
    
//    var monthlyData = statisticsData.monthlyData;
//    if (monthlyData.length === 0) {
//        window.lineChart.setOption({
//            xAxis: { data: [] },
//            series: [
//                { data: [] },
//                { data: [] },
//                { data: [] }
//            ]
//        });
//        return;
//    }
    
//    var categories = [];
//    var profitTrend = [];
//    var receivableTrend = [];
//    var copeTrend = [];
    
//    monthlyData.forEach(function(item) {
//        categories.push(item.month);
//        profitTrend.push(parseFloat(item.monthlyProfit || 0));
//        receivableTrend.push(parseFloat(item.netReceivable || 0));
//        copeTrend.push(parseFloat(item.netCope || 0));
//    });
    
//    window.lineChart.setOption({
//        xAxis: {
//            data: categories
//        },
//        series: [
//            { data: profitTrend },
//            { data: receivableTrend },
//            { data: copeTrend }
//        ]
//    }, true);
//}

//function updateSummaryInfo() {
//    if (!statisticsData) return;
    
//    var rawData = statisticsData.rawData;
//    var summary = statisticsData.summary;
    
//    if (!rawData || !summary) {
//        console.warn('汇总数据为空');
//        return;
//    }
    
//    // 计算总计
//    var totalReceivable = 0;
//    var totalCope = 0;
//    var totalProfit = 0;
//    var totalNetReceivable = 0;
//    var totalNetCope = 0;
    
//    rawData.forEach(function(item) {
//        totalReceivable += parseFloat(item.receivable || 0);
//        totalCope += parseFloat(item.cope || 0);
        
//        // 计算单条记录的利润
//        var netReceivable = parseFloat(item.receivable || 0) - parseFloat(item.receipts || 0);
//        var netCope = parseFloat(item.cope || 0) - parseFloat(item.payment || 0);
//        var profit = netReceivable - netCope;
        
//        totalNetReceivable += netReceivable;
//        totalNetCope += netCope;
//        totalProfit += profit;
//    });
    
//    // 更新页面显示
//    $("#totalRecords").text(summary.totalRecords || 0);
//    $("#totalReceivable").text(totalReceivable.toFixed(2));
//    $("#totalCope").text(totalCope.toFixed(2));
//    $("#totalProfit").text(totalProfit.toFixed(2));
    
//    // 计算利润率
//    var profitRate = totalReceivable > 0 ? (totalProfit / totalReceivable * 100).toFixed(2) : 0;
//    $("#profitRate").text(profitRate + "%");
    
//    // 更新净额
//    $("#netReceivable").text(totalNetReceivable.toFixed(2));
//    $("#netCope").text(totalNetCope.toFixed(2));
//}

//function updateDataTables() {
//    if (!statisticsData) return;
    
//    // 更新月度表格
//    if (statisticsData.monthlyData) {
//        $('#monthlyTable').datagrid('loadData', statisticsData.monthlyData);
//    }
    
//    // 更新科目表格
//    if (statisticsData.accountingData) {
//        $('#accountingTable').datagrid('loadData', statisticsData.accountingData);
//    }
    
//    // 更新项目表格
//    if (statisticsData.projectData) {
//        $('#projectTable').datagrid('loadData', statisticsData.projectData);
//    }
//}

//// 导出数据到Excel
//function exportStatisticsData() {
//    if (!statisticsData) {
//        alert("请先查询数据");
//        return;
//    }
    
//    var ks = $("#ks").datebox('getText');
//    var js = $("#js").datebox('getText');
//    var filename = "统计报表_" + ks + "_至_" + js;
    
//    // 准备数据
//    var exportData = [];
    
//    // 1. 汇总数据
//    exportData.push({
//        sheetName: "数据汇总",
//        data: [
//            ["项目", "数值"],
//            ["总记录数", statisticsData.summary.totalRecords],
//            ["开始时间", statisticsData.summary.startDate],
//            ["结束时间", statisticsData.summary.endDate],
//            ["公司", statisticsData.summary.company]
//        ]
//    });
    
//    // 2. 月度数据
//    var monthlySheet = [["月份", "应收总额", "实收总额", "应付总额", "实付总额", "净利润"]];
//    if (statisticsData.monthlyData) {
//        statisticsData.monthlyData.forEach(function(item) {
//            monthlySheet.push([
//                item.month,
//                item.totalReceivable.toFixed(2),
//                item.totalReceipts.toFixed(2),
//                item.totalCope.toFixed(2),
//                item.totalPayment.toFixed(2),
//                item.monthlyProfit.toFixed(2)
//            ]);
//        });
//    }
//    exportData.push({
//        sheetName: "月度统计",
//        data: monthlySheet
//    });
    
//    // 3. 科目数据
//    var accountingSheet = [["科目", "应收总额", "实收总额", "应付总额", "实付总额", "利润", "记录数"]];
//    if (statisticsData.accountingData) {
//        statisticsData.accountingData.forEach(function(item) {
//            accountingSheet.push([
//                item.accounting || "未分类",
//                item.totalReceivable.toFixed(2),
//                item.totalReceipts.toFixed(2),
//                item.totalCope.toFixed(2),
//                item.totalPayment.toFixed(2),
//                item.totalProfit.toFixed(2),
//                item.recordCount || 0
//            ]);
//        });
//    }
//    exportData.push({
//        sheetName: "科目分析",
//        data: accountingSheet
//    });
    
//    // 调用导出函数
//    exportToExcel(exportData, filename);
//}

//// 多Sheet Excel导出函数
//function exportToExcel(sheets, filename) {
//    var excelFile = "";
    
//    sheets.forEach(function(sheet, index) {
//        excelFile += '<table border="1">';
//        excelFile += '<caption><strong>' + sheet.sheetName + '</strong></caption>';
        
//        sheet.data.forEach(function(row) {
//            excelFile += '<tr>';
//            row.forEach(function(cell) {
//                excelFile += '<td>' + (cell || '') + '</td>';
//            });
//            excelFile += '</tr>';
//        });
        
//        excelFile += '</table>';
        
//        // 添加分页符（除了最后一个sheet）
//        if (index < sheets.length - 1) {
//            excelFile += '<div style="page-break-after: always;"></div>';
//        }
//    });
    
//    var fullExcel = '<html xmlns:o="urn:schemas-microsoft-com:office:office" ' +
//                   'xmlns:x="urn:schemas-microsoft-com:office:excel" ' +
//                   'xmlns="http://www.w3.org/TR/REC-html40">' +
//                   '<head><meta charset="UTF-8"></head><body>' + 
//                   excelFile + '</body></html>';
    
//    var uri = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(fullExcel);
//    var link = document.createElement("a");
//    link.href = uri;
//    link.download = filename + ".xls";
//    link.style = "visibility:hidden";
//    document.body.appendChild(link);
//    link.click();
//    document.body.removeChild(link);
//}

//// 图表切换视图
//function switchView(viewType) {
//    $(".chart-container").hide();
//    $(".summary-container").hide();
    
//    if (viewType === 'summary') {
//        $(".summary-container").show();
//    } else {
//        $("#" + viewType + "Container").show();
//    }
    
//    // 重新渲染图表
//    setTimeout(function() {
//        if (window[viewType + 'Chart']) {
//            window[viewType + 'Chart'].resize();
//        }
//    }, 100);
//}

//// 优化setTimeout性能
//function optimizedSetTimeout(callback, delay) {
//    return setTimeout(function() {
//        try {
//            callback();
//        } catch (e) {
//            console.error('setTimeout callback error:', e);
//        }
//    }, Math.max(delay, 0));
//}