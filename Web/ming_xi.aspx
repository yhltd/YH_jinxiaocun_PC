<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ming_xi.aspx.cs" Inherits="Web.ming_xi" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #biao_ge {
            /*margin: 0px auto;*/
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

        /*tr:nth-child(2n-1) input {
            background-color: #eeeeee;
        }

        tr:nth-child(2n) input {
            background-color: #ffffff;
        }


        #biao_ge tr:nth-of-type(odd) {
            background-color: #eeeef6;
        }*/

        .auto-style1 {
            color: black;
            height: 31px;
            font-size: 84%;
            background-color: #eeeef6;
            border-top: 1px dashed #a8a8a8;
        }


        td {
            border-left: 1px dashed #a8a8a8;
            border-bottom: 1px dashed #a8a8a8;
        }

        table {
            /*border: 1px dashed #a8A8A8;*/
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
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin-top: 3%;">
                <div style="background-color: #eeeeee; width: 44px; height: 24px;"></div>
                <div style="margin-top: -1.7%; margin-left: 4%; padding-bottom: 0.5%;">:入库</div>
                <div style="background-color: #ffffff; width: 44px; height: 24px;"></div>
                <div style="margin-top: -1.7%; margin-left: 4%; margin-bottom: -2.5%;">:出库</div>
            </div>
            <%--<asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="bt_select_Click">
            </asp:DropDownList>--%>
            <img class="new_mingxi" src="Myadmin/images/Resources/refresh_24.gif" />
            <asp:Button ID="Button2" class="qichu_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
               <img class="new_mingxisave" src="Myadmin/images/Resources/arrow.jpg" />
             <asp:Button ID="downexcel" class="qichu_input_tr_tj" OnClick="toExcel" Text="保存Excel" runat="server" />
            <div class="rq_css" style="margin-left: 63%; margin-top: -2.2%; margin-bottom: -8%;">
                <label style="margin-left: -35%;">起始日期：</label><input type="date" style="width: 27%" class="input_tr" name="time_qs" />
                <label style="margin-left: 9%;">截止日期：</label><input type="date" style="width: 27%" class="input_tr" name="time_jz" />
                   <img class="new_sslddivmingxi" src="Myadmin/images/Resources/newbookChecktb.jpg" />
                    <asp:Button ID="Button3" class="rk_btmingxifind" OnClick="rq_select" Text="查询" runat="server" />
            </div>


            <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: 8%;">
                <tr id="dj_yh">
                    <td class="auto-style1" style="width: 18px; padding-left: 1%;"></td>
                    <%--<td class="auto-style1" style="width: 69px; padding-left: 1%;">产品id</td>
                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">商品价格</td>--%>
                    <td class="auto-style1" style="width: 74px; padding-left: 1%;">订单号</td>
                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">商品代码</td>
                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">商品名称</td>
                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">商品类别</td>

                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">价格</td>
                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">数量</td>
                    <%--      <td class="auto-style1" style="width: 66px; padding-left: 1%;">用户名</td>--%>
                    <td class="auto-style1" style="width: 83px; padding-left: 1%;">明细类型</td>

                    <td class="auto-style1" style="width: 131px; padding-left: 1%;">时间</td>

                    <td class="auto-style1" style="width: 132px; padding-left: 1%;">公司名</td>
                    <td class="auto-style1" style="width: 132px; padding-left: 1%; border-right: 1px dashed #a8a8a8;">收货方</td>
                </tr>

                <%
               
                    List<ming_xi_info> ming_xi_select_dd = Session["ming_xi_select_dd"] as List<ming_xi_info>;
                    if (ming_xi_select_dd != null)
                    {
                        for (int i = 0; i < ming_xi_select_dd.Count; i++)
                        {                          
                %>
                <tr id="Tr1" class="tr_<%=ming_xi_select_dd[i].Openid %>">
                    <td style="font-size: 14px; padding-left: 0.5%; width: 18px;"><%=(i+1) %></td>
                    <%--<td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Cpid %></td>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Cpjg %></td>--%>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Orderid %></td>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].sp_dm %></td>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Cpname %></td>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Cplb %></td>

                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Cpsj %></td>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Cpsl %></td>
                    <%--   <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Finduser %></td>--%>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Mxtype %></td>

                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Shijian %></td>

                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%;"><%=ming_xi_select_dd[i].Gongsi %></td>
                    <td class="bg_bj" style="font-size: 84%; padding-left: 1%; border-right: 1px dashed #a8a8a8;"><%=ming_xi_select_dd[i].shou_h %></td>
                </tr>
                <%
                        }
                    }
                %>
            </table>
            <div style="margin-left: 41%; margin-top: 4%;">
                <asp:Button CssClass="input_tr" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="input_tr" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Button CssClass="input_tr" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="input_tr" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>




        </div>
    </form>
</body>
</html>
