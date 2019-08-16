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
                <th class="upload_tr">请选择文件*</th>
                <td class="upload_tr1">
                    <asp:TextBox ID="txrearchID" runat="server" class="select_w150" Height="20px" Width="310px"></asp:TextBox>
                </td>

                <td width="10%">
                    <input type="button" class="uploadify-button" name="button" value="..." onclick="javascript: Upload_openBrowse();" />
                </td>
            </tr>
            <div>
            </div>
            <tr>

                <td align="center" colspan="4" class="upload_bt">
                    <br />
                      &nbsp;
                    <asp:Button ID="btsearch" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                        onmouseout="this.className='button'" runat="server" Text="开始导入" Width="27%" Height="30px" OnClick="UploadButton_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button1" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                        onmouseout="this.className='button'" runat="server" Text="取消" Width="27%" Height="30px" OnClick="vcButton_Click" />

                </td>

            </tr>

        </table>
    </form>
</body>
</html>
