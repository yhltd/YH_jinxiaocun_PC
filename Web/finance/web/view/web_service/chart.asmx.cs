﻿using System;
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
    public class chart : System.Web.Services.WebService
    {
        ChartsService cs;

        [WebMethod]
        public string getAccounting() {
            try
            {
                cs = new ChartsService();
                Dictionary<string, List<decimal>> result = cs.getAccountingService();
                if (result != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, result, "年初余额");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().success(500, null, "错误");
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
        public string getSummary() {
            try
            {
                cs = new ChartsService();
                Dictionary<string, decimal> result = cs.getSummaryService();
                if (result != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, result, "凭证金额");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().success(500, null, "错误");
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
        public string getAccountingBalance()
        {
            try
            {
                cs = new ChartsService();
                Dictionary<string, List<decimal>> result = cs.getAccountBalanceService();
                if (result != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, result, "科目余额");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().success(500, null, "错误");
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
        public string getLiabilities()
        {
            try
            {
                cs = new ChartsService();
                Dictionary<string, List<decimal>> result = cs.getLiabilitiesService();
                if (result != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, result, "资产负债");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().success(500, null, "错误");
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
        public string getProfit()
        {
            try
            {
                cs = new ChartsService();
                Dictionary<string, List<decimal>> result = cs.getProfitService();
                if (result != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, result, "利润合计");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().success(500, null, "错误");
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
        public string getFlow()
        {
            try
            {
                cs = new ChartsService();
                Dictionary<string, List<decimal>> result = cs.getFlowService();
                if (result != null)
                {
                    return FinanceResultData.getFinanceResultData().success(200, result, "现金流量");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().success(500, null, "错误");
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