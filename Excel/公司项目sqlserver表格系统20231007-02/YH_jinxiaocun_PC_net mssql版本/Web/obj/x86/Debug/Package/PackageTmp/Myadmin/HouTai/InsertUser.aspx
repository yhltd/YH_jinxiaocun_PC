<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertUser.aspx.cs" Inherits="Web.Myadmin.HouTai.InsertUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        #main 
        {
            margin: auto;
            height: 412px;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        #main span 
        {
            margin-right: 10%;
        }
        #us 
        {
            height: 80%;
            width: 80%;
        }
        .input_tr {
            order: 1px solid #eee;
            width: 224px;
            height: 40px;
            border-radius: 3px;
            padding-left: 16px;
        }
        .table_tr
        {
            display: flex;
            height: 60px;
            align-items: center;
            justify-content: center;
        }
        .table_text
        {
            text-align: right;
            width: 20%;
            
        }
        .table_input
        {
            width: 200px;
            height: 35px;
            border: 1px solid #eee;
            padding-left: 20px;
            border-radius: 3px;
        }
        .go
        {
            height: 40px;
            width: 100px;
            background-color: #009688;
            border: none;
            color: white;
            border-radius: 3px;
            box-shadow: 2px 2px 5px black;
            padding:0;
            cursor: pointer;
        }
        .go:active
        {
            height: 40px;
            width: 100px;
            background-color: #03685F;
            border: none;
            color: white;
            border-radius: 3px;
            padding:0;
            box-shadow: 2px 2px 5px black;
            cursor: pointer;
        }
    </style>
</head>
<body style ="margin: auto;">
    <form id="form1" runat="server">
        <div id="main">
            <table id ="us">
                <tr class="table_tr">
                    <td class="table_text">用户名：</td>
                    <td><asp:TextBox CssClass="table_input" ID="Name" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="table_tr">
                    <td class="table_text">密码： </td>
                    <td><asp:TextBox CssClass="table_input" ID="Pwd" runat="server" ></asp:TextBox></td>
                </tr>
                <tr class="table_tr">
                    <td class="table_text">确认密码：</td>
                    <td><asp:TextBox CssClass="table_input" ID="Qrpwd" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="table_tr">
                    <td class="table_text">用户权限：</td>
                    <td><select class="input_tr" id="quanxian" runat="server">
                        <option>管理员</option>
                        <option>普通用户</option>
                </select></td>
                </tr>
                <tr class="table_tr">
                    <td>
                        <asp:Button ID="queren" CssClass="go"  Text="确认提交" OnClick="queren_Click" runat="server"/>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
