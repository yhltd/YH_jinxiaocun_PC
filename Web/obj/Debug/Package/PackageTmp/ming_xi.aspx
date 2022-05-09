<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ming_xi.aspx.cs" Inherits="Web.ming_xi" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #biao_ge {
            width: 100%;
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
            font-size:4px;
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
        .page_bt {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
        }
    </style>
    <title></title>
</head>
<body>
    <script type="text/ecmascript">
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

        $(document).ready(function () {
            var row = 1;
            $("#dj_yh").click(function () {

                var rowLength = $("#biao_ge tr").length;

                var insertStr = "<tr id='del_row" + row + "' >"
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 70px;'>" + rowLength + "</td>"
                               + "<td ><input type='text' class='input_tr' style='width: 130px;margin:0.2%;' name='sp_dm" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='name" + row + "' ></input></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='lei_bie" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='dan_wei" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='shou_huo" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width: 160px;margin:0.2%;' class='input_tr' name='gong_huo" + row + "' ></input></td>"
                               + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button' style='width: 70px;margin:0.2%;' class='rk_btu'value='删除' style='margin-left: 3px;'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
            });


        });



    </script>
    <form id="form1" runat="server">
        <div>
            <div class="d-header rq_css">
                
                
                <div class="select_div">
                    <label class="lable_select">起始日期：</label>
                    <input type="datetime-local" class="time_select" name="time_qs" />
                    <label class="lable_select">截止日期：</label>
                    <input type="datetime-local" class="time_select" name="time_jz" />
                    <asp:Button ID="Button3" class="mingxi_input_tr_tj" OnClick="rq_select" Text="查询" runat="server" />
                 

                  <asp:Button ID="del_mx_btu" OnClick="del_mingxi" class="mingxi_input_tr_tj" Text="删除" runat="server" />

                    <asp:Button ID="Button2" class="mingxi_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
                </div>
                <div class="funcion_top">
                    <asp:Button ID="downexcel" class="mingxi_input_tr_tj" OnClick="toExcel" Text="保存至Excel" runat="server" />
                </div>
            </div>

            <div class="d-main table_div" style="width:100%;overflow:scroll;">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row">
                    <tr id="dj_yh">                     
                        <td class="auto-style1" style="width: 50px">序号</td>
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
                        <td class="bg_bj"><%=(i+1) %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].orderid %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].sp_dm %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].cpname %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].cplb %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].cpsj %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].cpsl %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].mxtype %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].shijian.GetValueOrDefault().ToString("g") %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].zh_name %></td>
                        <td class="bg_bj"><%=ming_xi_select_dd[i].shou_h %></td>
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
        </div>
    </form>
</body>
</html>
