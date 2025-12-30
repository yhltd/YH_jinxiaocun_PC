using System;
using System.Collections.Generic;
using System.Web.Services;
using Web.finance.service;
using Web.finance.util;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// gongzimingxi 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class gongzimingxi : System.Web.Services.WebService
    {
        private gongzimingxiService gongzimingxiService;

        [WebMethod]
        public string getList(string financePageJson, string renming, string beizhu)
        {
            try
            {
                gongzimingxiService = new gongzimingxiService();
                var financePage = FinanceJson.getFinanceJson().toObject<FinancePage<Web.finance.model.gongzimingxi>>(financePageJson);
                financePage = gongzimingxiService.getList(financePage, renming, beizhu);

                return FinanceResultData.getFinanceResultData().success(200, financePage, "成功");
            }
            catch (InvalidOperationException ex)
            {
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误：" + ex.Message);
            }
        }

        [WebMethod]
        public string getAllList(string renming, string beizhu)
        {
            try
            {
                gongzimingxiService = new gongzimingxiService();
                var list = gongzimingxiService.getAllList(renming, beizhu);
                return FinanceResultData.getFinanceResultData().success(200, list, "成功");
            }
            catch (InvalidOperationException ex)
            {
                return FinanceResultData.getFinanceResultData().fail(401, null, ex.Message);
            }
            catch (Exception ex)
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误：" + ex.Message);
            }
        }

        [WebMethod]
        public string upd(string updInfo)
        {
            try
            {
                gongzimingxiService = new gongzimingxiService();
                var entity = FinanceJson.getFinanceJson().toObject<Web.finance.model.gongzimingxi>(updInfo);

                if (gongzimingxiService.upd(entity))
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
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误：" + ex.Message);
            }
        }

        [WebMethod]
        public string add(string simpleDataJson)
        {
            try
            {
                gongzimingxiService = new gongzimingxiService();
                var entity = FinanceJson.getFinanceJson().toObject<Web.finance.model.gongzimingxi>(simpleDataJson);

                if (gongzimingxiService.add(entity))
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
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误：" + ex.Message);
            }
        }


        [WebMethod]
        public string del(string idsJson)
        {
            try
            {
                gongzimingxiService = new gongzimingxiService();
                var ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (gongzimingxiService.del(ids))
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
                return FinanceResultData.getFinanceResultData().fail(500, null, "未知的错误：" + ex.Message);
            }
        }
    }
}