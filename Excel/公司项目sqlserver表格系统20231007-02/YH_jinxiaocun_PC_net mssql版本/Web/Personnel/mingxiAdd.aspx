<%@ page language="C#" autoeventwireup="true" codebehind="mingxiAdd.aspx.cs" inherits="Web.Personnel.mingxiAdd" %>

<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <script src="../finance/web/assets/js/Jquery.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" height="600px" width="1000px">
        <div id="Div1" runat="server" height="600px" width="600px" class="asd">
            <asp:label id="Label1" runat="server" text="姓名" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox1" onclick="getInfo" cssclass="top_option"></asp:textbox>
            <asp:label id="Label19" runat="server" text="迟到扣款" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox19" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label37" runat="server" text="个人医疗" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox37" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label2" runat="server" text="部门" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox2" cssclass="top_option"></asp:textbox>
            <br />
            <asp:label id="Label20" runat="server" text="应发工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox20" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label38" runat="server" text="个人生育" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox38" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label3" runat="server" text="岗位" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox3" cssclass="top_option"></asp:textbox>
            <asp:label id="Label21" runat="server" text="社保基数" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList21" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:Textbox runat="server" ID="Textbox21" cssclass="top_option"  TextMode="Number"></asp:Textbox>--%>
            <br />
            <asp:label id="Label39" runat="server" text="个人公积金" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox39" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label4" runat="server" text="身份证号" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox4" cssclass="top_option"></asp:textbox>
            <asp:label id="Label22" runat="server" text="医疗技术" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList22" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox22" cssclass="top_option"></asp:textbox>--%>
            
            <asp:label id="Label23" runat="server" text="公积金基数" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList23" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:Textbox runat="server" ID="Textbox23" cssclass="top_option"  TextMode="Number"></asp:Textbox>--%>
            <br />

            <asp:label id="Label40" runat="server" text="个人年金4%" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox40" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label41" runat="server" text="个人滞纳金" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList41" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox32" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <asp:label id="Label6" runat="server" text="基本工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox6" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label5" runat="server" text="入职时间" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox5" cssclass="top_option" textmode="date"></asp:textbox>
            <br />
            <asp:label id="Label24" runat="server" text="年金基数" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList24" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox24" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <asp:label id="Label42" runat="server" text="个人利息" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList42" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox33" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <asp:label id="Label7" runat="server" text="绩效工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox7" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label25" runat="server" text="企业养老" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox25" cssclass="top_option" textmode="Number"></asp:textbox>
            <br />
            <asp:label id="Label43" runat="server" text="个人小计" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox43" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label8" runat="server" text="岗位工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox8" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label26" runat="server" text="企业失业" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox26" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label44" runat="server" text="税前工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox44" cssclass="top_option" textmode="Number"></asp:textbox>
            <br />
            <asp:label id="Label9" runat="server" text="当月合计工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox9" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label27" runat="server" text="企业医疗" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox27" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label45" runat="server" text="应税工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox45" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label10" runat="server" text="跨度工资" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList10" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox10" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <br />
            <asp:label id="Label28" runat="server" text="企业工伤" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox28" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label46" runat="server" text="税率" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox46" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label11" runat="server" text="职称津贴" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList11" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox11" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <asp:label id="Label29" runat="server" text="企业生育" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox29" cssclass="top_option" textmode="Number"></asp:textbox>
            <br />
            <asp:label id="Label47" runat="server" text="扣除数" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox47" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label12" runat="server" text="月出勤天数" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox12" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label30" runat="server" text="企业公积金" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox30" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label48" runat="server" text="代扣个人所得税" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox48" cssclass="top_option" textmode="Number"></asp:textbox>
            <br />
            <asp:label id="Label13" runat="server" text="加班时间" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox13" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label31" runat="server" text="企业年金" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox31" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label49" runat="server" text="年金1%" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList49" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox49" cssclass="top_option"></asp:textbox>--%>
            <asp:label id="Label14" runat="server" text="加班费" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox14" cssclass="top_option" textmode="Number"></asp:textbox>
            <br />
            <asp:label id="Label32" runat="server" text="企业滞纳金" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList32" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox41" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <asp:label id="Label50" runat="server" text="实发工资" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox50" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label15" runat="server" text="全勤应发" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox15" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label33" runat="server" text="公司利息" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList33" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox42" cssclass="top_option" textmode="Number"></asp:textbox>--%>
            <br />
            <asp:label id="Label51" runat="server" text="验算公式" width="115px" height="30px"></asp:label>
            <asp:dropdownlist id="DropDownList51" runat="server" cssclass="top_option"></asp:dropdownlist>
            <%--<asp:textbox runat="server" id="Textbox51" cssclass="top_option"></asp:textbox>--%>
            <asp:label id="Label16" runat="server" text="缺勤天数" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox16" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label34" runat="server" text="企业小计" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox34" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label52" runat="server" text="银行账号" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox52" cssclass="top_option"></asp:textbox>
            <br />
            <asp:label id="Label17" runat="server" text="缺勤扣款" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox17" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label35" runat="server" text="个人养老" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox35" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label18" runat="server" text="迟到天数" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox18" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label53" runat="server" text="调薪时间" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox53" cssclass="top_option" textmode="date"></asp:textbox>
            <br />
            <asp:label id="Label36" runat="server" text="个人失业" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox36" cssclass="top_option" textmode="Number"></asp:textbox>
            <asp:label id="Label54" runat="server" text="录入时间" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox54" cssclass="top_option" textmode="date"></asp:textbox>
            <asp:label id="Label55" runat="server" text="工资年月" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox55" cssclass="top_option" textmode="month"></asp:textbox>
            <br />
            <p style="margin-left: 340px">
                <asp:button id="Button1" runat="server" onclick="Button1_Click" text="添加" cssclass="top_bt" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button id="Button2" runat="server" onclick="Button2_Click" text="返回" cssclass="top_bt" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:button id="Button4" runat="server" onclick="Button4_Click" text="计算" cssclass="top_bt" />

                <asp:button id="Button3" runat="server" onclick="getInfo" text="获得数据" cssclass="top_bt" style="display: none;" />
            </p>
        </div>
    </form>
</body>
<%--</html>--%>
