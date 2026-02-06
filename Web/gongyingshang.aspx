<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gongyingshang.aspx.cs" Inherits="Web.gongyingshang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />

    <script>
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
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 50px;'>" + rowLength + "</td>"
                               + "<td ><input type='text' class='input_tr' style='width: 150px;margin:0.2%;' name='beizhu" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'><input type='text' style='width: 150px;margin:0.2%;' class='input_tr' name='lianxidizhi" + row + "' ></input></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width: 150px;margin:0.2%;' class='input_tr' name='lianxifangshi" + row + "' ></input></td>"
                               + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button' style='width: 50px;margin:0.2%;' class='rk_btu'value='删除'  onclick='del_row(" + row + ")'/></td>"
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
            if (document.getElementById("xx_hidden").value == "tj_false") {
                return false;
            } else {
            }
        })

    </script>

    <style type="text/css">
        .input_tr
        {
            border: none;
            height: 90%;
            width: 90%;
            text-align:center;
        }

        td
        {
            text-align: center;
            height: 40px;
            background-color: white;
            font-size: 4px;
        }

        .auto-style1
        {
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

        .input_tr_sc
        {
        }

        .input_tr_tj
        {
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            margin-left: 10px;
        }

        .input_tr {
            text-align: center;
            height: 40px;
            color:black;
            font-size:14px;
            background-color: #98c9d9;
            /*border: 2.5px solid white;*/
        }
        
        /* 奇数行样式 */
        tr:nth-child(odd) .input_tr {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .input_tr {
            background-color: #e0f7fa; 
        }

                /* 奇数行样式 */
        tr:nth-child(odd) .bg_bj {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .bg_bj {
            background-color: #e0f7fa; 
        }

        .top-div
        {
            width: 100%;
            height: 50px;
            display: flex;
            flex-direction: row;
            justify-content: start;
            align-items: center;
        }
        .select_input {
            width: 300px;
            border: none;
            height: 64%;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
            /*margin-top:20px;*/
        }

          .table_div {
            overflow:auto;
            margin-left:1%;
            margin-top:10px;
            box-sizing: border-box;
           padding-left:5px;
            padding-right:5px;
            width:97%;
            height:80%;
            border:3px solid #D3D3D3;
             box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
            
        }
        .top-div {
            margin-left:1%;
            margin-top:10px;
            padding:5px;
            width:97%;
            min-height:50px;
           background: linear-gradient(135deg, #3030c7 0%, #2424a1 50%, #a8a8d2 100%);
           border-radius:5px;
           box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
           
        }


    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="xx_hidden" value="tj_false" />
            <div class="top-div">
                <asp:TextBox ID='gys_cx_a' class='select_input' Autocomplete='off'  runat="server" placeholder="按供应商名称查询"/>
                <asp:Button  ID="gys_query" OnClick="gys_chaxun" class="input_tr_tj" Text="查询" runat="server" />
                <input type="button" id="dj_yh" class="input_tr_tj" value="添加">
                <asp:Button  ID="dj_row" class="input_tr_tj" onclick="gys_tj" Text="提交" runat="server" />
                <asp:Button  ID="del_button" class="input_tr_tj" OnClick="delete" Text="删除" runat="server" />
                <asp:Button ID="Button2" class="input_tr_tj" OnClick="gys_select_load"  Text="刷新数据" runat="server" />
            </div>
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <input type="hidden" id="row_i1" name="row_i" />
            <div class="table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="dj_yh">
                        <th class="auto-style1" style="width: 50px">序号</th>
                        <th class="auto-style1" style="width: 150px">供应商</th>
                        <th class="auto-style1" style="width: 150px">联系地址</th>
                        <th class="auto-style1" style="width: 150px">联系方式</th>
                        <th class="auto-style1" style="width: 50px">功能</th>
                    </tr>
                    <%
                        System.Collections.Generic.List<Web.Server.yh_jinxiaocun_jinhuofang> gys = Session["gys_select"] as System.Collections.Generic.List<Web.Server.yh_jinxiaocun_jinhuofang>;
                        if (gys != null)
                        {
                            for (int i = 0; i < gys.Count; i++)
                            {                          
                    %>
                    <tr id="del_row_cs<%=i %>">
                        <%--style="font-size: 90%; padding-left: 2%;"--%>
                        <td style="font-size: 14px; padding-left: 0.5%; width: 22px;"class="input_tr"><%=(i+1) %></td>
                        <td class="bg_bj">
                            <input type="text"class="input_tr" id="beizhu" name="beizhu_cs<%=i %>" value="<%=gys[i].beizhu %>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="lianxidizhi" name="lianxidizhi_cs<%=i %>" value="<%=gys[i].lianxidizhi %>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="lianxifangshi" name="lianxifangshi_cs<%=i %>" value="<%=gys[i].lianxifangshi %>" /></td>
                        <td class="bg_bj">
                            <input type="hidden" class="input_tr" id="Text3" name="id_cs<%=i %>" value="<%=gys[i]._id %>" /><input id="checkbox" name="Checkbox_bd<%=i %>" value=" <%=i %>" type="checkbox" /></td>
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
