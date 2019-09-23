<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUserManger.aspx.cs" Inherits="Web.frmUserManger" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="trbackcolor">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户管理</title>
    <link href="/Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Myadmin/css/common.css" type="text/css" />
  <%--  <br />
    <a href="#" onclick="nvhome();" id="aa">

        <input type="text" size="40" style="font-size: 16pt; border-style: none" class="trbackcolor" value="      当前位置：用户管理>新建用户" />
    </a>--%>
    <script src="/Myadmin/js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="/Myadmin/js/json2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function nvhome() {
            window.location.href = "/Myadmin/login.aspx";
        }
    </script>


</head>
<body class="trbackcolor" style="background-color:#ffffff">
    <div class="headerContainer">
        <div class="logo">
            <a href="http://www.yhocn.com" target="_blank">
                <img src="/Myadmin/images/top_bg.jpg" alt="Logo" style="width: 100%" height="40px" title="管理系统" />
            </a>
        </div>
        <hr />
        <%--<div class="pageOperation"><a href="/Myadmin/login.aspx" target="_blank">网站首页</a> &nbsp;| &nbsp;<a href="/Myadmin/changepassword.aspx" target="_blank">密码修改</a> &nbsp;| &nbsp;<a href="/Myadmin/logout.aspx">退出登录</a> </div>--%>
       <iframe id="ifrMain" name="ifrMain" frameborder="0" scrolling="no" src="/frmNav.aspx" style="height: 21%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
      
    </div>
    <form id="form1" runat="server">
        <div>
            <div>
                <%--`<span style="float: left">当前位置： 用户管理>新建</span>--%>
            </div>
            <br />
            <br />
            <div>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="ui-table">
                    <tbody>
                        <tr>
                            <th class="textfield1">上级机构*</th>
                            <td>
                                <asp:TextBox ID="comboBox1" runat="server" class="textfield"></asp:TextBox>
                            </td>

                        </tr>
                        &nbsp;
                        <tr>

                            <th class="textfield1">登录帐号*</th>
                            <td>
                                <asp:TextBox ID="textBox1" runat="server" class="textfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="textfield1">登录密码*</th>
                            <td>
                                <asp:TextBox ID="textBox2" runat="server" class="textfield"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <th class="textfield1">确认密码*</th>
                            <td>
                                <asp:TextBox ID="textBox3" runat="server" class="textfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="textfield1" width="30%">帐号设置*</th>
                            <td>
                                <ul>
                                    <asp:RadioButton ID="radioButton1" runat="server" Height="30px" GroupName="Sports" Text="正常"></asp:RadioButton>
                                    <asp:RadioButton ID="radioButton2" runat="server" Height="30px" GroupName="Sports" Text="锁定"></asp:RadioButton>
                                </ul>
                            </td>

                        </tr>
                        <tr>
                            <th class="textfield1" width="30%">密保问题*</th>
                            <td>
                                <asp:TextBox ID="textBox4" runat="server" Height="30px" class="textfield"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th class="textfield1" width="30%">系统管理员*</th>
                            <td>
                                <ul>
                                    <asp:CheckBox ID="checkBox1" runat="server" Height="30px" Text=""></asp:CheckBox>
                                </ul>
                            </td>
                        </tr>

                    </tbody>
                </table>
                <br />

                <table cellpadding="0" cellspacing="0" border="0" width="100%">

                    <tr>
                        <td align="center" colspan="5">
                            <div>
                                <asp:Button ID="button1" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                    onmouseout="this.className='button'" runat="server" Text="创建" OnClick="Button1_Click" Width="20%" Height="40px" />
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="button2" class="button" onmouseover="this.className='ui-btn ui-btn-reset-hover'"
                                        onmouseout="this.className='button'" runat="server" Text="清空" OnClientClick="reSet();return false;" Width="20%" Height="40px" OnClick="button2_Click" />
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <br />
                            <asp:Label ID="Label1" runat="server">
                             <%=alterinfo%>
                            </asp:Label>
                        </td>
                    </tr>
                </table>
                <tr align="center">
                    <span class="textfield2">&nbsp;&nbsp;&nbsp;用户列表</span>
                </tr>

                <asp:GridView ID="gvList" runat="server" Width="70%" AutoGenerateColumns="False"
                    CssClass="gridview_m" align="center"
                    CellPadding="0" Style="margin-top: 5px;"
                    EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。"
                    EnableModelValidation="True" OnRowCommand="GridView_OnRowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <%--   <ItemTemplate>
                            <input type="hidden" id="hdfDetailID" runat="server" value='<%#Eval("EXAM_DETAIL_ID") %>' />
                        </ItemTemplate>--%>
                            <ItemStyle HorizontalAlign="Center" Width="0%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="登录帐号" DataField="name">
                            <%--dengluzhanghao--%>
                            <%--<FooterStyle HorizontalAlign="Left" />--%>
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="登录密码" DataField="password">
                            <%--denglumima--%>
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="所属机构" DataField="jigoudaima">
                            <%--suoshujigou--%>
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                        </asp:BoundField>

                        <asp:ButtonField ButtonType="Button" Text="删除" HeaderText="删除" CommandName="Btn_Operation">
                            <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>

                        </asp:ButtonField>


                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
