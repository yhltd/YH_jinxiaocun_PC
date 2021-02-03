<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kaoqinjiluAdd.aspx.cs" Inherits="Web.Personnel.kaoqinjiluAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <form id="form1" runat="server">
    <div style="margin-left: 400px">
    
        <asp:Label ID="Label1" runat="server" Text="姓名：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="150px"  CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="年份：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="月份：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="应到：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="实到：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="请假：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="加班：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="迟到：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" Height="30px" Width="150px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="部门：" Width="80px" Height="30px"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="bumen" DataValueField="bumen" Height="30px" Width="150px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString15 %>" SelectCommand="SELECT [bumen] FROM [gongzi_peizhi] WHERE ([gongsi] = @gongsi) and bumen !='-'">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" Height="30px" Width="80px"  CssClass="top_bt" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" Height="30px" Width="80px"  CssClass="top_bt" />
    
    </div>
    </form>
</body>
</html>
