<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renyuanxinxiAdd.aspx.cs" Inherits="Web.Personnel.renyuanxinxiAdd" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>

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
        <div>
            <div style="width: 50%;margin-left: 30%;margin-top: 4%;">
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
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click"  CssClass="top_bt" />
                 &nbsp;
            <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"  CssClass="top_bt" />
                 &nbsp;
            <asp:Button ID="Button3" runat="server" Text="权限" OnClick="Button3_Click"  CssClass="top_bt" />
                 &nbsp;
            <asp:Button ID="Button4" runat="server" Text="更多" OnClick="Button4_Click"   CssClass="top_bt" />
          </div>
        </div>
    </form>
</body>
</html>
