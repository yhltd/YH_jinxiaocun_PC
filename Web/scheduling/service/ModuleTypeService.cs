using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.scheduling.dao;
using Web.scheduling.model;
using Web.scheduling.utils;

namespace Web.scheduling.service
{
    public class ModuleTypeService
    {
        private static ModuleTypeDao mtdo = new ModuleTypeDao();

        private static ModuleService ms = new ModuleService();

        private static ModuleDao md = new ModuleDao();

        private static CommonDao cd = new CommonDao();

        private user_info user;

        public ModuleTypeService()
        {
            user = TokenUtil.getToken();
            if (user == null)
            {
                throw new ErrorUtil("无权限");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <returns>模块类别集合</returns>
        public List<module_type> list()
        {
            return mtdo.list(user.company);
        }

        /// <summary>
        /// 新增模块类别
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public module_type save(module_type moduleType) 
        {
            moduleType.company = user.company;
            return cd.save<module_type>(moduleType);
        }

        /// <summary>
        /// 修改模块类别
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public Boolean update(module_type moduleType) 
        {
            return cd.update<module_type>(moduleType);
        }

        /// <summary>
        /// 删除模块类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boolean delete(int id) 
        {
            List<module_info> moduleList = md.listByTypeId(id);
            foreach (module_info moduleInfo in moduleList)
            {
                ms.delete(moduleInfo.id);
            }
            return cd.delete<module_type>(id);
        }
    }
}