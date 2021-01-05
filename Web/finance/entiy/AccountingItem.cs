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
    public class AccountingItem : Accounting
    {
        public AccountingItem() {
            this.detail = "Y";
        }
        //序号
        public Int64 rownum { get; set; }
        //科目等级
        public string grade { get; set; }
        //全称
        public string fullName { get; set; }
        //借贷合计
        public decimal money { get; set; }
        //明细
        public string detail { get; set; }
        //类别
        public string @class { get; set; }

        public Accounting getParent() {
            Accounting accounting = new Accounting();
            accounting.id = this.id;
            accounting.code = this.code;
            accounting.direction = this.direction;
            accounting.name = this.name;
            accounting.load = this.load;
            accounting.borrowed = this.borrowed;
            accounting.company = this.company;
            return accounting;
        }
    }
}