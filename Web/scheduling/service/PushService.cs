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

        public List<product_pushnews> getPushNews()
        {
            user = TokenUtil.getToken();
            string company = user.company;
            List<product_pushnews> List = dao.SelectListPC();
            return List;
        }
    }
}