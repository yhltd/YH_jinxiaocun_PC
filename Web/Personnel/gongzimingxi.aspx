    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongzimingxi.aspx.cs" Inherits="Web.Personnel.gongzimingxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="js/jqueryui/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/iframe_d.js"></script>
    <link rel="stylesheet" type="text/css" href="css/iframe_d.css"/>
    <link rel="stylesheet" href="js/jqueryui/jquery-ui.css"/>
    <script type="text/javascript">
        function updinput(e) {
            if (e < 8) {
                var iName = "GridView1$ctl0" + (2 + parseInt(e)) + "$ctl06";
                var iName2 = "GridView1$ctl0" + (2 + parseInt(e)) + "$ctl55";
            } else {
                var iName = "GridView1$ctl" + (2 + parseInt(e)) + "$ctl06";
                var iName2 = "GridView1$ctl" + (2 + parseInt(e)) + "$ctl55";
            }
            $("[name='" + iName + "']").datepicker({ dateFormat: 'yy-mm-dd' });
            $("[name='" + iName2 + "']").datepicker({ dateFormat: 'yy-mm-dd' });
        };
        function upUser(e) {
            console.log($(".iframe_d"))
            iframe_d_open({
                title: "工资明细修改",//头部
                shadeClose: true, //点击遮罩层关闭
                area: {            //弹窗大小
                    x: '600',
                    y: '500'
                },
                content: 'gongzimingxiUpd.aspx?strs=' + e,     //路径
                maxmin: true,      //最大化最小化按钮
                z_index: 100        //层级
            })
        }
    </script>
    <h1 style="margin-top:0px;margin-bottom:10px;">工资明细</h1>
    <form id="form1" runat="server">
        <div>
    <div class="iframe_d">
    
    </div>
    <div  ><%--style="margin-left: 40px"--%>
        <asp:Label ID="Label1" runat="server" Height="30px" Text="搜索类型：" Width="80px" style="text-align:center"></asp:Label>
        <asp:DropDownList ID="DropDownList1" CssClass="top_option" runat="server" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888">
            <asp:ListItem>姓名</asp:ListItem>
            <asp:ListItem>部门</asp:ListItem>
            <asp:ListItem>岗位</asp:ListItem> 
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Height="30px" Text="搜索条件：" Width="80px" style="text-align:center"></asp:Label>
        <asp:TextBox ID="TextBox1" CssClass="top_select_input" runat="server" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Button ID="Button1" CssClass="top_bt" runat="server" OnClick="Button1_Click" Text="搜索" Height="30px" Width="80px" style="margin-right:-10px"/>
        <asp:Button ID="Button2" CssClass="top_bt" runat="server" OnClick="Button2_Click" Text="添加" Width="80px" Height="30px" style="margin-right:-10px"/>
        <asp:Button ID="Button3" CssClass="top_bt" runat="server"  Text="所有" OnClientClick="aa" OnClick="Button3_Click" Height="30px" Width="80px" style="margin-right:-10px"/>
        <asp:Button ID="Button4" CssClass="top_bt" runat="server" Height="30px" Text="生成Excel" Width="80px" OnClick="toExcel" style="margin-right:-10px" />
      
        
        <%-- <asp:Button ID="Button4" CssClass="top_bt" runat="server"  Text="刷新" OnClientClick="aa"  Height="30px" Width="80px" OnClick="Button4_Click"/> --%>
        <asp:GridView ID="GridView1" runat="server" CssClass="grid_view" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" ScrollBars="Auto" Width="100%" HeaderStyle-BorderStyle="None" AllowPaging="True"  OnRowCreated="aaa" OnRowEditing="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" ItemStyle-CssClass="bt_upd1" SelectText="修改">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <%--<asp:CommandField ButtonType="Button" ShowEditButton="True" ItemStyle-CssClass="bt_upd2">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>--%>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  ItemStyle-CssClass="bt_upd2">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"  Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="岗位" SortExpression="D" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="身份证号" SortExpression="E" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="入职时间" SortExpression="F" HeaderStyle-Font-Bold="true" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" CssClass="date" />
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="基本工资" SortExpression="G" HeaderStyle-Font-Bold="true" ControlStyle-Width="95%">
                <HeaderStyle Wrap="False" Width="20px" />
                <ItemStyle Wrap="False" Width="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="绩效工资" SortExpression="H" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="岗位工资" SortExpression="I" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="当月合计工资" SortExpression="J" HeaderStyle-Font-Bold="true" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="跨度工资" SortExpression="K" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="职称津贴" SortExpression="L" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="M" HeaderText="月出勤天数" SortExpression="M" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="N" HeaderText="加班时间" SortExpression="N" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="加班费" SortExpression="O" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="P" HeaderText="全勤应发" SortExpression="P" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Q" HeaderText="缺勤天数" SortExpression="Q" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="R" HeaderText="缺勤扣款" SortExpression="R" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="S" HeaderText="迟到天数" SortExpression="S" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="T" HeaderText="迟到扣款" SortExpression="T" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="应发工资" SortExpression="U" HeaderStyle-Font-Bold="true" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="社保基数" SortExpression="V" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="W" HeaderText="医疗技术" SortExpression="W" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="公积金基数" SortExpression="X" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Y" HeaderText="年金基数" SortExpression="Y" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AB" HeaderText="企业医疗" SortExpression="AB" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AE" HeaderText="企业公积金" SortExpression="AE" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AF" HeaderText="企业年金" SortExpression="AF" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AG" HeaderText="滞纳金" SortExpression="AG" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AH" HeaderText="利息" SortExpression="AH" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AI" HeaderText="企业小计" SortExpression="AI" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AL" HeaderText="个人医疗" SortExpression="AL" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AM" HeaderText="个人生育" SortExpression="AM" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AN" HeaderText="个人公积金" SortExpression="AN" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AO" HeaderText="个人年金4%" SortExpression="AO" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AP" HeaderText="滞纳金" SortExpression="AP" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AQ" HeaderText="利息" SortExpression="AQ" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AR" HeaderText="个人小计" SortExpression="AR" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ASA" HeaderText="税前工资" SortExpression="ASA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ATA" HeaderText="应税工资" SortExpression="ATA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AU" HeaderText="税率" SortExpression="AU" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AV" HeaderText="扣除数" SortExpression="AV" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AW" HeaderText="代扣个人所得税" SortExpression="AW" HeaderStyle-Font-Bold="true" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AX" HeaderText="年金1%" SortExpression="AX" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AY" HeaderText="实发工资" SortExpression="AY" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AZ" HeaderText="验算公式" SortExpression="AZ" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BA" HeaderText="银行账号" SortExpression="BA" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BB" HeaderText="调薪时间" SortExpression="BB" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BC" HeaderText="录入时间" SortExpression="BC" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD"   Visible="false">
                </asp:BoundField>
                </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString23 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="if exists(SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([D] like '%'+ @D +'%') ) begin SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([D] like '%'+ @D +'%') end else select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="D" SessionField="zw1" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString22 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="if exists(SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%') ) begin SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%') end else  select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString21 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="if exists(SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([B] like '%'+ @B +'%') ) begin SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') AND ([B] like '%'+ @B +'%') end else select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString20 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="if exists(SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') ) begin SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') end else SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="BD" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
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
                <asp:Parameter Name="AP" Type="String" />
                <asp:Parameter Name="AQ" Type="String" />
                <asp:Parameter Name="AR" Type="String" />
                <asp:Parameter Name="ASA" Type="String" />
                <asp:Parameter Name="ATA" Type="String" />
                <asp:Parameter Name="AU" Type="String" />
                <asp:Parameter Name="AV" Type="String" />
                <asp:Parameter Name="AW" Type="String" />
                <asp:Parameter Name="AX" Type="String" />
                <asp:Parameter Name="AY" Type="String" />
                <asp:Parameter Name="AZ" Type="String" />
                <asp:Parameter Name="BA" Type="String" />
                <asp:Parameter Name="BB" Type="String" />
                <asp:Parameter Name="BC" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
            </div>
    </form>
    
</body>
</html>
