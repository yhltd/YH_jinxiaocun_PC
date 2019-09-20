<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yl_set_page.aspx.cs" Inherits="Web.yl_set_page" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
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
                               + "<td style='font-size: 14px;padding-left: 0.5%;width: 18px;'>" + rowLength + "</td>"
                               + "<td ><input type='text' class='input_tr' style='width: 203px;' name='cp_name" + row + "' ></input></td>"
                               + "<td class='bg_bj_dm'><input type='text' style='width: 203px;' class='input_tr' name='yl_dm" + row + "' ></input></td>"
                               + "<td class='bg_bj_lb'><input type='text' style='width: 203px;' class='input_tr' name='yl_name" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width: 203px;' class='input_tr' name='yl_sl" + row + "' ></input></td>"
                               + "<td class='bg_bj_sj'><input type='text' style='width: 195px;' class='input_tr' name='yl_tx" + row + "' ></input></td>"
                               + "<td style='border-right: 1px dashed #a8a8a8;'><input type='button'  class='rk_btu'value='删除'  onclick='del_row(" + row + ")'/></td>"
                               + "</tr>";
                $("#biao_ge tr:eq(" + (rowLength - 1) + ")").after(insertStr);
                row++;
            });


        });

        function pd_tj_ff() {
            var c = confirm('要提交吗?');
            if (c)
                $("#tj_pd_id").val("tj_true");
            else
                $("#tj_pd_id").val("tj_false");
        }
    </script>
    <style type="text/css">
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

        td {
           border-left: 1px dashed #a8a8a8;
border-bottom: 1px dashed #a8a8a8;
            font-size: 84%;
        }

        table {
            /*border: 1px dashed #a8A8A8;*/
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
             margin-left: 11%;
          
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
        .hidden_load {
          display: none;
        }

               .input_tr_sx {
         margin-bottom: 2%;
          margin-left: 4%; 
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
        <div style="margin-top: 5%;">
               <input type="hidden" id="tj_pd_id"  name="tj_pd" />
           <%-- <asp:DropDownList CssClass="hidden_load" ID="DropDownList1" runat="server" OnLoad="yl_set_select_load">
            </asp:DropDownList>--%>
             <asp:Button ID="Button2" class="input_tr_sx" OnClick="yl_set_select_load" Text="刷新数据" runat="server" />
              <div style="width: 171px;border: 1px solid #95b8e7;height: 51px;margin-left: 80%;margin-top: -6%;margin-bottom: 2%;">
                <div style="font-size: 19%; margin-top: -5%; margin-left: 7%; background-color: white; width: 27px;">功能</div>
                <asp:Button OnClick="del_yong_liao" ID="del_qc_btu" class="input_tr_sc" Text="删除" runat="server" />
                <asp:Button OnClick="yl_tj" ID="dj_row" class="input_tr_tj" Text="提交" runat="server" />
            </div>
            <input type="hidden" id="row_i1" name="row_i" />

            <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="">
                <tr id="dj_yh">
                     <td class="auto-style1" style="width: 18px; padding-left: 1%;"></td>
                    <td class="auto-style1" style="width: 217px; padding-left: 1%;">商品代码</td>
                    <td class="auto-style1" style="width: 217px; padding-left: 1%;">商品名称</td>
                    <td class="auto-style1" style="width: 217px; padding-left: 1%;">商品类别</td>
                    <td class="auto-style1" style="width: 217px; padding-left: 1%;">商品单位</td>
                    <td class="auto-style1" style="width: 210px; padding-left: 1%;">用料设定</td>
                    <td class="auto-style1" style="width: 47px; padding-left: 1%;border-right: 1px dashed #a8a8a8;">功能</td>
                </tr>
                <%
                    List<yong_liao_set_info> yl_set_select = Session["yl_set_select"] as List<yong_liao_set_info>;
                    if (yl_set_select != null)
                    {
                    for (int i = 0; i < yl_set_select.Count; i++)
                    {                          
                %>
                <tr id="del_row_cs<%=i %>">
                    <%--style="font-size: 90%; padding-left: 2%;"--%>
                    <td style="font-size: 14px;padding-left: 0.5%;width: 18px;"><%=(i+1) %></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 203px;margin: 0.5%;" class="input_tr" id="sp_name" name="cp_name_cs<%=i %>" value="<%=yl_set_select[i].cp_name %>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 203px;margin: 0.5%;" class="input_tr" id="Text1" name="yl_dm_cs<%=i %>" value="<%=yl_set_select[i].yl_dm %>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 203px;margin: 0.5%;" class="input_tr" id="Text2" name="yl_name_cs<%=i %>" value="<%=yl_set_select[i].yl_name %>" /></td>
                    <td class="bg_bj">
                        <input type="text" style="width: 203px;margin: 0.5%;" class="input_tr" id="ck_dj<%=i %>" name="yl_sl_cs<%=i %>" value="<%=yl_set_select[i].yl_sl %>" /></td>
                      <td class="bg_bj">
                        <input type="text" style="width: 195px;margin: 0.5%;" class="input_tr" id="Text4" name="yl_tx_cs<%=i %>" value="<%=yl_set_select[i].yl_tx %>" /></td>
                    <td class="bg_bj" style="border-right: 1px dashed #a8a8a8;">
                        <input type="hidden" class="input_tr" id="Text3" name="id_cs<%=i %>" value="<%=yl_set_select[i].id %>" /><input id="checkbox" style="margin-left: 30%;" name="Checkbox_bd<%=i %>" value=" <%=i %>" type="checkbox" /></td>
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
