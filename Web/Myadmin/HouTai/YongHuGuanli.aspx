<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YongHuGuanli.aspx.cs" Inherits="Web.Myadmin.HouTai.YongHuGuanli" %>

<!DOCTYPE html>
<html dir="ltr" lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="assets/images/favicon.png">
    <title>云和进销存 - 管理员后台</title>
    <!-- Custom CSS -->
    <link href="dist/css/style.min.css" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
</head>

<body>
    <style type="text/css">
        #BTN_ShuaXing 
        {
            /*position: relative;
            left: 48%;*/
            /*margin-top: -19%;*/
            float: right;
            margin-top: -4%;
    margin-bottom: 3%;
        }
        #BTN_Insert {
            
            /*position: relative;
            left: 82%;*/
            /*margin-top: -19%;*/
            float: right;
    margin-right: 4%;
    margin-top: -4%;
            
        }
        .btn {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            cursor:pointer;
        }
        .Cbtn {
             background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 8px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 11px;
            cursor:pointer;
        }
    </style>
<%--    <script src="../../Scripts/layer.js"> </script>--%>
    <script src="../../Scripts/layui/layui.all.js"></script>
    <script src="../../Scripts/layui/lay/modules/layer.js"></script>
    <script src="../../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" >
        
        function queren( id,gongsi )
        {

            if (!confirm("确定删除吗？")) {
                window.event.returnValue = false;
            } else
            {
                $.ajax({
                    type: "post", //要用post方式                 
                    //url: "ru_ku.aspx/selectNameAndLebie",//方法所在页面和方法名
                    url: "YongHuGuanli.aspx?act=PostUser&id=" + id +"&gongsi="+gongsi,
                    //contentType: "application/json; charset=utf-8",
                    //async: false,
                    dataType: "json",
                    data: {},
                    success: function (data) {
                        //alert("yyes")
                        //$("#sp_cplb" + row).val(data[0].leibie)
                        //$("#sp_name" + row).val(data[0].name)
                        alert(data[0].endtext)
                        history.go(0)
                    },
                    error: function (err) {
                        //alert(err.toString());
                        //alert("删除失败！")
                    }
                });

                return true;
            }
        }
        $('#BTN_DELETE').click(function () {
            var id = $(this).data("id")
            var gongsi = $(this).data("gongsi")
            queren(id, gongsi);
        })
        function upUser(id,gongsi)
        {
            //var id = $(this).data("id")
            //var gongsi = $(this).data("gongsi")
            title = '修改用户';
            url = 'InsertUser.aspx?type=update&id=' + id + '&gs=' + gongsi;
            layui.use('layer', function () {
                var layer = layui.layer;
            });
            layer.open({
                type: 2,
                title: title,
                maxmin: true,
                shadeClose: true, //点击遮罩关闭层
                area: ['623px', '454px'],
                content: url,
                scrollbar: false,
                //data: { "type": "insert" },
                success: function (layero, index) {
                    var iframeBody = document.getElementById($('.layui-layer-content').find('iframe').prop('id')).contentWindow.document.body;
                    $(".manage_location_wrap", iframeBody).appendTo(iframeBody);
                    $('.container,header,footer', iframeBody).remove();
                },
                yes: function (index) {
                    console.log(11556156);
                    shwoAddrs();
                },
                cancel: function () {
                    console.log(11556156);
                }
            })
        }
        function openZiyemian() {
            title = '添加用户';
            url = 'InsertUser.aspx?type=insert';
            layui.use('layer', function () {
                var layer = layui.layer;
            });
            layer.open({
                type: 2,
                title: title,
                maxmin: true,
                shadeClose: true, //点击遮罩关闭层
                area: ['623px', '454px'],
                content: url,
                scrollbar: false,
                //data: { "type": "insert" },
                success: function (layero, index) {
                    var iframeBody = document.getElementById($('.layui-layer-content').find('iframe').prop('id')).contentWindow.document.body;
                    $(".manage_location_wrap", iframeBody).appendTo(iframeBody);
                    $('.container,header,footer', iframeBody).remove();
                },
                yes: function (index) {
                    console.log(11556156);
                    shwoAddrs();
                },
                cancel: function () {
                    console.log(11556156);
                }
            })
        }
    </script>
    <div class="preloader">
        <div class="lds-ripple">
            <div class="lds-pos"></div>
            <div class="lds-pos"></div>
        </div>
    </div>
    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full" data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
        <header class="topbar" data-navbarbg="skin5">
            <nav class="navbar top-navbar navbar-expand-md navbar-dark">
                <div class="navbar-header" data-logobg="skin5">
                    <a class="navbar-brand" href="index.html">
                                                <b class="logo-icon">
                            <img src="../images/tm_logo.png" alt="homepage" style="width: 65px;" class="light-logo" />云合未来

                        </b>

                    </a>
                    <a class="nav-toggler waves-effect waves-light d-block d-md-none" href="javascript:void(0)"><i class="ti-menu ti-close"></i></a>
                </div>
                <div class="navbar-collapse collapse" id="navbarSupportedContent" data-navbarbg="skin5">
                 <%--   <ul class="navbar-nav float-left mr-auto">
                        <li class="nav-item search-box"> <a class="nav-link waves-effect waves-dark" href="javascript:void(0)"><i class="ti-search"></i></a>
                            <form class="app-search position-absolute">
                                <input type="text" class="form-control" placeholder="Search &amp; enter"> <a class="srh-btn"><i class="ti-close"></i></a>
                            </form>
                        </li>
                    </ul>--%>
                    <ul class="navbar-nav float-right">
                        <li class="nav-item dropdown">
