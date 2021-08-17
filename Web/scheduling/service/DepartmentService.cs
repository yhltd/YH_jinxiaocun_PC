using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class DepartmentService
    {
        private static DepartmentDao dd = new DepartmentDao();

        private user_info user;

        public DepartmentService()
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
        public PageUtil<department> list(int nowPage, int pageCount)
        {
            user = TokenUtil.getToken();
            PageUtil<department> page = new PageUtil<department>();
            page.nowPage = nowPage;
            page.pageCount = pageCount;
            page.total = dd.DepartmentCount();
            page.pageList = dd.getList(page.getSkip(), page.getTake(),user.company);
            return page;
        }

        /// <summary>
        /// 新增部门
        /// </summary>
        /// <returns></returns>
        public Boolean save(department department)
        {
            department.company = user.company;
            return dd.save<department>(department) != null;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            DepartmentDao dd = new DepartmentDao();
            return dd.delete<department>(id);
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        public Boolean update(department department)
        {
            return dd.update<department>(department);
        }

    }
}