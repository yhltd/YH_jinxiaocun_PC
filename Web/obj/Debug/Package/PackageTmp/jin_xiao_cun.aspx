<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jin_xiao_cun.aspx.cs" Inherits="Web.jin_xiao_cun" %>

<%@ Import Namespace="SDZdb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <script>

        function aaa(row) {
            var inputValue = document.getElementById("cun_liang" + row).value;
            if (inputValue <= 20) {
                document.getElementById("ti_xing" + row).style.backgroundColor = "red";

            } else {
                document.getElementById("ti_xing" + row).style.backgroundColor = "green";

            }

            //$("#dj_js" + row).text($("#ck_sl" + row).val() * $("#ck_dj" + row).val());


        }
    </script>
    <title></title>
    <style type="text/css">
        .bk_nr {
            height: 21px;
            font-size: 1%;
            padding-left: 1%;
        }

        .bk_bt {
            border-top: 1px dashed #a8a8a8;
            padding-left: 1%;
            font-size: 92%;
            color: black;
            width: 47px;
            height: 33px;
            background-color: #eeeeee;
        }

        bk_bt_t {
            border-top: 1px dashed #a8a8a8;
            padding-left: 1%;
            font-size: 92%;
            color: black;
            width: 84px;
            height: 33px;
            background-color: #eeeeee;
        }

        .hidden_load {
            display: none;
        }

        td {
          border-left: 1px dashed #a8a8a8;
border-bottom: 1px dashed #a8a8a8;
        }

        table {
            /*border: 1px dashed #a8A8A8;*/
        }


        tr:nth-child(2n-1) input {
            background-color: #eeeef6;
            /*偶数input*/
        }

        tr:nth-child(2n) input {
            /*奇数input*/
            background-color: #ffffff;
        }


        .biao_ge tr:nth-of-type(odd) {
            background-color: #eeeef6;
            /*偶数行*/
        }

        .biao_ge tr:nth-of-type(even) {
            /*奇数行*/
        }

          input{
            
          
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
    
            input:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        .input_tr {
        margin-top: 2%;
        /*margin-left: 3%;*/
        border: 1px solid #ccc;
        -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
        box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
        -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
        -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Button ID="Button2" class="input_tr" OnClick="jxc_load" Text="刷新数据" runat="server" />
           <%-- <asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="jxc_load">
            </asp:DropDownList>--%>
            <asp:Button ID ="downexcel" class="input_tr" OnClick="toExcel" Text="保存至excel" runat="server" />
            <div class="sp_css" style=" position: absolute;width: 100%;left: 85%;top: -2%;">
                <label style="margin-left: -35%;">商品代码：</label><input type="text" style="width: 10%;margin-right: 3%;"class="input_tr" name="sp_dm" />
                <span><label>商品名称：</label><input type="text" style="width: 10%" class="input_tr" name="sp_mc" /></span>
            </div>
            <div class="rq_css" style="margin-left: 63%;margin-top: -2.2%;margin-bottom: -2%;">
                
                <label style="margin-left: -35%;">起始日期：</label><input type="date" style="width: 27%" class="input_tr" name="time_qs" />
                  <label style="margin-left: 9%;">截止日期：</label><input type="date" style="width: 27%" class="input_tr" name="time_jz" />
                <asp:Button ID="Button1" class="input_tr_ck" OnClick="time_select" Text="查询" runat="server" />
            </div>

            <div>
                <table cellspacing="0" cellpadding="0" id="Table4" style="margin-left: 31.98%; margin-bottom: -8.1%; margin-top: 5%;">
                    <tr id="Tr8">
                        <td class="" style="background-color: #eeeeee; width: 133px;border-top: 1px dashed #a8a8a8;padding-left:10px;">期初</td>
                        <td class="" style="background-color: #eeeeee; width: 133px;border-top: 1px dashed #a8a8a8;padding-left:10px;">进货</td>
                        <td class="" style="background-color: #eeeeee; width: 133px;border-top: 1px dashed #a8a8a8;padding-left:10px;">出货</td>
                        <td class="" style="background-color: #eeeeee; width: 335px;border-top: 1px dashed #a8a8a8;padding-left:10px;border-right: 1px dashed #a8a8a8;">结存</td>
                    </tr>

                </table>
                <table cellspacing="0" cellpadding="0" class="biao_ge" name="bg_row" style="margin-top: 8%; margin-left: 0%;">
                    <tr id="dj_yh">
                        <td class="bk_bt_t" style="padding-left: 1%; width: 18px;border-top: 1px dashed #a8a8a8;"></td>
                        <td class="bk_bt_t" style="padding-left: 1%; width: 100px;border-top: 1px dashed #a8a8a8;">商品代码</td>
                        <td class="bk_bt_t" style="padding-left: 1%; width: 157px;border-top: 1px dashed #a8a8a8;">商品名称</td>
                        <td class="bk_bt_t" style="padding-left: 1%; width: 100px;border-top: 1px dashed #a8a8a8;">商品类别</td>
                        <td class="bk_bt">数量</td>
                        <td class="bk_bt">单价</td>
                        <td class="bk_bt">金额</td>
                        <td class="bk_bt">数量</td>
                        <td class="bk_bt">单价</td>
                        <td class="bk_bt">金额</td>
                        <td class="bk_bt">数量</td>
                        <td class="bk_bt">单价</td>
                        <td class="bk_bt">金额</td>
                        <td class="bk_bt">结存</td>
                        <td class="bk_bt">单价</td>
                        <td class="bk_bt">金额</td>
                        <td style="background-color:#eeeeee;padding-left: 1%; width: 100px;border-top: 1px dashed #a8a8a8;">边缘存量</td>
                        <td class="" style="background-color:#eeeeee;border-right: 1px dashed #a8a8a8;border-top: 1px dashed #a8a8a8;padding-left: 1%;width: 50px;">缺货提醒</td>
                    </tr>
                    <%
               
                        List<jxc_z_info> jxc_z_select = Session["jxc_z_select"] as List<jxc_z_info>;
                        if (jxc_z_select != null)
                        {
                            for (int i = 0; i < jxc_z_select.Count; i++)
                            {                          
                    %>
                    <tr id="Tr1">
                        <td style="font-size: 12px;padding-left: 0.5%;width: 18px;"><%=(i+1) %></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Sp_dm%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Name%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Lei_bie%></td>


                        <td class="bk_nr"><%=jxc_z_select[i].Cpsl_3%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Cpsj_3%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Cpje_3%></td>


                        <td class="bk_nr"><%=jxc_z_select[i].Cpsl_1%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Cpsj_1%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Cpje_1%></td>


                        <td class="bk_nr"><%=jxc_z_select[i].Cpsl_2%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Cpsj_2%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].Cpje_2%></td>

                        <td class="bk_nr"><%=jxc_z_select[i].jc_jc%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].jc_dj%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].jc_je%></td>
                        <td class="bk_nr"><%=jxc_z_select[i].yl_tx%></td>
                        <%
                                if (jxc_z_select[i].yl_tx == "")
                                { 
                        %>

                        <td style="background-color: red;border-right: 1px dashed #a8a8a8;"></td>
                        <%
                                
                                }
                                else if (Convert.ToInt32(jxc_z_select[i].yl_tx) <= 20)
                                {
                            
                        %>

                        <td style="background-color: red;border-right: 1px dashed #a8a8a8;"></td>
                        <%
                                }
                                else
                                {
                        %>

                        <td style="background-color: green;border-right: 1px dashed #a8a8a8;"></td>
                        <%
                                
                                }
                        %>
                    </tr>
                    <%
                 
                            }
                        }
                    %>
                </table>



            </div>

        </div>
    </form>
</body>
</html>
