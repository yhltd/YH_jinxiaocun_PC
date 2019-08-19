<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="Web.frmMain" %>--%>

<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="Web.frmMain" %>

<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="images/uploadify.css" />
    <%--<link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />--%>
    <link href="images/style.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        /*body {
            margin: 0;
            padding: 0;
        }

        form {
            margin: 0;
            padding: 0;
        }

        .leftNav {
            width: 112px;
        }

        .sidebar-menu {
            width: 129px;
        }*/
    </style>
    <script type="text/javascript">
        function changeurl() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "ImportData.aspx";                
        }
        function yejichangeurl() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "yejiguanli.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <iframe id="ifrMain" name="ifrMain" frameborder="0" scrolling="no" src="/frmNav.aspx" style="height: 21%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
        <%--  <div class="main">
            <td class="leftNav">
                <ul class="sidebar-menu">
                    <li class="treeview">
                        <a href="#">
                            <span>业绩管理
                             <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ui class="treeview-menu menu-open" style="display: block;">
                                <li>
                                    <a onclick=""></a>
                                </li>
                         </ui>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <span>团队管理
                        <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ui class="treeview-menu menu-open" style="display: block;">
                            <li>
                                <a onclick=""></a>
                            </li>
                       </ui>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <span>商户管理
                           <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ui class="treeview-menu menu-open" style="display: block;">
                                <li>
                                    <a onclick=""></a>
                                </li>
                        </ui>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <span>分润中心
                           <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ui class="treeview-menu menu-open" style="display: block;">
                            <li>
                                <a onclick=""></a>
                            </li>
                        </ui>
                    </li>
                    <li class="treeview">
                        <a href="#">
                            <span>管理中心
                        <i class="fa fa-angle-left pull-right"></i>
                            </span>

                        </a>
                        <ui class="treeview-menu menu-open" style="display: block;">
                    <li>
                        <a onclick=""></a>
                    </li>
                   </ui>
                    </li>
                </ul>
            </td>
       
     
        </div>--%>

        <%--  <div>
            <% Response.WriteFile("frmNav.aspx");%>
            </div>--%>

        <div class="main">
            <div class="mainCon1">
                <div class="leftNav">
                    <ul>
                        <li><a id="Nav_begin" class="leftNav_li" href="senior.asp">信息导航</a></li>
                        <li><span class="leftNav_block"></span></li>
                        <li><a href="#" class="leftNav_li" onclick="yejichangeurl()">业绩管理</a></li>
                        <li><a href="statelist.asp#Nav_profile_image" class="leftNav_li">团队管理</a></li>
                        <li><a href="UserPassUp.asp" class="leftNav_li">商户管理</a></li>
                        <li><a href="UserPassUp.asp" class="leftNav_li">分润中心</a></li>
                         <li><a href="#" id="abc" class="leftNav_li" onclick="changeurl()">管理中心</a></li>
                        
                        <li><a href="ru_ku.aspx" id="r_k" class="leftNav_li" onclick="r_k_ff()">入库</a></li>

                        <span id="show_hide_app" style="display: &#39; none &#39;"></span>
                    </ul>
                </div>

                <div class="rightContentfrmain">
                    <!--start -->
                    <!--startprint-->
                      <iframe id="Iframe1" name="ifrMain" frameborder="0" scrolling="yes" src="/yejiguanli.aspx" style="height: 100%; visibility: inherit; width: 100%; z-index: 1;"></iframe>
      

               <%--     <table id="Nav_profile_whish" class="app_table">
                        <tbody>
                            <tr bgcolor="#D9DDE9">
                                <td width="20" height="25" align='center' nowrap><strong>ID</strong></td>
                                <td align='center' nowrap><strong>客户</strong></font></td>
                                <td width="5%" align='center' nowrap><strong>城市</strong></td>
                                <td width="5%" align='center' nowrap><strong>电话</strong></td>
                                <td width="5%" align='center' nowrap><strong>会员</strong></td>
                                <td width="5%" align='center' nowrap><strong>地址</strong></td>
                                <td align='center' nowrap><strong>报修时间</strong></td>
                                <td align='center' nowrap><strong>维修经费</strong></td>
                                <td align='center' nowrap><strong>是否完成</strong></td>
                            </tr>
                            <% NewsList() %>
                        </tbody>
                    </table>--%>

                </div>
                <div class="clear"></div>
            </div>
        </div>
    </form>


</body>
</html>
