<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simpleData.aspx.cs" Inherits="Web.finance.web.view.simpleData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

    <!-- 修改窗口 -->
    <div id="upd-simpleData-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="upd-simpleData-form">
            <div class="form-item">
                <label>日期:</label>
                <input id="upd_insert_date" name="insert_date" class="easyui-datetimebox" data-options="width: 318,height: 38"/>
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
                <input id="upd-receivable" class="easyui-numberbox" name="receivable" data-options="width: 248,height: 38,precision:2"/>
                <button type="button" class="btn-small" onclick="setReceivableValueUltimate()" style="margin-left: 5px;height: 38px;">计算</button>
            </div>
            <div class="form-item">
                <label>实收:</label>
                <input class="easyui-numberbox" name="receipts" data-options="width: 318,height: 38,precision:2"/>
            </div>
            <div class="form-item">
                <label>应付:</label>
                <input id="upd-cope" class="easyui-numberbox" name="cope" data-options="width: 248,height: 38,precision:2"/>
                <button type="button" class="btn-small" onclick="setCopeValueUltimate()" style="margin-left: 5px;height: 38px;">计算</button>
            </div>
            <div class="form-item">
                <label>实付:</label>
                <input class="easyui-numberbox" name="payment" data-options="width: 318,height: 38,precision:2"/>
            </div>
            <div class="form-item">
                <label>已交税金额:</label>
                <input id="upd-yijiaoshuijine" class="easyui-numberbox" name="yijiaoshuijine" data-options="width: 248,height: 38,precision:2"/>
                <button type="button" class="btn-small" onclick="openTaxCalculator('receivable')" style="margin-left: 5px;height: 38px;">计算</button>
            </div>
            <div class="form-item">
                <label>纳税金额:</label>
                <input id="upd-nashuijine" class="easyui-numberbox" name="nashuijine" data-options="width: 318,height: 38,precision:2,readonly:true"/>
                <span style="color:#666;font-size:12px;"></span>
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

    <!-- 新增窗口 -->
    <div id="add-simpleData-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="add-simpleData-form">
            <div class="form-item">
                <label>日期:</label>
                <input id="add_insert_date" name="insert_date" class="easyui-datetimebox"/>
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
                <input id="add-receivable" class="easyui-numberbox" name="receivable" data-options="width: 248,height: 38,precision:2"/>
                <button type="button" class="btn-small" onclick="setReceivableValueUltimate()" style="margin-left: 5px;height: 38px;">计算</button>
            </div>
            <div class="form-item">
                <label>实收:</label>
                <input class="easyui-numberbox" name="receipts" data-options="width: 318,height: 38,precision:2"/>
            </div>
            <div class="form-item">
                <label>应付:</label>
                <input id="add-cope" class="easyui-numberbox" name="cope" data-options="width: 248,height: 38,precision:2"/>
                <button type="button" class="btn-small" onclick="setCopeValueUltimate()" style="margin-left: 5px;height: 38px;">计算</button>
            </div>

            <div class="form-item">
                <label>已交税金额:</label>
                <input id="add-yijiaoshuijine" class="easyui-numberbox" name="yijiaoshuijine" data-options="width: 248,height: 38,precision:2"/>
                <button type="button" class="btn-small" onclick="openTaxCalculator('receivable')" style="margin-left: 5px;height: 38px;">计算</button>
            </div>
            <div class="form-item">
                <label>纳税金额:</label>
                <input id="add-nashuijine" class="easyui-numberbox" name="nashuijine" data-options="width: 318,height: 38,precision:2,readonly:true"/>
                <span style="color:#666;font-size:12px;"></span>
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

    <!-- 计算弹窗 -->
    <!-- 计算弹窗 -->
<div id="tax-calculator-window" style="display: none;">
    <div style="padding: 20px;">
        <form id="tax-calculator-form">
            <div class="form-item">
                <label>计算类型:</label>
                <select id="calculation-type" class="easyui-combobox" style="width:200px;height:35px;">
                    <option value="receivable">应收</option>
                    <option value="receipts">实收</option>
                    <option value="profit">利润</option>
                </select>
                <span style="color:#666;font-size:12px;margin-left:5px;">（自动获取表单值）</span>
            </div>
            <div class="form-item">
                <label>计算数值:</label>
                <input id="calculation-value" class="easyui-numberbox" style="width:200px;height:35px;" data-options="precision:2,required:true,readonly:true"/>
                <span style="color:#666;font-size:12px;margin-left:5px;">（自动填充，不可修改）</span>
            </div>
            <div class="form-item">
                <label>纳税金额:</label>
                <input id="calculated-tax" class="easyui-numberbox" style="width:200px;height:35px;" data-options="precision:2,readonly:true"/>
            </div>
            <div class="form-item form-item-btn" style="margin-top: 20px;">
                <button type="button" class="btn" onclick="performCalculation()">计算</button>
                <button type="button" class="btn" onclick="applyTaxCalculation()">应用</button>
                <button type="button" class="btn" onclick="$('#tax-calculator-window').window('close')">取消</button>
            </div>
            <div class="form-note" style="color:#666;font-size:12px;margin-top:10px;">
                说明：选择计算类型后自动获取表单对应值，点击"计算"得到纳税金额，点击"应用"填入表单
            </div>
        </form>
    </div>
</div>
</body>
</html>