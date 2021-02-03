<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Web.Myadmin.changepassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head runat="server">
    <style type="text/css">
        .text_sc {
            margin-bottom: 2%;
            padding-left:1%;
        }
         .text_mb {
            margin-bottom: 1%;
            padding-left:1%;
        }
        .text_gx {
            margin-bottom: 4%;
        }

        .button_gx {
          
            font-family: "Arail", "微软雅黑";
            font-size: 12pt;
            color: #ffffff;
            border: 0px #93bee2 solid;
            /*background-image:url(<img src="./imege/button-常态.png" />);*/
            background-color: #e2231a;
            width: 120px;
            height: 34px;
            border-radius: 3px;
            margin-left: 4%;

        }
        .button_qk {
        font-family: "Arail", "微软雅黑";
            font-size: 12pt;
            color: #ffffff;
            border: 0px #93bee2 solid;
            /*background-image:url(<img src="./imege/button-常态.png" />);*/
            background-color: #7AC143;
            width: 120px;
            height: 34px;
            border-radius: 3px;
           
        }
        .button_qk:hover {
            background-color:#8ee153
        
        }
         .button_gx:hover {
            background-color:#c81623
        
        }
       
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />

    <script src="/Myadmin/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Myadmin/js/json2.js" type="text/javascript"></script>
    <title>修改密码</title>
</head>
<body class="trbackcolor">
    <div class="headerContainer">
        <div class="logo">
            <a href="http://www.yhocn.cn" target="_blank">
                <img src="/Myadmin/images/top_bg.jpg" alt="Logo" style="width: 100%" height="40px" title="管理系统" />
            </a>
        </div>
        <hr />
        <div class="pageOperation"><a href="/Myadmin/login.aspx" style="margin-left: 82%;" target="_blank">网站首页</a> &nbsp;| &nbsp;<a href="/Myadmin/changepassword.aspx" target="_blank">密码修改</a> &nbsp;| &nbsp;<a href="logout.aspx">退出登录</a> </div>

    </div>
    <form id="form1" runat="server">
        <div>
            <div>
                <br />
                <span style="float: left; margin-top: -2%;margin-left: 2%;">当前位置： 用户管理>修改密码</span>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" border="0" width="83%" style="margin-left: 14.5%;margin-top: 4%;">
                    <tbody>
                        <%--style="padding-left: 150px;"--%>
                        <tr>
                            <th width="30%" class="textfield1"></th>
                            <td>
                                <asp:TextBox ID="textBox6" placeholder="登录账号" runat="server" Height="46px" Width="41%" CssClass="text_sc"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%" class="textfield1"></th>
                            <td>
                                <asp:TextBox ID="textBox5" placeholder="登录密码" runat="server" Height="46px" Width="41%" CssClass="text_sc"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%" class="textfield1"></th>
                            <td>
                                <asp:TextBox ID="textBox4" placeholder="确认密码" runat="server" Height="46px" Width="41%" CssClass="text_sc"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%" class="textfield1"></th>
                            <td>
                                <asp:TextBox ID="textBox1" placeholder="密保" runat="server" Height="46px" Width="41%" CssClass="text_mb"></asp:TextBox>
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
                               <%-- onmouseover="this.className='ui-btn ui-btn-search-hover'"    onmouseout="this.className='button_gx'"--%>
                                <asp:Button ID="button1" class="button_gx" 
                                   runat="server" Text="更新" OnClick="Button1_Click" Width="20%" Height="46px" />
                                &nbsp;&nbsp;&nbsp;
                                   <%-- <asp:Button ID="button2" class="button_qk" 
                                         runat="server" Text="清空" OnClientClick="reSet();return false;" Width="10%" Height="30px" OnClick="button2_Click" />--%>
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
