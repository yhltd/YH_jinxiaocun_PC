using System;
using System.Collections.Generic;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class ysyfpeizhiService
    {
        private ysyfpzModel ysyfpzModel;
        private Account account;

        public ysyfpeizhiService()
        {
            try
            {
                string token = FinanceToken.getFinanceCheckToken().getToken();
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                ysyfpzModel = new ysyfpzModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public FinancePage<ysyfpeizhi> getList(FinancePage<ysyfpeizhi> financePage, string ysyf, string xiangmumingcheng)
        {
            financePage = ysyfpzModel.getList(financePage, account.company, ysyf, xiangmumingcheng);
            financePage.total = ysyfpzModel.getCount(account.company, ysyf, xiangmumingcheng);
            return financePage;
        }

        /// <summary>
        /// 获取所有数据（导出Excel）
        /// </summary>
        public List<ysyfpeizhi> getAllList(string ysyf, string xiangmumingcheng)
        {
            return ysyfpzModel.getAllList(account.company, ysyf, xiangmumingcheng);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public Boolean upd(ysyfpeizhi entity)
        {
            entity.company = account.company;
            int result = ysyfpzModel.updBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public Boolean add(ysyfpeizhi entity)
        {
            entity.company = account.company;
            int result = ysyfpzModel.addBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public Boolean del(int[] ids)
        {
            int result = ysyfpzModel.delBySql(account.company, ids);
            return result > 0;
        }
    }
}