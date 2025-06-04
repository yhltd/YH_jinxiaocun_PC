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
    /// Summary description for invoice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class invoice : System.Web.Services.WebService
    {
        private InvoiceService invoiceService;

        private SimplePeizhiService simplePeizhiService;

        [WebMethod]
        public string getList(string financePageJson, string ks, string js,string unit)
        {
            //分页对象
            FinancePage<Invoice> financePage = null;
            try
            {
                //创建service层实例
                invoiceService = new InvoiceService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<Invoice>>(financePageJson);
                //获取处理过的分页对象
                financePage = invoiceService.getList(financePage, ks, js, unit);

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
        /// 修改
        /// </summary>
        /// <param name="newExpenditure"></param>
        /// <returns></returns>
        [WebMethod]
        public string upd(string updInfo)
        {
            try
            {
                //创建service层实例
                invoiceService = new InvoiceService();
                //处理json
                Invoice invoice = FinanceJson.getFinanceJson().toObject<Invoice>(updInfo);
                //修改操作
                if (invoiceService.upd(invoice))
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
        public string add(string simpleDataJson)
        {
            try
            {
                //创建service层实例
                invoiceService = new InvoiceService();
                //处理json
                Invoice invoice = FinanceJson.getFinanceJson().toObject<Invoice>(simpleDataJson);

                if (invoiceService.add(invoice))
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
        public string del(string idsJson)
        {
            try
            {
                //创建service层实例
                invoiceService = new InvoiceService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (invoiceService.del(ids))
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
        /// 获取发票种类
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string getInvoicePeizhi()
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();

                List<InvoicePeizhi> list = simplePeizhiService.getInvoicePeizhi();

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
        /// 获取往来单位
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string getKehuPeizhi()
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();

                List<KehuPeizhi> list = simplePeizhiService.getKehuPeizhi();

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
        /// 获取科目
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string getAccountingPeizhi()
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();

                List<AccountingPeizhi> list = simplePeizhiService.getAccountingPeizhi();

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
    }
}
