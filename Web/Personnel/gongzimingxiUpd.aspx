<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongzimingxiUpd.aspx.cs" Inherits="Web.Personnel.gongzimingxiUpd" %>

<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="css/mingxi.css" type="text/css"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>

<style>
    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
    }
    
    body {
        background: linear-gradient(to right, #b9b6d0 0%, #4758cb 50%, #999df2 100%);
        padding: 20px;
        min-height: 100vh;
        display: flex;
        justify-content: center;
    }
    
    .asd {
        width: 100%;
        max-width: 1400px;
        margin: 0 auto;
    }
    
    #Div1 {
        background: white;
        border-radius: 12px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        padding: 30px;
        overflow-x: auto;
        border: 1px solid #e0e0e0;
    }
    
    /* 页面标题样式 */
    .page-title {
        background: linear-gradient(135deg, rgba(22, 10, 141, 0.95) 0%, rgba(59, 77, 203, 0.95) 50%, rgba(90, 95, 221, 0.95) 100%);
        color: white;
        padding: 15px 30px;
        border-radius: 12px 12px 0 0;
        text-align: center;
        font-size: 24px;
        font-weight: 700;
        text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
        margin-bottom: 20px;
    }
    
    /* 表单容器样式 */
    .form-container {
        background: white;
        padding: 20px 30px;
        border-radius: 0 0 12px 12px;
    }
    
    /* 标签样式 */
    .form-container label {
        display: inline-block;
        width: 115px;
        height: 30px;
        line-height: 30px;
        font-weight: 600;
        color: #2E8B57;
        text-align: right;
        margin-right: 10px;
        margin-bottom: 15px;
    }
    
    /* 输入框和下拉框样式 */
    .top_option {
        width: 150px;
        height: 30px;
        padding: 6px 12px;
        border: 1px solid #ddd;
        border-radius: 6px;
        font-size: 14px;
        transition: all 0.3s;
        margin-right: 20px;
        margin-bottom: 15px;
    }
    
    .top_option:focus {
        outline: none;
        border-color: #3CB371;
        box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
    }
    
    .top_option[type="number"] {
        text-align: right;
    }
    
    /* 按钮样式 */
    .top_bt {
        background: linear-gradient(to bottom, #07f2e7, #071ec1);
        color: white;
        border: none;
        border-radius: 6px;
        cursor: pointer;
        font-weight: 600;
        transition: all 0.3s;
        min-width: 100px;
        height: 35px;
        padding: 0 20px;
        font-size: 15px;
        margin: 20px 10px;
    }
    
    .top_bt:hover {
        background: linear-gradient(to bottom, #07f2e7, #071ec1);
        transform: translateY(-2px);
        box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
    }
    
    /* 按钮容器 */
    .button-container {
        text-align: center;
        margin-top: 30px;
        padding-top: 20px;
        border-top: 1px solid #eee;
    }
    
    /* 表单行样式 */
    .form-row {
        margin-bottom: 5px;
    }
    
    /* 输入框组样式 */
    .input-group {
        display: inline-block;
        vertical-align: top;
    }
    
    /* 响应式设计 */
    @media (max-width: 768px) {
        #Div1 {
            padding: 15px;
        }
        
        .form-container label {
            width: 100%;
            text-align: left;
            margin-bottom: 5px;
        }
        
        .top_option {
            width: 100%;
            margin-right: 0;
            margin-bottom: 15px;
        }
        
        .button-container {
            text-align: center;
        }
        
        .top_bt {
            width: 48%;
            margin: 5px 1%;
        }
    }
    
    /* 美化滚动条 */
    #Div1::-webkit-scrollbar {
        width: 8px;
        height: 8px;
    }
    
    #Div1::-webkit-scrollbar-track {
        background: #f1f1f1;
        border-radius: 4px;
    }
    
    #Div1::-webkit-scrollbar-thumb {
        background: linear-gradient(to bottom, #07f2e7, #071ec1);
        border-radius: 4px;
    }
    
    #Div1::-webkit-scrollbar-thumb:hover {
        background: linear-gradient(to bottom, #06d9cf, #0619b8);
    }
    
    /* 表单区域的渐变背景 */
    .form-container {
        background: linear-gradient(135deg, rgba(248, 248, 248, 0.9) 0%, rgba(255, 255, 255, 0.9) 100%);
        border-radius: 8px;
        padding: 20px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
    }
    
    /* 特殊字段高亮 */
    .top_option[type="date"] {
        background-color: #f8f9fa;
    }
    
    .top_option[type="month"] {
        background-color: #f8f9fa;
    }
    
    /* 下拉框美化 */
    select.top_option {
        background: linear-gradient(to bottom, white, #f8f9fa);
        cursor: pointer;
    }
    
    select.top_option option {
        padding: 8px;
    }
    
    /* 聚焦效果增强 */
    .top_option:focus {
        border-color: #4b77d0;
        box-shadow: 0 0 0 3px rgba(75, 119, 208, 0.2);
        transform: translateY(-1px);
    }
    
    /* 按钮的悬停和点击效果 */
    .top_bt:active {
        transform: translateY(0);
        box-shadow: 0 2px 4px rgba(46, 139, 87, 0.2);
    }
    
    /* 表单内的分隔线 */
    .form-section {
        margin-bottom: 20px;
        padding-bottom: 15px;
        border-bottom: 1px dashed #eee;
    }
    
    /* 最后一个表单部分去掉底部分隔线 */
    .form-section:last-child {
        border-bottom: none;
    }
</style>

<body style="margin: 0;" runat="server" height="100%" width="100%">
    <form id="form1" runat="server" height="600px" width="600px" class="asd">
        <div id="Div1" runat="server" style="height:100%; width: 100%;overflow-x:scroll" >
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
            <asp:label id="Label55" runat="server" text="录入时间" width="115px" height="30px"></asp:label>
            <asp:textbox runat="server" id="Textbox55" cssclass="top_option" textmode="month"></asp:textbox>
            <br />
            <%--<p style="margin-left: 500px; margin-top: 25px;">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" CssClass="top_bt" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" OnClick="Button2_Click" Text="返回" CssClass="top_bt" />
            </p>--%>

            <p style="margin-left: 340px">
                <asp:button id="Button1" runat="server" onclick="Button1_Click" text="保存" cssclass="top_bt" />
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
