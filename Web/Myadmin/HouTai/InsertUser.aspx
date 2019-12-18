<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertUser.aspx.cs" Inherits="Web.Myadmin.HouTai.InsertUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
         .btn {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            cursor:pointer;
        }

        #main 
        {
           /*margin: 0 auto; */
            /*margin-left: 271px;
            margin-top: 122px;*/
            height: 354px;
            color: white;
            line-height: 40px;
            font-weight: bolder;
            font-family: "微软雅黑";
            background-color: #00C5CD;
            width: 473px;
            padding: 51px;
            /* margin: 1px; */
            padding: 59px;
        }
            #main span 
            {
                margin-right: 10%;
            }
        #us 
        {
            padding: 10%;
            padding-left: 18%;
        }
        #queren {
            margin-left: 138%;
        }
    </style>
</head>
<body style ="margin: 0;">
    <form id="form1" runat="server">
        <div id="main">
            <table id ="us">
                <tr>
                    <td>用户名：</td>
                    <td><asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>密码： </td>
                    <td><asp:TextBox ID="Pwd" runat="server" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>确认密码：</td>
                    <td><asp:TextBox ID="Qrpwd" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>用户权限：</td>
                    <td><select id="quanxian" runat="server">
                        <option>管理员</option>
                        <option>普通用户</option>
                </select></td>
                </tr>
                <tr>
                    <td><asp:Button ID="queren" CssClass="btn"  Text="确认提交" OnClick="queren_Click" runat="server"/></td>
                </tr>
            </table>
<%--            公司：<asp:TextBox ID="gongsi" runat="server"></asp:TextBox>--%>
    </form>
</body>
</html>
