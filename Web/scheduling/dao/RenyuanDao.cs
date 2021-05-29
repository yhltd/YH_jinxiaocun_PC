using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class RenyuanDao
    {
        private schedulingEntities se;

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<paibanbiao_renyuan> getList(int skip, int take,String company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_renyuan.Where(r => r.company == company).OrderBy(r => r.department_name).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int DepartmentCount()
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_renyuan.Count();
                return (int)result;
            }
        }

        public T add<T>(T t)
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


        public List<paibanbiao_renyuan> getAllList(String company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_renyuan.Where(r => r.company == company);
                return result.ToList();
            }
        }

        public List<paibanbiao_renyuan> getAllList(String company,String department_name)
        {
            using (se = new schedulingEntities())
            {
                var result = se.paibanbiao_renyuan.Where(r => r.company == company && r.department_name==department_name);
                return result.ToList();
            }
        }


    }
}