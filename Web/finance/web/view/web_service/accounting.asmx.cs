using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.entiy;
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
    public class accounting : System.Web.Services.WebService
    {

        private AccountingService asc;

        private LiabilitiesService liabilitiesService;

        private ProfitService profitService;

        [WebMethod]
        public string getList(string financePageJson, int classId)
        {
            if (financePageJson != "")
            {
                FinancePage<AccountingItem> financePage = new FinancePage<AccountingItem>();
                financePage = FinanceJson.getFinanceJson().toObject<FinancePage<AccountingItem>>(financePageJson);
                try
                {
                    asc = new AccountingService();
                    financePage = asc.getList(financePage, classId);
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
            else
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
            }
        }

        [WebMethod]
        public string getListOfGrade(int classId, int grade,int code) {
            if (classId != 0 && grade != 0)
            {
                try
                {
                    List<Accounting> accountingList = new List<Accounting>();
                    asc = new AccountingService();
                    accountingList = asc.getList(classId, grade, code);
                    if (accountingList != null)
                    {
                        return FinanceResultData.getFinanceResultData().success(200, accountingList, "成功");
                    }
                    else
                    {
                        return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
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
            else
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
            }
        }

        [WebMethod]
        public string updAccounting(string itemJson)
        {
            if (itemJson != "")
            {
                AccountingItem accountingItem = new AccountingItem();
                accountingItem = FinanceJson.getFinanceJson().toObject<AccountingItem>(itemJson);
                if (accountingItem != null)
                {
                    try
                    {
                        asc = new AccountingService();
                        accountingItem = asc.updAccounting(accountingItem);
                        if (accountingItem != null)
                        {
                            return FinanceResultData.getFinanceResultData().success(200, accountingItem, "成功");
                        }
                        else
                        {
                            return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
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
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
                }
            }
            else
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
            }
        }

        [WebMethod]
        public string delAccounting(string idJson)
        {
            if (idJson != "")
            {
                try
                {
                    int[] ids = FinanceJson.getFinanceJson().toObject<int[]>(idJson);
                    asc = new AccountingService();
                    if (asc.delAccounting(ids))
                    {
                        return FinanceResultData.getFinanceResultData().success(200, null, "成功");
                    }
                    else
                    {
                        return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
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
            else
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
            }
        }

        [WebMethod]
        public string balanceCheck() {
            try
            {
                asc = new AccountingService();
                return FinanceResultData.getFinanceResultData().success(200, asc.balanceCheck(), "成功");
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
        public string newAccounting(string itemJson) {
            if (itemJson == "")
            {
                return FinanceResultData.getFinanceResultData().fail(500, null, "无参数");
            }
            else {
                Accounting accounting = FinanceJson.getFinanceJson().toObject<Accounting>(itemJson);
                if (accounting != null) {
                    try
                    {
                        asc = new AccountingService();
                        if (asc.newAccounting(accounting))
                        {
                            return FinanceResultData.getFinanceResultData().success(200, null, "添加成功");
                        }
                        else
                        {
                            return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
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
                else
                {
                    return FinanceResultData.getFinanceResultData().fail(500, null, "失败");
                }
            }
        }


        [WebMethod]
        public string getLiabilitiesList(string financePageJson)
        {
            try
            {
                FinancePage<Liabilities> financePage = FinanceJson.getFinanceJson().toObject<FinancePage<Liabilities>>(financePageJson);
                liabilitiesService = new LiabilitiesService();

                financePage = liabilitiesService.getLiabilitiesList(financePage);
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
        public string getProfitList(string financePageJson)
        {
            try
            {
                FinancePage<Profit> financePage = FinanceJson.getFinanceJson().toObject<FinancePage<Profit>>(financePageJson);
                profitService = new ProfitService();

                financePage = profitService.getProfitList(financePage);
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
