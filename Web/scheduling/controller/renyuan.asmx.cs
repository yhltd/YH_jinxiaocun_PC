using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Web.scheduling.model;
using Web.scheduling.service;
using Web.scheduling.utils;

namespace Web.scheduling.controller
{
    /// <summary>
    /// Summary description for renyuan
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class renyuan : System.Web.Services.WebService
    {
        private UserInfoService us;

        private RenyuanService rs;

        private PaiBanDetailService pbds;

        //private int lunhuanjiangetianshu = 0;


        [WebMethod]
        public string getDepartment()
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "人员信息");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                rs = new RenyuanService();
                return ResultUtil.success(rs.getDepartment(), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("查询失败");
            }
        }


        [WebMethod]
        public string getList(int nowPage, int pageCount,string staff_name,string staff_banci)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("sel", "人员信息");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                rs = new RenyuanService();
                return ResultUtil.success(rs.list(nowPage, pageCount,staff_name,staff_banci), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string add(paibanbiao_renyuan renyuanList)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "人员信息");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {

                    return ResultUtil.error("没有权限！");
                }

                rs = new RenyuanService();
                if (rs.add(renyuanList))
                {
                    return ResultUtil.success("保存成功");
                }
                else
                {
                    return ResultUtil.error("保存失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string delete(int id)
        {
            {
                try
                {
                    us = new UserInfoService();
                    string quanxian_save1 = us.new_quanxian("del", "人员信息");
                    if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                    {
                    }
                    else
                    {
                        return ResultUtil.error("没有权限！");
                    }

                    rs = new RenyuanService();
                    if (rs.delete(id))
                    {
                        return ResultUtil.success("删除成功");
                    }
                    else
                    {
                        return ResultUtil.error("删除失败");
                    }
                }
                catch (ErrorUtil err)
                {
                    return ResultUtil.fail(401, err.Message);
                }
                catch
                {
                    return ResultUtil.error("删除失败");
                }
            }
        }

        [WebMethod]
        public string update(paibanbiao_renyuan renyuanList)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("upd", "人员信息");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                rs = new RenyuanService();
                if (rs.update(renyuanList))
                {
                    return ResultUtil.success("修改成功");
                }
                else
                {
                    return ResultUtil.error("修改失败");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch
            {
                return ResultUtil.error("修改失败");
            }
        }

        [WebMethod]
        public string getAllList()
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "排班");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }

                rs = new RenyuanService();
                return ResultUtil.success(rs.getAllList(), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string getAllListByDept(String department_name)
        {
            try
            {
                rs = new RenyuanService();
                return ResultUtil.success(rs.getAllList(department_name), "查询成功");
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("查询失败");
            }
        }

        [WebMethod]
        public string getPaibanList(paibanbiao_info paibanbiaoInfo, List<paibanbiao_renyuan> renyuan, DateTime startDate, DateTime endDate, int banci, int meizu_part, int lunhuanjiangetianshu)
        {
            try
            {
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "排班");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }


                List<paibanbiao_renyuan> renyuan_wordplan = new List<paibanbiao_renyuan>();

                //获取时间轴
                //指定某一日期
                string datetime = "2013-5-13";
                datetime = DateTime.Now.ToString("yyyy-MM-dd");

                //MessageBox.Show(((DateTime.Parse(datetime).DayOfWeek)).ToString());//返回值是英文的星期枚举
                //System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);//转化为中文的星期，要判断的日期是今天
                string nowwenk = (((int)DateTime.Parse(datetime).DayOfWeek).ToString());

                string nextmou = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(1).ToString("yyyy-MM-dd");
                //  2021-6-26
                DateTime dt3;
                //dt3 = Convert.ToDateTime(datetime);
                dt3 = Convert.ToDateTime(startDate);
                DateTime dt2;
                //dt2 = Convert.ToDateTime(nextmou);
                dt2 = Convert.ToDateTime(endDate);
                TimeSpan ts = dt2 - dt3;
                int reday = ts.Days;
                if (reday < 0)
                {
                }
                // int reday = Convert.ToInt32(nextmou.Replace("-", "").Replace("/", "")) - Convert.ToInt32(datetime.Replace("-", "").Replace("/", ""));
                //汉字星期几
                string weeki = "";
                string startDate_weeki = "";
                bool isrunnew_week1 = true;

                DateTime dtnextday;
                dtnextday = DateTime.Now;
                //临时
                //dtnextday = Convert.ToDateTime("2021-05-24");
                dtnextday = Convert.ToDateTime(startDate);
                String paibanbiao_id = DateTime.Now.ToString("yyyyMMddss");
                int index_xunhuanday28 = 0;
                string diyicijieyu = "";


                //班次
                //int banci=2;
                //每组人员分半或者几半为周末加班用
                //int meizu_part = 2;
                //都上白班  ，两天或者几天1轮换
                //int lunhuanjiangetianshu = 2;//用变量
                bool isnext_banci = false;
                int dangqianpaidaorenci = 0;
                int xunhuanjitian = 0;
                int forindex = 0;
                bool isnew_time = false;
                int bencijialejigeren = 0;
                startDate_weeki = (((int)DateTime.Parse(startDate.ToString("yyyy-MM-dd")).DayOfWeek).ToString());
                if (startDate_weeki == "0")
                {
                    startDate_weeki = "7";
                }
                GetWeekCHA(nowwenk);
                int diwuzhouxunhuan = 0;
                for (int i = 0; i <= reday; i++)
                {
                    int indexi = 0;
                    weeki = (((int)DateTime.Parse(dtnextday.ToString("yyyy-MM-dd")).DayOfWeek).ToString());
                    nowwenk = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1).ToString("yyyy-MM-dd");
                    xunhuanjitian++;
                    if (lunhuanjiangetianshu > 0)//如果先择轮换天数大于1天情况
                    {
                        //if (isnext_banci == false)
                        {
                            int exitfor = 0;
                            foreach (paibanbiao_renyuan item in renyuan)
                            {
                                paibanbiao_renyuan temp = new paibanbiao_renyuan();
                                #region 初始化值
                                temp.b = item.b;
                                temp.banci = item.banci;
                                temp.c = item.c;
                                temp.company = item.company;
                                temp.d = item.d;
                                temp.department_name = item.department_name;
                                temp.e = paibanbiao_id;
                                temp.f = item.f;
                                temp.g = item.g;
                                temp.h = item.h;
                                temp.i = item.i;
                                temp.id = item.id;
                                temp.id_number = item.id_number;
                                temp.j = item.j;
                                temp.k = item.k;
                                temp.l = item.l;
                                temp.m = item.m;
                                temp.n = item.n;
                                temp.phone_number = item.phone_number;
                                temp.staff_name = item.staff_name;
                                temp.c = item.staff_name;
                                temp.d = i.ToString();
                                temp.c = dtnextday.ToString("yyyy-MM-dd");
                                temp.b = "无";
                                #endregion
                                //if (dangqianpaidaorenci < (renyuan.Count / banci))
                                if (forindex == 0)
                                {
                                    if (dangqianpaidaorenci < (renyuan.Count / banci) || (isnew_time == true &&  exitfor < dangqianpaidaorenci))
                                    {
                                        temp = diyizhou_panban_lunhuanzhi(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu, dangqianpaidaorenci);
                                        if (isnew_time == false)
                                        {
                                            dangqianpaidaorenci++;
                                            bencijialejigeren++;
                                        }
                                    }
                                    exitfor++;
                                    if ((isnew_time == false && dangqianpaidaorenci == (renyuan.Count / banci)) || exitfor == (renyuan.Count / banci))
                                    {
                                        if (renyuan.Count == exitfor)
                                            isnew_time = true;
                                        //isnew_time = true;
                                        indexi++;
                                        renyuan_wordplan.Add(temp);
                                        //  break;
                                        continue;
                                    }                                   
                                }
                                //if (dangqianpaidaorenci >= (renyuan.Count / banci) && dangqianpaidaorenci < (renyuan.Count / banci * 2))
                                if (forindex == 1)
                                {
                                    if (dangqianpaidaorenci <= exitfor || (isnew_time == true && dangqianpaidaorenci - bencijialejigeren <= exitfor))
                                    {
                                        temp = diyizhou_panban_lunhuanzhi(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu, dangqianpaidaorenci);

                                        if (isnew_time == false)
                                        {
                                            dangqianpaidaorenci++;
                                            bencijialejigeren++;
                                        }
                                    }
                                    exitfor++;
                                    if ((isnew_time == false && dangqianpaidaorenci == (renyuan.Count / banci * 2)) || exitfor == (renyuan.Count / banci * 2))
                                    {
                                        isnew_time = true;
                                        indexi++;
                                        renyuan_wordplan.Add(temp);
                                        break;
                                    }
                                }
                                //if (dangqianpaidaorenci >= (renyuan.Count / banci * 2) && dangqianpaidaorenci < (renyuan.Count / banci * 3))
                                if (forindex == 2)
                                {
                                    if (dangqianpaidaorenci <= exitfor || (isnew_time == true && dangqianpaidaorenci - bencijialejigeren <= exitfor))
                                    {
                                        temp = diyizhou_panban_lunhuanzhi(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu, dangqianpaidaorenci);

                                        if (isnew_time == false)
                                        {
                                            dangqianpaidaorenci++;
                                            bencijialejigeren++;
                                        }
                                    }
                                    exitfor++;
                                    if ((isnew_time == false && dangqianpaidaorenci == (renyuan.Count / banci * 3)) || exitfor == (renyuan.Count / banci * 3))
                                    {
                                        isnew_time = true;
                                        indexi++;
                                        renyuan_wordplan.Add(temp);
                                        break;
                                    }
                                }
                                indexi++;
                                renyuan_wordplan.Add(temp);
                            }
                            if (xunhuanjitian == lunhuanjiangetianshu)
                            {
                                isnew_time = false;
                                isnext_banci = true;
                                forindex++;
                                bencijialejigeren = 0;
                                xunhuanjitian = 0;
                                if (dangqianpaidaorenci == renyuan.Count)//如果本轮人数循环完毕则循环下一个周期重新当第一天排班
                                {
                                    dangqianpaidaorenci = 0;
                                    forindex = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        //if (i % 28 == 0)
                        //{
                        //    index_xunhuanday28 = 0;
                        //}                     
                        foreach (paibanbiao_renyuan item in renyuan)
                        {
                            paibanbiao_renyuan temp = new paibanbiao_renyuan();
                            #region 初始化值
                            temp.b = item.b;
                            temp.banci = item.banci;
                            temp.c = item.c;
                            temp.company = item.company;
                            temp.d = item.d;
                            temp.department_name = item.department_name;
                            temp.e = paibanbiao_id;
                            temp.f = item.f;
                            temp.g = item.g;
                            temp.h = item.h;
                            temp.i = item.i;
                            temp.id = item.id;
                            temp.id_number = item.id_number;
                            temp.j = item.j;
                            temp.k = item.k;
                            temp.l = item.l;
                            temp.m = item.m;
                            temp.n = item.n;
                            temp.phone_number = item.phone_number;
                            temp.staff_name = item.staff_name;
                            temp.c = item.staff_name;
                            temp.d = i.ToString();
                            temp.c = dtnextday.ToString("yyyy-MM-dd");
                            temp.b = "无";
                            #endregion
                            
                            //如果起始日期不是周一情况
                            if (startDate_weeki != "1" && diwuzhouxunhuan != 1)
                            {

                                if (index_xunhuanday28 % 21 == 0 && i>10)
                                {
                                    //因为第一周执行完后index_xunhuanday28=0，剩余三周加起来共计21天，循环是从0开始
                                    index_xunhuanday28 = 0;
                                    diwuzhouxunhuan = 1;
                                }
                            }
                            if (startDate_weeki != "1" && diwuzhouxunhuan==0)
                            {

                                //if (index_xunhuanday28 % 20 == 0)
                                //{
                                //    //因为第一周执行完后index_xunhuanday28=0，剩余三周加起来共计21天，循环是从0开始
                                //    index_xunhuanday28 = 0;
                                //} 
                                if (index_xunhuanday28 <= (6 - Convert.ToInt32(startDate_weeki) + 1) && isrunnew_week1 == true)
                                //if (6 - Convert.ToInt32(index_xunhuanday28) + 1 == Convert.ToInt32(startDate_weeki) && isrunnew_week1 == true)
                                {
                                    //第一班
                                    temp = diyizhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu);
                                }
                                if (index_xunhuanday28 == (6 - Convert.ToInt32(startDate_weeki) + 1) && indexi >= (renyuan.Count - 1) && isrunnew_week1 == true)
                                {
                                    isrunnew_week1 = false;

                                    //index_xunhuanday28 = 0;
                                    //   diyicijieyu = "br";
                                    index_xunhuanday28 = -1;

                                    indexi++;
                                    renyuan_wordplan.Add(temp);
                                    break;

                                }
                                if (isrunnew_week1 == false)
                                {
                                    if (index_xunhuanday28 <= 6)
                                    {
                                        //第二班
                                        temp = dierzhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp);

                                    }
                                    else if (index_xunhuanday28 <= 13 && index_xunhuanday28 > 6)
                                    {
                                        #region 4人情况
                                        //if (weeki == "6" || weeki == "0")
                                        //{
                                        //    if (weeki == "6")
                                        //    {
                                        //        if (indexi < 1)//第一个人上班
                                        //        {
                                        //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //        }
                                        //        if (indexi == 2)
                                        //        {
                                        //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        if (indexi == 1)//第一个人上班
                                        //        {
                                        //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                                        //        }
                                        //        if (indexi == 3)
                                        //        {
                                        //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //        }
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    if (indexi < 2)
                                        //    {
                                        //        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //    }
                                        //    else if (indexi >= 2)
                                        //    {
                                        //        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //    }
                                        //} 
                                        #endregion

                                        //第一班
                                        temp = diyizhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu);

                                    }
                                    else if (index_xunhuanday28 <= 20 && index_xunhuanday28 > 13)
                                    {
                                        #region 4人情况
                                        //if (weeki == "6" || weeki == "0")
                                        //{
                                        //    if (weeki == "6")
                                        //    {
                                        //        if (indexi < 1)//第一个人上班
                                        //        {
                                        //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                                        //        }
                                        //        if (indexi == 2)
                                        //        {
                                        //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        if (indexi == 1)//第一个人上班
                                        //        {
                                        //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //        }
                                        //        if (indexi == 3)
                                        //        {
                                        //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //        }

                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    if (indexi < 2)
                                        //    {
                                        //        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //    }
                                        //    else if (indexi >= 2)
                                        //    {
                                        //        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //    }
                                        //} 
                                        #endregion
                                        //第二班
                                        temp = dierzhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp);

                                    }
                                    else if (index_xunhuanday28 <= 27 && index_xunhuanday28 > 20)
                                    {
                                        #region 4人情况
                                        //if (weeki == "6" || weeki == "0")
                                        //{
                                        //    if (weeki == "6")
                                        //    {
                                        //        if (indexi < 1)//第一个人上班
                                        //        {
                                        //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //        }
                                        //        if (indexi == 2)
                                        //        {
                                        //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        if (indexi == 1)//第一个人上班
                                        //        {
                                        //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //        }
                                        //        if (indexi == 3)
                                        //        {
                                        //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //        }

                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    if (indexi < 2)
                                        //    {

                                        //        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                        //    }
                                        //    else if (indexi >= 2 && i != 27 && i != 28)
                                        //    {
                                        //        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                        //    }
                                        //} 
                                        #endregion
                                        //第一班
                                        temp = diyizhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu);
                                    }
                                    #region 4人情况 算28 -31  天情况，现改成4周一轮回
                                    //else if (index_xunhuanday28 > 27)//大于28天自动归零
                                    //{
                                    //    if (weeki == "6" || weeki == "0")
                                    //    {
                                    //        if (weeki == "6")
                                    //        {
                                    //            if (indexi < 1)//第一个人上班
                                    //            {
                                    //                temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                                    //            }
                                    //            if (indexi == 2)
                                    //            {
                                    //                temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            if (indexi == 1)//第一个人上班
                                    //            {

                                    //                temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //            }
                                    //            if (indexi == 3)
                                    //            {

                                    //                temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //            }

                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        if (indexi < 2)
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //        }
                                    //        else
                                    //        {
                                    //            temp = temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //        }
                                    //    }
                                    //} 
                                    #endregion

                                }
                            }
                            else
                            {
                                if (index_xunhuanday28 % 28 == 0)
                                {
                                    //因为第一周是周一，剩余四周加起来共计28天，循环是从0开始
                                    index_xunhuanday28 = 0;
                                } 
                                if (index_xunhuanday28 <= 6)
                                {
                                    //第一班
                                    temp = diyizhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu);
                                }
                                else if (index_xunhuanday28 <= 13 && index_xunhuanday28 > 6)
                                {
                                    #region 4人情况
                                    //if (weeki == "6" || weeki == "0")
                                    //{
                                    //    if (weeki == "6")
                                    //    {
                                    //        if (indexi < 1)//第一个人上班
                                    //        {
                                    //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //        }
                                    //        if (indexi == 2)
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        if (indexi == 1)//第一个人上班
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                                    //        }
                                    //        if (indexi == 3)
                                    //        {
                                    //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (indexi < 2)
                                    //    {
                                    //        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //    }
                                    //    else if (indexi >= 2)
                                    //    {
                                    //        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //    }
                                    //} 
                                    #endregion

                                    //第二班
                                    temp = dierzhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp);

                                }
                                else if (index_xunhuanday28 <= 20 && index_xunhuanday28 > 13)
                                {
                                    #region 4人情况
                                    //if (weeki == "6" || weeki == "0")
                                    //{
                                    //    if (weeki == "6")
                                    //    {
                                    //        if (indexi < 1)//第一个人上班
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                                    //        }
                                    //        if (indexi == 2)
                                    //        {
                                    //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        if (indexi == 1)//第一个人上班
                                    //        {
                                    //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //        }
                                    //        if (indexi == 3)
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //        }

                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (indexi < 2)
                                    //    {
                                    //        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //    }
                                    //    else if (indexi >= 2)
                                    //    {
                                    //        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //    }
                                    //} 
                                    #endregion
                                    //第一班
                                    temp = diyizhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp, lunhuanjiangetianshu);
                                }
                                else if (index_xunhuanday28 <= 27 && index_xunhuanday28 > 20)
                                {
                                    #region 4人情况
                                    //if (weeki == "6" || weeki == "0")
                                    //{
                                    //    if (weeki == "6")
                                    //    {
                                    //        if (indexi < 1)//第一个人上班
                                    //        {
                                    //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //        }
                                    //        if (indexi == 2)
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        if (indexi == 1)//第一个人上班
                                    //        {
                                    //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //        }
                                    //        if (indexi == 3)
                                    //        {
                                    //            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //        }

                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    if (indexi < 2)
                                    //    {

                                    //        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                    //    }
                                    //    else if (indexi >= 2 && i != 27 && i != 28)
                                    //    {
                                    //        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                    //    }
                                    //} 
                                    #endregion

                                    //第二班
                                    temp = dierzhou_panban(renyuan, weeki, dtnextday, paibanbiao_id, banci, meizu_part, i, indexi, item, temp);
                                }
                                #region 4人情况 算28 -31  天情况，现改成4周一轮回
                                //else if (index_xunhuanday28 > 27)//大于28天自动归零
                                //{
                                //    if (weeki == "6" || weeki == "0")
                                //    {
                                //        if (weeki == "6")
                                //        {
                                //            if (indexi < 1)//第一个人上班
                                //            {
                                //                temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                                //            }
                                //            if (indexi == 2)
                                //            {
                                //                temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                //            }
                                //        }
                                //        else
                                //        {
                                //            if (indexi == 1)//第一个人上班
                                //            {

                                //                temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                //            }
                                //            if (indexi == 3)
                                //            {

                                //                temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                //            }

                                //        }
                                //    }
                                //    else
                                //    {
                                //        if (indexi < 2)
                                //        {
                                //            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                                //        }
                                //        else
                                //        {
                                //            temp = temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                                //        }
                                //    }
                                //} 
                                #endregion

                            }

                            indexi++;
                            //   Convert.ToDateTime(nowwenk).AddDays(1);
                            ///  weeki = (((int)DateTime.Parse(nowwenk).DayOfWeek).ToString());
                            renyuan_wordplan.Add(temp);
                        }
                        index_xunhuanday28++;
                    }
                    dtnextday = Convert.ToDateTime(dtnextday).AddDays(1);
                }

                #region 重新绑定数据传输到数据库中
                pbds = new PaiBanDetailService();
                user_info user;
                List<paibanbiao_detail> renyuan_wordplanlist = new List<paibanbiao_detail>();

                foreach (paibanbiao_renyuan itemnew in renyuan_wordplan)
                {
                    paibanbiao_detail additem = new paibanbiao_detail();
                    additem.staff_name = itemnew.staff_name;
                    additem.phone_number = itemnew.phone_number;
                    additem.banci = itemnew.banci;
                    additem.department_name = itemnew.department_name;
                    additem.id_number = itemnew.id_number;
                    additem.company = itemnew.company;
                    additem.b = itemnew.b;
                    additem.c = itemnew.c;
                    additem.d = itemnew.d;
                    additem.e = itemnew.e;
                    additem.f = itemnew.f;
                    additem.g = itemnew.g;
                    additem.h = itemnew.h;
                    additem.i = itemnew.i;
                    additem.j = itemnew.j;
                    additem.k = itemnew.k;
                    renyuan_wordplanlist.Add(additem);
                }
                #endregion
                return ResultUtil.success(pbds.save(paibanbiaoInfo, renyuan_wordplanlist, paibanbiao_id), "保存成功");


            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("保存失败");
            }
        }

        private static paibanbiao_renyuan diyizhou_panban(List<paibanbiao_renyuan> renyuan, string weeki, DateTime dtnextday, String paibanbiao_id, int banci, int meizu_part, int i, int indexi, paibanbiao_renyuan item, paibanbiao_renyuan temp, int lunhuanjiangetianshu)
        {
            if (weeki == "6" || weeki == "0")
            {
                if (weeki == "6")
                {

                    #region 4个人情况
                    //if (indexi < 1)//第一个人上班
                    //{
                    //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                    //}
                    //if (indexi == 2)
                    //{
                    //    temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                    //}
                    #endregion

                    if (indexi < (renyuan.Count / banci / meizu_part))//周六总人数除以2 前组前半人
                    {
                        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                    }
                    //周六总人数除以2 后组前半人
                    if (indexi >= (renyuan.Count / banci) && indexi < (renyuan.Count / banci / meizu_part + renyuan.Count / banci))
                    {
                        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                    }
                }
                else
                {
                    //如果周末分组 仅为1班就周六周日都上班
                    if (meizu_part == 1 && banci == 1)
                    {
                        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                    }
                    else
                    {
                        //周7总人数除以2 前组后半人
                        if (indexi >= (renyuan.Count / banci / meizu_part) && indexi < (renyuan.Count / banci))//第一个人上班
                        {
                            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                        }
                        //周7总人数除以2 后组后半人
                        if (indexi >= (renyuan.Count / banci / meizu_part + renyuan.Count / banci) && indexi < (renyuan.Count))
                        {
                            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                        }
                    }
                }
            }
            else
            {

                {
                    if (indexi < renyuan.Count / banci)//一班
                    {
                        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                    }
                    else if (indexi >= renyuan.Count / banci)//二班
                    {
                        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                    }
                }
            }
            return temp;
        }
        private static paibanbiao_renyuan dierzhou_panban(List<paibanbiao_renyuan> renyuan, string weeki, DateTime dtnextday, String paibanbiao_id, int banci, int meizu_part, int i, int indexi, paibanbiao_renyuan item, paibanbiao_renyuan temp)
        {
            if (weeki == "6" || weeki == "0")
            {
                if (weeki == "6")
                {
                    if (indexi < (renyuan.Count / banci / meizu_part))//周六总人数除以2 前组前半人
                    {
                        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);


                    }
                    //周六总人数除以2 后组前半人
                    if (indexi >= (renyuan.Count / banci) && indexi < (renyuan.Count / banci / meizu_part + renyuan.Count / banci))
                    {

                        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                    }
                }
                else
                {
                    //如果周末分组 仅为1班就周六周日都上班
                    if (meizu_part == 1 && banci == 1)
                    {
                        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                    }
                    else
                    {
                        //周7总人数除以2 前组后半人
                        if (indexi >= (renyuan.Count / banci / meizu_part) && indexi < (renyuan.Count / banci))//第一个人上班
                        {
                            temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                        }
                        //周7总人数除以2 后组后半人
                        if (indexi >= (renyuan.Count / banci / meizu_part + renyuan.Count / banci) && indexi < (renyuan.Count))
                        {

                            temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                        }
                    }
                }
            }
            else
            {

                if (indexi < renyuan.Count / banci)//一班
                {
                    temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                }
                else if (indexi >= renyuan.Count / banci)//二班
                {
                    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                }
            }
            return temp;
        }

        private static paibanbiao_renyuan diyizhou_panban_lunhuanzhi(List<paibanbiao_renyuan> renyuan, string weeki, DateTime dtnextday, String paibanbiao_id, int banci, int meizu_part, int i, int indexi, paibanbiao_renyuan item, paibanbiao_renyuan temp, int lunhuanjiangetianshu, int dangqianpaidaorenci)
        {
            if (weeki == "6" || weeki == "0")
            {
                if (weeki == "6")
                {
                    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                    //if (indexi < (renyuan.Count / banci / meizu_part))//周六总人数除以2 前组前半人
                    //{
                    //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                    //}
                    ////周六总人数除以2 后组前半人
                    //if (indexi >= (renyuan.Count / banci) && indexi < (renyuan.Count / banci / meizu_part + renyuan.Count / banci))
                    //{
                    //    temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                    //}
                }
                else
                {
                    //如果周末分组 仅为1班就周六周日都上班
                    if (meizu_part == 1 && banci == 1)
                    {
                        temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);

                    }
                    else
                    {
                        //周7总人数除以2 前组后半人
                        //if (indexi >= (renyuan.Count / banci / meizu_part) && indexi < (renyuan.Count / banci))//第一个人上班
                        //{
                        //    //temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                        //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                        //    dangqianpaidaorenci++;
                        //}

                        //if (dangqianpaidaorenci < (renyuan.Count / banci))
                        //{
                        //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);


                        //}
                        //if (dangqianpaidaorenci > (renyuan.Count / banci) && dangqianpaidaorenci < (renyuan.Count / banci * 2))
                        //{
                        //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);


                        //}
                        //if (dangqianpaidaorenci > (renyuan.Count / banci * 2) && dangqianpaidaorenci < (renyuan.Count / banci * 3))
                        //{
                        //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                        //}

                        temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                        ////周7总人数除以2 后组后半人
                        //if (indexi >= (renyuan.Count / banci / meizu_part + renyuan.Count / banci) && indexi < (renyuan.Count))
                        //{
                        //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                        //}
                    }
                }
            }
            else
            {
                temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);

                {
                    //if (indexi < renyuan.Count / banci)//一班
                    //{
                    //    temp = temp_wirte_day(dtnextday, i, item, temp, paibanbiao_id);
                    //}
                    //else if (indexi >= renyuan.Count / banci)//二班
                    //{
                    //    temp = temp_blackday(dtnextday, i, temp, item, paibanbiao_id);
                    //}
                }
            }
            return temp;
        }

        private static paibanbiao_renyuan temp_blackday(DateTime dtnextday, int i, paibanbiao_renyuan temp, paibanbiao_renyuan item, String paibanbiao_id)
        {

            temp.b = item.b;
            temp.banci = item.banci;
            temp.c = item.c;
            temp.company = item.company;
            temp.d = item.d;
            temp.department_name = item.department_name;
            temp.e = paibanbiao_id;
            temp.f = item.f;
            temp.g = item.g;
            temp.h = item.h;
            temp.i = item.i;
            temp.id = item.id;
            temp.id_number = item.id_number;
            temp.j = item.j;
            temp.k = item.k;
            temp.l = item.l;
            temp.m = item.m;
            temp.n = item.n;
            temp.phone_number = item.phone_number;
            temp.staff_name = item.staff_name;



            temp.d = i.ToString();
            temp.c = dtnextday.ToString("yyyy-MM-dd");
            temp.b = "black day";
            return temp;
        }

        private static paibanbiao_renyuan temp_wirte_day(DateTime dtnextday, int i, paibanbiao_renyuan item, paibanbiao_renyuan temp, String paibanbiao_id)
        {
            temp.b = item.b;
            temp.banci = item.banci;
            temp.c = item.c;
            temp.company = item.company;
            temp.d = item.d;
            temp.department_name = item.department_name;
            temp.e = paibanbiao_id;
            temp.f = item.f;
            temp.g = item.g;
            temp.h = item.h;
            temp.i = item.i;
            temp.id = item.id;
            temp.id_number = item.id_number;
            temp.j = item.j;
            temp.k = item.k;
            temp.l = item.l;
            temp.m = item.m;
            temp.n = item.n;
            temp.phone_number = item.phone_number;
            temp.staff_name = item.staff_name;

            temp.c = dtnextday.ToString("yyyy-MM-dd");
            temp.d = i.ToString();
            temp.b = "wirite day";
            return temp;
        }
        public string GetWeekCHA(string WeekENG)
        {
            string return_value = "";
            switch (WeekENG)
            {
                case "Monday":
                    return_value = "星期一";
                    return return_value;
                case "Tuesday":
                    return_value = "星期二";
                    return return_value;
                case "Wednesday":
                    return_value = "星期三";
                    return return_value;
                case "Thursday":
                    return_value = "星期四";
                    return return_value;
                case "Friday":
                    return_value = "星期五";
                    return return_value;
                case "Saturday":
                    return_value = "星期六";
                    return return_value;
                case "Sunday":
                    return_value = "星期日";
                    return return_value;
                case "1":
                    return_value = "星期一";
                    return return_value;
                case "2":
                    return_value = "星期二";
                    return return_value;
                case "3":
                    return_value = "星期三";
                    return return_value;
                case "4":
                    return_value = "星期四";
                    return return_value;
                case "5":
                    return_value = "星期五";
                    return return_value;
                case "6":
                    return_value = "星期六";
                    return return_value;
                case "7":
                    return_value = "星期日";
                    return return_value;
            }
            return return_value;
        }

        [WebMethod]
        public string Paiban1(paibanbiao_info paibanbiaoInfo, List<paibanbiao_renyuan> renyuan, DateTime ks1, DateTime js1, int banci,string xiuxi) 
        {
            List<paibanbiao_detail> paiban_detail = new List<paibanbiao_detail>();
            try
            {
                pbds = new PaiBanDetailService();
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "排班");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }
                //设置编号
                string paibanbiao_id= DateTime.Now.ToString("yyyyMMddss");

                //给人员分班次
                int zu = 1;
                for (int i = 0; i < renyuan.Count; i++)
                {
                    renyuan[i].b = "班次" + zu;
                    if (zu == banci)
                    {
                        zu = 1;
                    }
                    else
                    {
                        zu = zu + 1;
                    }
                }

                DateTime ks;
                DateTime js;
                ks = Convert.ToDateTime(ks1);
                js = Convert.ToDateTime(js1);
                xiuxi = xiuxi.Replace("，", ",");
                //排班天数
                TimeSpan tianshu = js - ks;
                for (int i = 0; i < tianshu.Days; i++)
                {
                    if (Array.IndexOf(Regex.Split(xiuxi, ","), Convert.ToString(CaculateWeekDay(ks))) == -1) 
                    {
                        for (int j = 0; j < renyuan.Count; j++)
                        {
                            paibanbiao_detail pd = new paibanbiao_detail();
                            pd.staff_name = renyuan[j].staff_name;
                            pd.phone_number = renyuan[j].phone_number;
                            pd.banci = renyuan[j].banci;
                            pd.department_name = renyuan[j].department_name;
                            pd.id_number = renyuan[j].id_number;
                            pd.company = renyuan[j].company;
                            pd.b = renyuan[j].b;
                            pd.c = ks.ToString("yyyy-MM-dd");
                            pd.e = paibanbiao_id;

                            paiban_detail.Add(pd);
                        }
                    }
                    ks = ks.AddDays(1);
                }
                paibanbiaoInfo.paibanbiao_detail_id = Convert.ToInt32(paibanbiao_id);
                return ResultUtil.success(pbds.save(paibanbiaoInfo, paiban_detail, paibanbiao_id), "保存成功");

            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("保存失败");
            }
        }

        [WebMethod]
        public string Paiban2(paibanbiao_info paibanbiaoInfo, List<paibanbiao_renyuan> renyuan, DateTime ks2, DateTime js2, int banci, string lunhuan_type,int lunhuan_num,int jiange)
        {
            List<paibanbiao_detail> paiban_detail = new List<paibanbiao_detail>();
            try
            {
                pbds = new PaiBanDetailService();
                us = new UserInfoService();
                string quanxian_save1 = us.new_quanxian("add", "排班");
                if (quanxian_save1 != null && quanxian_save1.Length > 0 && quanxian_save1 == "是")
                {
                }
                else
                {
                    return ResultUtil.error("没有权限！");
                }
                //设置编号
                string paibanbiao_id = DateTime.Now.ToString("yyyyMMddss");

                
                if (lunhuan_type == "天") 
                {
                    //给人员分队和班次
                    int dui = 1;
                    int zu = 1;
                    for (int i = 0; i < renyuan.Count; i++)
                    {
                        renyuan[i].f = "队伍" + dui;
                        renyuan[i].b = "班次" + zu;
                        if (dui == lunhuan_num)
                        {
                            dui = 1;
                            if (zu == banci)
                            {
                                zu = 1;
                            }
                            else
                            {
                                zu = zu + 1;
                            }
                        }
                        else
                        {
                            dui = dui + 1;
                        }
                    }

                    DateTime ks;
                    DateTime js;
                    ks = Convert.ToDateTime(ks2);
                    js = Convert.ToDateTime(js2);

                    //排班天数
                    TimeSpan tianshu = js - ks;
                    //轮换队伍变量
                    int lh = 1;
                    //轮换天数变量
                    int lu_ts = 0;
                    for (int i = 0; i < tianshu.Days; i++)
                    {
                        for (int j = 0; j < renyuan.Count; j++)
                        {
                            if (renyuan[j].f.Equals("队伍" + lh))
                            {
                                paibanbiao_detail pd = new paibanbiao_detail();
                                pd.staff_name = renyuan[j].staff_name;
                                pd.phone_number = renyuan[j].phone_number;
                                pd.banci = renyuan[j].banci;
                                pd.department_name = renyuan[j].department_name;
                                pd.id_number = renyuan[j].id_number;
                                pd.company = renyuan[j].company;
                                pd.b = renyuan[j].b;
                                pd.c = ks.ToString("yyyy-MM-dd");
                                pd.e = paibanbiao_id;
                                pd.f = renyuan[j].f;
                                paiban_detail.Add(pd);
                            }
                        }
                        lu_ts = lu_ts + 1;
                        if (lu_ts == jiange)
                        {
                            lu_ts = 0;
                            lh = lh + 1;
                            if (lh > lunhuan_num)
                            {
                                lh = 1;
                            }
                        }
                        ks = ks.AddDays(1);
                    }
                    paibanbiaoInfo.paibanbiao_detail_id = Convert.ToInt32(paibanbiao_id);
                    return ResultUtil.success(pbds.save(paibanbiaoInfo, paiban_detail, paibanbiao_id), "保存成功");
                }
                else if (lunhuan_type == "周")
                {
                    //给人员分队和班次
                    int dui = 1;
                    int zu = 1;

                    for (int i = 0; i < renyuan.Count; i++)
                    {
                        renyuan[i].f = "队伍" + dui;
                        renyuan[i].b = "班次" + zu;
                        if (dui == lunhuan_num)
                        {
                            dui = 1;
                            if (zu == banci)
                            {
                                zu = 1;
                            }
                            else
                            {
                                zu = zu + 1;
                            }
                        }
                        else
                        {
                            dui = dui + 1;
                        }
                        
                    }

                    DateTime ks;
                    DateTime js;
                    ks = Convert.ToDateTime(ks2);
                    js = Convert.ToDateTime(js2);

                    //排班天数
                    TimeSpan tianshu = js - ks;
                    //轮换队伍变量
                    int lh = 1;
                    //轮换周数变量
                    int zhou = 0;

                    for (int i = 0; i < tianshu.Days; i++)
                    {
                        for (int j = 0; j < renyuan.Count; j++)
                        {
                            if (renyuan[j].f.Equals("队伍" + lh))
                            {
                                paibanbiao_detail pd = new paibanbiao_detail();
                                pd.staff_name = renyuan[j].staff_name;
                                pd.phone_number = renyuan[j].phone_number;
                                pd.banci = renyuan[j].banci;
                                pd.department_name = renyuan[j].department_name;
                                pd.id_number = renyuan[j].id_number;
                                pd.company = renyuan[j].company;
                                pd.b = renyuan[j].b;
                                pd.c = ks.ToString("yyyy-MM-dd");
                                pd.e = paibanbiao_id;
                                pd.f = renyuan[j].f;
                                paiban_detail.Add(pd);
                            }
                        }
                        if (CaculateWeekDay(ks) ==7) 
                        {
                            zhou = zhou + 1;
                            if (zhou == jiange)
                            {
                                zhou = 0;
                                lh = lh + 1;
                                if (lh > lunhuan_num)
                                {
                                    lh = 1;
                                }
                            }
                        }
                        ks = ks.AddDays(1);
                    }
                    paibanbiaoInfo.paibanbiao_detail_id = Convert.ToInt32(paibanbiao_id);
                    return ResultUtil.success(pbds.save(paibanbiaoInfo, paiban_detail, paibanbiao_id), "保存成功");
                }
                else 
                {
                    return ResultUtil.error("请选择排班类型");
                }
            }
            catch (ErrorUtil err)
            {
                return ResultUtil.fail(401, err.Message);
            }
            catch (Exception ex)
            {

                return ResultUtil.error("保存失败");
            }
        }



        //根据日期计算周几，返回int
        public static int CaculateWeekDay(DateTime rq)
        {
            int y = rq.Year;
            int m = rq.Month;
            int d = rq.Day;
            if (m == 1 || m == 2)
            {
                m += 12;
                y--;
            }
            int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400 + 1) % 7;
            if (week == 0) 
            {
                week = 7;
            }
            return week;
        }


    }
}
