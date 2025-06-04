using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.finance.model;
using Web.finance.service;
using Web.Util;

namespace Web.finance.web.view.web_service
{
    /// <summary>
    /// Summary description for subLedger
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class subLedger : System.Web.Services.WebService
    {
        private SimpleDataModel simpleDataModel;
        private SubLedgerService subLedgerService;

        [WebMethod]
        public string getKehuList(string financePageJson, string ks, string js,string kehu)
        {
            try
            {
                subLedgerService = new SubLedgerService();
                List<SimpleData> getKehuSubLedger = subLedgerService.getKehuSubLedger(ks, js, kehu);
                List<SimpleData> getKehuSubLedgerByFirst = subLedgerService.getKehuSubLedgerByFirst(ks, js, kehu);

                List<subLedgetList> list = new List<subLedgetList>();

                subLedgetList jieyu = new subLedgetList();

                if (getKehuSubLedgerByFirst.Count == 0)
                {
                    subLedgetList sl = new subLedgetList();
                    sl.kehu = kehu;
                    sl.ying = 0;
                    sl.shi = 0;
                    sl.wei = 0;
                    sl.project = "上期合计";

                    jieyu.ying = 0;
                    jieyu.shi = 0;
                    jieyu.wei = 0;

                    list.Add(sl);
                }
                else 
                {
                    subLedgetList sl = new subLedgetList();
                    sl.kehu = kehu;
                    sl.accounting = getKehuSubLedgerByFirst[0].accounting;
                    if (getKehuSubLedgerByFirst[0].insert_date != null)
                    {
                        sl.insert_date = Convert.ToString(getKehuSubLedgerByFirst[0].insert_date);
                    }
                    sl.project = "上期合计";
                    sl.ying = getKehuSubLedgerByFirst[0].receivable;
                    sl.shi = getKehuSubLedgerByFirst[0].receipts;
                    sl.wei = getKehuSubLedgerByFirst[0].receivable - getKehuSubLedgerByFirst[0].receipts;

                    jieyu.ying = sl.ying;
                    jieyu.shi = sl.shi;
                    jieyu.wei = sl.wei;

                    list.Add(sl);
                }

                for (int i = 0; i < getKehuSubLedger.Count; i++)
                {
                    subLedgetList sl = new subLedgetList();
                    sl.kehu = kehu;
                    sl.accounting = getKehuSubLedger[0].accounting;
                    if (getKehuSubLedger[0].insert_date != null) {
                        sl.insert_date = Convert.ToString(getKehuSubLedger[0].insert_date);
                    }
                    sl.project = getKehuSubLedger[0].project;
                    sl.ying = getKehuSubLedger[0].receivable;
                    sl.shi = getKehuSubLedger[0].receipts;
                    sl.wei = sl.ying - sl.shi;

                    jieyu.ying = jieyu.ying + sl.ying;
                    jieyu.shi = jieyu.shi + sl.shi;
                    jieyu.wei = jieyu.wei + sl.wei;

                    list.Add(sl);
                }
                jieyu.kehu = kehu;
                jieyu.project = "结余合计";
                list.Add(jieyu);

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


        [WebMethod]
        public string getGYSList(string financePageJson, string ks, string js, string kehu)
        {
            try
            {
                subLedgerService = new SubLedgerService();
                List<SimpleData> getGYSSubLedger = subLedgerService.getGYSSubLedger(ks, js, kehu);
                List<SimpleData> getGYSSubLedgerByFirst = subLedgerService.getGYSSubLedgerByFirst(ks, js, kehu);

                List<subLedgetList> list = new List<subLedgetList>();

                subLedgetList jieyu = new subLedgetList();

                if (getGYSSubLedgerByFirst.Count == 0)
                {
                    subLedgetList sl = new subLedgetList();
                    sl.kehu = kehu;
                    sl.ying = 0;
                    sl.shi = 0;
                    sl.wei = 0;
                    sl.project = "上期合计";

                    jieyu.ying = 0;
                    jieyu.shi = 0;
                    jieyu.wei = 0;

                    list.Add(sl);
                }
                else
                {
                    subLedgetList sl = new subLedgetList();
                    sl.kehu = kehu;
                    sl.accounting = getGYSSubLedgerByFirst[0].accounting;
                    if (getGYSSubLedgerByFirst[0].insert_date != null) {
                        sl.insert_date = Convert.ToString(getGYSSubLedgerByFirst[0].insert_date);
                    }
                    sl.project = "上期合计";
                    sl.ying = getGYSSubLedgerByFirst[0].cope;
                    sl.shi = getGYSSubLedgerByFirst[0].payment;
                    sl.wei = getGYSSubLedgerByFirst[0].cope - getGYSSubLedgerByFirst[0].payment;

                    jieyu.ying = sl.ying;
                    jieyu.shi = sl.shi;
                    jieyu.wei = sl.wei;

                    list.Add(sl);
                }

                for (int i = 0; i < getGYSSubLedger.Count; i++)
                {
                    subLedgetList sl = new subLedgetList();
                    sl.kehu = kehu;
                    sl.accounting = getGYSSubLedger[0].accounting;
                    if (getGYSSubLedger[0].insert_date != null) {
                        sl.insert_date = Convert.ToString(getGYSSubLedger[0].insert_date);
                    }
                    sl.project = getGYSSubLedger[0].project;
                    sl.ying = getGYSSubLedger[0].cope;
                    sl.shi = getGYSSubLedger[0].payment;
                    sl.wei = sl.ying - sl.shi;

                    jieyu.ying = jieyu.ying + sl.ying;
                    jieyu.shi = jieyu.shi + sl.shi;
                    jieyu.wei = jieyu.wei + sl.wei;

                    list.Add(sl);
                }
                jieyu.kehu = kehu;
                jieyu.project = "结余合计";
                list.Add(jieyu);

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
