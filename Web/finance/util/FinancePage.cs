using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Web.finance.util
{
    /// <author>
    /// dai
    /// </author>
    public class FinancePage<T>
    {
        //当前页
        public int currentPage { get; set; }
        //每页多少项
        public int pageSize { get; set; }
        //总条数
        public int total { get; set; }
        //当前页list
        public List<T> pageList { get; set; }
        //查询条件
        public Dictionary<string, string> selectParamsMap { get; set; }

        public int getMin() {
            return (this.currentPage - 1) * this.pageSize;
        }

        public int getMax()
        {
            return this.currentPage * this.pageSize + 1;
        }

        public Boolean isEmpty() {
            return !(currentPage == 0 || pageSize == 0);
        }
    }
}