<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chart.aspx.cs" Inherits="Web.finance.web.view.chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/chart.css"/>

    <script type="text/javascript" src="../assets/js/Jquery.js"></script>
    
    <script type="text/javascript" src="../assets/js/EChart/echarts.js"></script>
    <script type="text/javascript" src="../assets/js/EChart/shine.js"></script>

    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/chart.js"></script>

    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/subject_ledger.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/demo/demo.css"/>

    <script type="text/javascript" src="../assets/js/EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/locale/easyui-lang-zh_CN.js"></script>

</head>
<body>
    <div style="padding-top:20px;padding-left:20px;padding-bottom:10px">
        <div class="form-item">
		    <label for="voucherDate">开始时间：</label>
		    <input id="start_date" type="text" class="easyui-datebox">
            <label for="voucherDate">  结束时间：</label>
		    <input id="stop_date" type="text" class="easyui-datebox">
            <a class="easyui-linkbutton btn-right l-btn-icon-left " data-options="iconCls:'icon-search',width:80" onclick="selectBtn()" style="margin-left:10px">查询</a>
        </div>
    </div>
    <div id="main-item">
        <div class="chart-item1">
            <label for="nianchu">年初余额：</label>
            <label for="heji1" style="margin-left:10px">借金合计</label>
            <span id="jiejinheji">0</span>
            <label for="heji2" style="margin-left:5px">贷金合计</label>
            <span id="daijinheji">0</span>
        </div>
        <div class="chart-item1">
            <label for="kemu">科目余额：</label>
            <label for="heji1" style="margin-left:10px">借方合计</label>
            <span id="jiefangheji">0</span>
            <label for="heji2" style="margin-left:5px">贷方合计</label>
            <span id="daifangheji">0</span>
        </div>
        <div class="chart-item">
            <div id="accounting"></div>
        </div>
        <div class="chart-item">
            <div id="summary"></div>
        </div>
        <div class="chart-item">
            <div id="accountingBalance"></div>
        </div>
        <div class="chart-item">
            <div id="liabilities"></div>
        </div>
        <div class="chart-item">
            <div id="profit"></div>
        </div>
        <div class="chart-item">
            <div id="flow"></div>
        </div>
    </div>
</body>
</html>
