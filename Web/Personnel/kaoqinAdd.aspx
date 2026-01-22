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
    <style>
    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
        background: white;
        border-radius: 12px;
        width: 100%;
    }
    
    body {
        background: linear-gradient(to right, #b9b6d0 0%, #4758cb 50%, #999df2 100%);
        padding: 20px;
        min-height: 100vh;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    
    #form1 {
        width: 100%;
        max-width: 1200px;
        margin: 0 auto;
    }
    
    #form1 > p:first-child {
        background: white;
        border-radius: 12px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        padding: 30px;
        border: 1px solid #e0e0e0;
        margin: 0 auto !important;
        width: 100% !important;
        height: auto !important;
        min-height: 460px;
    }
    
    /* 页面标题样式 */
    .form-title {
        background: linear-gradient(135deg, rgba(22, 10, 141, 0.95) 0%, rgba(59, 77, 203, 0.95) 50%, rgba(90, 95, 221, 0.95) 100%);
        color: white;
        padding: 15px 30px;
        border-radius: 12px 12px 0 0;
        text-align: center;
        font-size: 24px;
        font-weight: 700;
        text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
        margin: -30px -30px 30px -30px;
    }
    
    /* 表单容器样式 */
    .form-container {
        background: linear-gradient(135deg, rgba(248, 248, 248, 0.9) 0%, rgba(255, 255, 255, 0.9) 100%);
        border-radius: 8px;
        padding: 20px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
    }
    
    /* 基本信息行样式 */
    #form1 > p:first-child > br:first-child + asp:label {
        display: inline-block;
        margin-bottom: 20px;
    }
    
    /* 标签样式 */
    #form1 label {
        display: inline-block;
        height: 30px;
        line-height: 30px;
        font-weight: 600;
        color: #2E8B57;
        text-align: right;
        margin-right: 5px;
        margin-bottom: 10px;
        vertical-align: middle;
    }
    
    /* 基本信息标签宽度 */
    #Label1, #Label2, #Label3 {
        width: 60px;
    }
    
    /* 考勤标签宽度（1-31日） */
    #Label4, #Label5, #Label6, #Label7, #Label8, #Label9,
    #Label10, #Label11, #Label12, #Label13, #Label14, #Label15,
    #Label16, #Label17, #Label18, #Label19, #Label20, #Label21,
    #Label22, #Label23, #Label24, #Label25, #Label26, #Label27,
    #Label28, #Label29, #Label30, #Label31, #Label32, #Label33,
    #Label34 {
        width: 30px;
    }
    
    /* 统计标签宽度 */
    #Label35, #Label36, #Label37, #Label38, #Label39 {
        width: 41px;
    }
    
    /* 输入框和下拉框样式 */
    .top_select_input,
    .input1,
    #DropDownList4, #DropDownList5, #DropDownList6, #DropDownList7, #DropDownList8, #DropDownList9,
    #DropDownList10, #DropDownList11, #DropDownList12, #DropDownList13, #DropDownList14, #DropDownList15,
    #DropDownList16, #DropDownList17, #DropDownList18, #DropDownList19, #DropDownList20, #DropDownList21,
    #DropDownList22, #DropDownList23, #DropDownList24, #DropDownList25, #DropDownList26, #DropDownList27,
    #DropDownList28, #DropDownList29, #DropDownList30, #DropDownList31, #DropDownList32, #DropDownList33,
    #DropDownList34 {
        height: 30px;
        padding: 6px 12px;
        border: 1px solid #ddd;
        border-radius: 6px;
        font-size: 14px;
        transition: all 0.3s;
        margin-bottom: 10px;
        background: linear-gradient(to bottom, white, #f8f9fa);
        vertical-align: middle;
    }
    
    /* 基本信息输入框宽度 */
    #TextBox1, #TextBox2, #TextBox3 {
        width: 113px;
        margin-right: 20px;
    }
    
    #TextBox3 {
        margin-right: 0;
    }
    
    /* 考勤下拉框宽度 */
    #DropDownList4, #DropDownList5, #DropDownList6, #DropDownList7, #DropDownList8, #DropDownList9,
    #DropDownList10, #DropDownList11, #DropDownList12, #DropDownList13, #DropDownList14, #DropDownList15,
    #DropDownList16, #DropDownList17, #DropDownList18, #DropDownList19, #DropDownList20, #DropDownList21,
    #DropDownList22, #DropDownList23, #DropDownList24, #DropDownList25, #DropDownList26, #DropDownList27,
    #DropDownList28, #DropDownList29, #DropDownList30, #DropDownList31, #DropDownList32, #DropDownList33,
    #DropDownList34 {
        width: 50px;
        margin-right: 20px;
    }
    
    /* 统计输入框宽度 */
    #TextBox35, #TextBox36, #TextBox37, #TextBox38, #TextBox39 {
        width: 58px;
        margin-right: 20px;
        text-align: center;
    }
    
    #TextBox39 {
        margin-right: 0;
    }
    
    /* 聚焦效果 */
    .top_select_input:focus,
    .input1:focus,
    select:focus {
        outline: none;
        border-color: #3CB371;
        box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
        transform: translateY(-1px);
    }
    
    /* 下拉框美化 */
    select.top_select_input {
        cursor: pointer;
    }
    
    select.top_select_input option {
        padding: 8px;
        font-size: 13px;
    }
    
    /* 数字输入框特殊样式 */
    .top_select_input[type="number"]:focus {
        border-color: #4b77d0;
        box-shadow: 0 0 0 3px rgba(75, 119, 208, 0.2);
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
        margin: 10px;
    }
    
    .top_bt:hover {
        background: linear-gradient(to bottom, #07f2e7, #071ec1);
        transform: translateY(-2px);
        box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
    }
    
    .top_bt:active {
        transform: translateY(0);
        box-shadow: 0 2px 4px rgba(46, 139, 87, 0.2);
    }
    
    /* 按钮容器 */
    #form1 > p:last-child {
        text-align: center;
        margin-top: 30px;
        padding-top: 20px;
        border-top: 1px solid #eee;
        margin-left: 0 !important;
        width: 100% !important;
    }
    
    /* 美化滚动条 */
    #form1 > p:first-child::-webkit-scrollbar {
        width: 8px;
        height: 8px;
    }
    
    #form1 > p:first-child::-webkit-scrollbar-track {
        background: #f1f1f1;
        border-radius: 4px;
    }
    
    #form1 > p:first-child::-webkit-scrollbar-thumb {
        background: linear-gradient(to bottom, #07f2e7, #071ec1);
        border-radius: 4px;
    }
    
    #form1 > p:first-child::-webkit-scrollbar-thumb:hover {
        background: linear-gradient(to bottom, #06d9cf, #0619b8);
    }
    
    /* 考勤下拉框特殊样式 */
    #DropDownList4, #DropDownList5, #DropDownList6, #DropDownList7, #DropDownList8, #DropDownList9,
    #DropDownList10, #DropDownList11, #DropDownList12, #DropDownList13, #DropDownList14, #DropDownList15,
    #DropDownList16, #DropDownList17, #DropDownList18, #DropDownList19, #DropDownList20, #DropDownList21,
    #DropDownList22, #DropDownList23, #DropDownList24, #DropDownList25, #DropDownList26, #DropDownList27,
    #DropDownList28, #DropDownList29, #DropDownList30, #DropDownList31, #DropDownList32, #DropDownList33,
    #DropDownList34 {
        background-color: #f8f9fa;
        text-align: center;
    }
    
    /* 响应式设计 */
    @media (max-width: 1200px) {
        #form1 > p:first-child {
            padding: 20px;
            overflow-x: auto;
        }
        
        #form1 label {
            width: auto !important;
            text-align: left;
            margin-bottom: 5px;
        }
        
        .top_select_input,
        .input1,
        select {
            width: 100% !important;
            max-width: 150px;
            margin-right: 10px !important;
            margin-bottom: 15px;
        }
        
        .top_bt {
            width: 48%;
            margin: 5px 1%;
        }
        
        /* 考勤下拉框在移动端的布局 */
        #DropDownList4, #DropDownList5, #DropDownList6, #DropDownList7, #DropDownList8, #DropDownList9,
        #DropDownList10, #DropDownList11, #DropDownList12, #DropDownList13, #DropDownList14, #DropDownList15,
        #DropDownList16, #DropDownList17, #DropDownList18, #DropDownList19, #DropDownList20, #DropDownList21,
        #DropDownList22, #DropDownList23, #DropDownList24, #DropDownList25, #DropDownList26, #DropDownList27,
        #DropDownList28, #DropDownList29, #DropDownList30, #DropDownList31, #DropDownList32, #DropDownList33,
        #DropDownList34 {
            width: 40px !important;
            margin-right: 5px !important;
            font-size: 12px;
        }
    }
    
    @media (max-width: 768px) {
        body {
            padding: 10px;
        }
        
        #form1 > p:first-child {
            padding: 15px;
        }
        
        .top_select_input,
        .input1,
        select {
            max-width: 120px;
        }
        
        #DropDownList4, #DropDownList5, #DropDownList6, #DropDownList7, #DropDownList8, #DropDownList9,
        #DropDownList10, #DropDownList11, #DropDownList12, #DropDownList13, #DropDownList14, #DropDownList15,
        #DropDownList16, #DropDownList17, #DropDownList18, #DropDownList19, #DropDownList20, #DropDownList21,
        #DropDownList22, #DropDownList23, #DropDownList24, #DropDownList25, #DropDownList26, #DropDownList27,
        #DropDownList28, #DropDownList29, #DropDownList30, #DropDownList31, #DropDownList32, #DropDownList33,
        #DropDownList34 {
            width: 35px !important;
            margin-right: 3px !important;
            padding: 4px 6px;
            font-size: 11px;
        }
        
        #TextBox35, #TextBox36, #TextBox37, #TextBox38, #TextBox39 {
            width: 50px !important;
        }
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
        <p style=" width: 90%;margin-left: 7%;">
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
        <asp:DropDownList ID="DropDownList4" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox4" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label5" runat="server" Height="30px" Text="2：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList5" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label6" runat="server" Height="30px" Text="3：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList6" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox6" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label7" runat="server" Height="30px" Text="4：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList7" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox7" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label8" runat="server" Height="30px" Text="5：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList8" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox8" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label9" runat="server" Height="30px" Text="6：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList9" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
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
        <asp:DropDownList ID="DropDownList10" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox10" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label11" runat="server" Height="30px" Text="8：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList11" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox11" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label12" runat="server" Height="30px" Text="9：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList12" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox12" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label13" runat="server" Height="30px" Text="10：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList13" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox13" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label14" runat="server" Height="30px" Text="11：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList14" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox14" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label15" runat="server" Height="30px" Text="12：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList15" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
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
        <asp:DropDownList ID="DropDownList16" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox16" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label17" runat="server" Height="30px" Text="14：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList17" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox17" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label18" runat="server" Height="30px" Text="15：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList18" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox18" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label19" runat="server" Height="30px" Text="16：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList19" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox19" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label20" runat="server" Height="30px" Text="17：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList20" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox20" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label21" runat="server" Height="30px" Text="18：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList21" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
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
        <asp:DropDownList ID="DropDownList22" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox22" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label23" runat="server" Height="30px" Text="20：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList23" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox23" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label24" runat="server" Height="30px" Text="21：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList24" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox24" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label25" runat="server" Height="30px" Text="22：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList25" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox25" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label26" runat="server" Height="30px" Text="23：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList26" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox26" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label27" runat="server" Height="30px" Text="24：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList27" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
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
        <asp:DropDownList ID="DropDownList28" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox28" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label29" runat="server" Height="30px" Text="26：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList29" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox29" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label30" runat="server" Height="30px" Text="27：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList30" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox30" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label31" runat="server" Height="30px" Text="28：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList31" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox31" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label32" runat="server" Height="30px" Text="29：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList32" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>出勤</asp:ListItem>
            <asp:ListItem>旷勤</asp:ListItem>
            <asp:ListItem>请假</asp:ListItem>
            <asp:ListItem>迟到</asp:ListItem>
            <asp:ListItem>早退</asp:ListItem>
        </asp:DropDownList>
        <%--<asp:TextBox ID="TextBox32" runat="server" Height="30px" Width="50px" CssClass="top_select_input"></asp:TextBox>--%>
        <asp:Label ID="Label33" runat="server" Height="30px" Text="30：" Width="30px"></asp:Label>
        <asp:DropDownList ID="DropDownList33" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
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
        <asp:DropDownList ID="DropDownList34" runat="server" Height="30px" Width="100px"  CssClass="top_select_input">
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
