using System;
using System.Collections.Generic;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class gongzimingxiService
    {
        private gongzimingxiModel gongzimingxiModel;
        private Account account;

        public gongzimingxiService()
        {
            try
            {
                string token = FinanceToken.getFinanceCheckToken().getToken();
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                gongzimingxiModel = new gongzimingxiModel();
            }
            catch
            {
                throw new InvalidOperationException("身份验证不通过");
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        public FinancePage<gongzimingxi> getList(FinancePage<gongzimingxi> financePage, string renming, string beizhu)
        {
            financePage = gongzimingxiModel.getList(financePage, account.company, renming, beizhu);
            financePage.total = gongzimingxiModel.getCount(account.company, renming, beizhu);
            return financePage;
        }

        /// <summary>
        /// 获取所有数据（导出Excel）
        /// </summary>
        public List<gongzimingxi> getAllList(string renming, string beizhu)
        {
            return gongzimingxiModel.getAllList(account.company, renming, beizhu);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public Boolean upd(gongzimingxi entity)
        {
            entity.company = account.company;
            int result = gongzimingxiModel.updBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 新增
        /// </summary>
        public Boolean add(gongzimingxi entity)
        {
            entity.company = account.company;
            int result = gongzimingxiModel.addBySql(entity);
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public Boolean del(int[] ids)
        {
            int result = gongzimingxiModel.delBySql(account.company, ids);
            return result > 0;
        }
    }
}