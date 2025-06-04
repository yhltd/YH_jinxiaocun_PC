using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.finance.model;
using Web.finance.util;

namespace Web.Models
{
    /// <author>
    /// dai
    /// </author>
    public class AccountModel
    {
        //数据库模型
        private FinanceEntities fin;

        //实例化
        public AccountModel() 
        {
            fin = new FinanceEntities();
        }
        /// <summary>
        /// 获取单个用户对象
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="name">姓名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户对象</returns>Web
        public Account getAccount(string company, string name, string pwd)
        {
            var result = from u in fin.Account where u.company == company && u.name == name && u.pwd == pwd select u;
            Account account = null;
            try
            {
                account = result.FirstOrDefault();
            }
            catch(Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return account;
        }

        /// <summary>
        /// 获取单个用户对象
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>用户对象</returns>
        public Account getAccount(string name)
        {
            Account account = null;
            var result = from u in fin.Account where u.name == name select u;
            try
            {
                account = result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return account;
        }

        /// <summary>
        /// 获取单个用户对象
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>用户对象</returns>
        public Account getAccount(int id)
        {
            var result = from u in fin.Account where u.id == id select u;
            Account account = null;
            try
            {
                account = result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return account;
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <returns>用户集合</returns>
        public List<Account> getAccounts()
        {
            var result = from u in fin.Account select u;
            List<Account> accountList = null;
            try
            {
                accountList = result.ToList();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return accountList;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>影响行数</returns>
        public int updatePwd(int id,string newPwd) {
            Account account = null;
            int result = 0;
            try {
                account = this.getAccount(id);
                account.pwd = newPwd;
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        /// <summary>
        /// 修改操作密码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="newDo">新的操作密码</param>
        /// <returns>影响行数</returns>
        public int updateDo(int id, string newDo) {
            Account account = null;
            int result = 0;
            try
            {
                account = this.getAccount(id);
                account.@do = newDo;
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="account">新用户</param>
        /// <returns>影响行数</returns>
        public int newUser(Account account) {
            int result = 0;
            try 
            {
                fin.Entry<Account>(account).State = EntityState.Added;
                result = fin.SaveChanges();
            }
            catch (Exception ex)
            {
                FinanceToError.getFinanceToError().toError();
            }
            return result;
        }
    }
}