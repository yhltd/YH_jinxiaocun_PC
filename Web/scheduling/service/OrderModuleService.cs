using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class OrderModuleService
    {
        private static OrderModuleDao omd = new OrderModuleDao();
        private user_info user;

        public OrderModuleService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        public List<order_gongxu> getList(int orderId)
        {
            return omd.getList(orderId);
        }
    }
}