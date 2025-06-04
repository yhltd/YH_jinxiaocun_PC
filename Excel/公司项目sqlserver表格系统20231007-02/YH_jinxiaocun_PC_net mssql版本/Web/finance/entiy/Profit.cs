using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class Profit
    {
        /// <summary>
        /// 科目名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 本月合计
        /// </summary>
        public decimal sum_month { get; set; }
        /// <summary>
        /// 本年合计
        /// </summary>
        public decimal sum_year { get; set; }
    }
}