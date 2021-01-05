using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class InvestmentService
    {
        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public InvestmentService()
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
        public FinancePage<InvestmentExpenditure> getInvestmentExpenditureList(FinancePage<InvestmentExpenditure> financePage) 
        {
            InvestmentExpenditure investmentExpenditure = new InvestmentExpenditure();
            //获取pageList
            financePage = commonModel.getComList<InvestmentExpenditure>(investmentExpenditure, financePage, account.company, "investmentExpenditure");
            //获取总行数
            financePage.total = commonModel.getComTotal<InvestmentExpenditure>(investmentExpenditure, account.company, "investmentExpenditure");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addInvestmentExpenditure(InvestmentExpenditure investmentExpenditure)
        {
            investmentExpenditure.company = account.company;
            return commonModel.comAdd<InvestmentExpenditure>(investmentExpenditure) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteInvestmentExpenditure(int[] ids)
        {
            InvestmentExpenditure investmentExpenditure = new InvestmentExpenditure();
            for (int i = 0; i < ids.Length; i++) {
                investmentExpenditure = commonModel.comFind<InvestmentExpenditure>(investmentExpenditure, ids[i]);
                if (commonModel.comDel<InvestmentExpenditure>(investmentExpenditure) <= 0)
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
        public Boolean updateInvestmentExpenditure(InvestmentExpenditure investmentExpenditure)
        {
            investmentExpenditure.company = account.company;
            return commonModel.comUpd<InvestmentExpenditure>(investmentExpenditure) > 0;
        }






















        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<InvestmentIncome> getInvestmentIncomeList(FinancePage<InvestmentIncome> financePage)
        {
            InvestmentIncome investmentIncome = new InvestmentIncome();
            //获取pageList
            financePage = commonModel.getComList<InvestmentIncome>(investmentIncome, financePage, account.company, "investmentIncome");
            //获取总行数
            financePage.total = commonModel.getComTotal<InvestmentIncome>(investmentIncome, account.company, "investmentIncome");
            return financePage;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="financingExpenditure"></param>
        /// <returns></returns>
        public Boolean addInvestmentIncome(InvestmentIncome InvestmentIncome)
        {
            InvestmentIncome.company = account.company;
            return commonModel.comAdd<InvestmentIncome>(InvestmentIncome) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>删除是否成功</returns>
        public Boolean deleteInvestmentIncome(int[] ids)
        {
            InvestmentIncome InvestmentIncome = new InvestmentIncome();
            for (int i = 0; i < ids.Length; i++)
            {
                InvestmentIncome = commonModel.comFind<InvestmentIncome>(InvestmentIncome, ids[i]);
                if (commonModel.comDel<InvestmentIncome>(InvestmentIncome) <= 0)
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
        public Boolean updateInvestmentIncome(InvestmentIncome InvestmentIncome)
        {
            return commonModel.comUpd<InvestmentIncome>(InvestmentIncome) > 0;
        }
    }
}