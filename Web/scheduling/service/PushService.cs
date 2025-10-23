using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Pushnews.model;
using Web.Pushnews.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class PushService : ApiController
    {
        PushNewsDao dao = new PushNewsDao();
        private user_info user;

        public List<product_pushnews> getPushNews(string companyName = null)
        {
            user = TokenUtil.getToken();

            // 优先使用传入的参数，如果没有则使用token中的公司名称
            string company = !string.IsNullOrEmpty(companyName) ? companyName : user.company;

            List<product_pushnews> List = dao.SelectListPC(company);
            return List;
        }
    }
}