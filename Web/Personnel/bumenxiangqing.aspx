<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bumenxiangqing.aspx.cs" Inherits="Web.Personnel.bumenxiangqing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px"></asp:Label>
    
        <asp:TextBox ID="TextBox1" runat="server" CssClass="top_select_input" ></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" CssClass="top_bt" />
        <asp:Button ID="Button3" runat="server" Text="所有" OnClick="Button3_Click" CssClass="top_bt" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <%--<asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />--%>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" />
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" />
                <asp:BoundField DataField="D" HeaderText="岗位" SortExpression="D" />
                <%--<asp:BoundField DataField="E" HeaderText="E" SortExpression="E" />
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F" />
                <asp:BoundField DataField="G" HeaderText="G" SortExpression="G" />
                <asp:BoundField DataField="H" HeaderText="H" SortExpression="H" />
                <asp:BoundField DataField="I" HeaderText="I" SortExpression="I" />
                <asp:BoundField DataField="J" HeaderText="J" SortExpression="J" />
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K" />
                <asp:BoundField DataField="L" HeaderText="L" SortExpression="L" />
                <asp:BoundField DataField="M" HeaderText="M" SortExpression="M" />
                <asp:BoundField DataField="N" HeaderText="N" SortExpression="N" />
                <asp:BoundField DataField="O" HeaderText="O" SortExpression="O" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                <asp:BoundField DataField="Q" HeaderText="Q" SortExpression="Q" />
                <asp:BoundField DataField="R" HeaderText="R" SortExpression="R" />
                <asp:BoundField DataField="S" HeaderText="S" SortExpression="S" />
                <asp:BoundField DataField="T" HeaderText="T" SortExpression="T" />
                <asp:BoundField DataField="U" HeaderText="U" SortExpression="U" />
                <asp:BoundField DataField="V" HeaderText="V" SortExpression="V" />
                <asp:BoundField DataField="W" HeaderText="W" SortExpression="W" />
                <asp:BoundField DataField="X" HeaderText="X" SortExpression="X" />
                <asp:BoundField DataField="Y" HeaderText="Y" SortExpression="Y" />--%>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z" />
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ" />
                <asp:BoundField DataField="count1" HeaderText="个人养老" SortExpression="count1" />
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA" />
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK" />
                <asp:BoundField DataField="count1" HeaderText="失业小计" SortExpression="count1" />
                <%--<asp:BoundField DataField="AB" HeaderText="AB" SortExpression="AB" />--%>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC" />
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD" />
                <%--<asp:BoundField DataField="AE" HeaderText="AE" SortExpression="AE" />
                <asp:BoundField DataField="AF" HeaderText="AF" SortExpression="AF" />
                <asp:BoundField DataField="AG" HeaderText="AG" SortExpression="AG" />
                <asp:BoundField DataField="AH" HeaderText="AH" SortExpression="AH" />
                <asp:BoundField DataField="AI" HeaderText="AI" SortExpression="AI" />--%>
                <%--<asp:BoundField DataField="AL" HeaderText="AL" SortExpression="AL" />
                <asp:BoundField DataField="AM" HeaderText="AM" SortExpression="AM" />
                <asp:BoundField DataField="AN" HeaderText="AN" SortExpression="AN" />
                <asp:BoundField DataField="AO" HeaderText="AO" SortExpression="AO" />
                <asp:BoundField DataField="AP" HeaderText="AP" SortExpression="AP" />
                <asp:BoundField DataField="AQ" HeaderText="AQ" SortExpression="AQ" />
                <asp:BoundField DataField="AR" HeaderText="AR" SortExpression="AR" />
                <asp:BoundField DataField="ASA" HeaderText="ASA" SortExpression="ASA" />
                <asp:BoundField DataField="ATA" HeaderText="ATA" SortExpression="ATA" />
                <asp:BoundField DataField="AU" HeaderText="AU" SortExpression="AU" />
                <asp:BoundField DataField="AV" HeaderText="AV" SortExpression="AV" />
                <asp:BoundField DataField="AW" HeaderText="AW" SortExpression="AW" />
                <asp:BoundField DataField="AX" HeaderText="AX" SortExpression="AX" />
                <asp:BoundField DataField="AY" HeaderText="AY" SortExpression="AY" />
                <asp:BoundField DataField="AZ" HeaderText="AZ" SortExpression="AZ" />
                <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA" />
                <asp:BoundField DataField="BB" HeaderText="BB" SortExpression="BB" />
                <asp:BoundField DataField="BC" HeaderText="BC" SortExpression="BC" />
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD" />--%>
                <asp:BoundField DataField="count3" HeaderText="企业合计" SortExpression="count3" />
                <asp:BoundField DataField="count4" HeaderText="个人合计" SortExpression="count4" />
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString43 %>" SelectCommand="select id,B,C,D,Z,AJ,(Z+AJ)AS count1,AA,AK,(AA+AK)AS count2,AC,AD,(Z+AA+AC+AD)AS count3,(AJ+AK)AS count4 FROM gongzi_gongzimingxi WHERE (([BD]=@BD) AND ([B]=@B) AND ([C]=@C))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString42 %>" SelectCommand="select id,B,C,D,Z,AJ,(Z+AJ)AS count1,AA,AK,(AA+AK)AS count2,AC,AD,(Z+AA+AC+AD)AS count3,(AJ+AK)AS count4 FROM gongzi_gongzimingxi WHERE (([BD]=@BD) AND ([C]=@C))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"  CssClass="top_bt" />
    
    </div>
    </form>
</body>
</html>
