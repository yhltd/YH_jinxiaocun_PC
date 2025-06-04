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
    /// <author>
    /// dai
    /// </author>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class items : System.Web.Services.WebService
    {
        private FinancingService financingService;

        [WebMethod]
        public string getExpenditureList(string financePageJson){
            //分页对象
            FinancePage<FinancingExpenditure> financePage = null;
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<FinancingExpenditure>>(financePageJson);
                //获取处理过的分页对象
                financePage = financingService.getFinancingExpenditureList(financePage);

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
        public string addExpenditure(string expenditureJson)
        {
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                FinancingExpenditure financingExpenditure = FinanceJson.getFinanceJson().toObject<FinancingExpenditure>(expenditureJson);

                if (financingService.addFinancingExpenditure(financingExpenditure))
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
        public string delExpenditure(string idsJson)
        {
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (financingService.deleteFinancingExpenditure(ids))
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
        /// <param name="newExpenditure"></param>
        /// <returns></returns>
        [WebMethod]
        public string updExpenditure(string newExpenditure)
        {
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                FinancingExpenditure financingExpenditure = FinanceJson.getFinanceJson().toObject<FinancingExpenditure>(newExpenditure);
                //修改操作
                if (financingService.updateFinancingExpenditure(financingExpenditure))
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















        [WebMethod]
        public string getIncomeList(string financePageJson)
        {
            //分页对象
            FinancePage<FinancingIncome> financePage = null;
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<FinancingIncome>>(financePageJson);
                //获取处理过的分页对象
                financePage = financingService.getFinancingIncomeList(financePage);

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
        public string addIncome(string incomeJson)
        {
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                FinancingIncome financingIncome = FinanceJson.getFinanceJson().toObject<FinancingIncome>(incomeJson);

                if (financingService.addFinancingIncome(financingIncome))
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
        public string delIncome(string idsJson)
        {
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (financingService.deleteFinancingIncome(ids))
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
        /// <param name="newIncome"></param>
        /// <returns></returns>
        [WebMethod]
        public string updIncome(string newIncome)
        {
            try
            {
                //创建service层实例
                financingService = new FinancingService();
                //处理json
                FinancingIncome financingIncome = FinanceJson.getFinanceJson().toObject<FinancingIncome>(newIncome);
                //修改操作
                if (financingService.updateFinancingIncome(financingIncome))
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
