<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bumenxiangqing.aspx.cs" Inherits="Web.Personnel.bumenxiangqing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        align-items: flex-start;
    }
    
    #form1 {
        width: 100%;
        max-width: 1400px;
        margin: 0 auto;
    }
    
    #form1 > div {
        background: white;
        border-radius: 12px;
        box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        border: 1px solid #e0e0e0;
        margin: 0 auto;
        overflow: auto;
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
        margin: -30px -30px 20px -30px;
    }
    
    /* 搜索栏样式 */
    #form1 > div > #Label1 {
        display: inline-block;
        height: 30px;
        line-height: 30px;
        font-weight: 600;
        color: #2E8B57;
        text-align: right;
        margin-right: 10px;
        margin-bottom: 20px;
        width: 80px;
    }
    
    /* 搜索输入框 */
    #TextBox1 {
        height: 30px;
        padding: 6px 12px;
        border: 1px solid #ddd;
        border-radius: 6px;
        font-size: 14px;
        transition: all 0.3s;
        background: linear-gradient(to bottom, white, #f8f9fa);
        width: 150px;
        text-align: center !important;
        border: 0.5px solid #378888 !important;
    }
    
    #TextBox1:focus {
        outline: none;
        border-color: #3CB371 !important;
        box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
        transform: translateY(-1px);
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
        min-width: 80px;
        height: 35px;
        padding: 0 15px;
        font-size: 14px;
        margin: 0 5px;
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
    
    /* 返回按钮特殊样式 */
    #Button2 {
        display: block;
        height: 35px;
        font-size: 16px;
    }
    
    /* GridView样式增强 */
    #GridView1 {
        width: 100%;
        border-collapse: separate;
        border-spacing: 0;
        margin: 20px 0;
        border: 1px solid #e0e0e0;
        border-radius: 8px;
        overflow: hidden;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
    }
    
    /* 表头样式 */
    #GridView1 th.header {
        background: linear-gradient(135deg, rgba(59, 77, 203, 0.9) 0%, rgba(90, 95, 221, 0.9) 100%);
        color: white;
        font-weight: 600;
        text-align: center;
        padding: 12px 8px;
        border: none !important;
        border-bottom: 2px solid #4758cb !important;
        font-size: 14px;
    }
    
    /* 表头悬停效果 */
    #GridView1 th.header:hover {
        background: linear-gradient(135deg, rgba(59, 77, 203, 0.95) 0%, rgba(90, 95, 221, 0.95) 100%);
    }
    
    /* 数据行样式 */
    #GridView1 td.item {
        padding: 10px 8px;
        text-align: center;
        border: none !important;
        border-bottom: 1px solid #f0f0f0 !important;
        font-size: 13px;
        color: #333;
    }
    
    /* 斑马纹效果 */
    #GridView1 tr:nth-child(even) td.item {
        background-color: #f8f9fa;
    }
    
    #GridView1 tr:nth-child(odd) td.item {
        background-color: white;
    }
    
    /* 行悬停效果 */
    #GridView1 tr:hover td.item {
        background-color: #e8f4ff;
        transition: background-color 0.3s;
    }
    
    /* 数据列特殊样式 */
    #GridView1 td.item:first-child {
        font-weight: 500;
        color: #2E8B57;
    }
    
    /* 金额列样式（右对齐） */
    #GridView1 td.item:nth-child(n+5) {
        text-align: right;
        font-family: 'Consolas', 'Monaco', monospace;
        padding-right: 15px;
    }
    
    /* 合计行特殊样式 */
    #GridView1 tr:last-child td.item {
        background-color: #f0f8ff;
        font-weight: 600;
        color: #2E8B57;
        border-top: 2px solid #4758cb !important;
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
    
    /* 响应式设计 */
    @media (max-width: 1200px) {
        #form1 > div {
            padding: 20px;
            overflow-x: auto;
        }
        
        #GridView1 {
            min-width: 1000px;
        }
        
        #TextBox1 {
            width: 120px;
        }
        
        .top_bt {
            min-width: 70px;
            padding: 0 10px;
            font-size: 13px;
        }
    }
    
    @media (max-width: 768px) {
        body {
            padding: 10px;
        }
        
        #form1 > div {
            padding: 15px;
        }
        
        .page-title {
            margin: -15px -15px 15px -15px;
            padding: 12px 20px;
            font-size: 20px;
        }
        
        #Label1 {
            width: 60px !important;
            margin-right: 5px !important;
        }
        
        #TextBox1 {
            width: 100px;
            margin-right: 5px;
        }
        
        .top_bt {
            min-width: 60px;
            height: 30px;
            font-size: 12px;
            margin: 0 3px;
        }
        
        #Button2 {
            width: 100px;
            height: 35px;
            font-size: 14px;
        }
        
        #GridView1 th.header,
        #GridView1 td.item {
            padding: 8px 5px;
            font-size: 12px;
        }
    }
    
    /* 打印样式 */
    @media print {
        body {
            background: white !important;
            padding: 0 !important;
        }
        
        #form1 > div {
            box-shadow: none !important;
            border: 1px solid #ccc !important;
            padding: 10px !important;
        }
        
        .top_bt {
            display: none !important;
        }
        
        #GridView1 {
            box-shadow: none !important;
        }
    }
    
    /* 动画效果 */
    @keyframes fadeIn {
        from {
            opacity: 0;
            transform: translateY(10px);
        }
        to {
            opacity: 1;
            transform: translateY(0);
        }
    }
    
    #GridView1 {
        animation: fadeIn 0.5s ease-out;
    }
    
    /* 加载状态 */
    .loading-mask {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: rgba(255, 255, 255, 0.8);
        display: flex;
        justify-content: center;
        align-items: center;
        z-index: 1000;
        border-radius: 12px;
    }
    
    .loading-spinner {
        width: 40px;
        height: 40px;
        border: 3px solid #f3f3f3;
        border-top: 3px solid #4758cb;
        border-radius: 50%;
        animation: spin 1s linear infinite;
    }
    
    @keyframes spin {
        0% { transform: rotate(0deg); }
        100% { transform: rotate(360deg); }
    }
