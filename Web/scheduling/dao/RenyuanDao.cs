using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        //public List<paibanbiao_renyuan> getList(int skip, int take,String company,string staff_name,string staff_banci)
        //{
        //    var @params = new SqlParameter[]{
        //        new SqlParameter("@staff_name", staff_name),
        //        new SqlParameter("@banci", staff_banci),
        //        new SqlParameter("@company",company),
        //    };
        //    string sql = "select * from paibanbiao_renyuan where staff_name like '%'+ @staff_name +'%' and banci like '%'+ @banci +'%' and company=@company";
        //    using (se = new schedulingEntities())
        //    {
        //        var result = se.Database.SqlQuery<paibanbiao_renyuan>(sql, @params).OrderBy(p => p.department_name).Skip(skip).Take(take);
        //        //var result = se.paibanbiao_renyuan.Where(r => r.company == company).OrderBy(r => r.department_name).Skip(skip).Take(take);
        //        return result.ToList();
        //    }
        //}
        public List<paibanbiao_renyuan> getList(int skip, int take, String company, string staff_name, string staff_banci, string shengchanxian, string gongxu)
        {
            var @params = new SqlParameter[]{
            new SqlParameter("@staff_name", staff_name ?? ""),
            new SqlParameter("@banci", staff_banci ?? ""),
            new SqlParameter("@shengchanxian", shengchanxian ?? ""),
            new SqlParameter("@gongxu", gongxu ?? ""),
            new SqlParameter("@company", company),
            new SqlParameter("@skip", skip),
            new SqlParameter("@take", take)
        };

                // 使用存储过程或更复杂的查询
                string sql = @"
            WITH FilteredData AS (
                SELECT *,
                       ROW_NUMBER() OVER (ORDER BY department_name) AS RowNum
                FROM paibanbiao_renyuan 
                WHERE company = @company 
                AND (staff_name LIKE '%' + @staff_name + '%' OR @staff_name = '')
                AND (banci LIKE '%' + @banci + '%' OR @banci = '')
                AND (shengchanxian LIKE '%' + @shengchanxian + '%' OR @shengchanxian = '')
                AND (gongxu LIKE '%' + @gongxu + '%' OR @gongxu = '')
            )
            SELECT * FROM FilteredData 
            WHERE RowNum > @skip AND RowNum <= @skip + @take
            ORDER BY RowNum";

                using (se = new schedulingEntities())
                {
                    var result = se.Database.SqlQuery<paibanbiao_renyuan>(sql, @params).ToList();
                    return result;
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
            //var @params = new SqlParameter[]{
            //    new SqlParameter("@company", company),
            //};
            //string sql = "select department_name from paibanbiao_renyuan where company=@company group by department_name ";
            using (se = new schedulingEntities())
            {
                //var result = se.Database.SqlQuery<paibanbiao_renyuan>(sql, @params);
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

        public List<department> getDepartment(String company)
        {
            var @params = new SqlParameter[] { 
                new SqlParameter("@company", company),
            };
            string sql = "select * from department where company=@company ";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<department>(sql, @params);
                return result.ToList();
            }
        }
        

        //public List<department> getDepartment(String company)
        //{
        //    string sql = "select department_name from department where company='s1' group by department_name";
        //    using (se = new schedulingEntities())
        //    {
        //        var result = se.Database.SqlQuery<department>(sql);
        //        return result.ToList();
        //    }
        //}

    }
}