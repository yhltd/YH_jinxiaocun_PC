using Web.Models;
using Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    /// <author>
    /// dai
    /// </author>
    public class AccountService
    {
        //model层Account
        private AccountModel am;

        //实例化
        public AccountService() {
            am = new AccountModel();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>密钥</returns>
        public String login(string company,string name,string pwd) {
            //获取用户
            Account account = am.getAccount(company, name, pwd);
            if (account != null){
                //转json后加密
                return FinanceRSA.RSAEncryption(FinanceJson.getFinanceJson().toJson(account));
            } else {
                return "";
            }
        }

        /// <summary>
        /// 用token换取Account对象
        /// </summary>
        /// <param name="token">token字符串</param>
        /// <returns>Account对象</returns>
        public Account getAccount(string token) {
            //解密后转用户类型
            Account account = (Account)FinanceJson.getFinanceJson().toObject<Account>(FinanceRSA.RSADecrypt(token));
            return account;
        }
    }
}