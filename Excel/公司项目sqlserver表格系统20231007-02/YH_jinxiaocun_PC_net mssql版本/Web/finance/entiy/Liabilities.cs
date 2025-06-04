using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class Liabilities
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 年初借金
        /// </summary>
        public decimal load { get; set; }
        /// <summary>
        /// 年初贷金
        /// </summary>
        public decimal borrowed { get; set; }
        /// <summary>
        /// 借贷合计
        /// </summary>
        public decimal money { get; set; }
    }
}