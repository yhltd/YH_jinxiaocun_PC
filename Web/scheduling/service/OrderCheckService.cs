using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class OrderCheckService
    {
        private static OrderCheckDao ocd = new OrderCheckDao();

        private user_info user;

        //public DepartmentService()
        //{
        //    user = TokenUtil.getToken();
        //    if (user == null)
        //    {
        //        throw new ErrorUtil("无权限");
        //    }
        //}

        /// <summary>
        /// 查询订单核对汇总
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页显示行数</param>
        /// <returns></returns>
        public PageUtil<order_check> getList(int nowPage, int pageCount,string order_number,string moudle,string ks,string js)
        {
            user=TokenUtil.getToken();
            string company=user.company;
            PageUtil<order_check> page = new PageUtil<order_check>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = ocd.Count();
            page.pageList = ocd.getList(page.getSkip(), page.getTake(), order_number, moudle, company,ks,js);
            return page;
        }


        /// <summary>
        /// 新增订单核对
        /// </summary>
        /// <returns></returns>
        public Boolean save(order_check order_check)
        {
            user = TokenUtil.getToken();
            order_check.company = user.company;
            return ocd.save<order_check>(order_check) != null;
        }

        /// <summary>
        /// 删除订单核对
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            return ocd.delete<order_check>(id);
        }

        /// <summary>
        /// 修改订单核对
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(order_check order_check)
        {
            return ocd.update<order_check>(order_check);
        }

    }
}