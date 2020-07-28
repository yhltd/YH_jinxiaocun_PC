<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quanxian.aspx.cs" Inherits="Web.Personnel.quanxian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/quanxian.css" rel="stylesheet" type="text/css" />
    <link href="css/gridview.css" rel="stylesheet" type="text/css" />
    <title></title>
<script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>

<script>
    $("#Button1").click(function () {
        $("#Button1").css('background-color','black');
    });
</script>
    <style type="text/css">
        .add {
            background-color:black;
        }
        #Button13 {
        }
        #Button14 {
            width: 235px;
        }
        #Button15 {
            height: 107px;
            width: 235px;
        }
        #Button16 {
            height: 107px;
            width: 235px;
        }
        #Button17 {
            height: 107px;
            width: 235px;
        }
        #Button14 {
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="first">
        <div class="two">
            <asp:Button ID="Button1" runat="server" Text="考勤表" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="添加"></asp:Label>
            <asp:CheckBox ID="CheckBox1" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox2" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox3" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox4" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox5" runat="server" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="人员信息管理" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="添加"></asp:Label>
            <asp:CheckBox ID="CheckBox6" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox7" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox8" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox9" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox10" runat="server" />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="报盘" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox11" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label12" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox12" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label13" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox13" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label14" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox14" runat="server" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="配置表" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label15" runat="server" Text="添加"></asp:Label>
            <asp:CheckBox ID="CheckBox15" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label16" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox16" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label17" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox17" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label18" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox18" runat="server" />
            <br />
            <asp:Button ID="Button5" runat="server" Text="工资明细" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label19" runat="server" Text="添加"></asp:Label>
            <asp:CheckBox ID="CheckBox19" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label20" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox20" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label21" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox21" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label22" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox22" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label23" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox23" runat="server" />
            <br />
            <asp:Button ID="Button6" runat="server" Text="报税" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label24" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox24" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label25" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox25" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label26" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox26" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label27" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox27" runat="server" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="考勤记录" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label28" runat="server" Text="添加"></asp:Label>
            <asp:CheckBox ID="CheckBox28" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label29" runat="server" Text="删除"></asp:Label>
            <asp:CheckBox ID="CheckBox29" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label30" runat="server" Text="修改"></asp:Label>
            <asp:CheckBox ID="CheckBox30" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label31" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox31" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label32" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox32" runat="server" />
            <br />
            <asp:Button ID="Button8" runat="server" Text="部门汇总" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label33" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox33" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label34" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox34" runat="server" />
            <br />
            <asp:Button ID="Button9" runat="server" Text="社保" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label35" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox35" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label36" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox36" runat="server" />
            <br />
            <asp:Button ID="Button10" runat="server" Text="个人信息" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label37" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox37" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label38" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox38" runat="server" />
            <br />
            <asp:Button ID="Button11" runat="server" Text="个人所得税" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label39" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox39" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label40" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox40" runat="server" />
            <br />
            <asp:Button ID="Button12" runat="server" Text="工资条" Height="40px" Width="200px" CssClass="qx" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label41" runat="server" Text="搜索"></asp:Label>
            <asp:CheckBox ID="CheckBox41" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label42" runat="server" Text="查看"></asp:Label>
            <asp:CheckBox ID="CheckBox42" runat="server" />
            <br />
            <div style="margin-left:40%;">
            <asp:Button ID="Button13" runat="server" Height="30px" OnClick="Button13_Click"  CssClass="top_bt" Text="确认" Width="80px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button14" runat="server" Height="30px"   CssClass="top_bt"  Text="返回" Width="80px" OnClick="Button14_Click1" />
            </div>
            </div>
    </div>
    </form>
</body>
</html>
