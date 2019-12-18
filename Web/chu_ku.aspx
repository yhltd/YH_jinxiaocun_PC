<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chu_ku.aspx.cs" Inherits="Web.chu_ku" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.7.1.min.js"></script>
    <script>
        $(function () {

            $("#xx").click(function () {
                if (document.getElementById("#ck_xz1").checked == true) {
                    alert("aa");
                }
                //alert($("#ck_xz1").checked())
            })
        })

        //$(function () {
        //    for (var i = 0; i < $("#biao_ge tr").length; i++) {
        //        $("#dj_js"+i).click(function () {
        //            alert($("#row_i1").val($("#biao_ge tr").length));
        //            //alert($("#ck_sl"+ i).val());

        //        })
        //    }
        //})
        function js_xx(row) {

            $("#dj_js" + row).text($("#ck_sl" + row).val() * $("#ck_dj" + row).val());
        }

        function pd_tj_ff() {
            var c = confirm('要提交吗?');
            if (c) {
                $("#xx_hidden").val("tj_true");
                $("#tj_pd_id").val("tj_true");
            }
            else {
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
            if (document.getElementById("sh_f_id").value == "") {
                alert("请输入收货方");
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
        function pdsl(row, cpsl) {
            if ($("#ck_sl" + row).val() > cpsl) {
                alert("出库数量不能大于该产品的库存数量！");
                $("#ck_sl" + row).val("");
            }
        }
    </script>
    <style type="text/css">
        #biao_ti {
            margin-left: 45%;
            padding-bottom: 4%;
        }

        /*.dh_css {
            position: absolute;
            top: 90px;
        }

        .ghf_css {
            position: absolute;
            top: 90px;
            left: 325px;
        }

        .shf_css {
            position: absolute;
            top: 90px;
            left: 670px;
        }

        .rq_css {
            position: absolute;
            top: 90px;
            left: 1000px;
        }*/

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
         .tj_kk {
            /*position: absolute ;
            top: 10%;*/
            margin-top: 7%;
        }

        #biao_ge {
            /*margin: 0px auto;*/
        }

        .rk_btu {
            margin-left: 12%;
        }

        .hidden_load {
            display: none;
        }



        /*888888888888888888888888888888888888888888888888888*/


        input {
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

            input:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        td {
            border-left: 1px dashed #a8a8a8;
            border-bottom: 1px dashed #a8a8a8;
        }

        table {
            /*border: 1px dashed #a8A8A8;*/
        }

        .auto-style1 {
            color: black;
            height: 33px;
            background-color: #eeeef6;
            border-top: 1px dashed #a8a8a8;
        }

        .input_tr_ck {
            margin-left: 15%;
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

        .input_tr_sx {
            margin-left: 5%;
            margin-top: 3%;
        }
    </style>
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
               <input type="hidden" id="xx_hidden" value="tj_false" />

            <%-- <div class="tj_kk">
                <div class="dh_css">
                    <label>单号：</label><input type="text" name="orderid" />
                </div>
                <div class="ghf_css">
                    <label>供货方：</label><input type="text" name="gongsi" />
                </div>
                <div class="shf_css">
                    <label>收货方：</label><input type="text" name="shou_h" />
                </div>
                <div class="rq_css">
                    <label>日期：</label><input type="text" name="shijian" />
                </div>
             </div>--%>
            <%--<asp:Button ID="Button2" class="input_tr_sx" OnClick="bt_select_Click" Text="刷新数据" runat="server" />--%>
        </div>
        <input type="hidden" id="tj_pd_id" name="tj_pd" />
        <%-- <asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="bt_select_Click">
        </asp:DropDownList>--%>
        <table cellspacing="0" cellpadding="0" id="biao_ge" style="margin-top: 2%;" name="bg_row">
            <%--cellspacing="5" cellpadding="5"--%>

            <tr id="dj_yh">
                <td class="auto-style1" style="width: 25px; padding-left: 0.5%; font-size: 92%"></td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">商品id</td>
                <td class="auto-style1" style="width: 321px; padding-left: 1%; font-size: 92%">商品名称</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">商品数量</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">商品类别</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">数量</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">单价</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">金额</td>
                <td class="auto-style1" style="width: 45px; padding-left: 1%; border-right: 1px dashed #a8a8a8;">选择</td>
            </tr>
            <%
                List<ku_cun> ck_sp_select = Session["ck_sp_select"] as List<ku_cun>;
                if (ck_sp_select != null)
                {

                    for (int i = 0; i < ck_sp_select.Count; i++)
                    {                          
            %>
            <tr id="del_row0" class="dj_sj">
                <td style="font-size: 14px; padding-left:0.5%; width: 25px;"><%=(i+1) %></td>
                <td class="bg_bj" style="font-size:90%; padding-left:1%">
                    <input type="hidden" id="Hidden1" name="ck_spdm<%=i %>" value="<%=ck_sp_select[i].Sp_dm %>" />
                    <%=ck_sp_select[i].Sp_dm %>
                </td>
                <td class="bg_bj_mc" name="ck_name<%=i %>" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Name %>
                    <input type="hidden" id="Hidden2" name="ck_id<%=i %>" value="<%=ck_sp_select[i].Id %>" />
                    <input type="hidden" id="Text1" name="ck_name<%=i %>" value="<%=ck_sp_select[i].Name %>" />
                    
                </td>


                <td class="bg_bj" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Shu_liang %>
                </td>
                <td class="bg_bj" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Lei_bie %>
                    <input type="hidden" id="Hidden3" name="cp_lb<%=i %>" value="<%=ck_sp_select[i].Lei_bie %>" />
                </td>
               <%-- <td class="bg_bj" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Id %>
                </td>--%>

                <td class="bg_bj">
                    <input type="text" style="margin: 1px; width: 146px;" onchange="pdsl( <%=i %> , <%=ck_sp_select[i].Shu_liang %>)" id="ck_sl<%=i %>" name="ck_sl<%=i %>" value="" />
                </td>


                <td class="bg_bj">
                    <input type="text" style="margin: 1px; width: 146px;" id="ck_dj<%=i %>" name="ck_dj<%=i %>" value="" />
                </td>


                <td class="bg_bj" id="dj_js<%=i %>" style="font-size: 90%; padding-left: 1%; z-index: 7;" onclick="js_xx(<%=i %>)">
                    <%-- <input type="text" id="ck_je" name="ck_je0" /></td>           --%>
                    <td class="bg_xz" style="border-right: 1px dashed #a8a8a8;">


                        <input id="checkbox" style="margin-left: 30%;" name="Checkbox_bd<%=i %>" value=" <%=i %>" type="checkbox" />
                    </td>
            </tr>
            <%
                }
                }
            %>
        </table>
        <%--<asp:Button ID="Button1" class="rk_btu" OnClick="rk_pd" Text="出库" runat="server" />--%>
     <div class="tj_kk">

                <div class="dh_css" style="padding-left: 14.2%">
                    <label>单号：</label><input type="text" style="width: 6%" id="order_id" class="input_tr" name="orderid" />
                </div>
                <div class="ghf_css" style="padding-left: 6%">
                    <label>供货方：</label>
                    <select style="width: 13%" id="gh_f_id" class="input_tr" name="gongsi" >
                                                    <option>选择供货方</option>
                            <%
                                List<zl_and_jc_info> jichuc = Session["jichu"] as  List<zl_and_jc_info> ;
                                if (jichuc != null)
                                {
                                    for (int ji = 0; ji < jichuc.Count; ji++) 
                                    {
                                        if (jichuc[ji].id != "") 
                                        {
                                        %>
                                            <option value="<%=jichuc[ji].Gong_huo %>"><%=jichuc[ji].Gong_huo %></option>
                                        <%
                                        }
                                    }
                                }
                                 %>

                    </select>
                    <%--<input type="text" style="width: 10%" id="gh_f_id" class="input_tr" name="gongsi" />--%>
                </div>
                <div class="shf_css" style="">
                    <label>收货方：</label>
                    <select style="width: 12%" id="sh_f_id" class="input_tr" name="shou_h" >
                                                    <option>选择收货</option>
                            <%
                                List<zl_and_jc_info> jichub = Session["jichu"] as  List<zl_and_jc_info> ;
                                if (jichub != null)
                                {
                                    for (int ji = 0; ji < jichub.Count; ji++) 
                                    {
                                        if (jichub[ji].id != "") 
                                        {
                                        %>
                                            <option value="<%=jichub[ji].shou_huo %>"><%=jichub[ji].shou_huo %></option>
                                        <%
                                        }
                                    }
                                }
                                 %>

                    </select>
                    <%--<input type="text" style="width: 14%" id="sh_f_id" class="input_tr" name="shou_h" />--%>
                </div>
                <div class="rq_css" style="margin-left: 63%">
                    <label>日期：</label><input type="date" style="width: 29%" class="input_tr" name="shijian" />
                    <asp:Button OnClick="rk_pd" ID="dj_row" class="rk_btu" Text="出库" runat="server" />
                </div>

            </div>
        <div style="border: 1px solid #95b8e7; height: 90px; width: 79%; margin-top: -5%; margin-left: 11%;"></div>
        <div style="margin-top: -9%; margin-left: 13%; background-color: #ffffff; width: 7%; padding-left: 2%;">提交出库</div>
        </div>
    </form>
</body>
</html>
