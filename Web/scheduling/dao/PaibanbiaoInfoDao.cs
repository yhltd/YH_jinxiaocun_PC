using System;
using System.Collections.Generic;
using System.Data;
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
        public List<paibanbiao_info> getList(int skip, int take)
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_info.OrderBy(p => p.riqi).Skip(skip).Take(take);
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