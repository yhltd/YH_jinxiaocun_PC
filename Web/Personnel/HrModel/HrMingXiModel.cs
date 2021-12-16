using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web.Personnel.HrModel
{
    public class HrMingXiModel
    {

        public List<gongzi_gongzimingxi> getTiao(string a,string b, string c, string d,string e) {
            using (yaoEntities y = new yaoEntities()) {
                var @params = new SqlParameter[]{
                    new SqlParameter("@a", a),
                    new SqlParameter("@b", b),
                    new SqlParameter("@c", c),
                    new SqlParameter("@d", d),
                    new SqlParameter("@e", e)
                };

                string sql = "SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = '" + @a + "') AND ([C] like '%" + @b + "%') AND ([D] like '%" + @c + "%') AND (Year([F]) like '%" + @d + "')";
                if (@d != "")
                {
                    sql = sql + " AND (Month([F]) = '"+  @e +"'))";
                }
                else {
                    sql = sql + ")";
                }
                var result = y.Database.SqlQuery<gongzi_gongzimingxi>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_gongzimingxi> gongzitiao_list(string a)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@a", a),
                };

                string sql = "SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] = '" + @a + "')";
                var result = y.Database.SqlQuery<gongzi_gongzimingxi>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_kaoqinjilu> kaoqin_list(string a)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@a", a),
                };

                string sql = "SELECT * FROM [gongzi_kaoqinjilu] WHERE ([AO] = '" + @a + "')";
                var result = y.Database.SqlQuery<gongzi_kaoqinjilu>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_gongzimingxi> gongzi_list(string a)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@a", a),
                };

                string sql = "SELECT * FROM [gongzi_gongzimingxi] WHERE ([BD] = '" + @a + "')";
                var result = y.Database.SqlQuery<gongzi_gongzimingxi>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_kaoqinmingxi> kaoqin_mingxi_list(string a)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@a", a),
                };

                string sql = "SELECT * FROM [gongzi_kaoqinmingxi] WHERE ([K] = '" + @a + "')";
                var result = y.Database.SqlQuery<gongzi_kaoqinmingxi>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_gongzimingxi> baopan_list(string a)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@a", a),
                };

                string sql = "select * FROM gongzi_gongzimingxi WHERE ([BD]like '%" + @a + "%')";
                var result = y.Database.SqlQuery<gongzi_gongzimingxi>(sql, @params);
                return result.ToList();
            }
        }
    }
}