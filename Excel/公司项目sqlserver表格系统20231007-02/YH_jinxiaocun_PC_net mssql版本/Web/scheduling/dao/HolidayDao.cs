using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class HolidayDao
    {

        private schedulingEntities se;

        /// <summary>
        /// 查询所有休息日
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<holiday_config> list(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.holiday_config.Where(h => h.company == company);
                return result.ToList();
            }
        }
        
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="skip">跳过行数</param>
        /// <param name="take">查询行数</param>
        /// <returns></returns>
        public List<holiday_config> list(string company, int skip, int take)
        {
            using (se = new schedulingEntities())
            {
                var result = se.holiday_config.Where(h => h.company == company).OrderBy(h => h.day_or_reset).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        /// <summary>
        /// 总行数
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public int count(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.holiday_config.Count();
                return (int)result;
            }
        }
    }
}