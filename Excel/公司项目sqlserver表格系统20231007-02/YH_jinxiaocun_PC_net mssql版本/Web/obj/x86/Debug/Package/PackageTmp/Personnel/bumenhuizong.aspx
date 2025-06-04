<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bumenhuizong.aspx.cs" Inherits="Web.Personnel.bumenhuizong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body  style="    margin: 0;">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Height="30px" Text="部门：" Width="80px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="bumen" DataValueField="bumen" CssClass="top_select_input" Height="30px" Width="150px" >
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click"  CssClass="top_bt" />
        <asp:Button ID="Button2" runat="server" Text="部门详情" OnClick="Button2_Click"  CssClass="top_bt" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有"  CssClass="top_bt" />
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString26 %>" SelectCommand="SELECT [bumen], [gongsi] FROM [gongzi_peizhi] WHERE ([gongsi] = @gongsi)">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString25 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="SELECT C,BD,count(id) AS ID,SUM(CAST(G AS float)) AS G,SUM(CAST(H AS float)) AS H,SUM(CAST(I AS float)) AS I,SUM(CAST(J AS float)) AS J,SUM(CAST(K AS float)) AS K,SUM(CAST(L AS float)) AS  L,SUM(CAST(M AS float)) AS M,SUM(CAST(N AS float)) AS N,SUM(CAST(O AS float)) AS O,SUM(CAST(P AS float)) AS P,SUM(CAST(Q AS float)) AS Q,SUM(CAST(R AS float)) AS R,SUM(CAST(S AS float)) AS S,SUM(CAST(T AS float)) AS T,SUM(CAST(U AS float)) AS U,SUM(CAST(V AS float)) AS V,SUM(CAST(W AS float)) AS W,SUM(CAST(X AS float)) AS X,SUM(CAST(Y AS float)) AS Y,SUM(CAST(Z AS float)) AS Z,SUM(CAST(AA AS float)) AS AA,SUM(CAST(AB AS float)) AS AB,SUM(CAST(AC AS float)) AS AC,SUM(CAST(AD AS float)) AS AD,SUM(CAST(AE AS float)) AS AE,SUM(CAST(AF AS float)) AS AF,SUM(CAST(AG AS float)) AS AG,SUM(CAST(AH AS float)) AS AH,SUM(CAST(AI AS float)) AS AI,SUM(CAST(AJ AS float)) AS AJ,SUM(CAST(AK AS float)) AS AK,SUM(CAST(AL AS float)) AS AL,SUM(CAST(AM AS float)) AS AM,SUM(CAST(AN AS float)) AS AN,SUM(CAST(AO AS float)) AS AO,SUM(CAST(AP AS float)) AS AP,SUM(CAST(AQ AS float)) AS AQ,SUM(CAST(AR AS float)) AS AR,SUM(CAST(ASA AS float)) AS ASA,SUM(CAST(ATA AS float)) AS ATA,SUM(CAST(AU AS float)) AS AU,SUM(CAST(AV AS float)) AS AV,SUM(CAST(AW AS float)) AS AW,SUM(CAST(AX AS float)) AS AX,SUM(CAST(AY AS float)) AS AY FROM gongzi_gongzimingxi WHERE [BD] = @BD AND [C] = @C GROUP BY c,bd" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC, [BD] = @BD WHERE [id] = @id">
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
                <asp:Parameter Name="BD" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString24 %>" DeleteCommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" SelectCommand="SELECT C,BD,count(id) AS ID,SUM(CAST(G AS float)) AS G,SUM(CAST(H AS float)) AS H,SUM(CAST(I AS float)) AS I,SUM(CAST(J AS float)) AS J,SUM(CAST(K AS float)) AS K,SUM(CAST(L AS float)) AS  L,SUM(CAST(M AS float)) AS M,SUM(CAST(N AS float)) AS N,SUM(CAST(O AS float)) AS O,SUM(CAST(P AS float)) AS P,SUM(CAST(Q AS float)) AS Q,SUM(CAST(R AS float)) AS R,SUM(CAST(S AS float)) AS S,SUM(CAST(T AS float)) AS T,SUM(CAST(U AS float)) AS U,SUM(CAST(V AS float)) AS V,SUM(CAST(W AS float)) AS W,SUM(CAST(X AS float)) AS X,SUM(CAST(Y AS float)) AS Y,SUM(CAST(Z AS float)) AS Z,SUM(CAST(AA AS float)) AS AA,SUM(CAST(AB AS float)) AS AB,SUM(CAST(AC AS float)) AS AC,SUM(CAST(AD AS float)) AS AD,SUM(CAST(AE AS float)) AS AE,SUM(CAST(AF AS float)) AS AF,SUM(CAST(AG AS float)) AS AG,SUM(CAST(AH AS float)) AS AH,SUM(CAST(AI AS float)) AS AI,SUM(CAST(AJ AS float)) AS AJ,SUM(CAST(AK AS float)) AS AK,SUM(CAST(AL AS float)) AS AL,SUM(CAST(AM AS float)) AS AM,SUM(CAST(AN AS float)) AS AN,SUM(CAST(AO AS float)) AS AO,SUM(CAST(AP AS float)) AS AP,SUM(CAST(AQ AS float)) AS AQ,SUM(CAST(AR AS float)) AS AR,SUM(CAST(ASA AS float)) AS ASA,SUM(CAST(ATA AS float)) AS ATA,SUM(CAST(AU AS float)) AS AU,SUM(CAST(AV AS float)) AS AV,SUM(CAST(AW AS float)) AS AW,SUM(CAST(AX AS float)) AS AX,SUM(CAST(AY AS float)) AS AY FROM gongzi_gongzimingxi WHERE [BD] = @BD GROUP BY c,bd" UpdateCommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L, [M] = @M, [N] = @N, [O] = @O, [P] = @P, [Q] = @Q, [R] = @R, [S] = @S, [T] = @T, [U] = @U, [V] = @V, [W] = @W, [X] = @X, [Y] = @Y, [Z] = @Z, [AA] = @AA, [AB] = @AB, [AC] = @AC, [AD] = @AD, [AE] = @AE, [AF] = @AF, [AG] = @AG, [AH] = @AH, [AI] = @AI, [AJ] = @AJ, [AK] = @AK, [AL] = @AL, [AM] = @AM, [AN] = @AN, [AO] = @AO, [AP] = @AP, [AQ] = @AQ, [AR] = @AR, [ASA] = @ASA, [ATA] = @ATA, [AU] = @AU, [AV] = @AV, [AW] = @AW, [AX] = @AX, [AY] = @AY, [AZ] = @AZ, [BA] = @BA, [BB] = @BB, [BC] = @BC, [BD] = @BD WHERE [id] = @id">
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
                <asp:Parameter Name="BD" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="id" AllowPaging="True" >
            <Columns>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="人数" SortExpression="ID" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="基本工资" SortExpression="G">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="效绩工资" SortExpression="H" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="岗位工资" SortExpression="I" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="标准工资" SortExpression="J" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="跨度工资" SortExpression="K" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="职称津贴" SortExpression="L" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="M" HeaderText="月出勤天数" SortExpression="M" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="N" HeaderText="加班时间" SortExpression="N" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="加班费" SortExpression="O" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="P" HeaderText="全勤应发" SortExpression="P" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Q" HeaderText="缺勤天数" SortExpression="Q" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="R" HeaderText="缺勤扣款" SortExpression="R" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="S" HeaderText="迟到天数" SortExpression="S" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="T" HeaderText="迟到扣款" SortExpression="T" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="应发工资" SortExpression="U" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="社保基数" SortExpression="V" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="W" HeaderText="医疗技术" SortExpression="W" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="公积金基数" SortExpression="X" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Y" HeaderText="年金基数" SortExpression="Y" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AB" HeaderText="企业医疗" SortExpression="AB" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AE" HeaderText="企业公积金" SortExpression="AE" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AF" HeaderText="企业年金" SortExpression="AF" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AG" HeaderText="滞纳金" SortExpression="AG" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AH" HeaderText="利息" SortExpression="AH" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AI" HeaderText="企业小计" SortExpression="AI" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AL" HeaderText="个人医疗" SortExpression="AL" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AM" HeaderText="大额医疗" SortExpression="AM" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AN" HeaderText="个人公积金" SortExpression="AN" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AO" HeaderText="个人年金4%" SortExpression="AO" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AP" HeaderText="滞纳金" SortExpression="AP" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AQ" HeaderText="利息" SortExpression="AQ" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AR" HeaderText="个人小计" SortExpression="AR" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="ASA" HeaderText="税前工资" SortExpression="ASA" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="ATA" HeaderText="应税工资" SortExpression="ATA" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AU" HeaderText="税率" SortExpression="AU" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AV" HeaderText="扣除数" SortExpression="AV" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AW" HeaderText="代扣个人所得税" SortExpression="AW" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AX" HeaderText="1%年金" SortExpression="AX" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="AY" HeaderText="实发工资" SortExpression="AY" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD"  Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
    </form>
</body>
</html>
