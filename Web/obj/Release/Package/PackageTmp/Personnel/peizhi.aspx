<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="peizhi.aspx.cs" Inherits="Web.Personnel.peizhi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
    <script lang="javaScript">
        //function aaa() {
        //    document.getElementById("SqlDataSource2").SelectCommand = "SELECT [yi], [er] FROM [gongzi_shezhi];";
        //}
    </script>
<body  style="    margin: 0;">
    <form id="form1" runat="server">
    <div class="div1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" OnRowCreated="aaa">
            <Columns>
                <asp:CommandField ShowEditButton="True"   ButtonType="Button" ItemStyle-CssClass="bt_upd1" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="gongsi" HeaderText="gongsi" SortExpression="gongsi" Visible="false"/>
                <asp:BoundField DataField="kaoqin" HeaderText="考勤项目" SortExpression="kaoqin" ControlStyle-Width="80%">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="kaoqin_peizhi" HeaderText="考勤配置" SortExpression="kaoqin_peizhi" ControlStyle-Width="80%">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="bumen" HeaderText="部门配置" SortExpression="bumen" ControlStyle-Width="80%">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="zhiwu" HeaderText="职务配置" SortExpression="zhiwu" ControlStyle-Width="80%">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" Visible="false"/>
                <asp:BoundField DataField="month" HeaderText="month" SortExpression="month" Visible="false"/>
                <asp:BoundField DataField="day" HeaderText="day" SortExpression="day" Visible="false"/>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString44 %>" DeleteCommand="DELETE FROM [gongzi_peizhi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_peizhi] ([gongsi], [kaoqin], [kaoqin_peizhi], [bumen], [zhiwu], [year], [month], [day]) VALUES (@gongsi, @kaoqin, @kaoqin_peizhi, @bumen, @zhiwu, @year, @month, @day)" SelectCommand="SELECT * FROM [gongzi_peizhi] WHERE ([gongsi] = @gongsi)" UpdateCommand="UPDATE [gongzi_peizhi] SET [kaoqin] = @kaoqin, [kaoqin_peizhi] = @kaoqin_peizhi, [bumen] = @bumen, [zhiwu] = @zhiwu, [year] = @year, [month] = @month, [day] = @day WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="gongsi" Type="String" />
                <asp:Parameter Name="kaoqin" Type="String" />
                <asp:Parameter Name="kaoqin_peizhi" Type="String" />
                <asp:Parameter Name="bumen" Type="String" />
                <asp:Parameter Name="zhiwu" Type="String" />
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="month" Type="String" />
                <asp:Parameter Name="day" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="gongsi" Type="String" />
                <asp:Parameter Name="kaoqin" Type="String" />
                <asp:Parameter Name="kaoqin_peizhi" Type="String" />
                <asp:Parameter Name="bumen" Type="String" />
                <asp:Parameter Name="zhiwu" Type="String" />
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="month" Type="String" />
                <asp:Parameter Name="day" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加一行"  CssClass="top_bt" Height="30px" Width="80px" style="margin-left:46%;"/>
        </div>
    </form>
    
</body>
</html>
