﻿using System;
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

        [WebMethod]
        public string page(int nowPage, int pageCount, string orderId)
        {
            try
            {
                wds = new WorkDetailService();
                return ResultUtil.success(wds.list(nowPage, pageCount, orderId), "排产成功");
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
    }
}