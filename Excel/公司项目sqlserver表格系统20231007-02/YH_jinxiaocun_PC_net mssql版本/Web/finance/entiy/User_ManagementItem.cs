using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class User_ManagementItem : Account
    {
        //行号
        public Int64 rownum { get; set; }

        public Account getAccount()
        {
            Account account = new Account();
            account.id = this.id;
            account.company = this.company;
            account.pwd = this.pwd;
            account.@do = this.@do;
            account.name = this.name;
            account.salt = this.salt;
            account.bianhao = this.bianhao;
            return account;
        }
    }
}