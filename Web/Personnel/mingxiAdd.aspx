﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mingxiAdd.aspx.cs" Inherits="Web.Personnel.mingxiAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="姓名：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label19" runat="server" Text="迟到扣款：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox19" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label37" runat="server" Text="个人医疗：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox37" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="部门：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        
        <br />
        <asp:Label ID="Label20" runat="server" Text="应发工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox20" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label38" runat="server" Text="个人生育：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox38" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="岗位：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Text="社保基数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox21" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label39" runat="server" Text="个人公积金：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox39" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="身份证号：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label22" runat="server" Text="医疗技术：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox22" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label40" runat="server" Text="个人年金4%：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox40" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="入职时间：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label23" runat="server" Text="公积金基数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox23" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label41" runat="server" Text="滞纳金：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox41" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="基本工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label24" runat="server" Text="年金基数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox24" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label42" runat="server" Text="利息：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox42" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="绩效工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label25" runat="server" Text="企业养老：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox25" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label43" runat="server" Text="个人小计：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox43" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="岗位工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label26" runat="server" Text="企业失业：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox26" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label44" runat="server" Text="税前工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox44" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="当月合计工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label27" runat="server" Text="企业医疗：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox27" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label45" runat="server" Text="应税工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox45" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" Text="跨度工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label28" runat="server" Text="企业工伤：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox28" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label46" runat="server" Text="税率：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox46" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" Text="职称津贴：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox11" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label29" runat="server" Text="企业生育：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox29" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label47" runat="server" Text="扣除数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox47" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" Text="月出勤天数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label30" runat="server" Text="企业公积金：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox30" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label48" runat="server" Text="代扣个人所得税：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox48" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" Text="加班时间：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox13" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label31" runat="server" Text="企业年金：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox31" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label49" runat="server" Text="年金1%：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox49" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label14" runat="server" Text="加班费：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox14" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label32" runat="server" Text="滞纳金：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox32" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label50" runat="server" Text="实发工资：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox50" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label15" runat="server" Text="全勤应发：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox15" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label33" runat="server" Text="利息：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox33" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label51" runat="server" Text="验算公式：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox51" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label16" runat="server" Text="缺勤天数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox16" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label34" runat="server" Text="企业小计：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox34" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label52" runat="server" Text="银行账号：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox52" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label17" runat="server" Text="缺勤扣款：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox17" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label35" runat="server" Text="个人养老：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox35" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label53" runat="server" Text="调薪时间：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox53" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Text="迟到天数：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox18" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <asp:Label ID="Label36" runat="server" Text="个人失业：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox36" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <asp:Label ID="Label54" runat="server" Text="录入时间：" Width="130px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox54" runat="server" Height="30px" Width="150px" CssClass="top_option"></asp:TextBox>
        <br />
        <p style="margin-left: 480px">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加"  CssClass="top_bt"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回"  CssClass="top_bt"/>
        </p>
    </div>
    </form>
</body>
</html>