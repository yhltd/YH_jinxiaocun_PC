<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ming_xi.aspx.cs" Inherits="Web.ming_xi" %><%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Import Namespace="SDZdb" %>
<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="Myadmin/js/qrcode.min.js"></script>
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
            width: 190px;
            height: 30px;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
        }

        .bg_bj {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 4px;
        }

        .auto-style1 {
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
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
                this_text1 = elText.eq(i).children().eq(2).children().eq(1).prevObject[0].defaultValue
                this_text2 = elText.eq(i).children().eq(9)[0].innerText
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

            var newstr = '<canvas class="canvas" id="outCanvas" width="600" height="' + ((10 * 1) + this_list.length * 500) + '"></canvas>' + '<image id="Image" style="width:380px,height:380px" show="false"></image>'
            document.body.innerHTML = newstr;

            var image = document.querySelector('#Image')
            var canvas = document.querySelector('#outCanvas')
            var ctx = canvas.getContext('2d');

            ctx.font = "35px Arial";

            for (var i = 0; i < this_list.length; i++) {
                image.src = this_list[i].this_base64
                ctx.drawImage(image, 100, 10 + i * 500, 380, 380);
                ctx.fillText("订单号：" + this_list[i].this_text1, 50, 440 + i * 500);
                ctx.fillText("时间：" + this_list[i].this_text2, 50, 490 + i * 500);
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
            $('#time_qs').val(today);


            time.setMonth(time.getMonth() + 1);
            time.setDate('1');
            // 获取本月最后一天
            time.setDate(time.getDate() - 1);
            var today1 = time.getFullYear() + "-" + (month) + "-" + time.getDate();;
            $('#time_jz').val(today1);


            // 生成二维码
            var elText = $("#biao_ge").children().eq(0).children().eq(0).prevObject;
            console.log(elText)
            for (var i = 1; i < elText.length; i++) {
                this_text = elText.eq(i).children().eq(2).children().eq(1).prevObject[0].defaultValue
                console.log(this_text)
                var this_id = 'qrcode' + (i - 1)
                var qrcode = new QRCode(document.getElementById('' + this_id), {
                    width: 100,
                    height: 100
                });
                qrcode.makeCode(this_text);
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
                    <asp:Button ID="Button3" class="mingxi_input_tr_tj" OnClick="rq_select" Text="查询" runat="server" />
                    <asp:Button ID="del_mx_btu" OnClick="del_mingxi" class="mingxi_input_tr_tj" Text="删除" runat="server" />
                    <asp:Button ID="Button2" class="mingxi_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
                    <asp:Button ID="Button4" class="mingxi_input_tr_tj" OnClick="mx_save" Text="保存" runat="server" />
                    <input type="button" id="qr_print" class="mingxi_input_tr_tj" value="打印二维码">
                </div>
                <div class="funcion_top">
                    <asp:Button ID="downexcel" class="mingxi_input_tr_tj" OnClick="toExcel" Text="导出" runat="server" />
                </div>
            </div>

            <div class="d-main table_div" style="width:100%;overflow:scroll;">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row">
                    <tr id="dj_yh">                     
                        <td class="auto-style1" style="width: 50px">序号</td>
                        <th class="auto-style1" style="width: 105px">二维码</th>
                        <td class="auto-style1" style="width: 120px">订单号</td>
                        <td class="auto-style1" style="width: 100px">商品代码</td>
                        <td class="auto-style1" style="width: 100px">商品名称</td>
                        <td class="auto-style1" style="width: 100px">商品类别</td>
                        <td class="auto-style1" style="width: 100px">价格</td>
                        <td class="auto-style1" style="width: 100px">数量</td>
                        <td class="auto-style1" style="width: 100px">明细类型</td>
                        <td class="auto-style1" style="width: 140px">时间</td>
                        <td class="auto-style1" style="width: 100px">公司名</td>
                        <td class="auto-style1" style="width: 100px">收/进货方</td>
                        <td class="auto-style1" style="width: 50px">功能</td>
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
            <div class="d-footer" style="width: 300px;height: 70px;display: flex;justify-content: space-around;align-items: center;">
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
