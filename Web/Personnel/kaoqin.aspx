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
    <h1 style="margin-top: 0px; margin-bottom: 10px; position: fixed">考勤</h1>
    <div style="height: 50px"></div>
    <form id="form1" runat="server">
        <div>
        </div>
        <div style="position: fixed">
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
            <asp:label id="Label1" runat="server" height="30px" width="80px" style="text-align: center" >开始时间：</asp:label>
            <input type="date" name="ks" id="ks" class="top_select_input" style="width:150px"></input>
            <asp:label id="Label2" runat="server" height="30px" width="80px" style="text-align: center" >结束时间：</asp:label>
            <input type="date" name="js" id="js" class="top_select_input" style="width:150px"></input>
            <asp:button id="Button1" cssclass="top_bt" runat="server" onclick="Button1_Click" text="搜索" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button2" cssclass="top_bt" runat="server" text="添加" onclientclick="aa" onclick="Button2_Click" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button3" cssclass="top_bt" runat="server" text="所有" onclientclick="aa" onclick="Button3_Click" height="30px" width="80px" style="margin-right: -10px" />
            <asp:button id="Button4" cssclass="top_bt" runat="server" height="30px" text="生成Excel" width="80px" onclick="toExcel" style="margin-right: -10px" />
        </div>
        <div style="height: 35px"></div>
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
                <asp:CommandField  ButtonType="Button" ShowDeleteButton="True" ItemStyle-CssClass="bt_upd2">
                    <ControlStyle Font-Bold="True" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
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
    </form>
</body>
</html>
