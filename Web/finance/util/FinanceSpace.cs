using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;

namespace Web.finance.util
{
    /// <author>
    /// dai
    /// </author>
    public class FinanceSpace
    {

        private static FinanceSpace financeSpace;

        private Account account;
        
        //私有构造函数
        private FinanceSpace(){}

        //单例方法
        public static FinanceSpace getFinanceSpace()
        {
            if (financeSpace == null)
            {
                financeSpace = new FinanceSpace();
            }
            return financeSpace;
        }

        /// <summary>
        /// 获取用户在soft_time表设置的限定容量
        /// </summary>
        /// <returns>KB为单位的总可用容量</returns>
        public int getMark4() {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //获取对象
            Account account = FinanceToken.getFinanceCheckToken().checkToken(token);

            SpaceModel spaceModel = new SpaceModel();
            control_soft_time user = spaceModel.getUserSpaceInfo(account.company);
            if (user != null)
            {
                if (user.mark4 != null)
                {
                    return int.Parse(user.mark4.Trim()) * 1024;
                }
                else {
                    return 0;
                }
            }
            else {
                return 0;
            }
        }

        /// <summary>
        /// 获取已用行数
        /// </summary>
        /// <returns>以KB为单位的已用行数</returns>
        public int getUseMark4() {
            //获取token
            string token = FinanceToken.getFinanceCheckToken().getToken();
            //获取对象
            Account account = FinanceToken.getFinanceCheckToken().checkToken(token);

            VoucherSummaryModel voucherSummaryModel = new VoucherSummaryModel();
            return voucherSummaryModel.getCount(account.company) * 10;
        }

        /// <summary>
        /// 检查容量是否超出
        /// </summary>
        /// <returns>0为正常，-1提醒，-2强制关闭</returns>
        public int checkSpace() {
            int allSpace = 0;
            int use = 0;
            int state = 0;
            try
            {
                allSpace = int.Parse(HttpRuntime.Cache.Get("finance_allSpace").ToString());
                use = int.Parse(HttpRuntime.Cache.Get("finance_useSpace").ToString());

                if (use >= allSpace * 0.9)
                {
                    state = -1;
                }
                if (use >= allSpace * 0.9)
                {
                    state = -2;
                }
            }
            catch (Exception ex) {
                state = 0;
            }

            return state;
        }

        /// <summary>
        /// 获取用户在soft_time表设置的限定容量
        /// </summary>
        /// <returns>KB为单位的总可用容量</returns>
        public int getMark4_all(string company,string xitong)
        {
            SpaceModel spaceModel = new SpaceModel();
            control_soft_time user = spaceModel.getUserSpaceInfo_all(company, xitong);
            if (user != null)
            {
                if (user.mark4 != null)
                {
                    return int.Parse(user.mark4.Trim()) * 1024;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取已用行数
        /// </summary>
        /// <returns>以KB为单位的已用行数</returns>
        public int getUseMark4_all(string company, string xitong)
        {
            VoucherSummaryModel voucherSummaryModel = new VoucherSummaryModel();
            return voucherSummaryModel.getCount(company) * 10;
        }
    }
}