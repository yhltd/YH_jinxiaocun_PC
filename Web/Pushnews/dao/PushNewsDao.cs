using System;
using System.Collections.Generic;
using System.Linq;
using Web.Pushnews.model;

namespace Web.Pushnews.dao
{
    public class PushNewsDao
    {

        public List<product_pushnews> SelectList()
        {
            //string sql = "SELECT * FROM product_pushnews WHERE xtname = '云合未来进销存系统' AND gsname = '云合未来' ";
            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合未来进销存系统' " +
             "AND gsname = '云合未来' " +
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";
            using (var se = new yh_noticeEntities1()) 
            {
                var result = se.Database.SqlQuery<product_pushnews>(sql);
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListCW()
        {
            //string sql = "SELECT * FROM product_pushnews WHERE xtname = '云合未来财务系统' AND gsname = '云合未来' ";
            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合未来财务系统' " +
             "AND gsname = '云合未来' " +
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";
            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(sql);
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListPC()
        {
            //string sql = "SELECT * FROM product_pushnews WHERE xtname = '云合排产管理系统' AND gsname = '云合未来' ";
            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合排产管理系统' " +
             "AND gsname = '云合未来' " +
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";
            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(sql);
                return result.ToList();
            }
        }

        public List<product_pushnews> SelectListRS()
        {
            //string sql = "SELECT * FROM product_pushnews WHERE xtname = '云合人事管理系统' AND gsname = '云合未来' ";
            string sql = "SELECT * FROM product_pushnews " +
             "WHERE xtname = '云合人事管理系统' " +
             "AND gsname = '云合未来' " +
             "AND ( " +
             "   (qidate IS NULL OR GETUTCDATE() >= CONVERT(DATETIME, LEFT(qidate, 10), 120)) " +
             "   AND (zhidate IS NULL OR GETUTCDATE() <= CONVERT(DATETIME, LEFT(zhidate, 10), 120)) " +
             ")";
            using (var se = new yh_noticeEntities1())
            {
                var result = se.Database.SqlQuery<product_pushnews>(sql);
                return result.ToList();
            }
        }
    }
}