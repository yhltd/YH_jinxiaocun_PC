<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_pwd.aspx.cs" Inherits="Web.finance.web.view.update_pwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div id="main">
        <form id="updatePwd" method="post">
            <div class="form-item">
		        <label for="oldPwd">旧密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="oldPwd"/>
            </div>
            <div class="form-item">
		        <label for="newPwd">新密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="newPwd"/>
            </div>
            <div class="form-item">
		        <label for="newPwd_again">确认新密码:</label>
		        <input class="input easyui-validatebox" autocomplete="off" type="text" name="newPwd_again"/>
            </div>
            <div class="form-item form-item-btn">
                <button onclick="javascript:toUpdPwd()" class="btn" type="button">确认修改</button>
                <button onclick="javascript:toResetPwd()" class="btn btn-right" type="button">清空</button>
            </div>
        </form>
    </div>
</body>
</html>
