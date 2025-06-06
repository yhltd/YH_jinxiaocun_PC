﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongzimingxiUpd.aspx.cs" Inherits="Web.Personnel.gongzimingxiUpd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/mingxi.css" type="text/css"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;" runat="server" >
    <form id="form1" runat="server">
        <div id="Div1" runat="server" style="height: 600px; width: 1400px;overflow-x:scroll" >
            <asp:Label ID="Label1" runat="server" Text="姓名：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox1" cssclass="top_option"></asp:Textbox>
            <asp:Label ID="Label19" runat="server" Text="迟到扣款：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox19" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label37" runat="server" Text="个人医疗：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox37" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label2" runat="server" Text="部门：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox2" cssclass="top_option" ></asp:Textbox>
            <br />
            <asp:Label ID="Label20" runat="server" Text="应发工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox20" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label38" runat="server" Text="个人生育：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox38" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label3" runat="server" Text="岗位：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox3" cssclass="top_option" ></asp:Textbox>
            <asp:Label ID="Label21" runat="server" Text="社保基数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox21" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label39" runat="server" Text="个人公积金：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox39" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label4" runat="server" Text="身份证号：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox4" cssclass="top_option" ></asp:Textbox>
            <asp:Label ID="Label22" runat="server" Text="医疗技术：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox22" cssclass="top_option" ></asp:Textbox>
            <asp:Label ID="Label40" runat="server" Text="个人年金4%：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox40" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="入职时间：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox5" cssclass="top_option"  TextMode="date"></asp:Textbox>
            <asp:Label ID="Label23" runat="server" Text="公积金基数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox23" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label41" runat="server" Text="滞纳金：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox32" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label6" runat="server" Text="基本工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox6" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label24" runat="server" Text="年金基数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox24" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label42" runat="server" Text="利息：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox33" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label7" runat="server" Text="绩效工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox7" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label25" runat="server" Text="企业养老：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox25" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label43" runat="server" Text="个人小计：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox43" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label8" runat="server" Text="岗位工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox8" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label26" runat="server" Text="企业失业：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox26" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label44" runat="server" Text="税前工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox44" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="当月合计工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox9" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label27" runat="server" Text="企业医疗：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox27" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label45" runat="server" Text="应税工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox45" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label10" runat="server" Text="跨度工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox10" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label28" runat="server" Text="企业工伤：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox28" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label46" runat="server" Text="税率：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox46" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label11" runat="server" Text="职称津贴：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox11" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label29" runat="server" Text="企业生育：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox29" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label47" runat="server" Text="扣除数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox47" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label12" runat="server" Text="月出勤天数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox12" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label30" runat="server" Text="企业公积金：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox30" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label48" runat="server" Text="代扣个人所得税：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox48" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label13" runat="server" Text="加班时间：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox13" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label31" runat="server" Text="企业年金：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox31" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label49" runat="server" Text="年金1%：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox49" cssclass="top_option" ></asp:Textbox>
            <asp:Label ID="Label14" runat="server" Text="加班费：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox14" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label32" runat="server" Text="滞纳金：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox41" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label50" runat="server" Text="实发工资：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox50" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label15" runat="server" Text="全勤应发：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox15" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label33" runat="server" Text="利息：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox42" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label51" runat="server" Text="验算公式：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox51" cssclass="top_option" ></asp:Textbox>
            <asp:Label ID="Label16" runat="server" Text="缺勤天数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox16" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label34" runat="server" Text="企业小计：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox34" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label52" runat="server" Text="银行账号：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox52" cssclass="top_option" ></asp:Textbox>
            <br />
            <asp:Label ID="Label17" runat="server" Text="缺勤扣款：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox17" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label35" runat="server" Text="个人养老：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox35" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label53" runat="server" Text="调薪时间：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox53" cssclass="top_option"  TextMode="date"></asp:Textbox>
            <asp:Label ID="Label18" runat="server" Text="迟到天数：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox18" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <br />
            <asp:Label ID="Label36" runat="server" Text="个人失业：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox36" cssclass="top_option"  TextMode="Number"></asp:Textbox>
            <asp:Label ID="Label54" runat="server" Text="录入时间：" Width="130px" Height="30px"></asp:Label>
            <asp:Textbox runat="server" ID="Textbox54" cssclass="top_option"  TextMode="date"></asp:Textbox>
            <p style="margin-left: 500px; margin-top: 25px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" CssClass="top_bt" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        </div>
    </form>
</body>
</html>
