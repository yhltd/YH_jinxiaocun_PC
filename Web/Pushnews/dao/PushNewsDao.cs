using System;
using System.Collections.Generic;
using System.Linq;
using Web.Pushnews.model;
using System.Data.SqlClient;

namespace Web.Pushnews.dao
{
    public class PushNewsDao
    {

        public List<product_pushnews> SelectList(string companyName = null)
        {
            // 如果companyName为空，使用默认值
            if (string.IsNullOrEmpty(companyName))
            {
                companyName = "云合未来"; // 默认值
            }

            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合未来进销存系统' " +
             "AND gsname = @CompanyName " +  // 改为参数化查询
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";

            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(
                    sql,
                    new System.Data.SqlClient.SqlParameter("@CompanyName", companyName)
                );
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListCW(string companyName = null)
        {
            // 如果companyName为空，使用默认值
            if (string.IsNullOrEmpty(companyName))
            {
                companyName = "云合未来"; // 默认值
            }

            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合未来财务系统' " +
             "AND gsname = @CompanyName " +  // 改为参数化查询
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";

            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(
                    sql,
                    new System.Data.SqlClient.SqlParameter("@CompanyName", companyName)
                );
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListPC(string companyName = null)
        {
            // 如果companyName为空，使用默认值
            if (string.IsNullOrEmpty(companyName))
            {
                companyName = "云合未来"; // 默认值
            }

            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合排产管理系统' " +
             "AND gsname = @CompanyName " +  // 改为参数化查询
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";

            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(
                    sql,
                    new System.Data.SqlClient.SqlParameter("@CompanyName", companyName)
                );
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListRS(string companyName)
        {
            // 如果companyName为空，使用默认值
            if (string.IsNullOrEmpty(companyName))
            {
                companyName = "云合未来";
            }

            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合人事管理系统' " +
             "AND gsname = @CompanyName " +
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";

            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(
                    sql,
                    new System.Data.SqlClient.SqlParameter("@CompanyName", companyName)
                );
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListByCompanyAndSystem(string companyName, string systemName)
        {
           
            string sql = "SELECT * FROM product_pushnews " +
                         "WHERE gsname = @CompanyName " +
                         "AND xtname = @SystemName " +
                         "AND ( " +
                         "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
                         "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
                         ")";

            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(
                    sql,
                    new SqlParameter("@CompanyName", companyName),
                    new SqlParameter("@SystemName", systemName)
                );
                return result.ToList();
            }
        }
    }
}