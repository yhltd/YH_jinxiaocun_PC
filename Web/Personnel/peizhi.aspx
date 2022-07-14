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
    <div style="position:fixed">
        <h1 style="margin-top:0px;margin-bottom:10px">配置表</h1>
    </div>
    <div style="height:50px"></div>
    <form id="form1" runat="server">
    <div class="iframe_d">
    
    </div>
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
                <asp:BoundField DataField="gongsi" HeaderText="公司" SortExpression="gongsi" Visible="false"/>
                <asp:BoundField DataField="kaoqin" HeaderText="社保基数" SortExpression="kaoqin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="kaoqin_peizhi" HeaderText="公积金基数" SortExpression="kaoqin_peizhi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="bumen" HeaderText="部门配置" SortExpression="bumen" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="zhiwu" HeaderText="职务配置" SortExpression="zhiwu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="chidao_koukuan" HeaderText="迟到扣款" SortExpression="chidao_koukuan" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_yiliao" HeaderText="个人医疗" SortExpression="geren_yiliao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_yiliao" HeaderText="企业医疗" SortExpression="qiye_yiliao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_shengyu" HeaderText="个人生育" SortExpression="geren_shengyu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_shengyu" HeaderText="企业生育" SortExpression="qiye_shengyu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_gongjijin" HeaderText="个人公积金" SortExpression="geren_gongjijin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_gongjijin" HeaderText="企业公积金" SortExpression="qiye_gongjijin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="yiliao_jishu" HeaderText="医疗技术" SortExpression="yiliao_jishu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_nianjin" HeaderText="个人年金" SortExpression="geren_nianjin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_nianjin" HeaderText="企业年金" SortExpression="qiye_nianjin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="zhinajin" HeaderText="滞纳金" SortExpression="zhinajin" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="nianjin_jishu" HeaderText="年金基数" SortExpression="nianjin_jishu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="lixi" HeaderText="利息" SortExpression="lixi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_yanglao" HeaderText="个人养老" SortExpression="geren_yanglao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_yanglao" HeaderText="企业养老" SortExpression="qiye_yanglao" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="gangwei" HeaderText="岗位" SortExpression="gangwei" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="gangwei_gongzi" HeaderText="岗位工资" SortExpression="gangwei_gongzi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="geren_shiye" HeaderText="个人失业" SortExpression="geren_shiye" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_shiye" HeaderText="企业失业" SortExpression="qiye_shiye" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="gongzi" HeaderText="工资" SortExpression="gongzi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="shuilv" HeaderText="税率" SortExpression="shuilv" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="kuadu_gongzi" HeaderText="跨度工资" SortExpression="kuadu_gongzi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="qiye_gongshang" HeaderText="企业工伤" SortExpression="qiye_gongshang" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="jintie" HeaderText="职称津贴" SortExpression="jintie" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="nianjin1" HeaderText="年金1%" SortExpression="nianjin1" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="jiabanfei" HeaderText="加班费" SortExpression="jiabanfei" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="yansuangongshi" HeaderText="验算公式" SortExpression="yansuangongshi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="23%" />
                    <ItemStyle HorizontalAlign="Center" Wrap="False"/>
                    </asp:BoundField>
                <asp:BoundField DataField="queqin_koukuan" HeaderText="缺勤扣款" SortExpression="queqin_koukuan" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:yaoConnectionString44 %>" DeleteCommand="DELETE FROM [gongzi_peizhi] WHERE [id] = @id" InsertCommand="INSERT INTO [gongzi_peizhi] ([gongsi], [kaoqin], [kaoqin_peizhi], [bumen], [zhiwu], [year], [month], [day]) VALUES (@gongsi, @kaoqin, @kaoqin_peizhi, @bumen, @zhiwu, @year, @month, @day)" SelectCommand="SELECT * FROM [gongzi_peizhi] WHERE ([gongsi] = @gongsi)" UpdateCommand="UPDATE [gongzi_peizhi] SET [kaoqin] = @kaoqin, [kaoqin_peizhi] = @kaoqin_peizhi, [bumen] = @bumen, [zhiwu] = @zhiwu, [year] = @year, [month] = @month, [day] = @day, [chidao_koukuan] = @chidao_koukuan, geren_yiliao = @geren_yiliao, qiye_yiliao= @qiye_yiliao, geren_shengyu = @geren_shengyu, qiye_shengyu = @qiye_shengyu, geren_gongjijin = @geren_gongjijin, qiye_gongjijin= @qiye_gongjijin, yiliao_jishu = @yiliao_jishu, geren_nianjin = @geren_nianjin, zhinajin = @zhinajin, nianjin_jishu= @nianjin_jishu, lixi = @lixi, geren_yanglao= @geren_yanglao, qiye_yanglao = @qiye_yanglao, gangwei = @gangwei, gangwei_gongzi = @gangwei_gongzi, qiye_shiye = @qiye_shiye , gongzi = @gongzi , shuilv = @shuilv, kuadu_gongzi = @kuadu_gongzi, qiye_gongshang= @qiye_gongshang, jintie = @jintie, qiye_nianjin = @qiye_nianjin, nianjin1 = @nianjin1, jiabanfei = @jiabanfei, yansuangongshi = @yansuangongshi , queqin_koukuan= @queqin_koukuan, geren_shiye = @geren_shiye  WHERE [id] = @id">
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
                <asp:Parameter Name="kaoqin" Type="String" />
                <asp:Parameter Name="kaoqin_peizhi" Type="String" />
                <asp:Parameter Name="bumen" Type="String" />
                <asp:Parameter Name="zhiwu" Type="String" />
                <asp:Parameter Name="year" Type="String" />
                <asp:Parameter Name="month" Type="String" />
                <asp:Parameter Name="day" Type="String" />
                <asp:Parameter Name="chidao_koukuan" />
                <asp:Parameter Name="geren_yiliao" />
                <asp:Parameter Name="qiye_yiliao" />
                <asp:Parameter Name="geren_shengyu" />
                <asp:Parameter Name="qiye_shengyu" />
                <asp:Parameter Name="geren_gongjijin" />
                <asp:Parameter Name="qiye_gongjijin" />
                <asp:Parameter Name="yiliao_jishu" />
                <asp:Parameter Name="geren_nianjin" />
                <asp:Parameter Name="zhinajin" />
                <asp:Parameter Name="nianjin_jishu" />
                <asp:Parameter Name="lixi" />
                <asp:Parameter Name="geren_yanglao" />
                <asp:Parameter Name="qiye_yanglao" />
                <asp:Parameter Name="gangwei" />
                <asp:Parameter Name="gangwei_gongzi" />
                <asp:Parameter Name="qiye_shiye" />
                <asp:Parameter Name="gongzi" />
                <asp:Parameter Name="shuilv" />
                <asp:Parameter Name="kuadu_gongzi" />
                <asp:Parameter Name="qiye_gongshang" />
                <asp:Parameter Name="jintie" />
                <asp:Parameter Name="qiye_nianjin" />
                <asp:Parameter Name="nianjin1" />
                <asp:Parameter Name="jiabanfei" />
                <asp:Parameter Name="yansuangongshi" />
                <asp:Parameter Name="queqin_koukuan" />
                <asp:Parameter Name="geren_shiye" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加一行"  CssClass="top_bt" Height="30px" Width="80px" style="margin-left:4.3%;margin-top:1%"/>
        </div>
    </form>
    
</body>
</html>
