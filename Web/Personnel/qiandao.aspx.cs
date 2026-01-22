using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Web.Script.Serialization;

namespace Web.Personnel
{
    public partial class qiandao : System.Web.UI.Page
    {
        private string companyName = "";
        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            // 检查登录
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            companyName = Session["gongsi"].ToString();

            // 如果不是PostBack且不是AJAX请求，则加载部门数据
            if (!IsPostBack && string.IsNullOrEmpty(Request.Form["action"]))
            {
                LoadDepartments();
            }
            else
            {
                // 处理AJAX请求
                ProcessAction();
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

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // 查询gongzi_peizhi表中唯一的部门列表
                    string sql = "SELECT DISTINCT bumen FROM gongzi_peizhi WHERE gongsi = @gongsi AND bumen IS NOT NULL AND bumen != '' ORDER BY bumen";

                    SqlCommand cmd = new SqlCommand(sql, conn);
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

                    // 生成JavaScript代码来设置下拉选项
                    if (departments.Count > 0)
                    {
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
                        script.Append("   var $departmentInput = $('#department');");
                        script.Append("   if ($departmentInput.length > 0) {");
                        script.Append("       // 将输入框改为下拉选择框");
                        script.Append("       var $select = $('<select id=\"department\" class=\"form-input\"></select>');");
                        script.Append("       $select.append('<option value=\"\">请选择部门</option>');");
                        script.Append("       $.each(departments, function(index, dept) {");
                        script.Append("           $select.append('<option value=\"' + dept + '\">' + dept + '</option>');");
                        script.Append("       });");
                        script.Append("       // 替换输入框");
                        script.Append("       $departmentInput.replaceWith($select);");
                        script.Append("       // 如果有保存的部门值，设置选中状态");
                        script.Append("       var savedDept = getCookie('qiandao_department');");
                        script.Append("       if (savedDept) {");
                        script.Append("           $select.val(savedDept);");
                        script.Append("       }");
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

        private void ProcessAction()
        {
            string action = Request.Form["action"];
            if (string.IsNullOrEmpty(action))
                return;

            switch (action.ToLower())
            {
                case "checktodayattendance":
                    CheckTodayAttendance();
                    break;
                case "gettodaystatus":
                    GetTodayStatus();
                    break;
                case "saveattendance":
                    SaveAttendance();
                    break;
                case "loadworkschedule":
                    LoadWorkSchedule();
                    break;
                case "loadleaverequests":
                    LoadLeaveRequests();
                    break;
                case "submitleave":
                    SubmitLeave();
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

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        // 查询gongzi_peizhi表中唯一的部门列表
                        string sql = "SELECT DISTINCT bumen FROM gongzi_peizhi WHERE gongsi = @gongsi AND bumen IS NOT NULL AND bumen != '' ORDER BY bumen";

                        SqlCommand cmd = new SqlCommand(sql, conn);
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
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "获取部门数据失败：" + ex.Message;
                isSuccess = false;
            }

            // 构建JSON响应
            var response = new Dictionary<string, object>
            {
                { "success", isSuccess },
                { "message", responseMessage },
                { "data", departments }
            };

            Response.ContentType = "application/json";
            Response.Write(serializer.Serialize(response));
            Response.End();
        }

        // 检查今日考勤记录
        private void CheckTodayAttendance()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string userName = Request.Form["userName"] ?? "";
                string year = Request.Form["year"] ?? "";
                string month = Request.Form["month"] ?? "";
                string day = Request.Form["day"] ?? "";
                string company = Request.Form["companyName"] ?? companyName;

                if (string.IsNullOrEmpty(userName))
                {
                    responseMessage = "用户名为空";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];
                    string todayStatus = "";

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        // 获取对应日期的字段名
                        int dayNum;
                        if (!int.TryParse(day, out dayNum))
                        {
                            responseMessage = "日期格式错误";
                            isSuccess = false;
                        }
                        else
                        {
                            // 1-31天对应的字段映射
                            string dayField = GetDayField(dayNum);
                            if (string.IsNullOrEmpty(dayField))
                            {
                                responseMessage = "日期超出范围";
                                isSuccess = false;
                            }
                            else
                            {
                                // 使用字符串拼接字段名，但参数化其他值
                                string sql = string.Format("SELECT [{0}] as todayStatus FROM gongzi_kaoqinjilu " +
                                                         "WHERE name = @userName AND year = @year AND moth = @month AND AO = @company",
                                                         dayField);

                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@userName", userName);
                                cmd.Parameters.AddWithValue("@year", year);
                                cmd.Parameters.AddWithValue("@month", month);
                                cmd.Parameters.AddWithValue("@company", company);

                                conn.Open();
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    todayStatus = reader["todayStatus"] != DBNull.Value ? reader["todayStatus"].ToString() : "";
                                }
                                reader.Close();

                                responseMessage = "查询成功";
                                isSuccess = true;
                                responseData = new { todayStatus = todayStatus };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "查询失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                if (responseData != null)
                {
                    response["data"] = responseData;
                }

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 辅助方法：根据日期获取字段名
        private string GetDayField(int day)
        {
            if (day < 1 || day > 31) return "";

            // 第1-31天对应的字段名映射
            string[] fields = {
                "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
                "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI"
            };

            return fields[day - 1];
        }

        // 获取今日状态
        private void GetTodayStatus()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string userName = Request.Form["userName"] ?? "";
                string year = Request.Form["year"] ?? "";
                string month = Request.Form["month"] ?? "";
                string day = Request.Form["day"] ?? "";
                string company = Request.Form["companyName"] ?? companyName;

                if (string.IsNullOrEmpty(userName))
                {
                    responseMessage = "用户名为空";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];
                    string todayStatus = "";

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        // 获取对应日期的字段名
                        int dayNum;
                        if (!int.TryParse(day, out dayNum))
                        {
                            responseMessage = "日期格式错误";
                            isSuccess = false;
                        }
                        else
                        {
                            string dayField = GetDayField(dayNum);
                            if (string.IsNullOrEmpty(dayField))
                            {
                                responseMessage = "日期超出范围";
                                isSuccess = false;
                            }
                            else
                            {
                                // 使用字符串拼接字段名
                                string sql = string.Format("SELECT [{0}] as todayStatus FROM gongzi_kaoqinjilu " +
                                                         "WHERE name = @userName AND year = @year AND moth = @month AND AO = @company",
                                                         dayField);

                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@userName", userName);
                                cmd.Parameters.AddWithValue("@year", year);
                                cmd.Parameters.AddWithValue("@month", month);
                                cmd.Parameters.AddWithValue("@company", company);

                                conn.Open();
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    todayStatus = reader["todayStatus"] != DBNull.Value ? reader["todayStatus"].ToString() : "";
                                }
                                reader.Close();

                                responseMessage = "查询成功";
                                isSuccess = true;
                                responseData = new { todayStatus = todayStatus };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "查询失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                if (responseData != null)
                {
                    response["data"] = responseData;
                }

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 保存考勤记录
        private void SaveAttendance()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string type = Request.Form["type"] ?? "";
                string status = Request.Form["status"] ?? "";
                string time = Request.Form["time"] ?? "";
                string userName = Request.Form["userName"] ?? "";
                string year = Request.Form["year"] ?? "";
                string month = Request.Form["month"] ?? "";
                string day = Request.Form["day"] ?? "";
                string dayField = Request.Form["dayField"] ?? "";
                string company = Request.Form["companyName"] ?? companyName;
                string isNormal = Request.Form["isNormal"] ?? "true";
                string message = Request.Form["message"] ?? "";

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(dayField))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        // 先检查记录是否存在
                        string checkSql = "SELECT id FROM gongzi_kaoqinjilu " +
                                            "WHERE name = @userName AND year = @year AND moth = @month AND AO = @company";

                        SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                        checkCmd.Parameters.AddWithValue("@userName", userName);
                        checkCmd.Parameters.AddWithValue("@year", year);
                        checkCmd.Parameters.AddWithValue("@month", month);
                        checkCmd.Parameters.AddWithValue("@company", company);

                        conn.Open();
                        object result = checkCmd.ExecuteScalar();

                        if (result != null)
                        {
                            // 记录存在，更新 - 使用字符串拼接字段名
                            string updateSql = string.Format("UPDATE gongzi_kaoqinjilu SET [{0}] = @status " +
                                                            "WHERE name = @userName AND year = @year AND moth = @month AND AO = @company",
                                                            dayField);

                            SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                            updateCmd.Parameters.AddWithValue("@status", status);
                            updateCmd.Parameters.AddWithValue("@userName", userName);
                            updateCmd.Parameters.AddWithValue("@year", year);
                            updateCmd.Parameters.AddWithValue("@month", month);
                            updateCmd.Parameters.AddWithValue("@company", company);

                            int rows = updateCmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                // 更新统计信息
                                UpdateAttendanceStatistics(userName, year, month, company);
                                responseMessage = "考勤记录更新成功";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "更新失败";
                                isSuccess = false;
                            }
                        }
                        else
                        {
                            // 记录不存在，插入新记录 - 使用字符串拼接字段名
                            string insertSql = string.Format("INSERT INTO gongzi_kaoqinjilu (name, year, moth, [{0}], AO) " +
                                                            "VALUES (@userName, @year, @month, @status, @company)",
                                                            dayField);

                            SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                            insertCmd.Parameters.AddWithValue("@userName", userName);
                            insertCmd.Parameters.AddWithValue("@year", year);
                            insertCmd.Parameters.AddWithValue("@month", month);
                            insertCmd.Parameters.AddWithValue("@status", status);
                            insertCmd.Parameters.AddWithValue("@company", company);

                            int rows = insertCmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                // 更新统计信息
                                UpdateAttendanceStatistics(userName, year, month, company);
                                responseMessage = "考勤记录插入成功";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "插入失败";
                                isSuccess = false;
                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "保存失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                if (responseData != null)
                {
                    response["data"] = responseData;
                }

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 更新统计信息
        private void UpdateAttendanceStatistics(string userName, string year, string month, string company)
        {
            try
            {
                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // 先查询所有日期的状态
                    string selectSql = @"SELECT 
                                        E, F, G, H, I, J, K, L, M, N,
                                        O, P, Q, R, S, T, U, V, W, X,
                                        Y, Z, AA, AB, AC, AD, AE, AF, AG, AH, AI
                                        FROM gongzi_kaoqinjilu 
                                        WHERE name = @userName AND year = @year AND moth = @month AND AO = @company";

                    SqlCommand selectCmd = new SqlCommand(selectSql, conn);
                    selectCmd.Parameters.AddWithValue("@userName", userName);
                    selectCmd.Parameters.AddWithValue("@year", year);
                    selectCmd.Parameters.AddWithValue("@month", month);
                    selectCmd.Parameters.AddWithValue("@company", company);

                    conn.Open();
                    SqlDataReader reader = selectCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int attendanceCount = 0;
                        int lateEarlyCount = 0;

                        // 遍历所有字段
                        string[] fields = { "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                                          "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
                                          "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI" };

                        foreach (string field in fields)
                        {
                            string value = reader[field] != DBNull.Value ? reader[field].ToString() : "";

                            if (!string.IsNullOrEmpty(value))
                            {
                                // 判断是否出勤
                                if (value == "出勤" || value == "早签" || value == "迟到" || value == "早退")
                                {
                                    attendanceCount++;
                                }

                                // 判断是否迟到或早退
                                if (value == "迟到" || value == "早退")
                                {
                                    lateEarlyCount++;
                                }
                            }
                        }

                        reader.Close();

                        // 更新统计字段
                        string updateSql = @"UPDATE gongzi_kaoqinjilu 
                                           SET AJ = @attendanceCount, AN = @lateEarlyCount
                                           WHERE name = @userName AND year = @year AND moth = @month AND AO = @company";

                        SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                        updateCmd.Parameters.AddWithValue("@attendanceCount", attendanceCount);
                        updateCmd.Parameters.AddWithValue("@lateEarlyCount", lateEarlyCount);
                        updateCmd.Parameters.AddWithValue("@userName", userName);
                        updateCmd.Parameters.AddWithValue("@year", year);
                        updateCmd.Parameters.AddWithValue("@month", month);
                        updateCmd.Parameters.AddWithValue("@company", company);

                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // 统计失败不影响主流程
                Console.WriteLine("统计更新失败：" + ex.Message);
            }
        }

        // 加载工作安排
        private void LoadWorkSchedule()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string department = Request.Form["department"] ?? "";
                string userName = Request.Form["userName"] ?? "";
                string dateStr = Request.Form["dateStr"] ?? "";
                string company = Request.Form["companyName"] ?? companyName;

                if (string.IsNullOrEmpty(department) || string.IsNullOrEmpty(userName))
                {
                    responseMessage = "部门或姓名为空";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];
                    Dictionary<string, object> schedule = null;

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        // 查询今日工作安排
                        string sql = @"SELECT TOP 1 * FROM gongzi_gongzuoshijian 
                                     WHERE schedule_status = 'active' 
                                     AND work_days LIKE '%' + @dateStr + '%'
                                     AND (schedule_title LIKE '%' + @department + '%' OR schedule_title LIKE '%' + @userName + '%')
                                     AND gongsi = @company
                                     ORDER BY id DESC";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@dateStr", dateStr);
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@company", company);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            schedule = new Dictionary<string, object>();
                            schedule["schedule_title"] = reader["schedule_title"] != DBNull.Value ? reader["schedule_title"].ToString() : "";
                            schedule["gongzuoshijianks"] = reader["gongzuoshijianks"] != DBNull.Value ? reader["gongzuoshijianks"].ToString() : "";
                            schedule["gongzuoshijianjs"] = reader["gongzuoshijianjs"] != DBNull.Value ? reader["gongzuoshijianjs"].ToString() : "";
                            schedule["wuxiushijianks"] = reader["wuxiushijianks"] != DBNull.Value ? reader["wuxiushijianks"].ToString() : "";
                            schedule["wuxiushijianjs"] = reader["wuxiushijianjs"] != DBNull.Value ? reader["wuxiushijianjs"].ToString() : "";

                            // 解析work_days
                            string workDaysJson = reader["work_days"] != DBNull.Value ? reader["work_days"].ToString() : "[]";
                            try
                            {
                                var workDays = serializer.Deserialize<List<string>>(workDaysJson);
                                schedule["work_days"] = workDays != null ? workDays.Count : 0;
                            }
                            catch
                            {
                                schedule["work_days"] = 0;
                            }
                        }
                        reader.Close();
                    }

