using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class HolidayService
    {
        private static HolidayDao hd = new HolidayDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public HolidayService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">分页工具类</param>
        /// <returns></returns>
        public PageUtil<holiday_config> page(PageUtil<holiday_config> page)
        {
            page.total = hd.count(user.company);
            page.pageList = hd.list(user.company, page.getSkip(), page.getTake());
            return page;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="holidayConfig"></param>
        /// <returns></returns>
        public Boolean save(string holiday) {
            holiday_config holidayConfig = new holiday_config();
            holidayConfig.day_or_reset = DateTime.ParseExact(holiday, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture); 
            holidayConfig.company = user.company;
            return cd.save<holiday_config>(holidayConfig) != null;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id) {
            return cd.delete<holiday_config>(id);
        }
    }
}