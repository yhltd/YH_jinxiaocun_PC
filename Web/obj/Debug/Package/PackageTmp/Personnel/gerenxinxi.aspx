<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gerenxinxi.aspx.cs" Inherits="Web.Personnel.gerenxinxi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <%--<script type="text/javascript">
        function a(){
            alert("修改成功！")
        }
    </script>--%>
    <h1 style="margin-top:0px;margin-bottom:10px">个人信息</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px" style="text-align:center"></asp:Label>
    
        <asp:TextBox ID="TextBox1" runat="server"  CssClass="top_select_input" Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click"   CssClass="top_bt" ClientIDMode="AutoID" Height="30px" Width="80px" style="margin-right:-10px" />
        <asp:Button ID="Button2" runat="server" Text="所有" OnClick="Button2_Click" CssClass="top_bt" style="margin-right:-10px" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"  Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="职务" SortExpression="D" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="身份证号" SortExpression="E" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="基本工资" SortExpression="F" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="银行卡号" SortExpression="G" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="入职时间" SortExpression="H" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="账号" SortExpression="I" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="密码" SortExpression="J" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="工龄/年" SortExpression="K" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="10%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L"  Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString17 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="SELECT * FROM [gongzi_renyuan] WHERE (([L] like '%'+ @L +'%') AND ([B] like '%'+ @B +'%'))" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString16 %>" DeleteCommand="DELETE FROM [gongzi_renyuan] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_renyuan] ([B], [C], [D], [E], [F], [G], [H], [I], [J], [K], [L]) VALUES (@B, @C, @D, @E, @F, @G, @H, @I, @J, @K, @L)" SelectCommand="SELECT * FROM [gongzi_renyuan] WHERE ([L] like '%'+ @L +'%')" UpdateCommand="UPDATE [gongzi_renyuan] SET [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J, [K] = @K, [L] = @L WHERE [id] = @id">
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
