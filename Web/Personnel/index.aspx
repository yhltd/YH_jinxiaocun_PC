<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.Personnel.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Myadmin/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Myadmin/js/index.js"></script>
    <title></title>
</head>
<script lang="script">
    function a() {
        window.open('page.html', 'newwindow', 'height=100,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')
    }
</script>
<body>
    <div>
        <iframe id="Iframe1" class="Iframe1" name="ifrMain" frameborder="0" scrolling="no" src="../Personnel/head.aspx" style="height: 21%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
    </div>
    <form id="form1" runat="server">
        <div class="firstdiv">
             
        </div>
        <div class="div_iframe">
            <iframe id="Iframe2" class="Iframe" name="ifrMain" src="" ></iframe>
        </div>
        </form>
</body>
</html>

