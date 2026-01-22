<%@ page language="C#" autoeventwireup="true" codebehind="qiandao.aspx.cs" inherits="Web.Personnel.qiandao" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>考勤打卡</title>
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
        
        /* 标题样式 */
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
        
        /* 主容器 */
        .main-container {
            background: white;
            border-radius: 0 0 12px 12px;
            padding: 20px;
            margin-bottom: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
        }
        
        /* 用户信息输入 */
        .input-section {
            margin-bottom: 20px;
            padding: 15px;
            background: #f9f9f9;
            border-radius: 8px;
        }
        
        .form-group {
            margin-bottom: 15px;
        }
        
        .form-label {
            display: block;
            margin-bottom: 5px;
            font-weight: 600;
            color: #333;
        }
        
        .form-input {
            width: 100%;
            padding: 10px 15px;
            border: 1px solid #d9d9d9;
            border-radius: 6px;
            font-size: 14px;
            transition: all 0.3s;
        }
        
        .form-input:focus {
            border-color: #1890ff;
            box-shadow: 0 0 0 2px rgba(24, 144, 255, 0.1);
            outline: none;
        }
        
        .btn-save-userinfo {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            width: 100%;
        }
        
        .btn-save-userinfo:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 当前时间显示 */
        .time-display {
            text-align: center;
            margin: 20px 0;
            padding: 20px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            border-radius: 12px;
            color: white;
            box-shadow: 0 4px 12px rgba(102, 126, 234, 0.3);
        }
        
        .current-date {
            display: block;
            font-size: 18px;
            font-weight: 600;
            margin-bottom: 5px;
        }
        
        .current-time {
            display: block;
            font-size: 36px;
            font-weight: 700;
            font-family: 'Courier New', monospace;
        }
        
        /* 打卡操作区域 */
        .punch-section {
            margin: 20px 0;
        }
        
        .punch-buttons {
            display: flex;
            gap: 15px;
            margin-bottom: 15px;
        }
        
        .btn-punch {
            flex: 1;
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 20px 15px;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            font-weight: 600;
            font-size: 16px;
            transition: all 0.3s;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        
        .btn-punch:first-child {
            background: linear-gradient(to bottom, #52c41a, #389e0d);
            color: white;
        }
        
        .btn-punch:last-child {
            background: linear-gradient(to bottom, #fa541c, #d4380d);
            color: white;
        }
        
        .btn-punch.disabled {
            background: #d9d9d9 !important;
            color: #8c8c8c !important;
            cursor: not-allowed;
            opacity: 0.7;
        }
        
        .btn-punch:not(.disabled):hover {
            transform: translateY(-3px);
            box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
        }
        
        .punch-icon {
            font-size: 24px;
            margin-bottom: 5px;
        }
        
        .punch-time {
            margin-top: 5px;
            font-size: 12px;
            opacity: 0.9;
        }
        
        .today-status {
            text-align: center;
            font-size: 16px;
            font-weight: 600;
            padding: 10px;
            border-radius: 6px;
            margin-top: 10px;
        }
        
        .today-status.red {
            background: #fff2f0;
            border: 1px solid #ffccc7;
            color: #ff4d4f;
        }
        
        .today-status.green {
            background: #f6ffed;
            border: 1px solid #b7eb8f;
            color: #52c41a;
        }
        
        .today-status.orange {
            background: #fff7e6;
            border: 1px solid #ffd591;
            color: #fa8c16;
        }
        
        .today-status.blue {
            background: #e6f7ff;
            border: 1px solid #91d5ff;
            color: #1890ff;
        }
        
        .today-status.gray {
            background: #fafafa;
            border: 1px solid #d9d9d9;
            color: #8c8c8c;
        }
        
        /* 工作安排信息 */
        .schedule-info {
            background: #f9f9f9;
            border-radius: 8px;
            padding: 15px;
            margin: 20px 0;
        }
        
        .section-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 15px;
            padding-bottom: 10px;
            border-bottom: 2px solid #1890ff;
        }
        
        .section-title {
            font-size: 16px;
            font-weight: 600;
            color: #333;
        }
        
        .schedule-detail {
            background: white;
            border-radius: 6px;
            padding: 15px;
        }
        
        .schedule-row {
            display: flex;
            margin-bottom: 8px;
        }
        
        .schedule-label {
            width: 100px;
            font-weight: 600;
            color: #666;
        }
        
        .schedule-value {
            flex: 1;
            color: #333;
        }
        
        /* 打卡记录 */
        .records-section {
            background: #f9f9f9;
            border-radius: 8px;
            padding: 15px;
            margin: 20px 0;
        }
        
        .refresh-btn {
            color: #1890ff;
            cursor: pointer;
            font-size: 14px;
        }
        
        .refresh-btn:hover {
            text-decoration: underline;
        }
        
        .records-list {
            background: white;
            border-radius: 6px;
            padding: 10px;
            max-height: 200px;
            overflow-y: auto;
        }
        
        .record-item {
            display: flex;
            align-items: center;
            padding: 10px;
            border-bottom: 1px solid #f0f0f0;
        }
        
        .record-item:last-child {
            border-bottom: none;
        }
        
        .record-type {
            width: 60px;
            font-weight: 600;
            padding: 3px 8px;
            border-radius: 4px;
            font-size: 12px;
            text-align: center;
        }
        
        .record-type.sign-in {
            background: #f6ffed;
            color: #52c41a;
        }
        
        .record-type.sign-out {
            background: #fff2f0;
            color: #ff4d4f;
        }
        
        .record-time {
            flex: 1;
            margin: 0 10px;
            font-weight: 500;
        }
        
        .record-status {
            width: 50px;
            font-size: 12px;
            text-align: center;
            padding: 2px 6px;
            border-radius: 3px;
        }
        
        .record-status.valid {
            background: #f6ffed;
            color: #52c41a;
        }
        
        .record-status.invalid {
            background: #fff2f0;
            color: #ff4d4f;
        }
        
        .record-message {
            flex: 2;
            font-size: 12px;
            color: #666;
            text-align: right;
        }
        
        .empty-records {
            text-align: center;
            padding: 20px;
            color: #999;
        }
        
        /* 请假申请模块 */
        .leave-section {
            background: #f9f9f9;
            border-radius: 8px;
            padding: 15px;
            margin: 20px 0;
        }
        
        .btn-leave-apply {
            background: #1890ff;
            color: white;
            border: none;
            padding: 4px 12px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 12px;
            transition: all 0.3s;
        }
        
        .btn-leave-apply:hover {
            background: #096dd9;
        }
        
        .leave-result-toast {
            background: #e6f7ff;
            border: 1px solid #91d5ff;
            border-radius: 6px;
            padding: 10px;
            margin-bottom: 15px;
            color: #1890ff;
            font-size: 14px;
        }
        
        .leave-records {
            background: white;
            border-radius: 6px;
            padding: 10px;
        }
        
        .leave-records-header {
            display: flex;
            padding: 8px 0;
            border-bottom: 2px solid #f0f0f0;
            font-weight: 600;
            color: #333;
        }
        
        .leave-records-list {
            max-height: 200px;
            overflow-y: auto;
        }
        
        .leave-record-item {
            display: flex;
            padding: 8px 0;
            border-bottom: 1px solid #f9f9f9;
        }
        
        .leave-record-item:hover {
            background: #fafafa;
        }
        
        .leave-record-header-cell,
        .leave-record-cell {
            padding: 0 5px;
        }
        
        .leave-record-cell {
            font-size: 12px;
        }
        
        .empty-leave-records {
            text-align: center;
            padding: 20px;
            color: #999;
        }
        
        /* 模态框样式 */
        .modal-overlay {
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background: rgba(0, 0, 0, 0.5);
            display: flex;
            align-items: center;
            justify-content: center;
            z-index: 1000;
        }
        
        .modal-container {
            background: white;
            border-radius: 12px;
            width: 90%;
            max-width: 500px;
            max-height: 80vh;
            overflow-y: auto;
            box-shadow: 0 8px 24px rgba(0, 0, 0, 0.2);
        }
        
        .modal-header {
            padding: 15px 20px;
            border-bottom: 1px solid #e8e8e8;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        
        .modal-title {
            font-size: 18px;
            font-weight: 600;
            color: #333;
        }
        
        .modal-close {
            font-size: 24px;
            color: #999;
            cursor: pointer;
            width: 32px;
            height: 32px;
            display: flex;
            align-items: center;
            justify-content: center;
            border-radius: 50%;
            transition: all 0.3s;
        }
        
        .modal-close:hover {
            background: #f0f0f0;
            color: #333;
        }
        
        .modal-content {
            padding: 20px;
        }
        
        .picker-input {
            padding: 10px 15px;
            border: 1px solid #d9d9d9;
            border-radius: 6px;
            background: #f9f9f9;
            cursor: pointer;
        }
        
        .textarea-input {
            width: 100%;
            padding: 10px 15px;
            border: 1px solid #d9d9d9;
            border-radius: 6px;
            font-size: 14px;
            resize: vertical;
            min-height: 80px;
        }
        
        .info-display {
            background: #f9f9f9;
            border-radius: 6px;
            padding: 10px;
        }
        
        .info-display text {
            display: block;
            margin-bottom: 5px;
            color: #666;
        }
        
        .modal-footer {
            padding: 15px 20px;
            border-top: 1px solid #e8e8e8;
            display: flex;
            justify-content: flex-end;
            gap: 10px;
        }
        
        .btn-modal {
            padding: 8px 16px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
        }
        
        .btn-modal-cancel {
            background: #f0f0f0;
            color: #333;
        }
        
        .btn-modal-cancel:hover {
            background: #d9d9d9;
        }
        
        .btn-modal-submit {
            background: #1890ff;
            color: white;
        }
        
        .btn-modal-submit:hover {
            background: #096dd9;
        }
        
        .btn-modal-submit[disabled] {
            background: #d9d9d9;
            cursor: not-allowed;
        }
        
        /* 消息提示 */
        .message-toast {
            position: fixed;
            top: 20px;
            left: 50%;
            transform: translateX(-50%);
            padding: 12px 24px;
            border-radius: 6px;
            color: white;
            font-weight: 600;
            z-index: 2000;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
            animation: slideDown 0.3s ease;
        }
        
        @keyframes slideDown {
            from {
                transform: translate(-50%, -20px);
                opacity: 0;
            }
            to {
                transform: translate(-50%, 0);
                opacity: 1;
            }
        }
        
        .message-toast.success {
            background: #52c41a;
        }
        
        .message-toast.error {
            background: #ff4d4f;
        }
        
        .message-toast.info {
            background: #1890ff;
        }
        
        .message-toast.warning {
            background: #fa8c16;
        }
        
        /* 统计信息 */
        .stats-section {
            background: #f9f9f9;
            border-radius: 8px;
            padding: 15px;
            margin: 20px 0;
        }
        
        .stats-grid {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 10px;
        }
        
        .stat-item {
            background: white;
            border-radius: 6px;
            padding: 15px;
            text-align: center;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.05);
        }
        
        .stat-number {
            display: block;
            font-size: 24px;
            font-weight: 700;
            color: #1890ff;
            margin-bottom: 5px;
        }
        
        .stat-label {
            font-size: 12px;
            color: #666;
        }
        
        /* 调试按钮区域 */
        .debug-section {
            margin: 20px 0;
        }
        
        .debug-buttons {
            display: flex;
            justify-content: center;
            gap: 10px;
        }
        
        .btn-debug {
            background: #722ed1;
            color: white;
            border: none;
            padding: 6px 12px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 12px;
            transition: all 0.3s;
        }
        
        .btn-debug:hover {
            background: #531dab;
        }
        
        /* 响应式设计 */
        @media (max-width: 768px) {
            .punch-buttons {
                flex-direction: column;
            }
            
            .stats-grid {
                grid-template-columns: repeat(2, 1fr);
            }
        }
        
        @media (max-width: 480px) {
            .stats-grid {
                grid-template-columns: 1fr;
            }
            
            .leave-records-header,
            .leave-record-item {
                font-size: 11px;
            }
        }
    </style>
    <script src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        // 全局变量
        var currentDate = '';
        var currentTime = '';
        var currentYear = '';
        var currentMonth = '';
        var currentDay = '';

        var department = '';
        var userName = '';
        var userId = '';
        var companyName = '';

        var signInDisabled = false;
        var signOutDisabled = true;
        var signInTime = '';
        var signOutTime = '';
        var todayStatus = { text: '未签到', color: 'red' };

        var workSchedule = null;
        var todayRecords = [];
        var myLeaveRecords = [];

        // 字段映射（日期1-31对应数据库字段E-AI）
        var dayFieldMap = {
            1: 'E', 2: 'F', 3: 'G', 4: 'H', 5: 'I', 6: 'J', 7: 'K', 8: 'L', 9: 'M', 10: 'N',
            11: 'O', 12: 'P', 13: 'Q', 14: 'R', 15: 'S', 16: 'T', 17: 'U', 18: 'V', 19: 'W', 20: 'X',
            21: 'Y', 22: 'Z', 23: 'AA', 24: 'AB', 25: 'AC', 26: 'AD', 27: 'AE', 28: 'AF', 29: 'AG', 30: 'AH', 31: 'AI'
        };

        // 页面加载
        $(document).ready(function () {
            // 获取公司名称
            companyName = '<%= Session["gongsi"] != null ? Session["gongsi"].ToString() : "" %>';
            if (!companyName) {
                showMessage('请先登录！', 'error');
                setTimeout(function () {
                    window.location.href = '/Myadmin/Login.aspx';
                }, 2000);
                return;
            }

            // 初始化时间
            updateTime();
            setInterval(updateTime, 1000);

            // 加载部门数据
            loadDepartments();

            // 加载用户信息
            setTimeout(function () {
                loadUserInfo();
            }, 500);

            // 加载工作安排
            loadWorkSchedule();

            // 加载今日记录
            loadTodayRecords();

            // 加载请假记录
            loadMyLeaveRecords();
        });


        // 新增：加载部门数据
        function loadDepartments() {
            console.log('开始加载部门数据...');

            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: { action: 'getdepartments' },
                success: function (response) {
                    console.log('部门数据响应:', response);
                    console.log('响应类型:', typeof response);

                    try {
                        // 确保response是对象
                        var result = response;
                        if (typeof response === 'string') {
                            try {
                                result = JSON.parse(response);
                            } catch (e) {
                                console.error('JSON解析失败:', e);
                                return;
                            }
                        }

                        console.log('解析后的结果:', result);
                        console.log('success:', result.success);
                        console.log('data:', result.data);

                        if (result.success && result.data && result.data.length > 0) {
                            console.log('找到部门数据，数量:', result.data.length);

                            var $departmentSelect = $('#department');
                            console.log('找到的select元素:', $departmentSelect.length);

                            if ($departmentSelect.length > 0) {
                                // 清空现有选项（保留第一个选项）
                                $departmentSelect.find('option:not(:first)').remove();
                                console.log('清空现有选项完成');

                                // 添加部门选项
                                $.each(result.data, function (index, dept) {
                                    console.log('添加部门:', index, dept);
                                    $departmentSelect.append('<option value="' + dept + '">' + dept + '</option>');
                                });

                                // 如果有保存的部门值，设置选中状态
                                var savedDept = getCookie('qiandao_department');
                                console.log('从cookie获取保存的部门:', savedDept);
                                if (savedDept) {
                                    $departmentSelect.val(savedDept);
                                    console.log('设置选中值:', savedDept);
                                    // 更新全局变量
                                    department = savedDept;
                                }

                                console.log('部门下拉框最终选项数量:', $departmentSelect.find('option').length);
                            } else {
                                console.error('没有找到id为department的select元素');
                                // 尝试查找其他可能的元素
                                var $formInputs = $('.form-input');
                                console.log('所有form-input元素:', $formInputs.length);

                                // 如果是input元素，需要替换为select
                                var $departmentInput = $('#department');
                                if ($departmentInput.length === 0) {
                                    // 尝试通过placeholder查找
                                    $departmentInput = $('input[placeholder*="部门"]').first();
                                }

                                if ($departmentInput.length > 0 && $departmentInput.is('input')) {
                                    console.log('找到部门input元素，准备替换为select');
                                    var $select = $('<select id="department" class="form-input"></select>');
                                    $select.append('<option value="">请选择部门</option>');
                                    $.each(result.data, function (index, dept) {
                                        $select.append('<option value="' + dept + '">' + dept + '</option>');
                                    });

                                    // 替换input为select
                                    $departmentInput.replaceWith($select);
                                    console.log('替换完成');

                                    // 更新引用
                                    $departmentSelect = $('#department');

                                    // 如果有保存的部门值，设置选中状态
                                    var savedDept = getCookie('qiandao_department');
                                    if (savedDept) {
                                        $departmentSelect.val(savedDept);
                                        department = savedDept;
                                    }
                                }
                            }
                        } else {
                            console.log('没有获取到有效的部门数据');
                            console.log('success:', result.success);
                            console.log('data exists:', !!result.data);
                            console.log('data length:', result.data ? result.data.length : 0);
                        }
                    } catch (e) {
                        console.error('加载部门数据失败:', e);
                    }
                },
                error: function (xhr, status, error) {
                    console.error('加载部门数据请求失败:', status, error);
                    console.log('XHR响应:', xhr.responseText);
                }
            });
        }

        // 更新时间显示
        function updateTime() {
            var now = new Date();
            currentYear = now.getFullYear();
            currentMonth = (now.getMonth() + 1).toString().padStart(2, '0');
            currentDay = now.getDate();
            currentDate = currentYear + '年' + currentMonth + '月' + currentDay + '日';
            currentTime = now.getHours().toString().padStart(2, '0') + ':' +
                         now.getMinutes().toString().padStart(2, '0') + ':' +
                         now.getSeconds().toString().padStart(2, '0');

            $('#currentDate').text(currentDate);
            $('#currentTime').text(currentTime);
        }

        // 加载用户信息
        function loadUserInfo() {
            // 从cookie中获取用户信息
            department = getCookie('qiandao_department') || '';
            userName = getCookie('qiandao_userName') || '';
            userId = getCookie('qiandao_userId') || '';

            $('#department').val(department);
            $('#userName').val(userName);

            if (department && userName) {
                updatePunchButtons();
            }
        }

        // 保存用户信息
        function saveUserInfo() {
            department = $('#department').val().trim();
            userName = $('#userName').val().trim();

            if (!department || !userName) {
                showMessage('请填写完整的部门和个人信息', 'error');
                return;
            }

            // 生成用户ID
            userId = generateUserId(department, userName);

            // 保存到cookie（30天有效）
            setCookie('qiandao_department', department, 30);
            setCookie('qiandao_userName', userName, 30);
            setCookie('qiandao_userId', userId, 30);

            showMessage('个人信息保存成功', 'success');

            // 重新加载工作安排
            loadWorkSchedule();
            checkTodayAttendance();
        }

        // 生成用户ID
        function generateUserId(department, userName) {
            var timestamp = Date.now().toString(36);
            var randomStr = Math.random().toString(36).substr(2, 4);
            return department + '_' + userName + '_' + timestamp + '_' + randomStr;
        }

        // 检查今日考勤记录
        function checkTodayAttendance() {
            if (!userName) return;

            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: {
                    action: 'checktodayattendance',
                    userName: userName,
                    year: currentYear,
                    month: currentMonth,
                    day: currentDay,
                    companyName: companyName
                },
                success: function (data) {
                    try {
                        if (data.success) {
                            var todayStatus = data.data.todayStatus || '';

                            if (todayStatus === '休') {
                                // 休息日，禁用打卡按钮
                                signInDisabled = true;
                                signOutDisabled = true;
                                signInTime = '休息日';
                                signOutTime = '休息日';
                                updateTodayStatus('休息日', 'blue');
                                showMessage('今天是休息日，无需打卡', 'info');
                            } else if (todayStatus === '早签' || todayStatus === '迟到') {
                                // 已签到
                                signInTime = '已签到';
                                signInDisabled = true;
                                signOutDisabled = false;
                            } else if (todayStatus === '出勤' || todayStatus === '早退' || todayStatus === '旷勤') {
                                // 已签退
                                signInTime = '已签到';
                                signOutTime = '已签退';
                                signInDisabled = true;
                                signOutDisabled = true;
                            } else {
                                // 没有记录
                                if (!workSchedule) {
                                    signInDisabled = true;
                                    updateTodayStatus('无工作安排', 'gray');
                                } else {
                                    signInDisabled = false;
                                    signOutDisabled = true;
                                }
                            }

                            updatePunchButtons();
                        }
                    } catch (e) {
                        console.log('检查考勤记录失败:', e);
                    }
                }
            });
        }

        // 签到功能
        function signIn() {
            console.log('开始签到...');

            // 检查用户信息
            if (!checkUserInfo()) {
                return;
            }

            // 检查今日是否有工作安排
            if (!workSchedule) {
                showMessage('今日无工作安排，无需打卡', 'error');
                return;
            }

            // 检查是否已经签到
            if (signInTime && signInTime !== '') {
                showMessage('今日已签到，不能重复签到', 'error');
                return;
            }

            // 获取当前时间
            var now = new Date();
            var currentTimeStr = formatTime(now);
            var currentDateTime = now;

            console.log('当前时间:', currentTimeStr);

            // 获取工作时间配置
            var workStartTime = parseTimeString(workSchedule.gongzuoshijianks);

            // 判断签到状态
            var isNormal = true;
            var statusText = '早签';
            var message = '签到成功';

            // 判断是否迟到
            if (currentDateTime > workStartTime) {
                var minutesLate = Math.floor((currentDateTime - workStartTime) / (1000 * 60));
                console.log('迟到时间:', minutesLate + '分钟');

                if (minutesLate > 5 && minutesLate <= 30) {
                    // 迟到5-30分钟
                    isNormal = false;
                    statusText = '迟到';
                    message = '迟到' + minutesLate + '分钟';
                } else if (minutesLate > 30) {
                    // 迟到超过30分钟，视为旷勤
                    isNormal = false;
                    statusText = '旷勤';
                    message = '旷勤（迟到' + minutesLate + '分钟）';
                } else {
                    message = '正常签到（迟到' + minutesLate + '分钟）';
                }
            }

            // 保存签到记录
            saveAttendanceToDB('signIn', statusText, currentTimeStr, isNormal, message);
        }

        // 签退功能
        function signOut() {
            console.log('开始签退...');

            // 检查用户信息
            if (!checkUserInfo()) {
                return;
            }

            // 检查是否已签到
            if (!signInTime || signInTime === '') {
                showMessage('请先进行签到', 'error');
                return;
            }

            // 检查是否已签退
            if (signOutTime && signOutTime !== '') {
                showMessage('今日已签退，不能重复签退', 'error');
                return;
            }

            var now = new Date();
            var currentTimeStr = formatTime(now);
            var currentDateTime = now;

            console.log('当前时间:', currentTimeStr);

            // 获取工作时间配置
            var workEndTime = parseTimeString(workSchedule.gongzuoshijianjs);

            // 获取今日考勤状态
            getTodayAttendanceStatus(function (attendanceStatus) {
                console.log('当前考勤状态:', attendanceStatus);

                // 如果签到状态已经是旷勤，签退不做任何修改
                if (attendanceStatus === '旷勤') {
                    showMessage('签到状态为旷勤，签退不做更新', 'info');
                    signOutTime = currentTimeStr;
                    signOutDisabled = true;
                    updateLocalState('signOut', currentTimeStr, '旷勤（不变）', false, '签退不做更新（签到已旷勤）');
                    return;
                }

                var statusText = '出勤';
                var isNormal = true;
                var message = '签退成功';

                // 判断签退时间
                if (currentDateTime < workEndTime) {
                    var minutesEarly = Math.floor((workEndTime - currentDateTime) / (1000 * 60));
                    console.log('提前时间:', minutesEarly + '分钟');

                    if (minutesEarly > 5 && minutesEarly <= 30) {
                        // 早退5-30分钟
                        isNormal = false;

                        if (attendanceStatus === '早签') {
                            statusText = '早退';
                            message = '早退' + minutesEarly + '分钟';
                        } else if (attendanceStatus === '迟到') {
                            statusText = attendanceStatus;
                            message = '早退' + minutesEarly + '分钟（保持迟到状态）';
                        }
                    } else if (minutesEarly > 30) {
                        // 早退超过30分钟
                        isNormal = false;
                        statusText = '旷勤';
                        message = '旷勤（早退' + minutesEarly + '分钟）';
                    } else {
                        message = '正常签退（提前' + minutesEarly + '分钟）';
                    }
                } else if (currentDateTime > workEndTime) {
                    // 超时工作
                    var minutesLate = Math.floor((currentDateTime - workEndTime) / (1000 * 60));
                    console.log('超时时间:', minutesLate + '分钟');

                    if (minutesLate > 30) {
                        isNormal = false;
                        if (attendanceStatus === '早签') {
                            statusText = '出勤';
                            message = '超时签退（超时' + minutesLate + '分钟）';
                        } else if (attendanceStatus === '迟到') {
                            statusText = attendanceStatus;
                            message = '超时签退（超时' + minutesLate + '分钟，保持迟到）';
                        }
                    } else {
                        if (attendanceStatus === '早签') {
                            statusText = '出勤';
                        } else if (attendanceStatus === '迟到') {
                            statusText = attendanceStatus;
                        }
                        message = '正常签退（超时' + minutesLate + '分钟）';
                    }
                } else {
                    // 准时签退
                    message = '准时签退';

                    if (attendanceStatus === '早签') {
                        statusText = '出勤';
                    } else if (attendanceStatus === '迟到') {
                        statusText = attendanceStatus;
                    }
                }

                // 保存签退记录
                saveAttendanceToDB('signOut', statusText, currentTimeStr, isNormal, message);
            });
        }

        // 获取今日考勤状态
        function getTodayAttendanceStatus(callback) {
            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: {
                    action: 'gettodaystatus',
                    userName: userName,
                    year: currentYear,
                    month: currentMonth,
                    day: currentDay,
                    companyName: companyName,
                    dayFieldMap: JSON.stringify(dayFieldMap)
                },
                success: function (data) {
                    try {
                        if (data.success) {
                            var todayStatus = data.todayStatus || '';

                            // 如果是"休"状态，禁用打卡按钮
                            if (todayStatus === '休') {
                                signInDisabled = true;
                                signOutDisabled = true;
                                updateTodayStatus('休息日', 'blue');
                            }

                            callback(todayStatus);
                        } else {
                            callback('');
                        }
                    } catch (e) {
                        console.log('获取考勤状态失败:', e);
                        callback('');
                    }
                }
            });
        }

        // 保存考勤记录到数据库
        function saveAttendanceToDB(type, status, time, isNormal, message) {
            var dayField = dayFieldMap[currentDay];

            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: {
                    action: 'saveattendance',
                    type: type,
                    status: status,
                    time: time,
                    userName: userName,
                    year: currentYear,
                    month: currentMonth,
                    day: currentDay,
                    dayField: dayField,
                    companyName: companyName,
                    isNormal: isNormal,
                    message: message
                },
                success: function (data) {
                    try {
                        if (data.success) {
                            updateLocalState(type, time, status, isNormal, message);

                            // 更新统计信息
                            updateAttendanceStatistics();
                        } else {
                            showMessage(data.message || '保存失败', 'error');
                        }
                    } catch (e) {
                        console.log('保存失败:', e);
                        showMessage('保存失败', 'error');
                    }
                }
            });
        }

        // 更新本地状态
        function updateLocalState(type, time, status, isNormal, message) {
            // 添加到今日记录
            var record = {
                id: Date.now(),
                type: type,
                time: time,
                status: status,
                isValid: isNormal,
                message: message
            };

            todayRecords.push(record);

            // 更新界面状态
            if (type === 'signIn') {
                signInTime = time;
                signInDisabled = true;
                signOutDisabled = false;
            } else if (type === 'signOut') {
                signOutTime = time;
                signOutDisabled = true;
            }

            // 更新今日状态
            updateTodayStatus();

            // 显示结果
            if (isNormal) {
                showMessage(message, 'success');
            } else {
                showMessage(message, 'error');
            }

            // 刷新记录列表
            updateTodayRecordsDisplay();
            updatePunchButtons();
            savePunchState();

            console.log('打卡流程完成');
        }

        // 加载工作安排
        function loadWorkSchedule() {
            if (!department || !userName) {
                return;
            }

            var today = new Date();
            var dateStr = formatDate(today);

            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: {
                    action: 'loadworkschedule',
                    department: department,
                    userName: userName,
                    dateStr: dateStr,
                    companyName: companyName
                },
                success: function (data) {
                    try {
                        if (data.success) {
                            console.log("工作安排返回数据",data)
                            workSchedule = data.data.schedule;
                            console.log("工作安排返回数据workSchedule", workSchedule)
                            updateScheduleDisplay(workSchedule);
                            showMessage('已找到排班：' + workSchedule.schedule_title, 'success');
                            checkTodayAttendance();
                            updatePunchButtons();
                        } else {
                            workSchedule = null;
                            updateScheduleDisplay(workSchedule);
                            showMessage('今日无工作安排', 'info');
                            checkTodayAttendance();
                            updatePunchButtons();
                        }
                    } catch (e) {
                        console.log("工作安排返回数据cuowu", data)
                        console.log('加载工作安排失败:', e);
                        workSchedule = null;
                        updateScheduleDisplay(workSchedule);
                    }
                }
            });
        }

        // 加载今日记录
        function loadTodayRecords() {
            // 这里可以从服务器加载，或者使用本地存储
            // 为了简化，我们这里只显示当前会话的记录
            updateTodayRecordsDisplay();
        }

        // 加载请假记录
        function loadMyLeaveRecords() {
            if (!userName) {
                return;
            }

            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: {
                    action: 'loadleaverequests',
                    userName: userName,
                    companyName: companyName
                },
                success: function (data) {
                    try {
                        if (data.success) {
                            myLeaveRecords = data.data.records || [];
                            updateLeaveRecordsDisplay();
                        }
                    } catch (e) {
                        console.log('加载请假记录失败:', e);
                    }
                }
            });
        }

        // 更新统计信息
        function updateAttendanceStatistics() {
            // 这里可以调用服务器端接口更新统计
            console.log('更新统计信息...');
        }

        // 更新今日状态
        function updateTodayStatus() {
            var hasSignedIn = signInTime && signInTime !== '';
            var hasSignedOut = signOutTime && signOutTime !== '';

            var status = { text: '未签到', color: 'red' };

            if (hasSignedIn && hasSignedOut) {
                var hasInvalidRecord = todayRecords.some(function (record) {
                    return !record.isValid;
                });

                if (hasInvalidRecord) {
                    status = { text: '已完成（有异常）', color: 'orange' };
                } else {
                    status = { text: '已完成', color: 'green' };
                }
            } else if (hasSignedIn) {
                var signInRecord = todayRecords.find(function (record) {
                    return record.type === 'signIn';
                });
                if (signInRecord && !signInRecord.isValid) {
                    status = { text: '已签到（异常）', color: 'orange' };
                } else {
                    status = { text: '已签到', color: 'green' };
                }
            }

            todayStatus = status;
            updateTodayStatusDisplay();
        }

        // 更新打卡按钮状态
        function updatePunchButtons() {
            var hasWorkSchedule = !!workSchedule;
            var hasSignedIn = signInTime && signInTime !== '';
            var hasSignedOut = signOutTime && signOutTime !== '';

            signInDisabled = !hasWorkSchedule || hasSignedIn || hasSignedOut;
            signOutDisabled = !hasSignedIn || hasSignedOut;

            // 更新按钮显示
            var signInBtn = $('.btn-punch:first-child');
            var signOutBtn = $('.btn-punch:last-child');

            if (signInDisabled) {
                signInBtn.addClass('disabled').prop('disabled', true);
            } else {
                signInBtn.removeClass('disabled').prop('disabled', false);
            }

            if (signOutDisabled) {
                signOutBtn.addClass('disabled').prop('disabled', true);
            } else {
                signOutBtn.removeClass('disabled').prop('disabled', false);
            }

            // 更新时间显示
            $('#signInTime').text(signInTime || '');
            $('#signOutTime').text(signOutTime || '');
        }

        // 保存打卡状态
        function savePunchState() {
            // 可以保存到cookie或本地存储
            var punchState = {
                signInTime: signInTime,
                signOutTime: signOutTime,
                signInDisabled: signInDisabled,
                signOutDisabled: signOutDisabled,
                lastUpdate: new Date().getTime()
            };

            setCookie('punch_state_' + formatDate(new Date()), JSON.stringify(punchState), 1);
        }

        // 检查用户信息
        function checkUserInfo() {
            if (!department || !userName) {
                showMessage('请先保存部门和个人信息', 'error');
                return false;
            }
            return true;
        }

        // 显示消息
        function showMessage(text, type) {
            var toast = $('#messageToast');
            if (!toast.length) {
                $('body').append('<div id="messageToast" class="message-toast ' + type + '">' + text + '</div>');
                toast = $('#messageToast');
            } else {
                toast.removeClass().addClass('message-toast ' + type).text(text);
            }

            setTimeout(function () {
                toast.fadeOut(300, function () {
                    $(this).remove();
                });
            }, 3000);
        }

        // 工具方法：格式化日期
        function formatDate(date) {
            var d = new Date(date);
            return d.getFullYear() + '-' +
                   (d.getMonth() + 1).toString().padStart(2, '0') + '-' +
                   d.getDate().toString().padStart(2, '0');
        }

        // 工具方法：格式化时间
        function formatTime(date) {
            var d = new Date(date);
            return d.getHours().toString().padStart(2, '0') + ':' +
                   d.getMinutes().toString().padStart(2, '0');
        }

        // 工具方法：解析时间字符串
        function parseTimeString(timeStr) {
            var now = new Date();
            var parts = timeStr.split(':');
            return new Date(now.getFullYear(), now.getMonth(), now.getDate(),
                           parseInt(parts[0]), parseInt(parts[1]), 0);
        }

        // 更新今日状态显示
        function updateTodayStatusDisplay() {
            var statusDiv = $('#todayStatus');
            if (!statusDiv.length) {
                $('.punch-section').append('<div id="todayStatus" class="today-status ' + todayStatus.color + '">' + todayStatus.text + '</div>');
            } else {
                statusDiv.removeClass().addClass('today-status ' + todayStatus.color).text(todayStatus.text);
            }
        }

        // 更新工作安排显示
        function updateScheduleDisplay(workSchedule) {
            console.log("更新数据", workSchedule);
            var scheduleHtml = '';
            if (workSchedule) {
                scheduleHtml = '<div class="section-header">' +
                              '<div class="section-title">今日工作安排</div>' +
                              '</div>' +
                              '<div class="schedule-detail">' +
                              '<div class="schedule-row">' +
                              '<span class="schedule-label">排班：</span>' +
                              '<span class="schedule-value">' + (workSchedule.schedule_title || '') + '</span>' +
                              '</div>' +
                              '<div class="schedule-row">' +
                              '<span class="schedule-label">工作时间：</span>' +
                              '<span class="schedule-value">' + (workSchedule.gongzuoshijianks || '') + ' - ' + (workSchedule.gongzuoshijianjs || '') + '</span>' +
                              '</div>' +
                              '<div class="schedule-row">' +
                              '<span class="schedule-label">午休时间：</span>' +
                              '<span class="schedule-value">' + (workSchedule.wuxiushijianks || '') + ' - ' + (workSchedule.wuxiushijianjs || '') + '</span>' +
                              '</div>' +
                              '</div>';
            } else {
                scheduleHtml = '<div class="section-header">' +
                              '<div class="section-title">今日工作安排</div>' +
                              '</div>' +
                              '<div class="schedule-detail">' +
                              '<div class="empty-records">今日无工作安排</div>' +
                              '</div>';
            }

            $('#scheduleInfo').html(scheduleHtml);
        }

        // 更新今日记录显示
        function updateTodayRecordsDisplay() {
            var recordsHtml = '';
            if (todayRecords.length > 0) {
                recordsHtml = todayRecords.map(function (record) {
                    return '<div class="record-item">' +
                          '<span class="record-type ' + (record.type === 'signIn' ? 'sign-in' : 'sign-out') + '">' +
                          (record.type === 'signIn' ? '签到' : '签退') +
                          '</span>' +
                          '<span class="record-time">' + record.time + '</span>' +
                          '<span class="record-status ' + (record.isValid ? 'valid' : 'invalid') + '">' +
                          (record.isValid ? '正常' : '异常') +
                          '</span>' +
                          '<span class="record-message">' + record.message + '</span>' +
                          '</div>';
                }).join('');
            } else {
                recordsHtml = '<div class="empty-records">暂无打卡记录</div>';
            }

        }

        // 更新请假记录显示
        function updateLeaveRecordsDisplay() {
            var recordsHtml = '';
            if (myLeaveRecords.length > 0) {
                // 表头
                recordsHtml = '<div class="leave-records-header">' +
                             '<span class="leave-record-header-cell" style="width: 25%;">请假时间</span>' +
                             '<span class="leave-record-header-cell" style="width: 20%;">天数</span>' +
                             '<span class="leave-record-header-cell" style="width: 30%;">原因</span>' +
                             '<span class="leave-record-header-cell" style="width: 20%;">状态</span>' +
                             '</div>' +
                             '<div class="leave-records-list">';

                // 记录行
                recordsHtml += myLeaveRecords.map(function (record) {
                    var startDate = record.qsqingjiashijian || '';
                    var endDate = record.jzqingjiashijan || '';
                    var daysCount = record.daysCount || 0;
                    var reason = record.qingjiayuanyin || '--';
                    var status = record.zhuangtai || '待审批';
                    var statusColor = record.statusColor || 'gray';

                    return '<div class="leave-record-item">' +
                          '<span class="leave-record-cell" style="width: 25%;">' +
                          startDate + '至' + endDate +
                          '</span>' +
                          '<span class="leave-record-cell" style="width: 20%;">' + daysCount + '天</span>' +
                          '<span class="leave-record-cell" style="width: 30%;">' + reason + '</span>' +
                          '<span class="leave-record-cell" style="width: 20%; color: ' + statusColor + ';">' +
                          status +
                          '</span>' +
                          '</div>';
                }).join('');

                recordsHtml += '</div>';
            } else {
                recordsHtml = '<div class="empty-leave-records">暂无请假记录</div>';
            }

            $('#leaveRecords').html(recordsHtml);
        }

        // 请假申请相关函数
        function showLeaveApplication() {
            if (!checkUserInfo()) {
                return;
            }

            var today = new Date();
            var tomorrow = new Date(today);
            tomorrow.setDate(tomorrow.getDate() + 1);

            $('#leaveStartDate').val(formatDate(today));
            $('#leaveEndDate').val(formatDate(tomorrow));
            $('#leaveReason').val('');

            $('#leaveModal').show();
        }

        function hideLeaveApplication() {
            $('#leaveModal').hide();
        }

        function submitLeaveApplication() {
            var startDate = $('#leaveStartDate').val();
            var endDate = $('#leaveEndDate').val();
            var reason = $('#leaveReason').val();

            if (!startDate || !endDate) {
                showMessage('请选择请假日期', 'error');
                return;
            }

            if (!reason || reason.trim() === '') {
                showMessage('请输入请假原因', 'error');
                return;
            }

            var startDateObj = new Date(startDate);
            var endDateObj = new Date(endDate);

            if (endDateObj < startDateObj) {
                showMessage('结束日期不能早于开始日期', 'error');
                return;
            }

            // 计算请假天数
            var diffTime = Math.abs(endDateObj - startDateObj);
            var diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)) + 1;

            // 提交请假申请
            $.ajax({
                url: 'qiandao.aspx',
                type: 'POST',
                data: {
                    action: 'submitleave',
                    department: department,
                    userName: userName,
                    companyName: companyName,
                    startDate: startDate,
                    endDate: endDate,
                    reason: reason,
                    days: diffDays
                },
                success: function (data) {
                    try {
                        if (data.success) {
                            showMessage('请假申请提交成功，等待审批', 'success');
                            hideLeaveApplication();
                            loadMyLeaveRecords();
                        } else {
                            showMessage(data.message || '提交失败', 'error');
                        }
                    } catch (e) {
                        showMessage('提交失败', 'error');
                    }
                }
            });
        }

        // Cookie操作函数
        function setCookie(name, value, days) {
            var expires = "";
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toUTCString();
            }
            document.cookie = name + "=" + (value || "") + expires + "; path=/";
        }

        function getCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) === ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }
    </script>
