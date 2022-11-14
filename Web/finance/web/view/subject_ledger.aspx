<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subject_ledger.aspx.cs" Inherits="Web.finance.web.view.subject_ledger" %>

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

    <link rel="stylesheet" type="text/css" href="../assets/css/subject_ledger.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/subject_ledger.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="toolbar">
            <input id="clases" name="clases" value=""/>
            &nbsp;&nbsp;科目代码：
            <input id="code" class="easyui-numberbox" style="margin-left:20px" value=""/>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="sel()">查询</a>
            <a href="#" class="easyui-linkbutton btn-right" onclick="balanceBtn()">平衡验证</a>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-print',width:120" onclick="toExcel()">导出Excel</a>
        </div>
        <div class="main-item" style="height:540px">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="update" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="updateForm" method="post">
            <div class="form-item">
		        <label for="code">科目代码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="code"/>
            </div>
            <div class="form-item">
		        <label for="name">科目名称:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="name"/>
            </div>
            <div class="form-item">
		        <label for="load">年初借金:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="number" name="load"/>
            </div>
            <div class="form-item">
		        <label for="borrowed">年初贷金:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="number" name="borrowed"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset()" class="btn" style="margin-right:-2%" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="new" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover" >
        <div id="new-accordion" class="easyui-accordion" style="height: 510px;width: 800px;">
            <div title="选择科目代码" class="accordion-item" data-option="selected:true">
                <div class="accordion-item-main">
                    <div id="grade-list1"></div>
                    <div id="grade-list2"></div>
                    <div id="grade-list3"></div>
                </div>
                <div>
                    <span id="newTextGrade"></span>
                    <span id="newTextCode"></span>
                    <a href="#" class="easyui-linkbutton btn-right" onclick="choiceCode()">确认选择</a>
                </div>
            </div>
            <div title="科目基本信息" class="accordion-item">
                <form id="newForm" method="post">
                    <div class="form-item">
		                <label for="code">科目代码:</label>
		                <input id="newCode" class="input easyui-validatebox" disabled="disabled" autocomplete="off" type="text" name="code"/>
                    </div>
                    <div class="form-item">
		                <label for="name">科目名称:</label>
		                <input class="input easyui-validatebox" autocomplete="off" type="text" name="name"/>
                    </div>
                    <div class="form-item">
		                <label for="name">借贷方向:</label>
                        <div class="radio">
                            <input class="easyui-radiobutton radio-right" type="radio" name="direction" value="1"/>借
                            <input class="easyui-radiobutton radio-right" type="radio" name="direction" value="0"/>贷
                        </div>
                    </div>
                    <div class="form-item">
		                <label for="load">年初借金:</label>
		                <input class="input easyui-validatebox" autocomplete="off" type="number" name="load"/>
                    </div>
                    <div class="form-item">
		                <label for="borrowed">年初贷金:</label>
		                <input class="input easyui-validatebox" autocomplete="off" type="number" name="borrowed"/>
                    </div>
                    <div class="form-item form-item-btn">
                        <button onclick="javascript:toNew()" class="btn" type="button">确认添加</button>
                        <button onclick="javascript:toResetNew()" class="btn btn-right" type="button">清空</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
