<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ming_xi.aspx.cs" Inherits="Web.ming_xi" %><%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Import Namespace="SDZdb" %>
<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="Myadmin/js/qrcode.min.js"></script>
    <script src="Myadmin/js/JsBarcode.all.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #biao_ge {
            width: 100%;
        }

        .input_tr2 {
            border: none;
            height: 90%;
            width: 90%;
            text-align: center;
        }

        .hidden_load {
            display: none;
        }

        .tr_1 {
            background-color: #eeeeee;
        }

        .tr_2 {
            background-color: white;
        }


        .input_tr {
            border: 1px solid #ccc;
            padding: 4px 0px;
            /*border-radius: 3px;*/
            padding-left: 5px;
            padding-right: 5px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

            .input_tr:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        .ss_div {
            margin-left: 69%;
            margin-top: -3%;
            margin-bottom: -8%;
        }

        .rk_btu {
            margin-left: 6%;
            margin-bottom: 6%;
            border: 1px solid #ccc;
            padding: 4px 0px;
            /*border-radius: 3px;*/
            padding-left: 5px;
            padding-right: 5px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .rk_btu:focus {
            border-color: #66afe9;
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
        }

        .input_tr_sx {
            margin-left: 10%;
            border: 1px solid #ccc;
            padding: 4px 0px;
            /*border-radius: 3px;*/
            padding-left: 5px;
            padding-right: 5px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

            .input_tr_sx:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        .rq_css {
            width: 100%;
            height: 50px;
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            align-items: center;
        }

        .lable_select {
            font-size: 15px;
        }

        .select_div {
            display: flex;
            align-items: center;
        }

        .funcion_top {
            /*margin-left:150px;*/
            display: flex;
            align-items: center;
            /*justify-content: space-around;
            width: 200px;*/
        }

        .time_select {
            width: 130px;
            height: 30px;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
        }

        .bg_bj {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 16px;
        }

        .auto-style1 {
            height: 49px;
            text-align: center;
            background-color:#143268;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
            top : 0;
        }

        .page_bt {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
        }

        .select_input {
            border: none;
            text-align: center;
            width: 90%;
            height: 90%;
        }


         .item_td {
            text-align: center;
            height: 40px;
            color:black;
            font-size:14px;
            background-color: #98c9d9;
            /*border: 2.5px solid white;*/
        }

          tr:hover {
            transform: translateY(-4px);
            box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1);
            z-index: 10;
        }
        
        /* 奇数行样式 */
        tr:nth-child(odd) .item_td {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .item_td {
            background-color: #e0f7fa; 
        }

         .table_input {
            border: none;
            color:black;
            height: 90%;
            width: 90%;
        }
         /* 奇数行样式 */
        tr:nth-child(odd) .table_input {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .table_input {
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

        .input_tr {
            border: none;
            text-align: center;
            color:black;
            width: 90%;
            height: 90%;
        }
         /* 奇数行样式 */
        tr:nth-child(odd) .input_tr {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .input_tr {
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

        .d-header {
            margin-left:1%;
            margin-top:10px;
            padding:5px;
            width:97%;
            min-height:50px;
          background: linear-gradient(135deg, #3030c7 0%, #2424a1 50%, #a8a8d2 100%);
           border-radius:5px;
           box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
           
        }

        .d-main {
            overflow:auto;
            margin-left:1%;
            margin-top:30px;
            box-sizing: border-box;
            padding-left:5px;
            padding-right:5px;
            height:80%;
            width:97%;
            border:3px solid #D3D3D3;
             box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
            
        }
    </style>
    <title></title>
</head>
<body>
    <script type="text/ecmascript">
        $(function () {
            var shuliang = $("#shuliang").val();
            for (var i = 0 ; i < shuliang; i++) {
                $("#mxtype" + i + "").val($("#2mxtype" + i + "").val());
            }
            var mxtype2 = $("#mxtype2").val();
            $("#mxtype2").val(mxtype2);
        });
        $(function () {
            var windowHeight = window.innerHeight;
            $(".table_div").css("height", windowHeight * 0.8)
        })
        function del_mingxi(row) {
            var rowIndex = $("#del_mingxi").context.rowIndex;
            $("#del_mingxi" + row + "").remove();
        }

        function del_row(row) {
            var rowIndex = $("#del_row_cs1").context.rowIndex;
            $("#del_row" + row + "").remove();
        }
        function js_select() {
            var time_qs1 = document.getElementById('time_qs').value;
            var time_jz1 = document.getElementById('time_jz').value;
            console.log(time_qs1)
           setCookie('ks_riqi', time_qs1, 30); //保存帐号到cookie，有效期7天
            setCookie('js_riqi', time_jz1, 30);
        }
        function setCookie(name, value, day) {
            var date = new Date();
            date.setDate(date.getDate() + day);
            document.cookie = name + '=' + value + ';expires=' + date;
        };
        //获取cookie
        function getCookie(name) {
            var reg = RegExp(name + '=([^;]+)');
            var arr = document.cookie.match(reg);
            if (arr) {
                return arr[1];
            } else {
                return '';
            }
        };
        //删除cookie
        function delCookie(name) {
            setCookie(name, null, -1);
        };


        $(function () {

            $("#dj_row").click(function () {

                $("#row_i1").val($("#biao_ge tr").length);

            })

        })

        //$(document).ready(function () {
        //    var row = 1;
        //    $("#dj_yh").click(function () {

        //        var rowLength = $("#biao_ge tr").length;

        //        var insertStr = "<tr id='del_row" + row + "' >"
        //                       + "<td style='font-size: 14px;padding-left: 0.5%;width: 70px;'>" + rowLength + "</td>"
        //                       + "<td ><input type='text' class='input_tr' style='width: 130px;margin:0.2%;' name='sp_dm" + row + "' ></input></td>"
        //                       + "<td class='bg_bj_dm'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='name" + row + "' ></input></td>"
        //                       + "<td class='bg_bj_lb'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='lei_bie" + row + "' ></input></td>"
        //                       + "<td class='bg_bj_sj'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='dan_wei" + row + "' ></input></td>"
        //                       + "<td class='bg_bj_sj'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='shou_huo" + row + "' ></input></td>"
        //                       + "<td class='bg_bj_sj'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='gong_huo" + row + "' ></input></td>"
        //                       + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button' style='width: 70px;margin:0.2%;' class='rk_btu'value='删除' style='margin-left: 3px;'  onclick='del_row(" + row + ")'/></td>"
        //                       + "</tr>";
        //        $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
        //        row++;
        //    });


        //});

        //$(document).on("click", "#qr_print", function () {
        //    alert("点击打印按钮");
        //    var oldstr = window.document.body.innerHTML;
        //    var newstr = '<table>'

        //    var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
        //    console.log(elText)
        //    for (var i = 1; i < elText.length; i++) {
        //        this_text1 = elText.eq(i).children().eq(2)[0].innerHTML
        //        this_text2 = elText.eq(i).children().eq(1)[0].innerHTML
        //        this_text = '<tr><td>' + this_text1 + '</td><td>' + this_text2 + '</td></tr>'
        //        newstr = newstr + this_text
        //        console.log(this_text)
        //    }
        //    newstr = newstr + "</table>"
        //    document.body.innerHTML = newstr;
        //    window.print();
        //    document.body.innerHTML = oldstr;
        //    window.location.reload();
        //})

        $(document).on("click", "#qr_print", function () {
            var oldstr = window.document.body.innerHTML;
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            console.log(elText)
            var this_list = []
            for (var i = 1; i < elText.length; i++) {
                this_text1 = elText.eq(i).children().eq(3).children().eq(1).prevObject[0].defaultValue
                this_text2 = elText.eq(i).children().eq(10)[0].innerText
                this_base64 = elText.eq(i).children().eq(1).children().eq(0).children().eq(1)[0].currentSrc
                console.log(this_text1)
                console.log(this_text2)
                console.log(this_base64)
                this_list.push({
                    this_text1: this_text1,
                    this_text2: this_text2,
                    this_base64: this_base64,
                })
            }
            console.log(this_list)

            var newstr = '<canvas class="canvas" id="outCanvas" width="300" height="' + ((10 * 1) + this_list.length * 280) + '"></canvas>' + '<image id="Image" style="width:170px,height:170px" show="false"></image>'
            document.body.innerHTML = newstr;

            var image = document.querySelector('#Image')
            var canvas = document.querySelector('#outCanvas')
            var ctx = canvas.getContext('2d');

            ctx.font = "18px Arial";

            for (var i = 0; i < this_list.length; i++) {
                image.src = this_list[i].this_base64
                ctx.drawImage(image, 60, 10 + i * 280, 170, 170);
                ctx.fillText("订单号：" + this_list[i].this_text1, 30, 200 + i * 280);
                ctx.fillText("时间：" + this_list[i].this_text2, 30, 230 + i * 280);
            }
            image.remove();
            window.print();
            document.body.innerHTML = oldstr;
            window.location.reload();
        })


        $(document).on("click", "#barcode_print", function () {
            var oldstr = window.document.body.innerHTML;
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            console.log(elText)
            var this_list = []
            for (var i = 1; i < elText.length; i++) {
                this_text1 = elText.eq(i).children().eq(3).children().eq(1).prevObject[0].defaultValue
                this_text2 = elText.eq(i).children().eq(10)[0].innerText
                var canvas = document.createElement("canvas");
                JsBarcode(canvas, this_text1, { format: "CODE128" });
                this_base64 = canvas.toDataURL("image/png");
                console.log(this_text1)
                console.log(this_text2)
                console.log(this_base64)
                this_list.push({
                    this_text1: this_text1,
                    this_text2: this_text2,
                    this_base64: this_base64,
                })
            }
            console.log(this_list)

            var newstr = '<canvas class="canvas" id="outCanvas" width="300" height="' + ((10 * 1) + this_list.length * 280) + '"></canvas>' + '<image id="Image" style="width:170px,height:170px" show="false"></image>'
            document.body.innerHTML = newstr;

            var image = document.querySelector('#Image')
            var canvas = document.querySelector('#outCanvas')
            var ctx = canvas.getContext('2d');

            ctx.font = "18px Arial";

            for (var i = 0; i < this_list.length; i++) {
                image.src = this_list[i].this_base64
                ctx.drawImage(image, 60, 10 + i * 280, 170, 170);
                ctx.fillText("订单号：" + this_list[i].this_text1, 30, 200 + i * 280);
                ctx.fillText("时间：" + this_list[i].this_text2, 30, 230 + i * 280);
            }
            image.remove();
            window.print();
            document.body.innerHTML = oldstr;
            window.location.reload();
        })


        $(document).ready(function () {
          var time = new Date();
            var day = ("0" + time.getDate()).slice(-2);
            var month = ("0" + (time.getMonth() + 1)).slice(-2);
            var today = time.getFullYear() + "-" + (month) + "-" + "01";
        
            var ks_riqi = '<%= Session["ks_riqi"] %>';
            var js_riqi = '<%= Session["js_riqi"] %>';
            
            //var ks_riqi_1 = getCookie('ks_riqi');
            //var js_riqi_1 = getCookie('js_riqi');
           // console.log(ks_riqi_1)
           // console.log(js_riqi_1)
            //var ks_riqi = Session["ks_riqi"];
            console.log(ks_riqi)
            console.log(js_riqi)
            if (ks_riqi == '' &&  js_riqi == '') {
                $('#time_qs').val(today);
                time.setMonth(time.getMonth() + 1);
                time.setDate('1');
                // 获取本月最后一天
                time.setDate(time.getDate() - 1);
                var today1 = time.getFullYear() + "-" + (month) + "-" + time.getDate();;
                $('#time_jz').val(today1);
            } else {
                $('#time_qs').val(ks_riqi);
                $('#time_jz').val(js_riqi);
            }
            console.log( $('#time_jz').val())
            // 生成二维码
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            console.log(elText)
            for (var i = 1; i < elText.length; i++) {
                this_text = elText.eq(i).children().eq(3).children().eq(1).prevObject[0].defaultValue
                console.log(this_text)
                var this_id = 'qrcode' + (i - 1)
                var qrcode = new QRCode(document.getElementById('' + this_id), {
                    width: 100,
                    height: 100
                });
                var barcode_id = "barcode" + (i - 1)
                JsBarcode("#barcode" + (i - 1), this_text, {
                    format: "CODE128",
                    displayValue: true,
                    height: 50,
                    fontSize: 12,
                    width: 1,
                    lineColor: "#000000"
                });
                qrcode.makeCode(this_text);
                var canvas = document.createElement("canvas");
                JsBarcode(canvas, this_text, { format: "CODE128" });
                this_base64 = canvas.toDataURL("image/png");
                console.log(this_base64)
                var canvas_barcode = document.getElementById("barcode" + (i - 1))
                var this_html = '<img src="' + this_base64 + '" style="display: block;">'
                canvas_barcode.innerHTML = this_html
            }
        })
        


    </script>
    <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>--%>
    <form id="form1" runat="server">
        <div>
            <div class="d-header rq_css">
                
                
                <div class="select_div">
                    <label class="lable_select"></label>
                    <input type="date" class="time_select" name="time_qs" id="time_qs" />
                    <label class="lable_select"></label>
                    <input type="date" class="time_select" name="time_jz" id="time_jz" />
                    <label class="lable_select"></label>
                    <input type="text" class="time_select" placeholder="订单号" name="order_number" id="order_number" />
                    <asp:Button ID="Button3" class="mingxi_input_tr_tj" style="width:61px" OnClick="rq_select" OnClientClick="js_select()" Text="查询" runat="server" />
                    
                    <asp:Button ID="del_mx_btu" OnClick="del_mingxi" class="mingxi_input_tr_tj" style="width:61px" Text="删除" runat="server" />
                    <asp:Button ID="Button2" class="mingxi_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
                    <asp:Button ID="Button4" class="mingxi_input_tr_tj" style="width:61px" OnClick="mx_save" Text="保存" runat="server" />
                    <input type="button" id="qr_print" class="mingxi_input_tr_tj" value="打印二维码">
                    <input type="button" id="barcode_print" class="mingxi_input_tr_tj" value="打印条形码">
                    <asp:Button ID="downexcel" class="mingxi_input_tr_tj" OnClick="toExcel" Text="导出" runat="server" />
                </div>
                <div class="funcion_top">
                    
                </div>
            </div>

            <div class="d-main table_div" style="width:100%;">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row">
                    <tr id="dj_yh">                     
                        <td class="auto-style1" style="width: 5%">序号</td>
                        <th class="auto-style1" style="width: 10%">二维码</th>
                        <th class="auto-style1" style="width: 10%">条形码</th>
                        <td class="auto-style1" style="width: 10%">订单号</td>
                        <td class="auto-style1" style="width: 8%">商品代码</td>
                        <td class="auto-style1" style="width: 8%">商品名称</td>
                        <td class="auto-style1" style="width: 8%">商品类别</td>
                        <td class="auto-style1" style="width: 5%">价格</td>
                        <td class="auto-style1" style="width: 5%">数量</td>
                        <td class="auto-style1" style="width: 5%">明细类型</td>
                        <td class="auto-style1" style="width: 5%">时间</td>
                        <td class="auto-style1" style="width: 8%">公司名</td>
                        <td class="auto-style1" style="width: 8%">收/进货方</td>
                        <td class="auto-style1" style="width: 5%">功能</td>
                    </tr>

                    <%
               
                        System.Collections.Generic.List<Web.Server.yh_jinxiaocun_mingxi> ming_xi_select_dd = Session["ming_xi_select_dd"] as System.Collections.Generic.List<Web.Server.yh_jinxiaocun_mingxi>;
                        if (ming_xi_select_dd != null)
                        {
                            for (int i = 0; i < ming_xi_select_dd.Count; i++)
                            {                          
                    %>

                    <tr id="Tr1" class="tr_<%=ming_xi_select_dd[i]._openid %>">
                        <td class="bg_bj">
                            <%=(i+1) %>
                            
                            <input hidden="hidden" id="_id<%=i %>" name="_id<%=i %>" value="<%=ming_xi_select_dd[i]._id %>" />
                        </td>
                        <td class="bg_bj">
                            <div id="qrcode<%=i%>" style="width:60px;" name="<%=ming_xi_select_dd[i].orderid%>"></div></td>
                        <td class="bg_bj">
                            <canvas id="barcode<%=i%>" style="width:120px;" name="<%=ming_xi_select_dd[i].orderid%>"></canvas></td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr2" id="orderid" name="orderid<%=i %>" value="<%=ming_xi_select_dd[i].orderid %>" />
                        </td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr2" id="sp_dm" name="sp_dm<%=i %>" value="<%=ming_xi_select_dd[i].sp_dm %>" />
                        </td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr2" id="cpname" name="cpname<%=i %>" value="<%=ming_xi_select_dd[i].cpname %>" />
                        </td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr2" id="cplb" name="cplb<%=i %>" value="<%=ming_xi_select_dd[i].cplb %>" />
                        </td>
                        <td class="bg_bj">
                            <input type="number"class="input_tr2" id="cpsj" name="cpsj<%=i %>" value="<%=ming_xi_select_dd[i].cpsj %>" />
                        </td>
                        <td class="bg_bj">
                            <input type="number"class="input_tr2" id="cpsl" name="cpsl<%=i %>" value="<%=ming_xi_select_dd[i].cpsl %>" />
                        </td>
                        <td class="bg_bj">
                            <select class="select_input" id="mxtype<%=i %>" name="mxtype<%=i %>" >
                                <option value="入库">入库</option>
                                <option value="出库">出库</option>
                            </select>
                            <input hidden="hidden" id="2mxtype<%=i %>" value="<%=ming_xi_select_dd[i].mxtype %>" />
                        </td>
                        <td class="bg_bj">
                            <%=ming_xi_select_dd[i].shijian.GetValueOrDefault().ToString("g") %>
                        </td>
                        <td class="bg_bj">
                            <%=ming_xi_select_dd[i].gs_name %>
                        </td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr2" id="shou_h" name="shou_h<%=i %>" value="<%=ming_xi_select_dd[i].shou_h %>" />
                        </td>
                        <td class="bg_bj" style="width: 43px;"><input id="checkbox" name="Checkbox_bd<%=i%>" value=" <%=i%>" type="checkbox" /></td>
                        
                    </tr>
                    <%
                            }
                        }
                    %>
                </table>
            </div>
            <div class="d-footer" style="width: 300px;height: 70px;display: flex;justify-content: space-around;align-items: center; height:0;overflow:hidden;">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Label runat="server" ID="lblCurrentPage" style=" font-weight:bold"></asp:Label>
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>
            <input hidden="hidden" id="shuliang"  name="shuliang" value="<%=ming_xi_select_dd.Count %>" />
        </div>
    </form>
</body>
    
</html>
