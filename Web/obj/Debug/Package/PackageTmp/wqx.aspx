<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wqx.aspx.cs" Inherits="Web.wqx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script>
        function MyFun() {
            alert("无权限！");
        }
    </script>
    <form id="form1" runat="server" style="height:100%">
    <div style="text-align:center;height:500px;display: flex;flex-direction: column;justify-content: center;align-items: center;">
        <div style="font-size:40px;margin: 0 auto;">欢迎使用！</div>
        <div style="font-size:40px;margin: 0 auto;">云合进销存管理系统</div>
    </div>
    </form>
</body>
</html>
