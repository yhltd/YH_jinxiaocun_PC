using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.finance.model;
using Web.finance.util;
using Newtonsoft.Json;
using System.Text;

namespace Web.finance.service
{
    public class StatisticsService : ApiController
    {
        // 公共model层
        private SimpleDataModel simpleDataModel;

        // 当前登陆用户对象
        private Account account;

        // 构造方法
        public StatisticsService()
        {
            try
            {
                // 获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                // 获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                // 实例化model层
                simpleDataModel = new SimpleDataModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取完整的统计原始数据
        /// </summary>
        /// <summary>
        /// 获取完整的统计原始数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage GetStatisticsData(string ks, string js)
        {
            try
            {
                // 获取原始数据
                var rawData = simpleDataModel.GetFullStatisticsData(account.company, ks, js);
                var monthlyData = simpleDataModel.GetMonthlySummary(account.company, ks, js);
                var accountingData = simpleDataModel.GetAccountingSummary(account.company, ks, js);
                var projectData = simpleDataModel.GetProjectSummary(account.company, ks, js);

                // 确保数据不为null
                rawData = rawData ?? new List<SimpleData>();
                monthlyData = monthlyData ?? new List<MonthlySummary>();
                accountingData = accountingData ?? new List<AccountingSummary>();
                projectData = projectData ?? new List<ProjectSummary>();

                int totalRecords = rawData.Count;
                string company = account.company;
                string startDate = string.IsNullOrEmpty(ks) ? string.Empty : ks;
                string endDate = string.IsNullOrEmpty(js) ? string.Empty : js;

                // 构建返回对象
                var result = new
                {
                    success = true,
                    code = 200,
                    message = "成功",
                    data = new
                    {
                        rawData = rawData,
                        monthlyData = monthlyData,
                        accountingData = accountingData,
                        projectData = projectData,
                        summary = new
                        {
                            totalRecords = totalRecords,
                            startDate = startDate,
                            endDate = endDate,
                            company = company
                        }
                    }
                };

                // 手动创建 HttpResponseMessage
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(result),
                        Encoding.UTF8,
                        "application/json"
                    )
                };

                return response;
            }
            catch (Exception ex)
            {
                var errorResult = new
                {
                    success = false,
                    code = 500,
                    message = "获取统计数据失败: " + ex.Message
                };

                var errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(
                        JsonConvert.SerializeObject(errorResult),
                        Encoding.UTF8,
                        "application/json"
                    )
                };

                return errorResponse;
            }
        }



        /// <summary>
        /// 获取月度趋势数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage GetMonthlyTrendData(string ks, string js)
        {
            try
            {
                var monthlyData = simpleDataModel.GetMonthlySummary(account.company, ks, js);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    code = 200,
                    message = "成功",
                    data = monthlyData
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    code = 500,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// 获取科目分析数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage GetAccountingAnalysis(string ks, string js)
        {
            try
            {
                var accountingData = simpleDataModel.GetAccountingSummary(account.company, ks, js);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    code = 200,
                    message = "成功",
                    data = accountingData
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    code = 500,
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// 获取项目分析数据
        /// </summary>
        [HttpPost]
        public HttpResponseMessage GetProjectAnalysis(string ks, string js)
        {
            try
            {
                var projectData = simpleDataModel.GetProjectSummary(account.company, ks, js);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    code = 200,
                    message = "成功",
                    data = projectData
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    success = false,
                    code = 500,
                    message = ex.Message
                });
            }
        }
    }
}