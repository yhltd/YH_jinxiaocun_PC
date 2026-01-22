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
    public partial class qingjiashenpi : System.Web.UI.Page
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        string[] str = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }

            // 处理各种操作请求
            ProcessAction(null);

            if (!IsPostBack)
            {
                str = (string[])Session["arr1"];
                if (str != null)
                {
                    // 权限控制
                    if (str.Length > 1 && str[1].ToString() == "0")
                    {
                        // 可以在这里添加权限控制
                    }
                }

                // 动态构建查询条件
                BuildSqlDataSource();

                BindGridView();
            }
        }

        private void BuildSqlDataSource()
        {
            string gongsi = Session["gongsi"] != null ? Session["gongsi"].ToString() : "";

            // 构建基础查询
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT id, bumen, xingming, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, zhuangtai, shenpiyuanyin ");
            sqlBuilder.Append("FROM gongzi_qingjiashenpi ");
            sqlBuilder.Append("WHERE gongsi = @gongsi ");

            // 获取查询条件
            bool isSearching = Session["IsSearching"] != null && (bool)Session["IsSearching"];

            if (isSearching)
            {
                // 添加额外的查询条件
                string bumen = Session["SearchBumen"] != null ? Session["SearchBumen"].ToString() : "";
                string xingming = Session["SearchXingming"] != null ? Session["SearchXingming"].ToString() : "";
                string zhuangtai = Session["SearchZhuangtai"] != null ? Session["SearchZhuangtai"].ToString() : "";

                // 构建条件
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(bumen))
                {
                    conditions.Add("bumen LIKE @bumen");
                }

                if (!string.IsNullOrEmpty(xingming))
                {
                    conditions.Add("xingming LIKE @xingming");
                }

                if (!string.IsNullOrEmpty(zhuangtai))
                {
                    conditions.Add("zhuangtai = @zhuangtai");
                }

                if (conditions.Count > 0)
                {
                    sqlBuilder.Append("AND (" + string.Join(" AND ", conditions) + ") ");
                }
            }

            sqlBuilder.Append("ORDER BY id DESC");

            // 设置 SqlDataSource
            SqlDataSource1.SelectCommand = sqlBuilder.ToString();

            // 清除现有参数
            SqlDataSource1.SelectParameters.Clear();

            // 添加公司参数
            SqlDataSource1.SelectParameters.Add("gongsi", gongsi);

            // 如果是查询模式，添加额外的参数
            if (isSearching)
            {
                string bumen = Session["SearchBumen"] != null ? Session["SearchBumen"].ToString() : "";
                string xingming = Session["SearchXingming"] != null ? Session["SearchXingming"].ToString() : "";
                string zhuangtai = Session["SearchZhuangtai"] != null ? Session["SearchZhuangtai"].ToString() : "";

                if (!string.IsNullOrEmpty(bumen))
                {
                    SqlDataSource1.SelectParameters.Add("bumen", "%" + bumen + "%");
                }

                if (!string.IsNullOrEmpty(xingming))
                {
                    SqlDataSource1.SelectParameters.Add("xingming", "%" + xingming + "%");
                }

                if (!string.IsNullOrEmpty(zhuangtai))
                {
                    SqlDataSource1.SelectParameters.Add("zhuangtai", zhuangtai);
                }
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
                case "add":
                    AddRecord();
                    break;
                case "edital":
                    EditAllFields();
                    break;
                case "delete":
                    DeleteRecord();
                    break;
                case "updatestatus":
                    UpdateStatusWithAttendance(); // 修改为更新状态并更新考勤
                    break;
                case "export":
                    ExportToExcel();
                    break;
                case "search":
                    SearchRecords();
                    break;
                case "resetsearch":
                    ResetSearch();
                    break;
                // 去掉quickadd相关处理
            }
        }

        private void BindGridView()
        {
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // 可以在这里添加行数据绑定的额外处理
        }

        // 查询记录
        private void SearchRecords()
        {
            // 获取查询条件
            string bumen = Request.Form["bumen"] ?? "";
            string xingming = Request.Form["xingming"] ?? "";
            string zhuangtai = Request.Form["zhuangtai"] ?? "";

            // 存储查询条件到Session
            Session["SearchBumen"] = bumen;
            Session["SearchXingming"] = xingming;
            Session["SearchZhuangtai"] = zhuangtai;

            // 设置标志表示正在查询
            Session["IsSearching"] = true;

            // 返回成功响应
            Response.Write("{\"success\": true, \"message\": \"查询条件已设置\"}");
            Response.End();
        }

        // 重置查询
        private void ResetSearch()
        {
            // 清除查询条件
            Session["SearchBumen"] = null;
            Session["SearchXingming"] = null;
            Session["SearchZhuangtai"] = null;
            Session["IsSearching"] = false;

            // 返回成功响应
            Response.Write("{\"success\": true, \"message\": \"查询条件已重置\"}");
            Response.End();
        }

        // 添加记录
        private void AddRecord()
        {
            string responseMessage = "";
            bool isSuccess = false;

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
                    string bumen = Request.Form["addBumen"] ?? "";
                    string xingming = Request.Form["addXingming"] ?? "";
                    string tijiaoshijian = Request.Form["addTijiaoshijian"] ?? "";
                    string qsqingjiashijian = Request.Form["addQsqingjiashijian"] ?? "";
                    string jzqingjiashijan = Request.Form["addJzqingjiashijan"] ?? "";
                    string qingjiayuanyin = Request.Form["addQingjiayuanyin"] ?? "";
                    string shenpiyuanyin = Request.Form["addShenpiyuanyin"] ?? "";
                    string zhuangtai = Request.Form["addZhuangtai"] ?? "待审批";

                    // 验证必填字段
                    if (string.IsNullOrEmpty(bumen))
                    {
                        responseMessage = "部门不能为空！";
                        isSuccess = false;
                    }
                    else if (string.IsNullOrEmpty(xingming))
                    {
                        responseMessage = "员工名称不能为空！";
                        isSuccess = false;
                    }
                    else
                    {
                        using (conn = new SqlConnection(conString))
                        {
                            string sql = @"INSERT INTO gongzi_qingjiashenpi 
                                  (gongsi, bumen, xingming, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, shenpiyuanyin, zhuangtai) 
                                  VALUES(@gongsi, @bumen, @xingming, @tijiaoshijian, @qsqingjiashijian, @jzqingjiashijan, @qingjiayuanyin, @shenpiyuanyin, @zhuangtai)";

                            cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@gongsi", gongsi);
                            cmd.Parameters.AddWithValue("@bumen", bumen.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@tijiaoshijian", tijiaoshijian.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@qsqingjiashijian", qsqingjiashijian.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@jzqingjiashijan", jzqingjiashijan.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@qingjiayuanyin", qingjiayuanyin.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@shenpiyuanyin", shenpiyuanyin.Replace("'", "''"));
                            cmd.Parameters.AddWithValue("@zhuangtai", zhuangtai.Replace("'", "''"));

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            conn.Close();

                            if (result > 0)
                            {
                                responseMessage = "添加成功！";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "添加失败！";
                                isSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "添加失败：" + ex.Message;
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

        // 批量编辑记录
        // 批量编辑记录
        private void EditAllFields()
        {
            string id = Request.Form["editRecordId"];
            string bumen = Request.Form["editBumen"];
            string xingming = Request.Form["editXingming"];
            string tijiaoshijian = Request.Form["editTijiaoshijian"];
            string qsqingjiashijian = Request.Form["editQsqingjiashijian"];
            string jzqingjiashijan = Request.Form["editJzqingjiashijan"];
            string qingjiayuanyin = Request.Form["editQingjiayuanyin"];
            string shenpiyuanyin = Request.Form["editShenpiyuanyin"];
            string zhuangtai = Request.Form["editZhuangtai"];

            if (string.IsNullOrEmpty(id))
            {
                Response.Write("<script>alert('参数错误！');</script>");
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];
            string oldStatus = "";

            try
            {
                // 首先获取原来的状态
                using (conn = new SqlConnection(conString))
                {
                    string getOldStatusSql = "SELECT zhuangtai FROM gongzi_qingjiashenpi WHERE id = @id";
                    cmd = new SqlCommand(getOldStatusSql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    oldStatus = result != null ? result.ToString() : "";
                    conn.Close();
                }

                // 更新请假记录
                using (conn = new SqlConnection(conString))
                {
                    string sql = @"UPDATE gongzi_qingjiashenpi SET 
                           bumen = @bumen, 
                           xingming = @xingming, 
                           tijiaoshijian = @tijiaoshijian, 
                           qsqingjiashijian = @qsqingjiashijian, 
                           jzqingjiashijan = @jzqingjiashijan, 
                           qingjiayuanyin = @qingjiayuanyin, 
                           shenpiyuanyin = @shenpiyuanyin, 
                           zhuangtai = @zhuangtai 
                           WHERE id = @id";

                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@bumen", (bumen ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@xingming", (xingming ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@tijiaoshijian", (tijiaoshijian ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@qsqingjiashijian", (qsqingjiashijian ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@jzqingjiashijan", (jzqingjiashijan ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@qingjiayuanyin", (qingjiayuanyin ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@shenpiyuanyin", (shenpiyuanyin ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@zhuangtai", (zhuangtai ?? "").Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    // 如果状态发生变化，更新考勤记录
                    if (rowsAffected > 0 && oldStatus != zhuangtai)
                    {
                        UpdateAttendanceForRecord(id);
                    }

                    Response.Write("<script>alert('更新成功！'); location.href='qingjiashenpi.aspx';</script>");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('更新失败：" + ex.Message.Replace("'", "\\'") + "'); history.back();</script>");
                Response.End();
            }
        }

        // 更新状态并更新考勤记录
        private void UpdateStatusWithAttendance()
        {
            string id = Request.Form["id"];
            string newStatus = Request.Form["status"];

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(newStatus))
            {
                Response.Write("{\"success\": false, \"message\": \"参数错误\"}");
                Response.End();
                return;
            }

            string conString = ConfigurationManager.AppSettings["yao"];

            try
            {
                using (conn = new SqlConnection(conString))
                {
                    // 先更新状态
                    string updateSql = "UPDATE gongzi_qingjiashenpi SET zhuangtai = @zhuangtai WHERE id = @id";
                    cmd = new SqlCommand(updateSql, conn);
                    cmd.Parameters.AddWithValue("@zhuangtai", newStatus.Replace("'", "''"));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        // 更新考勤记录
                        bool attendanceUpdated = UpdateAttendanceForRecord(id);

                        Response.Write("{\"success\": true, \"message\": \"状态更新成功" + (attendanceUpdated ? "，考勤记录已更新" : "") + "\"}");
                    }
                    else
                    {
                        Response.Write("{\"success\": false, \"message\": \"更新失败：记录不存在\"}");
                    }
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("{\"success\": false, \"message\": \"更新失败: " + ex.Message.Replace("\"", "\\\"") + "\"}");
                Response.End();
            }
        }

        // 为指定记录更新考勤记录
        private bool UpdateAttendanceForRecord(string recordId)
        {
            try
            {
                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // 获取请假记录信息
                    string query = @"SELECT xingming, qsqingjiashijian, jzqingjiashijan, gongsi, bumen, zhuangtai 
                                    FROM gongzi_qingjiashenpi 
                                    WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(recordId));

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string xingming = (reader["xingming"] != DBNull.Value) ? reader["xingming"].ToString() : "";
                        string startDate = (reader["qsqingjiashijian"] != DBNull.Value) ? reader["qsqingjiashijian"].ToString() : "";
                        string endDate = (reader["jzqingjiashijan"] != DBNull.Value) ? reader["jzqingjiashijan"].ToString() : "";
                        string gongsi = (reader["gongsi"] != DBNull.Value) ? reader["gongsi"].ToString() : "";
                        string bumen = (reader["bumen"] != DBNull.Value) ? reader["bumen"].ToString() : "";
                        string status = (reader["zhuangtai"] != DBNull.Value) ? reader["zhuangtai"].ToString() : "";

                        reader.Close();
                        conn.Close();

                        if (!string.IsNullOrEmpty(xingming) && !string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                        {
                            return UpdateAttendance(xingming, startDate, endDate, gongsi, bumen, status);
                        }
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                // 记录日志但不影响主流程
            }

            return false;
        }

        // 更新考勤记录的具体实现
        private bool UpdateAttendance(string xingming, string startDate, string endDate, string gongsi, string bumen, string status)
        {
            try
            {
                string conString = ConfigurationManager.AppSettings["yao"];

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    // 解析开始和结束日期
                    DateTime startDateTime, endDateTime;

                    if (!DateTime.TryParse(startDate, out startDateTime) || !DateTime.TryParse(endDate, out endDateTime))
                    {
                        return false;
                    }

                    // 日期字段映射
                    Dictionary<int, string> dayFieldMap = new Dictionary<int, string>
                    {
                        {1, "E"}, {2, "F"}, {3, "G"}, {4, "H"}, {5, "I"}, {6, "J"}, {7, "K"}, {8, "L"}, {9, "M"}, {10, "N"},
                        {11, "O"}, {12, "P"}, {13, "Q"}, {14, "R"}, {15, "S"}, {16, "T"}, {17, "U"}, {18, "V"}, {19, "W"}, {20, "X"},
                        {21, "Y"}, {22, "Z"}, {23, "AA"}, {24, "AB"}, {25, "AC"}, {26, "AD"}, {27, "AE"}, {28, "AF"}, {29, "AG"}, {30, "AH"}, {31, "AI"}
                    };

                    // 遍历请假期间的所有日期
                    DateTime currentDate = startDateTime;
                    while (currentDate <= endDateTime)
                    {
                        int year = currentDate.Year;
                        int month = currentDate.Month;
                        int day = currentDate.Day;

                        if (dayFieldMap.ContainsKey(day))
                        {
                            string fieldName = dayFieldMap[day];
                            string attendanceValue = (status == "通过") ? "休" : ""; // 通过时标记为"休"，否则清空

                            // 检查记录是否存在
                            string checkSql = @"SELECT COUNT(*) FROM gongzi_kaoqinjilu 
                                               WHERE name = @xingming 
                                               AND year = @year 
                                               AND moth = @month 
                                               AND AO = @gongsi";

                            SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                            checkCmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                            checkCmd.Parameters.AddWithValue("@year", year.ToString());
                            checkCmd.Parameters.AddWithValue("@month", month.ToString("00"));
                            checkCmd.Parameters.AddWithValue("@gongsi", gongsi.Replace("'", "''"));

                            conn.Open();
                            int recordCount = (int)checkCmd.ExecuteScalar();

                            if (recordCount > 0)
                            {
                                // 记录存在，更新
                                string updateSql = string.Format("UPDATE gongzi_kaoqinjilu SET {0} = @value WHERE name = @xingming AND year = @year AND moth = @month AND AO = @gongsi", fieldName);
                                SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                                updateCmd.Parameters.AddWithValue("@value", attendanceValue);
                                updateCmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                                updateCmd.Parameters.AddWithValue("@year", year.ToString());
                                updateCmd.Parameters.AddWithValue("@month", month.ToString("00"));
                                updateCmd.Parameters.AddWithValue("@gongsi", gongsi.Replace("'", "''"));
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // 记录不存在，插入新记录
                                string insertSql = string.Format("INSERT INTO gongzi_kaoqinjilu (name, year, moth, {0}, AO) VALUES (@xingming, @year, @month, @value, @gongsi)", fieldName);
                                SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                                insertCmd.Parameters.AddWithValue("@xingming", xingming.Replace("'", "''"));
                                insertCmd.Parameters.AddWithValue("@year", year.ToString());
                                insertCmd.Parameters.AddWithValue("@month", month.ToString("00"));
                                insertCmd.Parameters.AddWithValue("@value", attendanceValue);
                                insertCmd.Parameters.AddWithValue("@gongsi", gongsi.Replace("'", "''"));
                                insertCmd.ExecuteNonQuery();
                            }

                            conn.Close();
                        }

                        // 日期加1天
                        currentDate = currentDate.AddDays(1);
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 删除记录
        private void DeleteRecord()
        {
            string responseMessage = "";
            bool isSuccess = false;

            try
            {
                string id = Request.Form["id"];

                if (string.IsNullOrEmpty(id))
                {
                    responseMessage = "参数错误！";
                    isSuccess = false;
                }
                else
                {
                    string conString = ConfigurationManager.AppSettings["yao"];

                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        string sql = "DELETE FROM gongzi_qingjiashenpi WHERE id = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                            conn.Open();
                            int result = cmd.ExecuteNonQuery();
                            conn.Close();

                            if (result > 0)
                            {
                                responseMessage = "删除成功！";
                                isSuccess = true;
                            }
                            else
                            {
                                responseMessage = "删除失败：记录不存在！";
                                isSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responseMessage = "删除失败：" + ex.Message;
                isSuccess = false;
            }
            finally
            {
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" +
                                      responseMessage.Replace("\"", "\\\"").Replace("\\", "\\\\") +
                                      "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }

        // 导出Excel功能
        private void ExportToExcel()
        {
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！');</script>");
                return;
            }

            string gongsi = Session["gongsi"].ToString();
            string conString = ConfigurationManager.AppSettings["yao"];

            using (conn = new SqlConnection(conString))
            {
                string sql = @"SELECT bumen, xingming, tijiaoshijian, qsqingjiashijian, jzqingjiashijan, qingjiayuanyin, zhuangtai, shenpiyuanyin 
                               FROM gongzi_qingjiashenpi 
                               WHERE gongsi = @gongsi 
                               ORDER BY id DESC";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@gongsi", gongsi);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 导出Excel
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=请假审批管理表.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    // 添加表头
                    hw.Write("<table border='1'><tr>");
                    hw.Write("<td>部门</td>");
                    hw.Write("<td>员工名称</td>");
                    hw.Write("<td>申请时间</td>");
                    hw.Write("<td>起始请假日期</td>");
                    hw.Write("<td>截止请假日期</td>");
                    hw.Write("<td>请假原因</td>");
                    hw.Write("<td>审批状态</td>");
                    hw.Write("<td>审批原因</td>");
                    hw.Write("</tr>");

                    // 添加数据行
                    foreach (DataRow row in dt.Rows)
                    {
                        hw.Write("<tr>");
                        hw.Write("<td>" + (row["bumen"] != null ? row["bumen"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["xingming"] != null ? row["xingming"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["tijiaoshijian"] != null ? row["tijiaoshijian"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["qsqingjiashijian"] != null ? row["qsqingjiashijian"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["jzqingjiashijan"] != null ? row["jzqingjiashijan"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["qingjiayuanyin"] != null ? row["qingjiayuanyin"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["zhuangtai"] != null ? row["zhuangtai"].ToString() : "") + "</td>");
                        hw.Write("<td>" + (row["shenpiyuanyin"] != null ? row["shenpiyuanyin"].ToString() : "") + "</td>");
                        hw.Write("</tr>");
                    }

                    hw.Write("</table>");
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }

        // 获取状态样式（用于前端调用）
        public string GetStatusClass(string status)
        {
            if (string.IsNullOrEmpty(status)) return "status-daishanpi";

            switch (status.ToLower())
            {
                case "通过":
                    return "status-tongguo";
                case "驳回":
                    return "status-bohui";
                case "待审批":
                    return "status-daishanpi";
                default:
                    return "status-daishanpi";
            }
        }
    }
}