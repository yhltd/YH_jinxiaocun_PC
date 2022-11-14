<%@ page language="C#" autoeventwireup="true" codebehind="gerenxinxi.aspx.cs" inherits="Web.Personnel.gerenxinxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <%--<script type="text/javascript">
        function a(){
            alert("修改成功！")
        }
    </script>--%>
    <h1 style="margin-top: 0px; margin-bottom: 10px">员工档案</h1>
    <form id="form1" runat="server">
        <div>

            <asp:label id="Label1" runat="server" height="30px" text="姓名：" width="80px" style="text-align: center"></asp:label>
            <asp:textbox id="TextBox1" runat="server" cssclass="top_select_input" height="30px" width="150px" style="text-align: center; border: 0.5px solid #378888; margin-bottom: 3px"></asp:textbox>
            <asp:button id="Button1" runat="server" text="搜索" onclick="Button1_Click" cssclass="top_bt" clientidmode="AutoID"  style="margin-right: -10px" />
            <asp:button id="Button2" runat="server" text="所有" onclick="Button2_Click" cssclass="top_bt" style="margin-right: -10px" />
            <asp:button id="Button3" runat="server" text="今日生日" onclick="Button3_Click" cssclass="top_bt" style="margin-right: -10px" />
            <br />
            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" datakeynames="id" datasourceid="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"/>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="职务" SortExpression="D" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="身份证号" SortExpression="E" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="基本工资" SortExpression="F" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="银行卡号" SortExpression="G" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="入职时间" SortExpression="H" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="工龄" SortExpression="K" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L"/>
                <asp:BoundField DataField="M" HeaderText="民族" SortExpression="M">
                </asp:BoundField>
                <asp:BoundField DataField="N" HeaderText="籍贯" SortExpression="N">
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="手机号" SortExpression="O">
                </asp:BoundField>
                <asp:BoundField DataField="P" HeaderText="学历" SortExpression="P">
                </asp:BoundField>
                <asp:BoundField DataField="Q" HeaderText="出生日期" SortExpression="Q">
                </asp:BoundField>
                <asp:BoundField DataField="R" HeaderText="婚姻状况" SortExpression="R">
                </asp:BoundField>
                <asp:BoundField DataField="S" HeaderText="就职状态" SortExpression="S">
                </asp:BoundField>
                <asp:BoundField DataField="AC" HeaderText="绩效工资" SortExpression="AC">
                </asp:BoundField>
                <asp:BoundField DataField="AD" HeaderText="调薪时间" SortExpression="AD">
                </asp:BoundField>
                <asp:BoundField DataField="T" HeaderText="现住址" SortExpression="T">
                </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="家庭地址" SortExpression="U">
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="银行卡支行" SortExpression="V">
                </asp:BoundField>
                <asp:BoundField DataField="W" HeaderText="是否购买社保" SortExpression="W">
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="公积金账号" SortExpression="X">
                </asp:BoundField>
                <asp:BoundField DataField="Y" HeaderText="社保账号" SortExpression="Y">
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="劳动合同签订有效期限" SortExpression="Z">
                </asp:BoundField>
                <asp:BoundField DataField="AA" HeaderText="劳动合同第二次续签" SortExpression="AA">
                </asp:BoundField>
                <asp:BoundField DataField="AB" HeaderText="备注" SortExpression="AB">
                </asp:BoundField>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:gridview>
            <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString17 %>" deletecommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" selectcommand="if exists(SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%') AND ([B] like '%'+ @B +'%')) begin SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%') AND ([B] like '%'+ @B +'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
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
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>
            <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString16 %>" deletecommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" selectcommand="if exists(SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%')) begin SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
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
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>

            <asp:sqldatasource id="SqlDataSource3" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString17 %>" deletecommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" insertcommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" selectcommand="if exists(SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%') AND (month(convert(date,Q)) =month(@B) and day(convert(date,Q)) =day(@B))) begin SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%') AND (month(convert(date,Q)) =month(@B) and day(convert(date,Q)) =day(@B) ) end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" updatecommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="L" SessionField="gongsi2" Type="String" />
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
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:sqldatasource>

        </div>
    </form>
</body>
</html>