﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kaoqinAdd.aspx.cs" Inherits="Web.Personnel.kaoqinAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .body {
            left: 400px;
        }
        #form {
        }
    </style>
</head>
<body class="body">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script>
        function MyFun() {
            alert("必填项不能为空！");
        }
    </script>
    <form id="form1" runat="server">
        <p style="margin-left: 240px">
            <br />
        <asp:Label ID="Label1" runat="server" Height="30px" Text="年份：" Width="60px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="113px"  CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Height="30px" Text="月份：" Width="60px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="113px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Height="30px" Text="姓名：" Width="60px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="113px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Height="30px" Text="1：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Height="30px" Text="2：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Height="30px" Text="3：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Height="30px" Text="4：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Height="30px" Text="5：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Height="30px" Text="6：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Height="30px" Text="7：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" Height="30px" Text="8：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox11" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" Height="30px" Text="9：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label13" runat="server" Height="30px" Text="10：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox13" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label14" runat="server" Height="30px" Text="11：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox14" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label15" runat="server" Height="30px" Text="12：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox15" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label16" runat="server" Height="30px" Text="13：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox16" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label17" runat="server" Height="30px" Text="14：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox17" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Height="30px" Text="15：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox18" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" Height="30px" Text="16：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox19" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label20" runat="server" Height="30px" Text="17：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox20" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Height="30px" Text="18：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox21" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" Height="30px" Text="19：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox22" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label23" runat="server" Height="30px" Text="20：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox23" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label24" runat="server" Height="30px" Text="21：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox24" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label25" runat="server" Height="30px" Text="22：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox25" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label26" runat="server" Height="30px" Text="23：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox26" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label27" runat="server" Height="30px" Text="24：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox27" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label28" runat="server" Height="30px" Text="25：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox28" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label29" runat="server" Height="30px" Text="26：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox29" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label30" runat="server" Height="30px" Text="27：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox30" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label31" runat="server" Height="30px" Text="28：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox31" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label32" runat="server" Height="30px" Text="29：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox32" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label33" runat="server" Height="30px" Text="30：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox33" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label34" runat="server" Height="30px" Text="31：" Width="30px"></asp:Label>
        <asp:TextBox ID="TextBox34" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label35" runat="server" Height="30px" Text="全勤:" Width="41px"></asp:Label>
        <asp:TextBox ID="TextBox35" runat="server" Height="30px" Width="58px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label36" runat="server" Height="30px" Text="实际:" Width="41px"></asp:Label>
        <asp:TextBox ID="TextBox36" runat="server" Height="30px" Width="58px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label37" runat="server" Height="30px" Text="请假:" Width="41px"></asp:Label>
        <asp:TextBox ID="TextBox37" runat="server" Height="30px" Width="58px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label38" runat="server" Height="30px" Text="加班:" Width="41px"></asp:Label>
        <asp:TextBox ID="TextBox38" runat="server" Height="30px" Width="58px" CssClass="top_select_input"></asp:TextBox>
        <asp:Label ID="Label39" runat="server" Height="30px" Text="迟到:" Width="41px"></asp:Label>
        <asp:TextBox ID="TextBox39" runat="server" Height="30px" Width="58px" CssClass="top_select_input"></asp:TextBox>
        <br />
        <br />
        </p>
        <p style="margin-left: 430px">
        <asp:Button ID="Button1" runat="server" Height="28px" OnClick="Button1_Click" Text="添加" Width="84px"  CssClass="top_bt"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="28px" OnClick="Button2_Click" Text="返回" Width="84px"  CssClass="top_bt"/>
        </p>
    </form>
</body>
</html>