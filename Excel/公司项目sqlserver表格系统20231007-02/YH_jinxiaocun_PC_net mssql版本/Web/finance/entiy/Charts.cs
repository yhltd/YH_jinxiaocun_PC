using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class Charts
    {
        public decimal sum_load { get; set; }
        public decimal sum_borrowed { get; set; }
        public decimal sum { get; set; }
        public Boolean direction { get; set; }
        public decimal sum_money { get; set; }
        public decimal sum_month { get; set; }
        public decimal sum_year { get; set; }
    }
}