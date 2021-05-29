using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class PaibanDetailDao
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

        public List<paibanbiao_detail> getList(int skip, int take, String company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_detail.Where(pd => pd.company == company).OrderBy(pd => pd.c).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int Count()
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_detail.Count();
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