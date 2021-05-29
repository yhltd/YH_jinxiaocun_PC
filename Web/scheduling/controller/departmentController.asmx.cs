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
    /// Summary description for department
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class departmentController : System.Web.Services.WebService
    {
        private DepartmentService ds;

        [WebMethod]
        public string departmentList(int nowPage, int pageCount)
        {
            try
            {
                ds = new DepartmentService();
                return ResultUtil.success(ds.list(nowPage,pageCount), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch(Exception ex)
            {
                
                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string save(department departmentList)
        {
            try
            {
                
                ds = new DepartmentService();
                if (ds.save(departmentList))
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
    }
}
