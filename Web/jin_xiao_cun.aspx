<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jin_xiao_cun.aspx.cs" Inherits="Web.jin_xiao_cun" %>

<%@ Import Namespace="SDZdb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <script src="/Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
    </script>
    <title></title>
    <style type="text/css">
        .top-fun {
            width: 100%;
            height: 50px;
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            align-items: center;
        }

        .input_tr {
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            margin-left: 10px;
        }

        .table_div {
            width: 100%;
            overflow: scroll;
        }

        .bk_bt {
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
        }

        .bk_bt2 {
            height: 25px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
        }

        .auto-style1 {
            text-align: center;
            height: 35px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 4px;
        }

        .time_select {
            width: 150px;
            height: 30px;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
        }

        .input_select {
            width: 150px;
            border: none;
            height: 30px;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
        }

        .none {
            background-color: none;
        }

        .page_bt {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
            cursor: pointer;
        }

        .bottom {
            top: 25px;
        }

        .top-fun-item {
            display: flex;
            align-items: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="top-fun">
                <div class="top-fun-item">
                    <label class="top-text">商品代码：</label>
                    <input type="text" class="input_select" name="code" />
                    <label class="top-text">起始日期：</label>
                    <%--<input type="date" class="time_select" name="time_start" />--%>
                    <asp:TextBox ID="txtCompletionTime" runat="server"
                        class="time_select" onClick="WdatePicker()" name="time_start" onfocus="WdatePicker({skin:'whyGreen',maxDate:'%y-%M-%d'})" OnTextChanged="txtCompletionTime_TextChanged" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
            
                    <label class="top-text">截止日期：</label>
                  <%--  <input type="date" class="time_select" name="time_end" />--%>
                     <asp:TextBox ID="txttime_end" runat="server"
                        class="time_select" onClick="WdatePicker()" name="time_end" OnTextChanged="txtCompletionTime_TextChanged" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
            
                    <asp:Button ID="Button1" class="input_tr" OnClick="jxc_select" Text="查询" runat="server" />
                    <asp:Button ID="Button2" class="input_tr" OnClick="jxc_load" Text="刷新数据" runat="server" />
                </div>
                <div class="top-fun-item">
                    <asp:Button ID="downexcel" class="input_tr" OnClick="toExcel" Text="保存至excel" runat="server" />
                </div>
            </div>

            <div class="table_div">
                <table cellspacing="0" cellpadding="0" class="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="Tr1">
                        <th colspan="1" rowspan="2" class="bk_bt2">序号</th>
                        <th colspan="1" rowspan="2" class="bk_bt2" style="width: 130px">商品代码</th>
                        <th colspan="1" rowspan="2" class="bk_bt2" style="width: 150px">商品名称</th>
                        <td colspan="1" rowspan="2" class="bk_bt2">商品类别</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 140px">期初</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 140px">入库</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 140px">出库</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 140px">结存</td>
                        <th colspan="1" rowspan="2" class="bk_bt2">边缘存量</th>
                    </tr>
                    <tr id="dj_yh">
                        <th class="bk_bt2 bottom" style="width: 70px">数量</th>
                        <th class="bk_bt2 bottom" style="width: 70px">金额</th>
                        <th class="bk_bt2 bottom" style="width: 70px">数量</th>
                        <th class="bk_bt2 bottom" style="width: 70px">金额</th>
                        <th class="bk_bt2 bottom" style="width: 70px">数量</th>
                        <th class="bk_bt2 bottom" style="width: 70px">金额</th>
                        <th class="bk_bt2 bottom" style="width: 70px">结存</th>
                        <th class="bk_bt2 bottom" style="width: 70px">金额</th>
                    </tr>
                    <%
               
                        System.Collections.Generic.List<jxc_z_info> jxc_z_select = Session["jxc_z_select"] as System.Collections.Generic.List<jxc_z_info>;
                        if (jxc_z_select != null)
                        {
                            for (int i = 0; i < jxc_z_select.Count; i++)
                            {                          
                    %>
                    <tr class="dj_yh">
                        <td class="auto-style1"><%=(i+1) %></td>
                        <td class="auto-style1"><%=jxc_z_select[i].sp_dm%></td>
                        <td class="auto-style1"><%=jxc_z_select[i].name%></td>
                        <td class="auto-style1"><%=jxc_z_select[i].lei_bie%></td>


                        <td class="auto-style1"><%=jxc_z_select[i].jq_cpsl%></td>
                        <td class="auto-style1"><%=jxc_z_select[i].jq_price%></td>


                        <td class="auto-style1"><%=jxc_z_select[i].mx_ruku_cpsl%></td>
                        <td class="auto-style1"><%=jxc_z_select[i].mx_ruku_price%></td>


                        <td class="auto-style1"><%=jxc_z_select[i].mx_chuku_cpsl%></td>
                        <td class="auto-style1"><%=jxc_z_select[i].mx_chuku_price%></td>

                        <td class="auto-style1"><%=jxc_z_select[i].jc_sl%></td>
                        <td class="auto-style1"><%=jxc_z_select[i].jc_price%></td>

                        <td class="auto-style1"><%=jxc_z_select[i].stock%></td>
                    </tr>
                    <%
                 
                            }
                        }
                    %>
                </table>
            </div>
            <div style="width: 300px; height: 70px; display: flex; justify-content: space-around; align-items: center;">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Label runat="server" ID="lblCurrentPage" Style="font-weight: bold"></asp:Label>
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
