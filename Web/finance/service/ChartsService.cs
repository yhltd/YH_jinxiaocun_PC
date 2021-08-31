using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.entiy;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    /// <author>
    /// dai
    /// </author>
    public class ChartsService
    {
        //model层
        private CommonModel common;

        private Account account;

        //实例化
        public ChartsService()
        {
            try
            {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                common = new CommonModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取图表年初余额
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<decimal>> getAccountingService()
        {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //返回的map
            Dictionary<string, List<decimal>> result = null;
            if (account != null) {
                //创建实例
                result = new Dictionary<string, List<decimal>>();
                //获取集合
                List<Charts> resultList = common.getAccounting(account.company);
                //年初借金数组
                List<decimal> loadList = new List<decimal>();
                //年初贷金数组
                List<decimal> borrowedList = new List<decimal>();
                //循环填入
                foreach (Charts chart in resultList)
                {
                    loadList.Add(chart.sum_load);
                    borrowedList.Add(chart.sum_borrowed);
                }
                //return
                result.Add("sum_load", loadList);
                result.Add("sum_borrowed", borrowedList);
            }
            
            return result;
        }

        /// <summary>
        /// 获取图表凭证金额
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, decimal> getSummaryService(string start_date,string stop_date)
        {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //返回的map
            Dictionary<string, decimal> result = null;
            if (account != null)
            {
                //创建实例
                result = new Dictionary<string, decimal>();
                //获取集合
                List<Charts> resultList = common.getSummary(account.company,start_date,stop_date);
                //return
                if (resultList.Count == 2)
                {
                    result.Add("sum_borrowed", resultList[1].sum);
                    result.Add("sum_load", resultList[0].sum);
                }
                else {
                    if (resultList.Count == 0)
                    {
                        result.Add("sum_borrowed", 0);
                        result.Add("sum_load",0);
                    }
                    else if (resultList[0].direction = true)
                    {
                        result.Add("sum_borrowed", resultList[0].sum);
                        result.Add("sum_load", 0);
                    }
                    else {
                        result.Add("sum_borrowed", 0);
                        result.Add("sum_load", resultList[0].sum);
                    }
                }
                
                
            }

            return result;
        }

        /// <summary>
        /// 获取图表科目余额
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<decimal>> getAccountBalanceService(string start_date,string stop_date)
        {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //返回的map
            Dictionary<string, List<decimal>> result = null;
            if (account != null)
            {
                //创建实例
                result = new Dictionary<string, List<decimal>>();
                //获取集合
                List<Charts> resultList = common.getAccountBalance(account.company,start_date,stop_date);
                //年初借金数组
                List<decimal> loadList = new List<decimal>();
                //年初贷金数组
                List<decimal> borrowedList = new List<decimal>();
                //循环填入
                foreach (Charts chart in resultList)
                {
                    loadList.Add(chart.sum_load);
                    borrowedList.Add(chart.sum_borrowed);
                }
                //return
                result.Add("sum_load", loadList);
                result.Add("sum_borrowed", borrowedList);
            }

            return result;
        }

        /// <summary>
        /// 获取图表资产负债
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<decimal>> getLiabilitiesService(string start_date,string stop_date) {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //返回的map
            Dictionary<string, List<decimal>> result = null;
            if (account != null)
            {
                //创建实例
                result = new Dictionary<string, List<decimal>>();
                //获取集合
                List<Charts> resultList = common.getLiabilities(account.company,start_date,stop_date);
                //年初借金数组
                List<decimal> yearStart = new List<decimal>();
                //年初贷金数组
                List<decimal> yaerEnd = new List<decimal>();
                //循环填入
                Boolean isFirst = true;
                foreach (Charts chart in resultList)
                {
                    if(isFirst)
                    {
                        yearStart.Add(chart.sum_load - chart.sum_borrowed);
                        yaerEnd.Add(chart.sum_load - chart.sum_borrowed + chart.sum_money);
                        isFirst = false;
                    }else
                    {
                        yearStart.Add(chart.sum_borrowed - chart.sum_load);
                        yaerEnd.Add(chart.sum_borrowed - chart.sum_load + chart.sum_money);
                    }
                }
                //return
                result.Add("yearStart", yearStart);
                result.Add("yearEnd", yaerEnd);
            }
            return result;
        }


        /// <summary>
        /// 获取图表利润合计
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<decimal>> getProfitService(string start_date,string stop_date)
        {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //返回的map
            Dictionary<string, List<decimal>> result = null;
            if (account != null)
            {
                //创建实例
                result = new Dictionary<string, List<decimal>>();
                //获取集合
                List<Charts> resultList = common.getProfit(account.company,start_date,stop_date);
                //年初借金数组
                List<decimal> sumYear = new List<decimal>();
                //年初贷金数组
                List<decimal> sumMonth = new List<decimal>();
                //循环填入
                foreach (Charts chart in resultList)
                {
                    sumYear.Add(chart.sum_year);
                    sumMonth.Add(chart.sum_month);
                }
                //return
                result.Add("sumYear", sumYear);
                result.Add("sumMonth", sumMonth);
            }
            return result;
        }

        /// <summary>
        /// 获取图表现金流量
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<decimal>> getFlowService(string start_date,string stop_date) {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //返回的map
            Dictionary<string, List<decimal>> result = null;
            if (account != null)
            {
                //创建实例
                result = new Dictionary<string, List<decimal>>();
                //年初借金数组
                List<decimal> sumYear = new List<decimal>();
                //年初贷金数组
                List<decimal> sumMonth = new List<decimal>();
                //投资结余
                ManagementModel management = new ManagementModel();
                //筹资结余
                InvestmentModel investment = new InvestmentModel();
                //经营结余
                FinancingModel financing = new FinancingModel();

                //今年结余
                sumYear.Add(management.getManagementYear(account.company, start_date,stop_date));
                sumYear.Add(investment.getInvestmentYear(account.company, start_date,stop_date));
                sumYear.Add(financing.getFinancingYear(account.company, start_date,stop_date));
                //当月结余
                sumMonth.Add(management.getManagementMonth(account.company, start_date,stop_date));
                sumMonth.Add(investment.getInvestmentMonth(account.company, start_date, stop_date));
                sumMonth.Add(financing.getFinancingMonth(account.company, start_date,stop_date));
                //return
                result.Add("sumYear", sumYear);
                result.Add("sumMonth", sumMonth);
            }
            return result;
        }

        
    }
}