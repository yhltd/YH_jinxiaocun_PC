<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kaoqinjiluAdd.aspx.cs" Inherits="Web.Personnel.kaoqinjiluAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>

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
        align-items: center;
    }
    
    form {
        width: 100%;
        max-width: 800px;
    }
    
    #form1 > div {
        background: white;
        border-radius: 12px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        padding: 30px;
        border: 1px solid #e0e0e0;
        margin: 0 auto;
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
    
    /* 标签样式 */
    #form1 label {
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
    .top_select_input,
    #DropDownList1 {
        width: 150px;
        height: 30px;
        padding: 6px 12px;
        border: 1px solid #ddd;
        border-radius: 6px;
        font-size: 14px;
        transition: all 0.3s;
        margin-bottom: 15px;
        background: linear-gradient(to bottom, white, #f8f9fa);
    }
    
    .top_select_input:focus,
    #DropDownList1:focus {
        outline: none;
        border-color: #3CB371;
        box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
        transform: translateY(-1px);
    }
    
    .top_select_input[type="number"] {
        text-align: right;
    }
    
    /* 数字输入框特殊样式 */
    .top_select_input[type="number"]:focus {
        border-color: #4b77d0;
        box-shadow: 0 0 0 3px rgba(75, 119, 208, 0.2);
    }
    
    /* 下拉框美化 */
    #DropDownList1 {
        cursor: pointer;
    }
    
    #DropDownList1 option {
        padding: 8px;
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
    
    .top_bt:active {
        transform: translateY(0);
        box-shadow: 0 2px 4px rgba(46, 139, 87, 0.2);
    }
    
    /* 按钮容器 */
    .button-container {
        text-align: center;
        margin-top: 30px;
        padding-top: 20px;
        border-top: 1px solid #eee;
    }
    
    /* 表单行间距 */
    br {
        display: none;
    }
    
    /* 响应式设计 */
    @media (max-width: 768px) {
        body {
            padding: 10px;
        }
        
        #form1 > div {
            padding: 15px;
        }
        
        #form1 label {
            width: 100%;
            text-align: left;
            margin-bottom: 5px;
        }
        
        .top_select_input,
        #DropDownList1 {
            width: 100%;
            margin-bottom: 15px;
        }
        
        .top_bt {
            width: 48%;
            margin: 5px 1%;
        }
        
        .form-title {
            margin: -15px -15px 15px -15px;
            padding: 12px 20px;
            font-size: 20px;
        }
    }
    
    /* 美化滚动条 */
    #form1 > div::-webkit-scrollbar {
        width: 8px;
        height: 8px;
    }
    
    #form1 > div::-webkit-scrollbar-track {
        background: #f1f1f1;
        border-radius: 4px;
    }
    
    #form1 > div::-webkit-scrollbar-thumb {
        background: linear-gradient(to bottom, #07f2e7, #071ec1);
        border-radius: 4px;
    }
    
    #form1 > div::-webkit-scrollbar-thumb:hover {
        background: linear-gradient(to bottom, #06d9cf, #0619b8);
    }
</style>
</head>
<body style="    margin: 0;">
    <form id="form1" runat="server">
    <div style="margin-left: 400px">
    
        <asp:Label ID="Label1" runat="server" Text="姓名：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="150px"  CssClass="top_select_input" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="年份：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="150px" CssClass="top_select_input" TextMode="Number" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"> </asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="月份：" Width="80px" Height="30px"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="150px" CssClass="top_select_input" TextMode="Number" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" MaxLength="15"> </asp:TextBox>
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
