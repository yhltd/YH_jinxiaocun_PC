using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class OrderDao
    {
        private schedulingEntities se;

        public Boolean checkOrderId(string orderId, string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.order_info.Where(o => o.company == company && o.order_id == orderId);
                return (int)result.Count() == 0;
            }
        }

        public List<order_info> list(string company, int skip, int take, string productName, string orderId)
        {
            using(se = new schedulingEntities())
            {
                var result = se.order_info.Where(o => o.company == company && o.product_name.Contains(productName) && o.order_id.Contains(orderId)).OrderBy(o => o.id).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        /// <summary>
        /// 查询所有可生产数量大于0的订单信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<order_info> list(string company)
        {
            using (se = new schedulingEntities()) {
                var result = se.Database.SqlQuery<order_info>("select oi.id,oi.code,oi.product_name,oi.norms,oi.set_date,oi.company,oi.order_id,oi.set_num-sum(isnull(wd.work_num, 0)) as set_num from order_info as oi left join work_detail as wd on oi.id = wd.order_id group by oi.id,oi.code,oi.product_name,oi.norms,oi.set_date,oi.company,oi.order_id,oi.set_num having oi.set_num-sum(isnull(wd.work_num, 0)) > 0");
                return result.ToList();
            }
        }

        public int count(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.order_info.Count();
                return (int)result;
            }
        }
    }
}