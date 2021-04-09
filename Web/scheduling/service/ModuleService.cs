using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class ModuleService
    {
        private static ModuleDao mdo = new ModuleDao();

        private static WorkModuleDao wmd = new WorkModuleDao();

        private static WorkDetailDao wdd = new WorkDetailDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public ModuleService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="moduleInfo"></param>
        /// <returns></returns>
        public Boolean update(module_info moduleInfo) 
        {
            moduleInfo.company = user.company;
            return cd.update<module_info>(moduleInfo);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id) 
        {
            if (cd.delete<module_info>(id))
            {
                return wdd.deleteByModuleId(id) && wmd.deleteByModuleId(id);
            }
            return false;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="moduleInfo"></param>
        /// <returns></returns>
        public module_info save(module_info moduleInfo)
        {
            moduleInfo.company = user.company;
            return cd.save<module_info>(moduleInfo);
        }

        public List<module_info> list() {
            return mdo.list(user.company);
        }

        /// <summary>
        /// 按层级懒加载模块信息
        /// </summary>
        /// <param name="parentId">父级id</param>
        /// <param name="moduleType">模块类型</param>
        /// <returns></returns>
        public List<module_info> list(int parentId, int moduleType) 
        {
            return mdo.list(user.company, parentId, moduleType);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">pageUtil对象</param>
        /// <param name="moduleType">模块类别</param>
        /// <returns>包含总行数和pageList的pageUtil对象</returns>
        public PageUtil<module_info> page(PageUtil<module_info> page, int moduleType)
        {
            page.total = mdo.count(user.company);
            page.pageList = mdo.list(user.company, page.getSkip(), page.getTake(), moduleType);
            return page;
        }

        /// <summary>
        /// 查询所有模块信息
        /// </summary>
        /// <param name="isHasNum">是否过滤没有效率的模块</param>
        /// <returns></returns>
        public List<ModuleItem> listByNum(Boolean isHasNum)
        {
            return mdo.listByNum(user.company, isHasNum);
        }
    }
}