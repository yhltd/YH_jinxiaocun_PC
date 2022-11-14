using SDZdb;
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

        public List<gongzi_kaoqinjilu> getKaoQin(string gongsi)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@AO", gongsi),
                };

                string sql = "select * FROM gongzi_kaoqinjilu WHERE ([AO]like '%" + @gongsi + "%')";
                var result = y.Database.SqlQuery<gongzi_kaoqinjilu>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_kaoqinjilu> getKaoQinQuery(string gongsi,string ks,string js)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@AO", gongsi),
                    new SqlParameter("@ks", ks),
                    new SqlParameter("@js", js),
                };

                string sql = "select * FROM gongzi_kaoqinjilu WHERE ([AO]like '%" + @gongsi + "%') AND (convert(int,[year]+moth) >= @ks) AND (convert(int,[year]+moth) <= @js)";
                var result = y.Database.SqlQuery<gongzi_kaoqinjilu>(sql, @params);
                return result.ToList();
            }
        }
        //SELECT C,BD,count(id) AS ID,SUM(CAST(G AS float)) AS G,SUM(CAST(H AS float)) AS H,SUM(CAST(I AS float)) AS I,SUM(CAST(J AS float)) AS J,SUM(CAST(K AS float)) AS K,SUM(CAST(L AS float)) AS  L,SUM(CAST(M AS float)) AS M,SUM(CAST(N AS float)) AS N,SUM(CAST(O AS float)) AS O,SUM(CAST(P AS float)) AS P,SUM(CAST(Q AS float)) AS Q,SUM(CAST(R AS float)) AS R,SUM(CAST(S AS float)) AS S,SUM(CAST(T AS float)) AS T,SUM(CAST(U AS float)) AS U,SUM(CAST(V AS float)) AS V,SUM(CAST(W AS float)) AS W,SUM(CAST(X AS float)) AS X,SUM(CAST(Y AS float)) AS Y,SUM(CAST(Z AS float)) AS Z,SUM(CAST(AA AS float)) AS AA,SUM(CAST(AB AS float)) AS AB,SUM(CAST(AC AS float)) AS AC,SUM(CAST(AD AS float)) AS AD,SUM(CAST(AE AS float)) AS AE,SUM(CAST(AF AS float)) AS AF,SUM(CAST(AG AS float)) AS AG,SUM(CAST(AH AS float)) AS AH,SUM(CAST(AI AS float)) AS AI,SUM(CAST(AJ AS float)) AS AJ,SUM(CAST(AK AS float)) AS AK,SUM(CAST(AL AS float)) AS AL,SUM(CAST(AM AS float)) AS AM,SUM(CAST(AN AS float)) AS AN,SUM(CAST(AO AS float)) AS AO,SUM(CAST(AP AS float)) AS AP,SUM(CAST(AQ AS float)) AS AQ,SUM(CAST(AR AS float)) AS AR,SUM(CAST(ASA AS float)) AS ASA,SUM(CAST(ATA AS float)) AS ATA,SUM(CAST(AU AS float)) AS AU,SUM(CAST(AV AS float)) AS AV,SUM(CAST(AW AS float)) AS AW,SUM(CAST(AX AS float)) AS AX,SUM(CAST(AY AS float)) AS AY FROM gongzi_gongzimingxi WHERE [BD] like '%'+ @BD +'%'  GROUP BY c,bd

        public List<bumenExcel> bumenToExcel(String gongsi) 
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@BD", gongsi),
                };

                string sql = "SELECT C,count(id) AS ID,SUM(CAST(G AS float)) AS G,SUM(CAST(H AS float)) AS H,SUM(CAST(I AS float)) AS I,SUM(CAST(J AS float)) AS J,SUM(CAST(K AS float)) AS K,SUM(CAST(L AS float)) AS  L,SUM(CAST(M AS float)) AS M,SUM(CAST(N AS float)) AS N,SUM(CAST(O AS float)) AS O,SUM(CAST(P AS float)) AS P,SUM(CAST(Q AS float)) AS Q,SUM(CAST(R AS float)) AS R,SUM(CAST(S AS float)) AS S,SUM(CAST(T AS float)) AS T,SUM(CAST(U AS float)) AS U,SUM(CAST(V AS float)) AS V,SUM(CAST(W AS float)) AS W,SUM(CAST(X AS float)) AS X,SUM(CAST(Y AS float)) AS Y,SUM(CAST(Z AS float)) AS Z,SUM(CAST(AA AS float)) AS AA,SUM(CAST(AB AS float)) AS AB,SUM(CAST(AC AS float)) AS AC,SUM(CAST(AD AS float)) AS AD,SUM(CAST(AE AS float)) AS AE,SUM(CAST(AF AS float)) AS AF,SUM(CAST(AG AS float)) AS AG,SUM(CAST(AH AS float)) AS AH,SUM(CAST(AI AS float)) AS AI,SUM(CAST(AJ AS float)) AS AJ,SUM(CAST(AK AS float)) AS AK,SUM(CAST(AL AS float)) AS AL,SUM(CAST(AM AS float)) AS AM,SUM(CAST(AN AS float)) AS AN,SUM(CAST(AO AS float)) AS AO,SUM(CAST(AP AS float)) AS AP,SUM(CAST(AQ AS float)) AS AQ,SUM(CAST(AR AS float)) AS AR,SUM(CAST(ASA AS float)) AS ASA,SUM(CAST(ATA AS float)) AS ATA,SUM(CAST(AU AS float)) AS AU,SUM(CAST(AV AS float)) AS AV,SUM(CAST(AW AS float)) AS AW,SUM(CAST(AX AS float)) AS AX,SUM(CAST(AY AS float)) AS AY FROM gongzi_gongzimingxi WHERE [BD] like '%"+ @gongsi +"%'  GROUP BY c,bd";
                var result = y.Database.SqlQuery<bumenExcel>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_renyuan> getListByRenYuan(string gongsi,string yue,string ri) 
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@L", gongsi),
                    new SqlParameter("@B", yue),
                    new SqlParameter("@C", ri),
                };

                string sql = "SELECT * from gongzi_renyuan where [L] like '%" + @gongsi + "%' and month(convert(date,Q))='" + @yue + "' and day(convert(date,Q))='" + @ri + "'  ";
                var result = y.Database.SqlQuery<gongzi_renyuan>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_renyuan> getRenYuanInfo(string gongsi, string name)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@L", gongsi),
                    new SqlParameter("@B", name),
                };

                string sql = "SELECT top 1 * from gongzi_renyuan where [L] like '%" + @gongsi + "%' and B='" + @name + "' ";
                var result = y.Database.SqlQuery<gongzi_renyuan>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_kaoqinjilu> getKaoQinByName(string gongsi, string name,string yue)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@AO", gongsi),
                    new SqlParameter("@name", name),
                    new SqlParameter("@yue", yue),
                };

                string sql = "SELECT top 1 * from gongzi_kaoqinjilu where [AO] like '%" + @gongsi + "%' and name='" + @name + "' and moth='" + @yue + "' ";
                var result = y.Database.SqlQuery<gongzi_kaoqinjilu>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_renyuan> getRenYuanById(string gongsi, string id)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@L", gongsi),
                    new SqlParameter("@id", id),
                };

                string sql = "SELECT top 1 * from gongzi_renyuan where [L] like '%" + @gongsi + "%' and id='" + @id + "' ";
                var result = y.Database.SqlQuery<gongzi_renyuan>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_peizhi> getPeizhi(string gongsi)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@gongsi", gongsi),
                };

                string sql = "SELECT * from gongzi_peizhi where gongsi like '%" + @gongsi + "%' ";
                var result = y.Database.SqlQuery<gongzi_peizhi>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_gongzimingxi> getBaoPan(string gongsi,string ks,string js)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@gongsi", gongsi),
                    new SqlParameter("@ks", ks),
                    new SqlParameter("@js", js),
                };

                string sql = "SELECT * from gongzi_gongzimingxi where BD like '%" + @gongsi + "%' and convert(date,BC)>='" + @ks + "' and convert(date,BC)<='" + @js + "' ";
                var result = y.Database.SqlQuery<gongzi_gongzimingxi>(sql, @params);
                return result.ToList();
            }
        }

        public List<gongzi_renyuan> getBirthday(string gongsi, string birthday)
        {
            using (yaoEntities y = new yaoEntities())
            {
                var @params = new SqlParameter[]{
                    new SqlParameter("@gongsi", gongsi),
                    new SqlParameter("@birthday", birthday),
                };

                string sql = "SELECT * from gongzi_renyuan where L like '%" + @gongsi + "%' and convert(date,Q)='" + @birthday + "' ";
                var result = y.Database.SqlQuery<gongzi_renyuan>(sql, @params);
                return result.ToList();
            }
        }
    }
}