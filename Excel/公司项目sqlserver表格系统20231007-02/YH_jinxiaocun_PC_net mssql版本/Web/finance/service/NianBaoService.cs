using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.finance.service
{
    public class NianBaoService
    {
        //model
        private SimpleDataModel simpleDataModel;

        //公共model层
        private CommonModel commonModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public NianBaoService()
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
        public List<SimpleData> getNianBaoByNian_shouru(string ks, string js)
        {
            List<SimpleData>getList = simpleDataModel.getNianBaoByNian_shouru(account.company, ks, js);
            return getList;
        }

        /// <summary>
        /// 获取分页对象的pageList和总页数
        /// </summary>
        /// <param name="financePage">分页对象</param>
        /// <returns>处理过的分页对象</returns>
        public List<SimpleData> getNianBaoByNian_zhichu(string ks, string js)
        {
            List<SimpleData> getList = simpleDataModel.getNianBaoByNian_zhichu(account.company, ks, js);
            return getList;
        }

    }
}