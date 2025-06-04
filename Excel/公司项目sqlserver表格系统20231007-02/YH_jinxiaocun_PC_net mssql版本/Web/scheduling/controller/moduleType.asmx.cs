using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// moduleType 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class moduleType : System.Web.Services.WebService
    {

        private ModuleTypeService mts;

        [WebMethod]
        public string list()
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "汇总");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                mts = new ModuleTypeService();
                return ResultUtil.success(mts.list(), "查询成功");
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
        public string add(module_type moduleType)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                mts = new ModuleTypeService();
                moduleType = mts.save(moduleType);
                if (moduleType.id > 0)
                {
                    return ResultUtil.success(moduleType, "添加成功");
                }
                else
                {
                    return ResultUtil.success("未添加");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("添加失败");
            }
        }

        [WebMethod]
        public string delete(int id)
        {
            UserInfoService us = new UserInfoService();
            string quanxian_save1 = us.new_quanxian("del", "模块单位");
            if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
            {
            }
            else
            {

                return ResultUtil.error("没有权限！");
            }

            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    mts = new ModuleTypeService();
                    if (mts.delete(id))
                    {
                        tran.Complete();
                        return ResultUtil.success("删除成功");
                    }
                    else
                    {
                        return ResultUtil.success("未删除");
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
    }
}
