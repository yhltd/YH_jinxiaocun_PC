using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class WorkModuleService
    {
        private static WorkModuleDao wmd = new WorkModuleDao();

        private user_info user;

        public WorkModuleService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 查询模块汇总
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页显示行数</param>
        /// <param name="typeId">模块类别id，-1为查询全部</param>
        /// <returns></returns>
        public PageUtil<WorkSummary> list(int nowPage, int pageCount, int typeId, string orderId)
        {
            PageUtil<WorkSummary> page = new PageUtil<WorkSummary>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = wmd.SummaryCount(user.company, typeId, orderId);
            page.pageList = wmd.listBySummary(user.company, orderId, typeId, page.getSkip(), page.getTake());
            return page;
        }
    }
}