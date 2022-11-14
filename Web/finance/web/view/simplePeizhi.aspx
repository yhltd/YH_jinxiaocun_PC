<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simplePeizhi.aspx.cs" Inherits="Web.finance.web.view.simplePeizhi" %>

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

    <link rel="stylesheet" type="text/css" href="../assets/css/items.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/simplePeizhi.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
        <div class="main-item" style="height:580px">
            <!--科目-->
            <div class="main-item-item">
                <div style="height:95%" id="data-table-accounting" class="easyui-datagrid"></div>
                <div id="data-page-accounting" class="easyui-pagination"></div>
                <div id="upd-accounting-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-accounting-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="accounting" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updAccounting()">保存</a>
                    </form>
                </div>
                <div id="add-accounting-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-accounting-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="accounting" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addAccounting()">保存</a>
                    </form>
                </div>
            </div>

            <!--客户-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-kehu" class="easyui-datagrid"></div>
                <div id="data-page-kehu" class="easyui-pagination"></div>
                <div id="upd-kehu-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-kehu-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="kehu" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updKehu()">保存</a>
                    </form>
                </div>
                <div id="add-kehu-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-kehu-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="kehu" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addKehu()">保存</a>
                    </form>
                </div>
            </div>

            <!--发票种类-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-invoice" class="easyui-datagrid"></div>
                <div id="data-page-invoice" class="easyui-pagination"></div>
                <div id="upd-invoice-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-invoice-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="invoice" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updInvoice()">保存</a>
                    </form>
                </div>
                <div id="add-invoice-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-invoice-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="invoice" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addInvoice()">保存</a>
                    </form>
                </div>
            </div>

        </div>
    </div>
</body>
</html>
