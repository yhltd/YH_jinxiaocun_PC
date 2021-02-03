<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simpleAccounting.aspx.cs" Inherits="Web.finance.web.view.simpleAccounting" %>

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

    <link rel="stylesheet" type="text/css" href="../assets/css/simpleAccounting.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/simpleAccounting.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <label>科目名称:</label>
            <input id="accounting" class="easyui-textbox" value=""/>
            <a href="#" class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="selectBtn()">查询</a>
        </div>
        <div class="main-item">
            <div id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="add-accounting-window" style="display: none">
        <form id="add-accounting-form" style="align-items: start;padding: 15px;">
            <input class="easyui-textbox" style="width: 300px;height: 35px;" name="accounting" type="text"/>
            <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="toAdd()">保存</a>
        </form>
    </div>

    <div id="upd-accounting-window" style="display: none">
        <form id="upd-accounting-form" style="align-items: start;padding: 15px;">
            <input class="easyui-textbox" style="width: 300px;height: 35px;" name="accounting" type="text"/>
            <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="toUpd()">保存</a>
        </form>
    </div>
</body>
</html>
