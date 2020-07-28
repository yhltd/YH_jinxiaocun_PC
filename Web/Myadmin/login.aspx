<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="inc/logincss.css" rel="stylesheet" type="text/css" />
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />

    <script language="JavaScript">
        function CheckLogin() {
            if (document.MyForm.username.value == "") {
                alert("请输入用户名再提交！");
                document.MyForm.username.focus();
                return false
            }
            if (document.MyForm.password.value == "") {
                alert("请输入密码再提交！");
                document.MyForm.password.focus()
                return false

            }

        }

        //$(document).ready(function () {

        //    $('select').addClass("form-control");

        //});
        //$(document).ready(function () {

        //});

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 227px;
        }

        .select {
            /*position: absolute;*/
            width: 100%;
            height: 100%;
            padding: 0 24px 0 8px;
            color: #fff;
            font: 12px/21px arial,sans-serif;
            background: url(select.png) no-repeat; /*span背景图片，其实就是dropdownlist图片*/
            overflow: hidden;
            top: 0px;
            left: 0px;
        }

        </style>
</head>

<body>
    <div class="mains">
        <div class="inners">
            <p>
                <span style="font-size: 12pt"  align="left" class="font_gray"><%=version%></span>

            </p>
            <div class="lefts">

                <p align="left" class="pname">
                    <b><span style="font-size: 38pt">云和未来-进销存</span></b>
                </p>
            </div>

            <div class="login">
                <form name="MyForm" id="MyForm" runat="server">
                    <%--<form action="admin_login.asp" method="post" name="MyForm" id="Form1" runat="server" >--%>
                    <div class="dbweizhi">
                        <table id="Table1">
                        </table>
                    </div>
                    <input type="hidden" value="chklogin" name="reaction">

                    <div class="center">
                        <div class="inner">
                            <%--     &nbsp;<p>&nbsp;</p>--%>
                            <%--         <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>
                            <p>&nbsp;</p>--%>
                            <table cellpadding="0" cellspacing="0" id="innnertalbe">
                                <tr>
                                    <td height="60">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">数据库：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Style="color: wheat; background-color: black" class="select_w150" DataSourceID="SqlDataSource1" DataTextField="systemName" DataValueField="systemName" AutoPostBack="true" OnSelectedIndexChanged="bian"></asp:DropDownList>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bds28428944_dbConnectionString %>" SelectCommand="SELECT [systemName] FROM [all_systems]"></asp:SqlDataSource>

                                    </td>
                                </tr>

                                 <tr>
                                    <td height="60">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">公 司 名：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="DropDownList2" runat="server" Style="color: wheat; background-color: black" class="select_w150" ></asp:DropDownList>
                                        </td>
                                </tr>

                                <tr>
                                    <td height="60">
                                        <p align="right" style="width: 81px">
                                            <b><span style="font-size: 13pt">用 户 名：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <input name="username" type="text" class="select_w150" id="username" size="16" maxlength="100" value="<%=user%>" /></td>
                                </tr>

                                <tr>
                                    <td height="60">
                                        <p align="right">
                                            <b><span style="font-size: 13pt">密&nbsp; 码：</span></b>
                                        </p>
                                    </td>
                                    <td class="auto-style1">
                                        <input name="password" type="password" class="select_w150" id="password" size="16" maxlength="100" value="<%=pass%>" /></td>
                                </tr>

                                <tr>
                                    <td height="49"></td>
                                    <td class="auto-style1">

                                        <%--<asp:Button  name="image" runat="server" type="submit" class="LoginSub" OnClientClick="CheckLogin()" onclick="CheckLogin()" value=" 登 录 " />--%>
                                        <asp:Button ID="image" runat="server" Text=" 登 录 " class="LoginSub" OnClick="HtmlBtn_Click" OnClientClick="CheckLogin()" />

                                        <asp:Button ID="btcreate" runat="server" Text=" 找回密码 " class="LoginSub" OnClick="Btchangepas_Click" Visible="true" />
                                        <br>
                                        <br>

                                        <span style="color: #4cff00;"></span>

                                    </td>

                                </tr>

                                <tr>
                                    <br>
                                    <td height="49"></td>
                                    <td class="auto-style1">
                                      <%--  <asp:Button ID="Btchangepas" runat="server" Text=" 改密 " class="LoginSub" OnClick="Btchangepas_Click" Visible="True" />
                                        <asp:Button ID="frmmain" runat="server" Text=" 主页面 " class="LoginSub" OnClick="Btmain_Click" Visible="False" />
                                        --%>
                                        <br>
                                        <span style="color: #FF0000;"></span>

                                    </td>


                                </tr>
                              <%--  <tr>
                                    <td align="center" colspan="5">
                                        <asp:Button ID="Button1" runat="server" Text=" 游客登录 " class="NOLoginSub" OnClick="HtmlNOlogin_Click" Visible="True" Width="285px" />
                                        <br />
                                        <asp:Label ID="Label1" runat="server">
                                       <%=alterinfo1%>
                                        </asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div class="clearfix"></div>

                    </div>

                </form>
            </div>

        </div>
        <div class="ui-login-footer">
            <p>
                <%--<span class="font_gray">云合未来计算机技术有限公司  © Copyright 2018-2020  技术支持：信息技术中心   联系电话：16619776280</span>--%>

            </p>
        </div>
    </div>

</body>
</html>
