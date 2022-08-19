using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class OrderCheckDao
    {
        private schedulingEntities se;

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        /// <summary>
        /// 查询所有排班汇总
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<order_check> getList(int skip, int take, string order_number, string moudle,string company,string ks,string js)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@moudle", moudle),
                new SqlParameter("@order_number", order_number),
                new SqlParameter("@company", company),
                new SqlParameter("@ks", ks),
                new SqlParameter("@js", js),
            };
            string sql = "select * from order_check where moudle like '%'+ @moudle +'%' and order_number like '%'+ @order_number +'%' and company=@company and convert(date,riqi)>=@ks and convert(date,riqi)<=@js";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<order_check>(sql, @params).OrderBy(p => p.riqi).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int Count()
        {
            using (se = new schedulingEntities())
            {
                var result = se.order_check.Count();
                return (int)result;
            }
        }

        public T save<T>(T t)
        {
            using (se = new schedulingEntities())
            {
                se.Set(t.GetType()).Add(t);
                se.SaveChanges();
                return t;
            }
        }

        public Boolean delete<T>(int id) where T : class
        {
            using (se = new schedulingEntities())
            {
                se.Entry<T>(se.Set<T>().Find(id)).State = EntityState.Deleted;
                return se.SaveChanges() > 0;
            }
        }

        public Boolean update<T>(T t) where T : class
        {
            using (se = new schedulingEntities())
            {
                se.Set(t.GetType()).Attach(t);
                se.Entry(t).State = EntityState.Modified;
                return se.SaveChanges() > 0;
            }
        }

    }
}