using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class UserInfoDao
    {
        private schedulingEntities se;

        public List<user_info> list() 
        {
            using (se = new schedulingEntities())
            {
                var result = from u in se.user_info select u;
                return result.ToList();
            }
        }

        public List<user_info> list(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = from u in se.user_info where u.company == company select u;
                return result.ToList();
            }
        }

        public List<user_info> list(string userCode, string password, string company)
        {
            using (se = new schedulingEntities())
            {
                var result = from u in se.user_info where u.user_code == userCode && u.password == password && u.company == company select u;
                return result.ToList();
            }
        }



        public List<user_info> getlist(int skip,int take,string company,string user_code)
        {
            var @params = new SqlParameter[] { 
                new SqlParameter("@company", company),
                new SqlParameter("@user_code", user_code),
            };
            string sql = "select * from user_info where company=@company and user_code like '%' + @user_code + '%'";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<user_info>(sql, @params);
                return result.ToList();
            }
        }

        public List<user_info> getUserNum(string company)
        {
            var @params = new SqlParameter[] { 
                new SqlParameter("@company", company),
            };
            string sql = "select count(id) as id,'' as user_code,'' as password,'' as company,'' as department_name,'' as state from user_info where company='" + company + "'";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<user_info>(sql, @params);
                return result.ToList();
            }
        }

        public int Count()
        {
            using (se = new schedulingEntities())
            {
                var result = se.user_info.Count();
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



    }
}