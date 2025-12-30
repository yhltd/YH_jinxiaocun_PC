<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kh_ming_xi_selcet.aspx.cs" Inherits="Web.kh_ming_xi_selcet" %>

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

        td
        {
            text-align: center;
            height: 40px;
            background-color: white;
            border: 0.5px solid #f2f2f2;
            font-size: 16px;
        }

        .input_tr
        {
            width: 91px;
            height: 30px;
            border: none;
            background-color: #009688;
            color: white;
            cursor: pointer;
            border-radius: 2px;
            margin-left: 10px;
            margin-right: 10px;
        }
        .td_cl {
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
        tr:nth-child(odd) .td_cl {
            background-color:#D3D3D3;
        }

        /* 偶数行样式 */
        tr:nth-child(even) .td_cl {
            background-color: #e0f7fa; 
        }

        .select_xl
        {
            width: 185px;
            height: 73%;
            border: 1px solid #C2C2C2;
            border-radius: 3px;
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
        .table_div
        {
            overflow-y: auto;
        }
          .d-main {
            overflow:auto;
            margin-left:1%;
            margin-top:30px;
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
            <div class="d-header top-div">
                <select class="select_xl" name="gonghuo">
                    <option>请选择</option>
                    <%           
                        System.Collections.Generic.List<string> shouhuo = Session["kh_mx_xl_select"] as System.Collections.Generic.List<string>;
                        if (shouhuo != null)
                        {
                            for (int i = 0; i < shouhuo.Count; i++)
                            {                          
                                if(Session["shouhuo"].ToString() == shouhuo[i])
                                {
                                    %>
                                    <option selected="selected"><%=shouhuo[i]%></option>
                                    <%
                                }
                                else
                                {
                                    %>
                                    <option><%=shouhuo[i]%></option>
                                    <%
                                }
                            }
                        }
                    %>
                </select>
                <asp:Button OnClick="kh_mx_select_Click" ID="Button2" class="input_tr" Text="查询" runat="server" />
                <asp:Button OnClick="kh_mx_select_load" ID="Button1" class="input_tr" Text="刷新" runat="server" />
                <asp:Button ID="btn_print" class="button" onmouseover="this.className='ui-btn ui-btn-search-hover'"
                                onmouseout="this.className='button'" runat="server" Text="e打印" OnClick="toExcel" Width="100px" Height="30px" />
            </div>

            <div class="d-main table_div">
                <table cellspacing="0" cellpadding="0" id="biao_ge" name="bg_row" style="width: 100%">
                    <tr id="dj_yh">
                        <th class="auto-style1" style="width: 150px;">供货商/客户</th>
                        <th class="auto-style1" style="width: 110px;">商品代码</th>
                        <th class="auto-style1" style="width: 110px;">商品名称</th>
                        <th class="auto-style1" style="width: 110px;">商品类别</th>
                        <%--<th class="auto-style1" style="width: 138px;">商品名称</th>--%>
                        <th class="auto-style1" style="width: 100px;">入库/出库数量</th>
                        <th class="auto-style1" style="width: 100px;">入库/出库金额</th>
                    </tr>

                    <%
               
                        System.Collections.Generic.List<Web.ServerEntity.MingXiItem> mingxi = Session["rk_mx_select"] as System.Collections.Generic.List<Web.ServerEntity.MingXiItem>;


                        if (mingxi == null)
                        {

                        }
                        else
                        {
                            for (int i = 0; i < mingxi.Count; i++)
                            {
                       
                    %>
                    <tr id="Tr1">
                        <td class="td_cl"><%=mingxi[i].shou_h %></td>
                        <td class="td_cl"><%=mingxi[i].sp_dm%></td>
                        <td class="td_cl"><%=mingxi[i].cpname %></td>
                        <td class="td_cl"><%=mingxi[i].cplb %></td>
                        <%--<td class="td_cl"><%=mingxi[i].cpname %></td>--%>
                        <td class="td_cl"><%=mingxi[i].ruku_num %></td>
                        <td class="td_cl"><%=mingxi[i].ruku_price %></td>
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
