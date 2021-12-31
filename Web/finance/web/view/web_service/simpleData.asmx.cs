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
    public class simpleData : System.Web.Services.WebService
    {
        private SimpleDataService simpleDataService;

        [WebMethod]
        public string getSimpleDataList(string financePageJson,string start_date,string stop_date) {
            //分页对象
            FinancePage<SimpleData> financePage = null;
            try
            {
                //创建service层实例
                simpleDataService = new SimpleDataService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<SimpleData>>(financePageJson);
                //获取处理过的分页对象
                financePage = simpleDataService.getSimpleDataList(financePage,start_date,stop_date);

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
        public string addSimpleData(string simpleDataJson)
        {
            try
            {
                //创建service层实例
                simpleDataService = new SimpleDataService();
                //处理json
                SimpleData simpleData = FinanceJson.getFinanceJson().toObject<SimpleData>(simpleDataJson);

                if (simpleDataService.newSimpleData(simpleData))
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
        public string delSimpleData(string idsJson)
        {
            try
            {
                //创建service层实例
                simpleDataService = new SimpleDataService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (simpleDataService.delSimpleData(ids))
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
        public string updSimpleData(string newSimpleData)
        {
            try
            {
                //创建service层实例
                simpleDataService = new SimpleDataService();
                //处理json
                SimpleData simpleData = FinanceJson.getFinanceJson().toObject<SimpleData>(newSimpleData);
                //修改操作
                if (simpleDataService.updSimpleData(simpleData))
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
