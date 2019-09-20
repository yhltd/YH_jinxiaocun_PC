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
            if (c)
                $("#tj_pd_id").val("tj_true");
            else
                $("#tj_pd_id").val("tj_false");
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
            <asp:Button ID="Button2" class="input_tr_sx" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
        </div>
        <input type="hidden" id="tj_pd_id" name="tj_pd" />
        <%-- <asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="bt_select_Click">
        </asp:DropDownList>--%>
        <table cellspacing="0" cellpadding="0" id="biao_ge" style="margin-top: 2%;" name="bg_row">
            <%--cellspacing="5" cellpadding="5"--%>

            <tr id="dj_yh">
                <td class="auto-style1" style="width: 18px; padding-left: 1%; font-size: 92%"></td>
                <td class="auto-style1" style="width: 321px; padding-left: 1%; font-size: 92%">商品名称</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">成品数量</td>
                <td class="auto-style1" style="width: 148px; padding-left: 1%; font-size: 92%">商品id</td>
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
                <td style="font-size: 14px; padding-left: 0.5%; width: 18px;"><%=(i+1) %></td>
                <td class="bg_bj_mc" name="ck_name<%=i %>" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Name %>
                    <input type="hidden" id="Text1" name="ck_name<%=i %>" value="<%=ck_sp_select[i].Name %>" />
                    <input type="hidden" id="Hidden1" name="ck_id<%=i %>" value="<%=ck_sp_select[i].Id %>" />
                </td>


                <td class="bg_bj" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Shu_liang %>
                </td>
                <td class="bg_bj" style="font-size: 90%; padding-left: 1%;">
                    <%=ck_sp_select[i].Id %>
                </td>

                <td class="bg_bj">
                    <input type="text" style="margin: 1px; width: 146px;" id="ck_sl<%=i %>" name="ck_sl<%=i %>" value="" />
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
        <div class="tj_kk" style="margin-top: 9%;">

            <div class="dh_css" style="margin-top: -2.1%; padding-left: 14.2%;">
                <label>单号：</label><input type="text" style="width: 6%" class="input_tr" name="orderid" />
            </div>
            <div class="ghf_css" style="margin-top: -2.1%; padding-left: 29%;">
                <label>供货方：</label><input type="text" style="width: 10%" class="input_tr" name="gongsi" />
            </div>
            <div class="shf_css" style="margin-top: -2.1%; padding-left: 46%;">
                <label>收货方：</label><input type="text" style="width: 14%" class="input_tr" name="shou_h" />
            </div>
            <div class="rq_css" style="margin-top: -2.2%; margin-left: 63%;">
                <label>日期：</label><input type="date" style="width: 27%" class="input_tr" name="shijian" />
                <asp:Button ID="Button1" class="input_tr_ck" OnClick="rk_pd" Text="出库" runat="server" />
            </div>

        </div>
        <div style="border: 1px solid #95b8e7; height: 90px; width: 79%; margin-top: -5%; margin-left: 11%;"></div>
        <div style="margin-top: -9%; margin-left: 13%; background-color: #ffffff; width: 7%; padding-left: 2%;">提交入库</div>
        </div>
    </form>
</body>
</html>
