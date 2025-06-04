<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="Web.ImportData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="../../Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="images/uploadify.css" />

    <script type="text/javascript">
        function Upload_openBrowse() {
            var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;
            if (ie) {
                document.getElementById("FileUpload1").click();     // 通过document元素点击FileUpload控件
            }
            else {
                var a = document.createEvent("MouseEvents");//FF的处理 
                a.initEvent("click", true, true);
                document.getElementById("FileUpload1").dispatchEvent(a);
                document.getElementById("txrearchID").value = document.getElementById("FileUpload1").value;
            }
            document.getElementById("txrearchID").value = document.getElementById("FileUpload1").value;

        }
        function CheckLogin() {
            var mymessage = confirm("确认上传服务中心吗?");
            if (mymessage == true) {
                return true

            }
            else {
                return false

            }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<iframe id="ifrMain" name="ifrMain" frameborder="0" scrolling="no" src="/frmNav.aspx" style="height: 21%; visibility: inherit; width: 100%; z-index: 1;"></iframe>--%>

        <table>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <tr class="upload_tr">
                <br />
                <br />
                <th class="upload_tr">请选择上传文件*</th>
                <td class="upload_tr1">
                    <asp:TextBox ID="txrearchID" runat="server" class="select_w150" Height="20px" Width="310px"></asp:TextBox>
                </td>

                <td width="10%">
                    <%--<input type="button" class="uploadify-button" name="button" value="..." onclick="javascript: Upload_openBrowse();" />--%>
                    <asp:Button ID="button" class="uploadify-button" runat="server" OnClientClick="Upload_openBrowse()" Text="..." />

                </td>
            </tr>
            <div>
            </div>
            <tr>

                <td align="center" colspan="4" class="upload_bt">
                    <br />
                    &nbsp;
                    <asp:Button ID="btsearch" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                        onmouseout="this.className='button'" runat="server" Text="开始导入" Width="27%" Height="30px" OnClick="UploadButton_Click" OnClientClick="return CheckLogin()" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                        onmouseout="this.className='button'" runat="server" Text="取消" Width="27%" Height="30px" OnClick="vcButton_Click" />

                </td>

            </tr>

            <tr>
            </tr>
        </table>

        <table border="0">
            <tr>
                <td align="center" colspan="1">
                    <br />
                    <asp:Label ID="Label1" runat="server">
                             <%=alterinfo%>
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <%--Width="90%"--%>
                    <div style="width: 100%; height: 300px; overflow: auto;">
                        <asp:GridView ID="gvList" runat="server" Width="90%" AutoGenerateColumns="False"
                            CssClass="mGrid" align="center"
                            CellPadding="0" Style="margin-top: 5px;" GridLines="Vertical"
                            EmptyDataText="&lt;span class='ui-icon ui-icon-remind' style='float: left; margin-right: .3em;'&gt;&lt;/span&gt;&lt;strong&gt;提醒：&lt;/strong&gt;对不起！您所查询的数据不存在。" OnRowCommand="GridView_OnRowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" ViewStateMode="Disabled" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView_RowDataBound" OnDataBound="GridView1_DataBound">

                            <HeaderStyle BackColor="#EDEDED" Height="26px" />
                            <Columns>
                                <asp:BoundField HeaderText="商户编号" DataField="shangpinbianhao">
                                    <%--dengluzhanghao--%>
                                    <%--<FooterStyle HorizontalAlign="Left" />--%>
                                    <ControlStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="注册名称" DataField="zhucemingcheng">
                                    <%--denglumima--%>
                                    <ControlStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="经营名称" DataField="jingyingmingcheng" Visible="True">

                                    <ControlStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="所属机构" DataField="suoshujigou">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="交易类型" DataField="jiaoyileixing">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="交易状态" DataField="jiaoyizhuangtai">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="交易金额" DataField="jiaoyijine">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="交易手续费" DataField="jiaoyishouxufei">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="交易附加手续费" DataField="jiaoyifujiashouxufei" SortExpression="commentContent">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField HeaderText="交易时间" DataField="jiaoyishijian">
                                    <%--suoshujigou--%>
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderText="检索参考号" DataField="jiansuocankaohao" Visible="True">
                                    <ControlStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="Button" Text="删除" HeaderText="删除" CommandName="Btn_Operation">
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
                                <asp:CommandField HeaderText="编辑" ShowEditButton="True">
                                    <ControlStyle Font-Bold="True" Width="50px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:ButtonField ButtonType="Button" Text="查看" HeaderText="查看图片" CommandName="Btn_View">
                                    <ControlStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
