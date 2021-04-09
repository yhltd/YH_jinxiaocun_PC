using System;
using System.Collections.Generic;
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
    }
}