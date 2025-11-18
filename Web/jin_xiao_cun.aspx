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

        function Enter(e) {
            if (e.keyCode == 13) {
                alert("触发")
                select_btn = document.getElementById("Button1")
                var test = document.getElementById("order_code_text").value;
                console.log(test)
                $.ajax({
                    type: 'Post',
                    url: 'chu_ku.aspx',
                    data: {
                        act: 'checkOrder_mingxi',
                        order_id: test,
                    },
                    dataType: 'json',
                    success: function (result) {
                        var mingxi_list = result;
                        console.log(mingxi_list)
                        var sql = ""
                        for (var i = 0; i < mingxi_list.length; i++) {
                            if (mingxi_list[i].sp_dm != null && mingxi_list[i].sp_dm != "") {
                                if (sql == "") {
                                    sql = "where sp_dm ='" + mingxi_list[i].sp_dm + "'"
                                } else {
                                    sql = sql + "or sp_dm ='" + mingxi_list[i].sp_dm + "'"
                                }
                            }
                        }
                        document.getElementById("shangpindaima").value = sql
                        select_btn.onclick();
                    }
                });
                
            }
        }

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
           margin-left: 10px;
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            display: inline-block;
            transition: all 0.4s cubic-bezier(0.165, 0.84, 0.44, 1);
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
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
            height: 49px;
            text-align: center;
            /*background-color: #2F4056;*/
            background-color:#143268;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
            /*border:1px solid white;*/
            top : 0;
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




        
        .auto-style1 {
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
        tr:nth-child(odd) .auto-style1 {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .auto-style1 {
            background-color: #e0f7fa; 
        }


        .table_div{
            overflow:auto;
            margin-left:1%;
            margin-top:10px;
            box-sizing: border-box;
            padding-left:5px;
            padding-right:5px;
            width:98%;
            height:80%;
            border:3px solid #D3D3D3;
             box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
            
        }
        .top-fun {
            margin-left:1%;
            margin-top:10px;
            padding:5px;
            width:97%;
            min-height:50px;
           background-color: #D3D3D3;
           border-radius:5px;
           box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
           
        }



    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="top-fun">
                <div class="top-fun-item">
                    <label class="top-text">商品代码：</label>
                    <input id="shangpindaima" type="text" class="input_select" name="code" />
                    <label class="top-text">起始日期：</label>
                    <%--<input type="date" class="time_select" name="time_start" />--%>
                    <asp:TextBox ID="txtCompletionTime" runat="server"
                        class="time_select" onClick="WdatePicker()" name="time_start" onfocus="WdatePicker({skin:'whyGreen',maxDate:'%y-%M-%d'})" OnTextChanged="txtCompletionTime_TextChanged" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
            
                    <label class="top-text">截止日期：</label>
                  <%--  <input type="date" class="time_select" name="time_end" />--%>
                     <asp:TextBox ID="txttime_end" runat="server"
                        class="time_select" onClick="WdatePicker()" name="time_end" OnTextChanged="txtCompletionTime_TextChanged" autocomplete="off" AutoCompleteType="Disabled"></asp:TextBox>
            
                    <asp:Button ID="Button1" class="input_tr" OnClick="jxc_select" Text="查询" runat="server" UseSubmitBehavior="false"/>
                    <asp:Button ID="Button2" class="input_tr" OnClick="jxc_load" Text="刷新数据" runat="server" UseSubmitBehavior="false"/>
                    <input id='order_code_text' class='input_select' autocomplete='off' placeholder='扫码订单二维码' style="margin-left:5px;" onkeypress="Enter(event)"/>
                </div>
                <div class="top-fun-item">
                    <asp:Button ID="downexcel" class="input_tr" OnClick="toExcel" Text="保存至excel" runat="server" UseSubmitBehavior="false"/>
                </div>
            </div>

            <div class="table_div">
                <table cellspacing="0" cellpadding="0" class="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="Tr1">
                        <th colspan="1" rowspan="2" class="bk_bt2" style="width: 10%">序号</th>
                        <th colspan="1" rowspan="2" class="bk_bt2" style="width: 10%">商品代码</th>
                        <th colspan="1" rowspan="2" class="bk_bt2" style="width: 11%">商品名称</th>
                        <td colspan="1" rowspan="2" class="bk_bt2" style="width: 11%">商品类别</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 12%">期初</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 12%">入库</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 12%">出库</td>
                        <td colspan="2" rowspan="1" class="bk_bt2" style="width: 12%">结存</td>
                        <th colspan="1" rowspan="2" class="bk_bt2" style="width: 10%">边缘存量</th>
                    </tr>
                    <tr id="dj_yh">
                        <th class="bk_bt2 bottom" style="width: 6%">数量</th>
                        <th class="bk_bt2 bottom" style="width: 6%">金额</th>
                        <th class="bk_bt2 bottom" style="width: 6%">数量</th>
                        <th class="bk_bt2 bottom" style="width: 6%">金额</th>
                        <th class="bk_bt2 bottom" style="width: 6%">数量</th>
                        <th class="bk_bt2 bottom" style="width: 6%">金额</th>
                        <th class="bk_bt2 bottom" style="width: 6%">结存</th>
                        <th class="bk_bt2 bottom" style="width: 6%">金额</th>
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
            <div style="width: 300px; height: 70px; display: none; justify-content: space-around; align-items: center;">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" UseSubmitBehavior="false"/>
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" UseSubmitBehavior="false"/>
                <asp:Label runat="server" ID="lblCurrentPage" Style="font-weight: bold"></asp:Label>
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" UseSubmitBehavior="false"/>
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" UseSubmitBehavior="false"/>
            </div>
        </div>
    </form>
</body>
</html>
