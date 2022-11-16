<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="birthday.aspx.cs" Inherits="Web.Personnel.birthday" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body style="margin: 0;">
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="../Myadmin/js/jquerysession.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#riqi').val($.session.get('riqi'));
            $.session.set('riqi', '');

            $('#Button1').click(function () {
                $.session.set('riqi', $('#riqi').val());
            })
        })

    </script>

    <h1 style="margin-top: 0px; margin-bottom: 10px">生日提醒</h1>
    <form id="form1" runat="server">
        <div>
            <asp:label id="Label1" runat="server" height="30px" text="年月：" width="80px" style="text-align: center"></asp:label>
            <input id="riqi" name="riqi" type="date" class="top_select_input" style="width:150px" />
            <%--<asp:textbox id="TextBox1" type="number" runat="server" cssclass="top_select_input" height="30px" width="150px" style="margin-right: -10px; border: 0.5px solid #378888"></asp:textbox>--%>
            
            <asp:button id="Button1" runat="server" onclick="Button1_Click" text="搜索" cssclass="top_bt" style="margin-right: -10px" height="30px" width="80px" />
            <br />
            <%-- datasourceid="SqlDataSource1" --%>
            <asp:gridview id="GridView1" runat="server" autogeneratecolumns="False"  allowpaging="False" datakeynames="id" onrowcreated="aaa">
                <Columns>
                    <asp:BoundField DataField="zhouyi" HeaderText="周一" SortExpression="zhouyi"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="zhouer" HeaderText="周二" SortExpression="zhouer"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="zhousan" HeaderText="周三" SortExpression="zhousan" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="zhousi" HeaderText="周四" SortExpression="zhousi" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="zhouwu" HeaderText="周五" SortExpression="zhouwu"  ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="zhouliu" HeaderText="周六" SortExpression="zhouliu" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                    <asp:BoundField DataField="zhouri" HeaderText="周日" SortExpression="zhouri" ControlStyle-Width="80%" HeaderStyle-Font-Bold="true"/>
                </Columns>
                <HeaderStyle CssClass="header" Font-Bold="False" BorderStyle="None" />
                <RowStyle CssClass="item" BorderStyle="None" Wrap="False" Height="48px" />
                <SelectedRowStyle CssClass="header" />
            </asp:gridview>
        </div>
    </form>
</body>
</html>
