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
        function yjgl_tz() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "yejiguanli.aspx";
        }
        function ru_ku() {
            //alert(sds0)

        }
        //function chu_ku() {
        //    //alert(sds0)
        //    window.parent.document.getElementById("Iframe1").src = "chu_ku.aspx";
        //}



        //function rk_id_ff() {
        //    //alert(sds0)
        //    window.parent.document.getElementById("Iframe1").src = "ru_ku.aspx";
        //}


        function ck_id_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "chu_ku.aspx";
        }

        //function qi_chu_ff() {
        //    //alert(sds0)
        //    window.parent.document.getElementById("Iframe1").src = "qi_chu.aspx";
        //}

        function jin_xiao_cun_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "jin_xiao_cun.aspx";
        }
        function sp_rc_ru_select_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "sp_rc_ru_select_page.aspx";
        }
        function kh_ming_xi_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "kh_ming_xi_selcet.aspx";
        }
        function yl_set_page_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "yl_set_page.aspx";
        }
        function ji_chu_zi_liao_page_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "ji_chu_zi_liao_page.aspx";
        }
        function zheng_li_page_ff() {
            //alert(sds0)
            window.parent.document.getElementById("Iframe1").src = "zheng_li_page.aspx";
        }



    </script>

    <script src="Myadmin/js/jquery-1.7.1.min.js"></script>
    <script>

        var a = 0;
        var li_count = 0;
        var mycars = new Array(8);
        var id_ary = new Array(8);
        function add_li(ff, row, tz_lj, id, xb) {
            id_ary[xb] = id;
            if (row == mycars[xb]) {
                for (var i = 0; i < id_ary.length; i++) {
                    if (id_ary[i] == null) {

                    } else {
                        document.getElementById(id_ary[i]).style.background = "#e0ecff";
                    }
                }
                document.getElementById(id).style.background = "#b8d9fc";
                window.parent.document.getElementById("Iframe1").src = tz_lj;
            }
            else {
                window.parent.document.getElementById("Iframe1").src = tz_lj;
                $("#ul_tj").append("<li id='" + id + "' class='bj_ys'><a href='#'  id='" + id + "'  onclick='" + ff + "'  class='a_lj' >" + row + "</a></li>");
                for (var i = 0; i < id_ary.length; i++) {
                    if (id_ary[i] == null) {
                    } else {
                        document.getElementById(id_ary[i]).style.background = "#e0ecff";
                    }
                }
                document.getElementById(id).style.background = "#b8d9fc";
                mycars[xb] = row;
            }
            li_count++;
        }
        function chu_ku_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }

            document.getElementById("chu_ku_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "chu_ku.aspx";
        }

        function rk_id_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("ru_ku_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "ru_ku.aspx";
        }

        function qi_chu_ff() {
            //alert(sds0)
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("qi_chu_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "qi_chu.aspx";
        }

        function ming_xi_ff() {
            //alert(sds0)
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("ming_xi_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "ming_xi.aspx";
        }

        function jin_xiao_cun_ff() {
            //alert(sds0)
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("jin_xiao_cun_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "jin_xiao_cun.aspx";
        }

        function sp_rc_ru_select_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("sp_rc_ru_select_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "sp_rc_ku_select.aspx";
        }

        function kh_ming_xi_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("kh_ming_xi_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "kh_ming_xi_selcet.aspx";
        }

        function yl_set_page_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("yl_set_page_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "yl_set_page.aspx";
        }

        function ji_chu_zi_liao_page_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("ji_chu_zi_liao_page_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "ji_chu_zi_liao_page.aspx";
        }

        function zheng_li_page_ff() {
            for (var i = 0; i < id_ary.length; i++) {
                if (id_ary[i] == null) {

                } else {
                    document.getElementById(id_ary[i]).style.background = "#e0ecff";
                }
            }
            document.getElementById("zheng_li_page_id").style.background = "#b8d9fc";
            window.parent.document.getElementById("Iframe1").src = "zheng_li_page.aspx";
        }

    </script>

    <style type="text/css">
        #ul_tj li {
            float: left;
            margin-right: 0.1%;
            background-color: #e0ecff;
            width: 98px;
            height: 31px;
            border-radius: 11px 11px 32px 5px;
        }

        .a_lj {
            color: white;
            font-size: 118%;
            position: relative;
            left: 6%;
            top: 17%;
        }
    </style>

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
                <div class="leftNav" style="background-color: #e0ecff;">
                    <ul>
                        <li><a id="Nav_begin" style="font-weight: bold; font-size: 18px;" class="leftNav_li" href="senior.asp">信息导航</a></li>
                        <li><span class="leftNav_block"></span></li>
<%--                        <li><a href="#" class="leftNav_li" onclick="add_li('yjgl_tz()','业绩管理','yejiguanli.aspx')">业绩管理</a></li>--%>
                        <%--add_li('yjgl_tz','业绩管理','yejiguanli.aspx'     function add_li(ff, row, tz_lj) {)--%>
                        <%--       <li><a href="statelist.asp#Nav_profile_image" class="leftNav_li">团队管理</a></li>
                        <li><a href="UserPassUp.asp" class="leftNav_li">商户管理</a></li>
                        <li><a href="UserPassUp.asp" class="leftNav_li">分润中心</a></li>
                        <li><a href="#" id="abc" class="leftNav_li" onclick="changeurl()">管理中心</a></li>      --%>
                        <li><a href="#" id="r_k" class="leftNav_li" onclick="add_li('rk_id_ff()','入库单','ru_ku.aspx','ru_ku_id','0')"><%--<img style="height:50px;width:50px;" src="Myadmin/images/ru_tm.png"/>--%>入库</a></li>
                        <li><a href="#" id="A1" class="leftNav_li" onclick="add_li('chu_ku_ff()','出库单','chu_ku.aspx','chu_ku_id','1')">出库</a></li>
                        <li><a href="#" id="A2" class="leftNav_li" onclick="add_li('qi_chu_ff()','期初数','qi_chu.aspx','qi_chu_id','2')">期初数</a></li>
                        <li><a href="#" id="A3" class="leftNav_li" onclick="add_li('ming_xi_ff()','明细','ming_xi.aspx','ming_xi_id','3')">明细</a></li>
                        <li><a href="#" id="A4" class="leftNav_li" onclick="add_li('jin_xiao_cun_ff()','进销存','jin_xiao_cun.aspx','jin_xiao_cun_id','4')">进销存</a></li>
                        <li><a href="#" id="A10" class="leftNav_li" onclick="add_li('sp_rc_ru_select_ff()','商品进出查询','sp_rc_ku_select.aspx','sp_rc_ru_select_id','5')">商品进出查询</a></li>
                        <li><a href="#" id="A11" class="leftNav_li" onclick="add_li('kh_ming_xi_ff()','客户出货查询','kh_ming_xi_selcet.aspx','kh_ming_xi_id','6')">客户出货查询</a></li>
                        <li><a href="#" id="A7" class="leftNav_li" onclick="add_li('yl_set_page_ff()','用料基础设定','yl_set_page.aspx','yl_set_page_id','7')">用料基础设定</a></li>
                        <li><a href="#" id="A8" class="leftNav_li" onclick="add_li('ji_chu_zi_liao_page_ff()','基础资料','ji_chu_zi_liao_page.aspx','ji_chu_zi_liao_page_id','8')">基础资料</a></li>
                        <li><a href="#" id="A9" class="leftNav_li" onclick="add_li('zheng_li_page_ff()','整理','zheng_li_page.aspx','zheng_li_page_id','9')">整理</a></li>
                        <%--        <li><a href="#" id="A5" class="leftNav_li" onclick="add_li('jin_xiao_cun_ff()','进销存','jin_xiao_cun.aspx','jin_xiao_cun_id')">进销存</a></li>--%>
                        <span id="show_hide_app" style="display: &#39; none &#39;"></span>
                    </ul>
                </div>

                <div class="rightContentfrmain">
                    <!--start -->
                    <!--startprint-->
                    <iframe id="Iframe1" name="ifrMain" frameborder="0" scrolling="yes" src="/ru_ku.aspx" style="height: 100%; visibility: inherit; width: 90%; z-index: 1; margin-top: 0%;"></iframe>
                    <%--  <input  id="k_y_g" type="text" value="1"/>
                    <input  id="k_y_g1" type="text" value="1"/>--%>
                    <ul style="margin-top: -35%; list-style: none" id="ul_tj">
                    </ul>
                   

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
