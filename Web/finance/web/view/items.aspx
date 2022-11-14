<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="items.aspx.cs" Inherits="Web.finance.web.view.items" %>

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
    <script type="text/javascript" src="../assets/js/items.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="main" class="item">
<%--        <div class="toolbar">
        </div>--%>
        <div class="main-item" style="height:580px">
            <!--经营收入-->
            <div class="main-item-item">
                <div style="height:95%" id="data-table-financingExpenditure" class="easyui-datagrid"></div>
                <div id="data-page-financingExpenditure" class="easyui-pagination"></div>
                <div id="upd-financingExpenditure-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-financingExpenditure-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="financingExpenditure1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updFinancingExpenditure()">保存</a>
                    </form>
                </div>
                <div id="add-financingExpenditure-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover;">
                    <form id="add-financingExpenditure-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="financingExpenditure1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addFinancingExpenditure()">保存</a>
                    </form>
                </div>
            </div>

            <!--经营支出-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-financingIncome" class="easyui-datagrid"></div>
                <div id="data-page-financingIncome" class="easyui-pagination"></div>
                <div id="upd-financingIncome-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-financingIncome-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="financingIncome1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updFinancingIncome()">保存</a>
                    </form>
                </div>
                <div id="add-financingIncome-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-financingIncome-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="financingIncome1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addFinancingIncome()">保存</a>
                    </form>
                </div>
            </div>


            <!--筹资收入-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-investmentExpenditure" class="easyui-datagrid"></div>
                <div id="data-page-investmentExpenditure" class="easyui-pagination"></div>
                <div id="upd-investmentExpenditure-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-investmentExpenditure-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="investmentExpenditure1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updInvestmentExpenditure()">保存</a>
                    </form>
                </div>
                <div id="add-investmentExpenditure-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-investmentExpenditure-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="investmentExpenditure1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addInvestmentExpenditure()">保存</a>
                    </form>
                </div>
            </div>

            <!--筹资支出-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-investmentIncome" class="easyui-datagrid"></div>
                <div id="data-page-investmentIncome" class="easyui-pagination"></div>
                <div id="upd-investmentIncome-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-investmentIncome-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="investmentIncome1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updInvestmentIncome()">保存</a>
                    </form>
                </div>
                <div id="add-investmentIncome-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-investmentIncome-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="investmentIncome1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addInvestmentIncome()">保存</a>
                    </form>
                </div>
            </div>


            <!--投资收入-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-managementExpenditure" class="easyui-datagrid"></div>
                <div id="data-page-managementExpenditure" class="easyui-pagination"></div>
                <div id="upd-managementExpenditure-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-managementExpenditure-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="managementExpenditure1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updManagementExpenditure()">保存</a>
                    </form>
                </div>
                <div id="add-managementExpenditure-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-managementExpenditure-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="managementExpenditure1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addManagementExpenditure()">保存</a>
                    </form>
                </div>
            </div>

            <!--投资支出-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-managementIncome" class="easyui-datagrid"></div>
                <div id="data-page-managementIncome" class="easyui-pagination"></div>
                <div id="upd-managementIncome-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-managementIncome-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="managementIncome1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updManagementIncome()">保存</a>
                    </form>
                </div>
                <div id="add-managementIncome-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-managementIncome-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="managementIncome1" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addManagementIncome()">保存</a>
                    </form>
                </div>
            </div>

            <!--凭证字-->
            <div class="main-item-item btn-right">
                <div style="height:95%" id="data-table-voucherWord" class="easyui-datagrid"></div>
                <div id="data-page-voucherWord" class="easyui-pagination"></div>
                <div id="upd-voucherWord-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="upd-voucherWord-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="word" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="updVoucherWord()">保存</a>
                    </form>
                </div>
                <div id="add-voucherWord-window" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
                    <form id="add-voucherWord-form">
                        <input class="easyui-textbox" style="width: 300px;height: 35px;" name="word" type="text"/>
                        <a class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="addVoucherWord()">保存</a>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
