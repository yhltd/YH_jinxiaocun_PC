﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class WorkModuleDao
    {

        private schedulingEntities se;

        public List<work_module> listByWorkId(int workId)
        {
            using (se = new schedulingEntities())
            {
                var result = se.work_module.Where(wm => wm.work_id == workId).OrderBy(wm => wm.id);
                return result.ToList();
            }
        }

        
        public List<WorkSummary> listBySummary(string company, int typeId, int skip, int take)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@typeId", typeId),
                new SqlParameter("@company", company)
            };

            string sql = "select mt.name as type,mi.name as name,mi.num as num,(select name from module_info where id = mi.parent_id) as parentName,sum(wd.work_num) as workNum from module_info as mi left join work_module as wm on wm.module_id = mi.id left join module_type as mt on mi.type_id = mt.id left join work_detail as wd on wm.work_id = wd.id where wd.company = @company " + (typeId > 0 ? "and mi.type_id = @typeId" : "") + " group by mt.name,mi.name,mi.num,mi.parent_id";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<WorkSummary>(sql, @params).OrderBy(w => w.type).Skip(skip).Take(take);
                return result.ToList();
            }
        }

        public int SummaryCount(string company, int typeId) 
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@typeId", typeId),
                new SqlParameter("@company", company)
            };

            string sql = "select mt.name as type,mi.name as name,mi.num as num,(select name from module_info where id = mi.parent_id) as parentName,sum(wd.work_num) as workNum from work_module as wm left join module_info as mi on wm.module_id = mi.id left join module_type as mt on mi.type_id = mt.id left join work_detail as wd on wm.work_id = wd.id where wd.company = @company " + (typeId > 0 ? "and mi.type_id = @typeId" : "") + " group by mt.name,mi.name,mi.num,mi.parent_id";
            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<WorkSummary>(sql, @params).OrderBy(w => w.type).Count();
                return (int)result;
            }
        }

        public Boolean deleteByModuleId(int moduleId)
        {
            using (se = new schedulingEntities())
            {
                var param = new SqlParameter("@moduleId", moduleId);
                var sql = "delete from work_module where module_id = @moduleId";
                return se.Database.ExecuteSqlCommand(sql, param) > 0;
            }
        }
    }
}