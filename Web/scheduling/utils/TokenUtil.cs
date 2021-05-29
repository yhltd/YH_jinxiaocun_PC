using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.utils
{
    public class TokenUtil
    {
        private const double VALID_NUM = 12;


        public static void setToken(user_info user)
        {
            string token = RsaUtil.RSAEncryption(JsonUtil.toJson(user));
            DateTime dateTime = DateTime.Now.AddHours(VALID_NUM);
            HttpRuntime.Cache.Insert("scheduling_token", token, null, dateTime, TimeSpan.Zero);
        }
        public static void setToken_dp(user_info user)
        {
            string token = RsaUtil.RSAEncryption(JsonUtil.toJson(user));
            DateTime dateTime = DateTime.Now.AddHours(VALID_NUM);
            HttpRuntime.Cache.Insert("scheduling_token_dp", token, null, dateTime, TimeSpan.Zero);
        }

        public static user_info getToken()
        {
            try
            {
                string token = HttpRuntime.Cache.Get("scheduling_token").ToString();
                return JsonUtil.toObject<user_info>(RsaUtil.RSADecrypt(token));
            }
            catch
            {
                return null;
            }
        }
    }
}