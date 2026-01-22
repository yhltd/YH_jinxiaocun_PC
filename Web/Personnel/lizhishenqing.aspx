<%@ page language="C#" autoeventwireup="true" codebehind="lizhishenqing.aspx.cs" inherits="Web.Personnel.lizhishenqing" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>离职申请</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
        }
        
        body {
            background: linear-gradient(135deg, #f5f7fa 0%, #e4e8f0 100%);
            padding: 20px;
            min-height: 100vh;
        }
        
        .container {
            max-width: 900px;
            margin: 0 auto;
            padding: 20px;
            background: white;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
        
        /* 标题样式 */
        .header {
            text-align: center;
            margin-bottom: 30px;
            padding-bottom: 20px;
            border-bottom: 2px solid #764ba2;
        }
        
        .title {
            font-size: 28px;
            font-weight: 700;
            color: #764ba2;
            display: block;
            margin-bottom: 10px;
        }
        
        .subtitle {
            font-size: 16px;
            color: #666;
            display: block;
        }
        
        /* 表单卡片样式 */
        .form-card {
            background: #f9f9f9;
            border-radius: 10px;
            padding: 30px;
            margin-bottom: 20px;
            border: 1px solid #e0e0e0;
        }
        
        /* 表单项目 */
        .form-item {
            margin-bottom: 25px;
        }
        
        .form-item:last-child {
            margin-bottom: 0;
        }
        
        .label {
            display: block;
            font-size: 16px;
            font-weight: 600;
            color: #333;
            margin-bottom: 8px;
        }
        
        .label::after {
            content: "*";
            color: #f44336;
            margin-left: 4px;
        }
        
        .label.readonly::after {
            content: none;
        }
        
        /* 输入框容器 */
        .input-container {
            position: relative;
        }
        
        .input-container.readonly {
            opacity: 0.8;
        }
        
        .input, .textarea {
            width: 100%;
            padding: 12px 15px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 16px;
            color: #333;
            transition: all 0.3s ease;
            background: white;
        }
        
        .input:focus, .textarea:focus {
            outline: none;
            border-color: #764ba2;
            box-shadow: 0 0 0 2px rgba(118, 75, 162, 0.2);
        }
        
        .input[disabled], .textarea[disabled] {
            background: #f5f5f5;
            color: #666;
            cursor: not-allowed;
        }
        
        .hint {
            position: absolute;
            right: 10px;
            top: 50%;
            transform: translateY(-50%);
            font-size: 12px;
            color: #999;
            background: rgba(255, 255, 255, 0.9);
            padding: 2px 6px;
            border-radius: 4px;
        }
        
        /* 文本域容器 */
        .textarea-container {
            position: relative;
        }
        
        .textarea-container.readonly {
            opacity: 0.8;
        }
        
        .textarea {
            min-height: 120px;
            resize: vertical;
            font-family: inherit;
            line-height: 1.5;
        }
        
        .word-count {
            position: absolute;
            right: 10px;
            bottom: 10px;
            font-size: 12px;
            color: #999;
            background: white;
            padding: 2px 6px;
            border-radius: 4px;
        }
        
        /* 按钮容器 */
        .button-container {
            display: flex;
            flex-direction: column;
            gap: 15px;
            margin-top: 30px;
        }
        
        .submit-btn, .reset-btn, .history-btn {
            padding: 15px 30px;
            border: none;
            border-radius: 8px;
            font-size: 16px;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s ease;
            text-align: center;
            display: block;
            width: 100%;
        }
        
        .submit-btn {
            background: linear-gradient(135deg, #764ba2 0%, #667eea 100%);
            color: white;
        }
        
        .submit-btn:hover:not(:disabled) {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            transform: translateY(-2px);
            box-shadow: 0 4px 12px rgba(118, 75, 162, 0.3);
        }
        
        .submit-btn:disabled {
            opacity: 0.6;
            cursor: not-allowed;
        }
        
        .reset-btn {
            background: #f5f5f5;
            color: #666;
            border: 2px solid #ddd;
        }
        
        .reset-btn:hover {
            background: #e0e0e0;
            border-color: #ccc;
        }
        
        .history-btn {
            background: white;
            color: #764ba2;
            border: 2px solid #764ba2;
        }
        
        .history-btn:hover {
            background: #764ba2;
            color: white;
        }
        
        /* 错误提示 */
        .error-message {
            color: #f44336;
            font-size: 14px;
            margin-top: 5px;
            display: none;
        }
        
        .error-message.show {
            display: block;
        }
        
        /* 提示卡片 */
        .tips-card {
            background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
            border-radius: 10px;
            padding: 20px;
            margin-top: 30px;
            border-left: 4px solid #764ba2;
        }
        
        .tips-title {
            font-size: 18px;
            font-weight: 600;
            color: #764ba2;
            display: block;
            margin-bottom: 15px;
        }
        
        .tips-content {
            display: flex;
            flex-direction: column;
            gap: 8px;
        }
        
        .tips-content text {
            font-size: 14px;
            color: #666;
            line-height: 1.5;
        }
        
        /* 历史记录样式 */
        .history-section {
            margin-top: 30px;
            background: white;
            border-radius: 10px;
            padding: 20px;
            border: 1px solid #e0e0e0;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }
        
        .history-header {
            display: flex;
            justify-content: space-between;
            align-items: flex-start;
            margin-bottom: 20px;
            padding-bottom: 15px;
            border-bottom: 1px solid #e0e0e0;
        }
        
        .history-title {
            font-size: 20px;
            font-weight: 600;
            color: #333;
            display: block;
            margin-bottom: 5px;
        }
        
        .filter-info {
            display: flex;
            gap: 10px;
            flex-wrap: wrap;
        }
        
        .filter-item {
            background: #e9ecef;
            padding: 4px 10px;
            border-radius: 15px;
            font-size: 14px;
            color: #666;
        }
        
        .history-count {
            font-size: 14px;
            color: #764ba2;
            font-weight: 600;
        }
        
        .history-list {
            max-height: 400px;
            overflow-y: auto;
        }
        
        .history-item {
            background: #f8f9fa;
            border-radius: 8px;
            padding: 15px;
            margin-bottom: 10px;
            border-left: 4px solid #764ba2;
            cursor: pointer;
            transition: all 0.3s ease;
            position: relative;
        }
        
        .history-item:hover {
            background: #e9ecef;
            transform: translateX(5px);
        }
        
        .item-header {
            display: flex;
            align-items: center;
            gap: 15px;
            margin-bottom: 10px;
        }
        
        .item-name {
            font-size: 16px;
            font-weight: 600;
            color: #333;
        }
        
        .item-department {
            font-size: 14px;
            color: #666;
            background: #e9ecef;
            padding: 2px 8px;
            border-radius: 4px;
        }
        
        .item-status {
            font-size: 12px;
            padding: 3px 8px;
            border-radius: 4px;
            color: white;
            font-weight: 600;
        }
        
        .item-content {
            display: flex;
            flex-direction: column;
            gap: 5px;
        }
        
        .item-date {
            font-size: 14px;
            color: #999;
        }
        
        .item-reason {
            font-size: 14px;
            color: #666;
            line-height: 1.4;
        }
        
        .item-arrow {
            position: absolute;
            right: 15px;
            top: 50%;
            transform: translateY(-50%);
            font-size: 20px;
            color: #764ba2;
        }
        
        .load-more, .no-more, .no-data {
            text-align: center;
            padding: 20px;
            color: #666;
            font-size: 14px;
            cursor: pointer;
        }
        
        .load-more:hover {
            color: #764ba2;
        }
        
        .no-data {
            color: #999;
        }
        
        /* 状态颜色 */
        .status-tongguo {
            background-color: #07c160 !important;
        }
        
        .status-bohui {
            background-color: #ff4444 !important;
        }
        
        .status-daishanpi {
            background-color: #ff976a !important;
        }
        
        /* 响应式设计 */
        @media (max-width: 768px) {
            .container {
                padding: 15px;
            }
            
            .form-card {
                padding: 20px;
            }
            
            .title {
                font-size: 24px;
            }
            
            .history-header {
                flex-direction: column;
                gap: 10px;
            }
        }
        
        /* 加载动画 */
        .loading {
            display: inline-block;
            width: 20px;
            height: 20px;
            border: 2px solid #f3f3f3;
            border-top: 2px solid #764ba2;
            border-radius: 50%;
            animation: spin 1s linear infinite;
            margin-right: 8px;
        }
        
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
        
        /* 成功提示 */
        .success-message {
            background: #4CAF50;
            color: white;
            padding: 15px;
            border-radius: 8px;
            margin-bottom: 20px;
            text-align: center;
            display: none;
        }
        
        .success-message.show {
            display: block;
            animation: fadeIn 0.5s ease;
        }
        
        @keyframes fadeIn {
            from { opacity: 0; }
            to { opacity: 1; }
        }
    </style>
    <script src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        // 初始化页面
        $(document).ready(function () {
            // 设置提交日期为今天
            var today = new Date();
            var formattedDate = today.getFullYear() + '-' + 
                               String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                               String(today.getDate()).padStart(2, '0');
            $('#tijiaoriqi').val(formattedDate);
            
            // 设置默认审批结果
            $('#shenpijieguo').val('待审批');
            
            // 更新字数统计
            updateWordCount();
            loadDepartments();
        });

        // 加载部门数据
        function loadDepartments() {
            $.ajax({
                url: 'lizhishenqing.aspx',
                type: 'POST',
                data: { action: 'getdepartments' },
                success: function(response) {
                    try {
                        var result = typeof response === 'string' ? JSON.parse(response) : response;
                        if (result.success && result.data && result.data.length > 0) {
                            var $bumenSelect = $('#bumen');
                            if ($bumenSelect.length === 0) {
                                // 如果select不存在，创建它
                                var $bumenInput = $('input[placeholder*="部门"]').first();
                                if ($bumenInput.length > 0) {
                                    var $select = $('<select id="bumen" class="input" onchange="onInputChange(\'bumen\')"></select>');
                                    $select.append('<option value="">请选择部门</option>');
                                    $.each(result.data, function(index, dept) {
                                        $select.append('<option value="' + escapeHtml(dept) + '">' + escapeHtml(dept) + '</option>');
                                    });
                                    $bumenInput.replaceWith($select);
                                }
                            } else {
                                // 清空现有选项（保留第一个选项）
                                $bumenSelect.find('option:not(:first)').remove();
                                // 添加部门选项
                                $.each(result.data, function(index, dept) {
                                    $bumenSelect.append('<option value="' + escapeHtml(dept) + '">' + escapeHtml(dept) + '</option>');
                                });
                            }
                        }
                    } catch (e) {
                        console.error('加载部门数据失败:', e);
                    }
                },
                error: function() {
                    console.error('加载部门数据请求失败');
                }
            });
        }
        
        // 更新字数统计
        function updateWordCount() {
            var text = $('#shenqingyuanyin').val();
            var count = text ? text.length : 0;
            $('#wordCount').text(count + '/500');
        }
        
        // 输入框变化处理
        function onInputChange(field) {
            var value = $('#' + field).val();
            
            // 更新字数统计（如果是申请原因字段）
            if (field === 'shenqingyuanyin') {
                updateWordCount();
            }
            
            // 清除错误信息
            $('#' + field + 'Error').removeClass('show');
            
            return value;
        }
        
        // 表单验证
        function validateForm() {
            var isValid = true;
            
            // 验证部门
            var bumen = onInputChange('bumen');
            if (!bumen || bumen.trim() === '') {
                $('#bumenError').text('请输入部门名称').addClass('show');
                isValid = false;
            } else if (bumen.trim().length < 2) {
                $('#bumenError').text('部门名称至少2个字符').addClass('show');
                isValid = false;
            }
            
            // 验证姓名
            var xingming = onInputChange('xingming');
            if (!xingming || xingming.trim() === '') {
                $('#xingmingError').text('请输入姓名').addClass('show');
                isValid = false;
            } else if (xingming.trim().length < 2) {
                $('#xingmingError').text('姓名至少2个字符').addClass('show');
                isValid = false;
            }
            
            // 验证申请原因
            var shenqingyuanyin = onInputChange('shenqingyuanyin');
            if (!shenqingyuanyin || shenqingyuanyin.trim() === '') {
                $('#shenqingyuanyinError').text('请输入申请原因').addClass('show');
                isValid = false;
            }
            
            return isValid;
        }
        
        // 提交表单
        function submitForm() {
            // 验证表单
            if (!validateForm()) {
                showAlert('请完善表单信息');
                return;
            }
            
            // 防止重复提交
            if ($('#submitBtn').prop('disabled')) {
                return;
            }
            
            // 禁用提交按钮
            $('#submitBtn').prop('disabled', true).html('<span class="loading"></span>提交中...');
            
            // 获取表单数据
            var formData = {
                action: 'submit',
                bumen: $('#bumen').val().trim(),
                xingming: $('#xingming').val().trim(),
                tijiaoriqi: $('#tijiaoriqi').val(),
                shenqingyuanyin: $('#shenqingyuanyin').val().trim(),
                shenpijieguo: $('#shenpijieguo').val(),
                shenpiyuanyin: $('#shenpiyuanyin').val().trim()
            };
            
            // 使用AJAX提交
            $.ajax({
                url: 'lizhishenqing.aspx',
                type: 'POST',
                data: formData,
                success: function (response) {
                    console.log(response.success)
                    console.log(response.message)
                    if (response.success) {
                        // 显示成功消息
                        showAlert(response.message);
                            
                        window.location.href = 'lizhishenqing.aspx';
                    } else {
                        showAlert(response.message);
                    }
                },
                error: function () {
                    showAlert('网络错误，请稍后重试');
                    $('#submitBtn').prop('disabled', false).text('提交申请');
                }
            });
        }

        
        // 重置表单
        function resetForm() {
            if (!confirm('确定要重置表单吗？所有填写的内容将被清空。')) {
                return;
            }
            
            // 清空表单数据
            $('#bumen').val('');
            $('#xingming').val('');
            $('#shenqingyuanyin').val('');
            $('#shenpiyuanyin').val('');
            
            // 重置日期和默认值
            var today = new Date();
            var formattedDate = today.getFullYear() + '-' + 
                               String(today.getMonth() + 1).padStart(2, '0') + '-' + 
                               String(today.getDate()).padStart(2, '0');
            $('#tijiaoriqi').val(formattedDate);
            $('#shenpijieguo').val('待审批');
            
            // 清除错误信息
            $('.error-message').removeClass('show');
            
            // 更新字数统计
            updateWordCount();
            
            showAlert('表单已重置', 'success');
        }
        
        // 显示/隐藏历史记录
        var showHistory = false;
        function toggleHistory() {
            showHistory = !showHistory;
            var $historySection = $('#historySection');
            var $historyBtn = $('#historyBtn');
            
            if (showHistory) {
                // 验证部门和姓名是否填写
                var bumen = $('#bumen').val().trim();
                var xingming = $('#xingming').val().trim();
                
                if (!bumen || !xingming) {
                    showAlert('请先填写部门和姓名');
                    showHistory = false;
                    return;
                }
                
                $historySection.slideDown();
                $historyBtn.text('隐藏历史记录');
                
                // 如果历史记录为空，加载数据
                if ($('#historyList').children().length === 0) {
                    loadHistoryData(1);
                }
            } else {
                $historySection.slideUp();
                $historyBtn.text('查看历史记录');
            }
        }
        
        // 加载历史记录数据
        var currentPage = 1;
        var loadingHistory = false;
        var hasMore = true;
        
        function loadHistoryData(page) {
            if (loadingHistory || !hasMore) return;
            
            loadingHistory = true;
            $('#loadMore').text('加载中...');
            
            var formData = {
                action: 'gethistory',
                bumen: $('#bumen').val().trim(),
                xingming: $('#xingming').val().trim(),
                page: page,
                pageSize: 10
            };
            
            $.ajax({
                url: 'lizhishenqing.aspx',
                type: 'POST',
                data: formData,
                success: function (result) {
                    try {
                        if (result.success) {
                            // 渲染历史记录
                            renderHistoryList(result.data, page === 1);
                            currentPage = page;
                            hasMore = result.hasMore;
                            
                            // 更新记录数量
                            $('#historyCount').text('共' + (page === 1 ? result.data.length : 
                                parseInt($('#historyCount').text().replace('共', '').replace('条记录', '')) + result.data.length) + '条记录');
                        }
                    } catch (e) {
                        console.error('解析历史记录失败:', e);
                    }
                    loadingHistory = false;
                    $('#loadMore').text(hasMore ? '点击加载更多' : '没有更多记录了');
                },
                error: function () {
                    loadingHistory = false;
                    $('#loadMore').text('加载失败，点击重试');
                }
            });
        }
        
        // 渲染历史记录列表
        function renderHistoryList(data, clear) {
            var $historyList = $('#historyList');
            
            if (clear) {
                $historyList.empty();
            }
            
            if (data.length === 0 && clear) {
                $historyList.html('<div class="no-data">暂无申请记录</div>');
                return;
            }
            
            data.forEach(function(item, index) {
                var statusClass = '';
                switch(item.shenpijieguo) {
                    case '通过': statusClass = 'status-tongguo'; break;
                    case '驳回': statusClass = 'status-bohui'; break;
                    case '待审批': statusClass = 'status-daishanpi'; break;
                }
                
                var reasonShort = item.shenqingyuanyin ? 
                    (item.shenqingyuanyin.length > 30 ? 
                     item.shenqingyuanyin.substring(0, 30) + '...' : 
                     item.shenqingyuanyin) : '';
                
                var historyItem = `
                    <div class="history-item">
                        <div class="item-header">
                            <span class="item-name">${escapeHtml(item.xingming)}</span>
                            <span class="item-department">${escapeHtml(item.bumen)}</span>
                            <span class="item-status ${statusClass}">${escapeHtml(item.shenpijieguo)}</span>
                        </div>
                        <div class="item-content">
                            <span class="item-date">${escapeHtml(item.tijiaoriqi)}</span>
                            <span class="item-reason">${escapeHtml(reasonShort)}</span>
                        </div>
                        <div class="item-arrow">驳回原因：${escapeHtml(item.shenpiyuanyin)}</div>
                    </div>
                `;
                
                $historyList.append(historyItem);
            });
        }
        
        // 加载更多历史记录
        function loadMoreHistory() {
            if (hasMore) {
                loadHistoryData(currentPage + 1);
            }
        }
        
        // 工具函数：HTML转义
        function escapeHtml(text) {
            var map = {
                '&': '&amp;',
                '<': '&lt;',
                '>': '&gt;',
                '"': '&quot;',
                "'": '&#039;'
            };
            return text.replace(/[&<>"']/g, function(m) { return map[m]; });
        }
        
        // 显示提示消息
        function showAlert(message, type) {
            var alertClass = type === 'success' ? 'success-message' : '';
            alert(message); // 简单使用alert，可以替换为更美观的提示框
        }
        
        // 显示成功消息
        function showSuccessMessage(message) {
            $('#successMessage').text(message).addClass('show');
        }
    </script>
</head>
<body>
    <div class="container">
        <!-- 成功提示 -->
        <div id="successMessage" class="success-message"></div>
        
        <!-- 标题 -->
        <div class="header">
            <span class="title">离职申请表</span>
            <span class="subtitle">请填写以下信息提交离职申请</span>
        </div>
        
        <!-- 申请表单 -->
        <div class="form-card">
            <!-- 部门 -->
            <%--<div class="form-item">
                <span class="label">部门</span>
                <div class="input-container">
                    <input id="bumen" type="text" placeholder="请输入部门名称" 
                           oninput="onInputChange('bumen')" 
                           class="input" />
                </div>
                <div id="bumenError" class="error-message"></div>
            </div>--%>
            <div class="form-item">
                <span class="label">部门</span>
                <div class="input-container">
                    <!-- 将原来的input改为select，并添加id和class -->
                    <select id="bumen" class="input" onchange="onInputChange('bumen')">
                        <option value="">请选择部门</option>
                        <!-- 部门选项将通过JavaScript动态加载 -->
                    </select>
                </div>
                <div id="bumenError" class="error-message"></div>
            </div>
            
            <!-- 姓名 -->
            <div class="form-item">
                <span class="label">姓名</span>
                <div class="input-container">
                    <input id="xingming" type="text" placeholder="请输入姓名" 
                           oninput="onInputChange('xingming')" 
                           class="input" />
                </div>
                <div id="xingmingError" class="error-message"></div>
            </div>
            
            <!-- 提交日期（只读） -->
            <div class="form-item">
                <span class="label readonly">提交日期</span>
                <div class="input-container readonly">
                    <input id="tijiaoriqi" type="text" disabled class="input" />
                    <span class="hint">系统自动生成</span>
                </div>
            </div>
            
            <!-- 申请原因 -->
            <div class="form-item">
                <span class="label">申请原因</span>
                <div class="textarea-container">
                    <textarea id="shenqingyuanyin" placeholder="请详细说明离职原因..." 
                              oninput="onInputChange('shenqingyuanyin')" 
                              class="textarea" maxlength="500"></textarea>
                    <div class="word-count">
                        <span id="wordCount">0/500</span>
                    </div>
                </div>
                <div id="shenqingyuanyinError" class="error-message"></div>
            </div>
            
            <!-- 审批结果（只读，默认为"待审批"） -->
            <div class="form-item">
                <span class="label readonly">审批结果</span>
                <div class="input-container readonly">
                    <input id="shenpijieguo" type="text" disabled class="input" />
                    <span class="hint">提交后由领导审批</span>
                </div>
            </div>
            
            <!-- 审批原因（只读） -->
            <div class="form-item">
                <span class="label readonly">审批原因</span>
                <div class="textarea-container readonly">
                    <textarea id="shenpiyuanyin" placeholder="审批通过后由领导填写" disabled class="textarea"></textarea>
                </div>
            </div>
        </div>
        
        <!-- 提交按钮 -->
        <div class="button-container">
            <button id="submitBtn" onclick="submitForm()" class="submit-btn">
                提交申请
            </button>
            
            <button onclick="resetForm()" class="reset-btn">
                重置表单
            </button>
        </div>
        
        <!-- 查看历史记录按钮 -->
        <div class="button-container">
            <button id="historyBtn" onclick="toggleHistory()" class="history-btn">
                查看历史记录
            </button>
        </div>
        
        <!-- 历史记录查看 -->
        <div id="historySection" class="history-section" style="display: none;">
            <div class="history-header">
                <div>
                    <span class="history-title">历史申请记录</span>
                    <div class="filter-info">
                        <span id="filterBumen" class="filter-item"></span>
                        <span id="filterXingming" class="filter-item"></span>
                    </div>
                </div>
                <span id="historyCount" class="history-count">共0条记录</span>
            </div>
            
            <div id="historyList" class="history-list">
                <!-- 历史记录将在这里动态加载 -->
            </div>
            
            <!-- 加载更多 -->
            <div id="loadMore" class="load-more" onclick="loadMoreHistory()">
                <span>点击加载更多</span>
            </div>
        </div>
        
        <!-- 填写提示 -->
        <div class="tips-card">
            <span class="tips-title">填写说明：</span>
            <div class="tips-content">
                <span>1. 请务必如实填写所有必填信息</span>
                <span>2. 提交日期由系统自动生成，不可修改</span>
                <span>3. 提交后请等待上级领导审批</span>
                <span>4. 审批结果和审批原因将由领导填写</span>
                <span>5. 如有疑问，请联系人力资源部门</span>
            </div>
        </div>
    </div>
</body>
</html>