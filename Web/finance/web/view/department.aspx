<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="Web.finance.web.view.department" %>

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
    <script type="text/javascript" src="../assets/js/department.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="main-item">
            <div id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="update" style="display: none">
        <form id="updateForm" method="post">
            <div class="form-item">
		        <label for="code">部门名称:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="department1"/>
            </div>
            <div class="form-item">
		        <label for="name">审核人:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="man"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset()" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="new" style="display: none;" >
        <form id="newForm" method="post">
            <div class="form-item">
		        <label for="code">部门名称:</label>
		        <input id="newCode" class="input easyui-validatebox" autocomplete="off" type="text" name="department1"/>
            </div>
            <div class="form-item">
		        <label for="name">制表人:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="man"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toNew()" class="btn" type="button">确认添加</button>
                <button onclick="javascript:toResetNew()" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>
