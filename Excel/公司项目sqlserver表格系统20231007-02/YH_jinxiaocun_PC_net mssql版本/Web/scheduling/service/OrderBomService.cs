using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class OrderBomService
    {
        private static OrderBomDao obd = new OrderBomDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public OrderBomService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 查询某条订单全部bom
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<order_bom> getList(int id)
        {
            return obd.getList(id);
        }
    }
}