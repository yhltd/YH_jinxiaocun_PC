using Web.Models;
using Web.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.Service
{
    /// <author>
    /// dai
    /// </author>
    public class AccountService
    {
        //model层
        private AccountModel am;

        private Account account;

        //实例化
        public AccountService(Boolean isLogin) {
            //实例化model层
            am = new AccountModel();
            if (isLogin) {
                try
                {
                    //获取token
                    string token = FinanceToken.getFinanceCheckToken().getToken();
                    //获取对象
                    account = FinanceToken.getFinanceCheckToken().checkToken(token);
                }
                catch
                {
                    throw new InvalidOperationException("身份验证不通过");
                }
            }
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

        /// <summary>
        /// 获取所有公司名
        /// </summary>
        /// <returns>公司名数组</returns>
        public List<string> getCompanys()
        {
            List<Account> accountList = am.getAccounts();
            List<string> companys = new List<string>();
            var groups = accountList.GroupBy(p => p.company);
            foreach (var group in groups)
            {
                companys.Add(group.Key);
            }
            return companys;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>1为修改成功，-2为修改失败，-1为旧密码错误</returns>
        public int updatePwd(string oldPwd,string newPwd) {
            int state = 0;
            if (account.pwd.Equals(oldPwd))
            {
                int result = am.updatePwd(account.id, newPwd);
                if (result > 0) 
                {
                    state = 1;
                }
                else
                {
                    state = -2;
                }
            }
            else 
            {
                state = -1;
            }
            return state;
        }

        /// <summary>
        /// 修改操作密码
        /// </summary>
        /// <param name="oldPwd">旧操作密码</param>
        /// <param name="newPwd">新操作密码</param>
        /// <returns>1为修改成功，-2为修改失败，-1为旧操作密码错误</returns>
        public int updateDo(string oldDo, string newDo) {
            int state = 0;
            if (account.@do.Equals(oldDo))
            {
                int result = am.updateDo(account.id, newDo);
                if (result > 0)
                {
                    state = 1;
                }
                else
                {
                    state = -2;
                }
            }
            else
            {
                state = -1;
            }
            return state;
        }

        /// <summary>
        /// 检查操作密码是否正确
        /// </summary>
        /// <param name="do">操作密码</param>
        /// <returns>boolean</returns>
        public Boolean checkDo(string @do)
        {
            return account.@do == @do;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="account">用户对象</param>
        /// <returns>1为修改成功，-1为操作密码错误，-2为用户名重复,-3为新增失败</returns>
        public int newUser(string myDo,Account newAccount) {

            int state = 0;
            //验证操作密码
            if (this.checkDo(myDo))
            {
                //验证用户名是否重复
                Account checkAccount = am.getAccount(newAccount.name);
                if (checkAccount == null)
                {
                    newAccount.company = account.company;
                    //新增操作
                    int result = am.newUser(newAccount);
                    if (result > 0)
                    {
                        state = 1;
                    }
                    else
                    {
                        state = -3;
                    }
                    
                }
                else 
                {
                    state = -2;
                }
            }
            else 
            {
                state = -1;
            }
            return state;
        }
    }
}