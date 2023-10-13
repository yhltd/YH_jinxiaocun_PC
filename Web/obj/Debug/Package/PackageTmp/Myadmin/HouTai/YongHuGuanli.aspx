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
    <!-- Custom CSS -->
    <link href="dist/css/style.min.css" rel="stylesheet">
    <link href="../css/common.css" rel="stylesheet">
    
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
<![endif]-->
</head>

<body>
    <style type="text/css">
        .item_td {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 10px;
        }
        .auto-style1 {
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
            top : 0;
        }
        .select_input {
            width: 100%;
            border: none;
            height: 64%;
            border: 1px solid #F0F0F0;
            border-radius: 3px;
        }
        .btn_top {
            margin-left: 10px;
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
        }
        .table_bt {
            border: 1px solid #ccc;
            padding: 4px 0px;
            border-radius: 3px;
            width: 80%;
            height: 80%;
            background-color: #009688;
            color: white;
            cursor: pointer;
        }
    </style>
    <script src="../../Scripts/layui/layui.all.js"></script>

    <script src="../../Scripts/layui/lay/modules/layer.js"></script>
<%--    <script src="../../Scripts/jquery-1.4.1.min.js"></script>--%>
    <script src="../js/Jquery.js"></script>
    <script src="../js/qrcode.min.js"></script>
    <script type="text/javascript" >

        $(function () {
            var windowHeight = window.innerHeight;
            $(".table_div").css("height",windowHeight * 0.8+ "px");
        })

        function bindInput_select(val) {
            var tbody = $(".table_div table tbody")
            for (var i = 0; i < tbody.length; i++) {
                var tr = tbody[i].firstElementChild
                var td = tr.cells[1].textContent
                if (td.indexOf(val) >= 0) {
                    tbody[i].style.display = "table-row-group"
                } else {
                    tbody[i].style.display = "none"
                }
            }
        }

        function shuaxin() {
            window.location.href = window.location.href;
        }
        
        function queren( id,gongsi )
        {
            if (!confirm("确定删除吗？")) {
                window.event.returnValue = false;
            } else
            {
                $.ajax({
                    type: "post", //要用post方式                 
                    url: "YongHuGuanli.aspx?act=PostUser&id=" + id +"&gongsi="+gongsi,
                    dataType: "json",
                    success: function (data) {
                        console.log("delete", data);
                        shuaxin();
                    },
                    error: function (err) {
                    }
                });
            }
        }
        $('#BTN_DELETE').click(function () {
            var id = $(this).data("id")
            var gongsi = $(this).data("gongsi")
            queren(id, gongsi);
        })

        function qr_make(name,password, gongsi) {
            console.log(name)
            console.log(password)
            console.log(gongsi)
            var url = window.top.location.href
            console.log(url)
            var str = name + "`" + password + "`" + gongsi + "`" + "云合未来进销存系统"
            $.ajax({
                type: "post", //要用post方式     
                url: "/Myadmin/HouTai/YongHuGuanli.aspx/EncryptAes",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                data: JSON.stringify({
                    source: str,
                }),
                success: function (data) {
                    console.log(data)
                    console.log(window.top.location.href)
                    var this_url = window.top.location.href.replace("/frmMain.aspx", "/Myadmin/login.aspx")
                    console.log(this_url)
                    this_url = this_url + "?user=" + data.d
                    console.log(this_url)
                    var qrcode_container = document.getElementById('qrcode');
                    // 生成二维码
                    var qrcode = new QRCode(qrcode_container, {
                        text: this_url, // 二维码中的内容
                        width: 200, // 二维码的宽度
                        height: 200, // 二维码的高度
                        colorDark: "#000000", // 二维码的颜色
                        colorLight: "#ffffff", // 二维码的背景色
                    });
                    var base64_qrcode = qrcode_container.firstChild.toDataURL("image/png");
                    console.log(base64_qrcode)
                    downloadFileByBase64(name + ".png", base64_qrcode.split(",")[1])
                },
                error: function (err) {
                    console.log(err)
                }
            });
        }

        //function upUser(id, gongsi)
        function upUser(id,gongsi)
        {
            title = '修改用户';
            //var id = $(this).data("id");
            //document.getElementById(type).innerHTML = content;
            //url = 'InsertUser.aspx?type=update&id=' + v.id + '&gs=' + v.gongsi;
            url = 'InsertUser.aspx?type=update&id=' + id;
            layui.use('layer', function () {
                var layer = layui.layer;
            });
            layer.open({
                type: 2,
                title: title,
                shadeClose: true, //点击遮罩关闭层
                area: ['623px', '454px'],
                content: url,
                scrollbar: false,
                success: function (layero, index) {
                    var iframeBody = document.getElementById($('.layui-layer-content').find('iframe').prop('id')).contentWindow.document.body;
                    $(".manage_location_wrap", iframeBody).appendTo(iframeBody);
                    $('.container,header,footer', iframeBody).remove();
                },
                yes: function (index) {
                    shwoAddrs();
                },
                end: function () {
                    shuaxin();
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
                shadeClose: true, //点击遮罩关闭层
                area: ['623px', '454px'],
                content: url,
                scrollbar: false,
                success: function (layero, index) {
                    var iframeBody = document.getElementById($('.layui-layer-content').find('iframe').prop('id')).contentWindow.document.body;
                    $(".manage_location_wrap", iframeBody).appendTo(iframeBody);
                    $('.container,header,footer', iframeBody).remove();
                },
                yes: function (index) {
                    shwoAddrs();
                },
                end: function () {
                    shuaxin();
                }
            })
        }

        function dataURLtoBlob(dataurl, name) {//name:文件名
            var mime = name.substring(name.lastIndexOf('.') + 1)//后缀名
            var bstr = atob(dataurl), n = bstr.length, u8arr = new Uint8Array(n);
            while (n--) {
                u8arr[n] = bstr.charCodeAt(n);
            }
            return new Blob([u8arr], {type: mime});
        }

        function downloadFile(url, name) {
            var a = document.createElement("a")//创建a标签触发点击下载
            a.setAttribute("href", url)//附上
            a.setAttribute("download", name);
            a.setAttribute("target", "_blank");
            var clickEvent = document.createEvent("MouseEvents");
            clickEvent.initEvent("click", true, true);
            a.dispatchEvent(clickEvent);
        }

            //主函数
            function downloadFileByBase64(name, base64) {
                var myBlob = dataURLtoBlob(base64, name);
                var myUrl = URL.createObjectURL(myBlob);
                downloadFile(myUrl, name)
            }

            //获取后缀
            function getType(file) {
                var filename = file;
                var index1 = filename.lastIndexOf(".");
                var index2 = filename.length;
                var type = filename.substring(index1 + 1, index2);
                return type;
            }

            //根据文件后缀 获取base64前缀不同
            function getBase64Type(type) {
                switch (type) {
                    case 'data:text/plain;base64':
                        return 'txt';
                    case 'data:application/msword;base64':
                        return 'doc';
                    case 'data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64':
                        return 'docx';
                    case 'data:application/vnd.ms-excel;base64':
                        return 'xls';
                    case 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64':
                        return 'xlsx';
                    case 'data:application/pdf;base64':
                        return 'pdf';
                    case 'data:application/vnd.openxmlformats-officedocument.presentationml.presentation;base64':
                        return 'pptx';
                    case 'data:application/vnd.ms-powerpoint;base64':
                        return 'ppt';
                    case 'data:image/png;base64':
                        return 'png';
                    case 'data:image/jpeg;base64':
                        return 'jpg';
                    case 'data:image/gif;base64':
                        return 'gif';
                    case 'data:image/svg+xml;base64':
                        return 'svg';
                    case 'data:image/x-icon;base64':
                        return 'ico';
                    case 'data:image/bmp;base64':
                        return 'bmp';
                }
            }

            function base64ToBlob(code) {
                code = code.replace(/[\n\r]/g, '');
                var raw = window.atob(code);
                var rawLength = raw.length;
                var uInt8Array = new Uint8Array(rawLength);
                for (var i = 0; i < rawLength; ++i) {
                    uInt8Array[i] = raw.charCodeAt(i)
                }
            return new Blob([uInt8Array], {type: 'application/pdf'})
        }

    </script>
    <div class="preloader">
        <div class="lds-ripple">
            <div class="lds-pos"></div>
            <div class="lds-pos"></div>
        </div>
    </div>
    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full" data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
        <div id="qrcode" style="display: none"></div>
        <form id="formtable" runat="server" >
            <div class="new_ss_div">
                <input id="ru_cx" class="select_input" autocomplete="off" oninput="bindInput_select(this.value)" placeholder="按用户名称搜索" />
                <asp:Button id="BTN_ShuaXing" Text="刷新" CssClass="btn_top"  runat="server" OnClick="BTN_ShuaXing_Click"/>
                <input class="btn_top" type="button" id="BTN_Insert" value="新增用户" runat="server" onclick="openZiyemian()"/> 

            </div>
            <div class="table_div" style="width:100%;overflow:scroll;">
                <asp:Repeater runat="server" ID="UserFor"> 
                    <HeaderTemplate>
                        <table class="">
                            <thead>
                                <tr>
                                    <th class="auto-style1" style="width:100px">id</th>
                                    <th class="auto-style1" style="width:200px">账号</th>
                                    <th class="auto-style1" style="width:200px">密码</th>
                                    <th class="auto-style1" style="width:200px">公司</th>
                                    <th class="auto-style1" style="width:200px">权限</th>
                                    <th class="auto-style1" style="width:80px">删除</th>
                                    <th class="auto-style1" style="width:80px">修改</th>
                                    <th class="auto-style1" style="width:100px">二维码</th>
                                </tr>
                            </thead>   
                                  
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                        <tr>
                            <th class='item_td'><%#Eval("_id") %></th>
                            <td class='item_td'><%#Eval("name") %></td>
                            <td class='item_td'><%#Eval("password") %></td>
                            <td class='item_td'><%#Eval("gongsi") %></td>
                            <td class='item_td'><%#Eval("AdminIS").Equals("true") ? "管理员" : "普通用户" %></td>
                            <td class='item_td'>
                                <input type="button" value="删除" <%--data-id ="<%#Eval("_id") %>" data-gongsi ="<%#Eval("gongsi")%>" --%> onclick="queren('<%#Eval("_id") %>','<%#Eval("gongsi") %>')" class="table_bt" id="BTN_DELETE"  />

                            </td>
                            <td class='item_td'>
                                <input type="button" value="修改" <%--data-id ="<%#Eval("_id") %>" data-gongsi ="<%#Eval("gongsi")%>" --%> onclick="upUser('<%#Eval("_id") %>','<%#Eval("gongsi") %>')"  class="table_bt" id="BTN_UP" />

                            </td>
                            <td class='item_td'>
                                <input type="button" value="二维码" <%--data-id ="<%#Eval("_id") %>" data-gongsi ="<%#Eval("gongsi")%>" --%> onclick="qr_make('<%#Eval("name") %>','<%#Eval("password") %>','<%#Eval("gongsi") %>')"  class="table_bt" id="BTN_UP" />

                            </td>
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
    <script src="assets/libs/jquery/dist/jquery.min.js"></script>
    <script src="assets/libs/popper.js/dist/umd/popper.min.js"></script>
    <script src="assets/libs/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="dist/js/app-style-switcher.js"></script>
    <script src="dist/js/waves.js"></script>
    <script src="dist/js/sidebarmenu.js"></script>
    <script src="dist/js/custom.js"></script>
</body>

</html>