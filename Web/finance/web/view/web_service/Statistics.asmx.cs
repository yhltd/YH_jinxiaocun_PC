using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Web.finance.service;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// 统计图表Web服务
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Statistics : System.Web.Services.WebService
    {
        private StatisticsService statisticsService;

        [WebMethod]
        public string GetStatisticsData(string ks, string js)
        {
            try
            {
                statisticsService = new StatisticsService();
                var result = statisticsService.GetStatisticsData(ks, js);

                // 转换为JSON字符串返回
                var content = result.Content.ReadAsStringAsync().Result;
                return content;
            }
            catch (InvalidOperationException ex)
            {
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string GetMonthlyTrendData(string ks, string js)
        {
            try
            {
                statisticsService = new StatisticsService();
                var result = statisticsService.GetMonthlyTrendData(ks, js);

                var content = result.Content.ReadAsStringAsync().Result;
                return content;
            }
            catch (InvalidOperationException ex)
            {
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string GetAccountingAnalysis(string ks, string js)
        {
            try
            {
                statisticsService = new StatisticsService();
                var result = statisticsService.GetAccountingAnalysis(ks, js);

                var content = result.Content.ReadAsStringAsync().Result;
                return content;
            }
            catch (InvalidOperationException ex)
            {
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string GetProjectAnalysis(string ks, string js)
        {
            try
            {
                statisticsService = new StatisticsService();
                var result = statisticsService.GetProjectAnalysis(ks, js);

                var content = result.Content.ReadAsStringAsync().Result;
                return content;
            }
            catch (InvalidOperationException ex)
            {
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }
    }
}