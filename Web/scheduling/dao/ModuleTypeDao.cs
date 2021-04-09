using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class ModuleTypeDao
    {
        private schedulingEntities se;

        public List<module_type> list(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = from m in se.module_type where m.company == company select m;
                return result.ToList();
            }
        }
    }
}