                    if (schedule != null)
                    {
                        responseMessage = "查询成功";
                        isSuccess = true;
                        responseData = new { schedule = schedule };
                    }
                    else
                    {
                        responseMessage = "今日无工作安排";
                        isSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "查询失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                if (responseData != null)
                {
                    response["data"] = responseData;
                }

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 加载请假记录
        private void LoadLeaveRequests()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string userName = Request.Form["userName"] ?? "";
                string company = Request.Form["companyName"] ?? companyName;

                if (string.IsNullOrEmpty(userName))
                {
                    responseMessage = "用户名为空";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];
                    List<Dictionary<string, object>> records = new List<Dictionary<string, object>>();

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = @"SELECT TOP 10 * FROM gongzi_qingjiashenpi 
                                     WHERE xingming = @userName AND gongsi = @company
                                     ORDER BY id DESC";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@company", company);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var record = new Dictionary<string, object>();
                            record["id"] = reader["id"] != DBNull.Value ? reader["id"] : 0;
                            record["qsqingjiashijian"] = reader["qsqingjiashijian"] != DBNull.Value ? Convert.ToDateTime(reader["qsqingjiashijian"]).ToString("yyyy-MM-dd") : "";
                            record["jzqingjiashijan"] = reader["jzqingjiashijan"] != DBNull.Value ? Convert.ToDateTime(reader["jzqingjiashijan"]).ToString("yyyy-MM-dd") : "";
                            record["qingjiayuanyin"] = reader["qingjiayuanyin"] != DBNull.Value ? reader["qingjiayuanyin"].ToString() : "";
                            record["zhuangtai"] = reader["zhuangtai"] != DBNull.Value ? reader["zhuangtai"].ToString() : "待审批";

