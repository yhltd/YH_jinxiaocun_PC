using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{

    public class PaibanbiaoInfoService
    {
        private user_info user;

        private static PaibanbiaoInfoDao pi = new PaibanbiaoInfoDao();

        public PaibanbiaoInfoService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 查询部门汇总
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页显示行数</param>
        /// <returns></returns>
        public PageUtil<paibanbiao_info> list(int nowPage, int pageCount,string department_name,string plan_name)
        {
            PageUtil<paibanbiao_info> page = new PageUtil<paibanbiao_info>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = pi.Count();
            string company = user.company;
            page.pageList = pi.getList(page.getSkip(), page.getTake(), department_name, plan_name, company);
                //pi.getList(page.getSkip(), page.getTake());
            return page;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            PaibanbiaoInfoDao pi = new PaibanbiaoInfoDao();
            return pi.delete<paibanbiao_info>(id);
        }

        /// <summary>
        /// 修改人员信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(paibanbiao_info infoList)
        {
            PaibanbiaoInfoDao pi = new PaibanbiaoInfoDao();
            return pi.update<paibanbiao_info>(infoList);
        }
    }
}