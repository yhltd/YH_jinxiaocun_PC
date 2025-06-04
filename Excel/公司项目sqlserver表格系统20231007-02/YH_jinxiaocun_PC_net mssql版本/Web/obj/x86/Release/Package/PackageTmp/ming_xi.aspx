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
            display: flex;
            justify-content: space-around;
            width: 200px;
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
    </script>
    <form id="form1" runat="server">
        <div>
            <div class="d-header rq_css">
                
                
                <div class="select_div">
                    <label class="lable_select">起始日期：</label>
                    <input type="datetime-local" class="time_select" name="time_qs" />
                    <label class="lable_select">截止日期：</label>
                    <input type="datetime-local" class="time_select" name="time_jz" />
                    <asp:Button ID="Button3" class="qichu_input_tr_tj" OnClick="rq_select" Text="查询" runat="server" />
                </div>
                <div class="funcion_top">
                    <asp:Button ID="Button2" class="qichu_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
                    <asp:Button ID="downexcel" class="qichu_input_tr_tj" OnClick="toExcel" Text="保存Excel" runat="server" />

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
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
