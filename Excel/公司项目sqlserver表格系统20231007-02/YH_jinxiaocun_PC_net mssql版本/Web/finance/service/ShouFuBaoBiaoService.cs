using SDZdb;
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
    public class ShouFuBaoBiaoService : ApiController
    {
        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public ShouFuBaoBiaoService()
        {
            try {
                //获取token
                string token = FinanceToken.getFinanceCheckToken().getToken();
                //获取对象
                account = FinanceToken.getFinanceCheckToken().checkToken(token);
                //实例化model层
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
        public List<shoufubaobiao> getYingShou(string kehu,string ks,string js)
        {
            List<shoufubaobiao> getList = commonModel.getYingShou(account.company, kehu, ks, js);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<shoufubaobiao> getXiaoXiang(string kehu, string ks, string js)
        {
            List<shoufubaobiao> getList = commonModel.getXiaoXiang(account.company, kehu, ks, js);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<shoufubaobiao> getYingFu(string kehu, string ks, string js)
        {
            List<shoufubaobiao> getList = commonModel.getYingFu(account.company, kehu, ks, js);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<shoufubaobiao> getJinXiang(string kehu, string ks, string js)
        {
            List<shoufubaobiao> getList = commonModel.getJinXiang(account.company, kehu,ks,js);
            return getList;
        }

    }
}