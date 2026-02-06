using clsBuiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web.scheduling.model;

namespace Web.scheduling.dao
{
    public class WorkDetailDao
    {
        private schedulingEntities se;

        public List<WorkItem> list(string company, int skip, int take, string orderId)
        {
            var @params = new SqlParameter[]{
                new SqlParameter("@company", company),
                //new SqlParameter("@orderId", orderId),
                new SqlParameter("@minRowNumber", skip),
                //new SqlParameter("@maxRowNumber", (skip + 1) + take)
                new SqlParameter("@maxRowNumber", skip + take)
            };

            //string sql = "select * from (select row_number() over(order by wd.id) as rownum,wd.*,oi.order_id as orderId from work_detail as wd left join order_info as oi on wd.order_id = oi.id) as wd where wd.company = @company and wd.orderId like '%' + @orderId + '%' and rownum > @minRowNumber and rownum < @maxRowNumber order by wd.row_num,wd.is_insert asc";
            //string sql = "select * from (select row_number() over(order by wd.id) as rownum,wd.*,oi.order_id as orderId from work_detail as wd left join order_info as oi on wd.order_id = oi.id) as wd where wd.company = @company and rownum > @minRowNumber and rownum < @maxRowNumber order by wd.work_start_date,wd.row_num,wd.is_insert asc";
            string sql = @"select * from (select row_number() over(order by wd.work_start_date, wd.row_num, wd.is_insert asc) as rownum, wd.*, oi.order_id as orderId from work_detail as wd left join order_info as oi on wd.order_id = oi.id where wd.company = @company) as wd where wd.rownum > @minRowNumber and wd.rownum <= @maxRowNumber order by wd.work_start_date, wd.row_num, wd.is_insert asc";


            using (se = new schedulingEntities())
            {
                var result = se.Database.SqlQuery<WorkItem>(sql, @params);
                return result.ToList();
            }
        }


        public int count(string company)
        {
            using (se = new schedulingEntities())
            {
                var result = se.work_detail.Count(w => w.company == company);
                return (int)result;
            }
        }

        public Boolean deleteByModuleId(int moduleId)
        {
            using (se = new schedulingEntities())
            {
                var param = new SqlParameter("@moduleId", moduleId);
                var sql = "delete from work_detail where id in (select work_id from work_module where module_id = @moduleId) ";
                return se.Database.ExecuteSqlCommand(sql, param) > 0;
            }
        }

        public Boolean deleteWork(string rowNum, string company)
        {
            using (se = new schedulingEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@rowNum", rowNum),
                    new SqlParameter("@company", company),
                };

                //var sql = "delete from work_detail where row_num=@rowNum";
                var sql = "delete from work_detail where order_id =(select top 1 id from order_info where order_id=@rowNum) and company=@company";
                return se.Database.ExecuteSqlCommand(sql, @params) > 0;
            }
        }

        //public Int32 getCount(string company) 
        //{
        //    using (se = new schedulingEntities())
        //    {
        //        var @params = new SqlParameter[]{
        //            new SqlParameter("@company", company),
        //        };

        //        var sql = "select * work_detail where company=@company";
        //        return se.Database.ExecuteSqlCommand(sql, @params);
        //    }
        //}

        public Boolean deleteWork1<T>(int id) where T : class
        {
            
            //var param = new SqlParameter("@row_num", rowNum);
            //var sql = "delete from work_detail where row_num=@row_num";
            //using (se = new schedulingEntities())
            //{
            //    se.Entry<T>(se.Set<T>().Find(id)).State = EntityState.Deleted;
            //    return se.SaveChanges() > 0;

            //    //return se.Database.ExecuteSqlCommand(sql, param) > 0;
            //}
            //rowNum = 82;
            //using (se = new schedulingEntities())
            //{

            //    string sql = "delete from work_detail where id = @id";
            //    var param = new SqlParameter("@id", rowNum);
            //    return se.Database.ExecuteSqlCommand(sql, param) > 0;
            //}
            //delete from work_detail where row_num=@row_num

            //clsAllnew BusinessHelp = new clsAllnew();
            //string sql2 = "delete from work_detail where   id='" + 82 + "'";

            ////BusinessHelp.Readt_PICServer(sql2);
            //BusinessHelp.deleteCard(sql2);

            return true;

        }


    }
}