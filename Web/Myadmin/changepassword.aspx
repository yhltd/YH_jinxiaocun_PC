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
         .table_tr
        {
            display: flex;
            height: 60px;
            align-items: center;
            justify-content: center;
        }
        .table_text
        {
            text-align: right;
            width: 20%;
            
        }
        .table_input
        {
            width: 200px;
            height: 35px;
            border: 1px solid #eee;
            padding-left: 20px;
            border-radius: 3px;
        }
        .go
        {
            height: 40px;
            width: 100px;
            background-color: #009688;
            border: none;
            color: white;
            border-radius: 3px;
            box-shadow: 2px 2px 5px black;
            padding:0;
            cursor: pointer;
        }
        .go:active
        {
            height: 40px;
            width: 100px;
            background-color: #03685F;
            border: none;
            color: white;
            border-radius: 3px;
            padding:0;
            box-shadow: 2px 2px 5px black;
            cursor: pointer;
        }
       
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />

    <script src="/Myadmin/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Myadmin/js/json2.js" type="text/javascript"></script>
</head>
<body class="trbackcolor">
    <form id="form1" runat="server">
        <div>
            <div>
                <table cellpadding="0" cellspacing="0" border="0" width="83%" style="margin:auto;margin-top:10%">
                    <tbody>
                        <tr class="table_tr">
                            <td class="table_text">登录账号：</td>
                            <td>
                                <asp:TextBox ID="textBox6" autocomplete="off" runat="server" CssClass="table_input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="table_tr">
                            <td class="table_text">登录密码：</td>
                            <td>
                                <asp:TextBox ID="textBox5" autocomplete="off" runat="server" CssClass="table_input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="table_tr">
                            <td class="table_text">确认密码：</td>
                            <td>
                                <asp:TextBox ID="textBox4" autocomplete="off" runat="server" CssClass="table_input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="table_tr">
                            <td class="table_text">密保：</td>
                            <td>
                                <asp:TextBox ID="textBox1" autocomplete="off" runat="server" CssClass="table_input"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="table_tr">
                            <td>
                                <asp:Button ID="button1" CssClass="go" runat="server" Text="更新" OnClick="Button1_Click"/>
                            </td>

                        </tr>
                    </tbody>
                </table>
            </div>

        </div>


    </form>
</body>
</html>
