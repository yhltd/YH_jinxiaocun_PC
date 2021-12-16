<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_user.aspx.cs" Inherits="Web.finance.web.view.new_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div id="main">
        <form id="newUser" method="post">
            <div class="form-item">
		        <label for="myDo">验证操作密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="myDo"/>
            </div>
            <div class="form-item">
		        <label for="name">账号名称:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="name"/>
            </div>
            <div class="form-item">
		        <label for="pwd">账号密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="pwd"/>
            </div>
            <div class="form-item">
		        <label for="do">操作密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="do"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toNewUser()" class="btn" type="button">确认新增</button>
                <button onclick="javascript:toResetNewUser()" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>
