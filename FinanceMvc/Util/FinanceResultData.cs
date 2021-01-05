using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Util
{
    /// <author>
    /// dai
    /// </author>
    public class FinanceResultData
    {
        private FinanceResultData(){}

        public static FinanceResultData resultData;

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns>返回this</returns>
        public static FinanceResultData getFinanceResultData() {
            if (resultData == null) {
                resultData = new FinanceResultData();
            }
            return resultData;
        }

        //状态码
        public int code { get; set; }
        //数据
        public object data { get; set; }
        //消息
        public string msg { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns>json</returns>
        public string success(int code, object data, string msg)
        {
            this.code = code;
            this.data = data;
            this.msg = msg;
            return FinanceJson.getFinanceJson().toJson(this);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="data">数据</param>
        /// <returns>json</returns>
        public string success(int code, object data)
        {
            this.code = code;
            this.data = data;
            this.msg = "";
            return FinanceJson.getFinanceJson().toJson(this);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns>json</returns>
        public string fail(object data,string msg)
        {
            this.code = 500;
            this.data = data;
            this.msg = msg;
            return FinanceJson.getFinanceJson().toJson(this);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns>json</returns>
        public string fail(int code,object data, string msg)
        {
            this.code = code;
            this.data = data;
            this.msg = msg;
            return FinanceJson.getFinanceJson().toJson(this);
        }
    }
}