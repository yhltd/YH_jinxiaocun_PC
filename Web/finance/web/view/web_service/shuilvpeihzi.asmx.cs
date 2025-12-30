using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.service;
using Web.finance.util;
using Web.finance.model;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// shuilvpeihzi 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class shuilvpeihzi : System.Web.Services.WebService
    {
        private shuilvpeizhiService shuilvpeizhiService;

        [WebMethod]
        public string getList(string financePageJson, string shuilv, string linjiezhi)  // 修改：参数名
        {
            try
            {
                shuilvpeizhiService = new shuilvpeizhiService();
                var financePage = FinanceJson.getFinanceJson().toObject<FinancePage<shuilvPeizhi>>(financePageJson);
                financePage = shuilvpeizhiService.getList(financePage, shuilv, linjiezhi);  // 修改：传递参数
                return FinanceResultData.getFinanceResultData().success(200, financePage, "成功");
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
        public string getAllList(string shuilv, string linjiezhi)  // 修改：参数名
        {
            try
            {
                shuilvpeizhiService = new shuilvpeizhiService();
                var list = shuilvpeizhiService.getAllList(shuilv, linjiezhi);  // 修改：传递参数
                return FinanceResultData.getFinanceResultData().success(200, list, "成功");
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
        public string upd(string updInfo)
        {
            try
            {
                shuilvpeizhiService = new shuilvpeizhiService();
                var entity = FinanceJson.getFinanceJson().toObject<shuilvPeizhi>(updInfo);

                if (shuilvpeizhiService.upd(entity))
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
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string add(string simpleDataJson)
        {
            try
            {
                shuilvpeizhiService = new shuilvpeizhiService();
                var entity = FinanceJson.getFinanceJson().toObject<shuilvPeizhi>(simpleDataJson);

                if (shuilvpeizhiService.add(entity))
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
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }

        [WebMethod]
        public string del(string idsJson)
        {
            try
            {
                shuilvpeizhiService = new shuilvpeizhiService();
                var ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (shuilvpeizhiService.del(ids))
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
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误");
            }
        }
    }
}