</head>
<body>
    <div class="ti">
        <h1>考勤打卡</h1>
    </div>
    
    <div class="main-container">
        <!-- 用户信息输入 -->
        <div class="input-section">
            <div class="form-group">
                <label class="form-label">部门</label>
                <!-- 确保这里只有这一个id为department的元素 -->
                <select id="department" class="form-input">
                    <option value="">请选择部门</option>
                    <!-- 部门选项将通过JavaScript动态加载 -->
                </select>
            </div>
            
            <div class="form-group">
                <label class="form-label">姓名</label>
                <input type="text" id="userName" class="form-input" placeholder="请输入您的姓名" />
            </div>
            
            <button class="btn-save-userinfo" onclick="saveUserInfo()">保存个人信息</button>
        </div>
        
        <!-- 当前时间显示 -->
        <div class="time-display">
            <span class="current-date" id="currentDate"></span>
            <span class="current-time" id="currentTime"></span>
        </div>
        
        <!-- 打卡操作区域 -->
        <div class="punch-section">
            <div class="punch-buttons">
                <button class="btn-punch" onclick="signIn()">
                    <span class="punch-icon">📝</span>
                    <span>签到</span>
                    <span class="punch-time" id="signInTime"></span>
                </button>
                
                <button class="btn-punch" onclick="signOut()">
                    <span class="punch-icon">✅</span>
                    <span>签退</span>
                    <span class="punch-time" id="signOutTime"></span>
                </button>
            </div>
            
            <!-- 今日状态将通过JS动态显示 -->
        </div>
        
        <!-- 工作安排信息 -->
        <div class="schedule-info" id="scheduleInfo">
            <!-- 工作安排将通过JS动态显示 -->
        </div>
        
        
        <!-- 请假申请模块 -->
        <div class="leave-section">
            <div class="section-header">
                <span class="section-title">请假申请</span>
                <button class="btn-leave-apply" onclick="showLeaveApplication()">申请请假</button>
            </div>
            
            <div class="leave-records" id="leaveRecords">
                <!-- 请假记录将通过JS动态显示 -->
            </div>
        </div>
       
    </div>
    
    <!-- 请假申请弹窗 -->
    <div class="modal-overlay" id="leaveModal" style="display:none;">
        <div class="modal-container">
            <div class="modal-header">
                <span class="modal-title">请假申请</span>
                <span class="modal-close" onclick="hideLeaveApplication()">×</span>
            </div>
            
            <div class="modal-content">
                <div class="form-group">
                    <label class="form-label">请假开始日期</label>
                    <input type="date" id="leaveStartDate" class="form-input" />
                </div>
                
                <div class="form-group">
                    <label class="form-label">请假结束日期</label>
                    <input type="date" id="leaveEndDate" class="form-input" />
                </div>
                
                <div class="form-group">
                    <label class="form-label">请假原因</label>
                    <textarea id="leaveReason" class="textarea-input" placeholder="请输入请假原因" maxlength="500"></textarea>
                </div>
                
            </div>
            
            <div class="modal-footer">
                <button class="btn-modal btn-modal-cancel" onclick="hideLeaveApplication()">取消</button>
                <button class="btn-modal btn-modal-submit" onclick="submitLeaveApplication()">提交申请</button>
            </div>
        </div>
    </div>
</body>
</html>