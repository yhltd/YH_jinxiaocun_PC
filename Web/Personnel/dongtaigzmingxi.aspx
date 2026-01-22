<%@ page language="C#" autoeventwireup="true" codebehind="dongtaigzmingxi.aspx.cs" inherits="Web.Personnel.dongtaigzmingxi" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>动态工资明细管理</title>
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
        
        /* 表格样式 */
        table {
            border-collapse: separate !important;
            border-spacing: 0 !important;
            width: 100%;
            border-radius: 8px !important;
            overflow: hidden !important;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15) !important;
            background: white !important;
            border: 1px solid #ddd !important;
        }
        
        table th {
            background: linear-gradient(to bottom, #4b77d0, #0521e8);
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            border: none !important;
            position: sticky;
            top: 0;
        }
        
        table td {
            padding: 12px 15px !important;
            border: 1px solid #e0e0e0 !important;
            text-align: center !important;
            min-width: 150px;
        }
        
        /* 斑马条纹效果 */
        table tr:nth-child(even) td {
            background: linear-gradient(to bottom, #f9f9f9, #f0f0f0) !important;
        }
        
        table tr:nth-child(odd) td {
            background: linear-gradient(to bottom, #ffffff, #f7f7f7) !important;
        }
        
        table tr:hover td {
            background: linear-gradient(to bottom, #e8f5e9, #c8e6c9) !important;
        }
        
        /* 按钮样式 */
        .btn-edit {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 3px;
            cursor: pointer;
            font-size: 12px;
            margin: 2px;
        }
        
        .btn-delete {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 3px;
            cursor: pointer;
            font-size: 12px;
            margin: 2px;
        }
        
        /* 模态框样式 */
        .modal {
            display: none;
            position: fixed;
            z-index: 1000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0,0,0,0.5);
        }
        
        .modal-content {
            background-color: white;
            margin: 5% auto;
            padding: 20px;
            border-radius: 8px;
            width: 80%;
            max-width: 600px;
            max-height: 80vh;
            overflow-y: auto;
        }
        
        .modal-header {
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 20px;
            text-align: center;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        
        .modal-body {
            margin-bottom: 20px;
        }
        
        .modal-footer {
            display: flex;
            justify-content: flex-end;
            gap: 10px;
        }
        
        .form-group {
            margin-bottom: 15px;
        }
        
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: 600;
        }
        
        .form-group input,
        .form-group select,
        .form-group textarea {
            width: 100%;
            padding: 8px 12px;
            border: 1px solid #ddd;
            border-radius: 4px;
            font-size: 14px;
        }
        
        /* 标题配置样式 */
        .title-fields-container {
            max-height: 300px;
            overflow-y: auto;
            margin-bottom: 20px;
            border: 1px solid #ddd;
            border-radius: 4px;
            padding: 10px;
        }
        
        .title-field-item {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
            padding: 10px;
            background: #f9f9f9;
            border-radius: 4px;
        }
        
        .title-field-input {
            flex: 1;
            margin-right: 10px;
        }
        
        .title-field-index {
            margin-right: 10px;
            font-weight: bold;
            color: #5677fc;
        }
        
        /* 公式配置样式 */
        .operator-buttons {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            margin: 10px 0;
        }
        
        .operator-btn {
            padding: 5px 10px;
            background: #5677fc;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
        }
        
        .field-buttons {
            display: flex;
            flex-wrap: wrap;
            gap: 10px;
            margin: 10px 0;
        }
        
        .field-btn {
            padding: 5px 10px;
            background: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 12px;
        }
        
        .formula-preview {
            padding: 10px;
            background: #f0f0f0;
            border-radius: 4px;
            margin: 10px 0;
            font-family: monospace;
        }
        
        .formula-list {
            margin-top: 20px;
            max-height: 200px;
            overflow-y: auto;
        }
        
        .formula-item {
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            margin-bottom: 10px;
            background: #f9f9f9;
        }
        
        /* 操作说明弹窗 */
        .guide-modal {
            display: none;
            position: fixed;
            z-index: 1001;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
        }
        
        .modal-mask {
            position: absolute;
            width: 100%;
            height: 100%;
            background: rgba(0,0,0,0.5);
        }
        
        .modal-content-guide {
            position: relative;
            background-color: white;
            margin: 10% auto;
            padding: 20px;
            border-radius: 8px;
            width: 80%;
            max-width: 600px;
            max-height: 70vh;
            overflow-y: auto;
        }
        
        .guide-text {
            white-space: pre-line;
            line-height: 1.6;
        }
        
        .close-guide {
            position: absolute;
            top: 10px;
            right: 15px;
            font-size: 24px;
            cursor: pointer;
            color: #666;
        }
        
        /* 滚动区域 */
        .scrollable-container {
            overflow-x: auto;
            margin: 20px 0;
            border: 1px solid #ddd;
            border-radius: 8px;
            background: white;
        }
        
        .table-wrapper {
            min-width: 100%;
        }
        
        /* 单元格编辑样式 */
        .editable-cell {
            cursor: pointer;
            transition: background-color 0.3s;
        }
        
        .editable-cell:hover {
            background-color: #e3f2fd !important;
        }
        
        /* 底部操作区 */
        .action-buttons {
            display: flex;
            justify-content: center;
            gap: 20px;
            margin: 20px 0;
            flex-wrap: wrap;
        }
        
        .action-btn {
            min-width: 120px;
        }
        
        /* 响应式设计 */
        @media (max-width: 768px) {
            .action-buttons {
                flex-direction: column;
                align-items: center;
            }
            
            .action-btn {
                width: 80%;
                margin-bottom: 10px;
            }
            
            .modal-content {
                width: 95%;
                margin: 10% auto;
            }
        }
    </style>
    <script src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        // 动态标题配置
        var dynamicTitles = <%= GetDynamicTitlesJson() %>;
        var formulaList = <%= GetFormulaListJson() %>;
        var separator = "|||";
        
        // 显示标题配置模态框
        function showTitleModal() {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }
            // 加载当前标题配置
            loadTitleConfig();
            $('#titleModal').show();
        }
        
        function hideTitleModal() {
            $('#titleModal').hide();
        }
        
        // 加载标题配置
        function loadTitleConfig() {
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: { action: 'loadtitleconfig' },
                success: function(result) {
                    try {
                        if (result.success) {
                            renderTitleFields(result.fields);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 渲染标题字段
        function renderTitleFields(fields) {
            var container = $('#titleFieldsContainer');
            container.empty();
            
            fields.forEach(function(field, index) {
                var fieldHtml = `
                    <div class="title-field-item">
                        <span class="title-field-index">${index + 1}</span>
                        <input type="text" class="title-field-input" 
                value="${field}" 
                data-index="${index}"
                placeholder="请输入字段名称" />
         <button type="button" onclick="removeTitleField(${index})" 
                                class="btn-delete" ${index === 0 ? 'disabled' : ''}>
                            删除
                        </button>
                    </div>
                `;
                container.append(fieldHtml);
            });
        }
        
        // 添加标题字段
        function addTitleField() {
            var container = $('#titleFieldsContainer');
            var index = container.children().length;
            
            var fieldHtml = `
                <div class="title-field-item">
                    <span class="title-field-index">${index + 1}</span>
                    <input type="text" class="title-field-input" 
            value="" 
            data-index="${index}"
            placeholder="请输入字段名称" />
     <button type="button" onclick="removeTitleField(${index})" 
                            class="btn-delete">
                        删除
                    </button>
                </div>
            `;
            container.append(fieldHtml);
        }
        
        // 删除标题字段
        function removeTitleField(index) {
            if (index === 0) {
                alert('第一个字段不能删除');
                return;
            }
    
            // 安全地获取字段名
            var fieldElement = $('.title-field-input[data-index="' + index + '"]');
            var fieldName = '';
    
            if (fieldElement.length > 0) {
                fieldName = fieldElement.val() || '';
                fieldName = fieldName.trim();
            }
    
            console.log('要删除的字段名:', fieldName, '索引:', index); // 调试用
    
            // 检查字段是否在公式中使用
            if (fieldName && checkFieldUsedInFormula(fieldName)) {
                alert('该字段已在公式中使用，请先删除相关公式');
                return;
            }
    
            // 重新渲染所有字段
            var fields = [];
            $('.title-field-input').each(function() {
                var currentIndex = $(this).data('index');
                var currentValue = $(this).val() || '';
        
                if (currentIndex !== index && currentValue.trim() !== '') {
                    fields.push(currentValue);
                }
            });
    
            renderTitleFields(fields);
        }

        // 新增辅助函数处理删除逻辑
        function proceedWithRemoval(index) {
            var fields = [];
            $('.title-field-input').each(function() {
                if ($(this).data('index') !== index) {
                    fields.push($(this).val());
                }
            });
    
            renderTitleFields(fields);
        }
        
        // 检查字段是否在公式中使用
        function checkFieldUsedInFormula(fieldName) {
            console.log('检查字段:', fieldName, 'formulaList:', formulaList); // 调试用
    
            // 1. 先检查fieldName是否有效
            if (!fieldName || typeof fieldName !== 'string') {
                console.log('字段名无效:', fieldName);
                return false;
            }
    
            // 2. 检查formulaList是否存在且是数组
            if (!formulaList) {
                console.log('formulaList未定义');
                return false;
            }
    
            if (!Array.isArray(formulaList)) {
                console.log('formulaList不是数组:', typeof formulaList);
                return false;
            }
    
            // 3. 遍历检查
            for (var i = 0; i < formulaList.length; i++) {
                var formula = formulaList[i];
        
                // 跳过无效的formula对象
                if (!formula || typeof formula !== 'object') {
                    console.log('跳过无效的formula对象:', formula);
                    continue;
                }
        
                // 安全地获取属性
                var gongshi = formula.gongshi || '';
                var zhuziduan = formula.zhuziduan || '';
        
                console.log('检查公式:', zhuziduan, '=', gongshi);
        
                // 检查字段是否在公式中
                if (typeof gongshi === 'string' && gongshi.indexOf(fieldName) !== -1) {
                    console.log('字段在公式内容中找到:', fieldName);
                    return true;
                }
        
                if (zhuziduan === fieldName) {
                    console.log('字段是目标字段:', fieldName);
                    return true;
                }
            }
    
            console.log('字段未在公式中使用');
            return false;
        }
        
        // 保存标题配置
        function saveTitle() {
            var fields = [];
            $('.title-field-input').each(function() {
                var value = $(this).val().trim();
                if (value) {
                    fields.push(value);
                }
            });
            
            if (fields.length === 0) {
                alert('请至少输入一个字段');
                return;
            }
            
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: {
                    action: 'savetitleconfig',
                    fields: JSON.stringify(fields)
                },
                success: function(result) {
                    try {
                        if (result.success) {
                            alert('保存成功');
                            hideTitleModal();
                            location.reload();
                        } else {
                            alert('保存失败：' + result.message);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 显示公式配置模态框
        function showFormulaModal() {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }
            loadFormulaList();
            $('#formulaModal').show();
        }
        
        function hideFormulaModal() {
            $('#formulaModal').hide();
        }
        
        // 加载公式列表
        function loadFormulaList() {
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: { action: 'loadformulalist' },
                success: function(result) {
                    try {
                        if (result.success) {
                            formulaList = result.formulas;
                            renderFormulaList();
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 渲染公式列表
        function renderFormulaList() {
            var container = $('#formulaListContainer');
            container.empty();
            
            if (formulaList.length === 0) {
                container.html('<div style="text-align:center;color:#666;">暂无公式配置</div>');
                return;
            }
            
            formulaList.forEach(function(formula, index) {
                var formulaHtml = `
                    <div class="formula-item">
                        <div><strong>${formula.zhuziduan}</strong> = ${formula.gongshi}</div>
                        <div style="text-align:right;margin-top:5px;">
                            <button type="button" onclick="deleteFormula(${formula.id})" 
                                    class="btn-delete">
                                删除
                            </button>
                        </div>
                    </div>
                `;
                container.append(formulaHtml);
            });
        }
        
        // 目标字段选择变化
        function onTargetFieldChange() {
            var select = $('#targetFieldSelect');
            var selectedField = select.val();
            $('#formulaTargetField').val(selectedField);
        }
        
        // 插入运算符
        function insertOperator(operator) {
            var expression = $('#formulaExpression').val();
            $('#formulaExpression').val(expression + operator);
        }
        
        // 插入字段
        function insertField(fieldName) {
            var expression = $('#formulaExpression').val();
            $('#formulaExpression').val(expression + (expression ? ' ' : '') + fieldName + ' ');
        }
        
        // 保存公式
        function saveFormula() {
            var targetField = $('#formulaTargetField').val();
            var expression = $('#formulaExpression').val();
            
            if (!targetField) {
                alert('请选择目标字段');
                return;
            }
            
            if (!expression) {
                alert('请输入计算公式');
                return;
            }
            
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: {
                    action: 'saveformula',
                    targetField: targetField,
                    expression: expression
                },
                success: function(result) {
                    try {
                        if (result.success) {
                            alert('保存成功');
                            $('#formulaTargetField').val('');
                            $('#formulaExpression').val('');
                            loadFormulaList();
                        } else {
                            alert('保存失败：' + result.message);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 删除公式
        function deleteFormula(formulaId) {
            if (!confirm('确定要删除这个公式吗？')) {
                return;
            }
            
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: {
                    action: 'deleteformula',
                    formulaId: formulaId
                },
                success: function(result) {
                    try {
                        if (result.success) {
                            alert('删除成功');
                            loadFormulaList();
                        } else {
                            alert('删除失败：' + result.message);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 显示操作说明
        function showGuide() {
            // 防止事件冒泡
            if (event) {
                event.stopPropagation();
                event.preventDefault();
            }
            $('#guideModal').show();
        }
        
        function hideGuide() {
            $('#guideModal').hide();
        }
        
        // 跳转到统计图表
        function gotoStatistics() {
            window.location.href = 'toujitu.aspx';
        }
        
        // 添加一行数据
        function addRow() {
            if (!confirm('确认添加新的数据行？')) {
                return;
            }
            
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: { action: 'addrow' },
                success: function(result) {
                    try {
                        if (result.success) {
                            alert('添加成功');
                            location.reload();
                        } else {
                            alert('添加失败：' + result.message);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 删除数据行
        function deleteRow(id, index) {
            if (!confirm('确认删除序号为 ' + index + ' 的数据行吗？')) {
                return;
            }
            
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: {
                    action: 'deleterow',
                    id: id
                },
                success: function(result) {
                    try {
                        if (result.success) {
                            alert('删除成功');
                            location.reload();
                        } else {
                            alert('删除失败：' + result.message);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                }
            });
        }
        
        // 编辑单元格
        function editCell(id, columnIndex, currentValue) {
            var newValue = prompt('请输入新的值：', currentValue);
            if (newValue !== null) {
                $.ajax({
                    url: 'dongtaigzmingxi.aspx',
                    type: 'POST',
                    data: {
                        action: 'editcell',
                        id: id,
                        columnIndex: columnIndex,
                        newValue: newValue
                    },
                    success: function(result) {
                        try {
                            if (result.success) {
                                alert('修改成功');
                                location.reload();
                            } else {
                                alert('修改失败：' + result.message);
                            }
                        } catch(e) {
                            console.log('解析失败:', e);
                        }
                    }
                });
            }
        }
        
        // 计算公式并更新
        function calculateAllData() {
            if (!confirm('确认重新计算数据？将只更新公式涉及的字段。')) {
                return;
            }
    
            $.ajax({
                url: 'dongtaigzmingxi.aspx',
                type: 'POST',
                data: { action: 'calculateformulaonly' }, 
                success: function(result) {
                    try {
                        if (result.success) {
                            alert('计算完成，更新了 ' + result.updatedRows + ' 行数据');
                            location.reload();
                        } else {
                            alert('计算失败：' + result.message);
                        }
                    } catch(e) {
                        console.log('解析失败:', e);
                    }
                },
                error: function(xhr, status, error) {
                    alert('请求失败：' + error);
                }
            });
        }
        
        // 页面加载完成后初始化
        $(document).ready(function() {
            // 初始化目标字段选择
            var targetSelect = $('#targetFieldSelect');
            dynamicTitles.forEach(function(title) {
                targetSelect.append(new Option(title.Text, title.Text));
            });
            
            // 初始化字段按钮
            var fieldButtons = $('#fieldButtons');
            dynamicTitles.forEach(function(title) {
                var button = $('<button type="button" class="field-btn"></button>')
                    .text(title.Text)
                    .click(function() { insertField(title.Text); });
                fieldButtons.append(button);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="ti">
                <h1>动态工资明细管理</h1>
            </div>
            
            <div class="header-top">
                <div style="display: flex; flex-wrap: wrap; gap: 15px; align-items: center;">
                    <button onclick="showTitleModal()" class="top_bt">配置标题</button>
                    <button onclick="showFormulaModal()" class="top_bt">公式配置</button>
                    <button onclick="calculateAllData()" class="top_bt">重新计算</button>
                    <button onclick="addRow()" class="top_bt">添加一行</button>
<%--                    <button onclick="gotoStatistics()" class="top_bt">统计图表</button>--%>
                    <button onclick="showGuide()" class="top_bt">操作说明</button>
                </div>
            </div>
            
            <!-- 数据表格区域 -->
            <div class="scrollable-container">
                <div class="table-wrapper">
                    <table border="1">
                        <thead>
                            <tr>
                                <th style="width: 80px; min-width: 80px;">序号</th>
                                <th style="width: 80px; min-width: 80px;">操作</th>
                                <asp:Repeater ID="rptDynamicHeaders" runat="server">
                                    <ItemTemplate>
                                        <th><%# Container.DataItem %></th>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex + 1 %></td>
                                    <td>
                                        <!-- 修改1：添加ID属性，使用Literal控件 -->
                                        <asp:Literal ID="ltlDeleteButton" runat="server"></asp:Literal>
                                    </td>
                                    <asp:Repeater ID="rptRowData" runat="server">
                                        <ItemTemplate>
                                            <td class="editable-cell" 
                                                onclick='<%# "editCell(\"" + ((Dictionary<string, object>)((RepeaterItem)Container.Parent.Parent).DataItem)["id"] + "\", \"" + Container.ItemIndex + "\", \"" + Container.DataItem + "\")" %>'>
                                                <%# Container.DataItem %>
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            
            <!-- 分页控件 -->
            <div style="text-align: center; margin: 20px 0;">
                <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" CssClass="top_bt" />
                <asp:Button ID="btnPrev" runat="server" Text="上一页" OnClick="btnPrev_Click" CssClass="top_bt" />
                <span style="margin: 0 15px;">
                    第 <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label> 页
                    共 <asp:Label ID="lblTotalPages" runat="server" Text="1"></asp:Label> 页
                </span>
                <asp:Button ID="btnNext" runat="server" Text="下一页" OnClick="btnNext_Click" CssClass="top_bt" />
                <asp:Button ID="btnLast" runat="server" Text="末页" OnClick="btnLast_Click" CssClass="top_bt" />
            </div>
        </div>
        
        <!-- 标题配置模态框 -->
        <div id="titleModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">
                    <span>配置标题字段</span>
                    <span onclick="hideTitleModal()" style="cursor:pointer;font-size:24px;">×</span>
                </div>
                <div class="modal-body">
                    <div class="title-fields-container" id="titleFieldsContainer">
                        <!-- 标题字段将通过JS动态加载 -->
                    </div>
                    <div style="text-align: center; margin: 20px 0;">
                        <button type="button" onclick="addTitleField()" class="top_bt">添加字段</button>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideTitleModal()" class="top_bt" style="background:#999;">取消</button>
                    <button onclick="saveTitle()" class="top_bt">保存配置</button>
                </div>
            </div>
        </div>
        
        <!-- 公式配置模态框 -->
        <div id="formulaModal" class="modal">
            <div class="modal-content">
                <div class="modal-header">
                    <span>配置计算公式</span>
                    <span onclick="hideFormulaModal()" style="cursor:pointer;font-size:24px;">×</span>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>目标字段：</label>
                        <select id="targetFieldSelect" onchange="onTargetFieldChange()">
                            <option value="">请选择目标字段</option>
                        </select>
                        <input type="hidden" id="formulaTargetField" />
                    </div>
                    
                    <div class="form-group">
                        <label>计算公式：</label>
                        <div class="operator-buttons">
                            <button type="button" onclick="insertOperator('+')" class="operator-btn">+</button>
                            <button type="button" onclick="insertOperator('-')" class="operator-btn">-</button>
                            <button type="button" onclick="insertOperator('*')" class="operator-btn">×</button>
                            <button type="button" onclick="insertOperator('/')" class="operator-btn">÷</button>
                            <button type="button" onclick="insertOperator('(')" class="operator-btn">(</button>
                            <button type="button" onclick="insertOperator(')')" class="operator-btn">)</button>
                        </div>
                        
                        <div class="field-buttons" id="fieldButtons">
                            <!-- 字段按钮将通过JS动态加载 -->
                        </div>
                        
                        <input type="text" id="formulaExpression" placeholder="例如：基本工资 + 绩效奖金 * 1.2" 
                               style="width:100%;padding:10px;font-size:14px;" />
                        
                        <div class="formula-preview">
                            公式预览：<span id="formulaPreview"></span>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <label>已保存的公式：</label>
                        <div class="formula-list" id="formulaListContainer">
                            <!-- 公式列表将通过JS动态加载 -->
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button onclick="hideFormulaModal()" class="top_bt" style="background:#999;">取消</button>
                    <button onclick="saveFormula()" class="top_bt">保存公式</button>
                </div>
            </div>
        </div>
        
        <!-- 操作说明模态框 -->
        <div id="guideModal" class="guide-modal">
            <div class="modal-mask" onclick="hideGuide()"></div>
            <div class="modal-content-guide">
                <div class="modal-header">
                    <span>操作说明</span>
                    <span class="close-guide" onclick="hideGuide()">×</span>
                </div>
                <div class="modal-body">
                    <div class="guide-text">
                        操作步骤说明：
                        1. 点击"配置标题"按钮，在弹窗中配置需要的列内容；
                        2. 点击"公式配置"按钮，目标字段内容为计算结果赋值字段；
                        3. 在计算公式中选择已有的计算符，选择下方遍历字段或手动输入数字生成对应计算公式；
                        4. 在已保存公式中可以删除配置好的内容；
                        5.单击单元格在弹窗中输入修改的条件；
                        
                        注意事项：
                        1. 在配置标题中删除字段时需要先接触该字段设计公式内容；
                        2. 公式设计建议从基础字段到高级字段顺序设置；
                        3. 涉及到计算的内容要输入数值内容；
                        4. 修改单元格内容后，可点击"重新计算"按钮更新公式计算结果；
                    </div>
                </div>
            </div>
        </div>
    </form>
    
    <script type="text/javascript">
        // 实时更新公式预览
        $('#formulaExpression').on('input', function() {
            $('#formulaPreview').text($(this).val() || '暂无公式');
        });
    </script>
</body>
</html>