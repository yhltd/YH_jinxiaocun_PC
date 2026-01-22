<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kaoqinjilu.aspx.cs" Inherits="Web.Personnel.kaoqinjilu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            <div >
                <div class="ti">
                    <h1>考勤记录</h1>
                </div>
                <div class="header-top" >
                <asp:Label ID="Label1" runat="server" Height="30px" Text="日期：" Width="80px" Style="text-align: center"></asp:Label>
                <input type="date" name="ks" />
                <input type="date" name="js" />
                <%--<asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="150px" CssClass="top_select_input" Style="text-align: center; border: 0.5px solid #378888">
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                    <asp:ListItem>2026</asp:ListItem>
                    <asp:ListItem>2027</asp:ListItem>
                    <asp:ListItem>2028</asp:ListItem>
                    <asp:ListItem>2029</asp:ListItem>
                    <asp:ListItem>2030</asp:ListItem>
                    <asp:ListItem>2031</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" Height="30px" Text="月份：" Width="80px" Style="text-align: center"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="150px" CssClass="top_select_input" Style="text-align: center; border: 0.5px solid #378888">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>--%>
                <asp:Button ID="Button1" runat="server" Height="30px" Text="搜索" Width="80px" OnClick="Button1_Click" CssClass="top_bt" Style="margin-right: -10px" />
                <%--<asp:Button ID="Button2" runat="server" Height="30px" Text="添加" Width="80px" OnClick="Button2_Click" CssClass="top_bt" Style="margin-right: -10px" />--%>
                <asp:Button ID="Button3" runat="server" Height="30px" Text="所有" Width="80px" OnClick="Button3_Click" CssClass="top_bt" Style="margin-right: -10px" />
                <asp:Button ID="Button4" CssClass="top_bt" runat="server" Height="30px" Text="生成Excel" Width="80px" OnClick="toExcel" Style="margin-right: -10px" />
                <br />
                    </div>
            </div>
             <%--<td>
                <asp:TextBox ID="comboBox1" runat="server" class="select_w150"></asp:TextBox>
            </td>--%>


            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" DataKeyNames="id"  AllowPaging="True"  OnRowCreated="aaa">--%>

            <asp:GridView ID="GridViewnew" runat="server" Width="86%" AutoGenerateColumns="True"
                CssClass="mGrid" align="center"
                CellPadding="0" Style="margin-top: 40px;" GridLines="Vertical"
                EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。" Height="297px">
                <Columns>
                    <asp:BoundField HeaderText="名称（即姓名）" DataField="name">
                        <%--denglumima--%>
                        <ControlStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>

                </Columns>

            </asp:GridView>

            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                CssClass="mGrid" align="left"
                CellPadding="0" Style="margin-top: 5px;" GridLines="Vertical"
                EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。">

                <Columns>
                    <%--<asp:CommandField ShowEditButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd1">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:CommandField>--%>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="True" ReadOnly="True" SortExpression="id" Visible="false" />
                    <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="C" HeaderText="年" SortExpression="C" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="D" HeaderText="月" SortExpression="D" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="E" HeaderText="应到" SortExpression="E" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="F" HeaderText="实到" SortExpression="F" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="G" HeaderText="请假" SortExpression="G" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>
                        
                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="H" HeaderText="加班" SortExpression="H" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="I" HeaderText="迟到" SortExpression="I" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="25%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="J" HeaderText="部门" SortExpression="J" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        <ControlStyle Width="80%"></ControlStyle>

                        <HeaderStyle HorizontalAlign="Center" Width="11%" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="K" HeaderText="K" SortExpression="K" Visible="false" />
                </Columns>
                <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
                <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
                <SelectedRowStyle CssClass="header" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString14 %>" DeleteCommand="DELETE FROM [gongzi_kaoqinmingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_kaoqinmingxi] ([name], [C], [D], [E], [F], [G], [H], [I], [J], [K]) VALUES (@name, @C, @D, @E, @F, @G, @H, @I, @J, @K)" SelectCommand="SELECT * FROM [gongzi_kaoqinmingxi] WHERE (([K] = @K) AND ([C] = @C) AND ([D] = @D ))  UNION select '','','','','','','','','','','' order by id desc" UpdateCommand="UPDATE [gongzi_kaoqinmingxi] SET [name] = @name, [C] = @C, [D] = CASE WHEN CONVERT(INT,@D)&gt;0 AND CONVERT(INT,@D)&lt;13 THEN @D  ELSE '1' END, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="C" Type="String" />
                    <asp:Parameter Name="D" Type="String" />
                    <asp:Parameter Name="E" Type="String" />
                    <asp:Parameter Name="F" Type="String" />
                    <asp:Parameter Name="G" Type="String" />
                    <asp:Parameter Name="H" Type="String" />
                    <asp:Parameter Name="I" Type="String" />
                    <asp:Parameter Name="J" Type="String" />
                    <asp:Parameter Name="K" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="K" SessionField="gongsi" Type="String" />
                    <asp:SessionParameter Name="C" SessionField="year" Type="String" />
                    <asp:SessionParameter Name="D" SessionField="moth" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="C" Type="String" />
                    <asp:Parameter Name="D" Type="String" />
                    <asp:Parameter Name="E" Type="String" />
                    <asp:Parameter Name="F" Type="String" />
                    <asp:Parameter Name="G" Type="String" />
                    <asp:Parameter Name="H" Type="String" />
                    <asp:Parameter Name="I" Type="String" />
                    <asp:Parameter Name="J" Type="String" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString13 %>" DeleteCommand="DELETE FROM [gongzi_kaoqinmingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_kaoqinmingxi] ([name], [C], [D], [E], [F], [G], [H], [I], [J], [K]) VALUES (@name, @C, @D, @E, @F, @G, @H, @I, @J, @K)" SelectCommand="SELECT * FROM [gongzi_kaoqinmingxi] WHERE ([K] like '%'+ @K +'%') UNION select '','','','','','','','','','','' order by id desc" UpdateCommand="UPDATE [gongzi_kaoqinmingxi] SET [name] = @name, [C] = @C, [D] = CASE WHEN CONVERT(INT,@D)&gt;0 AND CONVERT(INT,@D)&lt;13 THEN @D  ELSE '1' END, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="name"></asp:Parameter>
                    <asp:Parameter Name="C"></asp:Parameter>
                    <asp:Parameter Name="D"></asp:Parameter>
                    <asp:Parameter Name="E"></asp:Parameter>
                    <asp:Parameter Name="F"></asp:Parameter>
                    <asp:Parameter Name="G"></asp:Parameter>
                    <asp:Parameter Name="H"></asp:Parameter>
                    <asp:Parameter Name="I"></asp:Parameter>
                    <asp:Parameter Name="J"></asp:Parameter>
                    <asp:Parameter Name="K"></asp:Parameter>
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="K" SessionField="gongsi" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="name"></asp:Parameter>
                    <asp:Parameter Name="C"></asp:Parameter>
                    <asp:Parameter Name="D"></asp:Parameter>
                    <asp:Parameter Name="E"></asp:Parameter>
                    <asp:Parameter Name="F"></asp:Parameter>
                    <asp:Parameter Name="G"></asp:Parameter>
                    <asp:Parameter Name="H"></asp:Parameter>
                    <asp:Parameter Name="I"></asp:Parameter>
                    <asp:Parameter Name="J"></asp:Parameter>
                    <asp:Parameter Name="id"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
