using System;
using System.Collections.Generic;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class shuilvpeizhiService
    {
        private shuilvpeizhiModel shuilvpeizhiModel;
        private Account account;

        public shuilvpeizhiService()
        {
            try
            {
                string token = FinanceToken.getFinanceCheckToken().getToken();
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                shuilvpeizhiModel = new shuilvpeizhiModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public FinancePage<shuilvPeizhi> getList(FinancePage<shuilvPeizhi> financePage, string shuilv, string linjiezhi)
        {
            financePage = shuilvpeizhiModel.getList(financePage, account.company, shuilv, linjiezhi);  // 修改：传递参数
            financePage.total = shuilvpeizhiModel.getCount(account.company, shuilv, linjiezhi);  // 修改：传递参数
            return financePage;
        }

        /// <summary>
        /// 获取所有数据（导出Excel）
        /// </summary>
        public List<shuilvPeizhi> getAllList(string shuilv, string linjiezhi)
        {
            return shuilvpeizhiModel.getAllList(account.company, shuilv, linjiezhi);  // 修改：传递参数
        }

        /// <summary>
        /// 修改
        /// </summary>
        public Boolean upd(shuilvPeizhi entity)
        {
            entity.company = account.company;
            int result = shuilvpeizhiModel.updBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public Boolean add(shuilvPeizhi entity)
        {
            entity.company = account.company;
            int result = shuilvpeizhiModel.addBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public Boolean del(int[] ids)
        {
            int result = shuilvpeizhiModel.delBySql(account.company, ids);
            return result > 0;
        }
    }
}