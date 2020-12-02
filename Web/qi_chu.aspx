<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qi_chu.aspx.cs" Inherits="Web.qi_chu" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
        <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            var windowHeight = window.innerHeight;
            $(".table_div").css("height", windowHeight*0.8)
        })
        
        function bhhq(row) {
            $.ajax({
                type: "post", 
                url: "ru_ku.aspx?act=PostUser&id=" + $("#sp_dm" + row).val(),
                dataType: "json",
                data: {},
                success: function (data) {
                    $("#sp_cplb" + row).val(data[0].leibie)
                    $("#sp_name" + row).val(data[0].name)
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

        $(function () {
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
                               + "<td ><input type='text' class='input_tr' style='width:147px;margin:1px'  id='sp_name"+row+"' name='cpname" + row + "' ></input></td>"
                               //+ "<td class='bg_bj_dm'><input type='text' style='width:318px;margin:1px' id='sp_dm' class='input_tr' name='cpname" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'>"
                               + "<select class='input_tr' id='sp_dm" + row + "' name='cpid" + row + "' onchange='bhhq(" + row + ")'>"
                            + "<option>选择编号</option>" 
                            +<%
                                List<zl_and_jc_info> jichu = Session["jichu"] as  List<zl_and_jc_info> ;
                                if (jichu!=null){
                                    for (int ji = 0; ji < jichu.Count; ji++) 
                                    {
                                        if (jichu[ji].id != "") 
                                        {
                                            if(ji == 0){
                                        %>
                                            + "<option value ='<%=jichu[ji].sp_dm %>'><%=jichu[ji].sp_dm %></option>" 
                                            + "<option value ='<%=jichu[ji].sp_dm %>'><%=jichu[ji].sp_dm %></option>"      
                                        <%
                                            }else{
                                            %>
                                            + "<option value ='<%=jichu[ji].sp_dm %>'><%=jichu[ji].sp_dm %></option>"
                                            <%
                                            }
                                        }
                                    }
                                }
                                 %>

                        + "</select></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width:147px;margin:1px' id='sp_cplb"+row+"' class='input_tr' name='cplb" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width:147px;margin:1px'  id='ck_dj" + (rowLength - 1) + "' class='input_tr' name='cpsj" + row + "' ></input></td>"
                               + "<td class='bg_bj_sl'><input type='text' style='width:147px;margin:1px'  id='ck_sl" + (rowLength - 1) + "' class='input_tr' name='cpsl" + row + "' ></input></td>"
                               + "<td onclick='js_xx2(" + (rowLength - 1) + ")' id='dj_js" + (rowLength - 1) + "' style='width:147px;margin:1px'></td>"
                               + "<td  style='border-right: 1px dashed #a8a8a8;'><input type='button' class='qc_sc'value='删除'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
            });

            //$("#row_del_htl" + i).click(function () {
            //    $("#del_row" + i + "").remove();
            //});
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

        $(document).on("click", "#dj_row", function () {
            //  alert("asd");
            if (document.getElementById("xx_hidden").value == "tj_false") {
                return false;
            } else {
            }
        })

    </script>
    <style type="text/css">
        #biao_ge {
            /*margin: 0px auto;*/
        }



        .hidden_load {
            display: none;
        }

        .input_tr {
            border: none;
            height: 90%;
            width: 90%;
        }

        .auto-style1 {
            height: 49px;
            text-align: center;
            background-color: #2F4056;
            color: white;
            font-size: 16px;
            font-weight: bold;
            position: sticky;
            top: 0;
        }
        td
        {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 10px;
        }

        .qc_sc {
            margin-left: 1px;
        }
        .new_cuku {
            width: 28px;
        }
        .table_div
        {
            width:100%;
            height:70%;
            overflow:scroll;
        }
        .page_bt
        {
            border: none;
            background-color: #009688;
            color: white;
            width: 50px;
            height: 25px;
            border-radius: 2px;
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
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="hidden" id="xx_hidden" value="tj_false" />
            <input type="hidden" id="row_i1" name="row_i" />
            <input type="hidden" id="tj_pd_id" name="tj_pd" />
            <div class="fun_div">
                <asp:Button ID="Button2" class="qichu_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
                <asp:Button OnClick="del_qichu" ID="del_qc_btu" class="qichu_input_tr_tj" Text="删除" runat="server" />
                <asp:Button OnClick="qc_tj" ID="dj_row" class="qichu_input_tr_tj" Text="提交" runat="server" />
            </div>
            <div class="table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: 1%;">
                    <tr id="dj_yh">
                        <td class="auto-style1" style="width: 100px;">序号</td>
                        <td class="auto-style1" style="width: 130px;">商品名称</td>
                        <td class="auto-style1" style="width: 130px;">商品代码</td>
                        <td class="auto-style1" style="width: 130px;">商品类别</td>
                        <td class="auto-style1" style="width: 130px;">商品售价</td>
                        <td class="auto-style1" style="width: 130px;">商品数量</td>
                        <td class="auto-style1" style="width: 130px">金额</td>
                        <td class="auto-style1" style="width: 100px;">功能</td>
                    </tr>
                    <%
                        List<qi_chu_info> qi_chu_select = Session["qi_chu_select"] as List<qi_chu_info>;
                        if (qi_chu_select != null)
                        {
                            for (int i = 0; i < qi_chu_select.Count; i++)
                            {                          
                    %>
                    <tr id="del_row_cs<%=i%>">
                        <%--style="font-size: 90%; padding-left: 2%;"--%>
                        <td style="font-size: 14px; padding-left: 0.5%; width: 18px;"><%=(i+1) %>
                            <input class="input_tr" type="hidden" id="id<%=i%>" name="id<%=i%>" value="<%=qi_chu_select[i].Id%>" />
                        </td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="sp_name" name="cpname_cs<%=i%>" value="<%=qi_chu_select[i].Cpname%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="Text1" name="cpid_cs<%=i%>" value="<%=qi_chu_select[i].Cpid%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="Text2" name="cplb_cs<%=i%>" value="<%=qi_chu_select[i].Cplb%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="ck_dj<%=i%>" name="cpsj_cs<%=i%>" value="<%=qi_chu_select[i].Cpsj%>" /></td>
                        <td class="bg_bj">
                            <input type="text" class="input_tr" id="ck_sl<%=i%>" name="cpsl_cs<%=i%>" value="<%=qi_chu_select[i].Cpsl%>" /></td>
                        <td class="bg_bj" id="dj_js<%=i%>">
                            <%=int.Parse(qi_chu_select[i].Cpsj)*int.Parse(qi_chu_select[i].Cpsl)%>
                        </td>
                        <td class="bg_bj" style="width: 43px;">
                            <input id="checkbox" name="Checkbox_bd<%=i%>" value=" <%=i%>" type="checkbox" /></td>
                    </tr>
                    <%
                            }
                        }
                    %>
                </table>
            </div>

            <div style="width: 300px;height: 70px;display: flex;justify-content: space-around;align-items: center;">
                <asp:Button CssClass="page_bt" ID="shou_ye" OnClick="shou_ye_Click" Text="首页" runat="server" />
                <asp:Button CssClass="page_bt" ID="shang_ye" OnClick="shang_ye_Click" Text="上一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="xia_ye" OnClick="xia_ye_Click" Text="下一页" runat="server" />
                <asp:Button CssClass="page_bt" ID="mo_ye" OnClick="mo_ye_Click" Text="末页" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
