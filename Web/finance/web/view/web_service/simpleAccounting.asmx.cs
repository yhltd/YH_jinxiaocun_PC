using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.model;
using Web.finance.service;
using Web.finance.util;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// simpleAccounting 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class simpleAccounting : System.Web.Services.WebService
    {

        private SimpleAccountingService simpleAccountingService;

        /// <summary>
        /// 分页获取科目
        /// </summary>
        /// <param name="financePageJson"></param>
        /// <returns></returns>
        [WebMethod]
        public string getSimpleAccountingList(string financePageJson)
        {
            //分页对象
            FinancePage<SimpleAccounting> financePage = null;
            try
            {
                //创建service层实例
                simpleAccountingService = new SimpleAccountingService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<SimpleAccounting>>(financePageJson);
                //获取处理过的分页对象
                financePage = simpleAccountingService.getSimpleAccountingList(financePage);

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

        /// <summary>
        /// 获取所有科目
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string getList()
        {
            try
            {
                //创建service层实例
                simpleAccountingService = new SimpleAccountingService();
                //获取处理过的分页对象
                List<SimpleAccounting> list = simpleAccountingService.getSimpleAccountingList();

                return FinanceResultData.getFinanceResultData().success(200, list, "成功");
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
        /// 新增
        /// </summary>
        /// <param name="simpleAccountingJson"></param>
        /// <returns></returns>
        [WebMethod]
        public string addSimpleAccounting(string simpleAccountingJson)
        {
            try
            {
                //创建service层实例
                simpleAccountingService = new SimpleAccountingService();
                //处理json
                SimpleAccounting simpleAccounting = FinanceJson.getFinanceJson().toObject<SimpleAccounting>(simpleAccountingJson);

                if (simpleAccountingService.newSimpleAccounting(simpleAccounting))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "新增成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "新增失败");
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
        /// 删除
        /// </summary>
        /// <param name="idsJson">id数组json</param>
        /// <returns></returns>
        [WebMethod]
        public string delSimpleAccounting(string idsJson)
        {
            try
            {
                //创建service层实例
                simpleAccountingService = new SimpleAccountingService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (simpleAccountingService.delSimpleAccounting(ids))
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
        /// 修改
        /// </summary>
        /// <param name="newSimpleAccounting"></param>
        /// <returns></returns>
        [WebMethod]
        public string updSimpleAccounting(string newSimpleAccounting)
        {
            try
            {
                //创建service层实例
                simpleAccountingService = new SimpleAccountingService();
                //处理json
                SimpleAccounting simpleAccounting = FinanceJson.getFinanceJson().toObject<SimpleAccounting>(newSimpleAccounting);
                //修改操作
                if (simpleAccountingService.updSimpleAccounting(simpleAccounting))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "修改成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "修改失败");
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
