using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Util
{
    /// <author>
    /// dai
    /// </author>
    public class FinanceViewPath
    {
        /// <summary>
        /// 返回绕过mvc默认路径的绝对路径
        /// </summary>
        /// <param name="name">视图名</param>
        /// <returns>路径字符串</returns>
        public static string getViewName(string name)
        {
            return "~/Views/" + name + ".cshtml";
        }
    }
}