using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class OrderBomDao
    {

        private schedulingEntities se;

        public Boolean deleteBatchByOrderId(int id)
        {
            using (se = new schedulingEntities())
            {
                var result = se.order_bom.Where(o => o.order_id == id);
                foreach (var orderBom in result)
                {
                    se.Entry<order_bom>(se.Set<order_bom>().Find(orderBom.id)).State = EntityState.Deleted;
                }
                return se.SaveChanges() > 0;
            }
        }
    }
}