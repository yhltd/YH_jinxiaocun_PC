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
    public class FlowService
    {
        //公共model层
        private FlowModel flowModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public FlowService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                flowModel = new FlowModel();
            }catch{
                throw new InvalidOperationException("身份验证不通过");
            }
        }


        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public FinancePage<Flow> getFlowList(FinancePage<Flow> financePage)
        {
            //获取pageList
            financePage = flowModel.getFlowList(financePage, account.company);
            //获取总行数
            financePage.total = flowModel.getCount(account.company);

            return financePage;
        }
    }
}