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
    public partial class gongzuoshijian : System.Web.UI.Page
    {
        private string companyName = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // 检查登录
            if (Session["gongsi"] == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                return;
            }
            
            companyName = Session["gongsi"].ToString();
            
            // 处理各种操作请求
            ProcessAction();
        }
        
        private void ProcessAction()
        {
            string action = Request.Form["action"];
            if (string.IsNullOrEmpty(action))
                return;

            switch (action.ToLower())
            {
                case "saveschedule":
                    SaveSchedule();
                    break;
                case "loadschedules":
                    LoadSchedules();
                    break;
                case "updateworkdays":
                    UpdateWorkDays();
                    break;
                case "updatetime":
                    UpdateTime();
                    break;
                case "deleteschedule":
                    DeleteSchedule();
                    break;
            }
        }
        
        // 保存工作安排
        private void SaveSchedule()
        {
            string responseMessage = "";
            bool isSuccess = false;
            
            try
            {
                string scheduleDataJson = Request.Form["scheduleData"] ?? "";
                if (string.IsNullOrEmpty(scheduleDataJson))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                    return;
                }
                
                var scheduleData = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(scheduleDataJson);
                
                // 验证数据
                if (!scheduleData.ContainsKey("gongsi") || string.IsNullOrEmpty(scheduleData["gongsi"].ToString()))
                {
                    responseMessage = "公司信息不能为空";
                    isSuccess = false;
                    return;
                }
                
                // 准备插入数据
                string gongzuoshijianks = scheduleData.ContainsKey("gongzuoshijianks") ? scheduleData["gongzuoshijianks"].ToString() : "";
                string gongzuoshijianjs = scheduleData.ContainsKey("gongzuoshijianjs") ? scheduleData["gongzuoshijianjs"].ToString() : "";
                string wuxiushijianks = scheduleData.ContainsKey("wuxiushijianks") ? scheduleData["wuxiushijianks"].ToString() : "";
                string wuxiushijianjs = scheduleData.ContainsKey("wuxiushijianjs") ? scheduleData["wuxiushijianjs"].ToString() : "";
                string year_month = scheduleData.ContainsKey("year_month") ? scheduleData["year_month"].ToString() : "";
                string riqi = scheduleData.ContainsKey("riqi") ? scheduleData["riqi"].ToString() : "";
                string gongsi = scheduleData.ContainsKey("gongsi") ? scheduleData["gongsi"].ToString() : "";
                string work_days = scheduleData.ContainsKey("work_days") ? scheduleData["work_days"].ToString() : "[]";
                string repeat_type = scheduleData.ContainsKey("repeat_type") ? scheduleData["repeat_type"].ToString() : "none";
                string schedule_title = scheduleData.ContainsKey("schedule_title") ? scheduleData["schedule_title"].ToString() : "";
                string schedule_status = scheduleData.ContainsKey("schedule_status") ? scheduleData["schedule_status"].ToString() : "active";
                
                string conString = ConfigurationManager.AppSettings["yao"];
                
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = @"INSERT INTO gongzi_gongzuoshijian 
                                (gongzuoshijianks, gongzuoshijianjs, wuxiushijianks, wuxiushijianjs, 
                                 year_month, riqi, gongsi, work_days, repeat_type, 
                                 schedule_title, schedule_status) 
                                VALUES (@gongzuoshijianks, @gongzuoshijianjs, @wuxiushijianks, @wuxiushijianjs,
                                        @year_month, @riqi, @gongsi, @work_days, @repeat_type,
                                        @schedule_title, @schedule_status)";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gongzuoshijianks", gongzuoshijianks);
                    cmd.Parameters.AddWithValue("@gongzuoshijianjs", gongzuoshijianjs);
                    cmd.Parameters.AddWithValue("@wuxiushijianks", wuxiushijianks);
                    cmd.Parameters.AddWithValue("@wuxiushijianjs", wuxiushijianjs);
                    cmd.Parameters.AddWithValue("@year_month", year_month);
                    cmd.Parameters.AddWithValue("@riqi", riqi);
                    cmd.Parameters.AddWithValue("@gongsi", gongsi);
                    cmd.Parameters.AddWithValue("@work_days", work_days);
                    cmd.Parameters.AddWithValue("@repeat_type", repeat_type);
                    cmd.Parameters.AddWithValue("@schedule_title", schedule_title);
                    cmd.Parameters.AddWithValue("@schedule_status", schedule_status);
                    
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    if (rowsAffected > 0)
                    {
                        responseMessage = "保存成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "保存失败";
                        isSuccess = false;
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
                // 返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" + responseMessage.Replace("\"", "\\\"") + "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }
        
        // 加载工作安排
        private void LoadSchedules()
        {
            string responseMessage = "";
            bool isSuccess = false;
            List<Dictionary<string, object>> schedules = null;
            
            try
            {
                string conString = ConfigurationManager.AppSettings["yao"];
                
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = @"SELECT * FROM gongzi_gongzuoshijian 
                                   WHERE gongsi = @gongsi AND schedule_status = 'active'
                                   ORDER BY id DESC";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@gongsi", companyName);
                    
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    schedules = new List<Dictionary<string, object>>();
                    while (reader.Read())
                    {
                        var schedule = new Dictionary<string, object>
                        {
                            { "id", reader["id"] != DBNull.Value ? reader["id"] : null },
                            { "gongzuoshijianks", reader["gongzuoshijianks"] != DBNull.Value ? reader["gongzuoshijianks"] : "" },
                            { "gongzuoshijianjs", reader["gongzuoshijianjs"] != DBNull.Value ? reader["gongzuoshijianjs"] : "" },
                            { "wuxiushijianks", reader["wuxiushijianks"] != DBNull.Value ? reader["wuxiushijianks"] : "" },
                            { "wuxiushijianjs", reader["wuxiushijianjs"] != DBNull.Value ? reader["wuxiushijianjs"] : "" },
                            { "year_month", reader["year_month"] != DBNull.Value ? reader["year_month"] : "" },
                            { "riqi", reader["riqi"] != DBNull.Value ? reader["riqi"] : "" },
                            { "gongsi", reader["gongsi"] != DBNull.Value ? reader["gongsi"] : "" },
                            { "work_days", new List<string>() },
                            { "repeat_type", reader["repeat_type"] != DBNull.Value ? reader["repeat_type"] : "none" },
                            { "schedule_title", reader["schedule_title"] != DBNull.Value ? reader["schedule_title"] : "" },
                            { "schedule_status", reader["schedule_status"] != DBNull.Value ? reader["schedule_status"] : "active" }
                        };
                        
                        // 解析work_days
                        if (reader["work_days"] != DBNull.Value && !string.IsNullOrEmpty(reader["work_days"].ToString()))
                        {
                            try
                            {
                                var workDays = new JavaScriptSerializer().Deserialize<List<string>>(reader["work_days"].ToString());
                                schedule["work_days"] = workDays ?? new List<string>();
                            }
                            catch
                            {
                                schedule["work_days"] = new List<string>();
                            }
                        }
                        
                        schedules.Add(schedule);
                    }
                    reader.Close();
                    conn.Close();
                    
                    responseMessage = "加载成功";
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseMessage = "加载失败：" + ex.Message;
                isSuccess = false;
                schedules = new List<Dictionary<string, object>>();
            }
            finally
            {
                // 返回JSON响应
                Response.ContentType = "application/json";
                if (isSuccess)
                {
                    Response.Write(new JavaScriptSerializer().Serialize(new
                    {
                        success = true,
                        schedules = schedules,
                        message = responseMessage
                    }));
                }
                else
                {
                    Response.Write(new JavaScriptSerializer().Serialize(new
                    {
                        success = false,
                        message = responseMessage
                    }));
                }
                Response.End();
            }
        }
        
        // 更新工作日期
        private void UpdateWorkDays()
        {
            string responseMessage = "";
            bool isSuccess = false;
            
            try
            {
                string id = Request.Form["id"] ?? "";
                string work_days = Request.Form["work_days"] ?? "[]";
                
                if (string.IsNullOrEmpty(id))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                    return;
                }
                
                string conString = ConfigurationManager.AppSettings["yao"];
                
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = @"UPDATE gongzi_gongzuoshijian 
                                   SET work_days = @work_days
                                   WHERE id = @id AND gongsi = @gongsi";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@work_days", work_days);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.Parameters.AddWithValue("@gongsi", companyName);
                    
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    if (rowsAffected > 0)
                    {
                        responseMessage = "保存成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "保存失败，记录不存在";
                        isSuccess = false;
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
                // 返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" + responseMessage.Replace("\"", "\\\"") + "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }
        
        // 更新时间
        private void UpdateTime()
        {
            string responseMessage = "";
            bool isSuccess = false;
            
            try
            {
                string id = Request.Form["id"] ?? "";
                string field = Request.Form["field"] ?? "";
                string startTime = Request.Form["startTime"] ?? "";
                string endTime = Request.Form["endTime"] ?? "";
                
                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(field))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                    return;
                }
                
                string conString = ConfigurationManager.AppSettings["yao"];
                
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = "";
                    
                    if (field == "gongzuoshijian")
                    {
                        sql = @"UPDATE gongzi_gongzuoshijian 
                               SET gongzuoshijianks = @startTime, 
                                   gongzuoshijianjs = @endTime
                               WHERE id = @id AND gongsi = @gongsi";
                    }
                    else if (field == "wuxiushijian")
                    {
                        sql = @"UPDATE gongzi_gongzuoshijian 
                               SET wuxiushijianks = @startTime, 
                                   wuxiushijianjs = @endTime
                               WHERE id = @id AND gongsi = @gongsi";
                    }
                    else
                    {
                        responseMessage = "字段类型错误";
                        isSuccess = false;
                        return;
                    }
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@startTime", startTime);
                    cmd.Parameters.AddWithValue("@endTime", endTime);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.Parameters.AddWithValue("@gongsi", companyName);
                    
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    if (rowsAffected > 0)
                    {
                        responseMessage = "保存成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "保存失败，记录不存在";
                        isSuccess = false;
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
                // 返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" + responseMessage.Replace("\"", "\\\"") + "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }
        
        // 删除工作安排
        private void DeleteSchedule()
        {
            string responseMessage = "";
            bool isSuccess = false;
            
            try
            {
                string id = Request.Form["id"] ?? "";
                
                if (string.IsNullOrEmpty(id))
                {
                    responseMessage = "参数错误";
                    isSuccess = false;
                    return;
                }
                
                string conString = ConfigurationManager.AppSettings["yao"];
                
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sql = @"DELETE FROM gongzi_gongzuoshijian 
                                   WHERE id = @id AND gongsi = @gongsi";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                    cmd.Parameters.AddWithValue("@gongsi", companyName);
                    
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    if (rowsAffected > 0)
                    {
                        responseMessage = "删除成功";
                        isSuccess = true;
                    }
                    else
                    {
                        responseMessage = "删除失败，记录不存在";
                        isSuccess = false;
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
                // 返回JSON响应
                Response.ContentType = "application/json";
                string jsonResponse = "{\"success\": " + isSuccess.ToString().ToLower() +
                                      ", \"message\": \"" + responseMessage.Replace("\"", "\\\"") + "\"}";
                Response.Write(jsonResponse);
                Response.End();
            }
        }
        
    }
}