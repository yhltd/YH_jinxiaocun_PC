using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class TimeConfigDao
    {
        private schedulingEntities se;

        public List<time_config> list(string company) 
        {
            using (se = new schedulingEntities())
            {
                var result = from t in se.time_config where t.company == company select t;
                return result.ToList();
            }
        }
    }
}