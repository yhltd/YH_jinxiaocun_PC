<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renyuanxinxiAdd.aspx.cs" Inherits="Web.Personnel.renyuanxinxiAdd" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="js/jqueryui/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="js/jqueryui/jquery-ui.css"/>
        <script type="text/javascript">
            $(function updinput() {
                $("[name='TextBox7']").datepicker({ dateFormat: 'yy-mm-dd' });
                $("[name='TextBox15']").datepicker({ dateFormat: 'yy-mm-dd' });
                //$("[name='TextBox19']").datepicker({ dateFormat: 'yy-mm-dd' });
            })
            function MyFun() {
                alert("该用户名已存在！");
            }
            function text1() {
                alert("该用户名已存在！");
            }
            function text2() {
                alert("该用户名已存在！");
            }
            function text3() {
                alert("该用户名已存在！");
            }
            function text4() {
                alert("该用户名已存在！");
            }
            function text5() {
                alert("该用户名已存在！");
            }
            function text6() {
                alert("该用户名已存在！");
            }
            function text7() {
                alert("该用户名已存在！");
            }
            function text8() {
                alert("该用户名已存在！");
            }
            function text9() {
                alert("该用户名已存在！");
            }
            function text10() {
                alert("该用户名已存在！");
            }
        </script>
    <form id="form1" runat="server">
        <div style="margin-left:24%;margin-top:3%">
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label1" runat="server" Text="姓名：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"  CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label50" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label21" runat="server" Text="民族：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox11" runat="server"  CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label22" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>

            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label2" runat="server" Text="部门：" Width="80px" Height="25px"></asp:Label>
            <%--<asp:TextBox ID="TextBox2" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>--%>
            <asp:dropdownlist ID="DropDownList2" runat="server" cssclass="top_select_input" Height="25px" Width="150px"></asp:dropdownlist>    
                <asp:Label ID="Label12" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label23" runat="server" Text="籍贯：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox12" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label24" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label3" runat="server" Text="职务：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label13" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label25" runat="server" Text="手机号：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox13" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label26" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label4" runat="server" Text="身份证号：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label14" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label27" runat="server" Text="学历：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox14" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label28" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label5" runat="server" Text="基本工资：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label29" runat="server" Text="出生日期：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox15" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label30" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label6" runat="server" Text="银行卡号：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label16" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label31" runat="server" Text="婚姻状况：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox16" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label32" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>    
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label7" runat="server" Text="入职时间：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label17" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label33" runat="server" Text="就职状态：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox17" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label34" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>    
            
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label8" runat="server" Text="工龄：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label18" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="绩效工资：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox18" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label35" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>

            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label9" runat="server" Text="账号：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label19" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label36" runat="server" Text="调薪日期：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox19" runat="server" CssClass="top_select_input" Height="25px" Width="150px" ></asp:TextBox>
                <asp:Label ID="Label37" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Label ID="Label10" runat="server" Text="密码：" Width="80px" Height="25px"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server" CssClass="top_select_input" Height="25px" Width="150px"  ></asp:TextBox>
                <asp:Label ID="Label20" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                <br />
            <br />
            <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click"  CssClass="top_bt" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"  CssClass="top_bt" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="权限" OnClick="Button3_Click"  CssClass="top_bt" />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="更多" OnClick="Button4_Click"   CssClass="top_bt" />
        </div>
    </form>
</body>
</html>