<%--                            <a class="nav-link dropdown-toggle text-muted waves-effect waves-dark pro-pic" href="" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><img src="assets/images/users/1.jpg" alt="user" class="rounded-circle" width="31"></a>--%>
                       <%--     <div class="dropdown-menu dropdown-menu-right user-dd animated">
                                <a class="dropdown-item" href="javascript:void(0)"><i class="ti-user m-r-5 m-l-5"></i> My Profile</a>
                                <a class="dropdown-item" href="javascript:void(0)"><i class="ti-wallet m-r-5 m-l-5"></i> My Balance</a>
                                <a class="dropdown-item" href="javascript:void(0)"><i class="ti-email m-r-5 m-l-5"></i> Inbox</a>
                            </div>--%>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <aside class="left-sidebar" data-sidebarbg="skin6">
            <div class="scroll-sidebar">
                <nav class="sidebar-nav">
                    <ul id="sidebarnav">
                        <li>
                            <div class="user-profile d-flex no-block dropdown m-t-20">
                                <div class="user-pic"><img src="assets/images/users/1.jpg" alt="users" class="rounded-circle" width="40" /></div>
                                <div class="user-content hide-menu m-l-10">
                                    <a href="javascript:void(0)" class="" id="Userdd" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <h5 class="m-b-0 user-name font-medium"><%if (Session["username"] != null) 
                                                                                                                    {
                                                                                                                        %><%=Session["username"] %><%
                                                                                                                    } %> <i class="fa fa-angle-down"></i></h5>
                                        <span class="op-5 user-email"><%if (Session["gs_name"] != null) 
                                                                                                {
                                                                                                    %><%=Session["gs_name"] %><%
                                                                                                } %> </span>
                                    </a>

                                   <%-- <div class="dropdown-menu dropdown-menu-right" aria-labelledby="Userdd">
                                        <a class="dropdown-item" href="javascript:void(0)"><i class="ti-user m-r-5 m-l-5"></i> My Profile</a>
                                        <a class="dropdown-item" href="javascript:void(0)"><i class="ti-wallet m-r-5 m-l-5"></i> My Balance</a>
                                        <a class="dropdown-item" href="javascript:void(0)"><i class="ti-email m-r-5 m-l-5"></i> Inbox</a>
                                        <div class="dropdown-divider"></div>
                                        <a class="dropdown-item" href="javascript:void(0)"><i class="ti-settings m-r-5 m-l-5"></i> Account Setting</a>
                                        <div class="dropdown-divider"></div>
                                        <a class="dropdown-item" href="javascript:void(0)"><i class="fa fa-power-off m-r-5 m-l-5"></i> Logout</a>
                                    </div>--%>
                                </div>
                            </div>
                        </li>
                        <li class="p-15 m-t-10"><a href="javascript:void(0)" class="btn btn-block create-btn text-white no-block d-flex align-items-center"><i class="fa fa-plus-square"></i> <span class="hide-menu m-l-5">用户管理</span> </a></li>
