using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.Util
{
    /// <author>
    /// dai
    /// </author>
    public class FinanceJson
    {
        private static FinanceJson financeJson;

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns>this</returns>
        public static FinanceJson getFinanceJson() {
            if (financeJson == null) {
                financeJson = new FinanceJson();
            }
            return financeJson;
        }

        private static JavaScriptSerializer serializer;

        private FinanceJson()
        {
            serializer = new JavaScriptSerializer();
        }
        
        /// <summary>
        /// object转json
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>json字符串</returns>
        public string toJson(Object data)
        {
            return serializer.Serialize(data);
        }

        /// <summary>
        /// json转实体类
        /// </summary>
        /// <param name="json">json</param>
        /// <param name="T">类型</param>
        /// <returns>实体类</returns>
        public T toObject<T>(string json)
        {
            return serializer.Deserialize<T>(json);
        }
    }
}