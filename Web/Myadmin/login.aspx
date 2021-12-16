<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Web.login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="inc/logincss.css" rel="stylesheet" type="text/css" />
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <title>云合未来一体化系统</title>
    <link rel="shortcut icon" href="../Images/yhltd.ico">

    <script language="JavaScript">
        window.onload = function () {
            var oUser = document.getElementById('username');
            var oPswd = document.getElementById('password');
            var oRemember = document.getElementById('remember');
            var oForm = document.getElementById('MyForm');

            //页面初始化时，如果帐号密码cookie存在则填充
            if (getCookie('user') && getCookie('pwd')) {
                oUser.value = getCookie('user');
                oPswd.value = getCookie('pwd');
                oRemember.checked = true;
            }
            //复选框勾选状态发生改变时，如果未勾选则清除cookie
            oRemember.onchange = function () {
                if (!this.checked) {
                    delCookie('user');
                    delCookie('pwd');
                }
            };
            //表单提交事件触发时，如果复选框是勾选状态则保存cookie
            oForm.onsubmit = function () {
                if (remember.checked) {
                    setCookie('user', oUser.value, 30); //保存帐号到cookie，有效期7天
                    setCookie('pwd', oPswd.value, 30); //保存密码到cookie，有效期7天
                }
            };

        }

        //设置cookie
        function setCookie(name, value, day) {
            var date = new Date();
            date.setDate(date.getDate() + day);
            document.cookie = name + '=' + value + ';expires=' + date;
        };
        //获取cookie
        function getCookie(name) {
            var reg = RegExp(name + '=([^;]+)');
            var arr = document.cookie.match(reg);
            if (arr) {
                return arr[1];
            } else {
                return '';
            }
        };
        //删除cookie
        function delCookie(name) {
            setCookie(name, null, -1);
        };


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
            <img src="images/companyLogo.png" height="80" style="float:left;left:20px;position:absolute;" />
            <p align="right">
                <span style="font-size: 12pt" class="font_gray"><%=version%></span>
            </p>
            <div class="lefts">
                <p align="right" class="pname">
                    <b><span style="font-size: 36pt">云和未来一体化系统</span></b>
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
                        <div class="inner" style="left:720px;position:absolute;">
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
                                        <input name="username" autocomplete="off" type="text" class="select_w150" id="username" size="16" maxlength="100" value="<%=user%>" /></td>
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
                                    <td align="center">
                                        <input name="remember" type="checkbox"  id="remember" style="margin-top: 3px;height: auto;"  />
                                    </td>
                                    <td>
                                        <p align="left">
                                            <b><span style="font-size: 13pt">30天内记住密码</span></b>
                                        </p>
                                    </td>
                                    <%--<td class="auto-style1">
                                        <input name="remember" type="checkbox" class="select_w150" id="remember" size="16" maxlength="100" /></td>
                                    <td height="60">
                                        <p align="right">
                                            <b><span style="font-size: 13pt">30天内记住密码</span></b>
                                        </p>
                                    </td>--%>
                                </tr>

                                <tr>
                                    <td height="49"></td>
                                    <td class="auto-style1">
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
            <p style="vertical-align:bottom;line-height:20px">
                <span class="font_gray">云合未来计算机技术有限公司  © Copyright 2018-2030  技术支持：信息技术中心   联系电话：16619776280</span>
                <%--辽ICP备19018259号 云合未来计算机技术有限公司 技术支持 www.yhocn.cn--%>
            </p>
            <p style="vertical-align:bottom;line-height:20px">
                <span class="font_gray">辽ICP备19018259号 云合未来计算机技术有限公司 技术支持 www.yhocn.cn</span>
            </p>
        </div>
    </div>

</body>
</html>
