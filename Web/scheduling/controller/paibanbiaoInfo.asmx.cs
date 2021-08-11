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
    /// Summary description for paibanbiaoInfo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class paibanbiaoInfo : System.Web.Services.WebService
    {
        private UserInfoService us;

        private PaibanbiaoInfoService pis;
        [WebMethod]
        public string infoList(int nowPage, int pageCount,string department_name,string plan_name)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "排班");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                pis = new PaibanbiaoInfoService();
                return ResultUtil.success(pis.list(nowPage, pageCount,department_name,plan_name), "查询成功");
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
        public string delete(int id)
        {

            {
                try
                {
                    us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("del", "排班");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {
                        return ResultUtil.error("没有权限！");
                    }

                    pis = new PaibanbiaoInfoService();
                    if (pis.delete(id))
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
        }

        [WebMethod]
        public string update(paibanbiao_info infoList)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "排班");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                pis = new PaibanbiaoInfoService();
                if (pis.update(infoList))
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