<%--                        <li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link" href="index.html" aria-expanded="false"><i class="mdi mdi-view-dashboard"></i><span class="hide-menu">Dashboard</span></a></li>
                        <li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link" href="pages-profile.html" aria-expanded="false"><i class="mdi mdi-account-network"></i><span class="hide-menu">Profile</span></a></li>
                        <li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link" href="table-basic.html" aria-expanded="false"><i class="mdi mdi-border-all"></i><span class="hide-menu">Table</span></a></li>
                        <li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link" href="icon-material.html" aria-expanded="false"><i class="mdi mdi-face"></i><span class="hide-menu">Icon</span></a></li>
                        <li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link" href="starter-kit.html" aria-expanded="false"><i class="mdi mdi-file"></i><span class="hide-menu">Blank</span></a></li>
                        <li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link" href="error-404.html" aria-expanded="false"><i class="mdi mdi-alert-outline"></i><span class="hide-menu">404</span></a></li>--%>
                        <li class="text-center p-40 upgrade-btn">
<%--                            <a href="#" class="btn btn-block btn-danger text-white" >Upgrade to Pro</a>--%>
                        </li>
                    </ul>
                    
                </nav>
            </div>
        </aside>
        <div class="page-wrapper">
            <div class="page-breadcrumb">
                <div class="row align-items-center">
                    <div class="col-5">
                        <h4 class="page-title">用户管理</h4>
                        <div class="d-flex align-items-center">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="#">主页面</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">用户管理</li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                              <form id="formtable" runat="server" >
                                <h4 class="card-title">用户Table</h4>
                                <h6 class="card-title m-t-40"><asp:Button id="BTN_ShuaXing" Text="刷新" CssClass="btn"  runat="server" OnClick="BTN_ShuaXing_Click"/><input class="btn" type="button" id="BTN_Insert" value="新增用户" runat="server" onclick="openZiyemian()"/> </h6>
                                <div class="table-responsive">
                                    <asp:Repeater runat="server" ID="UserFor"> 
                                        <HeaderTemplate>
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th scope="col">id</th>
                                                        <th scope="col">名称</th>
                                                        <th scope="col">密码</th>
                                                        <th scope="col">公司</th>
                                                        <th scope="col">权限</th>
                                                        <th scope="col">删除</th>
                                                        <th scope="col">修改</th>
                                                    </tr>
                                                    </thead>
                                                
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tbody>
                                            <tr>
                                                <th scope="row"><%#Eval("_id") %></th>
                                                <td><%#Eval("name") %></td>
                                                <td><%#Eval("password") %></td>
                                                <td><%#Eval("gongsi") %></td>
                                                <td><%#Eval("AdminIS") %></td>
                                                <td><input type="button" value="删除" <%--data-id ="<%#Eval("_id") %>" data-gongsi ="<%#Eval("gongsi")%>" --%> onclick="queren('<%#Eval("_id") %>','<%#Eval("gongsi") %>')" Class="Cbtn" id="BTN_DELETE"  /></td>
                                                <td><input type="button" value="修改"<%--data-id ="<%#Eval("_id") %>" data-gongsi ="<%#Eval("gongsi")%>" --%> onclick="upUser('<%#Eval("_id")%>','<%#Eval("gongsi")%>')" Class="Cbtn" id="BTN_UP" /></td>
                                            </tr>
                                                        
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                 
                                </div>
                                  </form>
                            </div>
                            
                        </div>
                    </div>
                    
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="assets/libs/popper.js/dist/umd/popper.min.js"></script>
    <script src="assets/libs/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="dist/js/app-style-switcher.js"></script>
    <script src="dist/js/waves.js"></script>
    <script src="dist/js/sidebarmenu.js"></script>
    <script src="dist/js/custom.js"></script>
</body>

</html>