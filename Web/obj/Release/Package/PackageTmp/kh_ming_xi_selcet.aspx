<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kh_ming_xi_selcet.aspx.cs" Inherits="Web.kh_ming_xi_selcet" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <script>
        $(function () {
            $("#select_xl").change(function () {
                $("#kui_lei").val(this.value);

            })

        })



    </script>
    <style type="text/css">
         tr:nth-child(2n-1) input {
            background-color: #eeeeee;
        }

        tr:nth-child(2n) input {
            background-color: ;
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
            /*border: 1px dashed #a8A8A8;*/
             font-size: 84%;
            padding-left: 1%;
            border-left: 1px dashed #a8a8a8;
border-bottom: 1px dashed #a8a8a8;
        }

        table {
            /*border: 1px dashed #a8A8A8;*/
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
              .rk_btu {
            display: none;
        }
                select {
            font-family: "微软雅黑";
            background: rgba(0,0,0,0);
            width: 115px;
            height: 24px;
            font-size: 16px;
            color: black;
            text-align: center;
            border: 1px #1a1a1a solid;
            border-radius: 5px;
            margin-right: 2%;
            margin-left: 74%;
            margin-top: 3%;
            margin-bottom: 5%;
        }

        option {
            color: black;
            background: #eeeeee;
            line-height: 20px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:DropDownList CssClass="rk_btu" ID="DropDownList1" runat="server" OnLoad="kh_mx_select_load">
            </asp:DropDownList>
            <select id="select_xl">
                <%           
                    List<rc_ku_info> kh_mx_xl_select = Session["kh_mx_xl_select"] as List<rc_ku_info>;
                    for (int i = 0; i < kh_mx_xl_select.Count; i++)
                    {                          
                %>
                <option><%=kh_mx_xl_select[i].Gong_huo %></option>
                <%
                    }
                %>
            </select>
               <input name="kui_lei" id="kui_lei" value="<%=kh_mx_xl_select[0].Gong_huo %>" type="hidden" />
            <asp:Button OnClick="kh_mx_select_Click" ID="Button1" class="input_tr" Text="查询" runat="server" />

               <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: -2%;">
                <tr id="dj_yh">
                    <td class="auto-style1" style="width: 150px; padding-left: 1%;">日期</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">供货商</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">单号</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">商品代码</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">商品名称</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">类别</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">入库数量</td>
                    <td class="auto-style1" style="width: 138px; padding-left: 1%;">入库单价</td>
                    <td class="auto-style1" style="width: 47px; padding-left: 1%;border-right: 1px dashed #a8a8a8;">金额</td>
                </tr>

                <%
               
                    List<rc_ku_info> rk_mx_select = Session["rk_mx_select"] as List<rc_ku_info>;


                    if (rk_mx_select == null)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < rk_mx_select.Count; i++)
                        {
                       
                %>
                <tr id="Tr1">

                    <td><%=rk_mx_select[i].Ri_qi %></td>
                    <td><%=rk_mx_select[i].Gong_huo %></td>
                    <td><%=rk_mx_select[i].Orderid %></td>
                    <td><%=rk_mx_select[i].Sp_dm %></td>
                    <td><%=rk_mx_select[i].Name %></td>
                    <td><%=rk_mx_select[i].Lei_bie %></td>
                    <td><%=rk_mx_select[i].Shou_jia %></td>
                    <td><%=rk_mx_select[i].Shu_liang %></td>
                    <td style="border-right: 1px dashed #a8a8a8;"><%=Convert.ToInt32( rk_mx_select[i].Shou_jia) * Convert.ToInt32( rk_mx_select[i].Shu_liang )%></td>

                </tr>
                <%
                        }
                    }
                %>
            </table>
        </div>
    </form>
</body>
</html>
