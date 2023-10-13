using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public List<paibanbiao_detail> getList(int skip, int take, String company,string staff_name,string banci)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@staff_name", staff_name),
                new SqlParameter("@banci", banci),
                new SqlParameter("@company", company),
            };
            string sql = "select * from paibanbiao_detail where staff_name like '%' + @staff_name + '%' and b like '%' + @banci + '%' and company=@company order by e desc,id ";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<paibanbiao_detail>(sql, @params).OrderBy(pd => pd.c).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int Count(int skip, int take, String company, string staff_name, string banci)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@staff_name", staff_name),
                new SqlParameter("@banci", banci),
                new SqlParameter("@company", company),
            };
            string sql = "select * from paibanbiao_detail where staff_name like '%' + @staff_name + '%' and b like '%' + @banci + '%' and company=@company order by e desc,id ";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<paibanbiao_detail>(sql, @params).OrderBy(pd => pd.c);
                return result.ToList().Count;
            }
        }

        //public int Count()
        //{
        //    using (se = new schedulingEntities())
        //    {
        //        var result = se.paibanbiao_detail.Count();
        //        return (int)result;
        //    }
        //}

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

        public Boolean delete2<T>(string e) where T : class
        {
            using (se = new schedulingEntities())
            {
                se.Entry<T>(se.Set<T>().Find(e)).State = EntityState.Deleted;
                return se.SaveChanges() > 0;
            }
        }

        public Boolean deleteWork(int rowNum)
        {
            using (se = new schedulingEntities())
            {
                var param = new SqlParameter("@rowNum", rowNum);
                var sql = "delete from work_detail where row_num=@rowNum";
                return se.Database.ExecuteSqlCommand(sql, param) > 0;
            }
        }

    }
}