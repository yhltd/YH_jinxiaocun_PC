﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// work_summary 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class work_summary : System.Web.Services.WebService
    {

        private WorkModuleService wms;

        [WebMethod]
        public string page(int nowPage, int pageCount, int typeId, String orderId)
        {
            try
            {
                UserInfoService us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel","汇总");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                wms = new WorkModuleService();
                return ResultUtil.success(wms.list(nowPage, pageCount, typeId, orderId), "查询成功");
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
