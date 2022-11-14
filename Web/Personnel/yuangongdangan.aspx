<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yuangongdangan.aspx.cs" Inherits="Web.Personnel.yuangongdangan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="js/jqueryui/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="js/jqueryui/jquery-ui.css"/>
    <form id="form1" runat="server">
        <div style="margin-left:20%;margin-top:3%">
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label1" runat="server" Text="现住址：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"  CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="家庭地址：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"  CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>

            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label3" runat="server" Text="银行卡支行：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="是否购买社保：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label5" runat="server" Text="公积金账号：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="社保账号：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label7" runat="server" Text="劳动合同签订有效期限：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="劳动合同第二次续签：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label9" runat="server" Text="备注：" Width="120px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
        
            <br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click"  CssClass="top_bt" style="margin-left:180px;margin-top: 2%;" />
            <%--<asp:Button ID="Button2" runat="server" Text="返回"  CssClass="top_bt" />--%>
            <input type="button" onclick="javascript: window.history.go(-1);" value="返回" class="top_bt" style="margin-left:100px">
        </div>
    </form>
</body>
</html>
