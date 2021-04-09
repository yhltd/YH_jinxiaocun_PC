using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class WorkDetailDao
    {
        private schedulingEntities se;

        public List<WorkItem> list(string company, int skip, int take, string orderId)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@orderId", orderId),
                new SqlParameter("@minRowNumber", skip * take),
                new SqlParameter("@maxRowNumber", (skip + 1) * take + 1)
            };

            string sql = "select * from (select row_number() over(order by wd.id) as rownum,wd.*,oi.order_id as orderId from work_detail as wd left join order_info as oi on wd.order_id = oi.id) as wd where wd.company = @company and wd.orderId like '%' + @orderId + '%' and rownum > @minRowNumber and rownum < @maxRowNumber order by wd.row_num,wd.is_insert asc";

            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<WorkItem>(sql, @params);
                return result.ToList();
            }
        }

        public int count(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.work_detail.Count(w => w.company == company);
                return (int)result;
            }
        }

        public Boolean deleteByModuleId(int moduleId)
        {
            using (se = new schedulingEntities())
            {
                var param = new SqlParameter("@moduleId", moduleId);
                var sql = "delete from work_detail where id in (select work_id from work_module where module_id = @moduleId) ";
                return se.Database.ExecuteSqlCommand(sql, param) > 0;
            }
        }
    }
}