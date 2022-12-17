using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class OrderBomDao
    {

        private schedulingEntities se;

        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<order_bom> getList(int id)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@id", id),
            };
            string sql = "select * from order_bom where id= @id";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<order_bom>(sql, @params);
                //var result = se.department.Where(b => b.company == company).OrderBy(d => d.department_name).Skip(skip).Take(take);
                return result.ToList();
            }
        }
    }
}