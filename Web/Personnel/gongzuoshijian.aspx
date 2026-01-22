<%@ page language="C#" autoeventwireup="true" codebehind="gongzuoshijian.aspx.cs" inherits="Web.Personnel.gongzuoshijian" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工作时间安排</title>
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
        
        /* 头部操作栏 */
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
        
        /* 日历容器 */
        .calendar-container {
            width: 35%;
            height: 100%;
            background: white;
            border-radius: 12px;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
        
        .calendar-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
            padding-bottom: 15px;
            border-bottom: 1px solid #e8e8e8;
        }
        
        .calendar-nav {
            display: flex;
            align-items: center;
            gap: 20px;
        }
        
        .nav-btn {
            background: #f0f0f0;
            border: none;
            width: 36px;
            height: 36px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            font-size: 18px;
            font-weight: bold;
            transition: all 0.3s;
        }
        
        .nav-btn:hover {
            background: #1890ff;
            color: white;
        }
        
        .current-month {
            font-size: 18px;
            font-weight: 600;
            color: #333;
        }
        
        .week-header {
            display: grid;
            grid-template-columns: repeat(7, 1fr);
            text-align: center;
            padding: 10px 0;
            background: #f9f9f9;
            border-radius: 8px;
            margin-bottom: 10px;
        }
        
        .week-day {
            font-weight: 600;
            color: #666;
            padding: 8px;
        }
        
        /* 日历网格 */
        .calendar-grid {
            display: grid;
            grid-template-columns: repeat(7, 1fr);
            gap: 8px;
        }
        
        .calendar-day {
            aspect-ratio: 1;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            border-radius: 8px;
            cursor: pointer;
            transition: all 0.3s;
            position: relative;
            border: 2px solid transparent;
            padding: 5px;
        }
        
        .calendar-day.current-month {
            background: white;
            border-color: #f0f0f0;
        }
        
        .calendar-day.other-month {
            background: #f9f9f9;
            color: #999;
        }
        
        .calendar-day.today {
            background: #e6f7ff;
            border-color: #1890ff;
        }
        
        .calendar-day.selected {
            background: #1890ff;
            color: white;
            border-color: #096dd9;
        }
        
        .calendar-day.has-schedule {
            border-color: #52c41a;
        }
        
        .calendar-day.has-schedule .day-text {
            color: #52c41a;
            font-weight: bold;
        }
        
        .calendar-day:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        
        .day-text {
            font-size: 16px;
            font-weight: 500;
        }
        
        .schedule-dot {
            position: absolute;
            top: 5px;
            right: 5px;
            width: 6px;
            height: 6px;
            border-radius: 50%;
            background: #52c41a;
        }
        
        .schedule-count {
            position: absolute;
            top: 2px;
            right: 2px;
            background: #ff4d4f;
            color: white;
            font-size: 10px;
            width: 16px;
            height: 16px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        
        /* 选中日期显示 */
        .selected-dates {
            background: white;
            border-radius: 8px;
            padding: 15px;
            margin: 20px 0;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
        }
        
        .label {
            font-weight: 600;
            color: #333;
            margin-right: 10px;
        }
        
        .dates-scroll {
            display: flex;
            flex-wrap: wrap;
            gap: 8px;
            margin-top: 10px;
        }
        
        .date-tag {
            background: #1890ff;
            color: white;
            padding: 4px 12px;
            border-radius: 16px;
            font-size: 14px;
        }
        
        /* 时间设置面板 */
        .time-panel {
            background: white;
            border-radius: 12px;
            padding: 20px;
            margin: 20px 0;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
        
        .panel-title {
            font-size: 18px;
            font-weight: 600;
            color: #333;
            margin-bottom: 20px;
            padding-bottom: 10px;
            border-bottom: 2px solid #1890ff;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        .form-label {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #333;
        }
        
        .form-input, .form-select {
            width: 100%;
            padding: 10px 15px;
            border: 1px solid #d9d9d9;
            border-radius: 6px;
            font-size: 14px;
            transition: all 0.3s;
        }
        
        .form-input:focus, .form-select:focus {
            border-color: #1890ff;
            box-shadow: 0 0 0 2px rgba(24, 144, 255, 0.1);
            outline: none;
        }
        
        .time-range-group {
            display: flex;
            align-items: center;
            gap: 10px;
        }
        
        .time-picker {
            flex: 1;
            padding: 10px 15px;
            border: 1px solid #d9d9d9;
            border-radius: 6px;
            text-align: center;
            cursor: pointer;
            background: #f9f9f9;
        }
        
        .time-separator {
            color: #666;
            font-weight: 500;
        }
        
        .break-time-group {
            display: flex;
            align-items: center;
            gap: 10px;
        }
        
        /* 工作安排列表 */
        .schedule-list {
            width: 60%;
            height: 528px;
            overflow: auto;
            background: white;
            border-radius: 12px;
            padding: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }
        
        .section-title {
            font-size: 18px;
            font-weight: 600;
            color: #333;
            margin-bottom: 20px;
            padding-bottom: 10px;
            border-bottom: 2px solid #1890ff;
        }
        
        .schedule-item {
            border-left: 6px solid #1890ff;
            padding: 15px;
            margin-bottom: 15px;
            background: #f9f9f9;
            border-radius: 8px;
            transition: all 0.3s;
        }
        
        .schedule-item:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        
        .schedule-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
        }
        
        .schedule-title {
            font-size: 16px;
            font-weight: 600;
            color: #333;
        }
        
        .schedule-time {
            font-size: 14px;
            color: #1890ff;
            cursor: pointer;
            padding: 4px 8px;
            border-radius: 4px;
            transition: all 0.3s;
        }
        
        .schedule-time:hover {
            background: #e6f7ff;
        }
        
        .schedule-details {
            margin-bottom: 10px;
        }
        
        .schedule-date {
            display: inline-block;
            background: #f0f0f0;
            color: #666;
            padding: 4px 12px;
            border-radius: 16px;
            font-size: 12px;
            margin-right: 10px;
            cursor: pointer;
            transition: all 0.3s;
        }
        
        .schedule-date:hover {
            background: #1890ff;
            color: white;
        }
        
        .schedule-break {
            font-size: 13px;
            color: #666;
            cursor: pointer;
            padding: 4px 8px;
            border-radius: 4px;
            transition: all 0.3s;
        }
        
        .schedule-break:hover {
            background: #f6ffed;
            color: #52c41a;
        }
        
        .schedule-footer {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        
        .schedule-repeat {
            font-size: 12px;
            color: #666;
            padding: 2px 8px;
            background: #f0f0f0;
            border-radius: 12px;
        }
        
        .btn-delete {
            background: #ff4d4f;
            color: white;
            border: none;
            padding: 4px 12px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 12px;
            transition: all 0.3s;
        }
        
        .btn-delete:hover {
            background: #ff7875;
        }
        
        /* 底部操作栏 */
        .bottom-bar {
            position: fixed;
            bottom: 0;
            left: 0;
            right: 0;
            background: white;
            padding: 15px 20px;
            display: flex;
            justify-content: space-between;
            gap: 10px;
            box-shadow: 0 -2px 10px rgba(0, 0, 0, 0.1);
            z-index: 1000;
        }
        
        .btn-range, .btn-export {
            flex: 1;
            background: #f0f0f0;
            color: #333;
            border: none;
            padding: 10px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
        }
        
        .btn-range:hover, .btn-export:hover {
            background: #d9d9d9;
        }
        
        .btn-add {
            flex: 2;
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 10px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
        }
        
        .btn-add:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 模态框样式 */
        .modal {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
            z-index: 2000;
            align-items: center;
            justify-content: center;
        }
        
        .modal-content {
            margin-left: 26%;
            margin-top: 5%;
            background: white;
            border-radius: 12px;
            width: 90%;
            max-width: 600px;
            max-height: 80vh;
            overflow-y: auto;
            box-shadow: 0 8px 24px rgba(0, 0, 0, 0.2);
        }
        
        .modal-header {
            padding: 20px;
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
        
        .close-modal {
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
        
        .close-modal:hover {
            background: #f0f0f0;
            color: #333;
        }
        
        .modal-body {
            padding: 20px;
        }
        
        .modal-footer {
            padding: 20px;
            border-top: 1px solid #e8e8e8;
            display: flex;
            justify-content: flex-end;
            gap: 10px;
        }
        
        .btn-modal-cancel {
            background: #f0f0f0;
            color: #333;
            border: none;
            padding: 8px 16px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
        }
        
        .btn-modal-cancel:hover {
            background: #d9d9d9;
        }
        
        .btn-modal-save {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
        }
        
        .btn-modal-save:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
        }
        
        /* 编辑日历弹窗 */
        .edit-calendar-grid {
            display: grid;
            grid-template-columns: repeat(7, 1fr);
            gap: 5px;
            margin: 15px 0;
        }
        
        .edit-calendar-day {
            aspect-ratio: 1;
            display: flex;
            align-items: center;
            justify-content: center;
            border-radius: 6px;
            cursor: pointer;
            transition: all 0.3s;
            border: 2px solid transparent;
            font-size: 14px;
        }
        
        .edit-calendar-day.current-month {
            background: white;
            border-color: #e8e8e8;
        }
        
        .edit-calendar-day.other-month {
            background: #f9f9f9;
            color: #999;
        }
        
        .edit-calendar-day.selected {
            background: #1890ff;
            color: white;
            border-color: #096dd9;
        }
        
        .quick-actions {
            display: flex;
            gap: 10px;
            margin: 15px 0;
        }
        
        .btn-quick {
            background: #f0f0f0;
            border: none;
            padding: 6px 12px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 12px;
            transition: all 0.3s;
        }
        
        .btn-quick:hover {
            background: #d9d9d9;
        }
        
        .selected-preview {
            margin: 15px 0;
        }
        
        .selected-dates-scroll {
            max-height: 100px;
            overflow-y: auto;
            margin-top: 10px;
        }
        
        .selected-dates-grid {
            display: flex;
            flex-wrap: wrap;
            gap: 8px;
        }
        
        .selected-date-tag {
            background: #52c41a;
            color: white;
            padding: 4px 8px;
            border-radius: 12px;
            font-size: 12px;
        }
        
        .empty-tip {
            color: #999;
            font-style: italic;
        }
        
        /* 日期范围选择 */
        .filter-options {
            margin: 20px 0;
        }
        
        .options-title {
            display: block;
            margin-bottom: 10px;
            font-weight: 600;
            color: #333;
        }
        
        .option-group {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 10px;
        }
        
        .option-item {
            display: flex;
            align-items: center;
            gap: 8px;
        }
        
        .option-label {
            font-size: 14px;
            color: #666;
        }
        
        .preview-section {
            margin: 20px 0;
        }
        
        .preview-title {
            display: block;
            margin-bottom: 10px;
            font-weight: 600;
            color: #333;
        }
        
        .preview-dates {
            border: 1px solid #e8e8e8;
            border-radius: 6px;
            padding: 10px;
        }
        
        .preview-grid {
            display: flex;
            flex-wrap: wrap;
            gap: 8px;
        }
        
        .preview-date-tag {
            background: #f0f0f0;
            color: #666;
            padding: 4px 8px;
            border-radius: 12px;
            font-size: 12px;
        }
        
        .preview-more {
            color: #999;
            font-size: 12px;
        }
        
        /* 响应式设计 */
        @media (max-width: 768px) {
            .calendar-grid {
                gap: 4px;
            }
            
            .calendar-day {
                font-size: 14px;
            }
            
            .day-text {
                font-size: 14px;
            }
            
            .bottom-bar {
                flex-direction: column;
                gap: 8px;
            }
            
            .btn-range, .btn-export, .btn-add {
                width: 100%;
            }
            
            .option-group {
                grid-template-columns: 1fr;
            }
        }
        
        /* 滚动条样式 */
        ::-webkit-scrollbar {
            width: 6px;
            height: 6px;
        }
        
        ::-webkit-scrollbar-track {
            background: #f1f1f1;
            border-radius: 3px;
        }
        
        ::-webkit-scrollbar-thumb {
            background: #c1c1c1;
            border-radius: 3px;
        }
        
        ::-webkit-scrollbar-thumb:hover {
            background: #a8a8a8;
        }
    </style>
    <script src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        // 全局变量
        var currentYear = <%= DateTime.Now.Year %>;
        var currentMonth = <%= DateTime.Now.Month %>;
        var currentDay = <%= DateTime.Now.Day %>;
        var calendarDays = [];
        var selectedDates = [];
        var scheduleList = [];
        var companyName = '<%= Session["gongsi"] != null ? Session["gongsi"].ToString() : "" %>';
        
        // 初始化页面
        $(document).ready(function() {
            // 检查登录
            if (!companyName) {
                alert('请先登录！');
                window.location.href = '/Myadmin/Login.aspx';
                return;
            }
            
            // 初始化日历
            generateCalendar(currentYear, currentMonth);
            
            // 加载工作安排数据
            loadSchedules();
            
            // 设置默认日期范围
            var today = new Date();
            var nextMonth = new Date();
            nextMonth.setMonth(nextMonth.getMonth() + 1);
            
            $('#rangeStartDate').val(formatDate(today));
            $('#rangeEndDate').val(formatDate(nextMonth));
        });
        
        // 生成日历
        function generateCalendar(year, month) {
            var days = [];
            var firstDay = new Date(year, month - 1, 1);
            var lastDay = new Date(year, month, 0);
            var daysInMonth = lastDay.getDate();
            var firstDayWeek = firstDay.getDay() || 7; // 周一到周日 1-7
            
            // 添加上个月的最后几天
            var prevMonthLastDay = new Date(year, month - 1, 0).getDate();
            for (var i = firstDayWeek - 1; i > 0; i--) {
                var date = new Date(year, month - 2, prevMonthLastDay - i + 1);
                var dateStr = formatDate(date);
                
                days.push({
                    date: date,
                    day: date.getDate(),
                    month: month - 1,
                    year: date.getFullYear(),
                    isCurrentMonth: false,
                    isToday: false,
                    hasSchedule: false,
                    dateStr: dateStr
                });
            }
            
            // 添加当前月
            var today = new Date();
            for (var i = 1; i <= daysInMonth; i++) {
                var date = new Date(year, month - 1, i);
                var dateStr = formatDate(date);
                
                // 检查是否有工作安排
                var hasSchedule = checkHasSchedule(dateStr);
                
                days.push({
                    date: date,
                    day: i,
                    month: month,
                    year: year,
                    isCurrentMonth: true,
                    isToday: date.toDateString() === today.toDateString(),
                    hasSchedule: hasSchedule.has,
                    scheduleCount: hasSchedule.count,
                    dateStr: dateStr
                });
            }
            
            // 添加下个月的前几天
            var totalCells = 42; // 6行×7列
            var remainingCells = totalCells - days.length;
            for (var i = 1; i <= remainingCells; i++) {
                var date = new Date(year, month, i);
                var dateStr = formatDate(date);
                
                days.push({
                    date: date,
                    day: i,
                    month: month + 1,
                    year: date.getFullYear(),
                    isCurrentMonth: false,
                    isToday: false,
                    hasSchedule: false,
                    dateStr: dateStr
                });
            }
            
            calendarDays = days;
            updateCalendarDisplay();
        }
        
        // 更新日历显示
        function updateCalendarDisplay() {
            var calendarHtml = '';
            calendarDays.forEach(function(day, index) {
                var dayClass = 'calendar-day';
                if (day.isCurrentMonth) dayClass += ' current-month';
                if (!day.isCurrentMonth) dayClass += ' other-month';
                if (day.isToday) dayClass += ' today';
                if (selectedDates.includes(day.dateStr)) dayClass += ' selected';
                if (day.hasSchedule) dayClass += ' has-schedule';
                
                calendarHtml += '<div class="' + dayClass + '" onclick="selectDate(\'' + day.dateStr + '\', ' + index + ')">' +
                               '<span class="day-text">' + day.day + '</span>';
                
                if (day.hasSchedule) {
                    calendarHtml += '<span class="schedule-dot"></span>';
                    if (day.scheduleCount > 1) {
                        calendarHtml += '<span class="schedule-count">' + day.scheduleCount + '</span>';
                    }
                }
                
                calendarHtml += '</div>';
            });
            
            $('#calendarGrid').html(calendarHtml);
            $('#currentMonth').text(currentYear + '年' + currentMonth + '月');
        }
        
        // 检查日期是否有工作安排
        function checkHasSchedule(dateStr) {
            var hasSchedule = false;
            var count = 0;
            
            scheduleList.forEach(function(schedule) {
                if (schedule.work_days && Array.isArray(schedule.work_days) && schedule.work_days.includes(dateStr)) {
                    hasSchedule = true;
                    count++;
                }
            });
            
            return { has: hasSchedule, count: count };
        }
        
        // 选择日期
        function selectDate(dateStr, index) {
            var day = calendarDays[index];
            if (!day.isCurrentMonth) return;
            
            if (selectedDates.includes(dateStr)) {
                selectedDates = selectedDates.filter(function(date) {
                    return date !== dateStr;
                });
            } else {
                selectedDates.push(dateStr);
            }
            
            updateCalendarDisplay();
            updateSelectedDatesDisplay();
            
            // 如果有选中日期，显示时间设置面板
            if (selectedDates.length > 0) {
                $('#timePanel').show();
            }
        }
        
        // 更新选中日期显示
        function updateSelectedDatesDisplay() {
            if (selectedDates.length === 0) {
                $('#selectedDatesDisplay').hide();
                return;
            }
            
            var html = '<span class="label">已选日期：</span><div class="dates-scroll">';
            selectedDates.forEach(function(date) {
                html += '<span class="date-tag">' + date + '</span>';
            });
            html += '</div>';
            
            $('#selectedDatesDisplay').html(html).show();
        }
        
        // 上个月
        function prevMonth() {
            currentMonth--;
            if (currentMonth < 1) {
                currentYear--;
                currentMonth = 12;
            }
            generateCalendar(currentYear, currentMonth);
        }
        
        // 下个月
        function nextMonth() {
            currentMonth++;
            if (currentMonth > 12) {
                currentYear++;
                currentMonth = 1;
            }
            generateCalendar(currentYear, currentMonth);
        }
        
        // 格式化日期
        function formatDate(date) {
            var year = date.getFullYear();
            var month = (date.getMonth() + 1).toString().padStart(2, '0');
            var day = date.getDate().toString().padStart(2, '0');
            return year + '-' + month + '-' + day;
        }
        
        // 保存工作安排
        function saveSchedule() {
            if (selectedDates.length === 0) {
                alert('请选择日期');
                return;
            }
            
            var scheduleTitle = $('#scheduleTitle').val();
            if (!scheduleTitle) {
                alert('请输入排班标题');
                return;
            }
            
            var startTime = $('#startTime').val();
            var endTime = $('#endTime').val();
            var breakStart = $('#breakStart').val();
            var breakEnd = $('#breakEnd').val();
            
            // 获取年月
            var firstDate = selectedDates[0];
            var dateObj = new Date(firstDate);
            var yearMonth = dateObj.getFullYear() + '-' + (dateObj.getMonth() + 1).toString().padStart(2, '0');
            var riqi = firstDate;
            
            // 准备数据
            var scheduleData = {
                gongzuoshijianks: startTime,
                gongzuoshijianjs: endTime,
                wuxiushijianks: breakStart,
                wuxiushijianjs: breakEnd,
                year_month: yearMonth,
                riqi: riqi,
                gongsi: companyName,
                work_days: JSON.stringify(selectedDates),
                repeat_type: 'none',
                schedule_title: scheduleTitle,
                schedule_status: 'active'
            };
            
            $.ajax({
                url: 'gongzuoshijian.aspx',
                type: 'POST',
                data: {
                    action: 'saveschedule',
                    scheduleData: JSON.stringify(scheduleData)
                },
                success: function(data) {
                    try {
                        if (data.success) {
                            alert('保存成功');
                            resetForm();
                            loadSchedules();
                        } else {
                            alert('保存失败：' + data.message);
                        }
                    } catch(e) {
                        alert('保存失败');
                    }
                }
            });
        }
        
        // 加载工作安排
        function loadSchedules() {
            $.ajax({
                url: 'gongzuoshijian.aspx',
                type: 'POST',
                data: {
                    action: 'loadschedules'
                },
                success: function(data) {
                    try {
                        if (data.success) {
                            scheduleList = data.schedules || [];
                            updateScheduleListDisplay();
                            generateCalendar(currentYear, currentMonth);
                        }
                    } catch(e) {
                        console.log('加载失败:', e);
                    }
                }
            });
        }
        
        // 更新工作安排列表显示
        function updateScheduleListDisplay() {
            var html = '';
            scheduleList.forEach(function(schedule) {
                html += '<div class="schedule-item">' +
                       '<div class="schedule-header">' +
                       '<span class="schedule-title">' + (schedule.schedule_title || '') + '</span>' +
                       '<span class="schedule-time" onclick="editSchedule(\'gongzuoshijian\', ' + schedule.id + ')">' +
                       (schedule.gongzuoshijianks || '') + ' - ' + (schedule.gongzuoshijianjs || '') +
                       '</span>' +
                       '</div>' +
                       '<div class="schedule-details">' +
                       '<span class="schedule-date" onclick="editSchedule(\'work_days\', ' + schedule.id + ')">' +
                       '📅 点击编辑日期 (' + (schedule.work_days ? schedule.work_days.length : 0) + '天)' +
                       '</span>' +
                       '<span class="schedule-break" onclick="editSchedule(\'wuxiushijian\', ' + schedule.id + ')">' +
                       '午休：' + (schedule.wuxiushijianks || '') + ' - ' + (schedule.wuxiushijianjs || '') +
                       '</span>' +
                       '</div>' +
                       '<div class="schedule-footer">' +
                       '<span>' +
                       '</span>' +
                       '<button class="btn-delete" onclick="deleteSchedule(' + schedule.id + ')">删除</button>' +
                       '</div>' +
                       '</div>';
            });
            
            if (scheduleList.length === 0) {
                html = '<div style="text-align:center;color:#999;padding:20px;">暂无工作安排</div>';
            }
            
            $('#scheduleList').html(html);
        }
        
        // 编辑工作安排
        function editSchedule(field, scheduleId) {
            var schedule = scheduleList.find(function(s) {
                return s.id == scheduleId;
            });
            
            if (!schedule) return;
            
            if (field === 'work_days') {
                openCalendarEditModal(schedule);
            } else if (field === 'gongzuoshijian') {
                openTimeEditModal(schedule, 'gongzuoshijian');
            } else if (field === 'wuxiushijian') {
                openTimeEditModal(schedule, 'wuxiushijian');
            }
        }
        
        // 打开日历编辑弹窗
        function openCalendarEditModal(schedule) {
            $('#editScheduleData').val(JSON.stringify(schedule));
            $('#editSelectedDates').val(JSON.stringify(schedule.work_days || []));
            
            // 初始化编辑日历
            generateEditCalendar(currentYear, currentMonth);
            
            $('#calendarEditModal').show();
        }
        
        // 生成编辑日历
        function generateEditCalendar(year, month) {
            var days = [];
            var firstDay = new Date(year, month - 1, 1);
            var lastDay = new Date(year, month, 0);
            var daysInMonth = lastDay.getDate();
            var firstDayWeek = firstDay.getDay() || 7;
            
            // 获取选中的日期
            var editSelectedDates = [];
            try {
                editSelectedDates = JSON.parse($('#editSelectedDates').val() || '[]');
            } catch(e) {
                editSelectedDates = [];
            }
            
            // 添加上个月的最后几天
            var prevMonthLastDay = new Date(year, month - 1, 0).getDate();
            for (var i = firstDayWeek - 1; i > 0; i--) {
                var date = new Date(year, month - 2, prevMonthLastDay - i + 1);
                var dateStr = formatDate(date);
                var isSelected = editSelectedDates.includes(dateStr);
                
                days.push({
                    date: date,
                    day: date.getDate(),
                    month: month - 1,
                    year: date.getFullYear(),
                    isCurrentMonth: false,
                    isToday: false,
                    isSelected: isSelected,
                    dateStr: dateStr
                });
            }
            
            // 添加当前月
            var today = new Date();
            for (var i = 1; i <= daysInMonth; i++) {
                var date = new Date(year, month - 1, i);
                var dateStr = formatDate(date);
                var isSelected = editSelectedDates.includes(dateStr);
                
                days.push({
                    date: date,
                    day: i,
                    month: month,
                    year: year,
                    isCurrentMonth: true,
                    isToday: date.toDateString() === today.toDateString(),
                    isSelected: isSelected,
                    dateStr: dateStr
                });
            }
            
            // 添加下个月的前几天
            var totalCells = 42;
            var remainingCells = totalCells - days.length;
            for (var i = 1; i <= remainingCells; i++) {
                var date = new Date(year, month, i);
                var dateStr = formatDate(date);
                var isSelected = editSelectedDates.includes(dateStr);
                
                days.push({
                    date: date,
                    day: i,
                    month: month + 1,
                    year: date.getFullYear(),
                    isCurrentMonth: false,
                    isToday: false,
                    isSelected: isSelected,
                    dateStr: dateStr
                });
            }
            
            var calendarHtml = '';
            days.forEach(function(day, index) {
                var dayClass = 'edit-calendar-day';
                if (day.isCurrentMonth) dayClass += ' current-month';
                if (!day.isCurrentMonth) dayClass += ' other-month';
                if (day.isSelected) dayClass += ' selected';
                
                calendarHtml += '<div class="' + dayClass + '" onclick="selectEditDate(\'' + day.dateStr + '\', ' + index + ')">' +
                               '<span class="day-text">' + day.day + '</span>' +
                               '</div>';
            });
            
            $('#editCalendarGrid').html(calendarHtml);
            $('#editCurrentMonth').text(year + '年' + month + '月');
        }
        
        // 在编辑日历中选择日期
        function selectEditDate(dateStr, index) {
            var editSelectedDates = [];
            try {
                editSelectedDates = JSON.parse($('#editSelectedDates').val() || '[]');
            } catch(e) {
                editSelectedDates = [];
            }
            
            if (editSelectedDates.includes(dateStr)) {
                editSelectedDates = editSelectedDates.filter(function(date) {
                    return date !== dateStr;
                });
            } else {
                editSelectedDates.push(dateStr);
            }
            
            editSelectedDates = [...new Set(editSelectedDates)];
            $('#editSelectedDates').val(JSON.stringify(editSelectedDates));
            
            generateEditCalendar(currentYear, currentMonth);
            updateEditSelectedDatesDisplay(editSelectedDates);
        }
        
        // 更新编辑选中日期显示
        function updateEditSelectedDatesDisplay(dates) {
            var html = '<span class="preview-title">已选日期：</span><div class="selected-dates-scroll"><div class="selected-dates-grid">';
            
            if (dates.length === 0) {
                html += '<span class="empty-tip">暂无选择日期</span>';
            } else {
                dates.forEach(function(date) {
                    html += '<span class="selected-date-tag">' + date + '</span>';
                });
            }
            
            html += '</div></div>';
            $('#editSelectedDatesDisplay').html(html);
        }
        
        // 编辑弹窗上个月
        function prevEditMonth() {
            currentMonth--;
            if (currentMonth < 1) {
                currentYear--;
                currentMonth = 12;
            }
            generateEditCalendar(currentYear, currentMonth);
        }
        
        // 编辑弹窗下个月
        function nextEditMonth() {
            currentMonth++;
            if (currentMonth > 12) {
                currentYear++;
                currentMonth = 1;
            }
            generateEditCalendar(currentYear, currentMonth);
        }
        
        // 全选本月
        function selectAllInEditCalendar() {
            var editSelectedDates = [];
            try {
                editSelectedDates = JSON.parse($('#editSelectedDates').val() || '[]');
            } catch(e) {
                editSelectedDates = [];
            }
            
            calendarDays.forEach(function(day) {
                if (day.isCurrentMonth) {
                    if (!editSelectedDates.includes(day.dateStr)) {
                        editSelectedDates.push(day.dateStr);
                    }
                }
            });
            
            editSelectedDates = [...new Set(editSelectedDates)];
            $('#editSelectedDates').val(JSON.stringify(editSelectedDates));
            
            generateEditCalendar(currentYear, currentMonth);
            updateEditSelectedDatesDisplay(editSelectedDates);
        }
        
        // 清空选择
        function clearAllInEditCalendar() {
            $('#editSelectedDates').val('[]');
            generateEditCalendar(currentYear, currentMonth);
            updateEditSelectedDatesDisplay([]);
        }
        
        // 保存日历编辑
        function saveCalendarEdit() {
            var scheduleData = null;
            try {
                scheduleData = JSON.parse($('#editScheduleData').val());
            } catch(e) {
                alert('数据错误');
                return;
            }
            
            var editSelectedDates = [];
            try {
                editSelectedDates = JSON.parse($('#editSelectedDates').val() || '[]');
            } catch(e) {
                editSelectedDates = [];
            }
            
            $.ajax({
                url: 'gongzuoshijian.aspx',
                type: 'POST',
                data: {
                    action: 'updateworkdays',
                    id: scheduleData.id,
                    work_days: JSON.stringify(editSelectedDates)
                },
                success: function(data) {
                    try {
                        if (data.success) {
                            alert('保存成功');
                            $('#calendarEditModal').hide();
                            loadSchedules();
                        } else {
                            alert('保存失败：' + data.message);
                        }
                    } catch(e) {
                        alert('保存失败');
                    }
                }
            });
        }
        
        // 打开时间编辑弹窗
        function openTimeEditModal(schedule, field) {
            $('#timeEditScheduleData').val(JSON.stringify(schedule));
            $('#timeEditField').val(field);
            
            if (field === 'gongzuoshijian') {
                $('#timeEditTitle').text('编辑工作时间');
                $('#timeEditStart').val(schedule.gongzuoshijianks || '');
                $('#timeEditEnd').val(schedule.gongzuoshijianjs || '');
            } else if (field === 'wuxiushijian') {
                $('#timeEditTitle').text('编辑午休时间');
                $('#timeEditStart').val(schedule.wuxiushijianks || '');
                $('#timeEditEnd').val(schedule.wuxiushijianjs || '');
            }
            
            $('#timeEditModal').show();
        }
        
        // 保存时间编辑
        function saveTimeEdit() {
            var scheduleData = null;
            try {
                scheduleData = JSON.parse($('#timeEditScheduleData').val());
            } catch(e) {
                alert('数据错误');
                return;
            }
            
            var field = $('#timeEditField').val();
            var startTime = $('#timeEditStart').val();
            var endTime = $('#timeEditEnd').val();
            
            if (!startTime || !endTime) {
                alert('请填写完整的时间');
                return;
            }
            
            $.ajax({
                url: 'gongzuoshijian.aspx',
                type: 'POST',
                data: {
                    action: 'updatetime',
                    id: scheduleData.id,
                    field: field,
                    startTime: startTime,
                    endTime: endTime
                },
                success: function(data) {
                    try {
                        if (data.success) {
                            alert('保存成功');
                            $('#timeEditModal').hide();
                            loadSchedules();
                        } else {
                            alert('保存失败：' + data.message);
                        }
                    } catch(e) {
                        alert('保存失败');
                    }
                }
            });
        }
        
        // 删除工作安排
        function deleteSchedule(id) {
            if (!confirm('确定要删除这个工作安排吗？')) {
                return;
            }
            
            $.ajax({
                url: 'gongzuoshijian.aspx',
                type: 'POST',
                data: {
                    action: 'deleteschedule',
                    id: id
                },
                success: function(data) {
                    try {
                        if (data.success) {
                            alert('删除成功');
                            loadSchedules();
                        } else {
                            alert('删除失败：' + data.message);
                        }
                    } catch(e) {
                        alert('删除失败');
                    }
                }
            });
        }
        
        // 打开日期范围选择弹窗
        function showDateRangeModal() {
            $('#dateRangeModal').show();
            calculateDateRange();
        }
        
        // 计算日期范围
        function calculateDateRange() {
            var startDate = $('#rangeStartDate').val();
            var endDate = $('#rangeEndDate').val();
            var filterOption = $('input[name="filterOption"]:checked').val();
            
            if (!startDate || !endDate) return;
            
            var start = new Date(startDate);
            var end = new Date(endDate);
            
            if (start > end) {
                alert('起始日期不能晚于截止日期');
                return;
            }
            
            var dates = [];
            var current = new Date(start);
            
            while (current <= end) {
                var dateStr = formatDate(current);
                var dayOfWeek = current.getDay();
                
                var shouldInclude = true;
                switch (filterOption) {
                    case 'excludeSat':
                        shouldInclude = dayOfWeek !== 6;
                        break;
                    case 'excludeSun':
                        shouldInclude = dayOfWeek !== 0;
                        break;
                    case 'weekends':
                        shouldInclude = dayOfWeek === 0 || dayOfWeek === 6;
                        break;
                    case 'weekdays':
                        shouldInclude = dayOfWeek >= 1 && dayOfWeek <= 5;
                        break;
                    case 'all':
                    default:
                        shouldInclude = true;
                        break;
                }
                
                if (shouldInclude) {
                    dates.push(dateStr);
                }
                
                current.setDate(current.getDate() + 1);
            }
            
            var previewHtml = '';
            if (dates.length > 30) {
                previewHtml = dates.slice(0, 30).map(function(date) {
                    return '<span class="preview-date-tag">' + date + '</span>';
                }).join('');
                previewHtml += '<span class="preview-more">...等' + dates.length + '天</span>';
            } else {
                previewHtml = dates.map(function(date) {
                    return '<span class="preview-date-tag">' + date + '</span>';
                }).join('');
            }
            
            $('#filteredDatesDisplay').html(previewHtml);
            $('#filteredDatesCount').text(dates.length);
            $('#filteredDates').val(JSON.stringify(dates));
        }
        
        // 应用日期范围选择
        function applyDateRange() {
            var dates = [];
            try {
                dates = JSON.parse($('#filteredDates').val() || '[]');
            } catch(e) {
                dates = [];
            }
            
            if (dates.length === 0) {
                alert('请选择有效日期范围');
                return;
            }
            
            selectedDates = dates;
            updateCalendarDisplay();
            updateSelectedDatesDisplay();
            
            if (selectedDates.length > 0) {
                $('#timePanel').show();
            }
            
            alert('已选择 ' + dates.length + ' 天');
            $('#dateRangeModal').hide();
        }
        
      
        
        // 重置表单
        function resetForm() {
            selectedDates = [];
            $('#scheduleTitle').val('');
            $('#startTime').val('08:00');
            $('#endTime').val('17:00');
            $('#breakStart').val('12:00');
            $('#breakEnd').val('13:00');
            $('#timePanel').hide();
            $('#selectedDatesDisplay').hide();
            updateCalendarDisplay();
        }
        
        // 切换时间设置面板
        function toggleTimePicker() {
            if (selectedDates.length === 0) {
                alert('请先选择日期');
                return;
            }
            
            var panel = $('#timePanel');
            if (panel.is(':visible')) {
                panel.hide();
            } else {
                panel.show();
            }
        }
        
        // 关闭模态框
        function closeModal(modalId) {
            $('#' + modalId).hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="ti">
            <h1>工作时间安排</h1>
        </div>
        
        <div class="header-top">
            <button type="button" onclick="showDateRangeModal()" class="top_bt">日期范围选择</button>
            <button type="button" onclick="toggleTimePicker()" class="top_bt">新建安排</button>
        </div>
        
        <div style="display:flex;justify-content: space-around; " >
        <!-- 日历容器 -->
        <div class="calendar-container">
            <div class="calendar-header">
                <div class="calendar-nav">
                    <button type="button" class="nav-btn" onclick="prevMonth()">‹</button>
                    <span class="current-month" id="currentMonth"><%= DateTime.Now.Year %>年<%= DateTime.Now.Month %>月</span>
                    <button type="button" class="nav-btn" onclick="nextMonth()">›</button>
                </div>
            </div>
            
            <!-- 星期头部 -->
            <div class="week-header">
                <span class="week-day">一</span>
                <span class="week-day">二</span>
                <span class="week-day">三</span>
                <span class="week-day">四</span>
                <span class="week-day">五</span>
                <span class="week-day">六</span>
                <span class="week-day">日</span>
            </div>
            
            <!-- 日历网格 -->
            <div class="calendar-grid" id="calendarGrid">
                <!-- 日历将通过JS动态生成 -->
            </div>
        </div>

        <!-- 工作安排列表 -->
        <div class="schedule-list">
            <div class="section-title">工作安排列表</div>
            <div id="scheduleList">
                <!-- 工作安排将通过JS动态生成 -->
            </div>
        </div>
        </div>
        
        <!-- 选中日期显示 -->
        <div class="selected-dates" id="selectedDatesDisplay" style="display:none;">
            <!-- 选中日期将通过JS动态生成 -->
        </div>
        
        <!-- 时间设置面板 -->
        <div class="time-panel" id="timePanel" style="display:none;">
            <div class="panel-title">工作时间设置</div>
            
            <div class="form-group">
                <label class="form-label">排班标题</label>
                <input type="text" id="scheduleTitle" class="form-input" placeholder="请输入排班标题" />
            </div>
            
            <div class="form-group">
                <label class="form-label">工作时间</label>
                <div class="time-range-group">
                    <input type="time" id="startTime" class="form-input" value="08:00" />
                    <span class="time-separator">至</span>
                    <input type="time" id="endTime" class="form-input" value="17:00" />
                </div>
            </div>
            
            <div class="form-group">
                <label class="form-label">午休时间</label>
                <div class="break-time-group">
                    <input type="time" id="breakStart" class="form-input" value="12:00" />
                    <span class="time-separator">至</span>
                    <input type="time" id="breakEnd" class="form-input" value="13:00" />
                </div>
            </div>
            
            
            <div class="action-buttons" style="display:flex;gap:10px;">
                <button type="button" onclick="resetForm()" class="btn-modal-cancel">取消</button>
                <button type="button" onclick="saveSchedule()" class="btn-modal-save">保存安排</button>
            </div>
        </div>
        

        
        <!-- 日历编辑弹窗 -->
        <div class="modal" id="calendarEditModal">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">编辑工作日期</div>
                    <span class="close-modal" onclick="closeModal('calendarEditModal')">×</span>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="editScheduleData" />
                    <input type="hidden" id="editSelectedDates" />
                    
                    <div class="calendar-header">
                        <div class="calendar-nav">
                            <button type="button" class="nav-btn" onclick="prevEditMonth()">‹</button>
                            <span class="current-month" id="editCurrentMonth"><%= DateTime.Now.Year %>年<%= DateTime.Now.Month %>月</span>
                            <button type="button" class="nav-btn" onclick="nextEditMonth()">›</button>
                        </div>
                    </div>
                    
                    <div class="week-header">
                        <span class="week-day">一</span>
                        <span class="week-day">二</span>
                        <span class="week-day">三</span>
                        <span class="week-day">四</span>
                        <span class="week-day">五</span>
                        <span class="week-day">六</span>
                        <span class="week-day">日</span>
                    </div>
                    
                    <div class="edit-calendar-grid" id="editCalendarGrid">
                        <!-- 编辑日历将通过JS动态生成 -->
                    </div>
                    
                    <div class="quick-actions">
                        <button type="button" class="btn-quick" onclick="selectAllInEditCalendar()">全选本月</button>
                        <button type="button" class="btn-quick" onclick="clearAllInEditCalendar()">清空选择</button>
                    </div>
                    
                    <div class="selected-preview" id="editSelectedDatesDisplay">
                        <!-- 选中日期预览将通过JS动态生成 -->
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-modal-cancel" onclick="closeModal('calendarEditModal')">取消</button>
                    <button type="button" class="btn-modal-save" onclick="saveCalendarEdit()">保存修改</button>
                </div>
            </div>
        </div>
        
        <!-- 时间编辑弹窗 -->
        <div class="modal" id="timeEditModal">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title" id="timeEditTitle">编辑工作时间</div>
                    <span class="close-modal" onclick="closeModal('timeEditModal')">×</span>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="timeEditScheduleData" />
                    <input type="hidden" id="timeEditField" />
                    
                    <div class="form-group">
                        <label class="form-label" id="timeLabel">工作时间</label>
                        <div class="time-range-group">
                            <input type="time" id="timeEditStart" class="form-input" />
                            <span class="time-separator">至</span>
                            <input type="time" id="timeEditEnd" class="form-input" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-modal-cancel" onclick="closeModal('timeEditModal')">取消</button>
                    <button type="button" class="btn-modal-save" onclick="saveTimeEdit()">保存修改</button>
                </div>
            </div>
        </div>
        
        <!-- 日期范围选择弹窗 -->
        <div class="modal" id="dateRangeModal">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="modal-title">选择日期范围</div>
                    <span class="close-modal" onclick="closeModal('dateRangeModal')">×</span>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="form-label">起始日期</label>
                        <input type="date" id="rangeStartDate" class="form-input" onchange="calculateDateRange()" />
                    </div>
                    
                    <div class="form-group">
                        <label class="form-label">截止日期</label>
                        <input type="date" id="rangeEndDate" class="form-input" onchange="calculateDateRange()" />
                    </div>
                    
                    <div class="filter-options">
                        <span class="options-title">日期筛选：</span>
                        <div class="option-group">
                            <div class="option-item">
                                <input type="radio" id="filterAll" name="filterOption" value="all" checked onchange="calculateDateRange()" />
                                <label class="option-label" for="filterAll">全选</label>
                            </div>
                            <div class="option-item">
                                <input type="radio" id="filterExcludeSat" name="filterOption" value="excludeSat" onchange="calculateDateRange()" />
                                <label class="option-label" for="filterExcludeSat">排除周六</label>
                            </div>
                            <div class="option-item">
                                <input type="radio" id="filterExcludeSun" name="filterOption" value="excludeSun" onchange="calculateDateRange()" />
                                <label class="option-label" for="filterExcludeSun">排除周日</label>
                            </div>
                            <div class="option-item">
                                <input type="radio" id="filterWeekends" name="filterOption" value="weekends" onchange="calculateDateRange()" />
                                <label class="option-label" for="filterWeekends">仅双休日</label>
                            </div>
                            <div class="option-item">
                                <input type="radio" id="filterWeekdays" name="filterOption" value="weekdays" onchange="calculateDateRange()" />
                                <label class="option-label" for="filterWeekdays">仅工作日</label>
                            </div>
                        </div>
                    </div>
                    
                    <div class="preview-section">
                        <span class="preview-title">预览（共 <span id="filteredDatesCount">0</span> 天）：</span>
                        <div class="preview-dates">
                            <div class="preview-grid" id="filteredDatesDisplay">
                                <!-- 预览日期将通过JS动态生成 -->
                            </div>
                        </div>
                    </div>
                    
                    <input type="hidden" id="filteredDates" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-modal-cancel" onclick="closeModal('dateRangeModal')">取消</button>
                    <button type="button" class="btn-modal-save" onclick="applyDateRange()">确定</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>