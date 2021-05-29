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
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class module : System.Web.Services.WebService
    {

        private ModuleService ms;

        //public ResultUtil level(int parentId, int moduleType) {
        //    try
        //    {
        //        ms = new ModuleService();
        //        return ResultUtil.success(ms.list(parentId, moduleType), "查询成功");
        //    }
        //    catch (ErrorUtil err)
        //    {
        //        return ResultUtil.fail(401, err.Message);
        //    }
        //    catch
        //    {
        //        return ResultUtil.error("查询失败");
        //    }
        //}

        [WebMethod]
        public string save(module_info moduleInfo)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add","模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ms = new ModuleService();
                return ResultUtil.success(ms.save(moduleInfo), "保存成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("保存失败");
            }
        }

        [WebMethod]
        public string update(module_info moduleInfo)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ms = new ModuleService();
                return ResultUtil.success(ms.update(moduleInfo), "保存成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("保存失败");
            }
        }

        [WebMethod]
        public string delete(int id)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
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

                    ms = new ModuleService();
                    if (ms.delete(id))
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

        [WebMethod]
        public string page(PageUtil<module_info> modulePage, int moduleType) 
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ms = new ModuleService();
                return ResultUtil.success(ms.page(modulePage, moduleType), "查询成功");
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
        public string list()
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ms = new ModuleService();
                return ResultUtil.success(ms.list(), "查询成功");
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
        public string list_num_is()
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ms = new ModuleService();
                return ResultUtil.success(ms.listByNum(true), "查询成功");
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
        public string list_num()
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "模块单位");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                ms = new ModuleService();
                return ResultUtil.success(ms.listByNum(false), "查询成功");
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
