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
    public class AccountingService
    {
        //model层
        private AccountingModel accountingModel;

        private Account account;

        //实例化
        public AccountingService() {
            accountingModel = new AccountingModel();
            try
            {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                accountingModel = new AccountingModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 新增科目
        /// </summary>
        /// <param name="accounting">科目对象</param>
        /// <returns>新增是否成功</returns>
        public Boolean newAccounting(Accounting accounting)
        {
            accounting.company = account.company;
            return accountingModel.newAccounting(accounting) > 0;
        }

        /// <summary>
        /// 删除科目
        /// </summary>
        /// <param name="ids">id数组</param>
        /// <returns>是否全部删除成功</returns>
        public Boolean delAccounting(int[] ids)
        {
            for (int idx = 0; idx < ids.Length; idx++)
            {
                if (accountingModel.delAccounting(ids[idx]) <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 修改科目
        /// </summary>
        /// <param name="accountingItem">科目类的子类</param>
        /// <returns>修改过的子类</returns>
        public AccountingItem updAccounting(AccountingItem accountingItem)
        {
            accountingItem.company = account.company;
            int result = accountingModel.updAccounting(accountingItem.getParent());
            return result > 0 ? accountingItem : null;
        }

        /// <summary>
        /// 获取list
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="classId">科目类别id</param>
        /// <returns>有pageList的分页对象</returns>
        public FinancePage<AccountingItem> getList(FinancePage<AccountingItem> financePage,int classId) { 
            FinancePage<AccountingItem> page = accountingModel.getList(financePage, account.company, classId);
            page.total = accountingModel.getPageCount(account.company, classId);
            return page;
        }

        /// <summary>
        /// 获取list
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <param name="classId">科目类别id</param>
        /// <returns>有pageList的分页对象</returns>
        public FinancePage<AccountingItem> getList2(FinancePage<AccountingItem> financePage, int classId,string code)
        {
            FinancePage<AccountingItem> page = accountingModel.getList2(financePage, account.company, classId,code);
            page.total = accountingModel.getPageCount(account.company, classId);
            return page;
        }

        /// <summary>
        /// 获取某一类别某一等级某一特定科目代码下的子类
        /// </summary>
        /// <param name="classId">科目类别</param>
        /// <param name="grade">科目等级</param>
        /// <param name="code">科目父类的科目代码，0为不限制其父类</param>
        /// <returns>科目集合</returns>
        public List<Accounting> getList(int classId, int grade, int code)
        {
            grade = grade == 1 ? 4 : grade == 2 ? 6 : grade == 3 ? 8 : 0;
            return accountingModel.getList(account.company, classId, grade, code);
        }

        /// <summary>
        /// 平衡验证
        /// </summary>
        /// <returns>Map：check：是否验证成功 num：借贷相差多少钱</returns>
        public Dictionary<string, object> balanceCheck() {
            Charts charts = accountingModel.getLoadAndBorrword(account.company);
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (charts.sum_load == charts.sum_borrowed)
            {
                result.Add("check", true);
                result.Add("num", 0);
            }
            else {
                result.Add("check", false);
                if (charts.sum_load > charts.sum_borrowed)
                {
                    result.Add("num", charts.sum_load - charts.sum_borrowed);
                }
                else {
                    result.Add("num", charts.sum_borrowed - charts.sum_load);
                }
            }
            return result;
        }
    }
}