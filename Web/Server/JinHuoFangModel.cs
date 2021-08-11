using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class JinHuoFangModel
    {
        public List<yh_jinxiaocun_jinhuofang> getList(string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_jinhuofang where gongsi = '" + gongsi + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_jinhuofang>(sql);
                return result.ToList();
            }
        }

        public int delete(int id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_jinhuofang where _id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int add(List<yh_jinxiaocun_jinhuofang> list)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                foreach (yh_jinxiaocun_jinhuofang item in list)
                {
                    sql += "insert into yh_jinxiaocun_jinhuofang(beizhu,lianxidizhi,lianxifangshi,finduser,gongsi) values ('" + item.beizhu + "','" + item.lianxidizhi + "','" + item.lianxifangshi + "','" + item.finduser + "','" + item.gongsi + "');";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int update(string beizhu, string lianxidizhi, string lianxifangshi, string id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_jinhuofang SET beizhu = '" + beizhu + "',lianxidizhi = '" + lianxidizhi + "',lianxifangshi = '" + lianxifangshi + "'  WHERE _id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}