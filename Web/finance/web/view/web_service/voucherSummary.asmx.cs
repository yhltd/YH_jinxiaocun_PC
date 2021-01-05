using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.service;
using Web.finance.util;
using Web.Service;
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
    public class voucherSummary : System.Web.Services.WebService
    {
        private VoucherSummaryService voucherSummaryService;

        private FlowService llowService;

        [WebMethod]
        public string getVoucherSummaryList(string financePageJson)
        {
            //分页对象
            FinancePage<VoucherSummaryItem> financePage = null;
            try
            {
                //创建service层实例
                voucherSummaryService = new VoucherSummaryService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<VoucherSummaryItem>>(financePageJson);
                //获取处理过的分页对象
                financePage = voucherSummaryService.getVoucherSummaryList(financePage);

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
        public string updVoucherSummary(string newVoucherSummary) {
            try
            {
                //创建service层实例
                voucherSummaryService = new VoucherSummaryService();
                //处理json
                VoucherSummaryItem voucherSummaryItem = FinanceJson.getFinanceJson().toObject<VoucherSummaryItem>(newVoucherSummary);
                if (voucherSummaryService.updVoucherSummary(voucherSummaryItem))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "成功");
                }
                else {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "错误");
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
        public string addVoucherSummary(string voucherSummaryJson) {
            try
            {
                //创建service层实例
                voucherSummaryService = new VoucherSummaryService();
                //处理json
                VoucherSummary voucherSummary = FinanceJson.getFinanceJson().toObject<VoucherSummary>(voucherSummaryJson);
                if (voucherSummaryService.addVoucherSummary(voucherSummary))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "错误");
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
        public string delVoucherSummary(string idsJson)
        {
            try
            {
                //创建service层实例
                voucherSummaryService = new VoucherSummaryService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);
                if (voucherSummaryService.delVoucherSummary(ids))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "错误");
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
        public string examineVoucherSummary(string idsJson, string @do, string examineName) {
            try
            {
                //创建service层实例
                voucherSummaryService = new VoucherSummaryService();
                //获取用户service层实例
                AccountService accountService = new AccountService(true);
                //检查操作密码
                if (!accountService.checkDo(@do)) {
                    return FinanceResultData.getFinanceResultData().fail(402, null, "操作密码错误");
                }

                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);
                //审核
                if (voucherSummaryService.examineVoucherSummary(ids, examineName))
                {
                    return FinanceResultData.getFinanceResultData().success(200, null, "成功");
                }
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "错误");
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
        /// 获取现金流量List
        /// </summary>
        /// <param name="financePageJson">分页对象</param>
        /// <returns></returns>
        [WebMethod]
        public string getFlowList(string financePageJson)
        {
            //分页对象
            FinancePage<Flow> financePage = null;
            try
            {
                //创建service层实例
                llowService = new FlowService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<Flow>>(financePageJson);
                //获取处理过的分页对象
                financePage = llowService.getFlowList(financePage);

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
    }
}