                            // 计算请假天数
                            if (!string.IsNullOrEmpty(record["qsqingjiashijian"].ToString()) && !string.IsNullOrEmpty(record["jzqingjiashijan"].ToString()))
                            {
                                DateTime startDate = Convert.ToDateTime(record["qsqingjiashijian"]);
                                DateTime endDate = Convert.ToDateTime(record["jzqingjiashijan"]);
                                TimeSpan diff = endDate - startDate;
                                record["daysCount"] = diff.Days + 1;
                            }
                            else
                            {
                                record["daysCount"] = 0;
                            }

                            // 设置状态颜色
                            string status = record["zhuangtai"].ToString();
                            record["statusColor"] = GetStatusColor(status);

                            records.Add(record);
                        }
                        reader.Close();
                    }

                    responseMessage = "查询成功";
                    isSuccess = true;
                    responseData = new { records = records };
                }
            }
            catch (Exception ex)
            {
                responseMessage = "查询失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                if (responseData != null)
                {
                    response["data"] = responseData;
                }

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 提交请假申请
        private void SubmitLeave()
        {
            string responseMessage = "";
            bool isSuccess = false;
            object responseData = null;

            try
            {
                string department = Request.Form["department"] ?? "";
                string userName = Request.Form["userName"] ?? "";
                string company = Request.Form["companyName"] ?? companyName;
                string startDate = Request.Form["startDate"] ?? "";
                string endDate = Request.Form["endDate"] ?? "";
                string reason = Request.Form["reason"] ?? "";
                string days = Request.Form["days"] ?? "";

                if (string.IsNullOrEmpty(department) || string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate) || string.IsNullOrEmpty(reason))
                {
                    responseMessage = "参数不完整";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string submitTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        string sql = @"INSERT INTO gongzi_qingjiashenpi 
                                     (bumen, xingming, gongsi, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, zhuangtai, shenpiyuanyin) 
                                     VALUES (@bumen, @xingming, @gongsi, @tijiaoshijian, @qsqingjiashijian, @jzqingjiashijan, @qingjiayuanyin, '待审批', '')";

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@bumen", department);
                        cmd.Parameters.AddWithValue("@xingming", userName);
                        cmd.Parameters.AddWithValue("@gongsi", company);
                        cmd.Parameters.AddWithValue("@tijiaoshijian", submitTime);
                        cmd.Parameters.AddWithValue("@qsqingjiashijian", startDate);
                        cmd.Parameters.AddWithValue("@jzqingjiashijan", endDate);
                        cmd.Parameters.AddWithValue("@qingjiayuanyin", reason);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            responseMessage = "请假申请提交成功";
                            isSuccess = true;
                        }
                        else
                        {
                            responseMessage = "提交失败";
                            isSuccess = false;
                        }
                        conn.Close();
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
                // 统一在 finally 块中返回响应
                Response.ContentType = "application/json";
                var response = new Dictionary<string, object>
                {
                    { "success", isSuccess },
                    { "message", responseMessage }
                };

                if (responseData != null)
                {
                    response["data"] = responseData;
                }

                Response.Write(serializer.Serialize(response));
                Response.End();
            }
        }

        // 根据状态获取颜色
        private string GetStatusColor(string status)
        {
            switch (status)
            {
                case "待审批":
                    return "orange";
                case "通过":
                    return "green";
                case "驳回":
                    return "red";
                default:
                    return "gray";
            }
        }
    }
}