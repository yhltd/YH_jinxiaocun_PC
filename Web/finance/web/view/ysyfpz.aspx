<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ysyfpz.aspx.cs" Inherits="Web.finance.web.view.ysyfpz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>应收应付配置</title>
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
    <script type="text/javascript" src="../assets/js/ysyfpz.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <label>应收应付:</label>
            <select id="ysyf" class="easyui-combobox" style="width: 120px;">
                <option value="">全部</option>
                <option value="应收">应收</option>
                <option value="应付">应付</option>
            </select>
            <label>项目名称:</label>
            <input id="xiangmumingcheng" class="easyui-textbox" value="" style="width: 120px;"/>
            <a href="#" class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-search',width:80" onclick="getList(); return false;">查询</a>
             <a href="#" class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-search',width:80" onclick="getList1(); return false;">刷新</a>
            <a class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="upd-ysyf-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="upd-ysyf-form">
            <div class="form-item">
                <label>应收应付:</label>
                <select id="upd-ysyf" name="ysyf" class="easyui-combobox" data-options="width: 318,height: 38">
                    <option value="应收">应收</option>
                    <option value="应付">应付</option>
                </select>
            </div>
            <div class="form-item">
                <label>项目名称:</label>
		        <input class="easyui-textbox" name="xiangmumingcheng" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>金额:</label>
		        <input class="easyui-textbox" name="jine" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>应收应付科目:</label>
		        <input class="easyui-textbox" name="ysyfkemu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset('upd-ysyf-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="add-ysyf-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="add-ysyf-form">
            <div class="form-item">
                <label>应收应付:</label>
                <select id="add-ysyf" name="ysyf" class="easyui-combobox" data-options="width: 318,height: 38">
                    <option value="应收">应收</option>
                    <option value="应付">应付</option>
                </select>
            </div>
            <div class="form-item">
                <label>项目名称:</label>
		        <input class="easyui-textbox" name="xiangmumingcheng" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>金额:</label>
		        <input class="easyui-textbox" name="jine" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>应收应付科目:</label>
		        <input class="easyui-textbox" name="ysyfkemu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toAdd()" class="btn" type="button">确认新增</button>
                <button onclick="javascript:toReset('add-ysyf-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>