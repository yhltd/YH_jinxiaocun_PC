using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using SDZdb;
using Web.Server;

namespace Web
{
    public partial class caigoutuihuotongji : System.Web.UI.Page
    {
        protected yh_jinxiaocun_user user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];

            if (user == null)
            {
                Response.Redirect("/Myadmin/Login.aspx");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetAllSalesReturns(string startDate = null, string endDate = null)
        {
            try
            {
                var user = HttpContext.Current.Session["user"] as yh_jinxiaocun_user;
                if (user == null) return "{\"success\":false,\"message\":\"用户未登录\"}";

                TuiHuomxModel model = new TuiHuomxModel();
                var data = model.GetAllSalesReturnsCG(user.gongsi, startDate, endDate);

                // 转换为前端需要的格式（兼容老版本）
                var formattedData = new List<object>();

                foreach (var item in data)
                {
                    decimal qty = 0;
                    decimal price = 0;
                    decimal amount = 0;

                    // 老版本兼容的TryParse方式
                    if (!string.IsNullOrEmpty(item.cpsl))
                    {
                        decimal.TryParse(item.cpsl, out qty);
                    }

                    if (!string.IsNullOrEmpty(item.cpsj))
                    {
                        decimal.TryParse(item.cpsj, out price);
                    }

                    amount = qty * price;

                    var formattedItem = new
                    {
                        Id = item.id,
                        OrderId = item.orderid ?? "",
                        ProductName = item.cpname ?? "",
                        ProductCode = item.sp_dm ?? "",
                        Category = item.cplb ?? "",
                        Quantity = item.cpsl ?? "0",
                        Price = item.cpsj ?? "0",
                        Unit = item.mxtype ?? "",
                        Warehouse = item.cangku ?? "",
                        Status = item.ruku ?? "",
                        ReturnDate = (item.shijian != null) ? item.shijian.Value.ToString("yyyy-MM-dd") : "",
                        Amount = amount.ToString("F2"),
                        Receiver = item.shou_h ?? "",
                        Company = item.gongsi ?? "",
                        Creator = item.finduser ?? "",
                        // 添加原始数据用于计算
                        RawQuantity = qty,
                        RawPrice = price,
                        RawAmount = amount
                    };

                    formattedData.Add(formattedItem);
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(new
                {
                    success = true,
                    data = formattedData,
                    totalCount = formattedData.Count
                });
            }
            catch (Exception ex)
            {
                return "{\"success\":false,\"message\":\"" + ex.Message.Replace("\"", "'") + "\"}";
            }
        }

        [WebMethod]
        public static void ExportToExcel(string startDate = null, string endDate = null)
        {
            var user = HttpContext.Current.Session["user"] as yh_jinxiaocun_user;
            if (user == null) return;

            try
            {
                TuiHuomxModel model = new TuiHuomxModel();
                var data = model.GetAllSalesReturns(user.gongsi, startDate, endDate);

                var context = HttpContext.Current;
                context.Response.Clear();
                context.Response.ContentType = "application/vnd.ms-excel";
                context.Response.AddHeader("Content-Disposition",
                    "attachment;filename=销售退货数据_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls");
                context.Response.Charset = "UTF-8";

                // 生成Excel表格
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine("<html>");
                sb.AppendLine("<head>");
                sb.AppendLine("<meta charset=\"UTF-8\">");
                sb.AppendLine("<style>");
                sb.AppendLine("table { border-collapse: collapse; width: 100%; }");
                sb.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
                sb.AppendLine("th { background-color: #f2f2f2; font-weight: bold; }");
                sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                sb.AppendLine("</style>");
                sb.AppendLine("</head>");
                sb.AppendLine("<body>");
                sb.AppendLine("<h2>销售退货数据导出</h2>");
                sb.AppendLine("<p>导出时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</p>");

                if (!string.IsNullOrEmpty(startDate) || !string.IsNullOrEmpty(endDate))
                {
                    sb.AppendLine("<p>筛选条件：");
                    if (!string.IsNullOrEmpty(startDate))
                        sb.Append("开始日期：" + startDate + " ");
                    if (!string.IsNullOrEmpty(endDate))
                        sb.Append("结束日期：" + endDate);
                    sb.AppendLine("</p>");
                }

                sb.AppendLine("<table>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th>序号</th>");
                sb.AppendLine("<th>退货日期</th>");
                sb.AppendLine("<th>退货单号</th>");
                sb.AppendLine("<th>商品名称</th>");
                sb.AppendLine("<th>商品代码</th>");
                sb.AppendLine("<th>商品类别</th>");
                sb.AppendLine("<th>退货数量</th>");
                sb.AppendLine("<th>单价</th>");
                sb.AppendLine("<th>退货金额</th>");
                sb.AppendLine("<th>仓库</th>");
                sb.AppendLine("<th>入库状态</th>");
                sb.AppendLine("<th>收货人</th>");
                sb.AppendLine("</tr>");

                int index = 1;
                decimal totalAmount = 0;
                foreach (var item in data)
                {
                    decimal quantity = 0;
                    decimal price = 0;

                    if (!string.IsNullOrEmpty(item.cpsl))
                        decimal.TryParse(item.cpsl, out quantity);

                    if (!string.IsNullOrEmpty(item.cpsj))
                        decimal.TryParse(item.cpsj, out price);

                    decimal amount = quantity * price;
                    totalAmount += amount;

                    string returnDate = "";
                    if (item.shijian != null)
                        returnDate = item.shijian.Value.ToString("yyyy-MM-dd");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + index + "</td>");
                    sb.AppendLine("<td>" + returnDate + "</td>");
                    sb.AppendLine("<td>" + (item.orderid ?? "") + "</td>");
                    sb.AppendLine("<td>" + (item.cpname ?? "") + "</td>");
                    sb.AppendLine("<td>" + (item.sp_dm ?? "") + "</td>");
                    sb.AppendLine("<td>" + (item.cplb ?? "") + "</td>");
                    sb.AppendLine("<td>" + quantity.ToString("F2") + "</td>");
                    sb.AppendLine("<td>" + price.ToString("F2") + "</td>");
                    sb.AppendLine("<td>" + amount.ToString("F2") + "</td>");
                    sb.AppendLine("<td>" + (item.cangku ?? "") + "</td>");
                    sb.AppendLine("<td>" + (item.ruku ?? "") + "</td>");
                    sb.AppendLine("<td>" + (item.shou_h ?? "") + "</td>");
                    sb.AppendLine("</tr>");
                    index++;
                }

                // 汇总行
                sb.AppendLine("<tr style='background-color: #e8f4f8; font-weight: bold;'>");
                sb.AppendLine("<td colspan='8' style='text-align: right;'>合计：</td>");
                sb.AppendLine("<td>" + totalAmount.ToString("F2") + "</td>");
                sb.AppendLine("<td colspan='3'></td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("</table>");
                sb.AppendLine("<p>总计记录数：" + data.Count + " 条，总退货金额：" + totalAmount.ToString("F2") + "</p>");
                sb.AppendLine("</body>");
                sb.AppendLine("</html>");

                context.Response.Write(sb.ToString());
                context.Response.End();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("导出失败：" + ex.Message);
            }
        }
    }
}