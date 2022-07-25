<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YingShou.aspx.cs" Inherits="Web.finance.web.view.YingShou" %>

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
    <script type="text/javascript" src="../assets/js/YingShou.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <label>往来单位</label>
            <input id="kehu" class="easyui-textbox" value="" />
            <label>开始时间:</label>
            <input id="ks" class="easyui-datebox" value=""/>
            <label>结束时间:</label>
            <input id="js" class="easyui-datebox" value=""/>
            <a href="#" class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="getList()">查询</a>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item">
            <div id="data-table" class="easyui-datagrid"></div>
        </div>
    </div>
</body>
</html>
