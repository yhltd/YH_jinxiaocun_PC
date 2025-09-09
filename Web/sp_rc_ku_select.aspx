<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sp_rc_ku_select.aspx.cs" Inherits="Web.sp_rc_ku_select" %>

<%@ Import Namespace="SDZdb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Myadmin/js/jquery-1.8.3.min.js"></script>
    <link href="Myadmin/css/common.css" rel="stylesheet" type="text/css" />
    <script>
    </script>
    <style type="text/css">

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
            top : 0;
        }
        .header-bottom
        {
            top: 49px;
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


        .select_xl {
            width: 185px;
            height: 73%;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
        }
            .td_css {
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
        tr:nth-child(odd) .td_css {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .td_css {
            background-color: #e0f7fa; 
        }

         .d-main {
            overflow:auto;
            margin-left:1%;
            margin-top:50px;
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
        .d-header {
            margin-left:1%;
            padding:5px;
            width:97%;
            height:10%;
            min-height:50px;
            margin-top:10px;
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
    <script type="text/javascript">

        
        $(function () {
            var tableObj = document.getElementById("biao_ge");
            $('#hangshu').val(tableObj.rows.length - 1)
            // alert($('#hangshu').val)
        })
    </script>
    <title></title>
</head>
<body>
     <%--<input id="hangshu" />--%>
     
    <form id="form1" runat="server">
        <div>
            <div class="d-header top-div">
                <label class="top-text">商品代码：</label>
                    <asp:TextBox ID='sp_dm' class='select_xl' Autocomplete='off'  runat="server" placeholder="商品代码"/>
                <label class="top-text" style="margin-left:10px">商品类别：</label>
                    <asp:TextBox ID='cplb' class='select_xl' Autocomplete='off'  runat="server" placeholder="商品类别"/>
                <label class="top-text" style="margin-left:10px">商品名称：</label>
                <select class="select_xl" name="kui_lei">
                    <option>请选择</option>
                    <%           
                        System.Collections.Generic.List<string> rc_ku_xl_select = Session["rc_ku_xl_select"] as System.Collections.Generic.List<string>;
                        if (rc_ku_xl_select != null)
                        {
                            for (int i = 0; i < rc_ku_xl_select.Count; i++)
                            {
                                if (Session["cpname"].ToString() == rc_ku_xl_select[i])
                                {
                                    %>
                                    <option selected="selected"><%=rc_ku_xl_select[i]%></option>
                                    <%
                                }
                                else
                                {
                                    %>
                                    <option><%=rc_ku_xl_select[i]%></option>
                                    <%
                                }
                            }
                        }
                    %>
                </select>
                <asp:Button OnClick="rc_ku_select_Click" ID="Button1" CssClass="input_tr" Text="查询" runat="server" />
                <asp:Button OnClick="rc_ku_select_load" ID="Button2" CssClass="input_tr" Text="刷新" runat="server" />
                <asp:Button ID="btn_print" class="input_tr" runat="server" Text="打印" OnClick="toExcel" />
            </div>

            <div class="d-main table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="Tr2">
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 150px;">商品代码</th>
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 150px;">商品名称</th>
                        <th colspan="1" rowspan="2" class="auto-style1" style="width: 128px;">类别</th>
                        <%--<th colspan="1" rowspan="2" class="auto-style1" style="width: 128px;">商品名称</th>--%>
                        <th colspan="2" rowspan="1" class="auto-style1" style="width: 140px">入库</th>
                        <th colspan="2" rowspan="1" class="auto-style1" style="width: 140px;">出库</th>
                    </tr>
                    <tr id="dj_yh">
                        <th class="auto-style1 header-bottom" style="width: 70px">数量</th>
                        <th class="auto-style1 header-bottom" style="width: 70px">金额</th>
                        <th class="auto-style1 header-bottom" style="width: 70px">数量</th>
                        <th class="auto-style1 header-bottom" style="width: 70px">金额</th>
                    </tr>

                    <%
                        System.Collections.Generic.List<Web.ServerEntity.MingXiItem> mingxi = Session["selectSp"] as System.Collections.Generic.List<Web.ServerEntity.MingXiItem>;


                        if (mingxi != null)
                        {
                            for (int i = 0; i < mingxi.Count; i++)
                            {
                                %>
                                <tr id="Tr1">

                                    <td class="td_css"><%=mingxi[i].sp_dm %></td>
                                    <td class="td_css"><%=mingxi[i].cpname %></td>
                                    <td class="td_css"><%=mingxi[i].cplb %></td>
                                    <%--<td class="td_css"><%=mingxi[i].cpname %></td>--%>
                                    <td class="td_css"><%=mingxi[i].ruku_num %></td>
                                    <td class="td_css"><%=mingxi[i].ruku_price %></td>
                                    <td class="td_css"><%=mingxi[i].chuku_num %></td>
                                    <td class="td_css"><%=mingxi[i].chuku_price %></td>
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
