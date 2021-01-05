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
</head>
<body>
    <div id="main-item">
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
