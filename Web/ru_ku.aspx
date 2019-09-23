<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ru_ku.aspx.cs" Inherits="Web.ru_ku" %>

<%@ Import Namespace="SDZdb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Myadmin/js/jquery-1.7.1.min.js"></script>
    <script>
        $(function () {
            $("#dj_row").click(function () {

                $("#row_i1").val($("#biao_ge tr").length);

            })

        })

        function del_row(row) {
            $("#del_row" + row + "").remove();

        }

        $(document).ready(function () {
            var row = 1;
            $("#dj_yh").click(function () {

                var rowLength = $("#biao_ge tr").length;
                var insertStr = "<tr id='del_row" + row + "' >"
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 18px;'>" + (rowLength) + "</td>"
                               + "<td ><input type='text' class='input_tr'  id='sp_name" + row + "' name='sp_name" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'><input type='text' id='sp_dm"+row+"' class='input_tr' name='sp_dm" + row + "' ></input></td>"
                               + "<td class='bg_bj_lb'><input type='text' id='sp_cplb' class='input_tr' name='sp_cplb" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' id='sp_cpsj' class='input_tr' name='sp_cpsj" + row + "' ></input></td>"
                               + "<td class='bg_bj_sl'><input type='text' id='sp_cpsl" + row + "' class='input_tr' name='sp_cpsl" + row + "' ></input></td>"
                               + "<td class='bg_bj_je'><input type='text' id='sp_je' class='input_tr' name='sp_je" + row + "' ></input></td>"
                               + "<td ><input type='text' class='input_tr' id='sp_bz' name='sp_bz" + row + "' ></input></td>"
                               + "<td ><input type='button' style='color:red;border-right: 1px dashed #a8a8a8' class='rk_btu'value='删除'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
            });
        });

        function pd_tj_ff() {
            var c = confirm('要提交吗?');
            if (c) {
                $("#xx_hidden").val("tj_true");
                $("#tj_pd_id").val("tj_true");
            } else {
              
                $("#tj_pd_id").val("tj_false");
               
            }
         
        }


        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("order_id").value == "") {
                alert("请输入订单号");
                return false;
            } else {
            }
        })

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("gh_f_id").value == "") {
                alert("请输入供货方");
                return false;
            } else {
            }
        })

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("xx_hidden").value == "tj_false") {
                return false;
            } else {
            }
        })


        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("sh_f_id").value == "") {
                alert("请输入收货方");
                return false;
            } else {
            }
        })

        

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("sp_name").value == "") {
                alert("请输入商品名称");
                return false;
            } else {
            }
        })

      
        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            for (var i = 1; i < $("#biao_ge tr").length; i++) {
                if (document.getElementById("sp_name" + i).value == "") {
                    alert("请输入商品名称");
                    return false;
                } else {
                }
            }
          
        })

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("sp_dm").value == "") {
                alert("请输入商品代码");
                return false;
            } else {
            }
        })

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            for (var i = 1; i < $("#biao_ge tr").length; i++) {
                if (document.getElementById("sp_dm" + i).value == "") {
                    alert("请输入商品代码");
                    return false;
                } else {
                }
            }

        })

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            for (var i = 1; i < $("#biao_ge tr").length; i++) {
                if (document.getElementById("sp_cpsl" + i).value == "") {
                    alert("请输入商品数量");
                    return false;
                } else {
                }
            }

        })

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("sp_cpsl").value == "") {
                alert("请输入商品数量");
                return false;
            } else {
            }
        })
        //function pd_tj_ff() {


        //    if (document.getElementById("order_id").value == "") {
        //        alert("请输入订单号");

        //    } else {
        //        alert("asd");
        //    }
        //}
        function checkLogin1() {
            //var adminname = $("#order_id").val().trim();
            //if (adminpassword == "" || adminpassword.length <= 0) {
            //    alert("asd");
            //    $("#order_id").html("请填写单号!");

            //    return;

            //} else {
            //    alert("zxc");
            //    $("#order_id").html("");

            //}
            alert($("#biao_ge tr").length);
        }


        //$("#sssss").click(function () {

        //        //  var x = $(this).siblings("#bookid").text();
        //        var ddh =  document.getElementById("order_id").value;
        //        //if (document.getElementById("order_id").value == "") {
        //            $.ajax({
        //                url: "ru_ku.aspx",
        //                type: "POST",
        //                data: ddh,

        //                success: function (data) {
        //                    if (data == "") {
        //                        alert("输入1订单号");
        //                    }


        //                }
        //            });
        //        //}

        //    });



    </script>
    <style type="text/css">
        body {
            /*background-color:#ebf2f9;*/
        }

        #biao_ti {
            margin-bottom: 2%;
            color: white;
            height: 42px;
            width: 11%;
            background-color: #36bf7b;
            margin-top: -1%;
            margin-left: -1%;
            padding-bottom: 0%;
        }
        /*.input_tr {
           background-color: #ccffcc;
        }*/

        #biao_ge {
            /*margin: 0px auto;*/
        }

            #biao_ge td {
            }

        .auto-style1 {
            color: black;
            height: 33px;
            background-color: #eeeef6;
        }

        tr:nth-child(2n-1) input {
            background-color: #eeeeee;
        }

        tr:nth-child(2n) input {
            background-color: #ffffff;
        }


        #biao_ge tr:nth-of-type(odd) {
            background-color: #eeeef6;
        }


        #biao_ge tr:nth-of-type(even) {
            /*background: #ccffcc;*/
            /*background: #da6f5e;*/
        }

        input {
        }

        td {
            border-left: 1px dashed #a8a8a8;
            border-bottom: 1px dashed #a8a8a8;
        }

        table {
            /*border: 1px dashed #a8A8A8;*/
        }

        .dh_css {
            /*position:absolute;
            top: 90px;*/
        }

        .ghf_css {
            margin-top: -23px;
            margin-left: 23%;
        }

        .shf_css {
            margin-top: -26px;
            margin-left: 46%;
        }

        .rq_css {
            margin-top: -28px;
            margin-left: 69%;
        }

        #dj_row {
            position: relative;
            left: 13.7%;
        }




        /*input{
              border: 1px solid #ccc;             
              padding: 3px 0px;             
              border-radius: 3px;
              padding-left:5px;
              padding-right:5px;
              -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
              box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
              -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
               -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
               transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s

          }*/
        /*input:focus{
              border-color: #66afe9;
              outline: 0; 
              -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6); 
              box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6)         

          }*/
        .rk_btu {
            border-right: 1px dashed #a8a8a8;
            border: 1px solid #ccc;
            padding: 4px 0px;
            border-radius: 3px;
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

        .tj_kk {
            /*position: absolute ;
            top: 10%;*/
            margin-top: 7%;
        }

        .input_tr {
            margin: 0.1px;
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
            padding-left: 78.7%;
            padding-bottom: 2%;
            margin-top: 4%;
        }

        #sp_dm {
            width: 128px;
        }

        .bg_bj_dm {
            width: 128px;
        }


        #sp_cplb {
            width: 128px;
        }

        .bg_bj_lb {
            width: 128px;
        }


        .bg_bj_sj {
            width: 128px;
        }

        #sp_cpsj {
            width: 128px;
        }

        .bg_bj_sl {
            width: 128px;
        }

        #sp_cpsl {
            width: 128px;
        }

        .bg_bj_je {
            width: 128px;
        }

        #sp_je {
            width: 128px;
        }

        #sp_bz {
            width: 203px;
        }
    </style>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--        <div ></div>--%>

            <%-- <div id="biao_ti" ><div style="position: relative; padding-left: 31%; top: 30%;">入库单</div><div style="background-color:#36bf7b;height:2px;width:919%;margin-top: 16%;"></div> </div>--%>

            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <input type="hidden" id="row_i1" name="row_i" />
             <input type="hidden" id="xx_hidden" value="tj_false" />
            <div class="ss_div">
                <input id="ru_cx" style="width: 19%; border-radius: 3px;" class="input_tr" name="ru_cx" />
                <asp:Button OnClick="bt_select_Click" ID="Button1" class="rk_btu" Text="订单号查询" runat="server" />
            </div>

            <input onclick="checkLogin1()" id="sssss" value="asd" type="button" />
            <table id="biao_ge" name="bg_row" cellspacing="0" cellpadding="0">
                <%--cellspacing="5" cellpadding="5"--%>

                <tr id="dj_yh">
                    <td class="auto-style1" style="padding-left: 1%; width: 18px; font-size: 92%; border-top: 1px dashed #a8a8a8;"></td>
                    <td class="auto-style1" style="padding-left: 1%; width: 130px; font-size: 92%; border-top: 1px dashed #a8a8a8;">商品名称</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 130px; font-size: 92%; border-top: 1px dashed #a8a8a8;">商品代码</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 130px; font-size: 92%; border-top: 1px dashed #a8a8a8;">商品类别</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 130px; font-size: 92%; border-top: 1px dashed #a8a8a8;">商品单价</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 130px; font-size: 92%; border-top: 1px dashed #a8a8a8;">商品数量</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 130px; font-size: 92%; border-top: 1px dashed #a8a8a8;">金额</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 205px; font-size: 92%; border-top: 1px dashed #a8a8a8;">备注</td>
                    <td class="auto-style1" style="padding-left: 0.4%; font-size: 92%; border-right: 1px dashed #a8a8a8; border-top: 1px dashed #a8a8a8;">功能</td>
                </tr>

                <%
               
                    List<ming_xi_info> ru_ku_select = Session["ru_ku_select"] as List<ming_xi_info>;

                    if (ru_ku_select != null)
                    {
                        for (int i = 0; i < ru_ku_select.Count; i++)
                        {                          
                %>
                <tr id="del_row0" class="dj_sj">
                    <td class="bg_bj_mc" style="font-size: 14px; padding-left: 0.5%; width: 18px;"><%=i+1 %></td>
                    <td class="bg_bj_mc">
                        <input type="text" class="input_tr" id="sp_name" name="sp_name0" value="<%=ru_ku_select[i].Cpname%>" /></td>
                    <td class="bg_bj_dm">
                        <input type="text" class="input_tr" id="sp_dm" name="sp_dm0" value="<%=ru_ku_select[i].sp_dm%>" /></td>
                    <td class="bg_bj_lb">
                        <input type="text" class="input_tr" id="sp_cplb" name="sp_cplb0" value="<%=ru_ku_select[i].Cplb%>" /></td>
                    <td class="bg_bj_sj">
                        <input type="text" class="input_tr" id="sp_cpsj" name="sp_cpsj0" value="<%=ru_ku_select[i].Cpsj%>" /></td>
                    <td class="bg_bj_sl">
                        <input type="text" class="input_tr" id="sp_cpsl" name="sp_cpsl0" value="<%=ru_ku_select[i].Cpsl%>" /></td>
                    <td class="bg_bj_je">
                        <input type="text" class="input_tr" id="sp_je" name="sp_je0" value="<%=ru_ku_select[i].Cpjg%>" /></td>
                    <td class="bg_bj_bz">
                        <input type="text" class="input_tr" id="sp_bz" name="sp_bz0" value="<%=ru_ku_select[i].shou_h%>" /></td>
                    <td class="bg_bj">
                        <input type='button' style="color: red;" class='rk_btu' value='删除' onclick='del_row(0)' /></td>
                </tr>
                <%
                        }
                    }
                    else
                    {
                %>
                <tr id="del_row0" class="dj_sj">
                    <td class="bg_bj_mc" style="font-size: 14px; padding-left: 0.5%; width: 18px;">
                        <% int aa = 0; %><%= aa+=1 %>
                    </td>
                    <td class="bg_bj_mc">
                        <input type="text" class="input_tr" id="sp_name" name="sp_name0" /></td>
                    <td class="bg_bj_dm">
                        <input type="text" class="input_tr" id="sp_dm" name="sp_dm0" /></td>
                    <td class="bg_bj_lb">
                        <input type="text" class="input_tr" id="sp_cplb" name="sp_cplb0" /></td>
                    <td class="bg_bj_sj">
                        <input type="text" class="input_tr" id="sp_cpsj" name="sp_cpsj0" /></td>
                    <td class="bg_bj_sl">
                        <input type="text" class="input_tr" id="sp_cpsl" name="sp_cpsl0" /></td>
                    <td class="bg_bj_je">
                        <input type="text" class="input_tr" id="sp_je" name="sp_je0" /></td>
                    <td class="bg_bj_bz">
                        <input type="text" class="input_tr" id="sp_bz" name="sp_bz0" /></td>
                    <td class="bg_bj">
                        <input type='button' style="color: red;" class='rk_btu' value='删除' onclick='del_row(0)' /></td>
                </tr>
                <%
               }
                %>
            </table>

            <div style="margin-left: 41%; margin-top: 4%;">
                <asp:Button CssClass="input_tr" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="input_tr" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Button CssClass="input_tr" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="input_tr" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>
            <div class="tj_kk">

                <div class="dh_css" style="padding-left: 14.2%">
                    <label>单号：</label><input type="text" style="width: 6%" id="order_id" class="input_tr" name="orderid" />
                </div>
                <div class="ghf_css" style="padding-left: 6%">
                    <label>供货方：</label><input type="text" style="width: 10%" id="gh_f_id" class="input_tr" name="gongsi" />
                </div>
                <div class="shf_css" style="">
                    <label>收货方：</label><input type="text" style="width: 14%" id="sh_f_id" class="input_tr" name="shou_h" />
                </div>
                <div class="rq_css" style="margin-left: 63%">
                    <label>日期：</label><input type="date" style="width: 27%" class="input_tr" name="shijian" />
                    <asp:Button OnClick="bt_add_Click" ID="dj_row" class="rk_btu" Text="入库" runat="server" />
                </div>

            </div>
            <div style="border: 1px solid #95b8e7; height: 90px; width: 79%; margin-top: -5%; margin-left: 11%;">
            </div>
            <div style="margin-top: -9%; margin-left: 13%; background-color: #ffffff; width: 7%; padding-left: 2%;">提交入库</div>

        </div>
    </form>
</body>
</html>
