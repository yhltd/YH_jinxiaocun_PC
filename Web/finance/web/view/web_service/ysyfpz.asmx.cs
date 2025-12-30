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
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ysyfpz : System.Web.Services.WebService
    {
        private ysyfpeizhiService ysyfpeizhiservice;

        [WebMethod]
        public string getList(string financePageJson, string ysyf, string xiangmumingcheng)
        {
            try
            {
                ysyfpeizhiservice = new ysyfpeizhiService();
                var financePage = FinanceJson.getFinanceJson().toObject<FinancePage<ysyfpeizhi>>(financePageJson);
                financePage = ysyfpeizhiservice.getList(financePage, ysyf, xiangmumingcheng);
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
        public string getAllList(string ysyf, string xiangmumingcheng)
        {
            try
            {
                ysyfpeizhiservice = new ysyfpeizhiService();
                var list = ysyfpeizhiservice.getAllList(ysyf, xiangmumingcheng);
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
                ysyfpeizhiservice = new ysyfpeizhiService();
                var entity = FinanceJson.getFinanceJson().toObject<ysyfpeizhi>(updInfo);

                if (ysyfpeizhiservice.upd(entity))
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
                ysyfpeizhiservice = new ysyfpeizhiService();
                var entity = FinanceJson.getFinanceJson().toObject<ysyfpeizhi>(simpleDataJson);

                if (ysyfpeizhiservice.add(entity))
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
                ysyfpeizhiservice = new ysyfpeizhiService();
                var ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (ysyfpeizhiservice.del(ids))
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

