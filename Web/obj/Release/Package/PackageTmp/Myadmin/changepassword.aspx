<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Web.Myadmin.changepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />

    <script src="/Myadmin/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Myadmin/js/json2.js" type="text/javascript"></script>
    <title>修改密码</title>
</head>
<body class="trbackcolor">
    <div class="headerContainer">
        <div class="logo">
            <a href="http://www.yhocn.com" target="_blank">
                <img src="/Myadmin/images/top_bg.jpg" alt="Logo" style="width: 100%" height="40px" title="管理系统" />
            </a>
        </div>
        <hr />
        <div class="pageOperation"><a href="/Myadmin/login.aspx" target="_blank">网站首页</a> &nbsp;| &nbsp;<a href="/Myadmin/changepassword.aspx" target="_blank">密码修改</a> &nbsp;| &nbsp;<a href="logout.aspx">退出登录</a> </div>

    </div>
    <form id="form1" runat="server">
        <div>
            <div>
                <br />
                <span style="float: left">当前位置： 用户管理>修改密码</span>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tbody>
                        <%--style="padding-left: 150px;"--%>
                        <tr>
                            <th width="30%" class="textfield1">登录帐号*</th>
                            <td>
                                <asp:TextBox ID="textBox6" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%"class="textfield1">登录密码*</th>
                            <td>
                                <asp:TextBox ID="textBox5" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%" class="textfield1">确认密码*</th>
                            <td>
                                <asp:TextBox ID="textBox4" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%" class="textfield1">密保*</th>
                            <td>
                                <asp:TextBox ID="textBox1" runat="server" Height="30px" Width="60%"></asp:TextBox>
                            </td>
                        </tr>


                    </tbody>
                </table>
                <br />
                <br />
                <table cellpadding="0" cellspacing="0" border="0" width="100%">

                    <tr>
                        <td align="center" colspan="5">
                            <div>
                                <asp:Button ID="button1" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                    onmouseout="this.className='button'" runat="server" Text="更新" OnClick="Button1_Click" Width="10%" Height="30px" />
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="button2" class="button" onmouseover="this.className='ui-btn ui-btn-reset-hover'"
                                        onmouseout="this.className='button'" runat="server" Text="清空" OnClientClick="reSet();return false;" Width="10%" Height="30px" OnClick="button2_Click" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <br />
                            <asp:Label ID="Label1" runat="server">
                             <%=alterinfo1%>
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

        </div>


    </form>
</body>
</html>
