<%@ page language="C#" autoeventwireup="true" codebehind="baopan.aspx.cs" inherits="Web.Personnel.baopan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="../Myadmin/js/jquerysession.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#ks').val($.session.get('ks'));
            $('#js').val($.session.get('js'));
            $.session.set('ks', '')
            $.session.set('js', '')

            $('#Button2').click(function () {
                $.session.set('ks', $('#ks').val());
                $.session.set('js', $('#js').val());
            })
        })

    </script>
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
    
    <form id="form1" runat="server">
        <div>
            <div class="ti">
                <h1>报盘</h1>
            </div>
            <div class="header-top" >
            <%--<asp:label id="Label1" runat="server" height="30px" text="姓名：" width="80px" style="text-align: center"></asp:label>--%>
            <%--<asp:textbox id="TextBox1" runat="server" cssclass="top_select_input" height="30px" width="150px" style="margin-right: -10px; border: 0.5px solid #378888"></asp:textbox>--%>
            <%--&nbsp;&nbsp;&nbsp;--%>
            <asp:label id="Label2" runat="server" height="30px" text="开始时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="ks" id="ks" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            <asp:label id="Label3" runat="server" height="30px" text="结束时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="js" id="js" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            <asp:button id="Button2" runat="server" text="搜索" onclick="Button2_Click" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <asp:button id="Button3" runat="server" height="30px" text="所有" width="80px" onclick="Button3_Click" cssclass="top_bt" style="margin-right: -10px" />
            <asp:button id="Button4" cssclass="top_bt" runat="server" height="30px" text="生成Excel" width="80px" onclick="toExcel" style="margin-right: -10px" />
            
            <br />
            
            <asp:label id="Label11" runat="server" height="30px" text="实发工资" width="80px" style="text-align: center;margin-top: 10px;" ></asp:label>
            <asp:textbox runat="server" id="Textbox11" cssclass="top_select_input" style="width:150px"></asp:textbox>
            <asp:label id="Label12" runat="server" height="30px" text="个人支出" width="80px" style="text-align: center"></asp:label>
            <asp:textbox runat="server" id="Textbox12" cssclass="top_select_input" style="width:150px"></asp:textbox>
            <asp:label id="Label13" runat="server" height="30px" text="企业支出" width="80px" style="text-align: center"></asp:label>
            <asp:textbox runat="server" id="Textbox13" cssclass="top_select_input" style="width:150px"></asp:textbox>
            <asp:label id="Label14" runat="server" height="30px" text="员工人数" width="80px" style="text-align: center"></asp:label>
            <asp:textbox runat="server" id="Textbox14" cssclass="top_select_input" style="width:150px"></asp:textbox>
            <br />

            <asp:label id="Label15" runat="server" height="30px" text="全勤天数" width="80px" style="text-align: center"></asp:label>
            <asp:textbox runat="server" id="Textbox15" cssclass="top_select_input" style="width:150px"></asp:textbox>
            <asp:label id="Label16" runat="server" height="30px" text="审批人" width="80px" style="text-align: center"></asp:label>
            <asp:textbox runat="server" id="Textbox16" cssclass="top_select_input" style="width:150px"></asp:textbox>
            <asp:label id="Label17" runat="server" height="30px" text="审批日期" width="80px" style="text-align: center"></asp:label>
            <asp:textbox runat="server" id="Textbox17" cssclass="top_select_input" textmode="date" style="width:150px"></asp:textbox>
            &nbsp;&nbsp;&nbsp;
            <asp:button id="Button1" cssclass="top_bt" onclick="saveShenpi" runat="server" height="30px" text="保存审批记录" width="120px" style="margin-right: -10px" />
            <br />
            </div>
            <%-- datasourceid="SqlDataSource1" --%>
            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False"  allowpaging="True" datakeynames="id" onrowcreated="aaa" OnPageIndexChanging="GridView1_PageIndexChanging" >
              <PagerStyle HorizontalAlign="left" BackColor="LightGray" Font-Size="Large"  />   
                <Columns>
               <%-- <asp:CommandField ShowEditButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd1">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>--%>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="员工姓名" SortExpression="B"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                <ControlStyle Width="80%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="22%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="录入日期" SortExpression="C"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="80%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="22%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="实发工资" SortExpression="D"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="80%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="22%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="全勤天数" SortExpression="E"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="80%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="22%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="个人支出" SortExpression="F"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="80%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="22%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="企业支出" SortExpression="G"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="80%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="22%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                </asp:BoundField>

            </Columns>
             
            
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:gridview>
            <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString37 %>" deletecommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id and [id] !=0" insertcommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" selectcommand="if exists(SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%qwe qw esdas dasd%')) begin SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%dasd asd as das dqe%')  end else SELECT *,a='人民币' FROM [gongzi_gongzimingxi] WHERE id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [AY] = @AY, [BA] = @BA WHERE [id] = @id and[id] !=0">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="Double" />
                <asp:Parameter Name="H" Type="Double" />
                <asp:Parameter Name="I" Type="Double" />
                <asp:Parameter Name="J" Type="Double" />
                <asp:Parameter Name="K" Type="Double" />
                <asp:Parameter Name="L" Type="Double" />
                <asp:Parameter Name="M" Type="Double" />
                <asp:Parameter Name="N" Type="Double" />
                <asp:Parameter Name="O" Type="Double" />
                <asp:Parameter Name="P" Type="Double" />
                <asp:Parameter Name="Q" Type="Double" />
                <asp:Parameter Name="R" Type="Double" />
                <asp:Parameter Name="S" Type="Double" />
                <asp:Parameter Name="T" Type="Double" />
                <asp:Parameter Name="U" Type="Double" />
                <asp:Parameter Name="V" Type="Double" />
                <asp:Parameter Name="W" Type="Double" />
                <asp:Parameter Name="X" Type="Double" />
                <asp:Parameter Name="Y" Type="Double" />
                <asp:Parameter Name="Z" Type="Double" />
                <asp:Parameter Name="AA" Type="Double" />
                <asp:Parameter Name="AB" Type="Double" />
                <asp:Parameter Name="AC" Type="Double" />
                <asp:Parameter Name="AD" Type="Double" />
                <asp:Parameter Name="AE" Type="Double" />
                <asp:Parameter Name="AF" Type="Double" />
                <asp:Parameter Name="AG" Type="Double" />
                <asp:Parameter Name="AH" Type="Double" />
                <asp:Parameter Name="AI" Type="Double" />
                <asp:Parameter Name="AJ" Type="Double" />
                <asp:Parameter Name="AK" Type="Double" />
                <asp:Parameter Name="AL" Type="Double" />
                <asp:Parameter Name="AM" Type="Double" />
                <asp:Parameter Name="AN" Type="Double" />
                <asp:Parameter Name="AO" Type="Double" />
                <asp:Parameter Name="AP" Type="Double" />
                <asp:Parameter Name="AQ" Type="Double" />
                <asp:Parameter Name="AR" Type="Double" />
                <asp:Parameter Name="ASA" Type="Double" />
                <asp:Parameter Name="ATA" Type="Double" />
                <asp:Parameter Name="AU" Type="Double" />
                <asp:Parameter Name="AV" Type="Double" />
                <asp:Parameter Name="AW" Type="Double" />
                <asp:Parameter Name="AX" Type="Double" />
                <asp:Parameter Name="AY" Type="Double" />
                <asp:Parameter Name="AZ" Type="Double" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="AY" Type="Double" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>
            <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString36 %>" deletecommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" selectcommand="if exists(SELECT *,a='人民币' FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([B] like '%'+ @B +'%') and convert(date,[BC])&gt;=@ks and convert(date,[BC])&lt;=@js ) begin SELECT *,a='人民币' FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([B] like '%'+ @B +'%') and convert(date,[BC])&gt;=@ks and convert(date,[BC])&lt;=@js end else SELECT *,a='人民币' FROM [gongzi_gongzimingxi] WHERE id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B,[AY] = @AY, [BA] = @BA WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="Double" />
                <asp:Parameter Name="H" Type="Double" />
                <asp:Parameter Name="I" Type="Double" />
                <asp:Parameter Name="J" Type="Double" />
                <asp:Parameter Name="K" Type="Double" />
                <asp:Parameter Name="L" Type="Double" />
                <asp:Parameter Name="M" Type="Double" />
                <asp:Parameter Name="N" Type="Double" />
                <asp:Parameter Name="O" Type="Double" />
                <asp:Parameter Name="P" Type="Double" />
                <asp:Parameter Name="Q" Type="Double" />
                <asp:Parameter Name="R" Type="Double" />
                <asp:Parameter Name="S" Type="Double" />
                <asp:Parameter Name="T" Type="Double" />
                <asp:Parameter Name="U" Type="Double" />
                <asp:Parameter Name="V" Type="Double" />
                <asp:Parameter Name="W" Type="Double" />
                <asp:Parameter Name="X" Type="Double" />
                <asp:Parameter Name="Y" Type="Double" />
                <asp:Parameter Name="Z" Type="Double" />
                <asp:Parameter Name="AA" Type="Double" />
                <asp:Parameter Name="AB" Type="Double" />
                <asp:Parameter Name="AC" Type="Double" />
                <asp:Parameter Name="AD" Type="Double" />
                <asp:Parameter Name="AE" Type="Double" />
                <asp:Parameter Name="AF" Type="Double" />
                <asp:Parameter Name="AG" Type="Double" />
                <asp:Parameter Name="AH" Type="Double" />
                <asp:Parameter Name="AI" Type="Double" />
                <asp:Parameter Name="AJ" Type="Double" />
                <asp:Parameter Name="AK" Type="Double" />
                <asp:Parameter Name="AL" Type="Double" />
                <asp:Parameter Name="AM" Type="Double" />
                <asp:Parameter Name="AN" Type="Double" />
                <asp:Parameter Name="AO" Type="Double" />
                <asp:Parameter Name="AP" Type="Double" />
                <asp:Parameter Name="AQ" Type="Double" />
                <asp:Parameter Name="AR" Type="Double" />
                <asp:Parameter Name="ASA" Type="Double" />
                <asp:Parameter Name="ATA" Type="Double" />
                <asp:Parameter Name="AU" Type="Double" />
                <asp:Parameter Name="AV" Type="Double" />
                <asp:Parameter Name="AW" Type="Double" />
                <asp:Parameter Name="AX" Type="Double" />
                <asp:Parameter Name="AY" Type="Double" />
                <asp:Parameter Name="AZ" Type="Double" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" DefaultValue="" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
                <asp:SessionParameter Name="ks" SessionField="ks" Type="String"/>
                <asp:SessionParameter Name="js" SessionField="js" Type="String"/>
                <%--<asp:SessionParameter Name="js" SessionField="js">
                </asp:SessionParameter>--%>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="AY" Type="Double" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>

        </div>
    </form>
</body>
</html>
