using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class RenyuanService
    {
        private static RenyuanDao rd = new RenyuanDao();

        private user_info user;

        public RenyuanService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }


        /// <summary>
        /// 查询所有人员
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页显示行数</param>
        /// <returns></returns>
        public PageUtil<paibanbiao_renyuan> list(int nowPage, int pageCount,string staff_name,string staff_banci)
        {
            PageUtil<paibanbiao_renyuan> page = new PageUtil<paibanbiao_renyuan>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = rd.DepartmentCount();
            page.pageList = rd.getList(page.getSkip(), page.getTake(), user.company, staff_name, staff_banci);
            return page;
        }

        /// <summary>
        /// 添加人员信息
        /// </summary>
        /// <returns></returns>
        public Boolean add(paibanbiao_renyuan paibanbiao_renyuan)
        {
            paibanbiao_renyuan.company = user.company;
            return rd.add<paibanbiao_renyuan>(paibanbiao_renyuan) != null;
        }

        /// <summary>
        /// 删除人员信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            RenyuanDao rd = new RenyuanDao();
            return rd.delete<paibanbiao_renyuan>(id);
        }

        /// <summary>
        /// 修改人员信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(paibanbiao_renyuan renyuanList)
        {
            return rd.update<paibanbiao_renyuan>(renyuanList);
        }

        /// <summary>
        /// 查询所有人员
        /// </summary>
        public List<paibanbiao_renyuan> getAllList()
        {
            List<paibanbiao_renyuan> list =  rd.getAllList(user.company);
            return list;
        }

        public List<paibanbiao_renyuan> getAllList(String department_name)
        {
            List<paibanbiao_renyuan> list = rd.getAllList(user.company,department_name);
            return list;
        }

        /// <summary>
        /// 查询所有部门
        /// </summary>
        public List<department> getDepartment()
        {
            List<department> list = rd.getDepartment(user.company);
            return list;
        }

        //public List<paibanbiao_renyuan> paibanList(String a, String b, String c, String d)
        //{

        //    String startTime = DateTime.Now.ToLongDateString().ToString();
        //    String endTime=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(1).ToShortDateString();
            


            
        //}

    }
}