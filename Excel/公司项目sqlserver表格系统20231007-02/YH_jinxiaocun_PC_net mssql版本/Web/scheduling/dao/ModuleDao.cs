using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class ModuleDao
    {
        private schedulingEntities se;

        public List<module_info> list(string company, int parentId, int moduleType) {
            using (se = new schedulingEntities()) {
                var result = from m in se.module_info where m.company == company && m.parent_id == parentId && m.type_id == moduleType select m;
                return result.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company"></param>
        /// <returns>模块集合</returns>
        public List<module_info> list(string company) 
        {
            using (se = new schedulingEntities())
            {
                var result = from m in se.module_info where m.company == company select m;
                return result.OrderBy(m => m.parent_id).ToList();
            }
        }

        /// <summary>
        /// 查询所有模块信息
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="isHasNum">是否过滤没有效率的模块</param>
        /// <returns></returns>
        public List<ModuleItem> listByNum(string company, Boolean isHasNum)
        {
            var companyParam = new SqlParameter("@company", company);

            string sql = "select mi.*,mt.name as typeName,(select name from module_info as mmi where mmi.id = mi.parent_id) as parentName from module_info as mi left join module_type as mt on mi.type_id = mt.id where mi.company = @company" + (isHasNum ? " and num is not null and num > 0" : "");

            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<ModuleItem>(sql, companyParam);
                return result.ToList();
            }
        }

        /// <summary>
        /// 根据排产id查询模块信息
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public List<module_info> listByWorkId(int workId)
        {
            var @params = new SqlParameter("@workId", workId);
            string sql = "select * from module_info where id in (select module_id from work_module where work_id = @workId)";

            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<module_info>(sql, @params);
                return result.ToList();
            }
        }

        /// <summary>
        /// 根据模块id查询模块信息
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public List<module_info> listById(int id)
        {
            var @params = new SqlParameter("@id", id);
            string sql = "select * from module_info where id = @id";

            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<module_info>(sql, @params);
                return result.ToList();
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="skip">跳过行数</param>
        /// <param name="take">查询行数</param>
        /// <param name="moduleTypeId">类别id</param>
        /// <returns></returns>
        public List<module_info> list(string company, int skip, int take, int moduleTypeId) 
        {
            using (se = new schedulingEntities()) {
                var result = moduleTypeId > 0
                    ? se.module_info.Where(m => m.type_id == moduleTypeId && m.company == company).OrderBy(m => m.id).Skip(skip).Take(take)
                    : se.module_info.Where(m => m.company == company).OrderBy(m => m.id).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns>总行数</returns>
        public int count(string company) {
            using (se = new schedulingEntities()) {
                var result = se.module_info.Count();
                return (int)result;
            }
        }

        public Boolean deleteByTypeId(int typeId)
        {
            using (se = new schedulingEntities())
            {
                string sql = "delete from module_info where type_id = @typeId";
                var param = new SqlParameter("@typeId", typeId);
                return se.Database.ExecuteSqlCommand(sql, param) > 0;
            }
        }

        public List<module_info> listByTypeId(int typeId) { 
            using(se = new schedulingEntities()){
                var result = se.module_info.Where(m => m.type_id == typeId);
                return result.ToList();
            }
        }
    }
}