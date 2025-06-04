using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class SubLedgerService : ApiController
    {
        //model
        private SimpleDataModel simpleDataModel;

        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public SubLedgerService()
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
        public List<SimpleData> getKehuSubLedger(string ks, string js,string kehu)
        {
            List<SimpleData> getList = simpleDataModel.getKehuSubLedger(account.company, ks, js,kehu);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<SimpleData> getKehuSubLedgerByFirst(string ks, string js, string kehu)
        {
            List<SimpleData> getList = simpleDataModel.getKehuSubLedgerByFirst(account.company, ks, js, kehu);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<SimpleData> getGYSSubLedger(string ks, string js, string kehu)
        {
            List<SimpleData> getList = simpleDataModel.getGYSSubLedger(account.company, ks, js, kehu);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<SimpleData> getGYSSubLedgerByFirst(string ks, string js, string kehu)
        {
            List<SimpleData> getList = simpleDataModel.getGYSSubLedgerByFirst(account.company, ks, js, kehu);
            return getList;
        }

    }
}