using System;
using System.Collections.Generic;
using Web.Pushnews.dao;
using Web.Pushnews.model;
using Web.Pushnews.utils;
using Web.Server;

using Web.scheduling.utils;




namespace Web.Pushnews.service
{
    public class PushNewsService
    {
       private static PushNewsDao rd = new PushNewsDao();

       private yh_jinxiaocun_user user;

        public PushNewsService()
       {
           user = TokenUtil1.getToken();
           if (user == null)
           {
               throw new ErrorUtil1("无权限");
           }
       }


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public PageUtil<product_pushnews> list()
        {
            PageUtil<product_pushnews> page = new PageUtil<product_pushnews>();
            page.pageList = rd.SelectList();
            return page;
        }

    }
}