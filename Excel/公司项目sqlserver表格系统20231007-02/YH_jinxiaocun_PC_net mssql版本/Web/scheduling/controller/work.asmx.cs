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
    /// work 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class work : System.Web.Services.WebService
    {
        private WorkDetailService wds;
        private ModuleService ms;
        [WebMethod]
        public string page(int nowPage, int pageCount, string orderId,string type)
        {
            UserInfoService us = new UserInfoService();
            string quanxian_save1 = us.new_quanxian("sel","排产");
            if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
            {
            }
            else
            {

                return ResultUtil.error("没有权限！");
            }

            try
            {
                wds = new WorkDetailService();
                return ResultUtil.success(wds.list(nowPage, pageCount, orderId,type), "排产成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (TimeError err)
            {
                return ResultUtil.error(err.Message);
            }
            catch
            {
                return ResultUtil.error("排产失败");
            }

        }

        [WebMethod]
        public string save(work_detail workDetail, List<int> workModuleIdList)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    UserInfoService us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("add", "排产");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {

                        return ResultUtil.error("没有权限！");
                    }

                    wds = new WorkDetailService();
                    if (wds.save(workDetail, workModuleIdList))
                    {
                        tran.Complete();
                        return ResultUtil.success("添加成功");
                    }
                    else
                    {
                        return ResultUtil.success("添加失败");
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
        }

        [WebMethod]
        public string plSave(List<work_detail> plList, List<int> workModuleIdList)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    UserInfoService us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("add", "排产");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {

                        return ResultUtil.error("没有权限！");
                    }

                    wds = new WorkDetailService();
                    if (wds.plSave(plList, workModuleIdList))
                    {
                        tran.Complete();
                        return ResultUtil.success("添加成功");
                    }
                    else
                    {
                        return ResultUtil.success("添加失败");
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
        }

        [WebMethod]
        public string deleteWork(string rowNum)
        {
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    UserInfoService us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("del", "排产");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {

                        return ResultUtil.error("没有权限！");
                    }

                    wds = new WorkDetailService();
                    if (wds.deleteWork(rowNum))
                    {
                        tran.Complete();
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
        public string channeng(List<int> workModuleIdList,DateTime ks,DateTime js,double scsl,string is_insert,string type)
        {
            //ms = new ModuleService();
            //return ResultUtil.success(ms.listByNum(true), "查询成功");

            UserInfoService us = new UserInfoService();
            string quanxian_save1 = us.new_quanxian("sel", "排产");
            if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
            {
            }
            else
            {
                return ResultUtil.error("没有权限！");
            }

            try
            {
                wds = new WorkDetailService();
                if (wds.channeng1(workModuleIdList, ks, js, scsl,is_insert,type))
                {
                    return ResultUtil.success("产能足够，可以排产！");
                }
                else
                {
                    return ResultUtil.error("产能不足，请调整计划！");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (TimeError err)
            {
                return ResultUtil.error(err.Message);
            }
            catch
            {
                return ResultUtil.error("产能不足，请调整计划！");
            }
        }

    }
}
