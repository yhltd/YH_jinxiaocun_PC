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

                string sql = "SELECT * FROM [gongzi_gongzimingxi] WHERE (([BD] = '" + @a + "') AND ([C] like '%" + @b + "%') AND ([D] like '%" + @c + "%') AND (Year([BC]) like '%" + @d + "')";
                if (@d != "")
                {
                    sql = sql + " AND (Month([BC]) = '"+  @e +"'))";
                }
                else {
                    sql = sql + ")";
                }
                var result = y.Database.SqlQuery<gongzi_gongzimingxi>(sql, @params);
                return result.ToList();
            }
        }
    }
}