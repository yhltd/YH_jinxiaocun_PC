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
    public class VoucherSummaryItem : VoucherSummary
    {
        //行号
        public Int64 rownum { get; set; }
        //全称
        public string fullName { get; set; }
        //借方金额
        public decimal load { get; set; }
        //贷方金额
        public decimal borrowed { get; set; }

        public VoucherSummary getParent() {
            VoucherSummary voucherSummary = new VoucherSummary();
            voucherSummary.id = this.id;
            voucherSummary.word = this.word;
            voucherSummary.no = this.no;
            voucherSummary.@abstract = this.@abstract;
            voucherSummary.code = this.code;
            voucherSummary.department = this.department;
            voucherSummary.expenditure = this.expenditure;
            voucherSummary.note = this.note;
            voucherSummary.man = this.man;
            voucherSummary.money = this.money;
            voucherSummary.company = this.company;
            voucherSummary.voucherDate = this.voucherDate;
            voucherSummary.real = this.real;
            return voucherSummary;
        }
    }
}