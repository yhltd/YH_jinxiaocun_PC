<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qi_chu.aspx.cs" Inherits="Web.qi_chu" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
        <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
        function bhhq(row) {

            $.ajax({
                type: "post", //要用post方式                 
                //url: "ru_ku.aspx/selectNameAndLebie",//方法所在页面和方法名
                url: "ru_ku.aspx?act=PostUser&id=" + $("#sp_dm" + row).val(),
                //contentType: "application/json; charset=utf-8",
                //async: false,
                dataType: "json",
                data: {},
                success: function (data) {
                    //alert("yyes")
                    $("#sp_cplb" + row).val(data[0].leibie)
                    $("#sp_name" + row).val(data[0].name)
                },
                error: function (err) {
                    //alert(err.toString());

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

        tr:nth-child(2n-1) input {
            background-color: #eeeeee;
        }

        tr:nth-child(2n) input {
            background-color: #ffffff;
        }


        #biao_ge tr:nth-of-type(odd) {
            background-color: #eeeef6;
        }

        .auto-style1 {
            color: black;
            height: 33px;
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


        .input_tr_sc {
            margin-top: 3%;
            margin-left: 17%;
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

            .input_tr_sc:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        .input_tr_tj {
            margin-left: 4%;
            margin-top: 3%;
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

            .input_tr_tj:focus {
                border-color: #66afe9;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
            }

        .qc_sc {
            margin-left: 1px;
        }
        .new_cuku {
            width: 28px;
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
            <%--<asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="bt_select_Click">
            </asp:DropDownList>--%>
              <img class="new_qichu" src="Myadmin/images/Resources/refresh_24.gif"  />
             <asp:Button ID="Button2" class="qichu_input_tr_tj" OnClick="bt_select_Click" Text="刷新数据" runat="server" />
            <div style="width: 171px; border: 1px solid #95b8e7; height: 51px; margin-left: 80%; margin-top: -3%; margin-bottom: -6%;">
                <div style="font-size: 19%; margin-top: -5%; margin-left: 7%; background-color: white; width: 27px;">功能</div>
                <asp:Button OnClick="del_qichu" ID="del_qc_btu" class="input_tr_sc" Text="删除" runat="server" />
                <asp:Button OnClick="qc_tj" ID="dj_row" class="input_tr_tj" Text="提交" runat="server" />
            </div>
            <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: 8%;">
                <tr id="dj_yh">
                    <td class="auto-style1" style="padding-left: 1%; width: 38px; font-size: 92%">序号</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 148px; font-size: 92%">商品名称</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 321px; font-size: 92%">商品代码</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 148px; font-size: 92%">商品类别</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 148px; font-size: 92%">商品售价</td>
                    <td class="auto-style1" style="padding-left: 1%; width: 148px; font-size: 92%">商品数量</td>
                    <td class="auto-style1" style="padding-left: 1%; font-size: 92%; width: 148px">金额</td>
                    <td class="auto-style1" style="padding-left: 0.4%; font-size: 92%; width: 41px; border-right: 1px dashed #a8a8a8;">功能</td>
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
                    <td style="font-size: 14px; padding-left: 0.5%; width: 18px;"><%=(i+1) %></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 147px; margin: 1px;" class="input_tr" id="sp_name" name="cpid_cs<%=i%>" value="<%=qi_chu_select[i].Cpname%>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 318px; margin: 1px;" class="input_tr" id="Text1" name="cpname_cs<%=i%>" value="<%=qi_chu_select[i].Cpid%>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 147px; margin: 1px;" class="input_tr" id="Text2" name="cplb_cs<%=i%>" value="<%=qi_chu_select[i].Cplb%>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 147px; margin: 1px;" class="input_tr" id="ck_dj<%=i%>" name="cpsj_cs<%=i%>" value="<%=qi_chu_select[i].Cpsj%>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 147px; margin: 1px;" class="input_tr" id="ck_sl<%=i%>" name="cpsl_cs<%=i%>" value="<%=qi_chu_select[i].Cpsl%>" /></td>
                    <td class="bg_bj" style="width: 147px; margin: 1px;" onclick="js_xx(<%=i%>)" id="dj_js<%=i%>">
                        <input id="dt_row<%=i%>" type="hidden" value="<%=i%>" /></td>
                    <td class="bg_bj" style="width: 43px; border-right: 1px dashed #a8a8a8;">
                        <input id="checkbox" style="margin-left: 30%;" name="Checkbox_bd<%=i%>" value=" <%=i%>" type="checkbox" /></td>
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
