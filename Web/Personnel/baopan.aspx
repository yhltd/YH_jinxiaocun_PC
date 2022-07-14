<%@ page language="C#" autoeventwireup="true" codebehind="baopan.aspx.cs" inherits="Web.Personnel.baopan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <h1 style="margin-top: 0px; margin-bottom: 10px">报盘</h1>
    <form id="form1" runat="server">
        <div>

            <%--<asp:label id="Label1" runat="server" height="30px" text="姓名：" width="80px" style="text-align: center"></asp:label>--%>
            <%--<asp:textbox id="TextBox1" runat="server" cssclass="top_select_input" height="30px" width="150px" style="margin-right: -10px; border: 0.5px solid #378888"></asp:textbox>--%>
            <%--&nbsp;&nbsp;&nbsp;--%>
            <asp:label id="Label2" runat="server" height="30px" text="开始时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="ks" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            <asp:label id="Label3" runat="server" height="30px" text="结束时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="js" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
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
            
            <%-- datasourceid="SqlDataSource1" --%>
            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False"  allowpaging="True" datakeynames="id" onrowcreated="aaa">
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
