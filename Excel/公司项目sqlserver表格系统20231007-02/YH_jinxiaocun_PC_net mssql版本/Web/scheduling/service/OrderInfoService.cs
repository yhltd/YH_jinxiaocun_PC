using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class OrderInfoService
    {
        private static OrderDao oo = new OrderDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public OrderInfoService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        public Boolean checkOrderId(string orderId)
        {
            return oo.checkOrderId(orderId, user.company);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页行数</param>
        /// <param name="productName">产品名</param>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        public PageUtil<order_info> page(int nowPage, int pageCount, string productName, string orderId)
        {
            PageUtil<order_info> page = new PageUtil<order_info>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = oo.count(user.company);
            page.pageList = oo.list(user.company, page.getSkip(), page.getTake(), productName, orderId);
            return page;
        }

        /// <summary>
        /// 查询所有订单信息
        /// </summary>
        /// <returns></returns>
        public List<order_info> list()
        {
            return oo.list(user.company);
        }

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="orderInfo">订单信息</param>
        /// <param name="bomList">所用物料信息</param>
        /// <returns></returns>
        public Boolean save(order_info orderInfo, List<BomInfoItem> bomList)
        {
            orderInfo.set_date = DateTime.Now;
            orderInfo.company = user.company;
            orderInfo = cd.save<order_info>(orderInfo);
            if (orderInfo != null)
            {
                order_bom orderBom;
                foreach (BomInfoItem bomInfo in bomList)
                {
                    orderBom = new order_bom();
                    orderBom.order_id = orderInfo.id;
                    orderBom.bom_id = bomInfo.id;
                    orderBom.use_num = bomInfo.useNum;
                    cd.save<order_bom>(orderBom);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 重新保存物料信息
        /// </summary>
        /// <param name="orderInfo">订单信息</param>
        /// <param name="bomList">所用物料信息</param>
        /// <returns></returns>
        public Boolean saveBom(int updOrderId, List<BomInfoItem> bomList)
        {
            if (updOrderId != null)
            {
                order_bom orderBom;
                foreach (BomInfoItem bomInfo in bomList)
                {
                    orderBom = new order_bom();
                    orderBom.order_id = updOrderId;
                    orderBom.bom_id = bomInfo.id;
                    orderBom.use_num = bomInfo.useNum;
                    cd.save<order_bom>(orderBom);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改订单信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(order_info orderInfo)
        {
            orderInfo.company = user.company;
            return cd.update<order_info>(orderInfo);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id">订单id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            OrderBomDao orderBomDao = new OrderBomDao();
            if (orderBomDao.deleteBatchByOrderId(id))
            {
                return cd.delete<order_info>(id);
            }
            return false;
        }


        /// <summary>
        /// 删除订单Bom
        /// </summary>
        /// <param name="id">订单id</param>
        /// <returns></returns>
        public Boolean deleteBom(int id)
        {
            OrderBomDao orderBomDao = new OrderBomDao();
            return orderBomDao.deleteBatchByOrderId(id);
        }

    }
}