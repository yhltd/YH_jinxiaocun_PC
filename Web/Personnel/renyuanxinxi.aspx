<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renyuanxinxi.aspx.cs" Inherits="Web.Personnel.renyuanxinxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <script>
        function a() {
            var a= document.getelementbyid("header") 
            a.style.width="7%"
        }
    </script>
    <h1 style="margin-top:0px;margin-bottom:10px">人员信息管理</h1>
    <form id="form1" runat="server"  style="    margin: 0;">
    <div>
        <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px" style="text-align:center"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Height="30px" Text="手机号：" Width="80px" style="text-align:center"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="搜索" CssClass="top_bt" Height="30px" Width="80px"  style="margin-right:-10px"/>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" CssClass="top_bt" Height="30px" Width="80px" style="margin-right:-10px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有" CssClass="top_bt" Height="30px" Width="80px" style="margin-right:-10px" />
        <asp:Button ID="Button4" runat="server" OnClick="toExcel" Text="生成Excel" CssClass="top_bt" Height="30px" Width="80px" style="margin-right:-10px" />
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"  OnRowCommand="GridView_OnRowCommand" OnRowCreated="aaa" Width="100%"><%--AllowPaging="True"--%>
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="修改" CommandName="Btn_Operation" ItemStyle-CssClass="bt_upd1">
                        <ControlStyle Width="50px"  />
                    <HeaderStyle Wrap="False" />
                        <ItemStyle HorizontalAlign="Center" Wrap="False" ></ItemStyle>
                </asp:ButtonField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2" DeleteText="删除">
                    <ControlStyle Width="50px"/>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
<ControlStyle Width="80%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
<ControlStyle Width="80%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="职务" SortExpression="D" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
<ControlStyle Width="80%"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="E" SortExpression="E"   />
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F"   />
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G"   />
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H"   />
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I"   />
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J"   />
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K"   />
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L"   />
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R"   />
                <%--</asp:BoundField>--%>
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S"   />
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T"   />
                <asp:BoundField DataField="U" HeaderText="U" SortExpression="U"   />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V"   />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W"   />
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X"   />
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y"   />
                <asp:BoundField DataField="Z" HeaderText="Z" SortExpression="Z"   />
                <asp:BoundField DataField="AA" HeaderText="AA" SortExpression="AA"   />
                <asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB"   />
                <asp:BoundField DataField="AC" HeaderText="AC" SortExpression="AC"   />
                <asp:BoundField DataField="AD" HeaderText="AD" SortExpression="AD"   />
                <%--</asp:BoundField>--%>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+@L+'%') AND ([B] like '%'+@B+'%')  AND ([O] like '%'+@O+'%') ) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') AND ([B] like '%'+@B+'%') AND ([O] like '%'+@O+'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
                <asp:SessionParameter Name="O" SessionField="xm2" Type="String" />
                <%--<asp:Parameter Name="O">
                </asp:Parameter>--%>
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
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString18 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%')) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+@L+'%') AND ([B] like '%'+@B+'%')  ) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') AND ([B] like '%'+@B+'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
                <%--<asp:Parameter Name="O">
                </asp:Parameter>--%>
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
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="if exists(SELECT * FROM [gongzi_renyuan] where ([L] like '%'+@L+'%') AND ([O] like '%'+@O+'%') ) begin SELECT * FROM [gongzi_renyuan] where ([L] like '%'+ @L +'%') AND ([O] like '%'+@O+'%') end else SELECT * FROM [gongzi_renyuan] where id=0 UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','',''" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
                <asp:SessionParameter Name="O" SessionField="xm2" Type="String" />
                <%--<asp:Parameter Name="O">
                </asp:Parameter>--%>
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
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
