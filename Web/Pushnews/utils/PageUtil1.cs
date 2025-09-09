using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.utils
{
    public class Page1Util<T>
    {

        /// <summary>
        /// 当前页
        /// </summary>
        public int nowPage { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int pageCount { get; set; }
        /// <summary>
        /// 当前页的集合
        /// </summary>
        public List<T> pageList { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        /// <returns></returns>
        public int getSkip() 
        {
            return (nowPage - 1) * pageCount;
        }

        /// <summary>
        /// 获取查询的行数
        /// </summary>
        /// <returns></returns>
        public int getTake() 
        {
            return pageCount;
        }
    }
}