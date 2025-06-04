using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class BomService
    {
        private static BomDao bd = new BomDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public BomService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 查询全部bom
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<bom_info> list()
        {
            return bd.list(user.company);
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="nowPage">当前页</param>
        /// <param name="pageCount">每页行数</param>
        /// <param name="code">编码（可以为空）</param>
        /// <param name="name">名称（可以为空）</param>
        /// <param name="type">类别（可以为空）</param>
        /// <returns></returns>
        public PageUtil<BomInfoItem> page(int nowPage, int pageCount, string code, string name, string type)
        {
            PageUtil<BomInfoItem> bomPage = new PageUtil<BomInfoItem>();
            bomPage.nowPage = nowPage;
            bomPage.pageCount = pageCount;
            bomPage.total = bd.count(user.company);
            bomPage.pageList = bd.list(user.company, bomPage.getSkip(), bomPage.getTake(), code, name, type);
            return bomPage;
        }

        /// <summary>
        /// 新增bom
        /// </summary>
        /// <param name="bomInfo"></param>
        /// <returns></returns>
        public Boolean save(bom_info bomInfo)
        {
            bomInfo.company = user.company;
            return cd.save<bom_info>(bomInfo) != null;
        }

        /// <summary>
        /// 修改bom信息
        /// </summary>
        /// <param name="bomInfo"></param>
        /// <returns></returns>
        public Boolean update(bom_info bomInfo)
        {
            bomInfo.company = user.company;
            return cd.update<bom_info>(bomInfo);
        }

        /// <summary>
        /// 删除bom
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id)
        {
            return cd.delete<bom_info>(id);
        }

        /// <summary>
        /// 根据id批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public Boolean deleteBatch(List<int> idList)
        {
            foreach (int id in idList)
            {
                if (!cd.delete<bom_info>(id))
                {
                    return false;
                }
            }
            return true;
        }
    }
}