<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_management.aspx.cs" Inherits="Web.finance.web.view.user_management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../assets/js/EasyUI/demo/demo.css"/>
    <script type="text/javascript" src="../assets/js/Jquery.js"></script>
    <script type="text/javascript" src="../assets/js/qrcode.min.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../assets/js/EasyUI/locale/easyui-lang-zh_CN.js"></script>

    <link rel="stylesheet" type="text/css" href="../assets/css/main.css"/>
    <script type="text/javascript" src="../assets/js/main.js"></script>
    <script type="text/javascript" src="../assets/js/parsing.js"></script>
    <script type="text/javascript" src="../assets/js/user_management.js"></script>
    <link rel="stylesheet" type="text/css" href="../assets/css/update_user.css"/>
</head>
<body>
    <div id="qrcode" style="display: none"></div>
    <div id="main" class="item">
        <div class="toolbar">
            &nbsp;&nbsp;账号：
            <input id="username" class="easyui-textbox" style="margin-left:20px" value=""/>
            <a class="easyui-linkbutton btn-right" data-options="iconCls:'icon-search',width:80" onclick="sel()">查询</a>
        </div>
        <div class="main-item">
            <div style="height:95%" id="data-table" class="easyui-datagrid"></div>
            <div id="data-page" class="easyui-pagination"></div>
        </div>
    </div>

    <div id="update" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover">
        <form id="updateForm" method="post">
            <div class="form-item">
		        <label for="name">账号:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="name"/>
            </div>
            <div class="form-item">
		        <label for="pwd">密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="pwd"/>
            </div>
            <div class="form-item">
		        <label for="do">操作密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="do"/>
            </div>
            <div class="form-item">
		        <label for="xingming">姓名:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="xingming"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toReset()" class="btn" style="margin-right:-1%" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="new" style="display: none;background:url('../assets/img/background_pic.jpeg') no-repeat center 0px;background-position: center 0px;background-size: cover" >
        <form id="newForm" method="post">
            <div class="form-item">
		        <label for="name">账号:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="name"/>
            </div>
            <div class="form-item">
		        <label for="pwd">密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="pwd"/>
            </div>
            <div class="form-item">
		        <label for="do">操作密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="do"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toNew()" class="btn" type="button">确认添加</button>
                <button onclick="javascript:toResetNew()" class="btn" style="margin-right:-1%" type="button">清空</button>
            </div>
        </form>
    </div>

    <div id="qxupdate" style="display: none;" >
        <form id="qxForm" method="post">
            <div class="form-item">
		        <label for="name">科目总账-添加:</label>
                <select class="easyui-combobox" name="kmzz_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name" >科目总账-删除:</label>
                <select class="easyui-combobox" name="kmzz_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name" >科目总账-修改:</label>
                <select class="easyui-combobox" name="kmzz_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name" >科目总账-查询:</label>
                <select class="easyui-combobox" name="kmzz_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">开支项目-添加:</label>
                <select class="easyui-combobox" name="kzxm_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">开支项目-删除:</label>
                <select class="easyui-combobox" name="kzxm_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">开支项目-修改:</label>
                <select class="easyui-combobox" name="kzxm_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">开支项目-查询:</label>
                <select class="easyui-combobox" name="kzxm_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">部门设置-添加:</label>
                <select class="easyui-combobox" name="bmsz_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">部门设置-删除:</label>
                <select class="easyui-combobox" name="bmsz_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">部门设置-修改:</label>
                <select class="easyui-combobox" name="bmsz_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">部门设置-查询:</label>
                <select class="easyui-combobox" name="bmsz_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">账号管理-添加:</label>
                <select class="easyui-combobox" name="zhgl_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">账号管理-删除:</label>
                <select class="easyui-combobox" name="zhgl_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">账号管理-修改:</label>
                <select class="easyui-combobox" name="zhgl_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">账号管理-查询:</label>
                <select class="easyui-combobox" name="zhgl_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">凭证汇总-添加:</label>
                <select class="easyui-combobox" name="pzhz_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">凭证汇总-删除:</label>
                <select class="easyui-combobox" name="pzhz_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">凭证汇总-修改:</label>
                <select class="easyui-combobox" name="pzhz_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">凭证汇总-查询:</label>
                <select class="easyui-combobox" name="pzhz_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">智能看板-查询:</label>
                <select class="easyui-combobox" name="znkb_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">现金流量-查询:</label>
                <select class="easyui-combobox" name="xjll_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">资产负债-查询:</label>
                <select class="easyui-combobox" name="zcfz_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">利益损益-查询:</label>
                <select class="easyui-combobox" name="lysy_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">极简台账-添加:</label>
                <select class="easyui-combobox" name="jjtz_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">极简台账-删除:</label>
                <select class="easyui-combobox" name="jjtz_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">极简台账-修改:</label>
                <select class="easyui-combobox" name="jjtz_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">极简台账-查询:</label>
                <select class="easyui-combobox" name="jjtz_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item">
		        <label for="name">极简总账-添加:</label>
                <select class="easyui-combobox" name="jjzz_add" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">极简总账-删除:</label>
                <select class="easyui-combobox" name="jjzz_delete" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">极简总账-修改:</label>
                <select class="easyui-combobox" name="jjzz_update" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
                <label for="name">极简总账-查询:</label>
                <select class="easyui-combobox" name="jjzz_select" style="width:50px">
                    <option>是</option>
                    <option>否</option>
                </select>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:qxUpd()" class="btn" type="button">确认修改</button>
            </div>
        </form>
    </div>

</body>
</html>
