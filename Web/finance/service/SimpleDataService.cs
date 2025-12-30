using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    /// <author>
    /// dai
    /// </author>
    public class SimpleDataService
    {
        //model
        private SimpleDataModel simpleDataModel;
        
        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public SimpleDataService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
                simpleDataModel = new SimpleDataModel();
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
        public FinancePage<SimpleData> getSimpleDataList(FinancePage<SimpleData> financePage,string start_date,string stop_date) {
            financePage = simpleDataModel.getSimpleDataList(financePage, account.company,start_date,stop_date);
            financePage.total = simpleDataModel.getCount(account.company);
            return financePage;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="simpleData"></param>
        /// <returns></returns>
        public Boolean newSimpleData(SimpleData simpleData)
        {
            simpleData.company = account.company;
            int result = commonModel.comAdd<SimpleData>(simpleData);
            return result > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="simpleData"></param>
        /// <returns></returns>
        //public Boolean updSimpleData(SimpleData simpleData) {
        //    simpleData.company = account.company;
        //    int result = commonModel.comUpd<SimpleData>(simpleData);
        //    return result > 0;
        //}
        public Boolean updSimpleData(SimpleData simpleData)
        {
            simpleData.company = account.company;
            // 确保税相关字段有值
            simpleData.nashuijine = simpleData.nashuijine ?? 0;
            simpleData.yijiaoshuijine = simpleData.yijiaoshuijine ?? 0;
            int result = commonModel.comUpd<SimpleData>(simpleData);
            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Boolean delSimpleData(int[] ids) {
            SimpleData simpleData = new SimpleData();
            for (int i = 0; i < ids.Length; i++) {
                simpleData = commonModel.comFind<SimpleData>(simpleData,ids[i]);
                if (commonModel.comDel<SimpleData>(simpleData) <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}