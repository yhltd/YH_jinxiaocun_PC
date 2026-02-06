<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shebao.aspx.cs" Inherits="Web.Personnel.shebao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
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
            padding: 10px;
            min-height: 100vh;
            display: flex;
        }
       .ti {
            background: linear-gradient(135deg, rgba(22, 10, 141, 0.95) 0%, rgba(59, 77, 203, 0.95) 50%, rgba(90, 95, 221, 0.95) 100%);
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
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
            transition: all 0.3s;
            min-width: 80px;
            height: 30px;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            line-height:8px;
        }
        
        .top_bt:hover {
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
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
            background: linear-gradient(to bottom, #4b77d0, #0521e8);
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
    
    <form id="form1" runat="server"  style="margin: 0;width:100%">
    <div>
        <div class="ti">
            <h1>社保</h1>
        </div>
        <div class="header-top" >
        <asp:Label ID="Label1" runat="server" Height="30px" Text="部门：" Width="80px" style="text-align:center"></asp:Label>
    
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="C" DataValueField="C"  CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click"   CssClass="top_bt" style="margin-right:-10px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="社保详情"   CssClass="top_bt" style="margin-right:-10px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有"   CssClass="top_bt" style="margin-right:-10px" />
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString41 %>" SelectCommand="SELECT [C], [BD] FROM [gongzi_gongzimingxi] WHERE ([BD] = @gongsi)  GROUP BY [C], [BD]">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataSourceID="SqlDataSource1">
            <Columns>
<%--                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" Visible="false"/>--%>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" HeaderStyle-Font-Bold="true" />
<%--                <asp:BoundField DataField="D" HeaderText="D" SortExpression="D" Visible="false"/>
                <asp:BoundField DataField="E" HeaderText="E" SortExpression="E" Visible="false"/>
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F" Visible="false"/>
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G" Visible="false"/>
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H" Visible="false"/>
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I" Visible="false"/>
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J" Visible="false"/>
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K" Visible="false"/>
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L" Visible="false"/>
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M" Visible="false"/>
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N" Visible="false"/>
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O" Visible="false"/>
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" Visible="false"/>
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q" Visible="false"/>
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R" Visible="false"/>
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" Visible="false"/>
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T" Visible="false"/>
                <asp:BoundField DataField="U" HeaderText="U" SortExpression="U" Visible="false"/>
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" Visible="false"/>
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" Visible="false"/>
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X" Visible="false"/>
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y" Visible="false"/>--%>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" HeaderStyle-Font-Bold="true"/>
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" HeaderStyle-Font-Bold="true"/>
                <asp:BoundField DataField="count1" HeaderText="养老小计" SortExpression="count1" HeaderStyle-Font-Bold="true" />
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" HeaderStyle-Font-Bold="true"/>
<%--                <asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB" Visible="false"/>
                <asp:BoundField DataField="AE" HeaderText="AE" SortExpression="AE" Visible="false"/>
                <asp:BoundField DataField="AF" HeaderText="AF" SortExpression="AF" Visible="false"/>
                <asp:BoundField DataField="AG" HeaderText="AG" SortExpression="AG" Visible="false"/>
                <asp:BoundField DataField="AH" HeaderText="AH" SortExpression="AH" Visible="false"/>
                <asp:BoundField DataField="AI" HeaderText="AI" SortExpression="AI" Visible="false"/>--%>
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" HeaderStyle-Font-Bold="true"/>
                <asp:BoundField DataField="count2" HeaderText="失业小计" SortExpression="count2" HeaderStyle-Font-Bold="true"/>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" HeaderStyle-Font-Bold="true"/>
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" HeaderStyle-Font-Bold="true"/>
<%--                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" Visible="false"/>
                <asp:BoundField DataField="AM" HeaderText="AM" SortExpression="AM" Visible="false"/>
                <asp:BoundField DataField="AN" HeaderText="AN" SortExpression="AN" Visible="false"/>
                <asp:BoundField DataField="AO" HeaderText="AO" SortExpression="AO" Visible="false"/>
                <asp:BoundField DataField="AP" HeaderText="AP" SortExpression="AP" Visible="false"/>
                <asp:BoundField DataField="AQ" HeaderText="AQ" SortExpression="AQ" Visible="false"/>
                <asp:BoundField DataField="AR" HeaderText="AR" SortExpression="AR" Visible="false"/>
                <asp:BoundField DataField="ASA" HeaderText="ASA" SortExpression="ASA" Visible="false"/>
                <asp:BoundField DataField="ATA" HeaderText="ATA" SortExpression="ATA" Visible="false"/>
                <asp:BoundField DataField="AU" HeaderText="AU" SortExpression="AU" Visible="false"/>
                <asp:BoundField DataField="AV" HeaderText="AV" SortExpression="AV" Visible="false"/>
                <asp:BoundField DataField="AW" HeaderText="AW" SortExpression="AW" Visible="false"/>
                <asp:BoundField DataField="AX" HeaderText="AX" SortExpression="AX" Visible="false"/>
                <asp:BoundField DataField="AY" HeaderText="AY" SortExpression="AY" Visible="false"/>
                <asp:BoundField DataField="AZ" HeaderText="AZ" SortExpression="AZ" Visible="false"/>
                <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA" Visible="false"/>
                <asp:BoundField DataField="BB" HeaderText="BB" SortExpression="BB" Visible="false"/>
                <asp:BoundField DataField="BC" HeaderText="BC" SortExpression="BC" Visible="false"/>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD" Visible="false"/>--%>
                <asp:BoundField DataField="count3" HeaderText="企业合计" SortExpression="count3" HeaderStyle-Font-Bold="true"/>
                <asp:BoundField DataField="count4" HeaderText="个人合计" SortExpression="count4" HeaderStyle-Font-Bold="true"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString40 %>" SelectCommand="select C ,sum(cast(Z as float))as Z,sum(cast(AJ as float))as AJ,sum(cast(Z as float)+cast(AJ as float))as count1,sum(cast(AA as float))as AA,sum (CAST(AK as float))as AK,sum(cast(AA as float)+cast(AK as float))as count2,sum(cast(AC as float))as AC,sum(cast(AD as float))as AD,sum(cast(Z as float)+cast(AA as float)+cast(AC as float)+cast(AD as float))as count3,sum(cast(AJ as float)+cast(AK as float))as count4 from gongzi_gongzimingxi where (([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%')) group by C">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString34 %>" SelectCommand="select C ,sum(cast(Z as float))as Z,sum(cast(AJ as float))as AJ,sum(cast(Z as float)+cast(AJ as float))as count1,sum(cast(AA as float))as AA,sum (CAST(AK as float))as AK,sum(cast(AA as float)+cast(AK as float))as count2,sum(cast(AC as float))as AC,sum(cast(AD as float))as AD,sum(cast(Z as float)+cast(AA as float)+cast(AC as float)+cast(AD as float))as count3,sum(cast(AJ as float)+cast(AK as float))as count4 from gongzi_gongzimingxi where ([BD] like '%'+ @BD +'%')  group by C">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
