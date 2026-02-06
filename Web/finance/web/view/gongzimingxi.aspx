<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongzimingxi.aspx.cs" Inherits="Web.finance.web.view.gongzimingxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>工资明细管理</title>
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
    <script type="text/javascript" src="../assets/js/gongzimingxi.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <label>姓名:</label>
            <input id="renming" class="easyui-textbox" value="" style="width: 120px;"/>
            <label>备注:</label>
            <input id="beizhu" class="easyui-textbox" value="" style="width: 120px;"/>
            <a href="#" class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-search',width:80" onclick="getList(); return false;">查询</a>
            <a class="easyui-linkbutton btn-right l-btn-icon-left" data-options="iconCls:'icon-print',width:120" onclick="toExcel()" style="display:none">导出Excel</a>
        </div>
        <div class="main-item">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="upd-gongzi-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="upd-gongzi-form">
            <div class="form-item">
                <label>姓名:</label>
		        <input class="easyui-textbox" name="renming" data-options="width: 318,height: 38,required:true"/>
            </div>
            <div class="form-item">
                <label>时间:</label>
		        <input class="easyui-datebox" name="shijian" data-options="width: 318,height: 38,required:true"/>
            </div>
            <div class="form-item">
                <label>工资:</label>
		        <input class="easyui-numberbox" name="kkqgongzi" data-options="width: 318,height: 38,precision:2,required:true"/>
            </div>
            <div class="form-item">
                <label>扣款:</label>
		        <input class="easyui-numberbox" name="koukuan" data-options="width: 318,height: 38,precision:2,required:true"/>
            </div>
            <div class="form-item">
                <label>已付:</label>
		        <input class="easyui-numberbox" name="yifu" data-options="width: 318,height: 38,precision:2,required:true"/>
            </div>
            <div class="form-item">
                <label>银行账户:</label>
		        <input class="easyui-textbox" name="yinhangzhanghu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>备注:</label>
		        <input class="easyui-textbox" name="beizhu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset('upd-gongzi-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="add-gongzi-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="add-gongzi-form">
            <div class="form-item">
                <label>姓名:</label>
		        <input class="easyui-textbox" name="renming" data-options="width: 318,height: 38,required:true"/>
            </div>
            <div class="form-item">
                <label>时间:</label>
		        <input class="easyui-datebox" name="shijian" data-options="width: 318,height: 38,required:true"/>
            </div>
            <div class="form-item">
                <label>工资:</label>
		        <input class="easyui-numberbox" name="kkqgongzi" data-options="width: 318,height: 38,precision:2,required:true"/>
            </div>
            <div class="form-item">
                <label>扣款:</label>
		        <input class="easyui-numberbox" name="koukuan" data-options="width: 318,height: 38,precision:2,required:true"/>
            </div>
            <div class="form-item">
                <label>已付:</label>
		        <input class="easyui-numberbox" name="yifu" data-options="width: 318,height: 38,precision:2,required:true"/>
            </div>
            <div class="form-item">
                <label>银行账户:</label>
		        <input class="easyui-textbox" name="yinhangzhanghu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item">
                <label>备注:</label>
		        <input class="easyui-textbox" name="beizhu" data-options="width: 318,height: 38"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toAdd()" class="btn" type="button">确认新增</button>
                <button onclick="javascript:toReset('add-gongzi-form')" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>