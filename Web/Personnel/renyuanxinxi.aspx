<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="renyuanxinxi.aspx.cs" Inherits="Web.Personnel.renyuanxinxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <script>
        function a() {
            var a= document.getelementbyid("header") 
            a.style.width="7%"
        }
    </script>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="top_select_input" Height="30px" Width="150px" ></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="搜索" CssClass="top_bt" Height="30px" Width="80px" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" CssClass="top_bt" Height="30px" Width="80px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有" CssClass="top_bt" Height="30px" Width="80px" />
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"  OnRowCommand="GridView_OnRowCommand" OnRowCreated="aaa" Width="100%"><%--AllowPaging="True"--%>
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="修改" CommandName="Btn_Operation" ItemStyle-CssClass="bt_upd1">
                        <ControlStyle Width="50px"  />
                    <HeaderStyle Wrap="False" />
                        <ItemStyle HorizontalAlign="Center" Wrap="False" ></ItemStyle>
                </asp:ButtonField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                    <ControlStyle Width="50px"/>
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" ControlStyle-Width="80%">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" ControlStyle-Width="80%">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="职务" SortExpression="D" ControlStyle-Width="80%">
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
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString19 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="SELECT * FROM [gongzi_renyuan] WHERE (([L] = @L) AND ([B] = @B))" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString18 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="SELECT * FROM [gongzi_renyuan] WHERE ([L] = @L)" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
    </div>
    </form>
</body>
</html>
