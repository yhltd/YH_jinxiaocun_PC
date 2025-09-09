<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="peizhi.aspx.cs" Inherits="Web.Personnel.peizhi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
    <script lang="javaScript">
        //function aaa() {
        //    document.getElementById("SqlDataSource2").SelectCommand = "SELECT [yi], [er] FROM [gongzi_shezhi];";
        //}
    </script>

<body  style="    margin: 0;">
     <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Segoe UI', 'Microsoft YaHei', sans-serif;
        }
        
        body {
            background: linear-gradient(135deg, #f5f7fa 0%, #e4e8f0 100%);
            padding: 20px;
            min-height: 100vh;
            display: flex;
        }
       .ti {
            background: linear-gradient(135deg, #2E8B57 0%, #3CB371 30%, #20B2AA 100%);
            color: white;
            padding: 6px 30px;
            border-radius: 12px 12px 0 0;
            display: flex;
            justify-content: space-between;
            align-items: center;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            position: relative;
            overflow: hidden;
        }
        
        .ti h1 {
            margin: 0;
            font-size: 24px;
            font-weight: 700;
            text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
            z-index: 2;
        }
        
        .ti::before {
            content: "";
            position: absolute;
            top: -50%;
            right: -50%;
            width: 80%;
            height: 200%;
            background: rgba(255, 255, 255, 0.1);
            transform: rotate(25deg);
            z-index: 1;
        }
        
        .ti-content {
            display: flex;
            align-items: center;
            z-index: 2;
        }
        
        .ti-stats {
            display: flex;
            gap: 25px;
            margin-right: 20px;
        }
        
        .stat-item {
            text-align: center;
            padding: 0 15px;
            border-right: 1px solid rgba(255, 255, 255, 0.3);
        }
        
        .stat-item:last-child {
            border-right: none;
        }
        
        .stat-value {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 5px;
        }
        
        .stat-label {
            font-size: 14px;
            opacity: 0.9;
        }
        
        /* 表单区域样式 */
        .header-top {
            background: white;
            padding: 20px 30px;
            border-radius: 0 0 12px 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            align-items: center;
            margin-bottom:10px;
        }
        
        .header-top label {
            font-weight: 600;
            color: #2E8B57;
            margin-right: 8px;
            min-width: 80px;
            display: inline-block;
        }
        
        .top_select_input {
            padding: 12px 15px;
            border: 1px solid #ddd;
            border-radius: 6px;
            font-size: 15px;
            width: 150px;
            transition: all 0.3s;
        }
        
        .top_select_input:focus {
            outline: none;
            border-color: #3CB371;
            box-shadow: 0 0 0 2px rgba(46, 139, 87, 0.2);
        }
        
        .top_bt {
            background: linear-gradient(to right, #2E8B57, #3CB371);
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            min-width: 80px;
            height: 42px;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            line-height:8px;
        }
        
        .top_bt:hover {
            background: linear-gradient(to right, #26734d, #2fa866);
            transform: translateY(-2px);
            box-shadow: 0 4px 8px rgba(46, 139, 87, 0.3);
        }
        
        /* 响应式调整 */
        @media (max-width: 768px) {
            .ti {
                flex-direction: column;
                text-align: center;
                gap: 20px;
            }
            
            .ti-stats {
                margin-right: 0;
                justify-content: center;
            }
            
            .header-top {
                flex-direction: column;
                align-items: stretch;
            }
            
            .top_select_input {
                width: 100%;
            }
        }

        .personnel-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }
        
        table#ridView1 th[scope="col"],
        table th[scope="col"] {
            background: linear-gradient(to bottom, #2E8B57, #3CB371) !important;
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            border: none !important;
        }
        
        table#GridView1 tr.item:nth-child(even),
        table tr.item:nth-child(even) {
            background: linear-gradient(to bottom, #FFF9C4, #FFF8E1) !important;
        }

        /* 针对奇数行 */
        table#GridView1 tr.item:nth-child(odd),
        table tr.item:nth-child(odd) {
            background: linear-gradient(to bottom, #E0F2F1, #C8E6C9) !important;
        }

        /* 行悬停效果 */
        table#GridView1 tr.item:hover,
        table tr.item:hover {
            background: linear-gradient(to bottom, #E1F5FE, #B3E5FC) !important;
            cursor: pointer;
        }

        /* 确保单元格也有背景色 */
        table#GridView1 tr.item td,
        table tr.item td {
            border: 1px solid #ddd !important;
            padding: 10px !important;
        }

        /* 针对可能的内联样式 */
        tr[class*="item"] {
            background-image: none !important; /* 清除可能的内联背景 */
        }

        table {
            border-collapse: separate !important;
            border-spacing: 0 !important;
            width: 100%;
            border-radius: 8px !important;
            overflow: hidden !important;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15), 
                        0 2px 6px rgba(0, 0, 0, 0.1) !important;
            background: white !important;
            border: 1px solid #ddd !important;
        }

        /* 表头立体效果 */
        table th {
            background: linear-gradient(to bottom, #4CAF50, #2E8B57) !important;
            color: white !important;
            padding: 15px !important;
            text-align: center !important;
            font-weight: 600 !important;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.3) !important;
            border-bottom: 2px solid #1B5E20 !important;
            position: relative;
        }

        /* 表头底部阴影，增强立体感 */
        table th:after {
            content: '';
            position: absolute;
            bottom: 0;
            left: 0;
            width: 100%;
            height: 2px;
            background: linear-gradient(to right, 
                rgba(0,0,0,0.1) 0%, 
                rgba(0,0,0,0.2) 50%, 
                rgba(0,0,0,0.1) 100%) !important;
        }

        /* 单元格立体效果 */
        table td {
            padding: 12px 15px !important;
            border: 1px solid #e0e0e0 !important;
            position: relative;
        }

        /* 单元格内部阴影，增强立体感 */
        table td:before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.05) !important;
            pointer-events: none;
        }

        /* 斑马条纹效果 - 立体版本 */
        table tr:nth-child(even) td {
            background: linear-gradient(to bottom, #f9f9f9, #f0f0f0) !important;
        }

        table tr:nth-child(odd) td {
            background: linear-gradient(to bottom, #ffffff, #f7f7f7) !important;
        }

        /* 行悬停效果 - 立体版本 */
        table tr:hover td {
            background: linear-gradient(to bottom, #e8f5e9, #c8e6c9) !important;
            box-shadow: inset 0 0 10px rgba(46, 139, 87, 0.1) !important;
        }

        /* 表格底部阴影，增强整体立体感 */
        table:after {
            content: '';
            position: absolute;
            bottom: -5px;
            left: 5px;
            right: 5px;
            height: 5px;
            background: linear-gradient(to bottom, 
                rgba(0,0,0,0.1) 0%, 
                rgba(0,0,0,0.05) 50%, 
                transparent 100%) !important;
            border-radius: 0 0 8px 8px;
            z-index: -1;
        }

        /* 为表格容器添加额外阴影增强立体感 */
        .table-container {
            position: relative;
            margin: 20px 0;
        }

        .table-container:before {
            content: '';
            position: absolute;
            top: 5px;
            left: 10px;
            right: 10px;
            bottom: -5px;
            background: rgba(0,0,0,0.05);
            border-radius: 8px;
            z-index: -1;
        }
    </style>
    
    <form id="form1" runat="server">
        <div>
    <div class="iframe_d">
    
    </div>
    <div class="div1">
        <div class="ti">
            <h1>配置表</h1>
        </div>
        <div class="header-top">

        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" OnRowCreated="aaa">
            <Columns>
                <asp:CommandField ShowEditButton="True"   ButtonType="Button" ItemStyle-CssClass="bt_upd1" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                    
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                
                </asp:CommandField>
                <asp:BoundField DataField="gongsi" HeaderText="公司" SortExpression="gongsi" Visible="false"/>
                <asp:BoundField DataField="kaoqin" HeaderText="社保基数" SortExpression="kaoqin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="kaoqin_peizhi" HeaderText="公积金基数" SortExpression="kaoqin_peizhi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="bumen" HeaderText="部门配置" SortExpression="bumen" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="zhiwu" HeaderText="职务配置" SortExpression="zhiwu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="chidao_koukuan" HeaderText="迟到扣款" SortExpression="chidao_koukuan" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_yiliao" HeaderText="个人医疗" SortExpression="geren_yiliao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_yiliao" HeaderText="企业医疗" SortExpression="qiye_yiliao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_shengyu" HeaderText="个人生育" SortExpression="geren_shengyu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_shengyu" HeaderText="企业生育" SortExpression="qiye_shengyu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_gongjijin" HeaderText="个人公积金" SortExpression="geren_gongjijin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_gongjijin" HeaderText="企业公积金" SortExpression="qiye_gongjijin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="yiliao_jishu" HeaderText="医疗基数" SortExpression="yiliao_jishu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_nianjin" HeaderText="个人年金" SortExpression="geren_nianjin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_nianjin" HeaderText="企业年金" SortExpression="qiye_nianjin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="zhinajin" HeaderText="滞纳金" SortExpression="zhinajin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="nianjin_jishu" HeaderText="年金基数" SortExpression="nianjin_jishu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="lixi" HeaderText="利息" SortExpression="lixi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_yanglao" HeaderText="个人养老" SortExpression="geren_yanglao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_yanglao" HeaderText="企业养老" SortExpression="qiye_yanglao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="gangwei" HeaderText="岗位" SortExpression="gangwei" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="gangwei_gongzi" HeaderText="岗位工资" SortExpression="gangwei_gongzi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_shiye" HeaderText="个人失业" SortExpression="geren_shiye" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_shiye" HeaderText="企业失业" SortExpression="qiye_shiye" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="gongzi" HeaderText="工资" SortExpression="gongzi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="shuilv" HeaderText="税率" SortExpression="shuilv" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="kuadu_gongzi" HeaderText="跨度工资" SortExpression="kuadu_gongzi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_gongshang" HeaderText="企业工伤" SortExpression="qiye_gongshang" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="jintie" HeaderText="职称津贴" SortExpression="jintie" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="nianjin1" HeaderText="年金1%" SortExpression="nianjin1" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="jiabanfei" HeaderText="加班费" SortExpression="jiabanfei" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="yansuangongshi" HeaderText="验算公式" SortExpression="yansuangongshi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="queqin_koukuan" HeaderText="缺勤扣款" SortExpression="queqin_koukuan" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" Visible="false"/>
                <asp:BoundField DataField="month" HeaderText="month" SortExpression="month" Visible="false"/>
                <asp:BoundField DataField="day" HeaderText="day" SortExpression="day" Visible="false"/>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString44 %>" DeleteCommand="DELETE FROM [gongzi_peizhi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_peizhi] ([gongsi], [kaoqin], [kaoqin_peizhi], [bumen], [zhiwu], [year], [month], [day]) VALUES (@gongsi, @kaoqin, @kaoqin_peizhi, @bumen, @zhiwu, @year, @month, @day)" SelectCommand="SELECT * FROM [gongzi_peizhi] WHERE ([gongsi] = @gongsi)" UpdateCommand="UPDATE [gongzi_peizhi] SET [kaoqin] = @kaoqin, [kaoqin_peizhi] = @kaoqin_peizhi, [bumen] = @bumen, [zhiwu] = @zhiwu, [year] = @year, [month] = @month, [day] = @day, [chidao_koukuan] = @chidao_koukuan, geren_yiliao = @geren_yiliao, qiye_yiliao= @qiye_yiliao, geren_shengyu = @geren_shengyu, qiye_shengyu = @qiye_shengyu, geren_gongjijin = @geren_gongjijin, qiye_gongjijin= @qiye_gongjijin, yiliao_jishu = @yiliao_jishu, geren_nianjin = @geren_nianjin, zhinajin = @zhinajin, nianjin_jishu= @nianjin_jishu, lixi = @lixi, geren_yanglao= @geren_yanglao, qiye_yanglao = @qiye_yanglao, gangwei = @gangwei, gangwei_gongzi = @gangwei_gongzi, qiye_shiye = @qiye_shiye , gongzi = @gongzi , shuilv = @shuilv, kuadu_gongzi = @kuadu_gongzi, qiye_gongshang= @qiye_gongshang, jintie = @jintie, qiye_nianjin = @qiye_nianjin, nianjin1 = @nianjin1, jiabanfei = @jiabanfei, yansuangongshi = @yansuangongshi , queqin_koukuan= @queqin_koukuan, geren_shiye = @geren_shiye  WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="gongsi" Type="String" />
                <asp:Parameter Name="kaoqin" Type="String" />
                <asp:Parameter Name="kaoqin_peizhi" Type="String" />
                <asp:Parameter Name="bumen" Type="String" />
                <asp:Parameter Name="zhiwu" Type="String" />
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="month" Type="String" />
                <asp:Parameter Name="day" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="kaoqin" Type="String" />
                <asp:Parameter Name="kaoqin_peizhi" Type="String" />
                <asp:Parameter Name="bumen" Type="String" />
                <asp:Parameter Name="zhiwu" Type="String" />
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="month" Type="String" />
                <asp:Parameter Name="day" Type="String" />
                <asp:Parameter Name="chidao_koukuan" />
                <asp:Parameter Name="geren_yiliao" />
                <asp:Parameter Name="qiye_yiliao" />
                <asp:Parameter Name="geren_shengyu" />
                <asp:Parameter Name="qiye_shengyu" />
                <asp:Parameter Name="geren_gongjijin" />
                <asp:Parameter Name="qiye_gongjijin" />
                <asp:Parameter Name="yiliao_jishu" />
                <asp:Parameter Name="geren_nianjin" />
                <asp:Parameter Name="zhinajin" />
                <asp:Parameter Name="nianjin_jishu" />
                <asp:Parameter Name="lixi" />
                <asp:Parameter Name="geren_yanglao" />
                <asp:Parameter Name="qiye_yanglao" />
                <asp:Parameter Name="gangwei" />
                <asp:Parameter Name="gangwei_gongzi" />
                <asp:Parameter Name="qiye_shiye" />
                <asp:Parameter Name="gongzi" />
                <asp:Parameter Name="shuilv" />
                <asp:Parameter Name="kuadu_gongzi" />
                <asp:Parameter Name="qiye_gongshang" />
                <asp:Parameter Name="jintie" />
                <asp:Parameter Name="qiye_nianjin" />
                <asp:Parameter Name="nianjin1" />
                <asp:Parameter Name="jiabanfei" />
                <asp:Parameter Name="yansuangongshi" />
                <asp:Parameter Name="queqin_koukuan" />
                <asp:Parameter Name="geren_shiye" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加一行"  CssClass="top_bt" Height="30px" Width="80px" style="margin-left:4.3%;margin-top:1%"/>
        </div>
            </div>
    </form>
    
</body>
</html>
