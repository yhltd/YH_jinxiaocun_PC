<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flow.aspx.cs" Inherits="Web.finance.web.view.liabilities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/demo/demo.css"/>
    <script type="text/javascript" src="../assets/js/Jquery.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/locale/easyui-lang-zh_CN.js"></script>

    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/flow.js"></script>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <span>年：</span>
            <input id="year"class="easyui-numberbox" data-options="min:2000,max:2100" value=""/>
            <span>月：</span>
            <input id="month" class="easyui-numberbox" data-options="min:1,max:12" value=""/>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="selectBtn()">查询</a>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item">
            <div id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>
</body>
</html>
