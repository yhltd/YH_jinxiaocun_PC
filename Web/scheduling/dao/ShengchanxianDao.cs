using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class ShengchanxianDao
    {
        private schedulingEntities se;

        /// <summary>
        /// 查询所有生产线
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<shengchanxian> listAll(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.shengchanxian.Where(s => s.gongsi == company);
                return result.ToList();
            }
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="skip">跳过行数</param>
        /// <param name="take">查询行数</param>
        /// <param name="gongxu">工序</param>
        /// <param name="mingcheng">名称</param>
        /// <returns></returns>
        public List<shengchanxian> list(string company, int skip, int take, string gongxu, string mingcheng, string xiaolv)
        {
                using (se = new schedulingEntities())
                {
                    var @params = new SqlParameter[]{
                new SqlParameter("@company", company),
                new SqlParameter("@gongxu", gongxu),
                new SqlParameter("@mingcheng", mingcheng),
                new SqlParameter("@xiaolv", xiaolv),
                new SqlParameter("@minRowNumber", skip * take),
                new SqlParameter("@maxRowNumber", (skip + 1) * take + 1)
            };

                    string sql = @"SELECT * FROM (
                SELECT ROW_NUMBER() OVER(ORDER BY id) AS rownum, * 
                FROM shengchanxian 
                WHERE gongsi = @company 
                AND gongxu LIKE '%' + @gongxu + '%' 
                AND mingcheng LIKE '%' + @mingcheng + '%'
                AND xiaolv LIKE '%' + @xiaolv + '%'
            ) AS temp 
            WHERE rownum > @minRowNumber AND rownum < @maxRowNumber";

                    var result = se.Database.SqlQuery<shengchanxian>(sql, @params);
                    return result.ToList();
                }
            }

        /// <summary>
        /// 获取所有生产线（不分页）
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<shengchanxian> getAll(string company)
        {
            using (se = new schedulingEntities())
            {
                try
                {
                    // 直接查询该公司所有生产线，按ID排序
                    var result = se.shengchanxian
                        .Where(s => s.gongsi == company)
                        .OrderBy(s => s.id) 
                        .ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    // 记录异常日志
                    // LogHelper.Error("获取生产线列表失败", ex);
                    throw;
                }
            }
        }

        public shengchanxian save_shengchanxian(shengchanxian entity)
        {
            using (var se = new schedulingEntities())
            {
                try
                {
                    // 验证必填字段
                    if (string.IsNullOrEmpty(entity.mingcheng))
                    {
                        throw new Exception("生产线名称不能为空");
                    }

                    if (string.IsNullOrEmpty(entity.gongsi))
                    {
                        throw new Exception("公司信息不能为空");
                    }

                    var sql = @"
            INSERT INTO shengchanxian (mingcheng, gongxu, gongsi, xiaolv) 
            VALUES (@mingcheng, @gongxu, @gongsi, @xiaolv);
            SELECT CAST(SCOPE_IDENTITY() AS int)";

                    var id = se.Database.SqlQuery<int>(sql,
                        new SqlParameter("@mingcheng", entity.mingcheng ?? (object)DBNull.Value),
                        new SqlParameter("@gongxu", entity.gongxu ?? (object)DBNull.Value),
                        new SqlParameter("@gongsi", entity.gongsi),
                        new SqlParameter("@xiaolv", entity.xiaolv ?? (object)DBNull.Value)).FirstOrDefault();

                    entity.id = id;
                    return entity;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // 添加专门的 shengchanxian 更新方法
        public bool update_shengchanxian(shengchanxian entity)
        {
            using (var se = new schedulingEntities())
            {
                try
                {
                    // 验证必填字段
                    if (string.IsNullOrEmpty(entity.mingcheng))
                    {
                        throw new Exception("生产线名称不能为空");
                    }

                    if (string.IsNullOrEmpty(entity.gongsi))
                    {
                        throw new Exception("公司信息不能为空");
                    }

                    // 检查记录是否存在
                    var exists = se.shengchanxian.Any(x => x.id == entity.id);
                    if (!exists)
                    {
                        throw new Exception("生产线不存在");
                    }

                    var sql = @"
            UPDATE shengchanxian 
            SET mingcheng = @mingcheng, gongxu = @gongxu, gongsi = @gongsi, xiaolv = @xiaolv
            WHERE id = @id";

                    var rows = se.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@id", entity.id),
                        new SqlParameter("@mingcheng", entity.mingcheng ?? (object)DBNull.Value),
                        new SqlParameter("@gongxu", entity.gongxu ?? (object)DBNull.Value),
                        new SqlParameter("@gongsi", entity.gongsi),
                        new SqlParameter("@xiaolv", entity.xiaolv ?? (object)DBNull.Value));

                    return rows > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 总行数
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="gongxu">工序</param>
        /// <param name="mingcheng">名称</param>
        /// <returns></returns>
        public int count(string company, string gongxu, string mingcheng, string xiaolv = "")
        {
            using (se = new schedulingEntities())
            {
                return se.shengchanxian
                    .Where(s => s.gongsi == company
                        && s.gongxu.Contains(gongxu)
                        && s.mingcheng.Contains(mingcheng)
                        && s.xiaolv.Contains(xiaolv))
                    .Count();
            }
        }
    }
}