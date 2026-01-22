<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tongjitu.aspx.cs" Inherits="Web.Personnel.tongjitu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>统计图表分析</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
        }
        
        body {
            background: linear-gradient(135deg, #f5f7fa 0%, #e4e8f0 100%);
            padding: 10px;
            min-height: 100vh;
        }
        
        .ti {
            background: linear-gradient(135deg, rgba(22, 10, 141, 0.95) 0%, rgba(59, 77, 203, 0.95) 50%, rgba(90, 95, 221, 0.95) 100%);
            color: white;
            padding: 6px 30px;
            border-radius: 12px 12px 0 0;
            display: flex;
            justify-content: space-between;
            align-items: center;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            position: relative;
            overflow: hidden;
        }
        
        .ti h1 {
            margin: 0;
            font-size: 24px;
            font-weight: 700;
            text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
            z-index: 2;
        }
        
        .header-top {
            background: white;
            padding: 20px 30px;
            border-radius: 0 0 12px 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            align-items: center;
            margin-bottom: 20px;
        }
        
        .top_bt {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            font-size: 14px;
        }
        
        .top_bt:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 主容器 */
        .main-container {
            display: flex;
            gap: 20px;
            min-height: 600px;
        }
        
        /* 左侧配置面板 */
        .config-panel {
            width: 300px;
            background: white;
            border-radius: 12px;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
        }
        
        .config-title {
            font-size: 18px;
            font-weight: 600;
            color: #333;
            margin-bottom: 20px;
            padding-bottom: 10px;
            border-bottom: 2px solid #07f2e7;
        }
        
        /* 图表显示区域 */
        .chart-panel {
            flex: 1;
            background: white;
            border-radius: 12px;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
        }
        
        .chart-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }
        
        .chart-title {
            font-size: 20px;
            font-weight: 600;
            color: #333;
        }
        
        .chart-actions {
            display: flex;
            gap: 10px;
        }
        
        .chart-container {
            height: 500px;
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            padding: 15px;
            background: #f9f9f9;
            margin-bottom: 20px;
        }
        
        .chart-info {
            background: #f0f8ff;
            border-radius: 8px;
            padding: 15px;
            margin-top: 20px;
        }
        
        .info-title {
            font-weight: 600;
            color: #333;
            margin-bottom: 10px;
        }
        
        .info-content {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 10px;
        }
        
        .info-item {
            display: flex;
            justify-content: space-between;
            padding: 5px 0;
            border-bottom: 1px solid #e0e0e0;
        }
        
        .info-label {
            color: #666;
        }
        
        .info-value {
            font-weight: 600;
            color: #333;
        }
        
        /* 配置表单 */
        .config-form {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }
        
        .form-group {
            display: flex;
            flex-direction: column;
            gap: 5px;
        }
        
        .form-label {
            font-weight: 600;
            color: #333;
            font-size: 14px;
        }
        
        .form-select, .form-input {
            padding: 8px 12px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
            width: 100%;
        }
        
        .field-selection {
            max-height: 300px;
            overflow-y: auto;
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 10px;
            background: #f9f9f9;
        }
        
        .field-item {
            display: flex;
            align-items: center;
            margin-bottom: 8px;
            padding: 5px;
            border-radius: 4px;
            cursor: pointer;
            transition: all 0.2s;
        }
        
        .field-item:hover {
            background: #e3f2fd;
        }
        
        .field-item.selected {
            background: #bbdefb;
            border: 1px solid #2196f3;
        }
        
        .field-checkbox {
            margin-right: 8px;
        }
        
        .field-name {
            flex: 1;
        }
        
        /* 图表类型选择 */
        .chart-type-selector {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 10px;
            margin: 10px 0;
        }
        
        .chart-type-btn {
            padding: 10px;
            border: 2px solid #ddd;
            border-radius: 6px;
            background: white;
            cursor: pointer;
            text-align: center;
            font-size: 12px;
            transition: all 0.3s;
        }
        
        .chart-type-btn:hover {
            border-color: #07f2e7;
        }
        
        .chart-type-btn.active {
            border-color: #071ec1;
            background: linear-gradient(to bottom, #e3f2ff, #bbdefb);
        }
        
        /* 统计数据表格 */
        .data-table-container {
            margin-top: 20px;
            overflow-x: auto;
            border: 1px solid #ddd;
            border-radius: 8px;
        }
        
        .data-table {
            width: 100%;
            border-collapse: collapse;
        }
        
        .data-table th, .data-table td {
            padding: 12px 15px;
            border: 1px solid #e0e0e0;
            text-align: center;
        }
        
        .data-table th {
            background: linear-gradient(to bottom, #f5f5f5, #e0e0e0);
            font-weight: 600;
            color: #333;
        }
        
        .data-table tr:nth-child(even) {
            background: #f9f9f9;
        }
        
        .data-table tr:hover {
            background: #f0f8ff;
        }
        
        /* 响应式设计 */
        @media (max-width: 768px) {
            .main-container {
                flex-direction: column;
            }
            
            .config-panel {
                width: 100%;
            }
            
            .chart-container {
                height: 400px;
            }
            
            .chart-type-selector {
                grid-template-columns: repeat(4, 1fr);
            }
        }
    </style>
    <!-- 使用Chart.js -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js@3.9.1/dist/chart.min.js"></script>
    <script type="text/javascript">
        // 全局变量
        var chartInstance = null;
        var dynamicFields = [];
        var chartData = [];
        var selectedChartType = 'bar';
        var selectedFields = [];
        var selectedGroupField = '';
        
        // 页面加载
        document.addEventListener('DOMContentLoaded', function() {
            loadData();
            // 初始化图表类型选择
            selectChartType('bar');
        });
        
        // 加载数据
        function loadData() {
            var xhr = new XMLHttpRequest();
            xhr.open('POST', 'tongjitu.aspx', true);
            xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {
                        try {
                            var result = JSON.parse(xhr.responseText);
                            if (result.success) {
                                dynamicFields = result.data.fields || [];
                                chartData = result.data.data || [];
                                
                                // 更新数据计数
                                document.getElementById('dataCount').textContent = '共加载 ' + chartData.length + ' 条数据';
                                
                                // 渲染字段选择
                                renderFieldSelection();
                            } else {
                                alert('加载数据失败：' + result.message);
                            }
                        } catch(e) {
                            console.log('解析失败:', e);
                            alert('数据加载失败');
                        }
                    } else {
                        alert('网络错误，请重试');
                    }
                }
            };
            xhr.send('action=loaddata');
        }
        
        // 渲染字段选择
        function renderFieldSelection() {
            var container = document.getElementById('fieldSelection');
            container.innerHTML = '';
            
            dynamicFields.forEach(function(field, index) {
                var itemDiv = document.createElement('div');
                itemDiv.className = 'field-item';
                itemDiv.setAttribute('data-index', index);
                
                var checkbox = document.createElement('input');
                checkbox.type = 'checkbox';
                checkbox.className = 'field-checkbox';
                checkbox.id = 'field_' + index;
                checkbox.onchange = function() { toggleFieldSelection(index); };
                
                var label = document.createElement('label');
                label.htmlFor = 'field_' + index;
                label.className = 'field-name';
                label.textContent = field;
                
                itemDiv.appendChild(checkbox);
                itemDiv.appendChild(label);
                container.appendChild(itemDiv);
            });
            
            // 分组字段选择
            var groupSelect = document.getElementById('groupField');
            groupSelect.innerHTML = '<option value="">请选择分组字段</option>';
            
            dynamicFields.forEach(function(field, index) {
                var option = document.createElement('option');
                option.value = index;
                option.textContent = field;
                groupSelect.appendChild(option);
            });
        }
        
        // 切换字段选择
        function toggleFieldSelection(index) {
            var checkbox = document.getElementById('field_' + index);
            var fieldItems = document.querySelectorAll('.field-item[data-index="' + index + '"]');
            var fieldItem = fieldItems.length > 0 ? fieldItems[0] : null;
            
            if (checkbox.checked) {
                if (!selectedFields.includes(index)) {
                    selectedFields.push(index);
                }
                if (fieldItem) {
                    fieldItem.classList.add('selected');
                }
            } else {
                selectedFields = selectedFields.filter(f => f !== index);
                if (fieldItem) {
                    fieldItem.classList.remove('selected');
                }
            }
        }
        
        // 选择分组字段
        function selectGroupField() {
            selectedGroupField = document.getElementById('groupField').value;
        }
        
        // 选择图表类型
        function selectChartType(type) {
            selectedChartType = type;
            
            // 更新按钮状态
            var buttons = document.querySelectorAll('.chart-type-btn');
            buttons.forEach(function(btn) {
                btn.classList.remove('active');
            });
            
            var activeButton = document.querySelector('.chart-type-btn[data-type="' + type + '"]');
            if (activeButton) {
                activeButton.classList.add('active');
            }
        }
        
        // 生成统计图表
        function generateChart() {
            if (selectedFields.length === 0) {
                alert('请至少选择一个统计字段');
                return;
            }
            
            // 如果没有选择分组字段，使用简单图表
            if (!selectedGroupField) {
                generateSimpleChart();
            } else {
                generateGroupedChart();
            }
        }
        
        // 生成简单图表（无分组）
        function generateSimpleChart() {
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            var datasets = [];
            var labels = [];
            
            // 为每个选中的字段创建数据集
            selectedFields.forEach(function(fieldIndex, idx) {
                var fieldName = dynamicFields[fieldIndex];
                var fieldData = [];
                
                // 收集该字段的所有数据
                chartData.forEach(function(dataRow, rowIndex) {
                    var value = dataRow.values[fieldIndex] || 0;
                    var numValue = parseFloat(value);
                    fieldData.push(isNaN(numValue) ? 0 : numValue);
                });
                
                // 计算统计信息
                var stats = calculateStatistics(fieldData);
                
                var datasetConfig = {
                    label: fieldName + ' (平均: ' + stats.average.toFixed(2) + ')',
                    data: fieldData,
                    backgroundColor: getColorForIndex(idx, 0.7),
                    borderColor: getColorForIndex(idx, 1),
                    borderWidth: 2,
                    tension: 0.4, // 添加曲线平滑度，对折线图特别重要
                    pointBackgroundColor: getColorForIndex(idx, 1),
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2,
                    pointRadius: 4,
                    pointHoverRadius: 6
                };
                
                // 针对折线图添加特殊配置
                if (selectedChartType === 'line') {
                    datasetConfig.fill = false;
                    datasetConfig.backgroundColor = 'transparent';
                }
                
                datasets.push(datasetConfig);
            });
            
            // 准备标签数据
            labels = chartData.map(function(dataRow, index) {
                return '第' + (index + 1) + '条';
            });
            
            // 更新图表
            updateChart(labels, datasets);
            
            // 更新统计信息
            updateStatisticsInfo(selectedFields);
        }
        
        // 生成分组图表
        function generateGroupedChart() {

            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            var groupFieldIndex = parseInt(selectedGroupField);
            var groupFieldName = dynamicFields[groupFieldIndex];
            
            // 按分组字段的值分组数据
            var groupedData = {};
            var labels = [];
            
            chartData.forEach(function(dataRow) {
                var groupValue = dataRow.values[groupFieldIndex] || '未知';
                
                if (!groupedData[groupValue]) {
                    groupedData[groupValue] = [];
                    if (!labels.includes(groupValue)) {
                        labels.push(groupValue);
                    }
                }
                
                groupedData[groupValue].push(dataRow);
            });
            
            // 确保标签数据有序
            labels.sort();
            
            var datasets = [];
            
            // 为每个选中的字段创建数据集
            selectedFields.forEach(function(fieldIndex, idx) {
                // 如果选择了分组字段作为统计字段，则跳过
                if (fieldIndex === groupFieldIndex) return;
                
                var fieldName = dynamicFields[fieldIndex];
                var fieldData = [];
                
                // 计算每个分组的平均值
                labels.forEach(function(groupValue) {
                    var groupRows = groupedData[groupValue] || [];
                    
                    if (groupRows.length > 0) {
                        var sum = 0;
                        var count = 0;
                        
                        groupRows.forEach(function(row) {
                            var value = row.values[fieldIndex] || 0;
                            var numValue = parseFloat(value);
                            if (!isNaN(numValue)) {
                                sum += numValue;
                                count++;
                            }
                        });
                        
                        fieldData.push(count > 0 ? (sum / count) : 0);
                    } else {
                        fieldData.push(0);
                    }
                });
                
                // 计算统计信息
                var stats = calculateStatistics(fieldData);
                
                var datasetConfig = {
                    label: fieldName + ' (平均: ' + stats.average.toFixed(2) + ')',
                    data: fieldData,
                    backgroundColor: getColorForIndex(idx, 0.7),
                    borderColor: getColorForIndex(idx, 1),
                    borderWidth: 2,
                    tension: 0.4,
                    pointBackgroundColor: getColorForIndex(idx, 1),
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2,
                    pointRadius: 4,
                    pointHoverRadius: 6
                };
                
                // 针对折线图添加特殊配置
                if (selectedChartType === 'line') {
                    datasetConfig.fill = false;
                    datasetConfig.backgroundColor = 'transparent';
                }
                
                datasets.push(datasetConfig);
            });
            
            // 如果数据集为空（可能只选了分组字段），提示用户
            if (datasets.length === 0) {
                alert('请至少选择一个非分组字段作为统计字段');
                return;
            }
            
            // 更新图表
            updateChart(labels, datasets);
            
            // 更新统计信息
            updateStatisticsInfo(selectedFields.filter(f => f !== groupFieldIndex));
        }
        
        // 更新图表
        function updateChart(labels, datasets) {

            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            var chartTitle = '统计图表';
            if (selectedGroupField) {
                chartTitle += ' - 按' + dynamicFields[selectedGroupField] + '分组';
            }
            
            // 销毁之前的图表实例
            if (chartInstance) {
                chartInstance.destroy();
            }
            
            var canvas = document.getElementById('chartCanvas');
            var ctx = canvas.getContext('2d');
            
            // 根据图表类型配置
            var chartType = selectedChartType;
            var chartOptions = {
                type: chartType,
                data: {
                    labels: labels,
                    datasets: datasets
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        title: {
                            display: true,
                            text: chartTitle,
                            font: {
                                size: 18,
                                weight: 'bold'
                            },
                            padding: 20
                        },
                        legend: {
                            display: true,
                            position: 'top',
                            labels: {
                                boxWidth: 12,
                                padding: 15,
                                font: {
                                    size: 12
                                }
                            }
                        },
                        tooltip: {
                            enabled: true,
                            mode: 'index',
                            intersect: false,
                            backgroundColor: 'rgba(0, 0, 0, 0.7)',
                            titleFont: {
                                size: 14
                            },
                            bodyFont: {
                                size: 13
                            },
                            padding: 12
                        }
                    }
                }
            };
            
            // 为不同图表类型添加特定配置
            if (chartType === 'bar') {
                chartOptions.options.scales = {
                    x: {
                        display: true,
                        title: {
                            display: true,
                            text: selectedGroupField ? dynamicFields[selectedGroupField] : '序号',
                            font: {
                                size: 14,
                                weight: 'bold'
                            }
                        },
                        grid: {
                            display: true,
                            color: 'rgba(0, 0, 0, 0.05)'
                        }
                    },
                    y: {
                        display: true,
                        title: {
                            display: true,
                            text: '数值',
                            font: {
                                size: 14,
                                weight: 'bold'
                            }
                        },
                        beginAtZero: true,
                        grid: {
                            display: true,
                            color: 'rgba(0, 0, 0, 0.05)'
                        }
                    }
                };
            } else if (chartType === 'line') {
                chartOptions.options.scales = {
                    x: {
                        display: true,
                        title: {
                            display: true,
                            text: selectedGroupField ? dynamicFields[selectedGroupField] : '序号',
                            font: {
                                size: 14,
                                weight: 'bold'
                            }
                        },
                        grid: {
                            display: true,
                            color: 'rgba(0, 0, 0, 0.05)'
                        }
                    },
                    y: {
                        display: true,
                        title: {
                            display: true,
                            text: '数值',
                            font: {
                                size: 14,
                                weight: 'bold'
                            }
                        },
                        beginAtZero: false, // 折线图通常不从零开始
                        grid: {
                            display: true,
                            color: 'rgba(0, 0, 0, 0.05)'
                        }
                    }
                };
            } else if (chartType === 'pie' || chartType === 'doughnut') {
                // 饼图和环形图不需要坐标轴
                chartOptions.options.scales = {};
                
                // 为饼图/环形图调整数据格式
                if (datasets.length > 0) {
                    // 只使用第一个数据集
                    var firstDataset = datasets[0];
                    chartOptions.data.datasets = [firstDataset];
                    
                    // 添加百分比显示
                    chartOptions.options.plugins.tooltip.callbacks = {
                        label: function(context) {
                            var label = context.label || '';
                            var value = context.raw || 0;
                            var total = context.dataset.data.reduce((a, b) => a + b, 0);
                            var percentage = total > 0 ? ((value / total) * 100).toFixed(1) : 0;
                            return label + ': ' + value + ' (' + percentage + '%)';
                        }
                    };
                }
            }
            
            // 创建新图表
            chartInstance = new Chart(ctx, chartOptions);
            
            // 更新页面标题
            document.querySelector('.chart-title').textContent = chartTitle;
        }
        
        // 计算统计信息
        function calculateStatistics(data) {
            if (!data || data.length === 0) {
                return {
                    average: 0,
                    total: 0,
                    max: 0,
                    min: 0,
                    count: 0
                };
            }
            
            var validData = data.filter(function(d) { return !isNaN(d); });
            if (validData.length === 0) {
                return {
                    average: 0,
                    total: 0,
                    max: 0,
                    min: 0,
                    count: 0
                };
            }
            
            var sum = validData.reduce(function(a, b) { return a + b; }, 0);
            var max = Math.max.apply(null, validData);
            var min = Math.min.apply(null, validData);
            
            return {
                average: validData.length > 0 ? sum / validData.length : 0,
                total: sum,
                max: max,
                min: min,
                count: validData.length
            };
        }
        
        // 更新统计信息显示
        function updateStatisticsInfo(fieldIndices) {
            var infoHtml = '';
            
            fieldIndices.forEach(function(fieldIndex) {
                var fieldName = dynamicFields[fieldIndex];
                var fieldData = chartData.map(function(row) { 
                    return parseFloat(row.values[fieldIndex]) || 0; 
                });
                var stats = calculateStatistics(fieldData);
                
                infoHtml += '<div class="info-item">' +
                           '<span class="info-label">' + fieldName + ':</span>' +
                           '<span class="info-value">' +
                           '平均 ' + stats.average.toFixed(2) + ' | ' +
                           '最大 ' + stats.max.toFixed(2) + ' | ' +
                           '最小 ' + stats.min.toFixed(2) +
                           '</span>' +
                           '</div>';
            });
            
            document.getElementById('statisticsInfo').innerHTML = infoHtml;
        }
        
        // 获取颜色（改进版，确保颜色多样性）
        function getColorForIndex(index, alpha) {
            var colors = [
                {bg: 'rgba(24, 144, 255, ', border: 'rgba(24, 144, 255, '},    // 蓝色
                {bg: 'rgba(82, 196, 26, ', border: 'rgba(82, 196, 26, '},     // 绿色
                {bg: 'rgba(250, 173, 20, ', border: 'rgba(250, 173, 20, '},   // 橙色
                {bg: 'rgba(245, 34, 45, ', border: 'rgba(245, 34, 45, '},     // 红色
                {bg: 'rgba(114, 46, 209, ', border: 'rgba(114, 46, 209, '},   // 紫色
                {bg: 'rgba(19, 194, 194, ', border: 'rgba(19, 194, 194, '},   // 青色
                {bg: 'rgba(235, 47, 150, ', border: 'rgba(235, 47, 150, '},   // 粉色
                {bg: 'rgba(130, 202, 157, ', border: 'rgba(130, 202, 157, '}, // 浅绿
                {bg: 'rgba(231, 76, 60, ', border: 'rgba(231, 76, 60, '},     // 番茄红
                {bg: 'rgba(155, 89, 182, ', border: 'rgba(155, 89, 182, '}    // 紫罗兰
            ];
            
            var colorIndex = index % colors.length;
            var color = colors[colorIndex];
            
            return color.bg + alpha + ')';
        }
        
        // 导出图表为图片
        function exportChartImage() {

            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            if (!chartInstance) {
                alert('请先生成图表');
                return;
            }
            
            var canvas = document.getElementById('chartCanvas');
            var image = canvas.toDataURL('image/png');
            
            var link = document.createElement('a');
            link.href = image;
            link.download = '统计图表_' + new Date().getTime() + '.png';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
        
        // 显示数据表格
        function showDataTable() {

            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }

            if (selectedFields.length === 0) {
                alert('请先选择统计字段');
                return;
            }
            
            var tableHtml = '<table class="data-table">';
            
            // 表头
            tableHtml += '<thead><tr>';
            if (selectedGroupField) {
                tableHtml += '<th>' + dynamicFields[selectedGroupField] + '</th>';
            } else {
                tableHtml += '<th>序号</th>';
            }
            
            selectedFields.forEach(function(fieldIndex) {
                if (selectedGroupField && fieldIndex == selectedGroupField) {
                    // 如果字段是分组字段，已经显示在表头，跳过
                    return;
                }
                tableHtml += '<th>' + dynamicFields[fieldIndex] + '</th>';
            });
            tableHtml += '</tr></thead>';
            
            // 数据行
            tableHtml += '<tbody>';
            
            if (selectedGroupField) {
                // 分组显示
                var groupFieldIndex = parseInt(selectedGroupField);
                var groupedData = {};
                
                chartData.forEach(function(dataRow) {
                    var groupValue = dataRow.values[groupFieldIndex] || '未知';
                    if (!groupedData[groupValue]) {
                        groupedData[groupValue] = [];
                    }
                    groupedData[groupValue].push(dataRow);
                });
                
                Object.keys(groupedData).sort().forEach(function(groupValue) {
                    var groupRows = groupedData[groupValue];
                    var rowCount = groupRows.length;
                    
                    groupRows.forEach(function(row, rowIndex) {
                        tableHtml += '<tr>';
                        
                        // 如果是第一行，显示分组值并跨行
                        if (rowIndex === 0) {
                            tableHtml += '<td rowspan="' + rowCount + '">' + groupValue + '</td>';
                        }
                        
                        selectedFields.forEach(function(fieldIndex) {
                            if (fieldIndex === groupFieldIndex) return;
                            var value = row.values[fieldIndex] || '0';
                            var numValue = parseFloat(value);
                            tableHtml += '<td>' + (isNaN(numValue) ? value : numValue.toFixed(2)) + '</td>';
                        });
                        
                        tableHtml += '</tr>';
                    });
                });
            } else {
                // 简单列表显示
                chartData.forEach(function(dataRow, rowIndex) {
                    tableHtml += '<tr><td>' + (rowIndex + 1) + '</td>';
                    
                    selectedFields.forEach(function(fieldIndex) {
                        var value = dataRow.values[fieldIndex] || '0';
                        var numValue = parseFloat(value);
                        tableHtml += '<td>' + (isNaN(numValue) ? value : numValue.toFixed(2)) + '</td>';
                    });
                    
                    tableHtml += '</tr>';
                });
            }
            
            tableHtml += '</tbody></table>';
            
            var container = document.getElementById('dataTableContainer');
            container.innerHTML = '<div style="text-align: center; margin: 10px 0;">' +
                                '<strong>详细数据 (共' + chartData.length + '条记录)</strong>' +
                                '</div>' + tableHtml;
            container.style.display = 'block';
        }
        
        // 隐藏数据表格
        function hideDataTable() {
            document.getElementById('dataTableContainer').style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="ti">
                <h1>统计图表分析</h1>
            </div>
            
            <div class="header-top">
                <div style="display: flex; flex-wrap: wrap; gap: 15px; align-items: center;">
                    <button type="button" onclick="generateChart()" class="top_bt">生成图表</button>
                    <button type="button" onclick="exportChartImage()" class="top_bt">导出图片</button>
                    <button type="button" onclick="showDataTable()" class="top_bt">查看数据</button>
                    <button type="button" onclick="hideDataTable()" class="top_bt">隐藏表格</button>
                    <button type="button" onclick="loadData()" class="top_bt">刷新数据</button>
                </div>
            </div>
            
            <div class="main-container">
                <!-- 左侧配置面板 -->
                <div class="config-panel">
                    <div class="config-title">统计配置</div>
                    
                    <div class="config-form">
                        <!-- 字段选择 -->
                        <div class="form-group">
                            <label class="form-label">选择统计字段：</label>
                            <div class="field-selection" id="fieldSelection">
                                <!-- 字段将通过JS动态加载 -->
                            </div>
                        </div>
                        
                        <!-- 分组字段选择 -->
                        <div class="form-group">
                            <label class="form-label">分组字段（可选）：</label>
                            <select id="groupField" class="form-select" onchange="selectGroupField()">
                                <option value="">请选择分组字段</option>
                            </select>
                        </div>
                        
                        <!-- 图表类型选择 -->
                        <div class="form-group">
                            <label class="form-label">选择图表类型：</label>
                            <div class="chart-type-selector">
                                <button type="button" class="chart-type-btn active" data-type="bar" onclick="selectChartType('bar')">柱状图</button>
                                <button type="button" class="chart-type-btn" data-type="line" onclick="selectChartType('line')">折线图</button>
                                <%--<button type="button" class="chart-type-btn" data-type="pie" onclick="selectChartType('pie')">饼图</button>
                                <button type="button" class="chart-type-btn" data-type="doughnut" onclick="selectChartType('doughnut')">环形图</button>--%>
                            </div>
                        </div>
                        
                        <!-- 统计说明 -->
                        <div class="chart-info">
                            <div class="info-title">使用说明</div>
                            <div style="font-size: 12px; color: #666; line-height: 1.6;">
                                <p>1. 勾选要统计的字段</p>
                                <p>2. 可选选择分组字段进行分组统计</p>
                                <p>3. 选择图表类型</p>
                                <p>4. 点击"生成图表"查看结果</p>
                                <p>注：折线图需要至少2个数据点才能显示</p>
                            </div>
                        </div>
                    </div>
                </div>
                
                <!-- 右侧图表区域 -->
                <div class="chart-panel">
                    <div class="chart-header">
                        <div class="chart-title">统计图表</div>
                        <div class="chart-actions">
                            <span id="dataCount" style="color: #666; font-size: 14px;">共加载 0 条数据</span>
                        </div>
                    </div>
                    
                    <!-- 图表容器 -->
                    <div class="chart-container">
                        <canvas id="chartCanvas"></canvas>
                    </div>
                    
                    <!-- 统计信息 -->
                    <div class="chart-info">
                        <div class="info-title">统计信息</div>
                        <div class="info-content" id="statisticsInfo">
                            <!-- 统计信息将通过JS动态加载 -->
                        </div>
                    </div>
                    
                    <!-- 数据表格 -->
                    <div class="data-table-container" id="dataTableContainer" style="display: none;">
                        <!-- 数据表格将通过JS动态加载 -->
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>