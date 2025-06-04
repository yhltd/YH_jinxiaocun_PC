<%@ page language="C#" autoeventwireup="true" codebehind="baoshui.aspx.cs" inherits="Web.Personnel.baoshui" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <h1 style="margin-top: 0px; margin-bottom: 10px">报税</h1>
    <form id="form1" runat="server">
        <div>

            <asp:label id="Label1" runat="server" height="30px" text="姓名：" width="80px" style="text-align: center"></asp:label>
            <asp:textbox id="TextBox1" runat="server" cssclass="top_select_input" height="30px" width="150px" style="margin-right: -10px; border: 0.5px solid #378888"></asp:textbox>
<%--            <asp:Label ID="Label2" runat="server" Height="30px" Text="日期：" Width="80px" Style="text-align: center"></asp:Label>
                <input style="height:30px" type="month" name="ks" />
                <input style="height:30px" type="month" name="js" />--%>
            <asp:button id="Button1" runat="server" onclick="Button1_Click" text="搜索" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <asp:button id="Button2" runat="server" onclick="Button2_Click" text="所有" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <asp:button id="Button4" cssclass="top_bt" runat="server" height="30px" text="生成Excel" width="80px" onclick="toExcel" style="margin-right: -10px" />
            <br />

            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" datasourceid="SqlDataSource1" onrowcreated="aaa" allowpaging="True" datakeynames="id">
            
                <Columns>
                <asp:CommandField ShowEditButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd1" EditText="修改">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2" DeleteText="删除">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="xx" HeaderText="证件类型" SortExpression="xx"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="C" SortExpression="C"  Visible="false"/>
                <asp:BoundField DataField="D" HeaderText="D" SortExpression="D"  Visible="false"/>
                <asp:BoundField DataField="E" HeaderText="证件号码" SortExpression="E"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F"  Visible="false"/>
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G"  Visible="false"/>
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H"  Visible="false"/>
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I"  Visible="false"/>
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J"  Visible="false"/>
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K"  Visible="false"/>
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L"  Visible="false"/>
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M"  Visible="false"/>
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N"  Visible="false"/>
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O"  Visible="false"/>
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P"  Visible="false"/>
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q"  Visible="false"/>
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R"  Visible="false"/>
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S"  Visible="false"/>
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T"  Visible="false"/>
                <asp:BoundField DataField="BE" HeaderText="工资所属年月" SortExpression="BE"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="收入金额" SortExpression="U"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V"  Visible="false"/>
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W"  Visible="false"/>
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X"  Visible="false"/>
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y"  Visible="false"/>
                <asp:BoundField DataField="Z" HeaderText="Z" SortExpression="Z"  Visible="false"/>
                <asp:BoundField DataField="AA" HeaderText="AA" SortExpression="AA"  Visible="false"/>
                <asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB"  Visible="false"/>
                <asp:BoundField DataField="AC" HeaderText="AC" SortExpression="AC"  Visible="false"/>
                <asp:BoundField DataField="AD" HeaderText="AD" SortExpression="AD"  Visible="false"/>
                <asp:BoundField DataField="AE" HeaderText="AE" SortExpression="AE"  Visible="false"/>
                <asp:BoundField DataField="AF" HeaderText="AF" SortExpression="AF"  Visible="false"/>
                <asp:BoundField DataField="AG" HeaderText="AG" SortExpression="AG"  Visible="false"/>
                <asp:BoundField DataField="AH" HeaderText="AH" SortExpression="AH"  Visible="false"/>
                <asp:BoundField DataField="AI" HeaderText="基本养老保险金" SortExpression="AI"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="AJ" HeaderText="AJ" SortExpression="AJ"  Visible="false"/>
                <asp:BoundField DataField="AK" HeaderText="失业保险金" SortExpression="AK"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL"  Visible="false"/>
                <asp:BoundField DataField="AM" HeaderText="AM" SortExpression="AM"  Visible="false"/>
                <asp:BoundField DataField="AN" HeaderText="住房公积金" SortExpression="AN"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="AO" HeaderText="年金（个人部分）" SortExpression="AO"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="3%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="AP" HeaderText="AP" SortExpression="AP"  Visible="false"/>
                <asp:BoundField DataField="AQ" HeaderText="AQ" SortExpression="AQ"  Visible="false"/>
                <asp:BoundField DataField="AR" HeaderText="AR" SortExpression="AR"  Visible="false"/>
                <asp:BoundField DataField="ASA" HeaderText="ASA" SortExpression="ASA"  Visible="false"/>
                <asp:BoundField DataField="ATA" HeaderText="ATA" SortExpression="ATA"  Visible="false"/>
                <asp:BoundField DataField="AU" HeaderText="AU" SortExpression="AU"  Visible="false"/>
                <asp:BoundField DataField="AV" HeaderText="AV" SortExpression="AV"  Visible="false"/>
                <asp:BoundField DataField="AW" HeaderText="AW" SortExpression="AW"  Visible="false"/>
                <asp:BoundField DataField="AX" HeaderText="AX" SortExpression="AX"  Visible="false"/>
                <asp:BoundField DataField="AY" HeaderText="AY" SortExpression="AY"  Visible="false"/>
                <asp:BoundField DataField="AZ" HeaderText="AZ" SortExpression="AZ"  Visible="false"/>
                <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA"  Visible="false"/>
                <asp:BoundField DataField="BB" HeaderText="BB" SortExpression="BB"  Visible="false"/>
                <asp:BoundField DataField="BC" HeaderText="BC" SortExpression="BC"  Visible="false"/>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD" Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:gridview>
            <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString39 %>" deletecommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" selectcommand="if exists(SELECT *,xx=' 身份证'FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') and ([B] like '%'+ @B +'%')) begin SELECT *,xx=' 身份证'FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') and ([B] like '%'+ @B +'%') end else select *,xx=' 身份证' from [gongzi_gongzimingxi]  where id=0 union select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B,[E]= @E, [U] = @U, [AI] = @AI, [AK] = @AK, [AN] = @AN, [AO] = @AO WHERE [id] = @id">
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
                <asp:Parameter Name="BE" Type="String" />
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
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="BE" Type="String" />
                <asp:Parameter Name="U" Type="Double" />
                <asp:Parameter Name="AI" Type="Double" />
                <asp:Parameter Name="AK" Type="Double" />
                <asp:Parameter Name="AN" Type="Double" />
                <asp:Parameter Name="AO" Type="Double" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>
            <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString38 %>" deletecommand="DELETE FROM [gongzi_gongzimingxi] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_gongzimingxi] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L], [M], [N], [O], [P], [Q], [R], [S], [T], [U], [V], [W], [X], [Y], [Z], [AA], [AB], [AC], [AD], [AE], [AF], [AG], [AH], [AI], [AJ], [AK], [AL], [AM], [AN], [AO], [AP], [AQ], [AR], [ASA], [ATA], [AU], [AV], [AW], [AX], [AY], [AZ], [BA], [BB], [BC], [BD]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L, @M, @N, @O, @P, @Q, @R, @S, @T, @U, @V, @W, @X, @Y, @Z, @AA, @AB, @AC, @AD, @AE, @AF, @AG, @AH, @AI, @AJ, @AK, @AL, @AM, @AN, @AO, @AP, @AQ, @AR, @ASA, @ATA, @AU, @AV, @AW, @AX, @AY, @AZ, @BA, @BB, @BC, @BD)" selectcommand="if exists(SELECT *,xx=' 身份证'FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%')) begin SELECT *,xx=' 身份证'FROM [gongzi_gongzimingxi] WHERE ([BD] like '%'+ @BD +'%') end else select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_gongzimingxi] SET [B] = @B, [E] = @E, [U] = @U, [AI] = @AI, [AK] = @AK, [AN] = @AN, [AO] = @AO WHERE [id] = @id">
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
                <asp:Parameter Name="BE" Type="String" />
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
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="BE" Type="String" />
                <asp:Parameter Name="U" Type="Double" />
                <asp:Parameter Name="AI" Type="Double" />
                <asp:Parameter Name="AK" Type="Double" />
                <asp:Parameter Name="AN" Type="Double" />
                <asp:Parameter Name="AO" Type="Double" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>

        </div>
    </form>
</body>
</html>
