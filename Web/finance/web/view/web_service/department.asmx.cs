using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.service;
using Web.finance.util;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <author>
    /// dai
    /// </author>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    [System.Web.Script.Services.ScriptService]
    public class department : System.Web.Services.WebService
    {
        //service层对象
        private DepartmentService departmentService;

        /// <summary>
        /// 获取部门集合
        /// </summary>
        /// <param name="financePageJson">标准的分页对象</param>
        /// <returns>处理过的分页对象</returns>
        [WebMethod]
        public string getList(string financePageJson)
        {
            //分页对象
            FinancePage<DepartmentItem> financePage = null;
            try
            {
                //创建service层实例
                departmentService = new DepartmentService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<DepartmentItem>>(financePageJson);
                //获取处理过的分页对象
                financePage = departmentService.getListService(financePage);

                return FinanceResultData.getFinanceResultData().success(200, financePage, "成功");
            }
            catch (InvalidOperationException ex) 
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string getList2(string financePageJson,string dep)
        {
            //分页对象
            FinancePage<DepartmentItem> financePage = null;
            try
            {
                //创建service层实例
                departmentService = new DepartmentService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<DepartmentItem>>(financePageJson);
                //获取处理过的分页对象
                financePage = departmentService.getListService2(financePage,dep);

                return FinanceResultData.getFinanceResultData().success(200, financePage, "成功");
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string getDepartmentList()
        {
            try
            {
                //创建service层实例
                departmentService = new DepartmentService();
                //获取集合
                List<Department> list = departmentService.getList();
                if (list != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, list, "成功");
                }
                else 
                {
                    return FinanceResultData.getFinanceResultData().fail(500, list, "错误");
                }
                
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="departmentJson">部门对象json</param>
        /// <returns></returns>
        [WebMethod]
        public string add(string departmentJson) {
            try
            {
                //创建service层实例
                departmentService = new DepartmentService();
                //处理json
                Department department = FinanceJson.getFinanceJson().toObject<Department>(departmentJson);

                if (departmentService.newDepartmentService(department))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "添加成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "添加失败");
                }
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="idsJson">id数组json</param>
        /// <returns></returns>
        [WebMethod]
        public string delete(string idsJson)
        {
            try
            {
                //创建service层实例
                departmentService = new DepartmentService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (departmentService.delDepartmentService(ids))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "删除成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "删除失败");
                }
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }


        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="newDepartmentJson">新的部门json对象</param>
        /// <returns>不成功则null</returns>
        [WebMethod]
        public string update(string newDepartmentJson)
        {
            try
            {
                //创建service层实例
                departmentService = new DepartmentService();
                //处理json
                DepartmentItem departmentItem = FinanceJson.getFinanceJson().toObject<DepartmentItem>(newDepartmentJson);
                //修改操作
                departmentItem = departmentService.updDepartmentService(departmentItem);
                if (departmentItem != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, departmentItem, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "删除失败");
                }
            }
            catch (InvalidOperationException ex)
            {
                //身份验证不通过
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                //未知的错误
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }
    }
}
