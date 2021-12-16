<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bumenxiangqing1.aspx.cs" Inherits="Web.Personnel.bumenxiangqing1" %>

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
        <asp:Label ID="Label1" runat="server" Height="30px" Text="姓名：" Width="80px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"  CssClass="top_select_input"  Height="30px" Width="150px" style="text-align:center;border:0.5px solid #378888"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="搜索"  CssClass="top_bt" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" Text="所有"  CssClass="top_bt" />
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible = "false"/>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="岗位" SortExpression="D" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="E" SortExpression="E"  Visible = "false">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="F" SortExpression="F"  Visible = "false">
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="基本工资" SortExpression="G" >
                <HeaderStyle Wrap="False" HorizontalAlign="Center"/>
                <ItemStyle Wrap="False" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="绩效工资" SortExpression="H" >
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
                <asp:BoundField DataField="M" HeaderText="月出勤" SortExpression="M" >
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
                <asp:BoundField DataField="W" HeaderText="医疗基数" SortExpression="W" >
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
                <asp:BoundField DataField="AZ" HeaderText="AZ" SortExpression="AZ"   Visible = "false"/>
                <asp:BoundField DataField="BA" HeaderText="BA" SortExpression="BA"   Visible = "false"/>
                <asp:BoundField DataField="BB" HeaderText="BB" SortExpression="BB"   Visible = "false"/>
                <asp:BoundField DataField="BC" HeaderText="BC" SortExpression="BC"   Visible = "false"/>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD"   Visible = "false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString28 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] like '%'+ @BD +'%') AND ([C]like '%'+ @C +'%') AND ([B]like '%'+ @B +'%'))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="B" SessionField="xm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString27 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] like '%'+ @BD +'%') AND ([C] like '%'+ @C +'%'))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回"  CssClass="top_bt"  style="margin-left:46%;"/>
    </div>
    </form>
</body>
</html>
