<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="voucherSummary.aspx.cs" Inherits="Web.finance.web.view.web_service.voucherSummary1" %>

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
    <script type="text/javascript" src="../assets/js/EasyUI/datagrid-export.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/locale/easyui-lang-zh_CN.js"></script>

    <link rel="stylesheet" type="text/css" href="../assets/css/voucherSummary.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/voucherSummary.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <span>凭证字：</span>
            <input id="word" value=""/>
            <span>录入时间-开始：</span>
            <input id="start_date"class="easyui-datebox" value=""/>
            <span>录入时间-结束：</span>
            <input id="stop_date" class="easyui-datebox" value=""/>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="selectBtn()">查询</a>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="upd-voucherSummary-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="upd-voucherSummary-form">
            <div class="form-item">
		        <label for="word">凭证字:</label>
		        <input id="upd-word" name="word"/>
            </div>
            <div class="form-item">
		        <label for="no">凭证号:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="no"/>
            </div>
            <div class="form-item">
		        <label for="voucherDate">录入时间:</label>
		        <input id="upd-voucherDate" name="voucherDate"/>
            </div>
            <div class="form-item">
		        <label for="abstract">摘要:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="abstract"/>
            </div>
            <div class="form-item">
		        <label for="code">科目代码:</label>
		        <input id="upd-code" class="input easyui-validatebox" autocomplete="off" onfocus="openSubject('upd-code')" type="text" name="code"/>
            </div>
            <div class="form-item">
		        <label for="money">借贷金额:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="number" name="money"/>
            </div>
            <div class="form-item">
		        <label for="department">部门:</label>
		        <input id="upd-department" name="department"/>
            </div>
            <div class="form-item">
		        <label for="expenditure">开支项目:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="expenditure"/>
            </div>
            <div class="form-item">
		        <label for="note">备注:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="note"/>
            </div>
            <div class="form-item">
		        <label for="real">实收/付:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="number" name="real"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpdVoucherSummary()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toResetUpdVoucherSummary()" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="add-voucherSummary-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="add-voucherSummary-form">
            <div class="form-item">
		        <label for="word">凭证字:</label>
		        <input id="add-word" name="word"/>
            </div>
            <div class="form-item">
		        <label for="no">凭证号:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="no"/>
            </div>
            <div class="form-item">
		        <label for="voucherDate">录入时间:</label>
		        <input id="add-voucherDate" name="voucherDate"/>
            </div>
            <div class="form-item">
		        <label for="abstract">摘要:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="abstract"/>
            </div>
            <div class="form-item">
		        <label for="code">科目代码:</label>
		        <input id="add-code" class="input easyui-validatebox" autocomplete="off" onfocus="openSubject('add-code')" type="text" name="code"/>
            </div>
            <div class="form-item">
		        <label for="money">借贷金额:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="number" name="money"/>
            </div>
            <div class="form-item">
		        <label for="department">部门:</label>
		        <input id="add-department" name="department"/>
            </div>
            <div class="form-item">
		        <label for="expenditure">开支项目:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="expenditure"/>
            </div>
            <div class="form-item">
		        <label for="note">备注:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="note"/>
            </div>
            <div class="form-item">
		        <label for="real">实收/付:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="number" name="real"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toAddVoucherSummary()" class="btn" type="button">确认新增</button>
                <button onclick="javascript:toResetAddVoucherSummary()" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="examine-voucherSummary-window" style="display: none">
        <form id="examine-voucherSummary-form">
            <div class="form-item">
		        <label for="do">操作密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" name="do"/>
            </div>
            <%--<div class="form-item">
		        <label for="examineName">审核人姓名:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="examineName" readonly="readonly"/>
            </div>--%>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toExamineVoucherSummary()" class="btn" type="button">审核</button>
            </div>
        </form>
    </div>

    <div id="subject-window" style="display: none;padding: 20px">
        <div class="subject-item">
            <span>科目类别：</span>
            <input id="clases" value=""/>
            <span style="margin-left: 20px">科目等级：</span>
            <input id="grades" value=""/>
        </div>
        
        <div id="subject-list" style="margin-bottom: 20px"></div>

        <span>当前选择科目代码：</span>
        <span id="choiceCode"></span>
        <a class="easyui-linkbutton btn-right" data-options="width:65" onclick="submitCode()">确定</a>
    </div> 
</body>
</html>
