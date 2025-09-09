<%@ page language="C#" autoeventwireup="true" codebehind="kaoqin.aspx.cs" inherits="Web.Personnel.kaoqin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../Scripts/layui/layui.all.js"></script>
    <script src="../../Scripts/layui/lay/modules/layer.js"></script>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="../Myadmin/js/jquerysession.js"></script>
    <script type="text/javascript" src="js/iframe_d.js"></script>
    <link rel="stylesheet" type="text/css" href="css/iframe_d.css" />
    <script type="text/javascript">
        $(function () {
            $('#ks').val($.session.get('ks'));
            $('#js').val($.session.get('js'));
            $.session.set('ks', '')
            $.session.set('js', '')

            $('#Button1').click(function () {
                $.session.set('ks', $('#ks').val());
                $.session.set('js', $('#js').val());
            })
        })
        
        function a() {
            alert("无权限！")
        }
        function upUser(e) {
            iframe_d_open({
                title: "考勤修改",//头部
                shadeClose: true, //点击遮罩层关闭
                area: {            //弹窗大小
                    x: '600',
                    y: '500'
                },
                content: 'kaoqinUpd.aspx?strs=' + e,     //路径
                maxmin: true,      //最大化最小化按钮
                z_index: 100        //层级
            })
        }
    </script>
    <script type="text/javascript">
        //layer.open({
        //    type: 1, 
        //    title:'考勤修改', //这里content是一个普通的String
        //    offse: 'auto',
        //    maxmin: true,
        //});
        //function upUser(e) {
        //var id = $(this).data("id")
        //var gongsi = $(this).data("gongsi")
        //var strs = json.parse(e)
        //    title = '修改用户';
        //    url = 'kaoqinUpd.aspx?strs=' + e;
        //    layui.use('layer', function () {
        //        var layer = layui.layer;
        //    });
        //    layer.open({
        //        type: 2,
        //        title: '考勤修改',
        //        maxmin: true,
        //        shadeClose: true, //点击遮罩关闭层
        //        area: ['623px', '454px'],
        //        content: url,
        //        scrollbar: false,
        //        data: { "type": "insert" },
        //        success: function (layero, index) {
        //            var iframeBody = document.getElementById($('.layui-layer-content').find('iframe').prop('id')).contentWindow.document.body;
        //            $(".manage_location_wrap", iframeBody).appendTo(iframeBody);
        //            $('.container,header,footer', iframeBody).remove();
        //        },
        //        yes: function (index) {
        //            console.log(11556156);
        //            shwoAddrs();
        //        },
        //        cancel: function () {
        //            console.log(11556156);
        //        }
        //    })
        //}

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
        
        
            <%--<asp:Label ID="Label1" runat="server" Height="30px"  Width="80px" style="text-align:center" >年份：</asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="150px"  CssClass="top_select_input" style="text-align:center;border:0.5px solid #378888">
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
        <asp:Label ID="Label2" runat="server" Height="30px"  Width="80px" style="text-align:center">月份：</asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="150px"  CssClass="top_select_input" style="text-align:center;border:0.5px solid #378888">
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
            <div class="ti">
                <h1>考勤</h1>
            </div>
            <div class ="header-top">
            
             <asp:label id="Label1" runat="server" height="30px" width="80px" style="text-align: center" >开始时间：</asp:label>
            <input type="date" name="ks" id="ks" class="top_select_input" style="width:150px"></input>
            <asp:label id="Label2" runat="server" height="30px" width="80px" style="text-align: center" >结束时间：</asp:label>
            <input type="date" name="js" id="js" class="top_select_input" style="width:150px"></input>
            <asp:button id="Button1" cssclass="top_bt" runat="server" onclick="Button1_Click" text="搜索" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button2" cssclass="top_bt" runat="server" text="添加" onclientclick="aa" onclick="Button2_Click" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button3" cssclass="top_bt" runat="server" text="所有" onclientclick="aa" onclick="Button3_Click" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button4" cssclass="top_bt" runat="server" height="30px" text="生成Excel" width="80px" onclick="toExcel" style="margin-right: -10px" />
            <asp:button id="Button5" cssclass="top_bt" runat="server" text="当月休假" onclientclick="aa" onclick="Button5_Click" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button6" cssclass="top_bt" runat="server" text="当月初始化" onclientclick="aa" onclick="Button6_Click" height="30px" width="80px" style="margin-right: -10px" />
            </div>
        <%--<asp:Button ID="Button4" CssClass="top_bt" runat="server"  Text="刷新" OnClientClick="aa"  Height="30px" Width="80px" OnClick="Button4_Click"/>--%>
        <asp:gridview id="GridView1" allowpaging="True" runat="server" autogeneratecolumns="False" datakeynames="id" datasourceid="SqlDataSource1" onrowcreated="aaa" onselectedindexchanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" ItemStyle-CssClass="bt_upd1" SelectText="修改" >
                    <ControlStyle Font-Bold="True" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />

                </asp:CommandField>
                <%--<asp:CommandField ButtonType="Button" ShowEditButton="true" ItemStyle-CssClass="bt_upd2" ControlStyle-Width="170px">
                    <ControlStyle Font-Bold="True" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>--%>
                <asp:commandfield  buttontype="button" showdeletebutton="true" itemstyle-cssclass="bt_upd2" SelectText="删除" DeleteText="删除">
                    <controlstyle font-bold="true" width="50px" />
                    <headerstyle horizontalalign="center" />
                    <itemstyle horizontalalign="center" />
                </asp:commandfield>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                <asp:BoundField DataField="year" HeaderText="年" SortExpression="year" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="moth" HeaderText="月" SortExpression="moth" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="1" SortExpression="E" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="2" SortExpression="F" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="3" SortExpression="G" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="4" SortExpression="H" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="5" SortExpression="I" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="6" SortExpression="J" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="7" SortExpression="K" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="8" SortExpression="L" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="M" HeaderText="9" SortExpression="M" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="N" HeaderText="10" SortExpression="N" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="11" SortExpression="O" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="P" HeaderText="12" SortExpression="P" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Q" HeaderText="13" SortExpression="Q" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="R" HeaderText="14" SortExpression="R" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="S" HeaderText="15" SortExpression="S" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="T" HeaderText="16" SortExpression="T" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="17" SortExpression="U" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="18" SortExpression="V" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="W" HeaderText="19" SortExpression="W" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="20" SortExpression="X" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Y" HeaderText="21" SortExpression="Y" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="22" SortExpression="Z" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AA" HeaderText="23" SortExpression="AA" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AB" HeaderText="24" SortExpression="AB" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AC" HeaderText="25" SortExpression="AC" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AD" HeaderText="26" SortExpression="AD" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AE" HeaderText="27" SortExpression="AE" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AF" HeaderText="28" SortExpression="AF" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AG" HeaderText="29" SortExpression="AG" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AH" HeaderText="30" SortExpression="AH" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AI" HeaderText="31" SortExpression="AI" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AJ" HeaderText="全勤天数" SortExpression="AJ" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AK" HeaderText="实际天数" SortExpression="AK" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AL" HeaderText="请假/小时" SortExpression="AL" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AM" HeaderText="加班/小时" SortExpression="AM" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AN" HeaderText="迟到天数" SortExpression="AN" ControlStyle-Width="70%" HeaderStyle-Font-Bold="true">
                    <ControlStyle Width="70%"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AO" HeaderText="AO" SortExpression="AO" Visible="false" />
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:gridview>
        <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString6 %>" deletecommand="DELETE FROM [gongzi_kaoqinjilu] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_kaoqinjilu] ([year], [moth], [name], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO]) VALUES (@year, @moth, @name, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO)" selectcommand="if exists(SELECT * FROM [gongzi_kaoqinjilu] where ([AO] like '%'+ @AO +'%') AND (convert(int,[year]+moth) &gt;= @year) AND (convert(int,[year]+moth) &lt;= @moth) ) begin SELECT id,convert(int,[year]) as [year],convert(int,moth) as moth,name,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO FROM [gongzi_kaoqinjilu] where ([AO] like '%'+ @AO +'%') AND (convert(int,[year]+moth) &gt;= @year) AND (convert(int,[year]+moth) &lt;= @moth) order by [year] desc,moth desc end else SELECT * FROM [gongzi_kaoqinjilu] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_kaoqinjilu] SET [year] = @year, [moth] = @moth, [name] = @name, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="moth" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="AO" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="asd" Name="AO" SessionField="gongsi" Type="String" />
                <asp:SessionParameter DefaultValue="" Name="year" SessionField="year" Type="String" />
                <asp:SessionParameter Name="moth" SessionField="moth" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="moth" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>
        <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString5 %>" deletecommand="DELETE FROM [gongzi_kaoqinjilu] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_kaoqinjilu] ([year], [moth], [name], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO]) VALUES (@year, @moth, @name, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO)" selectcommand="if exists(SELECT * FROM [gongzi_kaoqinjilu] where ([AO] like '%'+ @AO +'%') ) begin SELECT id,convert(int,[year]) as [year],convert(int,moth) as moth,name,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO FROM [gongzi_kaoqinjilu] where ([AO] like '%'+ @AO +'%') order by [year] desc,moth desc end else SELECT * FROM [gongzi_kaoqinjilu] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_kaoqinjilu] SET [year] = @year, [moth] = @moth, [name] = @name, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="moth" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="AO" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="asd" Name="AO" SessionField="gongsi" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="moth" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
                <asp:Parameter Name="L" Type="String" />
                <asp:Parameter Name="M" Type="String" />
                <asp:Parameter Name="N" Type="String" />
                <asp:Parameter Name="O" Type="String" />
                <asp:Parameter Name="P" Type="String" />
                <asp:Parameter Name="Q" Type="String" />
                <asp:Parameter Name="R" Type="String" />
                <asp:Parameter Name="S" Type="String" />
                <asp:Parameter Name="T" Type="String" />
                <asp:Parameter Name="U" Type="String" />
                <asp:Parameter Name="V" Type="String" />
                <asp:Parameter Name="W" Type="String" />
                <asp:Parameter Name="X" Type="String" />
                <asp:Parameter Name="Y" Type="String" />
                <asp:Parameter Name="Z" Type="String" />
                <asp:Parameter Name="AA" Type="String" />
                <asp:Parameter Name="AB" Type="String" />
                <asp:Parameter Name="AC" Type="String" />
                <asp:Parameter Name="AD" Type="String" />
                <asp:Parameter Name="AE" Type="String" />
                <asp:Parameter Name="AF" Type="String" />
                <asp:Parameter Name="AG" Type="String" />
                <asp:Parameter Name="AH" Type="String" />
                <asp:Parameter Name="AI" Type="String" />
                <asp:Parameter Name="AJ" Type="String" />
                <asp:Parameter Name="AK" Type="String" />
                <asp:Parameter Name="AL" Type="String" />
                <asp:Parameter Name="AM" Type="String" />
                <asp:Parameter Name="AN" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>
        <div class="iframe_d">
        </div>
        </div>
    </form>
</body>
</html>
