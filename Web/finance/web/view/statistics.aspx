<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statistics.aspx.cs" Inherits="Web.finance.web.view.statistics" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>统计分析</title>
    
    <!-- 新界面样式和库 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.4/css/all.min.css" />
    
    <!-- 保留原有的 EasyUI 样式（可选） -->
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/statistics.css"/>
    
    <!-- 新样式 -->
    <style>
        :root {
            --primary-color: #3498db;
            --secondary-color: #2ecc71;
            --danger-color: #e74c3c;
            --warning-color: #f39c12;
            --info-color: #1abc9c;
            --dark-color: #2c3e50;
            --light-color: #ecf0f1;
            --border-radius: 8px;
            --box-shadow: 0 4px 6px rgba(0,0,0,0.1);
        }
        
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            padding-top: 70px;
        }
        
        .navbar {
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            background: linear-gradient(135deg, rgb(58, 12, 163) 0%, rgb(76, 201, 240) 100%);
        }
        
        .stat-card {
            background: white;
            border-radius: var(--border-radius);
            padding: 20px;
            margin-bottom: 20px;
            box-shadow: var(--box-shadow);
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            border-left: 4px solid var(--primary-color);
        }
        
        .stat-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 6px 12px rgba(0,0,0,0.15);
        }
        
        .stat-card.warning {
            border-left-color: var(--warning-color);
        }
        
        .stat-card.success {
            border-left-color: var(--secondary-color);
        }
        
        .stat-card.danger {
            border-left-color: var(--danger-color);
        }
        
        .stat-card.info {
            border-left-color: var(--info-color);
        }
        
        .stat-value {
            font-size: 2.2rem;
            font-weight: 700;
            color: var(--dark-color);
            margin-bottom: 5px;
        }
        
        .stat-label {
            font-size: 0.9rem;
            color: #6c757d;
            text-transform: uppercase;
            letter-spacing: 1px;
        }
        
        /* 调整图表容器 */
        .chart-container {
            background: white;
            border-radius: var(--border-radius);
            padding: 15px;
            margin-bottom: 15px;
            box-shadow: var(--box-shadow);
            display: none;
            min-height: 300px; /* 设置最小高度 */
        }
        
        .chart-container.active {
            display: block;
        }
        
        .chart-title {
            color: var(--dark-color);
            font-weight: 600;
            margin-bottom: 15px; /* 减小标题下边距 */
            padding-bottom: 8px; /* 减小内边距 */
            border-bottom: 2px solid #f0f0f0;
            font-size: 1.1rem; /* 减小标题字体大小 */
        }
        
        .view-switch {
            margin-top: 15px;
        }
        
        .nav-tabs {
            border-bottom: 2px solid #dee2e6;
        }
        
        .nav-tabs .nav-link {
            border: none;
            padding: 8px 20px; /* 减小选项卡内边距 */
            font-weight: 600;
            color: #6c757d;
            border-radius: var(--border-radius) var(--border-radius) 0 0;
            margin-right: 5px;
            font-size: 0.9rem; /* 减小选项卡字体大小 */
        }
        
        .nav-tabs .nav-link.active {
            color: var(--primary-color);
            background-color: white;
            border-bottom: 3px solid var(--primary-color);
        }
        
        .loading-overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(255, 255, 255, 0.9);
            display: flex;
            justify-content: center;
            align-items: center;
            z-index: 9999;
            display: none;
        }
        
        .spinner {
            width: 50px;
            height: 50px;
            border: 5px solid #f3f3f3;
            border-top: 5px solid var(--primary-color);
            border-radius: 50%;
            animation: spin 1s linear infinite;
        }
        
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    </style>
</head>
<body>
    <!-- 导航栏 -->
    <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
        <div class="container">
            <a class="navbar-brand" href="#">
                <i class="fas fa-chart-line mr-2"></i>
                统计分析系统
            </a>
        </div>
    </nav>

    <!-- 加载动画 -->
    <div class="loading-overlay" id="loadingOverlay">
        <div class="spinner"></div>
    </div>

    <div class="container">
        <!-- 筛选条件卡片 -->
        <div class="filter-card">
            <h4 class="mb-4"><i class="fas fa-filter mr-2"></i>数据筛选</h4>
            <div class="row">
                <div class="col-md-4">
                    <div class="date-input-group">
                        <label for="ks"><i class="far fa-calendar-alt mr-2"></i>开始日期</label>
                        <input type="text" id="ks" class="form-control" placeholder="选择开始日期">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="date-input-group">
                        <label for="js"><i class="far fa-calendar-alt mr-2"></i>结束日期</label>
                        <input type="text" id="js" class="form-control" placeholder="选择结束日期">
                    </div>
                </div>
                <div class="col-md-4 d-flex align-items-end">
                    <button id="btnSearch" class="btn btn-primary btn-lg w-100">
                        <i class="fas fa-search mr-2"></i>查询统计
                    </button>
                </div>
            </div>
        </div>

        <!-- 视图切换选项卡 -->
        <ul class="nav nav-tabs" id="chartTabs" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="summary-tab" data-toggle="tab" href="#summary" role="tab">
                    <i class="fas fa-chart-bar mr-2"></i>数据汇总
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="pie-tab" data-toggle="tab" href="#pieChart" role="tab">
                    <i class="fas fa-chart-pie mr-2"></i>利润分布
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="bar-tab" data-toggle="tab" href="#barChart" role="tab">
                    <i class="fas fa-chart-bar mr-2"></i>月度对比
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="line-tab" data-toggle="tab" href="#lineChart" role="tab">
                    <i class="fas fa-chart-line mr-2"></i>趋势分析
                </a>
            </li>
        </ul>

        <div class="tab-content" id="chartTabsContent">
            <!-- 数据汇总 -->
            <div class="tab-pane fade show active" id="summary" role="tabpanel">
                <!-- 统计卡片 -->
                <div class="row" id="statCards">
                    <!-- 统计卡片将通过JS动态生成 -->
                </div>

                <!-- 数据表格 -->
                <div class="mt-4">
                    <div class="easyui-tabs" style="width:100%;height:400px;">
                        <div title="月度统计" style="padding:10px;">
                            <table id="monthlyTable" class="easyui-datagrid" style="width:100%;height:100%">
                                <thead>
                                    <tr>
                                        <th data-options="field:'month',width:100">月份</th>
                                        <th data-options="field:'totalReceivable',width:100,align:'right'">应收总额</th>
                                        <th data-options="field:'totalReceipts',width:100,align:'right'">实收总额</th>
                                        <th data-options="field:'totalCope',width:100,align:'right'">应付总额</th>
                                        <th data-options="field:'totalPayment',width:100,align:'right'">实付总额</th>
                                        <th data-options="field:'monthlyProfit',width:100,align:'right'">净利润</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                        <div title="科目分析" style="padding:10px;">
                            <table id="accountingTable" class="easyui-datagrid" style="width:100%;height:100%">
                                <thead>
                                    <tr>
                                        <th data-options="field:'accounting',width:150">科目</th>
                                        <th data-options="field:'totalReceivable',width:100,align:'right'">应收总额</th>
                                        <th data-options="field:'totalReceipts',width:100,align:'right'">实收总额</th>
                                        <th data-options="field:'totalCope',width:100,align:'right'">应付总额</th>
                                        <th data-options="field:'totalPayment',width:100,align:'right'">实付总额</th>
                                        <th data-options="field:'totalProfit',width:100,align:'right'">利润</th>
                                        <th data-options="field:'recordCount',width:80,align:'center'">记录数</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 饼图 -->
            <div class="tab-pane fade" id="pieChart" role="tabpanel">
                <div class="chart-container active">
                    <h4 class="chart-title">科目利润分布</h4>
                    <canvas id="pieChartCanvas" height="280" style="padding: 100px;" ></canvas>
                </div>
            </div>

            <!-- 柱状图 -->
            <div class="tab-pane fade" id="barChart" role="tabpanel">
                <div class="chart-container active">
                    <h4 class="chart-title">月度利润对比</h4>
                    <canvas id="barChartCanvas" height="280" style="padding: 100px;"></canvas>
                </div>
            </div>

            <!-- 折线图 -->
            <div class="tab-pane fade" id="lineChart" role="tabpanel">
                <div class="chart-container active">
                    <h4 class="chart-title">利润趋势分析</h4>
                    <canvas id="lineChartCanvas" height="280" style="padding: 100px;"></canvas>
                </div>
            </div>
        </div>

        <!-- 导出按钮 -->
        <div class="export-buttons text-center mt-4">
            <button class="btn btn-success" onclick="exportStatisticsData()">
                <i class="fas fa-file-excel mr-2"></i>导出Excel
            </button>
        </div>
    </div>

    <!-- JS 库 -->
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    
    <!-- 保留原有的 EasyUI JS -->
    <script type="text/javascript" src="../assets/js/EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    
    <!-- 修改后的 statistics.js -->
    <script type="text/javascript">
        // 全局变量
        var statisticsData = null;
        var charts = {
            pie: null,
            bar: null,
            line: null
        };
        
        $(function () {
            // 初始化页面
            initPage();
        });
        
        function initPage() {
            // 初始化日期控件（使用 flatpickr）
            initDateControls();
            
            // 绑定查询事件
            $("#btnSearch").off('click').on('click', function() {
                loadStatisticsData();
            });
            
            // 页面加载时自动查询
            setTimeout(function() {
                loadStatisticsData();
            }, 500);
        }
        
        function initDateControls() {
            // 设置默认日期（当前月）
            var now = new Date();
            var firstDay = new Date(now.getFullYear(), now.getMonth(), 1);
            var lastDay = new Date(now.getFullYear(), now.getMonth() + 1, 0);
            
            // 格式化日期为 yyyy-MM-dd
            function formatDate(date) {
                var year = date.getFullYear();
                var month = ('0' + (date.getMonth() + 1)).slice(-2);
                var day = ('0' + date.getDate()).slice(-2);
                return year + '-' + month + '-' + day;
            }
            
            // 使用 flatpickr 初始化日期选择器
            flatpickr("#ks", {
                dateFormat: "Y-m-d",
                defaultDate: firstDay,
                maxDate: "today"
            });
            
            flatpickr("#js", {
                dateFormat: "Y-m-d",
                defaultDate: lastDay,
                maxDate: "today"
            });
            
            $("#ks").val(formatDate(firstDay));
            $("#js").val(formatDate(lastDay));
        }
        
        function loadStatisticsData() {
            var ks = $("#ks").val();
            var js = $("#js").val();
            
            if (!ks || !js) {
                alert("请选择开始时间和结束时间");
                return;
            }
            
            // 验证日期范围
            var startDate = new Date(ks);
            var endDate = new Date(js);
            if (startDate > endDate) {
                alert("开始时间不能晚于结束时间");
                return;
            }
            
            showLoading(true);
            
            $.ajax({
                type: 'POST',
                url: "web_service/Statistics.asmx/GetStatisticsData",
                data: {
                    ks: ks,
                    js: js
                },
                dataType: "xml",
                beforeSend: function () {
                    $.messager.progress({
                        title: '提示',
                        msg: '正在加载统计数据...',
                        text: ''
                    });
                },
                complete: function () {
                    $.messager.progress('close');
                    showLoading(false);
                },
                success: function (data) {
                    try {
                        var result = getJson(data);
                        if (result && result.success) {
                            statisticsData = result.data;
                            updateStatistics();
                        } else {
                            var errorMsg = result ? result.message : "未知错误";
                            alert("加载数据失败: " + errorMsg);
                        }
                    } catch (e) {
                        console.error('解析数据失败:', e);
                        alert("解析数据失败，请检查控制台");
                    }
                },
                error: function (err) {
                    console.error('请求错误:', err);
                    alert("请求错误：" + (err.statusText || "未知错误"));
                }
            });
        }
        
        function updateStatistics() {
            if (!statisticsData) return;
            
            // 更新统计卡片
            updateStatCards();
            
            // 更新图表
            updateCharts();
            
            // 更新数据表格
            updateDataTables();
        }
        
        function updateStatCards() {
            var rawData = statisticsData.rawData;
            var summary = statisticsData.summary;
            
            if (!rawData || !summary) {
                console.warn('汇总数据为空');
                return;
            }
            
            // 计算总计
            var totalReceivable = 0;
            var totalCope = 0;
            var totalProfit = 0;
            var totalNetReceivable = 0;
            var totalNetCope = 0;
            
            rawData.forEach(function(item) {
                totalReceivable += parseFloat(item.receivable || 0);
                totalCope += parseFloat(item.cope || 0);
                
                // 计算单条记录的利润
                var netReceivable = parseFloat(item.receivable || 0) - parseFloat(item.receipts || 0);
                var netCope = parseFloat(item.cope || 0) - parseFloat(item.payment || 0);
                var profit = netReceivable - netCope;
                
                totalNetReceivable += netReceivable;
                totalNetCope += netCope;
                totalProfit += profit;
            });
            
            // 计算利润率
            var profitRate = totalReceivable > 0 ? (totalProfit / totalReceivable * 100).toFixed(2) : 0;
            
            // 更新统计卡片显示
            var cardsHtml = '';
            
            // 总记录数卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card">';
            cardsHtml += '        <div class="stat-icon text-primary">';
            cardsHtml += '            <i class="fas fa-list-alt"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">' + (summary.totalRecords || 0) + '</div>';
            cardsHtml += '        <div class="stat-label">总记录数</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            // 总应收卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card warning">';
            cardsHtml += '        <div class="stat-icon text-warning">';
            cardsHtml += '            <i class="fas fa-money-bill-wave"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">¥' + totalReceivable.toFixed(2) + '</div>';
            cardsHtml += '        <div class="stat-label">总应收</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            // 总应付卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card success">';
            cardsHtml += '        <div class="stat-icon text-success">';
            cardsHtml += '            <i class="fas fa-hand-holding-usd"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">¥' + totalCope.toFixed(2) + '</div>';
            cardsHtml += '        <div class="stat-label">总应付</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            // 总利润卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card danger">';
            cardsHtml += '        <div class="stat-icon text-danger">';
            cardsHtml += '            <i class="fas fa-chart-line"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">¥' + totalProfit.toFixed(2) + '</div>';
            cardsHtml += '        <div class="stat-label">总利润</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            // 利润率卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card info">';
            cardsHtml += '        <div class="stat-icon text-info">';
            cardsHtml += '            <i class="fas fa-percentage"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">' + profitRate + '%</div>';
            cardsHtml += '        <div class="stat-label">利润率</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            // 净应收卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card">';
            cardsHtml += '        <div class="stat-icon text-primary">';
            cardsHtml += '            <i class="fas fa-arrow-circle-down"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">¥' + totalNetReceivable.toFixed(2) + '</div>';
            cardsHtml += '        <div class="stat-label">净应收</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            // 净应付卡片
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card warning">';
            cardsHtml += '        <div class="stat-icon text-warning">';
            cardsHtml += '            <i class="fas fa-arrow-circle-up"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">¥' + totalNetCope.toFixed(2) + '</div>';
            cardsHtml += '        <div class="stat-label">净应付</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
            
            $("#statCards").html(cardsHtml);
        }
        
        function updateCharts() {
            if (!statisticsData) return;
            
            // 渲染饼图（按科目）
            renderPieChart();
            
            // 渲染柱状图（月度对比）
            renderBarChart();
            
            // 渲染折线图（趋势分析）
            renderLineChart();
        }
        
        function renderPieChart() {
            if (!statisticsData.accountingData) return;
            
            var accountingData = statisticsData.accountingData;
            if (accountingData.length === 0) {
                clearChart('pie');
                return;
            }
            
            var labels = [];
            var data = [];
            var backgroundColors = [];
            
            // 生成颜色数组
            var colors = [
                'rgba(255, 99, 132, 0.7)',
                'rgba(54, 162, 235, 0.7)',
                'rgba(255, 206, 86, 0.7)',
                'rgba(75, 192, 192, 0.7)',
                'rgba(153, 102, 255, 0.7)',
                'rgba(255, 159, 64, 0.7)',
                'rgba(199, 199, 199, 0.7)',
                'rgba(83, 102, 255, 0.7)',
                'rgba(40, 159, 64, 0.7)',
                'rgba(210, 199, 199, 0.7)'
            ];
            
            // 只显示利润前10的科目
            var topAccounting = accountingData.slice(0, 10);
            
            topAccounting.forEach(function(item, index) {
                var profit = parseFloat(item.totalProfit || 0);
                if (Math.abs(profit) > 0.01) { // 过滤掉极小的值
                    labels.push(item.accounting || '未分类');
                    data.push(profit);
                    backgroundColors.push(colors[index % colors.length]);
                }
            });
            
            if (data.length === 0) {
                labels.push('无利润数据');
                data.push(1);
                backgroundColors.push(colors[0]);
            }
            
            // 销毁旧的图表实例
            if (charts.pie) {
                charts.pie.destroy();
            }
            
            // 创建新的饼图
            var ctx = document.getElementById('pieChartCanvas').getContext('2d');
            charts.pie = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: labels,
                    datasets: [{
                        data: data,
                        backgroundColor: backgroundColors,
                        borderColor: 'white',
                        borderWidth: 2
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'right',
                        },
                        title: {
                            display: true,
                            text: '科目利润分布'
                        },
                        tooltip: {
                            callbacks: {
                                label: function(context) {
                                    var label = context.label || '';
                                    var value = context.raw || 0;
                                    var total = context.dataset.data.reduce((a, b) => a + b, 0);
                                    var percentage = total > 0 ? ((value / total) * 100).toFixed(2) : 0;
                                    return label + ': ¥' + value.toFixed(2) + ' (' + percentage + '%)';
                                }
                            }
                        }
                    }
                }
            });
        }
        
        function renderBarChart() {
            if (!statisticsData.monthlyData) return;
            
            var monthlyData = statisticsData.monthlyData;
            if (monthlyData.length === 0) {
                clearChart('bar');
                return;
            }
            
            var labels = [];
            var receivableData = [];
            var copeData = [];
            var profitData = [];
            
            monthlyData.forEach(function(item) {
                labels.push(item.month);
                receivableData.push(parseFloat(item.netReceivable || 0));
                copeData.push(parseFloat(item.netCope || 0));
                profitData.push(parseFloat(item.monthlyProfit || 0));
            });
            
            // 销毁旧的图表实例
            if (charts.bar) {
                charts.bar.destroy();
            }
            
            // 创建新的柱状图
            var ctx = document.getElementById('barChartCanvas').getContext('2d');
            charts.bar = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [
                        {
                            label: '应收',
                            data: receivableData,
                            backgroundColor: 'rgba(54, 162, 235, 0.7)',
                            borderColor: 'rgba(54, 162, 235, 1)',
                            borderWidth: 1
                        },
                        {
                            label: '应付',
                            data: copeData,
                            backgroundColor: 'rgba(75, 192, 192, 0.7)',
                            borderColor: 'rgba(75, 192, 192, 1)',
                            borderWidth: 1
                        },
                        {
                            label: '利润',
                            data: profitData,
                            backgroundColor: 'rgba(255, 159, 64, 0.7)',
                            borderColor: 'rgba(255, 159, 64, 1)',
                            borderWidth: 1
                        }
                    ]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top',
                        },
                        title: {
                            display: true,
                            text: '月度利润对比'
                        }
                    },
                    scales: {
                        x: {
                            title: {
                                display: true,
                                text: '月份'
                            }
                        },
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: '金额 (元)'
                            }
                        }
                    }
                }
            });
        }
        
        function renderLineChart() {
            if (!statisticsData.monthlyData) return;
            
            var monthlyData = statisticsData.monthlyData;
            if (monthlyData.length === 0) {
                clearChart('line');
                return;
            }
            
            var labels = [];
            var profitTrend = [];
            var receivableTrend = [];
            var copeTrend = [];
            
            monthlyData.forEach(function(item) {
                labels.push(item.month);
                profitTrend.push(parseFloat(item.monthlyProfit || 0));
                receivableTrend.push(parseFloat(item.netReceivable || 0));
                copeTrend.push(parseFloat(item.netCope || 0));
            });
            
            // 销毁旧的图表实例
            if (charts.line) {
                charts.line.destroy();
            }
            
            // 创建新的折线图
            var ctx = document.getElementById('lineChartCanvas').getContext('2d');
            charts.line = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: labels,
                    datasets: [
                        {
                            label: '利润',
                            data: profitTrend,
                            borderColor: 'rgb(255, 99, 132)',
                            backgroundColor: 'rgba(255, 99, 132, 0.1)',
                            tension: 0.4,
                            fill: true
                        },
                        {
                            label: '应收',
                            data: receivableTrend,
                            borderColor: 'rgb(54, 162, 235)',
                            backgroundColor: 'rgba(54, 162, 235, 0.1)',
                            tension: 0.4,
                            fill: true
                        },
                        {
                            label: '应付',
                            data: copeTrend,
                            borderColor: 'rgb(75, 192, 192)',
                            backgroundColor: 'rgba(75, 192, 192, 0.1)',
                            tension: 0.4,
                            fill: true
                        }
                    ]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top',
                        },
                        title: {
                            display: true,
                            text: '利润趋势分析'
                        }
                    },
                    scales: {
                        x: {
                            title: {
                                display: true,
                                text: '月份'
                            }
                        },
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: '金额 (元)'
                            }
                        }
                    }
                }
            });
        }
        
        function clearChart(chartType) {
            if (charts[chartType]) {
                charts[chartType].destroy();
                charts[chartType] = null;
            }
        }
        
        function updateDataTables() {
            if (!statisticsData) return;
            
            // 更新月度表格
            if (statisticsData.monthlyData) {
                $('#monthlyTable').datagrid('loadData', statisticsData.monthlyData);
            }
            
            // 更新科目表格
            if (statisticsData.accountingData) {
                $('#accountingTable').datagrid('loadData', statisticsData.accountingData);
            }
        }
        
        // 图表切换视图（现在使用 Bootstrap 选项卡，无需此函数）
        
        // 导出数据到Excel（保留原有逻辑）
        function exportStatisticsData() {
            if (!statisticsData) {
                alert("请先查询数据");
                return;
            }
            
            var ks = $("#ks").val();
            var js = $("#js").val();
            var filename = "统计报表_" + ks + "_至_" + js;
            
            // 准备数据
            var exportData = [];
            
            // 1. 汇总数据
            exportData.push({
                sheetName: "数据汇总",
                data: [
                    ["项目", "数值"],
                    ["总记录数", statisticsData.summary.totalRecords],
                    ["开始时间", statisticsData.summary.startDate],
                    ["结束时间", statisticsData.summary.endDate],
                    ["公司", statisticsData.summary.company]
                ]
            });
            
            // 2. 月度数据
            var monthlySheet = [["月份", "应收总额", "实收总额", "应付总额", "实付总额", "净利润"]];
            if (statisticsData.monthlyData) {
                statisticsData.monthlyData.forEach(function(item) {
                    monthlySheet.push([
                        item.month,
                        item.totalReceivable.toFixed(2),
                        item.totalReceipts.toFixed(2),
                        item.totalCope.toFixed(2),
                        item.totalPayment.toFixed(2),
                        item.monthlyProfit.toFixed(2)
                    ]);
                });
            }
            exportData.push({
                sheetName: "月度统计",
                data: monthlySheet
            });
            
            // 3. 科目数据
            var accountingSheet = [["科目", "应收总额", "实收总额", "应付总额", "实付总额", "利润", "记录数"]];
            if (statisticsData.accountingData) {
                statisticsData.accountingData.forEach(function(item) {
                    accountingSheet.push([
                        item.accounting || "未分类",
                        item.totalReceivable.toFixed(2),
                        item.totalReceipts.toFixed(2),
                        item.totalCope.toFixed(2),
                        item.totalPayment.toFixed(2),
                        item.totalProfit.toFixed(2),
                        item.recordCount || 0
                    ]);
                });
            }
            exportData.push({
                sheetName: "科目分析",
                data: accountingSheet
            });
            
            // 调用导出函数
            exportToExcel(exportData, filename);
        }
        
        // 多Sheet Excel导出函数（保留原有逻辑）
        function exportToExcel(sheets, filename) {
            var excelFile = "";
            
            sheets.forEach(function(sheet, index) {
                excelFile += '<table border="1">';
                excelFile += '<caption><strong>' + sheet.sheetName + '</strong></caption>';
                
                sheet.data.forEach(function(row) {
                    excelFile += '<tr>';
                    row.forEach(function(cell) {
                        excelFile += '<td>' + (cell || '') + '</td>';
                    });
                    excelFile += '</tr>';
                });
                
                excelFile += '</table>';
                
                // 添加分页符（除了最后一个sheet）
                if (index < sheets.length - 1) {
                    excelFile += '<div style="page-break-after: always;"></div>';
                }
            });
            
            var fullExcel = '<html xmlns:o="urn:schemas-microsoft-com:office:office" ' +
                           'xmlns:x="urn:schemas-microsoft-com:office:excel" ' +
                           'xmlns="http://www.w3.org/TR/REC-html40">' +
                           '<head><meta charset="UTF-8"></head><body>' + 
                           excelFile + '</body></html>';
            
            var uri = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(fullExcel);
            var link = document.createElement("a");
            link.href = uri;
            link.download = filename + ".xls";
            link.style = "visibility:hidden";
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
        
        // 显示/隐藏加载动画
        function showLoading(show) {
            if (show) {
                $("#loadingOverlay").show();
            } else {
                $("#loadingOverlay").hide();
            }
        }
    </script>
</body>
</html>