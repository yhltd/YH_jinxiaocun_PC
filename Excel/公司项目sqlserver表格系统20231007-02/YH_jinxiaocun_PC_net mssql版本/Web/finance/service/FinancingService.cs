using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class FinancingService
    {
        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public FinancingService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                commonModel = new CommonModel();
            }catch{
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<FinancingExpenditure> getFinancingExpenditureList(FinancePage<FinancingExpenditure> financePage) 
        {
            FinancingExpenditure financingExpenditure = new FinancingExpenditure();
            //获取pageList
            financePage = commonModel.getComList<FinancingExpenditure>(financingExpenditure, financePage, account.company, "financingExpenditure");
            //获取总行数
            financePage.total = commonModel.getComTotal<FinancingExpenditure>(financingExpenditure, account.company, "financingExpenditure");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addFinancingExpenditure(FinancingExpenditure financingExpenditure) {
            financingExpenditure.company = account.company;
            return commonModel.comAdd<FinancingExpenditure>(financingExpenditure) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteFinancingExpenditure(int[] ids) {
            FinancingExpenditure financingExpenditure = new FinancingExpenditure();
            for (int i = 0; i < ids.Length; i++) {
                financingExpenditure = commonModel.comFind<FinancingExpenditure>(financingExpenditure, ids[i]);
                if (commonModel.comDel<FinancingExpenditure>(financingExpenditure) <= 0) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updateFinancingExpenditure(FinancingExpenditure financingExpenditure)
        {
            financingExpenditure.company = account.company;
            return commonModel.comUpd<FinancingExpenditure>(financingExpenditure) > 0;
        }






















        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<FinancingIncome> getFinancingIncomeList(FinancePage<FinancingIncome> financePage)
        {
            FinancingIncome financingIncome = new FinancingIncome();
            //获取pageList
            financePage = commonModel.getComList<FinancingIncome>(financingIncome, financePage, account.company, "financingIncome");
            //获取总行数
            financePage.total = commonModel.getComTotal<FinancingIncome>(financingIncome, account.company, "financingIncome");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addFinancingIncome(FinancingIncome financingIncome)
        {
            financingIncome.company = account.company;
            return commonModel.comAdd<FinancingIncome>(financingIncome) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteFinancingIncome(int[] ids)
        {
            FinancingIncome financingIncome = new FinancingIncome();
            for (int i = 0; i < ids.Length; i++)
            {
                financingIncome = commonModel.comFind<FinancingIncome>(financingIncome, ids[i]);
                if (commonModel.comDel<FinancingIncome>(financingIncome) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean updateFinancingIncome(FinancingIncome financingIncome)
        {
            return commonModel.comUpd<FinancingIncome>(financingIncome) > 0;
        }
    }
}