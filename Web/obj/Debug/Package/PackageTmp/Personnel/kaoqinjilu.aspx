<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kaoqinjilu.aspx.cs" Inherits="Web.Personnel.kaoqinjilu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="    margin: 0;">
    <h1 style="margin-top:0px;margin-bottom:10px">考勤记录</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Height="30px" Text="年份：" Width="80px"  style="text-align:center" ></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="150px"  CssClass="top_select_input" style="text-align:center;border:0.5px solid #378888">
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
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Height="30px" Text="月份：" Width="80px" style="text-align:center"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="150px"  CssClass="top_select_input" style="text-align:center;border:0.5px solid #378888" >
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Height="30px" Text="搜索" Width="80px" OnClick="Button1_Click" CssClass="top_bt" style="margin-right:-10px"/>
        <asp:Button ID="Button2" runat="server" Height="30px" Text="添加" Width="80px" OnClick="Button2_Click" CssClass="top_bt" style="margin-right:-10px"/>
        <asp:Button ID="Button3" runat="server" Height="30px" Text="所有" Width="80px" OnClick="Button3_Click" CssClass="top_bt" style="margin-right:-10px"/>
        <asp:Button ID="Button4" CssClass="top_bt" runat="server" Height="30px" Text="生成Excel" Width="80px" OnClick="toExcel" style="margin-right:-10px" />
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True"  OnRowCreated="aaa">
            <Columns>
                <asp:CommandField ShowEditButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd1">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-CssClass="bt_upd2">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false"/>
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="C" HeaderText="年" SortExpression="C"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="D" HeaderText="月" SortExpression="D"   ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="E" HeaderText="应到" SortExpression="E"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="F" HeaderText="实到" SortExpression="F"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true" >
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="G" HeaderText="请假" SortExpression="G"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="H" HeaderText="加班" SortExpression="H"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="I" HeaderText="迟到" SortExpression="I"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="J" HeaderText="部门" SortExpression="J"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center"  Width="11%"/>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="K" HeaderText="K" SortExpression="K" Visible="false"/>
            </Columns>
            <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
            <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
            <SelectedRowStyle CssClass="header" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString14 %>" DeleteCommand="DELETE FROM [gongzi_kaoqinmingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_kaoqinmingxi] ([name], [C], [D], [E], [F], [G], [H], [I], [J], [K]) VALUES (@name, @C, @D, @E, @F, @G, @H, @I, @J, @K)" SelectCommand="SELECT * FROM [gongzi_kaoqinmingxi] WHERE (([K] = @K) AND ([C] = @C) AND ([D] = @D ))" UpdateCommand="UPDATE [gongzi_kaoqinmingxi] SET [name] = @name, [C] = @C, [D] = CASE WHEN CONVERT(INT,@D)&gt;0 AND CONVERT(INT,@D)&lt;13 THEN @D  ELSE '1' END, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="K" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="K" SessionField="gongsi" Type="String" />
                <asp:SessionParameter Name="C" SessionField="year" Type="String" />
                <asp:SessionParameter Name="D" SessionField="moth" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="G" Type="String" />
                <asp:Parameter Name="H" Type="String" />
                <asp:Parameter Name="I" Type="String" />
                <asp:Parameter Name="J" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString13 %>" DeleteCommand="DELETE FROM [gongzi_kaoqinmingxi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_kaoqinmingxi] ([name], [C], [D], [E], [F], [G], [H], [I], [J], [K]) VALUES (@name, @C, @D, @E, @F, @G, @H, @I, @J, @K)"  SelectCommand="SELECT * FROM [gongzi_kaoqinmingxi] WHERE ([K] like '%'+ @K +'%')"  UpdateCommand="UPDATE [gongzi_kaoqinmingxi] SET [name] = @name, [C] = @C, [D] = CASE WHEN CONVERT(INT,@D)&gt;0 AND CONVERT(INT,@D)&lt;13 THEN @D  ELSE '1' END, [E] = @E, [F] = @F, [G] = @G, [H] = @H, [I] = @I, [J] = @J WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id">
                </asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name">
                </asp:Parameter>
                <asp:Parameter Name="C">
                </asp:Parameter>
                <asp:Parameter Name="D">
                </asp:Parameter>
                <asp:Parameter Name="E">
                </asp:Parameter>
                <asp:Parameter Name="F">
                </asp:Parameter>
                <asp:Parameter Name="G">
                </asp:Parameter>
                <asp:Parameter Name="H">
                </asp:Parameter>
                <asp:Parameter Name="I">
                </asp:Parameter>
                <asp:Parameter Name="J">
                </asp:Parameter>
                <asp:Parameter Name="K">
                </asp:Parameter>
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="K" SessionField="gongsi" Type="String"/>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="name">
                </asp:Parameter>
                <asp:Parameter Name="C">
                </asp:Parameter>
                <asp:Parameter Name="D">
                </asp:Parameter>
                <asp:Parameter Name="E">
                </asp:Parameter>
                <asp:Parameter Name="F">
                </asp:Parameter>
                <asp:Parameter Name="G">
                </asp:Parameter>
                <asp:Parameter Name="H">
                </asp:Parameter>
                <asp:Parameter Name="I">
                </asp:Parameter>
                <asp:Parameter Name="J">
                </asp:Parameter>
                <asp:Parameter Name="id">
                </asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
