using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class WorkDetailService
    {
        private static WorkDetailDao wdd = new WorkDetailDao();

        private static CommonDao cd = new CommonDao();

        private List<time_config> timeList;

        private List<holiday_config> holidayList;

        private user_info user;

        public WorkDetailService() {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        public PageUtil<WorkItem> list(int nowPage, int pageCount, string orderId)
        {
            PageUtil<WorkItem> page = new PageUtil<WorkItem>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = wdd.count(user.company);
            List<WorkItem> list = wdd.list(user.company, page.getSkip(), page.getTake(), orderId);
            if (list != null && list.Count > 0) 
            {
                page.pageList = computeWork(list);
            }
            return page;
        }

        public List<WorkItem> computeWork(List<WorkItem> list)
        {
            //最终需要返回的集合
            List<WorkItem> workItemList = new List<WorkItem>();
            //模块数据层实例
            ModuleDao moduleDao = new ModuleDao();

            int num = 0;
            //循环所有订单
            foreach (WorkItem workItem in list)
            {
                //订单开始日期
                DateTime nowDate = workItem.work_start_date;
                //总生产数量
                double lastNum = workItem.work_num;
                //订单所选模块
                List<module_info> moduleList = moduleDao.listByWorkId(workItem.id);

                //循环添加模块对应的每天生产的数量
                do
                {
                    //查找包含当前循环模块的订单实例
                    for (int i = num, j = 0; i < (moduleList.Count + num); i++)
                    {
                        try
                        {
                            workItemList[i].moduleInfo = moduleList[j];
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            workItemList.Add(new WorkItem(workItem));
                            workItemList[i].moduleInfo = moduleList[j];
                            workItemList[i].workDayList = new List<WorkDay>();
                        }

                        WorkDay workDay = new WorkDay();
                        //当天工作几小时
                        double hour = workHour(nowDate);
                        //当天生产数量
                        double workNum = hour * (double)moduleList[j].num;
                        //总生产数量减去当天生产数量
                        lastNum -= workNum;
                        //累加天
                        workDay.dateTime = nowDate;
                        //当天生产数量
                        workDay.work_num = lastNum < 0 ? workNum + lastNum < 0 ? 0 : workNum + lastNum : workNum;
                        //添加到当前循环模块的工作天集合
                        workItemList[i].workDayList.Add(workDay);

                        j++;
                    }
                    //天数加1
                    nowDate = nowDate.Date.AddDays(1);
                } while (lastNum > 0);

                num += moduleList.Count;
            }
            return workItemList;
        }

        public double workHour(DateTime startDateTime)
        {
            getHolidayList();
            if (holidayList.Find(h => h.day_or_reset.Date == startDateTime.Date) != null)
            {
                return 0;
            }
            getTimeList();

            int week = startDateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)startDateTime.DayOfWeek;
            time_config timeConfig = timeList.Find(t => t.week == week);

            DateTimeFormatInfo format = new DateTimeFormatInfo();
            format.ShortDatePattern = "HH:mm";

            TimeSpan mStart = Convert.ToDateTime(timeConfig.morning_start, format).TimeOfDay;
            TimeSpan startTime = startDateTime.TimeOfDay.Hours == 0 ? mStart : startDateTime.TimeOfDay;

            TimeSpan mEnd = Convert.ToDateTime(timeConfig.morning_end, format).TimeOfDay;
            TimeSpan mHour = mEnd <= startTime ? new TimeSpan(0, 0, 0) : mEnd - mStart;

            TimeSpan oStart = Convert.ToDateTime(timeConfig.noon_start, format).TimeOfDay;
            TimeSpan oEnd = Convert.ToDateTime(timeConfig.noon_end, format).TimeOfDay;
            TimeSpan oHour = oEnd <= startTime ? new TimeSpan(0, 0, 0) : oEnd - oStart;

            TimeSpan nStart = Convert.ToDateTime(timeConfig.night_start, format).TimeOfDay;
            TimeSpan nEnd = Convert.ToDateTime(timeConfig.night_end, format).TimeOfDay;
            TimeSpan nHour = nEnd <= startTime ? new TimeSpan(0, 0, 0) : nEnd - nStart;

            if (mHour.Hours > 24 || oHour.Hours > 24 || nHour.Hours > 24)
            {
                throw new TimeError("请检查工作时间配置是否正确");
            }
            else
            {
                TimeSpan result = new TimeSpan();
                
                if (startTime <= nEnd)
                {
                    result = nEnd - startTime;
                }
                if (startTime <= oEnd)
                {
                    result = (nEnd - nStart) + (oEnd - startTime);
                }
                if (startTime <= mEnd)
                {
                    result = (nEnd - nStart) + (oEnd - oStart) + (mEnd - startTime);
                }

                return result.TotalHours;
            }
        }

        public void getTimeList()
        {
            if (timeList == null)
            {
                TimeConfigDao timeConfigDao = new TimeConfigDao();
                timeList = timeConfigDao.list(user.company);
            }
        }

        public void getHolidayList()
        {
            if (holidayList == null)
            {
                HolidayDao holidayDao = new HolidayDao();
                holidayList = holidayDao.list(user.company);
            }
        }

        /// <summary>
        /// 新增排产明细
        /// </summary>
        /// <param name="workDetail">排产明细</param>
        /// <param name="workModuleList">排产物料集合</param>
        /// <returns></returns>
        public Boolean save(work_detail workDetail, List<int> workModuleIdList)
        {
            workDetail.company = user.company;
            workDetail = cd.save<work_detail>(workDetail);
            if (workDetail == null) return false;

            //如果不是插单，填充row_num
            if (workDetail.is_insert == 0) {
                workDetail.row_num = workDetail.id + 1;
                if (!cd.update<work_detail>(workDetail)) return false;
            }

            foreach (int workModuleId in workModuleIdList)
            {
                work_module workModule = new work_module();
                workModule.module_id = workModuleId;
                workModule.work_id = workDetail.id;
                if (cd.save<work_module>(workModule) == null) return false;
            }
            return true;
        }

        public Boolean deleteWork(int rowNum)
        {

            //return wdd.deleteWork<work_detail>(rowNum);
            return wdd.deleteWork(rowNum);
        }

    }
}