<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qi_chu.aspx.cs" Inherits="Web.qi_chu" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
        <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        function bhhq(row) {
            $.ajax({
                type: "post",
                url: "qi_chu.aspx?act=PostUser&id=" + $("#sp_dm" + row).val(),
                dataType: "json",
                data: {},
                success: function (data) {
                    $("#sp_cplb" + row).val(data.lei_bie)
                    $("#sp_name" + row).val(data.name)
                },
                error: function (err) {

                }
            });
        }
        function js_xx(row) {

            $("#dj_js" + row).text($("#ck_sl" + row).val() * $("#ck_dj" + row).val());


        }

        function js_xx2(row) {


            $("#dj_js" + row).text($("#ck_dj" + row).val() * $("#ck_sl" + row).val());


        }

        function heji() {
            var pMsg = 0;
            var tableObj = document.getElementById("biao_ge");
            for (i = 1; i < tableObj.rows.length; i++) {
                if (tableObj.rows[i].cells[6].innerText != "") {
                    pMsg += parseFloat(tableObj.rows[i].cells[6].innerText);
                }
            }
            $('#heji').html("合计："+pMsg);
        }

        $(function () {
            heji();

            $("#dj_row").click(function () {

                $("#row_i1").val($("#biao_ge tr").length);

            })

        })



        function test(obj) {
            var v = $(obj).select.length();
            alert(v);
        }


        function del_row(row) {
            var rowIndex = $("#del_row_cs1").context.rowIndex;
            $("#del_row" + row + "").remove();
        }

        $(document).ready(function () {
            var row = 1;
            $("#dj_yh").click(function () {

                var rowLength = $("#biao_ge tr").length;
                var insertStr = "<tr id='del_row" + row + "' >"
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 18px;'>" + (rowLength) + "</td>"
                               + "<td class='bg_bj_sj'></td>"
                               + "<td ><input type='text' class='input_tr' style='width:147px;margin:1px'  id='sp_name" + row + "' name='cpname" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'>"
                               + "<select class='input_tr' id='sp_dm" + row + "' name='cpid" + row + "' onchange='bhhq(" + row + ")'>"
                            + "<option>选择编号</option>"
                            +<%
        System.Collections.Generic.List<Web.ServerEntity.JinChuZiLiaoItem> jichu = Session["jichu"] as System.Collections.Generic.List<Web.ServerEntity.JinChuZiLiaoItem>;
                                if (jichu!=null){
                                    for (int ji = 0; ji < jichu.Count; ji++) 
                                    {
                                        %>
                                            + "<option value ='<%=jichu[ji].sp_dm %>'><%=jichu[ji].sp_dm %></option>"
                                            <%
                                    }
                                }
                                 %>

                        + "</select></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width:147px;margin:1px' id='sp_cplb" + row + "' class='input_tr' name='cplb" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width:147px;margin:1px'  id='ck_dj" + (rowLength - 1) + "' class='input_tr' name='cpsj" + row + "' ></input></td>"
                               + "<td class='bg_bj_sl'><input type='text' style='width:147px;margin:1px'  id='ck_sl" + (rowLength - 1) + "' class='input_tr' name='cpsl" + row + "' ></input></td>"
                               + "<td onclick='js_xx2(" + (rowLength - 1) + ")' id='dj_js" + (rowLength - 1) + "' style='width:147px;margin:1px'></td>"
                               + "<td  style='border-right: 1px dashed #a8a8a8;'><input type='button' class='qc_sc'value='删除'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
                $('#row_i1').val(row);
            });
            function click(obj) {
                alert($(obj).context.innerHTML);
            }

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


        function getJs(row) {
            $('#dj_js' + row).text($('#ck_dj' + row).val() * $('#ck_sl' + row).val())
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

        .hidden_load {
            display: none;
        }

        td
        {
            text-align: center;
            height: 40px;
            background-color: white;
            font-size: 10px;
        }

        .qc_sc {
            margin-left: 1px;
        }
        .new_cuku {
            width: 28px ;
        }
        .table_div
        {
            width:100%;
            overflow:scroll;
        }
        .fun_div
        {
            width: 100%;
            height: 50px;
            display: flex;
            flex-direction: row;
            justify-content: start;
            align-items: center;
        }


         .page_bt {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
        }
        .auto-style1 {
            height: 49px;
            text-align: center;
            /*background-color: #2F4056;*/
            background-color:#143268;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position:sticky;
            /*border:1px solid white;*/           
        }



        .item_td {
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
        tr:nth-child(odd) .item_td {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .item_td {
            background-color: #e0f7fa; 
        }

        
        .qichu_input {
            margin-top:10px;
            margin-left: 10px;
            width: 80px;
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
        .table_input {
            border: none;
            color:black;
            height: 90%;
            width: 90%;
        }
         /* 奇数行样式 */
        tr:nth-child(odd) .table_input {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .table_input {
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

                 /* 奇数行样式 */
        tr:nth-child(odd) .bg_bj {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .bg_bj {
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

        .input_tr {
            border: none;
            text-align: center;
            color:black;
            width: 90%;
            height: 90%;
        }
         /* 奇数行样式 */
        tr:nth-child(odd) .input_tr {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .input_tr {
            background-color: #e0f7fa;  /* 更浅的蓝色 */
        }

        .select_input {
            width: 200px;
            border: none;
            height: 64%;
            border: 1px solid white;
            border-radius: 3px;
        }


        .d-main.table_div {
            overflow:auto;
            margin-left:1%;
            margin-top:30px;
            box-sizing: border-box;
            padding-left:5px;
            padding-right:5px;
            width:97.5%;
            height:80%;
            border:3px solid #D3D3D3;
             box-shadow: 
                0 4px 6px rgba(0, 0, 0, 0.1),
                0 1px 3px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.2),
                inset 0 -1px 0 rgba(0, 0, 0, 0.1);
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
            
        }
        .d-header {
            margin-left:1%;
            margin-top:10px;
            padding:5px;
            width:97%;
            height: 50px;
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
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="xx_hidden" value="tj_false" />
            <input type="hidden" id="row_i1" name="row_i" />
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <div class="d-header">
                <%--<input id='ru_cx' class='select_input' autocomplete='off'  placeholder='按商品名称/商品代码搜索' />--%>
                <asp:TextBox ID='qc_cx' class='select_input' Autocomplete='off'  runat="server" placeholder="按商品名称搜索"/>
                <asp:Button  ID="qc_query" OnClick="bt_chaxun" class="qichu_input" Text="查询" runat="server" UseSubmitBehavior="false" />
                <asp:Button OnClick="qc_tj" ID="dj_row" class="qichu_input" Text="提交" runat="server" UseSubmitBehavior="false" />
                <asp:Button OnClick="del_qichu" ID="del_qc_btu" class="qichu_input" Text="批量删除" runat="server" UseSubmitBehavior="false" />
                <asp:Button ID="Button2" class="qichu_input" OnClick="bt_select_Click" Text="刷新数据" runat="server" UseSubmitBehavior="false" />
            </div>
            <div class="d-main table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: 1%;">
                    <tr id="dj_yh">
                        <td class="auto-style1" style="width: 10%;">序号</td>
                        <th class="auto-style1" style="width: 13%">图片</th>
                        <td class="auto-style1" style="width: 13%;">商品名称</td>
                        <td class="auto-style1" style="width: 13%;">商品代码</td>
                        <td class="auto-style1" style="width: 11%;">商品类别</td>
                        <td class="auto-style1" style="width: 10%;">商品售价</td>
                        <td class="auto-style1" style="width: 10%;">商品数量</td>
                        <td class="auto-style1" style="width: 10%">金额</td>
                        <td class="auto-style1" style="width: 10%;">功能</td>
                    </tr>
                    <%
                        System.Collections.Generic.List<Web.Server.yh_jinxiaocun_qichushu> qi_chu_select = Session["qi_chu_select"] as System.Collections.Generic.List<Web.Server.yh_jinxiaocun_qichushu>;
                        if (qi_chu_select != null)
                        {
                            for (int i = 0; i < qi_chu_select.Count; i++)
                            {
                                if (qi_chu_select[i].mark1 != null && qi_chu_select[i].mark1 != "")
                                {
                                    qi_chu_select[i].mark1 = "data:image/jpg;base64," + qi_chu_select[i].mark1;
                                } 
                    %>
                    <tr id="del_row_cs<%=i%>">
                        <%--style="font-size: 90%; padding-left: 2%;"--%>
                        <td style="font-size: 14px; padding-left: 0.5%; width: 18px;"class="input_tr"><%=(i+1) %>
                            <input class="input_tr" type="hidden" id="id<%=i%>" name="id<%=i%>" value="<%=qi_chu_select[i]._id%>" />
                        </td>
                        <td class="bg_bj">
                        <img style="width: 60px;"  src="<%=qi_chu_select[i].mark1%>"/></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="sp_name" name="cpname_cs<%=i%>" value="<%=qi_chu_select[i].cpname%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="Text1" name="cpid_cs<%=i%>" value="<%=qi_chu_select[i].cpid%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="Text2" name="cplb_cs<%=i%>" value="<%=qi_chu_select[i].cplb%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" onchange="getJs(<%=i%>)" id="ck_dj<%=i%>" name="cpsj_cs<%=i%>" value="<%=qi_chu_select[i].cpsj%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" onchange="getJs(<%=i%>)" id="ck_sl<%=i%>" name="cpsl_cs<%=i%>" value="<%=qi_chu_select[i].cpsl%>" /></td>
                        <td class="bg_bj" id="dj_js<%=i%>" class="input_tr" >
                            <input type="text" class="input_tr" value=" <%=qi_chu_select[i].cpsj == "" || qi_chu_select[i].cpsl == "" ? 0 : int.Parse(qi_chu_select[i].cpsj)*int.Parse(qi_chu_select[i].cpsl)%>" />
                        </td>
                        <td class="bg_bj" style="width: 43px;">
                            <input id="checkbox" name="Checkbox_bd<%=i%>" value=" <%=i%>" type="checkbox" />
                        </td>
                    </tr>
                    <%
                            }
                        }
                    %>
                </table>
            </div>

            <div class="d-footer" style="width: 300px;height: 70px;display: flex;justify-content: space-around;align-items: center;height:0;overflow:hidden">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Label runat="server" ID="lblCurrentPage" style=" font-weight:bold"></asp:Label>
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
                <span id="heji"></span>
            </div>
            </div>
    </form>
</body>
</html>
