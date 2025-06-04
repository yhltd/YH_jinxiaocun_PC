<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yejiguanli.aspx.cs" Inherits="Web.yejiguanli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="images/uploadify.css" />
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <link href="images/style.css" rel="stylesheet" type="text/css">
    <link href="images/account.css" rel="stylesheet" type="text/css">

    <script src="/Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function tuanti() {
            var d = document.getElementById("hea");
            d.style.backgroundColor = "red";
        }
        function geren() {
            var d = document.getElementById("button1");
            d.style.backgroundColor = "red";
        }
    </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="leftNav1">
                <td align="center" colspan="5">
                    <div class="headerlist" id="hea">
                        <asp:Button ID="button2" class="buttonheader" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                            onmouseout="this.className='buttonheader'" runat="server" Text="个 人" Width="10%" Height="30px" OnClick="btgeren" />
                        <asp:Button ID="button1" class="buttonheader" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                            onmouseout="this.className='buttonheader'" runat="server" Text="团 体" Width="10%" Height="30px" OnClick="bttuan" OnClientClick="tuanti()" />

                        <%--<asp:Button ID="button4" class="buttonheader"  runat="server" Text="团 体" Width="10%" Height="30px"  OnClientClick="tuanti()" />--%>
                    </div>
                </td>

            </div>

            <div class="rightContentfrmain">
                <b>当前模式：</b>
                <asp:Label ID="Label1" runat="server">
                             <%=alterinfo%>
                </asp:Label>

                <table style="width: 100%;" cellpadding="4" cellspacing="5" class="border">
                    <tr>
                        <%--     
                        <td class="tdbg" >
                           </td>--%>
                        <td style="width: 80px" align="right" class="textfield1">
                            <b>关键字：</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <b class="textfield1">开始日期：</b>
                            <asp:TextBox ID="txtCompletionTime" runat="server"
                                Height="20px" class="select_w150" onClick="WdatePicker()"></asp:TextBox>
                            <b class="textfield1">结束日期：</b>
                            <asp:TextBox ID="TextBox1" runat="server"
                                Height="20px" class="select_w150" onClick="WdatePicker()"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" class="button" Height="25px" Text="查询" OnClick="btnSearch_Click"></asp:Button>
                            <asp:Button ID="Button3" runat="server" class="button" Height="25px" Text="重置" OnClick="btnclearClick"></asp:Button>

                        </td>

                        <%-- <td class="tdbg"></td>--%>
                    </tr>

                </table>
                <br />
                <br />
                <div class="setup_box" style="margin-bottom: 0">
                    <div class="h_title">
                        <h4>个人月份统计</h4>
                    </div>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td height="25" width="30%" align="right" class="table_left">交易金额：
	：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtDocumentNumber" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right" class="table_left">交易手续费：
	：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtDocumentDescription" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                    <div class="h_title">
                        <h4>团体月份统计</h4>
                    </div>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td height="25" width="30%" align="right" class="table_left">交易金额：
	：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right" class="table_left">交易手续费：
	：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--start -->
                <!--startprint-->
                <table id="Nav_profile_whish" class="app_table">
                    <tbody>
                        <tr bgcolor="#D9DDE9">
                            <td width="20" height="25" align='center' nowrap><strong>ID</strong></td>
                            <td align='center' nowrap><strong>商户编号</strong></font></td>
                            <td width="5%" align='center' nowrap><strong>注册名称</strong></td>
                            <td width="5%" align='center' nowrap><strong>经营名称</strong></td>
                            <td width="5%" align='center' nowrap><strong>所属机构</strong></td>
                            <td width="5%" align='center' nowrap><strong>交易类型</strong></td>
                            <td align='center' nowrap><strong>交易状态</strong></td>
                            <td align='center' nowrap><strong>交易金额</strong></td>
                            <td align='center' nowrap><strong>交易手续费</strong></td>
                            <td align='center' nowrap><strong>交易附加手续费</strong></td>
                            <td align='center' nowrap><strong>交易时间</strong></td>
                            <td align='center' nowrap><strong>检索参考号</strong></td>

                        </tr>
                        <% NewsList();%>
                    </tbody>
                </table>

            </div>

        </div>
    </form>
</body>
</html>
