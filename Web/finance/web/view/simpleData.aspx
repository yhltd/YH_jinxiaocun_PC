<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simpleData.aspx.cs" Inherits="Web.finance.web.view.simpleData" %>

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
    <link rel="stylesheet" type="text/css" href="../assets/css/subject_ledger.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/simpleData.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <label>项目名称:</label>
            <input id="project" class="easyui-textbox" value=""/>
            <label>开始日期:</label>
            <input id="start_date" class="easyui-datebox" value=""/>
            <label>结束日期:</label>
            <input id="stop_date" class="easyui-datebox" value=""/>
            <a href="#" class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-search',width:80" onclick="selectBtn(); return false;">查询</a>
            <a class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="upd-simpleData-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="upd-simpleData-form">
            <div class="form-item">
                <label>日期:</label>
		        <input id="insert_date" name="insert_date" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>科目名称:</label>
		        <input id="upd-accounting" name="accounting"/>
            </div>
            <div class="form-item">
		        <label>项目名称:</label>
		        <input class="easyui-textbox" name="project" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>客户/供应商:</label>
		        <input class="easyui-textbox" id="upd_kehu" name="kehu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>应收:</label>
		        <input class="easyui-numberbox" name="receivable" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>实收:</label>
		        <input class="easyui-numberbox" name="receipts" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>应付:</label>
		        <input class="easyui-numberbox" name="cope" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>实付:</label>
		        <input class="easyui-numberbox" name="payment" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>摘要:</label>
		        <input class="easyui-textbox" name="zhaiyao" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset('upd-simpleData-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="add-simpleData-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="add-simpleData-form">
            <div class="form-item">
                <label>日期:</label>
		        <input id="add_insert_date" name="insert_date"/>
            </div>
            <div class="form-item">
                <label>科目名称:</label>
		        <input id="add-accounting" name="accounting"/>
            </div>
            <div class="form-item">
		        <label>项目名称:</label>
		        <input class="easyui-textbox" name="project" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>客户/供应商:</label>
		        <input class="easyui-textbox" id="add_kehu" name="kehu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>应收:</label>
		        <input class="easyui-numberbox" name="receivable" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>实收:</label>
		        <input class="easyui-numberbox" name="receipts" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>应付:</label>
		        <input class="easyui-numberbox" name="cope" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>实付:</label>
		        <input class="easyui-numberbox" name="payment" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>摘要:</label>
		        <input class="easyui-textbox" name="zhaiyao" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toAdd()" class="btn" type="button">确认新增</button>
                <button onclick="javascript:toReset('add-simpleData-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>
