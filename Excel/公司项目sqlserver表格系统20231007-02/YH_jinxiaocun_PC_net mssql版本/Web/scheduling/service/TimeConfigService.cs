using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class TimeConfigService
    {
        private static TimeConfigDao tcdo = new TimeConfigDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public TimeConfigService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 全部查询
        /// </summary>
        /// <returns></returns>
        public List<time_config> list() {
            return tcdo.list(user.company);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="timeConfig"></param>
        /// <returns></returns>
        public time_config save(time_config timeConfig) {
            timeConfig.company = user.company;
            return cd.save<time_config>(checkTime(timeConfig));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id) {
            return cd.delete<time_config>(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="timeConfig"></param>
        /// <returns></returns>
        public Boolean update(time_config timeConfig) {
            return cd.update<time_config>(checkTime(timeConfig));
        }

        /// <summary>
        /// 检查时间配置信息，为空改为null
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public time_config checkTime(time_config time)
        { 
            time.morning_start = time.morning_start.Equals(string.Empty) ? null : time.morning_start;
            time.morning_end = time.morning_end.Equals(string.Empty) ? null : time.morning_end;
            time.noon_start = time.noon_start.Equals(string.Empty) ? null : time.noon_start;
            time.noon_end = time.noon_end.Equals(string.Empty) ? null : time.noon_end;
            time.night_start = time.night_start.Equals(string.Empty) ? null : time.night_start;
            time.night_end = time.night_end.Equals(string.Empty) ? null : time.night_end;
            return time;
        }
    }
}