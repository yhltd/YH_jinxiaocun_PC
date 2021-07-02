using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class PaibanbiaoInfoDao
    {
        private schedulingEntities se;

        public T save<T>(T t)
        {
            using (se = new schedulingEntities())
            {
                se.Set(t.GetType()).Add(t);
                se.SaveChanges();
                return t;
            }
        }

        /// <summary>
        /// 查询所有排班汇总
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<paibanbiao_info> getList(int skip, int take, string department_name, string plan_name)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@department_name", department_name),
                new SqlParameter("@plan_name", plan_name),
            };
            string sql = "select * from paibanbiao_info where department_name like '%'+ @department_name +'%' and plan_name like '%'+ @plan_name +'%'";
            using (se = new schedulingEntities())
            {
                //var result = se.Database.SqlQuery<WorkSummary>(sql, @params).OrderBy(w => w.type).Skip(skip).Take(take);
                var result = se.Database.SqlQuery<paibanbiao_info>(sql, @params).OrderBy(p => p.riqi).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int Count()
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_info.Count();
                return (int)result;
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