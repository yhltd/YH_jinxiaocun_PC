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
    /// time 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class time : System.Web.Services.WebService
    {
        private TimeConfigService tcs;

        [WebMethod]
        public string list()
        {
            try
            {
                tcs = new TimeConfigService();
                return ResultUtil.success(tcs.list(), "查询成功");
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
        public string add(time_config timeConfig)
        {
            try
            {
                tcs = new TimeConfigService();
                timeConfig = tcs.save(timeConfig);
                if (timeConfig.id > 0)
                {
                    return ResultUtil.success(timeConfig, "保存成功");
                }
                else
                {
                    return ResultUtil.success("未保存");
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
        public string update(time_config timeConfig)
        {
            try
            {
                tcs = new TimeConfigService();
                if (tcs.update(timeConfig))
                {
                    return ResultUtil.success("保存成功");
                }
                else
                {
                    return ResultUtil.success("未保存");
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
