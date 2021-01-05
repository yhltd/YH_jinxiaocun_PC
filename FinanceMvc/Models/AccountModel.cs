using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    /// <author>
    /// dai
    /// </author>
    public class AccountModel
    {
        //数据库模型
        //private FinanceEntities fin;

        //实例化
        public AccountModel() {
            //fin = new FinanceEntities();
        }
        /// <summary>
        /// 获取单个用户对象
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="name">姓名</param>
        /// <param name="pwd">密码</param>
        /// <returns>用户对象</returns>Web
        public Account getAccount(string company, string name, string pwd) {
            //var result = from u in fin.Account where u.company == company && u.name == name && u.pwd == pwd select u;
            //return result.FirstOrDefault();
            return new Account();
        }

        /// <summary>
        /// 获取单个用户对象
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>用户对象</returns>
        public Account getAccount(int id)
        {
            //var result = from u in fin.Account where u.id == id select u;
            //return result.FirstOrDefault();
            return new Account();
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <returns>用户集合</returns>
        public List<Account> getAccounts()
        {
            //var result = from u in fin.Account select u;
            //return result.ToList();
            return null;
        }
    }
}