using SDZdb;
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

        public PageUtil<WorkItem> list(int nowPage, int pageCount, string orderId,string type)
        {
            PageUtil<WorkItem> page = new PageUtil<WorkItem>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = wdd.count(user.company);
            List<WorkItem> list = wdd.list(user.company, page.getSkip(), page.getTake(), orderId);
            if (list != null && list.Count > 0) 
            {
                if (type.Equals("排产1")) 
                {
                    page.pageList = paichan(list, orderId);
                }
                else if (type.Equals("排产2")) 
                {
                    page.pageList = paichan2(list, orderId);
                }
                
            }
            return page;
        }

        public Boolean channeng1(List<int> workModuleIdList, DateTime ks, DateTime js, double scsl, string is_insert,string type)
        {
            List<WorkItem> list = wdd.list(user.company, 0, 1000, "");
            if (list != null && list.Count > 0 && type.Equals("产能1"))
            {
                return getChanneng1(list, workModuleIdList, ks, js, scsl, is_insert);
            }
            else if (list != null && list.Count > 0 && type.Equals("产能2"))
            {
                return getChanneng2(list, workModuleIdList, ks, js, scsl, is_insert);
            }
            else 
            {
                return false;
            }
        }

        public List<WorkItem> paichan(List<WorkItem> list,string orderId)
        {
            //最终需要返回的集合
            List<WorkItem> workItemList = new List<WorkItem>();
            //模块最后的开始时间
            List<paichan_modoule_time> pmtList = new List<paichan_modoule_time>();
            //模块数据层实例
            ModuleDao moduleDao = new ModuleDao();
            int num = 0;
            //模块变量
            int mokuai = 0;

            int bianliang = 0;
            //循环所有订单
            foreach (WorkItem workItem in list)
            {
                //订单开始日期
                DateTime nowDate= list[0].work_start_date;
                //总生产数量
                double lastNum = workItem.work_num;
                //所需生产小时
                double xiaoshi = 0;
                //订单所选模块
                List<module_info> moduleList = moduleDao.listByWorkId(workItem.id);
                //订单所有模块效率合计
                double xiaolv = 0;
                //循环添加模块并计算效率
                for (int i = 0; i < moduleList.Count; i++)
                {
                    workItemList.Add(new WorkItem(workItem));
                    workItemList[mokuai].moduleInfo = moduleList[i];
                    workItemList[mokuai].workDayList = new List<WorkDay>();
                    xiaolv = xiaolv + Convert.ToDouble(moduleList[i].num);
                    mokuai = mokuai + 1;
                }
                if (xiaolv != 0)
                {
                    xiaoshi = lastNum / xiaolv;
                }
                else
                {
                    xiaoshi = 0;
                }

                //取当前订单模块的最后日期，如果没有就取开始时间
                
                for (int i = 0; i < moduleList.Count; i++)
                {
                    bool pd = false;
                    double shichang = xiaoshi;
                    double shijianbianliang = 0;
                    DateTime ks = nowDate;
                    for (int j = 0; j < pmtList.Count; j++) 
                    {
                        if (moduleList[i].id == pmtList[j].modoule_id) 
                        {
                            ks = pmtList[j].riqi;
                            int dowhile = 0;
                            do
                            {
                                //循环计算每天时长
                                WorkDay workDay = new WorkDay();
                                //当天工作几小时
                                double hour = workHour(ks);
                                if (dowhile == 0)
                                {
                                    hour = pmtList[j].time;
                                    dowhile = dowhile + 1;
                                }
                                //当天生产数量
                                if (shichang >= hour)
                                {
                                    workDay.work_num = hour * Convert.ToDouble(moduleList[i].num);
                                    shichang = shichang - hour;
                                }
                                else
                                {
                                    workDay.work_num = shichang * Convert.ToDouble(moduleList[i].num);
                                    shijianbianliang = hour - shichang;
                                    shichang = 0;
                                }
                                //累加天
                                workDay.dateTime = ks;
                                //添加到当前循环模块的工作天集合
                                workItemList[bianliang].workDayList.Add(workDay);
                                //天数加1
                                ks = ks.Date.AddDays(1);
                            } while (shichang > 0);
                            bianliang++;
                            ks = ks.Date.AddDays(-1);
                            pmtList[j].riqi = ks;
                            pmtList[j].time = shijianbianliang;
                            pd = true;
                        }   
                    }
                    if (pd == false) 
                    {
                        do
                        {
                            //循环计算每天时长
                            WorkDay workDay = new WorkDay();
                            //当天工作几小时
                            double hour = workHour(ks);
                            
                            //当天生产数量
                            if (shichang >= hour)
                            {
                                workDay.work_num = hour * Convert.ToDouble(moduleList[i].num);
                                shichang = shichang - hour;
                            }
                            else 
                            {
                                workDay.work_num = shichang * Convert.ToDouble(moduleList[i].num);
                                shijianbianliang = hour - shichang;
                                shichang = 0;
                            }
                            //累加天
                            workDay.dateTime = ks;
                            //添加到当前循环模块的工作天集合
                            workItemList[bianliang].workDayList.Add(workDay);
                            //天数加1
                            ks = ks.Date.AddDays(1);
                        } while (shichang > 0);
                        bianliang++;
                        paichan_modoule_time pmt = new paichan_modoule_time();
                        pmt.modoule_id = moduleList[i].id;
                        ks = ks.Date.AddDays(-1);
                        pmt.riqi = ks;
                        pmt.time = shijianbianliang;
                        pmtList.Add(pmt);
                    }
                }
            }
            if (!orderId.Equals(""))
            {
                List<WorkItem> workItemListById = new List<WorkItem>();
                for (int i = 0; i < workItemList.Count; i++)
                {
                    if (workItemList[i].orderId.Contains(orderId)) 
                    {
                        workItemListById.Add(workItemList[i]);
                    }
                }
                return workItemListById;
            }
            else 
            {
                return workItemList;
            }
        }

        public List<WorkItem> paichan2(List<WorkItem> list, string orderId)
        {
            //最终需要返回的集合
            List<WorkItem> workItemList = new List<WorkItem>();
            //模块数据层实例
            ModuleDao moduleDao = new ModuleDao();
            //模块最后的开始时间
            List<paichan_modoule_time> pmtList = new List<paichan_modoule_time>();



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
                    int zuihou = 0;
                    //bool pd = false;
                    DateTime ks = nowDate;
                    for (int i = num, j = 0; i < (moduleList.Count + num); i++)
                    {
                        bool pd = false;
                        double time = 0;
                        for (int k = 0; k < pmtList.Count; k++) 
                        {
                            if (moduleList[j].id == pmtList[k].modoule_id) 
                            {
                                pd = true;
                                zuihou = k;
                                if (ks == pmtList[k].riqi)
                                {
                                    ks = pmtList[k].riqi;
                                    time = pmtList[k].time;
                                }
                                else if (ks < pmtList[k].riqi)
                                {
                                    time = workHour(ks);
                                }
                            }
                        }
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
                        //当天可工作几小时
                        double hour = workHour(ks);
                        hour = hour - time;
                        //全部生产需要多少小时
                        double shengchan = lastNum / (double)moduleList[j].num;
                        double workNum = 0;
                        if (shengchan >= hour)
                        {
                            //当天生产数量
                            workNum = hour * (double)moduleList[j].num;
                            //总生产数量减去当天生产数量
                            lastNum -= workNum;
                            time = hour;
                        }
                        else 
                        {
                            //当天生产数量
                            workNum = shengchan * (double)moduleList[j].num;
                            //总生产数量减去当天生产数量
                            lastNum = 0;
                            time = shengchan;
                        }
                        //累加天
                        workDay.dateTime = ks;
                        //当天生产数量
                        workDay.work_num = lastNum < 0 ? workNum + lastNum < 0 ? 0 : workNum + lastNum : workNum;
                        if (workNum != 0) 
                        {
                            //添加到当前循环模块的工作天集合
                            workItemList[i].workDayList.Add(workDay);
                        }
                        j++;

                        if (pd && workNum!=0)
                        {
                            pmtList[zuihou].riqi = ks;
                            pmtList[zuihou].time = time;
                            pd = false;
                        }
                        else if(!pd && workNum!=0)
                        {
                            paichan_modoule_time pmt = new paichan_modoule_time();
                            pmt.modoule_id = moduleList[j-1].id;
                            pmt.riqi = ks;
                            pmt.time = time;
                            pmtList.Add(pmt);
                        }
                    }
                    //天数加1
                    nowDate = nowDate.Date.AddDays(1);
                } while (lastNum > 0);
                num += moduleList.Count;
            }
            return workItemList;
        }

        public Boolean getChanneng2(List<WorkItem> list, List<int> workModuleIdList, DateTime ks1, DateTime js1, double scsl, string is_insert)
        {
            bool is_changneng = true;
            try
            {
                //最终需要返回的集合
                List<WorkItem> workItemList = new List<WorkItem>();
                //模块最后的开始时间
                List<paichan_modoule_time> pmtList = new List<paichan_modoule_time>();
                //模块数据层实例
                ModuleDao moduleDao = new ModuleDao();
                int num = 0;
                //模块变量
                int mokuai = 0;

                int bianliang = 0;
                //循环所有订单
                foreach (WorkItem workItem in list)
                {
                    //订单开始日期
                    DateTime nowDate = list[0].work_start_date;
                    //总生产数量
                    double lastNum = workItem.work_num;
                    //所需生产小时
                    double xiaoshi = 0;
                    //订单所选模块
                    List<module_info> moduleList = moduleDao.listByWorkId(workItem.id);
                    //订单所有模块效率合计
                    double xiaolv = 0;
                    //循环添加模块并计算效率
                    for (int i = 0; i < moduleList.Count; i++)
                    {
                        workItemList.Add(new WorkItem(workItem));
                        workItemList[mokuai].moduleInfo = moduleList[i];
                        workItemList[mokuai].workDayList = new List<WorkDay>();
                        xiaolv = xiaolv + Convert.ToDouble(moduleList[i].num);
                        mokuai = mokuai + 1;
                    }
                    if (xiaolv != 0)
                    {
                        xiaoshi = lastNum / xiaolv;
                    }
                    else
                    {
                        xiaoshi = 0;
                    }

                    //取当前订单模块的最后日期，如果没有就取开始时间

                    for (int i = 0; i < moduleList.Count; i++)
                    {
                        bool pd = false;
                        double shichang = xiaoshi;
                        double shijianbianliang = 0;
                        DateTime ks = nowDate;
                        for (int j = 0; j < pmtList.Count; j++)
                        {
                            if (moduleList[i].id == pmtList[j].modoule_id)
                            {
                                ks = pmtList[j].riqi;
                                int dowhile = 0;
                                do
                                {
                                    //循环计算每天时长
                                    WorkDay workDay = new WorkDay();
                                    //当天工作几小时
                                    double hour = workHour(ks);
                                    if (dowhile == 0)
                                    {
                                        hour = pmtList[j].time;
                                        dowhile = dowhile + 1;
                                    }
                                    //当天生产数量
                                    if (shichang >= hour)
                                    {
                                        workDay.work_num = hour * Convert.ToDouble(moduleList[i].num);
                                        shichang = shichang - hour;
                                    }
                                    else
                                    {
                                        workDay.work_num = shichang * Convert.ToDouble(moduleList[i].num);
                                        shijianbianliang = hour - shichang;
                                        shichang = 0;
                                    }
                                    //累加天
                                    workDay.dateTime = ks;
                                    //添加到当前循环模块的工作天集合
                                    workItemList[bianliang].workDayList.Add(workDay);
                                    //天数加1
                                    ks = ks.Date.AddDays(1);
                                } while (shichang > 0);
                                bianliang++;
                                ks = ks.Date.AddDays(-1);
                                pmtList[j].riqi = ks;
                                pmtList[j].time = shijianbianliang;
                                pd = true;
                            }
                        }
                        if (pd == false)
                        {
                            do
                            {
                                //循环计算每天时长
                                WorkDay workDay = new WorkDay();
                                //当天工作几小时
                                double hour = workHour(ks);

                                //当天生产数量
                                if (shichang >= hour)
                                {
                                    workDay.work_num = hour * Convert.ToDouble(moduleList[i].num);
                                    shichang = shichang - hour;
                                }
                                else
                                {
                                    workDay.work_num = shichang * Convert.ToDouble(moduleList[i].num);
                                    shijianbianliang = hour - shichang;
                                    shichang = 0;
                                }
                                //累加天
                                workDay.dateTime = ks;
                                //添加到当前循环模块的工作天集合
                                workItemList[bianliang].workDayList.Add(workDay);
                                //天数加1
                                ks = ks.Date.AddDays(1);
                            } while (shichang > 0);
                            bianliang++;
                            paichan_modoule_time pmt = new paichan_modoule_time();
                            pmt.modoule_id = moduleList[i].id;
                            ks = ks.Date.AddDays(-1);
                            pmt.riqi = ks;
                            pmt.time = shijianbianliang;
                            pmtList.Add(pmt);
                        }
                    }
                }

                double cn = 0;

                for (int i = 0; i < workModuleIdList.Count; i++)
                {
                    List<module_info> moduleList = moduleDao.listById(workModuleIdList[i]);
                    cn = cn + Convert.ToDouble(moduleList[0].num);
                }
                cn = scsl / cn;
                if (is_insert.Equals("1")) 
                {
                    for (int i = 0; i < workModuleIdList.Count; i++)
                    {
                        bool pd = false;
                        int a = 0;
                        double xiaoshi = cn;
                        DateTime riqi = ks1;
                        do
                        {
                            //当天工作几小时
                            double hour = workHour(riqi);
                            if (hour >= xiaoshi)
                            {
                                xiaoshi = 0;
                            }
                            else
                            {
                                xiaoshi = xiaoshi - hour;
                            }
                            riqi = riqi.AddDays(1);
                        } while (xiaoshi > 0);
                        riqi = riqi.AddDays(-1);
                        if (riqi > js1)
                        {
                            is_changneng = false;
                        }
                    }
                } 
                else
                {
                    for (int i = 0; i < workModuleIdList.Count; i++)
                    {
                        bool pd = false;
                        int a = 0;
                        for (int j = 0; j < pmtList.Count; j++)
                        {
                            if (workModuleIdList[i] == pmtList[j].modoule_id && pmtList[j].riqi >= ks1)
                            {
                                double xiaoshi = cn;
                                DateTime riqi = pmtList[j].riqi;
                                if (pmtList[j].riqi > js1)
                                {
                                    is_changneng = false;
                                }
                                else
                                {
                                    do
                                    {
                                        //当天工作几小时
                                        double hour = workHour(riqi);
                                        if (a == 0)
                                        {
                                            hour = hour - pmtList[j].time;
                                            a++;
                                        }
                                        if (hour >= xiaoshi)
                                        {
                                            xiaoshi = 0;
                                        }
                                        else
                                        {
                                            xiaoshi = xiaoshi - hour;
                                        }
                                        riqi = riqi.AddDays(1);
                                    } while (xiaoshi > 0);
                                    a = 0;
                                    riqi = riqi.AddDays(-1);
                                    if (riqi > js1)
                                    {
                                        is_changneng = false;
                                    }
                                }
                            }
                            else if (workModuleIdList[i] == pmtList[j].modoule_id && pmtList[j].riqi < ks1)
                            {
                                double xiaoshi = cn;
                                DateTime riqi = ks1;
                                do
                                {
                                    //当天工作几小时
                                    double hour = workHour(riqi);
                                    if (hour >= xiaoshi)
                                    {
                                        xiaoshi = 0;
                                    }
                                    else
                                    {
                                        xiaoshi = xiaoshi - hour;
                                    }
                                    riqi = riqi.AddDays(1);
                                } while (xiaoshi > 0);
                                riqi = riqi.AddDays(-1);
                                if (riqi > js1)
                                {
                                    is_changneng = false;
                                }
                            }
                            pd = true;
                        }
                        if (pd == false)
                        {
                            double xiaoshi = cn;
                            DateTime riqi = ks1;
                            do
                            {
                                //当天工作几小时
                                double hour = workHour(riqi);
                                if (hour >= xiaoshi)
                                {
                                    xiaoshi = 0;
                                }
                                else
                                {
                                    xiaoshi = xiaoshi - hour;
                                }
                                riqi = riqi.AddDays(1);
                            } while (xiaoshi > 0);
                            riqi = riqi.AddDays(-1);
                            if (riqi > js1)
                            {
                                is_changneng = false;
                            }
                        }
                    }
                }
                return is_changneng;
            }
            catch 
            {
                is_changneng = false;
                return is_changneng;
            }
            
        }
        public Boolean getChanneng1(List<WorkItem> list, List<int> workModuleIdList, DateTime ks1, DateTime js1, double scsl, string is_insert)
        {

            //最终需要返回的集合
            List<WorkItem> workItemList = new List<WorkItem>();
            //模块数据层实例
            ModuleDao moduleDao = new ModuleDao();
            //模块最后的开始时间
            List<paichan_modoule_time> pmtList = new List<paichan_modoule_time>();
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
                    int zuihou = 0;
                    bool pd = false;
                    DateTime ks = nowDate;
                    for (int i = num, j = 0; i < (moduleList.Count + num); i++)
                    {
                        double time = 0;
                        for (int k = 0; k < pmtList.Count; k++)
                        {
                            if (moduleList[j].id == pmtList[k].modoule_id)
                            {
                                pd = true;
                                zuihou = k;
                                if (ks == pmtList[k].riqi)
                                {
                                    ks = pmtList[k].riqi;
                                    time = pmtList[k].time;
                                }
                                else if (ks < pmtList[k].riqi)
                                {
                                    time = workHour(ks);
                                }
                            }
                        }
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
                        //当天可工作几小时
                        double hour = workHour(ks);
                        hour = hour - time;
                        //全部生产需要多少小时
                        double shengchan = lastNum / (double)moduleList[j].num;
                        double workNum = 0;
                        if (shengchan >= hour)
                        {
                            //当天生产数量
                            workNum = hour * (double)moduleList[j].num;
                            //总生产数量减去当天生产数量
                            lastNum -= workNum;
                            time = hour;
                        }
                        else
                        {
                            //当天生产数量
                            workNum = shengchan * (double)moduleList[j].num;
                            //总生产数量减去当天生产数量
                            lastNum = 0;
                            time = shengchan;
                        }
                        //累加天
                        workDay.dateTime = ks;
                        //当天生产数量
                        workDay.work_num = lastNum < 0 ? workNum + lastNum < 0 ? 0 : workNum + lastNum : workNum;
                        if (workNum != 0)
                        {
                            //添加到当前循环模块的工作天集合
                            workItemList[i].workDayList.Add(workDay);
                        }
                        j++;

                        if (pd && workNum != 0)
                        {
                            pmtList[zuihou].riqi = ks;
                            pmtList[zuihou].time = time;
                            pd = false;
                        }
                        else if (!pd && workNum != 0)
                        {
                            paichan_modoule_time pmt = new paichan_modoule_time();
                            pmt.modoule_id = moduleList[j - 1].id;
                            pmt.riqi = ks;
                            pmt.time = time;
                            pmtList.Add(pmt);
                        }
                    }
                    //天数加1
                    nowDate = nowDate.Date.AddDays(1);
                } while (lastNum > 0);
                num += moduleList.Count;
            }

            List<paichan_modoule_time> pmtList2 = new List<paichan_modoule_time>();
            double shuliang =scsl;
            for (int i = 0; i < workModuleIdList.Count; i++)
            {
                List<module_info> moduleList = moduleDao.listById(workModuleIdList[i]);
                if (!is_insert.Equals("1"))
                {
                    for (int j = 0; j < pmtList.Count; j++)
                    {
                        if (moduleList[0].id == pmtList[j].modoule_id && pmtList[j].riqi >= ks1)
                        {
                            paichan_modoule_time pmt = new paichan_modoule_time();
                            pmt.riqi = pmtList[j].riqi;
                            pmt.time = pmtList[j].time;
                            pmt.modoule_id = moduleList[0].id;
                            pmt.num = Convert.ToDouble(moduleList[0].num);
                            pmtList2.Add(pmt);
                        }
                    }
                }
                else 
                {
                    paichan_modoule_time pmt = new paichan_modoule_time();
                    pmt.riqi = ks1;
                    pmt.time = 0;
                    pmt.modoule_id = moduleList[0].id;
                    pmt.num = Convert.ToDouble(moduleList[0].num);
                    pmtList2.Add(pmt);
                } 
            }

            do
            {
                for (int i = 0; i < pmtList2.Count; i++)
                {
                    if (ks1 >= pmtList2[i].riqi) 
                    {
                        //当天可工作几小时
                        double hour = workHour(ks1);
                        hour = hour - pmtList2[i].time;
                        pmtList2[i].time = 0;
                        //全部生产需要多少小时
                        double shengchan = shuliang / pmtList2[i].num;
                        double workNum = 0;
                        if (shengchan >= hour)
                        {
                            //当天生产数量
                            workNum = hour * pmtList2[i].num;
                            //总生产数量减去当天生产数量
                            shuliang -= workNum;
                        }
                        else
                        {
                            //当天生产数量
                            workNum = shengchan * pmtList2[i].num;
                            //总生产数量减去当天生产数量
                            shuliang = 0;
                        }
                    }
                }
                ks1 = ks1.AddDays(1);
            } while (shuliang > 0);

            if (ks1.AddDays(-1) <= js1)
            {
                return true;
            }
            else 
            {
                return false;
            }
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

        //批量添加
        public Boolean plSave(List<work_detail> plList, List<int> workModuleIdList)
        {
            //List<work_detail> plList
            for (int i = 0; i < plList.Count; i++) 
            {
                plList[i].company = user.company;
                work_detail workDetail = new work_detail();
                workDetail = cd.save<work_detail>(plList[i]);
                if (workDetail == null) return false;
                //如果不是插单，填充row_num
                if (workDetail.is_insert == 0)
                {
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
            }
            return true;
        }

        public Boolean deleteWork(string rowNum)
        {

            //return wdd.deleteWork<work_detail>(rowNum);
            return wdd.deleteWork(rowNum, user.company);
        }

        
    }
}