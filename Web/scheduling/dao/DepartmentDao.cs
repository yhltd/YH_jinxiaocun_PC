using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class DepartmentDao
    {
        private schedulingEntities se;
        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<department> getList(int skip, int take, string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.department.Where(b => b.company == company).OrderBy(d => d.department_name).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int DepartmentCount()
        {
            using (se = new schedulingEntities())
            {
                var result = se.department.Count();
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

        public List<department> getListByName(String departmentName,string company) 
        {
            using (se = new schedulingEntities())
            {
                var result = from d in se.department where d.department_name == departmentName && d.company==company select d;
                return result.ToList();
            }
        }

        
        
    }
}