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
    public class LiabilitiesService
    {
        //公共model层
        private LiabilitiesModel liabilitiesModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public LiabilitiesService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                liabilitiesModel = new LiabilitiesModel();
            }catch{
                throw new InvalidOperationException("身份验证不通过");
            }
        }


        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<Liabilities> getLiabilitiesList(FinancePage<Liabilities> financePage)
        {
            //获取pageList
            financePage = liabilitiesModel.getLiabilitiesList(financePage, account.company);
            int classId = int.Parse(financePage.selectParamsMap["classId"]);
            //foreach (Liabilities l in financePage.pageList) {
            //    decimal load = l.load;
            //    decimal borrowed = l.borrowed;
            //    decimal money = l.money;
            //    if (classId == 1)
            //    {
            //        l.load = load - borrowed;
            //        l.borrowed = load - borrowed + money;
            //    }
            //    else {
            //        l.load = borrowed - load;
            //        l.borrowed = borrowed - load + money;
            //    }
            //}
            //获取总行数
            financePage.total = liabilitiesModel.getCount(account.company, classId);

            return financePage;
        }
    }
}