using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class PaiChanDao
    {
        private schedulingEntities se;

        /// <summary>
        /// 查询所有排产明细
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<work_detail> list(string company, int nowPage, int pageCount, int? orderId = null)
        {
            using (se = new schedulingEntities())
            {
                var query = se.work_detail.Where(w => w.company == company);

                // 如果传入了订单号且大于0，进行精确匹配
                if (orderId.HasValue && orderId.Value > 0)
                {
                    query = query.Where(w => w.order_id == orderId.Value);
                }

                var result = query
                    .OrderByDescending(w => w.work_start_date)
                    .ThenBy(w => w.row_num)
                    .Skip((nowPage - 1) * pageCount)
                    .Take(pageCount)
                    .ToList();
                return result;
            }
        }


        /// <summary>
        /// 获取所有排产明细（不分页）
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public List<WorkDetailDTO> GetAll(string company)
        {
            using (se = new schedulingEntities())
            {
                try
                {
                    var result = (from work in se.work_detail
                                  join gongxu in se.order_gongxu on work.order_id equals gongxu.order_id
                                  join module in se.module_info on gongxu.module_id equals module.id
                                  join order in se.order_info on work.order_id equals order.id
                                  where work.company == company
                                  orderby work.work_start_date descending, work.row_num ascending
                                  select new WorkDetailDTO
                                  {
                                      // work_detail 表的字段
                                      Id = work.id,
                                      kaishishijian = work.work_start_date,
                                      charu = work.is_insert,
                                      dingdanleixing = work.type,
                                      jiezhishijian = work.jiezhishijian,
                              
                                      // order_gongxu 表的字段
                                      gongxushuliang = gongxu.module_num * work.work_num,
                              
                                      // module_info 表的字段
                                      gongxumingcheng = module.name,
                                      gongxuxiaolv = module.num,

                                      // oeder_info 表的字段
                                      dingdanhao = order.order_id,
                                      dingdanmingcheng = order.product_name,
                                  })
                                  .ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    // 这里应该记录异常日志，而不是直接抛出
                    throw new Exception("获取数据失败}");
                }
            }
        }

        

        /// <summary>
        /// 保存排产明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public work_detail save_work_detail(work_detail entity)
        {
            using (var se = new schedulingEntities())
            {
                try
                {
                    // 验证必填字段
                    if (entity.order_id <= 0)
                    {
                        throw new Exception("订单ID不能为空或小于等于0");
                    }

                    if (entity.work_num <= 0)
                    {
                        throw new Exception("排产数量不能为空或小于等于0");
                    }

                    if (string.IsNullOrEmpty(entity.company))
                    {
                        throw new Exception("公司信息不能为空");
                    }

                    if (entity.work_start_date == DateTime.MinValue)
                    {
                        throw new Exception("开始日期不能为空");
                    }

                    var sql = @"
                                INSERT INTO work_detail (order_id, work_num, work_start_date, company, row_num, is_insert, type, jiezhishijian) 
                                VALUES (@order_id, @work_num, @work_start_date, @company, @row_num, @is_insert, @type, @jiezhishijian);
                                SELECT CAST(SCOPE_IDENTITY() AS int)";

                    var id = se.Database.SqlQuery<int>(sql,
                        new SqlParameter("@order_id", entity.order_id),
                        new SqlParameter("@work_num", entity.work_num),
                        new SqlParameter("@work_start_date", entity.work_start_date),
                        new SqlParameter("@company", entity.company),
                        new SqlParameter("@row_num", entity.row_num ?? (object)DBNull.Value),
                        new SqlParameter("@is_insert", entity.is_insert ?? (object)DBNull.Value),
                        new SqlParameter("@type", entity.type ?? (object)DBNull.Value),
                        new SqlParameter("@jiezhishijian", entity.jiezhishijian ?? (object)DBNull.Value)).FirstOrDefault();

                    entity.id = id;
                    return entity;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 更新排产明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool update_work_detail(work_detail entity)
        {
            using (var se = new schedulingEntities())
            {
                try
                {
                    // 验证必填字段
                    if (entity.id <= 0)
                    {
                        throw new Exception("排产明细ID无效");
                    }

                    if (entity.order_id <= 0)
                    {
                        throw new Exception("订单ID不能为空或小于等于0");
                    }

                    if (entity.work_num <= 0)
                    {
                        throw new Exception("排产数量不能为空或小于等于0");
                    }

                    if (string.IsNullOrEmpty(entity.company))
                    {
                        throw new Exception("公司信息不能为空");
                    }

                    if (entity.work_start_date == DateTime.MinValue)
                    {
                        throw new Exception("开始日期不能为空");
                    }

                    // 检查记录是否存在
                    var exists = se.work_detail.Any(x => x.id == entity.id);
                    if (!exists)
                    {
                        throw new Exception("排产明细不存在");
                    }

                    var sql = @"
                    UPDATE work_detail 
                    SET order_id = @order_id, 
                        work_num = @work_num, 
                        work_start_date = @work_start_date, 
                        company = @company, 
                        row_num = @row_num, 
                        is_insert = @is_insert, 
                        type = @type,
                        jiezhishijian = @jiezhishijian
                    WHERE id = @id";

                            var rows = se.Database.ExecuteSqlCommand(sql,
                                new SqlParameter("@id", entity.id),
                                new SqlParameter("@order_id", entity.order_id),
                                new SqlParameter("@work_num", entity.work_num),
                                new SqlParameter("@work_start_date", entity.work_start_date),
                                new SqlParameter("@company", entity.company),
                                new SqlParameter("@row_num", entity.row_num ?? (object)DBNull.Value),
                                new SqlParameter("@is_insert", entity.is_insert ?? (object)DBNull.Value),
                                new SqlParameter("@type", entity.type ?? (object)DBNull.Value),
                                new SqlParameter("@jiezhishijian", entity.jiezhishijian ?? (object)DBNull.Value));

                            return rows > 0;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }

        /// <summary>
        /// 获取最大行号
        /// </summary>
        /// <param name="company">公司</param>
        /// <returns></returns>
        public int getMaxRowNum(string company)
        {
            using (se = new schedulingEntities())
            {
                var maxRowNum = se.work_detail
                    .Where(w => w.company == company)
                    .Max(w => (int?)w.row_num) ?? 0;
                return maxRowNum;
            }
        }

        /// <summary>
        /// 总行数
        /// </summary>
        /// <param name="company">公司</param>
        /// <param name="order_id">订单ID</param>
        /// <param name="work_num">排产数量</param>
        /// <param name="start_date">开始日期</param>
        /// <param name="end_date">结束日期</param>
        /// <returns></returns>
        public int count(string company, int? orderId = null)
        {
            using (se = new schedulingEntities())
            {
                var query = se.work_detail.Where(w => w.company == company);

                // 如果传入了订单号且大于0，进行精确匹配
                if (orderId.HasValue && orderId.Value > 0)
                {
                    query = query.Where(w => w.order_id == orderId.Value);
                }

                return query.Count();
            }
        }
    }
}