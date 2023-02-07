<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wuquanxian.aspx.cs" Inherits="Web.Personnel.changepwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <style>
        body
        {
            background: url('images/640x420.jpg')top center no-repeat; 
            background-size:cover;
        }
    </style>
<body style="margin: 0;height:100%;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script>
        function MyFun() {
            alert("无权限！");
        }
    </script>
    <form id="form1" runat="server" style="height:100%">
    <p style="color:black;position:absolute">当前系统版本：3.01.0</p>
    <div style="text-align:center;height:100%;display: flex;flex-direction: column;justify-content: center;align-items: center">
        <div style="font-size:40px;margin: 0 auto;color:black">欢迎使用！</div>
        <div style="font-size:40px;margin: 0 auto;color:black">云和人事管理系统</div>
    </div>
    </form>
</body>
</html>
