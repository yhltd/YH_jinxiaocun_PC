using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.scheduling.utils
{
    public class ResultUtil : Dictionary<string, object>
    {

        public ResultUtil() { }

        public ResultUtil(int code, object data, string msg) {
            base.Add(CODE, code);
            base.Add(MSG, msg);
            if (data != null) {
                base.Add(DATA, data);
            }
        }

        private const string CODE = "code";

        private const string DATA = "data";

        private const string MSG = "msg";

        public static string success(object data, string msg) 
        {
            return JsonUtil.toJson(new ResultUtil(200, data, msg));
        }

        public static string success(string msg) 
        {
            return success(null, msg);
        }

        public static string fail(int code, string msg) 
        {
            return JsonUtil.toJson(new ResultUtil(code, null, msg));
        }

        public static string error(string msg) 
        {
            return JsonUtil.toJson(new ResultUtil(500, null, msg));
        }
    }
}