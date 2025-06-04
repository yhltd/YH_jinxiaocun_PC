using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// holidayConfig 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class holidayConfig : System.Web.Services.WebService
    {

        private HolidayService hs;

        [WebMethod]
        public string holidayPage(PageUtil<holiday_config> page)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel","工作时间及休息日");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                hs = new HolidayService();
                return ResultUtil.success(hs.page(page), "查询成功");
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
                string quanxian_save1 = us.new_quanxian("del", "工作时间及休息日");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                hs = new HolidayService();
                if (hs.delete(id))
                {
                    return ResultUtil.success("删除成功");
                }
                else
                {
                    return ResultUtil.success("删除失败");
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
        public string save(string holiday)
        {
            UserInfoService us = new UserInfoService();
            string quanxian_save1 = us.new_quanxian("add", "工作时间及休息日");
            if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
            {
            }
            else
            {

                return ResultUtil.error("没有权限！");
            }

            try
            {
                hs = new HolidayService();
                if (hs.save(holiday))
                {
                    return ResultUtil.success("新增成功");
                }
                else 
                {
                    return ResultUtil.success("新增失败");
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
    }
}
