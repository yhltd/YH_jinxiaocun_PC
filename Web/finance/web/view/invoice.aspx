<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="Web.finance.web.view.invoice" %>

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
    <script type="text/javascript" src="../assets/js/invoice.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <label>往来单位:</label>
            <input id="unit" class="easyui-textbox" value=""/>
            <label>开始日期:</label>
            <input id="ks" class="easyui-datebox" value=""/>
            <label>结束日期:</label>
            <input id="js" class="easyui-datebox" value=""/>
            <a href="#" class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-search',width:80" onclick="getList(); return false;">查询</a>
            <a class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="upd-invoice-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="upd-invoice-form">
            <div class="form-item">
                <label>类型:</label>
                <select id="upd-type" name="type" class="easyui-combobox" data-options="width: 318,height: 38">
                    <option value="进项发票">进项发票</option>
                    <option value="销项发票">销项发票</option>
                </select>
            </div>
            <div class="form-item">
                <label>日期:</label>
		        <input class="easyui-datebox" name="riqi" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>摘要:</label>
		        <input class="easyui-textbox" name="zhaiyao" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>往来单位:</label>
		        <input class="easyui-textbox" id="upd_unit" name="unit" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>发票种类:</label>
		        <input class="easyui-textbox" id="upd_invoice_type" name="invoice_type" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>发票号码:</label>
		        <input class="easyui-textbox" name="invoice_no" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>金额:</label>
		        <input class="easyui-numberbox" name="jine" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>备注:</label>
		        <input class="easyui-textbox" name="remarks" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset('upd-invoice-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="add-invoice-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="add-invoice-form">
            <div class="form-item">
                <label>类型:</label>
                <select id="add-type" name="type" class="easyui-combobox" data-options="width: 318,height: 38">
                    <option value="进项发票">进项发票</option>
                    <option value="销项发票">销项发票</option>
                </select>
            </div>
            <div class="form-item">
                <label>日期:</label>
		        <input id="add-riqi" name="riqi" class="easyui-datebox" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>摘要:</label>
		        <input id="add-zhaiyao" name="zhaiyao" class="easyui-textbox" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>往来单位:</label>
		        <input class="easyui-textbox" id="add_unit" name="unit" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>发票种类:</label>
		        <input class="easyui-textbox" id="add_invoice_type" name="invoice_type" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>发票号码:</label>
		        <input class="easyui-textbox" name="invoice_no" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>金额:</label>
		        <input class="easyui-numberbox" name="jine" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>备注:</label>
		        <input class="easyui-textbox" name="remarks" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toAdd()" class="btn" type="button">确认新增</button>
                <button onclick="javascript:toReset('add-invoice-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>
