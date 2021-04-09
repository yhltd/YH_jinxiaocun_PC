using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.scheduling.utils
{
    public class JsonUtil
    {
        private static JavaScriptSerializer jsl = new JavaScriptSerializer();

        public static T toObject<T>(string json) 
        {
            
            return jsl.Deserialize<T>(json);
        }

        public static string toJson(object obj)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(obj, Formatting.None, timeConverter);
        }
    }
}