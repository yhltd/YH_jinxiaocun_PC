<%@ page language="C#" autoeventwireup="true" codebehind="shenpi.aspx.cs" inherits="Web.Personnel.shenpi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <h1 style="margin-top: 0px; margin-bottom: 10px">审批记录</h1>
    <form id="form1" runat="server">
        <div>

            <asp:label id="Label1" runat="server" height="30px" text="姓名：" width="80px" style="text-align: center"></asp:label>
            <asp:textbox id="TextBox1" runat="server" cssclass="top_select_input" height="30px" width="150px" style="margin-right: -10px; border: 0.5px solid #378888"></asp:textbox>
            <asp:label id="Label12" runat="server" height="30px" text="开始时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="ks" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            <asp:label id="Label13" runat="server" height="30px" text="结束时间" width="80px" style="text-align: center"></asp:label>
            <input type="date" name="js" class="top_select_input" class="top_select_input" style="height: 30px; width: 150px; margin-right: -10px; border: 0.5px solid #378888" />
            &nbsp;&nbsp;&nbsp;
            
            <asp:button id="Button1" runat="server" onclick="Button1_Click" text="搜索" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <asp:button id="Button2" runat="server" onclick="Button2_Click" text="所有" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <br />

            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False" datasourceid="SqlDataSource1" allowpaging="True" datakeynames="id" onrowcreated="aaa">
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
                    <asp:BoundField DataField="shifa_gongzi" HeaderText="实发工资" SortExpression="shifa_gongzi"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        </asp:BoundField>
                    <asp:BoundField DataField="geren_zhichu" HeaderText="个人支出" SortExpression="geren_zhichu"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        </asp:BoundField>
                    <asp:BoundField DataField="qiye_zhichu" HeaderText="企业支出" SortExpression="qiye_zhichu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="yuangong_renshu" HeaderText="员工人数" SortExpression="yuangong_renshu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="quanqin_tianshu" HeaderText="全勤天数" SortExpression="quanqin_tianshu"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true">
                        </asp:BoundField>
                    <asp:BoundField DataField="shenpiren" HeaderText="审批人" SortExpression="shenpiren" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="riqi" HeaderText="日期" SortExpression="riqi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="gongsi" HeaderText="公司" SortExpression="gongsi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                </Columns>
                <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
                <RowStyle CssClass="item" BorderStyle="None" Wrap="False" />
                <SelectedRowStyle CssClass="header" />
            </asp:gridview>
            <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString39 %>" deletecommand="DELETE FROM [gongzi_shenpi] WHERE [id] = @id" selectcommand="if exists(SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%' and shenpiren like '%'+ @shenpiren +'%' and convert(date,riqi)&gt;=@ks and convert(date,riqi)&lt;=@js )) begin SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%' and shenpiren like '%'+ @shenpiren +'%' ) end else SELECT * FROM [gongzi_shenpi] where id=0 union  select  '','','','','','','','',''" updatecommand="UPDATE [gongzi_shenpi] SET [shifa_gongzi] = @shifa_gongzi, [qiye_zhichu] = @qiye_zhichu, [geren_zhichu] = @geren_zhichu, [yuangong_renshu] = @yuangong_renshu, [quanqin_tianshu] = @quanqin_tianshu, [shenpiren] = @shenpiren, [riqi] = @riqi WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                    <asp:SessionParameter Name="shenpiren" SessionField="shenpiren"  Type="String"/>
                    <%--<asp:SessionParameter Name="ks" SessionField="ks"  Type="String"/>
                    <asp:Parameter Name="js" Type="String" />--%>

                    <asp:SessionParameter Name="ks" SessionField="ks" />
                    <asp:SessionParameter Name="js" SessionField="js" />

                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="shifa_gongzi" />
                    <asp:Parameter Name="qiye_zhichu" />
                    <asp:Parameter Name="geren_zhichu" />
                    <asp:Parameter Name="yuangong_renshu" />
                    <asp:Parameter Name="quanqin_tianshu" />
                    <asp:Parameter Name="shenpiren" />
                    <asp:Parameter Name="riqi" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:sqldatasource>
            <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:yaoConnectionString38 %>" deletecommand="DELETE FROM [gongzi_shenpi] WHERE [id] = @id" selectcommand="if exists(SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%')) begin SELECT * FROM [gongzi_shenpi] WHERE ([gongsi] like '%'+ @gongsi +'%') end else select '','','','','','','',''" updatecommand="UPDATE [gongzi_shenpi] SET [shifa_gongzi] = @shifa_gongzi, [qiye_zhichu] = @qiye_zhichu, [geren_zhichu] = @geren_zhichu, [yuangong_renshu] = @yuangong_renshu, [quanqin_tianshu] = @quanqin_tianshu, [shenpiren] = @shenpiren, [riqi] = @riqi WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="gongsi" SessionField="gongsi" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="shifa_gongzi" />
                    <asp:Parameter Name="qiye_zhichu" />
                    <asp:Parameter Name="geren_zhichu" />
                    <asp:Parameter Name="yuangong_renshu" />
                    <asp:Parameter Name="quanqin_tianshu" />
                    <asp:Parameter Name="shenpiren" />
                    <asp:Parameter Name="riqi" />
                    <asp:Parameter Name="id" Type="Int32" />
                </UpdateParameters>
            </asp:sqldatasource>
        </div>
    </form>
</body>
</html>
