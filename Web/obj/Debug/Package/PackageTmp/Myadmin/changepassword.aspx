<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Web.Myadmin.changepwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head runat="server">
    <style type="text/css">
        .text_sc {
            margin-bottom: 2%;
            border: none;
            border: 1px solid #f2f2f2;
            border-radius: 3px;
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
    <form id="form1" runat="server">
        <div>
            <div>
                <table cellpadding="0" cellspacing="0" border="0" width="83%" style="margin-left: 14.5%;margin-top: 4%;">
                    <tbody>
                        <tr>
                            <th width="30%" class="textfield1"></th>
                            <td>
                                <asp:TextBox ID="textBox5" placeholder="原密码" runat="server" Height="46px" Width="41%" CssClass="text_sc"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="30%" class="textfield1"></th>
                            <td>
                                <asp:TextBox ID="textBox4" placeholder="新密码" runat="server" Height="46px" Width="41%" CssClass="text_sc"></asp:TextBox>
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
                                <asp:Button ID="button1" class="button_gx" 
                                   runat="server" Text="更新" OnClick="Button1_Click" Width="20%" Height="46px" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

        </div>


    </form>
</body>
</html>
