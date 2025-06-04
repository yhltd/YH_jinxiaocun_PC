<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kaoqinAdd.aspx.cs" Inherits="Web.Personnel.kaoqinAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            alert("必填项不能为空，并且年月必须填写正确！");
        }
    </script>
    <form id="form1" runat="server" style="border:red;solid:1px">
        <p style="margin-left: 240px">
            <br />
        <asp:Label ID="Label1" runat="server" Height="30px"  style="text-align:center" Width="60px">年份：</asp:Label>
        <%--<input id="input1" runat="server" type="number" height="40px" class="input1" />--%>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="113px"  CssClass="top_select_input" TextMode="Number" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"> </asp:TextBox>
        <asp:Label ID="Label2" runat="server" Height="30px" style="text-align:center" Width="60px">月份：</asp:Label>
        <%--<input id="input2" runat="server" type="number" height="40px" width="100px" class="input1" />--%>
        <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="113px" CssClass="top_select_input" TextMode="Number" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"> </asp:TextBox>
        <asp:Label ID="Label3" runat="server" Height="30px" style="text-align:center" Width="60px">姓名：</asp:Label>
        <%--<input id="input3" runat="server" type="number" height="40px"  class="input1" />--%>
        <asp:TextBox ID="TextBox3" runat="server" Height="30px"  Width="113px" CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Height="30px" Text="1：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList4" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label5" runat="server" Height="30px" Text="2：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList5" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label6" runat="server" Height="30px" Text="3：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList6" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label7" runat="server" Height="30px" Text="4：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList7" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox7" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label8" runat="server" Height="30px" Text="5：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList8" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox8" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label9" runat="server" Height="30px" Text="6：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList9" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox9" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Height="30px" Text="7：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList10" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox10" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label11" runat="server" Height="30px" Text="8：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList11" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox11" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label12" runat="server" Height="30px" Text="9：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList12" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox12" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label13" runat="server" Height="30px" Text="10：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList13" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox13" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label14" runat="server" Height="30px" Text="11：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList14" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox14" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label15" runat="server" Height="30px" Text="12：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList15" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox15" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <br />
        <br />
        <asp:Label ID="Label16" runat="server" Height="30px" Text="13：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList16" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox16" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label17" runat="server" Height="30px" Text="14：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList17" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox17" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label18" runat="server" Height="30px" Text="15：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList18" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox18" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label19" runat="server" Height="30px" Text="16：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList19" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox19" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label20" runat="server" Height="30px" Text="17：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList20" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox20" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label21" runat="server" Height="30px" Text="18：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList21" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox21" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" Height="30px" Text="19：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList22" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox22" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label23" runat="server" Height="30px" Text="20：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList23" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox23" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label24" runat="server" Height="30px" Text="21：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList24" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox24" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label25" runat="server" Height="30px" Text="22：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList25" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox25" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label26" runat="server" Height="30px" Text="23：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList26" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox26" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label27" runat="server" Height="30px" Text="24：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList27" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox27" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <br />
        <br />
        <asp:Label ID="Label28" runat="server" Height="30px" Text="25：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList28" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox28" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label29" runat="server" Height="30px" Text="26：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList29" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox29" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label30" runat="server" Height="30px" Text="27：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList30" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox30" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label31" runat="server" Height="30px" Text="28：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList31" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox31" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label32" runat="server" Height="30px" Text="29：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList32" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox32" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label33" runat="server" Height="30px" Text="30：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList33" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox33" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <br />
        <br />
        <asp:Label ID="Label34" runat="server" Height="30px" Text="31：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList34" runat="server" Height="30px" Width="50px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox34" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <br />
        <br />
        <asp:Label ID="Label35" runat="server" Height="30px" Text="全勤:" Width="41px"></asp:Label>
        <%--<input id="input35" runat="server"  height="30px" width="100spx" class="input2" />--%>
        <asp:TextBox ID="TextBox35" runat="server" Height="30px" Width="58px" CssClass="top_select_input" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Label36" runat="server" Height="30px" Text="实际:" Width="41px"></asp:Label>
        <%--<input id="input36" runat="server"  height="30px" width="100px" class="input2" />--%>
        <asp:TextBox ID="TextBox36" runat="server" Height="30px" Width="58px" CssClass="top_select_input" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Label37" runat="server" Height="30px" Text="请假:" Width="41px"></asp:Label>
        <%--<input id="input37" runat="server"  height="30px" width="100px" class="input2" />--%>
        <asp:TextBox ID="TextBox37" runat="server" Height="30px" Width="58px" CssClass="top_select_input" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Label38" runat="server" Height="30px" Text="加班:" Width="41px"></asp:Label>
        <%--<input id="input38" runat="server"  height="30px" width="100px" class="input2" />--%>
        <asp:TextBox ID="TextBox38" runat="server" Height="30px" Width="58px" CssClass="top_select_input" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Label39" runat="server" Height="30px" Text="迟到:" Width="41px"></asp:Label>
        <%--<input id="input39" runat="server"  height="30px" width="100px" class="input2" />--%>
        <asp:TextBox ID="TextBox39" runat="server" Height="30px" Width="58px" CssClass="top_select_input" TextMode="Number"></asp:TextBox>
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
