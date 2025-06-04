using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class Flow
    {
        //项目名称
        public string expenditure { get; set; }
        //当月余额
        public decimal money_month { get; set; }
        //当年余额
        public decimal money_year { get; set; }
    }
}