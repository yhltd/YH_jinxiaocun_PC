using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.Models;
using Web.Util;

namespace Web.finance.util
{
    /// <author>
    /// dai
    /// </author>
    public class FinanceToken
    {
        //私有化构造方法
        private FinanceToken() { }

        //私有对象
        private static FinanceToken financeCheckToken;

        //单例
        public static FinanceToken getFinanceCheckToken()
        {
            if (financeCheckToken == null) {
                financeCheckToken = new FinanceToken();
            }
            return financeCheckToken;
        }

        //密钥有效时间 小时
        private const double tokenValidTime = 24; 

        /// <summary>
        /// 获取当前token
        /// </summary>
        /// <returns>token字符串</returns>
        public string getToken() {
            return HttpRuntime.Cache.Get("finance_token").ToString();
        }

        /// <summary>
        /// 设置当前token
        /// </summary>
        /// <param name="token"></param>
        public void setToken(string token) {
            DateTime dateTime = DateTime.Now.AddHours(FinanceToken.tokenValidTime);
            HttpRuntime.Cache.Insert("finance_token", token, null,dateTime, TimeSpan.Zero);
        }

        /// <summary>
        /// 检查token是否有效
        /// </summary>
        /// <param name="token">密钥</param>
        /// <returns>有效返回对象，无效返回null</returns>
        public Account checkToken(string token)
        {
            //解密
            token = FinanceRSA.RSADecrypt(token);
            Account account = null;
            //json转对象
            try
            {
                account = FinanceJson.getFinanceJson().toObject<Account>(token);
            }
            catch (Exception ex) {
                FinanceToError.getFinanceToError().toError();
            }
            return account;
        }
    }
}