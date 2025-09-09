using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.Services;
using Web.finance.util;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;
using Web.Pushnews.model;
using Web.Pushnews.dao;


namespace Web.scheduling.controller
{
    /// <summary>
    /// user 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class user : System.Web.Services.WebService
    {
        private user_info userinfo;
        private UserInfoService uis;
        private WorkDetailDao wdd;

        [WebMethod]
        public string updatePwd(string oldPwd, string newPwd)
        {
            try {
                uis = new UserInfoService();
                user_info user = uis.updatePwd(oldPwd, newPwd);
                if (user.password == newPwd)
                {
                    return ResultUtil.success("修改成功");
                }
                else if (user.password == oldPwd)
                {
                    return ResultUtil.fail(-1, "旧密码错误");
                }
                else
                {
                    return ResultUtil.error("修改失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("修改失败");
            }
        }


        //新加
        [WebMethod]
        public string GetPushNewsData()
        {
            try
            {
                PushNewsDao dao = new PushNewsDao();
                var data = dao.SelectListPC();

                // 创建响应对象
                var response = new
                {
                    code = 200,
                    msg = "查询成功",
                    data = data
                };

                // 序列化为JSON字符串
                return Newtonsoft.Json.JsonConvert.SerializeObject(response);
            }
            catch (InvalidOperationException ex)
            {
                var errorResponse = new
                {
                    code = 500,
                    msg = "查询失败: " + ex.Message,
                    data = new List<product_pushnews>()
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    code = 500,
                    msg = "系统错误: " + ex.Message,
                    data = new List<product_pushnews>()
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(errorResponse);
            }
        }


        [WebMethod]
        public string getUsername()
        {
            userinfo = TokenUtil.getToken();
            return ResultUtil.success(userinfo.user_code, "查询成功");
        }

        [WebMethod]
        public string getDepartment()
        {
            userinfo = TokenUtil.getToken();
            return ResultUtil.success(userinfo.department_name, "查询成功");
        }


        [WebMethod]
        public string getList(int nowPage, int pageCount, string user_code)
        {

            try
            {
                UserInfoService us = new UserInfoService();


                string quanxian_save1 = us.new_quanxian("sel", "账号管理");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                uis = new UserInfoService();
                return ResultUtil.success(uis.getList(nowPage, pageCount, user_code), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("查询失败");
            }
        }


        [WebMethod]
        public string save(user_info user_info)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "账号管理");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                uis = new UserInfoService();
                List<user_info> numList = uis.getUserNum();
                int num = uis.getUserNum()[0].id;

                SqlConnection conn = null;
                SqlDataReader str = null;
                SqlCommand cmd = null;

                conn = new SqlConnection("Data Source=sqloledb;server=bds28428944.my3w.com;Database=bds28428944_db;MultipleActiveResultSets=true;Uid=bds28428944;Pwd=07910Lyh;");  //数据库连接。
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string now = DateTime.Now.ToShortDateString().ToString();
                string company = uis.getCompany();
                string sqlStr = "select CASE WHEN convert(date,endtime)< '" + now + "' THEN 1 ELSE 0 END as endtime,CASE WHEN convert(date,mark2)<'" + now + "' THEN 1 ELSE 0 END as mark2,mark1,isnull(mark3,'') as mark3 from control_soft_time where name ='" + company + "' and soft_name='排产'";
                cmd = new SqlCommand(sqlStr, conn);
                str = cmd.ExecuteReader();
                string thisNum = "";
                int a = 0;
                List<string> itemi = new List<string>();
                while (str.Read())
                {
                    thisNum = str["mark3"].ToString().Trim();
                    if (!thisNum.Equals(""))
                    {
                        thisNum = thisNum.Split(':')[1];
                        thisNum = thisNum.Replace("(", "");
                        thisNum = thisNum.Replace(")", "");
                    }
                }

                if (!thisNum.Equals(""))
                {
                    int userNum = Convert.ToInt32(thisNum);
                    if (num >= userNum)
                    {
                        return ResultUtil.error("已有账号数量过多，请删除无用账号后再试！");
                    }
                }

                if (uis.save(user_info))
                {

                    return ResultUtil.success("保存成功");
                }
                else
                {
                    return ResultUtil.error("保存失败");
                }

            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string delete(int id)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("del", "账号管理");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                uis = new UserInfoService();
                if (uis.delete(id))
                {
                    return ResultUtil.success("删除成功");
                }
                else
                {
                    return ResultUtil.error("删除失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("删除失败");
            }
        }

        [WebMethod]
        public string update(user_info user_info)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "账号管理");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                uis = new UserInfoService();
                if (uis.update(user_info))
                {
                    return ResultUtil.success("修改成功");
                }
                else
                {
                    return ResultUtil.error("修改失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("修改失败");
            }
        }

        [WebMethod]
        public string rongliang() 
        {
            userinfo = TokenUtil.getToken();
            wdd = new WorkDetailDao();
            int ky_rongliang = FinanceSpace.getFinanceSpace().getMark4_all(userinfo.company, "排产");
            int sy_rongliang = wdd.count(userinfo.company);
            //int sy_rongliang = FinanceSpace.getFinanceSpace().getUseMark4_all(userinfo.company, "排产");
            int baifenbi = sy_rongliang / ky_rongliang;
            if (sy_rongliang <= ky_rongliang*0.9)
            {
                return ResultUtil.success(baifenbi,"已使用容量不超过90%，请放心使用。");
            }
            else if (sy_rongliang <= ky_rongliang)
            {
                return ResultUtil.success(baifenbi,"您在我公司租用的数据库容量即将超出上限，请注意。");
            }
            else 
            {
                return ResultUtil.success("错误");
            }
            
        }

    }
}
