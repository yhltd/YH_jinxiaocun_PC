using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;

namespace Web.finance.entiy
{
    public class SimpleAccountingSummary : SimpleAccounting
    {
        //序号
        public Int64 ROW_id { get; set; }
        //应收
        public decimal receipts { get; set; }
        //实收
        public decimal receivable { get; set; }
        //未收
        public decimal notget1 { get; set; }
        //应付
        public decimal cope { get; set; }
        //实付
        public decimal payment { get; set; }
        //未付
        public decimal notget2 { get; set; }

        public SimpleAccounting getParent()
        {
            SimpleAccounting sa = new SimpleAccounting();
            sa.id = this.id;
            sa.accounting = this.accounting;
            sa.company = this.company;
            return sa;
        }
    }
}