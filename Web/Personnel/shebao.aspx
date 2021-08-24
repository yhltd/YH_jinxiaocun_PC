<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shebao.aspx.cs" Inherits="Web.Personnel.shebao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body  style="    margin: 0;">
    <form id="form1" runat="server"  style="    margin: 0;">
    <div>
    
        <asp:Label ID="Label1" runat="server" Height="30px" Text="部门：" Width="80px"></asp:Label>
    
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="C" DataValueField="C"  CssClass="top_select_input" Height="30px" Width="150px">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click"   CssClass="top_bt" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="部门详情"   CssClass="top_bt" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="所有"   CssClass="top_bt" />
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString41 %>" SelectCommand="SELECT [C], [BD] FROM [gongzi_gongzimingxi] WHERE ([BD] = @gongsi)  GROUP BY [C], [BD]">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataSourceID="SqlDataSource1">
            <Columns>
<%--                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="B" SortExpression="B" Visible="false"/>--%>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" />
<%--                <asp:BoundField DataField="D" HeaderText="D" SortExpression="D" Visible="false"/>
                <asp:BoundField DataField="E" HeaderText="E" SortExpression="E" Visible="false"/>
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F" Visible="false"/>
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G" Visible="false"/>
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H" Visible="false"/>
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I" Visible="false"/>
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J" Visible="false"/>
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K" Visible="false"/>
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L" Visible="false"/>
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M" Visible="false"/>
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N" Visible="false"/>
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O" Visible="false"/>
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" Visible="false"/>
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q" Visible="false"/>
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R" Visible="false"/>
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" Visible="false"/>
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T" Visible="false"/>
                <asp:BoundField DataField="U" HeaderText="U" SortExpression="U" Visible="false"/>
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" Visible="false"/>
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" Visible="false"/>
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X" Visible="false"/>
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y" Visible="false"/>--%>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" />
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" />
                <asp:BoundField DataField="count1" HeaderText="养老小计" SortExpression="count1" />
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" />
<%--                <asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB" Visible="false"/>
                <asp:BoundField DataField="AE" HeaderText="AE" SortExpression="AE" Visible="false"/>
                <asp:BoundField DataField="AF" HeaderText="AF" SortExpression="AF" Visible="false"/>
                <asp:BoundField DataField="AG" HeaderText="AG" SortExpression="AG" Visible="false"/>
                <asp:BoundField DataField="AH" HeaderText="AH" SortExpression="AH" Visible="false"/>
                <asp:BoundField DataField="AI" HeaderText="AI" SortExpression="AI" Visible="false"/>--%>
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" />
                <asp:BoundField DataField="count2" HeaderText="失业小计" SortExpression="count2" />
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" />
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" />
<%--                <asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" Visible="false"/>
                <asp:BoundField DataField="AM" HeaderText="AM" SortExpression="AM" Visible="false"/>
                <asp:BoundField DataField="AN" HeaderText="AN" SortExpression="AN" Visible="false"/>
                <asp:BoundField DataField="AO" HeaderText="AO" SortExpression="AO" Visible="false"/>
                <asp:BoundField DataField="AP" HeaderText="AP" SortExpression="AP" Visible="false"/>
                <asp:BoundField DataField="AQ" HeaderText="AQ" SortExpression="AQ" Visible="false"/>
                <asp:BoundField DataField="AR" HeaderText="AR" SortExpression="AR" Visible="false"/>
                <asp:BoundField DataField="ASA" HeaderText="ASA" SortExpression="ASA" Visible="false"/>
                <asp:BoundField DataField="ATA" HeaderText="ATA" SortExpression="ATA" Visible="false"/>
                <asp:BoundField DataField="AU" HeaderText="AU" SortExpression="AU" Visible="false"/>
                <asp:BoundField DataField="AV" HeaderText="AV" SortExpression="AV" Visible="false"/>
                <asp:BoundField DataField="AW" HeaderText="AW" SortExpression="AW" Visible="false"/>
                <asp:BoundField DataField="AX" HeaderText="AX" SortExpression="AX" Visible="false"/>
                <asp:BoundField DataField="AY" HeaderText="AY" SortExpression="AY" Visible="false"/>
                <asp:BoundField DataField="AZ" HeaderText="AZ" SortExpression="AZ" Visible="false"/>
                <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA" Visible="false"/>
                <asp:BoundField DataField="BB" HeaderText="BB" SortExpression="BB" Visible="false"/>
                <asp:BoundField DataField="BC" HeaderText="BC" SortExpression="BC" Visible="false"/>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD" Visible="false"/>--%>
                <asp:BoundField DataField="count3" HeaderText="企业合计" SortExpression="count3" />
                <asp:BoundField DataField="count4" HeaderText="个人合计" SortExpression="count4" />
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString40 %>" SelectCommand="select C ,sum(cast(Z as float))as Z,sum(cast(AJ as float))as AJ,sum(cast(Z as float)+cast(AJ as float))as count1,sum(cast(AA as float))as AA,sum (CAST(AK as float))as AK,sum(cast(AA as float)+cast(AK as float))as count2,sum(cast(AC as float))as AC,sum(cast(AD as float))as AD,sum(cast(Z as float)+cast(AA as float)+cast(AC as float)+cast(AD as float))as count3,sum(cast(AJ as float)+cast(AK as float))as count4 from gongzi_gongzimingxi where (([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%')) group by C">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString34 %>" SelectCommand="select C ,sum(cast(Z as float))as Z,sum(cast(AJ as float))as AJ,sum(cast(Z as float)+cast(AJ as float))as count1,sum(cast(AA as float))as AA,sum (CAST(AK as float))as AK,sum(cast(AA as float)+cast(AK as float))as count2,sum(cast(AC as float))as AC,sum(cast(AD as float))as AD,sum(cast(Z as float)+cast(AA as float)+cast(AC as float)+cast(AD as float))as count3,sum(cast(AJ as float)+cast(AK as float))as count4 from gongzi_gongzimingxi where ([BD] like '%'+ @BD +'%')  group by C">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
