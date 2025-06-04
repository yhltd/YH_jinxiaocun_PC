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
    /// Summary description for orderCheck
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class orderCheck : System.Web.Services.WebService
    {
        private OrderCheckService ocs;
        private UserInfoService us;

        [WebMethod]
        public string getList(int nowPage, int pageCount,string order_number,string moudle,string ks,string js)
        {

            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "排产核对");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ocs = new OrderCheckService();
                return ResultUtil.success(ocs.getList(nowPage, pageCount, order_number, moudle,ks,js), "查询成功");
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
        public string save(order_check order_check)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "排产核对");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ocs = new OrderCheckService();
                if (ocs.save(order_check))
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
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("del", "排产核对");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ocs = new OrderCheckService();
                if (ocs.delete(id))
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
        public string update(order_check order_check)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "排产核对");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                ocs = new OrderCheckService();
                if (ocs.update(order_check))
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
    }
}
