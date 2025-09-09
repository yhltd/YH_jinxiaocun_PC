using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Server;
using System.Web;



namespace Web.Pushnews.utils
{
    public class TokenUtil1
    {
        private const double VALID_NUM = 12;


        public static void setToken(yh_jinxiaocun_user user)
        {
            string token = RsaUtil.RSAEncryption(JsonUtil.toJson(user));
            DateTime dateTime = DateTime.Now.AddHours(VALID_NUM);
            HttpRuntime.Cache.Insert("pushnews_token", token, null, dateTime, TimeSpan.Zero);
        }
        public static void setToken_dp(yh_jinxiaocun_user user)
        {
            string token = RsaUtil.RSAEncryption(JsonUtil.toJson(user));
            DateTime dateTime = DateTime.Now.AddHours(VALID_NUM);
            HttpRuntime.Cache.Insert("pushnews_token_dp", token, null, dateTime, TimeSpan.Zero);
        }

        public static yh_jinxiaocun_user getToken()
        {
            try
            {
                string token = HttpRuntime.Cache.Get("pushnews_token").ToString();
                return JsonUtil.toObject<yh_jinxiaocun_user>(RsaUtil.RSADecrypt(token));
            }
            catch
            {
                return null;
            }
        }
    }
}