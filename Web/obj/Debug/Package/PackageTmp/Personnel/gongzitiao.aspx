﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongzitiao.aspx.cs" Inherits="Web.Personnel.gongzitiao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <h1 style="margin-top:0px;margin-bottom:10px;">工资条</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Height="30px" Text="部门：" style="text-align:center"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="120px"  CssClass="top_select_input" DataSourceID="SqlDataSource5" DataTextField="C" DataValueField="C" style="text-align:center;border:0.5px solid #378888">
            <asp:ListItem></asp:ListItem>
             <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString49 %>" SelectCommand="SELECT NULL as [BD],NULL AS [C] UNION ALL SELECT DISTINCT [BD], [C] FROM [gongzi_gongzimingxi] WHERE (([BD] = @gongsi))    ">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString49 %>" SelectCommand="SELECT NULL as [BD],NULL AS [D] UNION ALL SELECT DISTINCT [BD], [D] FROM [gongzi_gongzimingxi] WHERE (([BD] = @gongsi))    ">
            <SelectParameters>
                <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Height="30px" Text="岗位：" style="text-align:center"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="120px"  CssClass="top_select_input" DataSourceID="SqlDataSource4" DataTextField="D" DataValueField="D" style="text-align:center;border:0.5px solid #378888">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Height="30px" Text="年：" style="text-align:center"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" Height="30px" Width="120px"  CssClass="top_select_input" style="text-align:center;border:0.5px solid #378888">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>2018</asp:ListItem>
            <asp:ListItem>2019</asp:ListItem>
            <asp:ListItem>2020</asp:ListItem>
            <asp:ListItem>2021</asp:ListItem>
            <asp:ListItem>2022</asp:ListItem>
            <asp:ListItem>2023</asp:ListItem>
            <asp:ListItem>2024</asp:ListItem>
            <asp:ListItem>2025</asp:ListItem>
            <asp:ListItem>2026</asp:ListItem>
            <asp:ListItem>2027</asp:ListItem>
            <asp:ListItem>2028</asp:ListItem>
            <asp:ListItem>2029</asp:ListItem>
            <asp:ListItem>2030</asp:ListItem>
            <asp:ListItem>2031</asp:ListItem>
            <asp:ListItem>2032</asp:ListItem>
            <asp:ListItem>2033</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Height="30px" Text="月：" style="text-align:center"></asp:Label>
        <asp:DropDownList ID="DropDownList4" runat="server" Height="30px" Width="120px"  CssClass="top_select_input" style="text-align:center;border:0.5px solid #378888">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>01</asp:ListItem>
            <asp:ListItem>02</asp:ListItem>
            <asp:ListItem>03</asp:ListItem>
            <asp:ListItem>04</asp:ListItem>
            <asp:ListItem>05</asp:ListItem>
            <asp:ListItem>06</asp:ListItem>
            <asp:ListItem>07</asp:ListItem>
            <asp:ListItem>08</asp:ListItem>
            <asp:ListItem>09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Height="30px" Text="搜索" OnClick="Button1_Click" CssClass="top_bt" style="margin-right:-10px" />
        <asp:Button ID="Button2" runat="server" Height="30px" Text="所有" OnClick="Button2_Click" CssClass="top_bt" style="margin-right:-10px" />
        <asp:Button ID="Button3" runat="server" Height="30px" Text="生成Excel" OnClick="toExcel" CssClass="top_bt" style="margin-right:-10px" />
        <asp:Button ID="Button4" runat="server" Height="30px" Text="打印" OnClick="print" CssClass="top_bt" style="margin-right:-10px" />
        <br />
        
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"  Visible="false"/>
                <asp:BoundField DataField="B" HeaderText="姓名" SortExpression="B" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="部门" SortExpression="C" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="岗位" SortExpression="D" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="身份证号" SortExpression="E" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="入职时间" SortExpression="F" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="基本工资" SortExpression="G" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="绩效工资" SortExpression="H" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="岗位工资" SortExpression="I" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="当月合计工资" SortExpression="J" HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="跨度工资" SortExpression="K"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="L" HeaderText="职称津贴" SortExpression="L"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="M" HeaderText="月出勤天数" SortExpression="M"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="N" HeaderText="加班时间" SortExpression="N"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="O" HeaderText="加班费" SortExpression="O"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="P" HeaderText="全勤应发" SortExpression="P"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Q" HeaderText="缺勤天数" SortExpression="Q"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="R" HeaderText="缺勤扣款" SortExpression="R"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="S" HeaderText="迟到天数" SortExpression="S"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="T" HeaderText="迟到扣款" SortExpression="T"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="U" HeaderText="应发工资" SortExpression="U"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="V" HeaderText="社保基数" SortExpression="V"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="W" HeaderText="医疗技术" SortExpression="W"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="X" HeaderText="公积金基数" SortExpression="X"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Y" HeaderText="年金基数" SortExpression="Y"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Z" HeaderText="企业养老" SortExpression="Z"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AA" HeaderText="企业失业" SortExpression="AA"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AB" HeaderText="企业医疗" SortExpression="AB"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AC" HeaderText="企业工伤" SortExpression="AC"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AD" HeaderText="企业生育" SortExpression="AD"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AE" HeaderText="企业公积金" SortExpression="AE"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AF" HeaderText="企业年金" SortExpression="AF"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AG" HeaderText="滞纳金" SortExpression="AG"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AH" HeaderText="利息" SortExpression="AH"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AI" HeaderText="企业小计" SortExpression="AI"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AJ" HeaderText="个人养老" SortExpression="AJ"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AK" HeaderText="个人失业" SortExpression="AK"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AL" HeaderText="个人医疗" SortExpression="AL"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AM" HeaderText="个人生育" SortExpression="AM"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AN" HeaderText="个人公积金" SortExpression="AN"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AO" HeaderText="个人年金4%" SortExpression="AO"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AP" HeaderText="滞纳金" SortExpression="AP"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AQ" HeaderText="利息" SortExpression="AQ"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AR" HeaderText="个人小计" SortExpression="AR"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ASA" HeaderText="税前工资" SortExpression="ASA"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ATA" HeaderText="应税工资" SortExpression="ATA"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AU" HeaderText="税率" SortExpression="AU"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AV" HeaderText="扣除数" SortExpression="AV"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AW" HeaderText="代扣个人所得税" SortExpression="AW"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AX" HeaderText="年金1%" SortExpression="AX"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AY" HeaderText="实发工资" SortExpression="AY"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="AZ" HeaderText="验算公式" SortExpression="AZ"  HeaderStyle-Font-Bold="true">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BA" HeaderText="银行账号" SortExpression="BA" Visible="false">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BB" HeaderText="调薪时间" SortExpression="BB" Visible="false">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BC" HeaderText="录入时间" SortExpression="BC" Visible="false">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BD" HeaderText="BD" SortExpression="BD"   Visible="false">
                </asp:BoundField>
                </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        
        <%--<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString48 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = @BD) AND ([C] = @C) AND ([D] = @D))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="D" SessionField="zw1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString47 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = @BD) AND ([D] = @D))">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="D" SessionField="zw1" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString46 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = @BD) AND ([C] like '%'+@C+'%') AND ([D] like '%'+@D+'%') AND (Year([BC]) like '%'+@N+'%')) UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','' order by id desc">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="D" SessionField="zw1" Type="String" />
                <asp:SessionParameter Name="N" SessionField="Nian" Type="String" />
                <%--<asp:SessionParameter Name="Y" SessionField="Yue" Type="String" />--%>
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString46 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = @BD) AND ([C] like '%'+@C+'%') AND ([D] like '%'+@D+'%') AND (Year([BC]) like '%'+@N+'%') AND (Month([BC]) = @Y)) UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','' order by id desc">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="bm1" Type="String" />
                <asp:SessionParameter Name="D" SessionField="zw1" Type="String" />
                <asp:SessionParameter Name="N" SessionField="Nian" Type="String" />
                <asp:SessionParameter Name="Y" SessionField="Yue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString45 %>" SelectCommand="SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] = @BD)  UNION select '','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','','' order by id desc">
            <SelectParameters>
                <asp:SessionParameter Name="BD" SessionField="gongsi" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
