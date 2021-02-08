<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_jxc.aspx.cs" Inherits="Web.test_jxc" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="jxc_load">
            </asp:DropDownList>

            <table border="1" class="biao_ge" name="bg_row" style="margin-top: 8%; margin-left: 12%;">
                <tr id="dj_yh">
                    <td class="bk_bt">商品代码</td>
                    <td class="bk_bt">商品名称</td>
                    <td class="bk_bt">商品类别</td>
                    <td class="bk_bt">数量</td>
                    <td class="bk_bt">单价</td>
                    <td class="bk_bt">金额</td>
                </tr>
                <%
               
                    List<jxc_z_info> jxc_z_info11 = Session["jxc_z_info11"] as List<jxc_z_info>;

                    for (int i = 0; i < jxc_z_info11.Count; i++)
                    {                          
                %>
                <tr id="Tr1">
                    <td class="bk_nr"><%=jxc_z_info11[i].ID %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Sp_dm %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Name %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Lei_bie %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Cpsl_1 %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Cpsj_1 %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Cpsl_2 %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Cpsj_2 %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Cpsl_3 %></td>
                    <td class="bk_nr"><%=jxc_z_info11[i].Cpsj_3 %></td>
                </tr>
                <%
                 
                    }
                %>
            </table>
        </div>
    </form>
</body>
</html>
