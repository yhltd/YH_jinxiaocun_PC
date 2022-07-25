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
    public class LirunService : ApiController
    {
        //公共model层
        private CommonModel commonModel;

        private SimpleDataModel simpleDataModel;

        //当前登陆用户对象
        private Account account;

        //构造方法
        public LirunService()
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

        //全部
        public List<lirunList> getAllLirun() {
            simpleDataModel = new SimpleDataModel();
            List<lirunList> getAllLirun=simpleDataModel.getAllLirun(account.company);
            return getAllLirun;
        }
        //本期
        public List<lirunList> getBenqiLirun(string ks,string js)
        {
            simpleDataModel = new SimpleDataModel();
            List<lirunList> getBenqiLirun = simpleDataModel.getBenqiLirun(account.company,ks,js);
            return getBenqiLirun;
        }
        //本年
        public List<lirunList> getBennianLirun(string ks, string js)
        {
            simpleDataModel = new SimpleDataModel();
            List<lirunList> getBennianLirun = simpleDataModel.getBennianLirun(account.company, ks, js);
            return getBennianLirun;
        }
        //上期
        public List<lirunList> getShangqiLirun(string ks)
        {
            simpleDataModel = new SimpleDataModel();
            List<lirunList> getShangqiLirun = simpleDataModel.getShangqiLirun(account.company, ks);
            return getShangqiLirun;
        }

    }
}