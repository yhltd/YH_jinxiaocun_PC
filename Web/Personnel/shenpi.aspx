<%@ page language="C#" autoeventwireup="true" codebehind="shenpi.aspx.cs" inherits="Web.Personnel.shenpi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
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
            background: linear-gradient(to bottom, #07f2e7, #071ec1);
            color: white;
            border: none;
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
    
    <form id="form1" runat="server" style="width:100%">
        <div>
            <div  class="ti">
                <h1>审批记录</h1>
            </div>
            <div class="header-top" >
            <asp:label id="Label1" runat="server" height="30px" text="姓名：" width="80px" style="text-align: center"></asp:label>
            <asp:textbox id="TextBox1" runat="server" cssclass="top_select_input" height="30px" width="150px" style="margin-right: -10px; border: 0.5px solid #378888"></asp:textbox>
            <asp:label id="Label12" runat="server" height="30px" text="开始时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="ks" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            <asp:label id="Label13" runat="server" height="30px" text="结束时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="js" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            
            <asp:button id="Button1" runat="server" onclick="Button1_Click" text="搜索" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <asp:button id="Button2" runat="server" onclick="Button2_Click" text="所有" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <br />
            </div>
            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" datasourceid="SqlDataSource1" allowpaging="True" datakeynames="id" onrowcreated="aaa">
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd1">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                    </asp:CommandField>

                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                    <asp:BoundField DataField="shifa_gongzi" HeaderText="实发工资" SortExpression="shifa_gongzi"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        </asp:BoundField>
                    <asp:BoundField DataField="geren_zhichu" HeaderText="个人支出" SortExpression="geren_zhichu"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        </asp:BoundField>
                    <asp:BoundField DataField="qiye_zhichu" HeaderText="企业支出" SortExpression="qiye_zhichu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="yuangong_renshu" HeaderText="员工人数" SortExpression="yuangong_renshu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="quanqin_tianshu" HeaderText="全勤天数" SortExpression="quanqin_tianshu"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        </asp:BoundField>
                    <asp:BoundField DataField="shenpiren" HeaderText="审批人" SortExpression="shenpiren" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="riqi" HeaderText="日期" SortExpression="riqi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="gongsi" HeaderText="公司" SortExpression="gongsi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                </Columns>
                <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
                <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
                <SelectedRowStyle CssClass="header" />
            </asp:gridview>
            <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString39 %>" deletecommand="DELETE FROM [gongzi_shenpi] WHERE [id] = @id" selectcommand="if exists(SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%' and shenpiren like '%'+ @shenpiren +'%' and convert(date,riqi)&gt;=@ks and convert(date,riqi)&lt;=@js )) begin SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%' and shenpiren like '%'+ @shenpiren +'%' and convert(date,riqi)&gt;=@ks and convert(date,riqi)&lt;=@js ) end else SELECT * FROM [gongzi_shenpi] where id=0 union  select  '','','','','','','','',''" updatecommand="UPDATE [gongzi_shenpi] SET [shifa_gongzi] = @shifa_gongzi, [qiye_zhichu] = @qiye_zhichu, [geren_zhichu] = @geren_zhichu, [yuangong_renshu] = @yuangong_renshu, [quanqin_tianshu] = @quanqin_tianshu, [shenpiren] = @shenpiren, [riqi] = @riqi WHERE [id] = @id">   <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                    <asp:SessionParameter Name="shenpiren" SessionField="shenpiren"  Type="String"/>
                    <%--<asp:SessionParameter Name="ks" SessionField="ks"  Type="String"/>
                    <asp:Parameter Name="js" Type="String" />--%>

                    <asp:SessionParameter Name="ks" SessionField="ks" />
                    <asp:SessionParameter Name="js" SessionField="js" />

                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="shifa_gongzi" />
                    <asp:Parameter Name="qiye_zhichu" />
                    <asp:Parameter Name="geren_zhichu" />
                    <asp:Parameter Name="yuangong_renshu" />
                    <asp:Parameter Name="quanqin_tianshu" />
                    <asp:Parameter Name="shenpiren" />
                    <asp:Parameter Name="riqi" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:sqldatasource>
            <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString38 %>" deletecommand="DELETE FROM [gongzi_shenpi] WHERE [id] = @id" selectcommand="if exists(SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%')) begin SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%') end else select '','','','','','','',''" updatecommand="UPDATE [gongzi_shenpi] SET [shifa_gongzi] = @shifa_gongzi, [qiye_zhichu] = @qiye_zhichu, [geren_zhichu] = @geren_zhichu, [yuangong_renshu] = @yuangong_renshu, [quanqin_tianshu] = @quanqin_tianshu, [shenpiren] = @shenpiren, [riqi] = @riqi WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="shifa_gongzi" />
                    <asp:Parameter Name="qiye_zhichu" />
                    <asp:Parameter Name="geren_zhichu" />
                    <asp:Parameter Name="yuangong_renshu" />
                    <asp:Parameter Name="quanqin_tianshu" />
                    <asp:Parameter Name="shenpiren" />
                    <asp:Parameter Name="riqi" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:sqldatasource>
        </div>
    </form>
</body>
</html>
