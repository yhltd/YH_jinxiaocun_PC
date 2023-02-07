<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ReportForm.aspx.cs" Inherits="Web.RDLC.frm_ReportForm" %>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sp_rc_ku_select_dayin.aspx.cs" Inherits="Web.RDLC.sp_rc_ku_select_dayin" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%><%----引用程序--%><%--<rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="1000px" Width="1000px">
    <LocalReport ReportPath="Report1.rdlc">
    </LocalReport>
</rsweb:ReportViewer>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">--%>
            <asp:ScriptManager runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer3" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="1000px" Width="1000px">
                <LocalReport ReportPath="Report3.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
            <%--   --页面显示控件--%>
        </div>
    </form>

</body>
</html>
