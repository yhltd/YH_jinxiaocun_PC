<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="caigoutuihuotongji.aspx.cs" Inherits="Web.caigoutuihuotongji" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>采购退货统计分析</title>
    
    <!-- CSS 库 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.4/css/all.min.css" />
    
    <!-- JS 库 -->
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
    
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
            background-color: #009688;
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
        
        .stat-icon {
            font-size: 2rem;
            color: var(--primary-color);
            margin-bottom: 15px;
        }
        
        .chart-container {
            background: white;
            border-radius: var(--border-radius);
            padding: 25px;
            margin-bottom: 20px;
            box-shadow: var(--box-shadow);
        }
        
        .filter-card {
            background: white;
            border-radius: var(--border-radius);
            padding: 20px;
            box-shadow: var(--box-shadow);
            margin-bottom: 20px;
        }
        
        .date-input-group {
            margin-bottom: 15px;
        }
        
        .date-input-group label {
            font-weight: 600;
            margin-bottom: 5px;
            color: var(--dark-color);
        }
        
        .btn-primary {
            background-color: #009688;
            border: none;
            padding: 10px 25px;
            border-radius: 6px;
            font-weight: 600;
            transition: all 0.3s ease;
        }
        
        .btn-primary:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(30, 60, 114, 0.3);
        }
        
        .btn-outline-secondary {
            border-color: #dee2e6;
            color: #6c757d;
        }
        
        .chart-title {
            color: var(--dark-color);
            font-weight: 600;
            margin-bottom: 20px;
            padding-bottom: 10px;
            border-bottom: 2px solid #f0f0f0;
        }
        
        .data-table {
            background: white;
            border-radius: var(--border-radius);
            overflow: hidden;
            box-shadow: var(--box-shadow);
        }
        
        .data-table thead th {
            background-color: #f8f9fa;
            border-bottom: 2px solid #dee2e6;
            font-weight: 600;
            color: var(--dark-color);
            padding: 15px;
        }
        
        .data-table tbody tr:hover {
            background-color: #f8f9fa;
        }
        
        .tab-content {
            background: white;
            border-radius: 0 0 var(--border-radius) var(--border-radius);
            padding: 25px;
            box-shadow: var(--box-shadow);
        }
        
        .nav-tabs {
            border-bottom: 2px solid #dee2e6;
        }
        
        .nav-tabs .nav-link {
            border: none;
            padding: 12px 30px;
            font-weight: 600;
            color: #6c757d;
            border-radius: var(--border-radius) var(--border-radius) 0 0;
            margin-right: 5px;
        }
        
        .nav-tabs .nav-link.active {
            color: var(--primary-color);
            background-color: white;
            border-bottom: 3px solid var(--primary-color);
        }
        
        .export-buttons {
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #eee;
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
        
        @media (max-width: 768px) {
            body {
                padding-top: 60px;
            }
            
            .stat-value {
                font-size: 1.8rem;
            }
            
            .chart-container {
                padding: 15px;
            }
            
            .nav-tabs .nav-link {
                padding: 10px 15px;
                font-size: 0.9rem;
            }
        }
    </style>
</head>
<body>
    <!-- 加载动画 -->
    <div class="loading-overlay" id="loadingOverlay">
        <div class="spinner"></div>
    </div>
    
    <!-- 导航栏 -->
    <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
        <div class="container">
            <a class="navbar-brand" href="#">
                <i class="fas fa-chart-line mr-2"></i>
                采购退货统计分析系统
            </a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <%--<div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="caigoudan.aspx">
                            <i class="fas fa-arrow-left mr-1"></i>返回退货管理
                        </a>
                    </li>
                </ul>
            </div>--%>
        </div>
    </nav>

    <div class="container">
        <!-- 筛选条件卡片 -->
        <div class="filter-card">
            <h4 class="mb-4"><i class="fas fa-filter mr-2"></i>数据筛选</h4>
            <div class="row">
                <div class="col-md-3">
                    <div class="date-input-group">
                        <label for="startDate"><i class="far fa-calendar-alt mr-2"></i>开始日期</label>
                        <input type="text" id="startDate" class="form-control" placeholder="选择开始日期">
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="date-input-group">
                        <label for="endDate"><i class="far fa-calendar-alt mr-2"></i>结束日期</label>
                        <input type="text" id="endDate" class="form-control" placeholder="选择结束日期">
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="chartType"><i class="fas fa-chart-bar mr-2"></i>统计维度</label>
                        <select id="chartType" class="form-control">
                            <option value="daily">按日统计</option>
                            <option value="monthly">按月统计</option>
                            <option value="product">按商品统计</option>
                            <option value="category">按类别统计</option>
                            <option value="warehouse">按仓库统计</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="warehouse"><i class="fas fa-warehouse mr-2"></i>仓库筛选</label>
                        <select id="warehouse" class="form-control">
                            <option value="">所有仓库</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="product"><i class="fas fa-box mr-2"></i>商品筛选</label>
                        <select id="product" class="form-control">
                            <option value="">所有商品</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="minAmount"><i class="fas fa-dollar-sign mr-2"></i>最小金额</label>
                        <input type="number" id="minAmount" class="form-control" placeholder="最小金额" min="0">
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="maxAmount"><i class="fas fa-dollar-sign mr-2"></i>最大金额</label>
                        <input type="number" id="maxAmount" class="form-control" placeholder="最大金额" min="0">
                    </div>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-12 text-center">
                    <button id="filterButton" class="btn btn-primary btn-lg mr-3">
                        <i class="fas fa-search mr-2"></i>查询统计
                    </button>
                    <button id="resetButton" class="btn btn-outline-secondary btn-lg">
                        <i class="fas fa-redo mr-2"></i>重置条件
                    </button>
                </div>
            </div>
        </div>

        <!-- 统计数据卡片 -->
        <div class="row" id="statCards">
            <!-- 统计卡片将通过JS动态生成 -->
        </div>

        <!-- 图表选项卡 -->
        <ul class="nav nav-tabs" id="chartTabs" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="line-tab" data-toggle="tab" href="#lineChart">
                    <i class="fas fa-chart-line mr-2"></i>趋势分析
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="bar-tab" data-toggle="tab" href="#barChart">
                    <i class="fas fa-chart-bar mr-2"></i>排行对比
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="pie-tab" data-toggle="tab" href="#pieChart">
                    <i class="fas fa-chart-pie mr-2"></i>分布比例
                </a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="table-tab" data-toggle="tab" href="#dataTable">
                    <i class="fas fa-table mr-2"></i>详细数据
                </a>
            </li>
        </ul>

        <div class="tab-content" id="chartTabsContent">
            <!-- 折线图 -->
            <div class="tab-pane fade show active" id="lineChart" role="tabpanel">
                <h4 class="chart-title">退货趋势分析</h4>
                <div class="chart-container">
                    <canvas id="lineChartCanvas"></canvas>
                </div>
            </div>

            <!-- 柱状图 -->
            <div class="tab-pane fade" id="barChart" role="tabpanel">
                <h4 class="chart-title">退货排行对比</h4>
                <div class="chart-container">
                    <canvas id="barChartCanvas"></canvas>
                </div>
            </div>

            <!-- 饼状图 -->
            <div class="tab-pane fade" id="pieChart" role="tabpanel">
                <h4 class="chart-title">退货分布比例</h4>
                <div class="chart-container">
                    <canvas id="pieChartCanvas"></canvas>
                </div>
            </div>

            <!-- 数据表格 -->
            <div class="tab-pane fade" id="dataTable" role="tabpanel">
                <h4 class="chart-title">详细退货数据</h4>
                <div class="table-responsive">
                    <table class="table data-table">
                        <thead>
                            <tr>
                                <th>日期</th>
                                <th>退货单号</th>
                                <th>商品名称</th>
                                <th>商品类别</th>
                                <th>商品代码</th>
                                <th>数量</th>
                                <th>单价</th>
                                <th>金额</th>
                                <th>仓库</th>
                                <th>入库状态</th>
                            </tr>
                        </thead>
                        <tbody id="statisticsTableBody">
                            <!-- 数据将通过JS动态填充 -->
                        </tbody>
                    </table>
                </div>
                <div class="row mt-3">
                    <div class="col-md-6">
                        <div id="paginationInfo"></div>
                    </div>
                    <div class="col-md-6 text-right">
                        <nav>
                            <ul class="pagination justify-content-end" id="pagination">
                                <!-- 分页将通过JS动态生成 -->
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>

        <!-- 导出按钮 -->
        <div class="export-buttons text-center">
<%--            <button id="exportExcel" class="btn btn-success mr-2">
                <i class="fas fa-file-excel mr-2"></i>导出Excel
            </button>
            <button id="exportPDF" class="btn btn-danger mr-2">
                <i class="fas fa-file-pdf mr-2"></i>导出PDF
            </button>--%>
            <button id="printReport" class="btn btn-info">
                <i class="fas fa-print mr-2"></i>打印报表
            </button>
        </div>
    </div>

    <script>
        // 全局变量
        var charts = {
            line: null,
            bar: null,
            pie: null
        };
        var allReturnData = []; // 存储所有数据
        var filteredData = []; // 存储筛选后的数据
        var currentPage = 1;
        var pageSize = 10;
        var totalRecords = 0;

        $(document).ready(function() {
            // 初始化日期选择器
            flatpickr("#startDate", {
                dateFormat: "Y-m-d",
                defaultDate: new Date(new Date().getFullYear(), 0, 1), // 当年1月1日
                maxDate: "today"
            });
        
            flatpickr("#endDate", {
                dateFormat: "Y-m-d",
                defaultDate: new Date(), // 今天
                maxDate: "today"
            });

            // 绑定事件
            $("#filterButton").click(loadReturnData);
            $("#resetButton").click(resetFilters);
            $("#exportExcel").click(exportToExcel);
            $("#exportPDF").click(exportToPDF);
            $("#printReport").click(printReport);

            // 默认加载数据
            loadReturnData();

            // 分页点击事件
            $(document).on('click', '.page-link', function(e) {
                e.preventDefault();
                var page = $(this).data('page');
                if (page) {
                    currentPage = page;
                    updateDataTable();
                }
            });

            // 仓库筛选变化时更新商品选项
            $("#warehouse").change(function() {
                updateProductOptions();
            });

            // 筛选条件变化时重新筛选
            $("#warehouse, #product, #minAmount, #maxAmount, #chartType").change(function() {
                applyFrontendFilters();
                updateStatistics();
            });
        });

        // 加载退货数据
        function loadReturnData() {
            showLoading(true);
        
            var startDate = $("#startDate").val();
            var endDate = $("#endDate").val();
        
            $.ajax({
                url: 'caigoutuihuotongji.aspx/GetAllSalesReturns',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({
                    startDate: startDate,
                    endDate: endDate
                }),
                success: function(response) {
                    showLoading(false);
                    var data = JSON.parse(response.d);
                
                    if (data.success) {
                        allReturnData = data.data;
                        totalRecords = data.totalCount;
                    
                        // 更新筛选选项
                        updateWarehouseOptions();
                        updateProductOptions();
                    
                        // 应用筛选并更新显示
                        applyFrontendFilters();
                        updateStatistics();
                    } else {
                        alert("获取数据失败: " + data.message);
                    }
                },
                error: function(xhr, status, error) {
                    showLoading(false);
                    console.log("请求错误:", xhr, status, error);
                    alert("网络错误，请稍后重试");
                }
            });
        }

        // 更新仓库选项
        function updateWarehouseOptions() {
            var warehouseSelect = $("#warehouse");
            var currentWarehouse = warehouseSelect.val();
            warehouseSelect.empty();
            warehouseSelect.append('<option value="">所有仓库</option>');
        
            var warehouses = {};
            for (var i = 0; i < allReturnData.length; i++) {
                var warehouse = allReturnData[i].Warehouse;
                if (warehouse && warehouse !== "" && !warehouses[warehouse]) {
                    warehouses[warehouse] = true;
                    warehouseSelect.append('<option value="' + warehouse + '">' + warehouse + '</option>');
                }
            }
        
            // 恢复之前的选择
            if (currentWarehouse && warehouses[currentWarehouse]) {
                warehouseSelect.val(currentWarehouse);
            }
        }

        // 更新商品选项
        function updateProductOptions() {
            var productSelect = $("#product");
            var currentProduct = productSelect.val();
            var selectedWarehouse = $("#warehouse").val();
            productSelect.empty();
            productSelect.append('<option value="">所有商品</option>');
        
            var products = {};
            for (var i = 0; i < allReturnData.length; i++) {
                var item = allReturnData[i];
                // 如果选择了仓库，只显示该仓库的商品
                if (selectedWarehouse && item.Warehouse !== selectedWarehouse) {
                    continue;
                }
            
                var productName = item.ProductName;
                if (productName && productName !== "" && !products[productName]) {
                    products[productName] = true;
                    productSelect.append('<option value="' + productName + '">' + productName + '</option>');
                }
            }
        
            // 恢复之前的选择
            if (currentProduct && products[currentProduct]) {
                productSelect.val(currentProduct);
            }
        }

        // 应用前端筛选
        function applyFrontendFilters() {
            filteredData = [];
        
            // 复制数据
            for (var i = 0; i < allReturnData.length; i++) {
                filteredData.push(allReturnData[i]);
            }
        
            // 应用仓库筛选
            var warehouse = $("#warehouse").val();
            if (warehouse) {
                var tempData = [];
                for (var i = 0; i < filteredData.length; i++) {
                    if (filteredData[i].Warehouse === warehouse) {
                        tempData.push(filteredData[i]);
                    }
                }
                filteredData = tempData;
            }
        
            // 应用商品筛选
            var product = $("#product").val();
            if (product) {
                var tempData = [];
                for (var i = 0; i < filteredData.length; i++) {
                    if (filteredData[i].ProductName === product) {
                        tempData.push(filteredData[i]);
                    }
                }
                filteredData = tempData;
            }
        
            // 应用金额筛选
            var minAmount = parseFloat($("#minAmount").val()) || 0;
            var maxAmount = parseFloat($("#maxAmount").val()) || Infinity;
        
            if (minAmount > 0 || maxAmount < Infinity) {
                var tempData = [];
                for (var i = 0; i < filteredData.length; i++) {
                    var amount = parseFloat(filteredData[i].Amount) || 0;
                    if (amount >= minAmount && amount <= maxAmount) {
                        tempData.push(filteredData[i]);
                    }
                }
                filteredData = tempData;
            }
        }

        // 更新统计信息
        function updateStatistics() {
            if (!filteredData || filteredData.length === 0) {
                clearStatistics();
                return;
            }
        
            // 计算统计数据
            var totalQuantity = 0;
            var totalAmount = 0;
            var productMap = {};
            var categoryMap = {};
            var warehouseMap = {};
            var dateMap = {};
        
            for (var i = 0; i < filteredData.length; i++) {
                var item = filteredData[i];
                var quantity = parseFloat(item.Quantity) || 0;
                var amount = parseFloat(item.Amount) || 0;
            
                totalQuantity += quantity;
                totalAmount += amount;
            
                // 按商品统计
                var productName = item.ProductName || "未知商品";
                if (productMap[productName]) {
                    productMap[productName] += quantity;
                } else {
                    productMap[productName] = quantity;
                }
            
                // 按类别统计
                var category = item.Category || "未知类别";
                if (categoryMap[category]) {
                    categoryMap[category] += quantity;
                } else {
                    categoryMap[category] = quantity;
                }
            
                // 按仓库统计
                var warehouse = item.Warehouse || "未知仓库";
                if (warehouseMap[warehouse]) {
                    warehouseMap[warehouse] += quantity;
                } else {
                    warehouseMap[warehouse] = quantity;
                }
            
                // 按日期统计
                var date = item.ReturnDate || '未知日期';
                if (dateMap[date]) {
                    dateMap[date] += quantity;
                } else {
                    dateMap[date] = quantity;
                }
            }
        
            // 更新统计卡片
            var productCount = Object.keys(productMap).length;
            updateStatCards(totalQuantity, totalAmount, productCount);
        
            // 根据选择的图表类型更新图表
            var chartType = $("#chartType").val();
            updateCharts(chartType, dateMap, productMap, categoryMap, warehouseMap);
        
            // 更新数据表格
            updateDataTable();
        }

        // 更新统计卡片
        function updateStatCards(totalQuantity, totalAmount, productCount) {
            var avgReturn = filteredData.length > 0 ? (totalQuantity / filteredData.length).toFixed(2) : "0.00";
    
            // 格式化数字
            var formattedTotalQuantity = formatNumber(totalQuantity);
            var formattedTotalAmount = formatNumber(totalAmount, 2);
    
            var cardsHtml = '';
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card">';
            cardsHtml += '        <div class="stat-icon text-primary">';
            cardsHtml += '            <i class="fas fa-box-open"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">' + formattedTotalQuantity + '</div>';
            cardsHtml += '        <div class="stat-label">总退货数量</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
    
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card warning">';
            cardsHtml += '        <div class="stat-icon text-warning">';
            cardsHtml += '            <i class="fas fa-money-bill-wave"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">¥' + formattedTotalAmount + '</div>';
            cardsHtml += '        <div class="stat-label">总退货金额</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
    
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card success">';
            cardsHtml += '        <div class="stat-icon text-success">';
            cardsHtml += '            <i class="fas fa-calculator"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">' + avgReturn + '</div>';
            cardsHtml += '        <div class="stat-label">平均退货量</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
    
            cardsHtml += '<div class="col-md-3">';
            cardsHtml += '    <div class="stat-card danger">';
            cardsHtml += '        <div class="stat-icon text-danger">';
            cardsHtml += '            <i class="fas fa-barcode"></i>';
            cardsHtml += '        </div>';
            cardsHtml += '        <div class="stat-value">' + productCount + '</div>';
            cardsHtml += '        <div class="stat-label">涉及商品数</div>';
            cardsHtml += '    </div>';
            cardsHtml += '</div>';
    
            $("#statCards").html(cardsHtml);
        }


        // 格式化数字
        function formatNumber(num, decimals) {
            if (decimals === undefined) {
                decimals = 0;
            }
        
            if (isNaN(num)) {
                return "0";
            }
        
            return parseFloat(num).toFixed(decimals).replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }

        // 清空统计数据
        function clearStatistics() {
            var clearHtml = '';
            clearHtml += '<div class="col-md-12">';
            clearHtml += '    <div class="alert alert-warning text-center" role="alert">';
            clearHtml += '        <i class="fas fa-info-circle mr-2"></i>暂无数据';
            clearHtml += '    </div>';
            clearHtml += '</div>';
    
            $("#statCards").html(clearHtml);
    
            // 清空图表
            if (charts.line) charts.line.destroy();
            if (charts.bar) charts.bar.destroy();
            if (charts.pie) charts.pie.destroy();
    
            // 清空表格
            $("#statisticsTableBody").html('<tr><td colspan="10" class="text-center">暂无数据</td></tr>');
            $("#paginationInfo").html("");
            $("#pagination").empty();
        }

        // 更新图表
        function updateCharts(chartType, dateMap, productMap, categoryMap, warehouseMap) {
            var chartData = getChartDataByType(chartType, dateMap, productMap, categoryMap, warehouseMap);
        
            // 更新折线图
            if (charts.line) charts.line.destroy();
            charts.line = createLineChart(chartData.lineData);
        
            // 更新柱状图
            if (charts.bar) charts.bar.destroy();
            charts.bar = createBarChart(chartData.barData);
        
            // 更新饼状图
            if (charts.pie) charts.pie.destroy();
            charts.pie = createPieChart(chartData.pieData);
        }

        // 根据图表类型获取数据
        function getChartDataByType(chartType, dateMap, productMap, categoryMap, warehouseMap) {
            var result = {
                lineData: { labels: [], quantities: [] },
                barData: { labels: [], quantities: [] },
                pieData: { labels: [], quantities: [] }
            };
        
            switch(chartType) {
                case 'daily':
                    // 折线图：按日期趋势
                    var dates = Object.keys(dateMap);
                    dates.sort();
                    var limitedDates = dates.slice(-15); // 只显示最近15天
                    result.lineData.labels = limitedDates;
                    for (var i = 0; i < limitedDates.length; i++) {
                        result.lineData.quantities.push(dateMap[limitedDates[i]] || 0);
                    }
                
                    // 柱状图：商品TOP10
                    var productEntries = [];
                    for (var product in productMap) {
                        if (productMap.hasOwnProperty(product)) {
                            productEntries.push([product, productMap[product]]);
                        }
                    }
                
                    productEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topProducts = productEntries.slice(0, 10);
                    for (var i = 0; i < topProducts.length; i++) {
                        result.barData.labels.push(topProducts[i][0] || "未知商品");
                        result.barData.quantities.push(topProducts[i][1]);
                    }
                
                    // 饼状图：类别分布
                    var categoryEntries = [];
                    for (var category in categoryMap) {
                        if (categoryMap.hasOwnProperty(category)) {
                            categoryEntries.push([category, categoryMap[category]]);
                        }
                    }
                
                    categoryEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topCategories = categoryEntries.slice(0, 8);
                    for (var i = 0; i < topCategories.length; i++) {
                        result.pieData.labels.push(topCategories[i][0] || "未知类别");
                        result.pieData.quantities.push(topCategories[i][1]);
                    }
                    break;
                
                case 'monthly':
                    // 按月份分组数据
                    var monthMap = {};
                    for (var date in dateMap) {
                        if (dateMap.hasOwnProperty(date) && date.length >= 7) {
                            var month = date.substring(0, 7); // 获取yyyy-MM
                            if (monthMap[month]) {
                                monthMap[month] += dateMap[date];
                            } else {
                                monthMap[month] = dateMap[date];
                            }
                        }
                    }
                
                    // 折线图：按月趋势
                    var months = Object.keys(monthMap);
                    months.sort();
                    result.lineData.labels = months;
                    for (var i = 0; i < months.length; i++) {
                        result.lineData.quantities.push(monthMap[months[i]] || 0);
                    }
                
                    // 柱状图：商品TOP10（同daily）
                    var productEntries = [];
                    for (var product in productMap) {
                        if (productMap.hasOwnProperty(product)) {
                            productEntries.push([product, productMap[product]]);
                        }
                    }
                
                    productEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topProducts = productEntries.slice(0, 10);
                    for (var i = 0; i < topProducts.length; i++) {
                        result.barData.labels.push(topProducts[i][0] || "未知商品");
                        result.barData.quantities.push(topProducts[i][1]);
                    }
                
                    // 饼状图：仓库分布
                    var warehouseEntries = [];
                    for (var warehouse in warehouseMap) {
                        if (warehouseMap.hasOwnProperty(warehouse)) {
                            warehouseEntries.push([warehouse, warehouseMap[warehouse]]);
                        }
                    }
                
                    warehouseEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topWarehouses = warehouseEntries.slice(0, 8);
                    for (var i = 0; i < topWarehouses.length; i++) {
                        result.pieData.labels.push(topWarehouses[i][0] || "未知仓库");
                        result.pieData.quantities.push(topWarehouses[i][1]);
                    }
                    break;
                
                case 'product':
                    // 折线图：商品趋势（按日期，显示前5个商品）
                    var top5Products = getTopItems(productMap, 5);
                    var productTrendData = {};
                
                    // 为每个商品创建趋势数据
                    for (var i = 0; i < top5Products.length; i++) {
                        var product = top5Products[i][0];
                        productTrendData[product] = {};
                    }
                
                    // 这里简化处理，实际应用中需要更复杂的逻辑来按商品和日期分组
                    var dates = Object.keys(dateMap);
                    dates.sort();
                    result.lineData.labels = dates.slice(-15);
                    // 简化：只显示总趋势
                    for (var i = 0; i < result.lineData.labels.length; i++) {
                        result.lineData.quantities.push(dateMap[result.lineData.labels[i]] || 0);
                    }
                
                    // 柱状图：商品排行
                    var productEntries = [];
                    for (var product in productMap) {
                        if (productMap.hasOwnProperty(product)) {
                            productEntries.push([product, productMap[product]]);
                        }
                    }
                
                    productEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topProducts = productEntries.slice(0, 15);
                    for (var i = 0; i < topProducts.length; i++) {
                        result.barData.labels.push(topProducts[i][0] || "未知商品");
                        result.barData.quantities.push(topProducts[i][1]);
                    }
                
                    // 饼状图：仓库分布
                    var warehouseEntries = [];
                    for (var warehouse in warehouseMap) {
                        if (warehouseMap.hasOwnProperty(warehouse)) {
                            warehouseEntries.push([warehouse, warehouseMap[warehouse]]);
                        }
                    }
                
                    warehouseEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topWarehouses = warehouseEntries.slice(0, 8);
                    for (var i = 0; i < topWarehouses.length; i++) {
                        result.pieData.labels.push(topWarehouses[i][0] || "未知仓库");
                        result.pieData.quantities.push(topWarehouses[i][1]);
                    }
                    break;
                
                case 'category':
                    // 折线图：类别趋势（简化，同daily）
                    var dates = Object.keys(dateMap);
                    dates.sort();
                    result.lineData.labels = dates.slice(-15);
                    for (var i = 0; i < result.lineData.labels.length; i++) {
                        result.lineData.quantities.push(dateMap[result.lineData.labels[i]] || 0);
                    }
                
                    // 柱状图：类别排行
                    var categoryEntries = [];
                    for (var category in categoryMap) {
                        if (categoryMap.hasOwnProperty(category)) {
                            categoryEntries.push([category, categoryMap[category]]);
                        }
                    }
                
                    categoryEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topCategories = categoryEntries.slice(0, 10);
                    for (var i = 0; i < topCategories.length; i++) {
                        result.barData.labels.push(topCategories[i][0] || "未知类别");
                        result.barData.quantities.push(topCategories[i][1]);
                    }
                
                    // 饼状图：类别分布
                    var categoryEntries2 = [];
                    for (var category in categoryMap) {
                        if (categoryMap.hasOwnProperty(category)) {
                            categoryEntries2.push([category, categoryMap[category]]);
                        }
                    }
                
                    categoryEntries2.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topCategories2 = categoryEntries2.slice(0, 8);
                    for (var i = 0; i < topCategories2.length; i++) {
                        result.pieData.labels.push(topCategories2[i][0] || "未知类别");
                        result.pieData.quantities.push(topCategories2[i][1]);
                    }
                    break;
                
                case 'warehouse':
                    // 折线图：仓库趋势（简化，同daily）
                    var dates = Object.keys(dateMap);
                    dates.sort();
                    result.lineData.labels = dates.slice(-15);
                    for (var i = 0; i < result.lineData.labels.length; i++) {
                        result.lineData.quantities.push(dateMap[result.lineData.labels[i]] || 0);
                    }
                
                    // 柱状图：仓库排行
                    var warehouseEntries = [];
                    for (var warehouse in warehouseMap) {
                        if (warehouseMap.hasOwnProperty(warehouse)) {
                            warehouseEntries.push([warehouse, warehouseMap[warehouse]]);
                        }
                    }
                
                    warehouseEntries.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topWarehouses = warehouseEntries.slice(0, 10);
                    for (var i = 0; i < topWarehouses.length; i++) {
                        result.barData.labels.push(topWarehouses[i][0] || "未知仓库");
                        result.barData.quantities.push(topWarehouses[i][1]);
                    }
                
                    // 饼状图：仓库分布
                    var warehouseEntries2 = [];
                    for (var warehouse in warehouseMap) {
                        if (warehouseMap.hasOwnProperty(warehouse)) {
                            warehouseEntries2.push([warehouse, warehouseMap[warehouse]]);
                        }
                    }
                
                    warehouseEntries2.sort(function(a, b) {
                        return b[1] - a[1];
                    });
                
                    var topWarehouses2 = warehouseEntries2.slice(0, 8);
                    for (var i = 0; i < topWarehouses2.length; i++) {
                        result.pieData.labels.push(topWarehouses2[i][0] || "未知仓库");
                        result.pieData.quantities.push(topWarehouses2[i][1]);
                    }
                    break;
                
                default:
                    // 默认使用daily模式
                    return getChartDataByType('daily', dateMap, productMap, categoryMap, warehouseMap);
            }
        
            return result;
        }

        // 获取前N个项目
        function getTopItems(itemMap, count) {
            var entries = [];
            for (var key in itemMap) {
                if (itemMap.hasOwnProperty(key)) {
                    entries.push([key, itemMap[key]]);
                }
            }
        
            entries.sort(function(a, b) {
                return b[1] - a[1];
            });
        
            return entries.slice(0, count);
        }

        // 创建折线图
        function createLineChart(chartData) {
            var ctx = document.getElementById('lineChartCanvas').getContext('2d');
            return new Chart(ctx, {
                type: 'line',
                data: {
                    labels: chartData.labels,
                    datasets: [{
                        label: '退货数量',
                        data: chartData.quantities,
                        borderColor: 'rgb(54, 162, 235)',
                        backgroundColor: 'rgba(54, 162, 235, 0.1)',
                        tension: 0.4,
                        fill: true
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top',
                        },
                        title: {
                            display: true,
                            text: '退货趋势分析'
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: '数量'
                            }
                        },
                        x: {
                            title: {
                                display: true,
                                text: '时间'
                            }
                        }
                    }
                }
            });
        }

        // 创建柱状图
        function createBarChart(chartData) {
            var ctx = document.getElementById('barChartCanvas').getContext('2d');
            var colors = [
                'rgba(255, 99, 132, 0.6)',
                'rgba(54, 162, 235, 0.6)',
                'rgba(255, 206, 86, 0.6)',
                'rgba(75, 192, 192, 0.6)',
                'rgba(153, 102, 255, 0.6)',
                'rgba(255, 159, 64, 0.6)',
                'rgba(199, 199, 199, 0.6)',
                'rgba(83, 102, 255, 0.6)',
                'rgba(40, 159, 64, 0.6)',
                'rgba(210, 199, 199, 0.6)',
                'rgba(255, 99, 132, 0.4)',
                'rgba(54, 162, 235, 0.4)',
                'rgba(255, 206, 86, 0.4)',
                'rgba(75, 192, 192, 0.4)',
                'rgba(153, 102, 255, 0.4)'
            ];
        
            // 为每个柱状图项分配颜色
            var backgroundColors = [];
            for (var i = 0; i < chartData.labels.length; i++) {
                backgroundColors.push(colors[i % colors.length]);
            }
        
            return new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: chartData.labels,
                    datasets: [{
                        label: '退货数量',
                        data: chartData.quantities,
                        backgroundColor: backgroundColors,
                        borderColor: backgroundColors.map(color => color.replace('0.6', '1').replace('0.4', '1')),
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top',
                        },
                        title: {
                            display: true,
                            text: '退货排行'
                        }
                    },
                    scales: {
                        y: {
                            beginAtZero: true,
                            title: {
                                display: true,
                                text: '数量'
                            }
                        },
                        x: {
                            ticks: {
                                maxRotation: 45,
                                minRotation: 45
                            }
                        }
                    }
                }
            });
        }

        // 创建饼状图
        function createPieChart(chartData) {
            var ctx = document.getElementById('pieChartCanvas').getContext('2d');
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
        
            // 为每个饼图项分配颜色
            var backgroundColors = [];
            for (var i = 0; i < chartData.labels.length; i++) {
                backgroundColors.push(colors[i % colors.length]);
            }
        
            return new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: chartData.labels,
                    datasets: [{
                        data: chartData.quantities,
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
                            text: '退货分布比例'
                        }
                    }
                }
            });
        }

        // 更新数据表格
        function updateDataTable() {
            var tbody = $("#statisticsTableBody");
            tbody.empty();
    
            if (!filteredData || filteredData.length === 0) {
                tbody.html('<tr><td colspan="10" class="text-center">暂无数据</td></tr>');
                updatePagination(0);
                return;
            }
    
            totalRecords = filteredData.length;
            var totalPages = Math.ceil(totalRecords / pageSize);
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.min(startIndex + pageSize, totalRecords);
    
            // 显示当前页的数据
            for (var i = startIndex; i < endIndex; i++) {
                var item = filteredData[i];
                var statusClass = item.Status === '已入库' ? 'badge-success' : 
                                  item.Status === '未入库' ? 'badge-warning' : 'badge-secondary';
        
                var row = '<tr>';
                row += '<td>' + (item.ReturnDate || '') + '</td>';
                row += '<td>' + (item.OrderId || '') + '</td>';
                row += '<td>' + (item.ProductName || '') + '</td>';
                row += '<td>' + (item.Category || '') + '</td>';
                row += '<td>' + (item.ProductCode || '') + '</td>';
                row += '<td>' + formatNumber(item.Quantity, 2) + '</td>';
                row += '<td>¥' + formatNumber(item.Price, 2) + '</td>';
                row += '<td>¥' + formatNumber(item.Amount, 2) + '</td>';
                row += '<td>' + (item.Warehouse || '') + '</td>';
                row += '<td><span class="badge ' + statusClass + '">' + (item.Status || '') + '</span></td>';
                row += '</tr>';
                tbody.append(row);
            }
    
            updatePagination(totalRecords);
        }

        // 更新分页
        function updatePagination(total) {
            totalRecords = total;
            var totalPages = Math.ceil(total / pageSize);
        
            var pagination = $("#pagination");
            pagination.empty();
        
            if (totalPages <= 1) {
                $("#paginationInfo").html(`显示 1-${total} 条，共 ${total} 条记录`);
                return;
            }
        
            var startPage = Math.max(1, currentPage - 2);
            var endPage = Math.min(totalPages, currentPage + 2);
        
            // 上一页
            if (currentPage > 1) {
                pagination.append('<li class="page-item"><a class="page-link" href="#" data-page="' + (currentPage - 1) + '">上一页</a></li>');
            }
        
            // 第一页
            if (startPage > 1) {
                pagination.append('<li class="page-item"><a class="page-link" href="#" data-page="1">1</a></li>');
                if (startPage > 2) {
                    pagination.append('<li class="page-item disabled"><span class="page-link">...</span></li>');
                }
            }
        
            // 页码
            for (var i = startPage; i <= endPage; i++) {
                var active = i === currentPage ? 'active' : '';
                pagination.append('<li class="page-item ' + active + '"><a class="page-link" href="#" data-page="' + i + '">' + i + '</a></li>');
            }
        
            // 最后一页
            if (endPage < totalPages) {
                if (endPage < totalPages - 1) {
                    pagination.append('<li class="page-item disabled"><span class="page-link">...</span></li>');
                }
                pagination.append('<li class="page-item"><a class="page-link" href="#" data-page="' + totalPages + '">' + totalPages + '</a></li>');
            }
        
            // 下一页
            if (currentPage < totalPages) {
                pagination.append('<li class="page-item"><a class="page-link" href="#" data-page="' + (currentPage + 1) + '">下一页</a></li>');
            }
        
            // 分页信息
            var startRecord = (currentPage - 1) * pageSize + 1;
            var endRecord = Math.min(currentPage * pageSize, total);
            $("#paginationInfo").html(`显示 ${startRecord}-${endRecord} 条，共 ${total} 条记录`);
        }

        // 重置筛选条件
        function resetFilters() {
            $("#startDate").val('');
            $("#endDate").val('');
            $("#chartType").val('daily');
            $("#warehouse").val('');
            $("#product").val('');
            $("#minAmount").val('');
            $("#maxAmount").val('');
            currentPage = 1;
        
            loadReturnData();
        }

        // 导出Excel
        function exportToExcel() {
            var startDate = $("#startDate").val();
            var endDate = $("#endDate").val();
        
            var url = 'caigoutuihuotongji.aspx/ExportToExcel?startDate=' + encodeURIComponent(startDate || '') +
                     '&endDate=' + encodeURIComponent(endDate || '');
        
            window.open(url, '_blank');
        }

        // 导出PDF
        function exportToPDF() {
            alert("PDF导出功能需要后端支持，请联系系统管理员配置");
        }

        // 打印报表
        function printReport() {
            // 创建一个打印专用的临时窗口
            var printWindow = window.open('', '_blank', 'width=800,height=600');
            printWindow.document.open();
    
            // 获取当前页面的内容（使用字符串拼接）
            var content = '';
            content += '<html>';
            content += '<head>';
            content += '    <title>采购退货统计报表</title>';
            content += '    <style>';
            content += '        body { font-family: Arial, sans-serif; margin: 20px; }';
            content += '        h1 { text-align: center; color: #333; }';
            content += '        .print-info { margin-bottom: 20px; }';
            content += '        .stat-cards { display: flex; flex-wrap: wrap; margin-bottom: 20px; }';
            content += '        .stat-card { flex: 1; min-width: 200px; background: #f5f5f5; padding: 15px; margin: 5px; border-radius: 5px; }';
            content += '        .stat-value { font-size: 24px; font-weight: bold; color: #3498db; }';
            content += '        .stat-label { font-size: 14px; color: #666; }';
            content += '        table { width: 100%; border-collapse: collapse; margin-top: 20px; }';
            content += '        th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }';
            content += '        th { background-color: #f2f2f2; }';
            content += '        .print-time { text-align: right; font-size: 12px; color: #666; margin-top: 30px; }';
            content += '    </style>';
            content += '</head>';
            content += '<body>';
            content += '    <h1>采购退货统计报表</h1>';
            content += '    <div class="print-info">';
            content += '        <p>打印时间: ' + new Date().toLocaleString() + '</p>';
    
            // 添加筛选条件
            if ($("#startDate").val() || $("#endDate").val()) {
                content += '        <p>筛选条件: ';
                if ($("#startDate").val()) {
                    content += '开始日期: ' + $("#startDate").val() + ' ';
                }
                if ($("#endDate").val()) {
                    content += '结束日期: ' + $("#endDate").val();
                }
                content += '</p>';
            }
    
            content += '    </div>';
            content += '    <div id="printStats"></div>';
            content += '    <h3>详细数据</h3>';
            content += '    <div id="printTable"></div>';
            content += '    <div class="print-time">报表生成时间: ' + new Date().toLocaleString() + '</div>';
            content += '</body>';
            content += '</html>';
    
            printWindow.document.write(content);
            printWindow.document.close();
    
            // 复制统计卡片到打印窗口
            setTimeout(function() {
                var printStats = printWindow.document.getElementById('printStats');
                var statCardsHtml = $("#statCards").html();
                printStats.innerHTML = statCardsHtml.replace(/col-md-3/g, 'stat-card');
        
                // 复制表格数据到打印窗口（只显示前50条数据）
                var printTable = printWindow.document.getElementById('printTable');
                var tableData = '';
        
                if (filteredData && filteredData.length > 0) {
                    var displayData = filteredData.slice(0, 50); // 限制打印50条
            
                    tableData += '<table>';
                    tableData += '<tr><th>日期</th><th>退货单号</th><th>商品名称</th><th>数量</th><th>金额</th><th>仓库</th><th>状态</th></tr>';
            
                    for (var i = 0; i < displayData.length; i++) {
                        var item = displayData[i];
                        tableData += '<tr>';
                        tableData += '<td>' + (item.ReturnDate || '') + '</td>';
                        tableData += '<td>' + (item.OrderId || '') + '</td>';
                        tableData += '<td>' + (item.ProductName || '') + '</td>';
                        tableData += '<td>' + formatNumber(item.Quantity, 2) + '</td>';
                        tableData += '<td>¥' + formatNumber(item.Amount, 2) + '</td>';
                        tableData += '<td>' + (item.Warehouse || '') + '</td>';
                        tableData += '<td>' + (item.Status || '') + '</td>';
                        tableData += '</tr>';
                    }
            
                    tableData += '</table>';
            
                    if (filteredData.length > 50) {
                        tableData += '<p style="color: #666; font-size: 12px;">注：仅显示前50条数据，共' + filteredData.length + '条记录</p>';
                    }
                } else {
                    tableData = '<p>暂无数据</p>';
                }
        
                printTable.innerHTML = tableData;
        
                // 打印
                setTimeout(function() {
                    printWindow.print();
                    printWindow.close();
                }, 500);
            }, 100);
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

