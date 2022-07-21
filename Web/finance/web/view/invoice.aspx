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
            <a href="#" class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="selectBtn()">查询</a>
        </div>
        <div class="main-item">
            <div id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="upd-simpleData-window" style="display: none">
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
		        <input class="easyui-textbox" name="kehu" data-options="width: 318,height: 38"/>
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

    <div id="add-invoice-window" style="display: none">
        <form id="add-invoice-form">
            <div class="form-item">
                <label>类型:</label>
                <select id="add-type" name="type">
                    <option value="进项发票">进项发票</option>
                    <option value="销项发票">销项发票</option>
                </select>
            </div>
            <div class="form-item">
                <label>日期:</label>
		        <input id="add-riqi" name="riqi"/>
            </div>
            <div class="form-item">
                <label>摘要:</label>
		        <input id="add-zhaiyao" name="zhaiyao"/>
            </div>
            <div class="form-item">
		        <label>往来单位:</label>
		        <input class="easyui-textbox" name="unit" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
		        <label>发票种类:</label>
		        <input class="easyui-textbox" name="kehu" data-options="width: 318,height: 38"/>
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
