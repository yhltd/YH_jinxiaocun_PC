<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renyuanxinxiAdd.aspx.cs" Inherits="Web.Personnel.renyuanxinxiAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script>
        function MyFun() {
            alert("该用户名已存在！");
        }
    </script>
    <form id="form1" runat="server">
        <div style="margin-left: 280px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="姓       名：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"  CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="部门：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="职务：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="身份证号：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="基本工资：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="银行卡号：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="入职时间：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="工龄：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="账号" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" Text="密码：" Width="80px" Height="25px"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server" CssClass="top_select_input" Height="25px" Width="150px"  ></asp:TextBox>
            <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click"  CssClass="top_bt" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"  CssClass="top_bt" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="权限" OnClick="Button3_Click"  CssClass="top_bt" />
    </div>
    </form>
</body>
</html>
