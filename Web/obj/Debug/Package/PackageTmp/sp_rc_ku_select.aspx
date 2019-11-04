<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sp_rc_ku_select.aspx.cs" Inherits="Web.sp_rc_ku_select" %>

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
        .rk_btu {
            display: none;
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

        .td_css {
            font-size: 84%;
            padding-left: 1%;
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
            <asp:DropDownList CssClass="rk_btu" ID="DropDownList1" runat="server" OnLoad="rc_ku_select_load">
            </asp:DropDownList>
            <div>
                <select id="select_xl">
                    <%           
                        List<rc_ku_info> rc_ku_xl_select = Session["rc_ku_xl_select"] as List<rc_ku_info>;
                        for (int i = 0; i < rc_ku_xl_select.Count; i++)
                        {                          
                    %>
                    <option><%=rc_ku_xl_select[i].Name %></option>
                    <%
                        }
                    %>
                </select>
                <input name="kui_lei" class="rk_btu" id="kui_lei" value="<%=rc_ku_xl_select[0].Name %>" type="text" />
                <asp:Button OnClick="rc_ku_select_Click" ID="Button1" CssClass="input_tr" Text="查询" runat="server" />
            </div>


            <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="margin-top: -2%;">
                <tr id="dj_yh">
                    <td class="auto-style1" style="width: 150px; padding-left: 1%;">日期</td>
                    <td class="auto-style1" style="width: 128px; padding-left: 1%;">供货商</td>
                    <td class="auto-style1" style="width: 50px; padding-left: 1%;">单号</td>
                    <td class="auto-style1" style="width: 128px; padding-left: 1%;">商品代码</td>
                    <td class="auto-style1" style="width: 128px; padding-left: 1%;">商品名称</td>
                    <td class="auto-style1" style="width: 128px; padding-left: 1%;">类别</td>
                    <td class="auto-style1" style="width: 84px; padding-left: 1%;">入库数量</td>
                    <td class="auto-style1" style="width: 84px; padding-left: 1%;">入库单价</td>
                    <td class="auto-style1" style="width: 47px; padding-left: 1%;">金额</td>
                    <td class="auto-style1" style="width: 84px; padding-left: 1%;">出库数量</td>
                    <td class="auto-style1" style="width: 84px; padding-left: 1%;">出库单价</td>
                    <td class="auto-style1" style="width: 47px; padding-left: 1%;border-right: 1px dashed #a8a8a8;">出库金额</td>
                </tr>

                <%
               
                    List<rc_ku_info> rc_ku_r_select = Session["selectSp"] as List<rc_ku_info>;


                    if (rc_ku_r_select == null)
                    {

                    }
                    else
                    {
                        for (int i = 0; i < rc_ku_r_select.Count; i++)
                        {
                       
                %>
                <tr id="Tr1">

                    <td class="td_css"><%=rc_ku_r_select[i].Ri_qi %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Gong_huo %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Orderid %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Sp_dm %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Name %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Lei_bie %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Shou_jia %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Shu_liang %></td>
                    <td class="td_css"><%=Convert.ToInt32( rc_ku_r_select[i].Shou_jia) * Convert.ToInt32( rc_ku_r_select[i].Shu_liang )%></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Shou_jia_2 %></td>
                    <td class="td_css"><%=rc_ku_r_select[i].Shu_liang_2 %></td>
                    <td style="border-right: 1px dashed #a8a8a8;" class="td_css"><%=Convert.ToInt32( rc_ku_r_select[i].Shou_jia_2) * Convert.ToInt32( rc_ku_r_select[i].Shu_liang_2 )%></td>
                </tr>
                <%
                        }
                    }
                %>
            </table>



            <%--<table border="1" id="Table2" name="bg_row" style="margin-top: -8.3%; margin-left: 58.63%;">
                <tr id="Tr4">

                    <td class="auto-style1" style="width: 84px; padding-left: 0.5%;">单价</td>
                    <td class="auto-style1" style="width: 84px; padding-left: 0.5%;">数量</td>
                    <td class="auto-style1" style="width: 84px; padding-left: 0.5%;">金额</td>
                </tr>
                <%
               
                    List<rc_ku_info> rc_ku_c_select = Session["rc_ku_c_select"] as List<rc_ku_info>;
                    if (rc_ku_c_select == null)
                    {


                    }
                    else
                    {


                        for (int i = 0; i < rc_ku_c_select.Count; i++)
                        {                          
                %>
                <tr id="Tr5">
                    <td><%=rc_ku_c_select[i].Shou_jia%></td>
                    <td><%=rc_ku_c_select[i].Shu_liang%></td>
                    <%if (Convert.ToInt32(rc_ku_r_select[i].Shu_liang) == 0 || Convert.ToInt32(rc_ku_r_select[i].Shu_liang) == 0)
                      {
                          %>
                      <td>0</td>
                    <%
                      }
                      else { 
                      %>
                      <td><%=Convert.ToInt32( rc_ku_r_select[i].Shu_liang) * Convert.ToInt32( rc_ku_r_select[i].Shu_liang )%></td>
                    <%
                      } %>
                    
                </tr>
                <%     
                    }
                    }
                %>
            </table>--%>
        </div>
    </form>
</body>
</html>