</style>
</head>
<body  style="    margin: 0;">
    <form id="form1" runat="server">
    <div>
    
        
        <div style="display:flex;margin-top: 20px; margin-left: 10px;">
            <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px"></asp:Label>
    
            <asp:TextBox ID="TextBox1" runat="server" CssClass="top_select_input"  Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" CssClass="top_bt" />
            <asp:Button ID="Button3" runat="server" Text="所有" OnClick="Button3_Click" CssClass="top_bt" />
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <%--<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />--%>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" />
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" />
                <asp:BoundField DataField="D" HeaderText="岗位" SortExpression="D" />
                <%--<asp:BoundField DataField="E" HeaderText="E" SortExpression="E" />
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F" />
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G" />
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H" />
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I" />
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J" />
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K" />
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L" />
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M" />
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N" />
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q" />
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T" />
                <asp:BoundField DataField="U" HeaderText="U" SortExpression="U" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X" />
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y" />--%>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" />
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" />
                <asp:BoundField DataField="count1" HeaderText="个人养老" SortExpression="count1" />
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" />
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" />
                <asp:BoundField DataField="count1" HeaderText="失业小计" SortExpression="count1" />
                <%--<asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB" />--%>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" />
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" />
                <%--<asp:BoundField DataField="AE" HeaderText="AE" SortExpression="AE" />
                <asp:BoundField DataField="AF" HeaderText="AF" SortExpression="AF" />
                <asp:BoundField DataField="AG" HeaderText="AG" SortExpression="AG" />
                <asp:BoundField DataField="AH" HeaderText="AH" SortExpression="AH" />
                <asp:BoundField DataField="AI" HeaderText="AI" SortExpression="AI" />--%>
                <%--<asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                <asp:BoundField DataField="AM" HeaderText="AM" SortExpression="AM" />
                <asp:BoundField DataField="AN" HeaderText="AN" SortExpression="AN" />
                <asp:BoundField DataField="AO" HeaderText="AO" SortExpression="AO" />
                <asp:BoundField DataField="AP" HeaderText="AP" SortExpression="AP" />
                <asp:BoundField DataField="AQ" HeaderText="AQ" SortExpression="AQ" />
                <asp:BoundField DataField="AR" HeaderText="AR" SortExpression="AR" />
                <asp:BoundField DataField="ASA" HeaderText="ASA" SortExpression="ASA" />
                <asp:BoundField DataField="ATA" HeaderText="ATA" SortExpression="ATA" />
                <asp:BoundField DataField="AU" HeaderText="AU" SortExpression="AU" />
                <asp:BoundField DataField="AV" HeaderText="AV" SortExpression="AV" />
                <asp:BoundField DataField="AW" HeaderText="AW" SortExpression="AW" />
                <asp:BoundField DataField="AX" HeaderText="AX" SortExpression="AX" />
                <asp:BoundField DataField="AY" HeaderText="AY" SortExpression="AY" />
                <asp:BoundField DataField="AZ" HeaderText="AZ" SortExpression="AZ" />
                <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA" />
                <asp:BoundField DataField="BB" HeaderText="BB" SortExpression="BB" />
                <asp:BoundField DataField="BC" HeaderText="BC" SortExpression="BC" />
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD" />--%>
                <asp:BoundField DataField="count3" HeaderText="企业合计" SortExpression="count3" />
                <asp:BoundField DataField="count4" HeaderText="个人合计" SortExpression="count4" />
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString43 %>" SelectCommand="select id,B,C,D,Z,AJ,(Z+AJ)AS count1,AA,AK,(AA+AK)AS count2,AC,AD,(Z+AA+AC+AD)AS count3,(AJ+AK)AS count4 FROM gongzi_gongzimingxi WHERE (([BD] like '%'+ @BD +'%') AND ([B] like '%'+ @B +'%') AND ([C] like '%'+ @C +'%'))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString42 %>" SelectCommand="select id,B,C,D,Z,AJ,(Z+AJ)AS count1,AA,AK,(AA+AK)AS count2,AC,AD,(Z+AA+AC+AD)AS count3,(AJ+AK)AS count4 FROM gongzi_gongzimingxi WHERE (([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%'))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"  CssClass="top_bt"  style="margin-left:46%;"/>
    
    </div>
    </form>
</body>
</html>
