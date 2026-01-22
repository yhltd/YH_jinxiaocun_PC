using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Web.Personnel
{
    public partial class lizhishenqing : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            // 处理各种操作请求
            //ProcessAction(null);

            if (!IsPostBack && string.IsNullOrEmpty(Request.QueryString["action"]) && string.IsNullOrEmpty(Request.Form["action"]))
            {
                LoadDepartments();
            }
            else
            {
                // 处理各种操作请求
                ProcessAction(null);
            }
        }

        // 新增：从数据库加载部门数据
        private void LoadDepartments()
        {
            try
            {
                if (Session["gongsi"] == null)
                    return;

                string gongsi = Session["gongsi"].ToString();
                string conString = ConfigurationManager.AppSettings["yao"];

                using (conn = new SqlConnection(conString))
                {
                    // 查询gongzi_peizhi表中唯一的部门列表
                    string sql = "SELECT DISTINCT bumen FROM gongzi_peizhi WHERE gongsi = @gongsi AND bumen IS NOT NULL AND bumen != '' ORDER BY bumen";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // 构建部门列表
                    List<string> departments = new List<string>();
                    while (reader.Read())
                    {
                        string dept = reader["bumen"].ToString();
                        if (!string.IsNullOrEmpty(dept))
                        {
                            departments.Add(dept);
                        }
                    }
                    reader.Close();
                    conn.Close();

                    // 将部门列表存储到ViewState中
                    ViewState["Departments"] = departments;

                    // 或者直接输出到页面
                    if (departments.Count > 0)
                    {
                        // 生成JavaScript代码来设置下拉选项
                        StringBuilder script = new StringBuilder();
                        script.Append("<script type='text/javascript'>");
                        script.Append("$(document).ready(function() {");
                        script.Append("var departments = [");

                        for (int i = 0; i < departments.Count; i++)
                        {
                            script.AppendFormat("'{0}'", HttpUtility.JavaScriptStringEncode(departments[i]));
                            if (i < departments.Count - 1)
                                script.Append(",");
                        }

                        script.Append("];");
                        script.Append("if (departments.length > 0) {");
                        script.Append("   var $bumenInput = $('#bumen');");
                        script.Append("   // 如果输入框不存在，可能是id不同，尝试其他选择器");
                        script.Append("   if ($bumenInput.length === 0) {");
                        script.Append("       $bumenInput = $('input[placeholder*=\"部门\"]').first();");
                        script.Append("   }");
                        script.Append("   if ($bumenInput.length > 0) {");
                        script.Append("       // 将输入框改为下拉选择框");
                        script.Append("       var $select = $('<select id=\"bumen\" class=\"input\"></select>');");
                        script.Append("       $select.append('<option value=\"\">请选择部门</option>');");
                        script.Append("       $.each(departments, function(index, dept) {");
                        script.Append("           $select.append('<option value=\"' + dept + '\">' + dept + '</option>');");
                        script.Append("       });");
                        script.Append("       // 替换输入框");
                        script.Append("       $bumenInput.replaceWith($select);");
                        script.Append("       // 添加事件处理");
                        script.Append("       $select.on('change', function() {");
                        script.Append("           onInputChange('bumen');");
                        script.Append("       });");
                        script.Append("   }");
                        script.Append("}");
                        script.Append("});");
                        script.Append("</script>");

                        // 将JavaScript代码注册到页面
                        ClientScript.RegisterStartupScript(this.GetType(), "LoadDepartments", script.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // 记录错误但不影响页面显示
                System.Diagnostics.Debug.WriteLine("加载部门数据失败: " + ex.Message);
            }
        }

        private void ProcessAction(string action)
        {
            // 从查询字符串或Form中获取action
            string actionType = Request.QueryString["action"];
            if (string.IsNullOrEmpty(actionType))
            {
                actionType = Request.Form["action"];
            }

            if (string.IsNullOrEmpty(actionType))
                return;

            switch (actionType.ToLower())
            {
                case "submit":
                    SubmitApplication();
                    break;
                case "gethistory":
                    GetHistoryData();
                    break;
                case "getdepartments":  // 新增：获取部门数据
                    GetDepartments();
                    break;
            }
        }

        // 新增：获取部门数据的方法
        private void GetDepartments()
        {
            string responseMessage = "";
            bool isSuccess = false;
            List<string> departments = new List<string>();

            try
            {
                if (Session["gongsi"] == null)
                {
                    responseMessage = "请登录！";
                    isSuccess = false;
                }
                else
                {
                    string gongsi = Session["gongsi"].ToString();
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (conn = new SqlConnection(conString))
                    {
                        // 查询gongzi_peizhi表中唯一的部门列表
                        string sql = "SELECT DISTINCT bumen FROM gongzi_peizhi WHERE gongsi = @gongsi AND bumen IS NOT NULL AND bumen != '' ORDER BY bumen";

                        cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@gongsi", gongsi);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string dept = reader["bumen"].ToString();
                            if (!string.IsNullOrEmpty(dept))
                            {
                                departments.Add(dept);
                            }
                        }
                        reader.Close();
                        conn.Close();

                        responseMessage = "获取部门数据成功";
                        isSuccess = true;

                        // 构建JSON响应
                        var serializer = new JavaScriptSerializer();
                        var response = new
                        {
                            success = isSuccess,
                            message = responseMessage,
                            data = departments
                        };

                        Response.ContentType = "application/json";
                        Response.Write(serializer.Serialize(response));
                        Response.End();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "获取部门数据失败：" + ex.Message;
                isSuccess = false;
            }

        }

        // 提交申请
        private void SubmitApplication()
        {
            string responseMessage = "";
            bool isSuccess = false;
            string gongsi = "";

            try
            {
                if (Session["gongsi"] == null)
                {
                    responseMessage = "请登录！";
                    isSuccess = false;
                }
                else
                {
                    gongsi = Session["gongsi"].ToString();
                    string conString = ConfigurationManager.AppSettings["yao"];

                    // 从Form获取参数
                    string bumen = Request.Form["bumen"] ?? "";
                    string xingming = Request.Form["xingming"] ?? "";
                    string tijiaoriqi = Request.Form["tijiaoriqi"] ?? "";
                    string shenqingyuanyin = Request.Form["shenqingyuanyin"] ?? "";
                    string shenpijieguo = Request.Form["shenpijieguo"] ?? "待审批";
                    string shenpiyuanyin = Request.Form["shenpiyuanyin"] ?? "";

                    // 验证必填字段
                    if (string.IsNullOrEmpty(bumen))
                    {
                        responseMessage = "部门不能为空！";
                        isSuccess = false;
                    }
                    else if (string.IsNullOrEmpty(xingming))
                    {
                        responseMessage = "姓名不能为空！";
                        isSuccess = false;
                    }
                    else if (string.IsNullOrEmpty(shenqingyuanyin))
                    {
                        responseMessage = "申请原因不能为空！";
                        isSuccess = false;
                    }
                    else
                    {
                        using (conn = new SqlConnection(conString))
                        {
                            string sql = @"INSERT INTO gongzi_lizhishenpi 
                                  (gongsi, bumen, xingming, tijiaoriqi, shenqingyuanyin, shenpijieguo, shenpiyuanyin) 
                                  VALUES(@gongsi, @bumen, @xingming, @tijiaoriqi, @shenqingyuanyin, @shenpijieguo, @shenpiyuanyin)";

                            cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);
                            cmd.Parameters.AddWithValue("@bumen", bumen.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@tijiaoriqi", tijiaoriqi.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenqingyuanyin", shenqingyuanyin.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenpijieguo", shenpijieguo.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenpiyuanyin", shenpiyuanyin.Replace("'", "''"));

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            conn.Close();

                            if (result > 0)
                            {
                                responseMessage = "您的离职申请已成功提交！请等待上级领导审批。";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "提交失败！";
                                isSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "提交失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }


        // 获取历史记录数据
        private void GetHistoryData()
        {
            string responseMessage = "";
            bool isSuccess = false;
            List<Dictionary<string, object>> historyData = new List<Dictionary<string, object>>();

            try
            {
                if (Session["gongsi"] == null)
                {
                    responseMessage = "请登录！";
                    isSuccess = false;
                }
                else
                {
                    string gongsi = Session["gongsi"].ToString();
                    string conString = ConfigurationManager.AppSettings["yao"];

                    // 从Form获取参数
                    string bumen = Request.Form["bumen"] ?? "";
                    string xingming = Request.Form["xingming"] ?? "";
                    int page = Convert.ToInt32(Request.Form["page"] ?? "1");
                    int pageSize = Convert.ToInt32(Request.Form["pageSize"] ?? "10");

                    // 验证必填字段
                    if (string.IsNullOrEmpty(bumen) || string.IsNullOrEmpty(xingming))
                    {
                        responseMessage = "部门和姓名为必填项";
                        isSuccess = false;
                    }
                    else
                    {
                        using (conn = new SqlConnection(conString))
                        {
                            // 构建查询语句 - 使用ROW_NUMBER()分页
                            int startRow = (page - 1) * pageSize + 1;
                            int endRow = page * pageSize;

                            string sql = @"
                                WITH NumberedRecords AS (
                                    SELECT *, 
                                           ROW_NUMBER() OVER (ORDER BY tijiaoriqi DESC, id DESC) AS RowNum 
                                    FROM gongzi_lizhishenpi 
                                    WHERE gongsi = @gongsi
                                      AND bumen = @bumen
                                      AND xingming = @xingming
                                )
                                SELECT * FROM NumberedRecords 
                                WHERE RowNum BETWEEN @startRow AND @endRow
                                ORDER BY RowNum";

                            cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);
                            cmd.Parameters.AddWithValue("@bumen", bumen.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@startRow", startRow);
                            cmd.Parameters.AddWithValue("@endRow", endRow);

                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Dictionary<string, object> record = new Dictionary<string, object>();

                                // 使用传统方式添加键值对
                                record.Add("id", reader["id"]);

                                // 处理字符串字段，确保不为null
                                object bumenValue = reader["bumen"];
                                record.Add("bumen", bumenValue != DBNull.Value ? bumenValue.ToString() : "");

                                object xingmingValue = reader["xingming"];
                                record.Add("xingming", xingmingValue != DBNull.Value ? xingmingValue.ToString() : "");

                                object tijiaoriqiValue = reader["tijiaoriqi"];
                                record.Add("tijiaoriqi", tijiaoriqiValue != DBNull.Value ? tijiaoriqiValue.ToString() : "");

                                object shenqingyuanyinValue = reader["shenqingyuanyin"];
                                record.Add("shenqingyuanyin", shenqingyuanyinValue != DBNull.Value ? shenqingyuanyinValue.ToString() : "");

                                object shenpijieguoValue = reader["shenpijieguo"];
                                record.Add("shenpijieguo", shenpijieguoValue != DBNull.Value ? shenpijieguoValue.ToString() : "");

                                object shenpiyuanyinValue = reader["shenpiyuanyin"];
                                record.Add("shenpiyuanyin", shenpiyuanyinValue != DBNull.Value ? shenpiyuanyinValue.ToString() : "");

                                historyData.Add(record);
                            }
                            reader.Close();

                            // 检查是否有更多数据
                            string countSql = "SELECT COUNT(*) FROM gongzi_lizhishenpi WHERE gongsi = @gongsi AND bumen = @bumen AND xingming = @xingming";
                            cmd = new SqlCommand(countSql, conn);
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);
                            cmd.Parameters.AddWithValue("@bumen", bumen.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));

                            int totalCount = (int)cmd.ExecuteScalar();
                            bool hasMore = (page * pageSize) < totalCount;

                            conn.Close();

                            responseMessage = "获取历史记录成功";
                            isSuccess = true;

                            // 构建JSON响应 - 手动构建JSON字符串
                            StringBuilder jsonBuilder = new StringBuilder();
                            jsonBuilder.Append("{");
                            jsonBuilder.Append("\"success\": " + isSuccess.ToString().ToLower() + ",");
                            jsonBuilder.Append("\"message\": \"" + responseMessage.Replace("\"", "\\\"") + "\",");
                            jsonBuilder.Append("\"data\": [");

                            // 添加历史数据
                            for (int i = 0; i < historyData.Count; i++)
                            {
                                var record = historyData[i];
                                jsonBuilder.Append("{");
                                jsonBuilder.Append("\"id\": " + Convert.ToString(record["id"]) + ",");
                                jsonBuilder.Append("\"bumen\": \"" + Convert.ToString(record["bumen"]).Replace("\"", "\\\"") + "\",");
                                jsonBuilder.Append("\"xingming\": \"" + Convert.ToString(record["xingming"]).Replace("\"", "\\\"") + "\",");
                                jsonBuilder.Append("\"tijiaoriqi\": \"" + Convert.ToString(record["tijiaoriqi"]).Replace("\"", "\\\"") + "\",");
                                jsonBuilder.Append("\"shenqingyuanyin\": \"" + Convert.ToString(record["shenqingyuanyin"]).Replace("\"", "\\\"") + "\",");
                                jsonBuilder.Append("\"shenpijieguo\": \"" + Convert.ToString(record["shenpijieguo"]).Replace("\"", "\\\"") + "\",");
                                jsonBuilder.Append("\"shenpiyuanyin\": \"" + Convert.ToString(record["shenpiyuanyin"]).Replace("\"", "\\\"") + "\"");
                                jsonBuilder.Append("}");

                                if (i < historyData.Count - 1)
                                {
                                    jsonBuilder.Append(",");
                                }
                            }

                            jsonBuilder.Append("],");
                            jsonBuilder.Append("\"hasMore\": " + hasMore.ToString().ToLower() + ",");
                            jsonBuilder.Append("\"totalCount\": " + totalCount + ",");
                            jsonBuilder.Append("\"currentPage\": " + page + ",");
                            jsonBuilder.Append("\"pageSize\": " + pageSize);
                            jsonBuilder.Append("}");

                            Response.ContentType = "application/json";
                            Response.Write(jsonBuilder.ToString());
                            Response.End();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "获取历史记录失败：" + ex.Message;
                isSuccess = false;
            }

            // 如果失败，返回错误响应
            Response.ContentType = "application/json";
            string errorJsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                       ", \"message\": \"" +
                                       responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                       "\", \"data\": [], \"hasMore\": false}";
            Response.Write(errorJsonResponse);
            Response.End();
        }
    }
}