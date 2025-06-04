<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 52px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="query_form">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="ui-table">

                    <tbody>
                        <tr>
                            <th width="10%" align="right" class="auto-style1">
                                <asp:Label ID="lblStatTime" runat="server" Text="起始时间"></asp:Label>
                            </th>
                            <td class="auto-style1">
                                <asp:TextBox ID="dtStartTime" runat="server" IsMustInput="false" CssClass="form_select_fill" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5">
                                <div>
                                    <asp:Button ID="Button1" class="ui-btn ui-btn-search" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                        onmouseout="this.className='ui-btn ui-btn-search'" runat="server" Text="查询" OnClick="Button1_Click"  width="20%"/>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button2" class="ui-btn ui-btn-reset" onmouseover="this.className='ui-btn ui-btn-reset-hover'"
                                        onmouseout="this.className='ui-btn ui-btn-reset'" runat="server" Text="重置" OnClientClick="reSet();return false;" width="20%" />
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <asp:GridView ID="gvList" runat="server" Width="100%" AutoGenerateColumns="False"
                CssClass="ui-datalist-view"
                CellPadding="0" Style="margin-top: 5px;" GridLines="None"
                EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。"
                EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                     <%--   <ItemTemplate>
                            <input type="hidden" id="hdfDetailID" runat="server" value='<%#Eval("EXAM_DETAIL_ID") %>' />
                        </ItemTemplate>--%>
                        <ItemStyle HorizontalAlign="Center" Width="0%"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="工会小组" DataField="ORG_NAME">
                        <%--<FooterStyle HorizontalAlign="Left" />--%>
                        <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderText="费用总额(元)" DataField="TOTAL_EXPENSENS">
                        <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                    </asp:BoundField>
               
                </Columns>
            </asp:GridView>





        </div>
    </form>
</body>
</html>
