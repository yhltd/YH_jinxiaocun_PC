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
    /// <summary>
    /// Summary description for simplePeizhi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class simplePeizhi : System.Web.Services.WebService
    {
        private SimplePeizhiService simplePeizhiService;

        [WebMethod]
        public string getAccounting(string financePageJson)
        {
            //分页对象
            FinancePage<AccountingPeizhi> financePage = null;
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<AccountingPeizhi>>(financePageJson);
                //获取处理过的分页对象
                financePage = simplePeizhiService.getAccounting(financePage);

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
        public string getKehu(string financePageJson)
        {
            //分页对象
            FinancePage<KehuPeizhi> financePage = null;
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<KehuPeizhi>>(financePageJson);
                //获取处理过的分页对象
                financePage = simplePeizhiService.getKehu(financePage);

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
        public string getInvoice(string financePageJson)
        {
            //分页对象
            FinancePage<InvoicePeizhi> financePage = null;
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<InvoicePeizhi>>(financePageJson);
                //获取处理过的分页对象
                financePage = simplePeizhiService.getInvoice(financePage);

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
        public string addAccounting(string addJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                AccountingPeizhi accountingPeizhi = FinanceJson.getFinanceJson().toObject<AccountingPeizhi>(addJson);

                if (simplePeizhiService.addAccounting(accountingPeizhi))
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

        [WebMethod]
        public string addKehu(string addJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                KehuPeizhi kehuPeizhi = FinanceJson.getFinanceJson().toObject<KehuPeizhi>(addJson);

                if (simplePeizhiService.addKehu(kehuPeizhi))
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

        [WebMethod]
        public string addInvoice(string addJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                InvoicePeizhi invoicePeizhi = FinanceJson.getFinanceJson().toObject<InvoicePeizhi>(addJson);

                if (simplePeizhiService.addInvoice(invoicePeizhi))
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

        [WebMethod]
        public string updAccounting(string updJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                AccountingPeizhi accountingPeizhi = FinanceJson.getFinanceJson().toObject<AccountingPeizhi>(updJson);
                //修改操作
                if (simplePeizhiService.updAccounting(accountingPeizhi))
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
        public string updKehu(string updJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                KehuPeizhi kehuPeizhi = FinanceJson.getFinanceJson().toObject<KehuPeizhi>(updJson);
                //修改操作
                if (simplePeizhiService.updKehu(kehuPeizhi))
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
        public string updInvoice(string updJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                InvoicePeizhi invoicePeizhi = FinanceJson.getFinanceJson().toObject<InvoicePeizhi>(updJson);
                //修改操作
                if (simplePeizhiService.updInvoice(invoicePeizhi))
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
        public string delAccounting(string idsJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (simplePeizhiService.delAccounting(ids))
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

        [WebMethod]
        public string delKehu(string idsJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (simplePeizhiService.delKehu(ids))
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

        [WebMethod]
        public string delInvoice(string idsJson)
        {
            try
            {
                //创建service层实例
                simplePeizhiService = new SimplePeizhiService();
                //处理json
                int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idsJson);

                if (simplePeizhiService.delInvoice(ids))
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


    }
}
