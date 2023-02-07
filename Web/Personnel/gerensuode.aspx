<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gerensuode.aspx.cs" Inherits="Web.Personnel.gerensuode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <h1 style="margin-top:0px;margin-bottom:10px">个人所得税</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="所有"    CssClass="top_bt" style="margin-bottom:2px;"/>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" Width="100%">
            <Columns>
                <asp:BoundField DataField="AU" HeaderText="税率" SortExpression="AU"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="25%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="count1" HeaderText="计税工资" SortExpression="count1" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="25%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="num" HeaderText="计税人数" SortExpression="num" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="25%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="count2" HeaderText="个人所得税" SortExpression="count2" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="25%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString29 %>" SelectCommand="select AU,sum((cast(ATA as money)*cast(AU as money))) AS COUNT1,COUNT(id) as num, sum((cast(AW AS money)*cast(AU AS money))) AS COUNT2 FROM gongzi_gongzimingxi WHERE AU is not null and ([BD]like '%'+ @BD +'%') GROUP BY AU UNION ALL select '合计',sum((cast(ATA as money)*cast(AU as money))) ,count(id),sum((cast(AW AS money)*cast(AU AS money))) from gongzi_gongzimingxi ">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
        
    </div>
    </form>
</body>
</html>
