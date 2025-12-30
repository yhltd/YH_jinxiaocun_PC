using System;
using System.Collections.Generic;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class waibipeizhiService
    {
        private waibipeizhiModel waibipeizhiModel;
        private Account account;

        public waibipeizhiService()
        {
            try
            {
                string token = FinanceToken.getFinanceCheckToken().getToken();
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                waibipeizhiModel = new waibipeizhiModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public FinancePage<waibiPeizhi> getList(FinancePage<waibiPeizhi> financePage, string huilv, string bizhong)
        {
            financePage = waibipeizhiModel.getList(financePage, account.company, huilv, bizhong);  // 修改：传递参数
            financePage.total = waibipeizhiModel.getCount(account.company, huilv, bizhong);  // 修改：传递参数
            return financePage;
        }


        /// <summary>
        /// 获取所有数据（导出Excel）
        /// </summary>
        public List<waibiPeizhi> getAllList(string huilv, string bizhong)
        {
            return waibipeizhiModel.getAllList(account.company, huilv, bizhong);  // 修改：传递参数
        }

        /// <summary>
        /// 修改
        /// </summary>
        public Boolean upd(waibiPeizhi entity)
        {
            entity.company = account.company;
            int result = waibipeizhiModel.updBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public Boolean add(waibiPeizhi entity)
        {
            entity.company = account.company;
            int result = waibipeizhiModel.addBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public Boolean del(int[] ids)
        {
            int result = waibipeizhiModel.delBySql(account.company, ids);
            return result > 0;
        }
    }
}