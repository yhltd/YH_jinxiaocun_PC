using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class OrderModuleDao
    {
        private schedulingEntities se;

        public List<order_gongxu> getList(int orderId)
        {
            using (se = new schedulingEntities())
            {
                var result = from og in se.order_gongxu
                             where og.order_id == orderId
                             select og;
                return result.ToList();
            }
        }

        public bool deleteBatchByOrderId(int orderId)
        {
            using (se = new schedulingEntities())
            {
                var result = from og in se.order_gongxu
                             where og.order_id == orderId
                             select og;

                foreach (var item in result)
                {
                    se.order_gongxu.Remove(item);
                }

                return se.SaveChanges() > 0;
            }
        }
    }
}