using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class ChuHuoFangModel
    {
        public List<yh_jinxiaocun_chuhuofang> getList(string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = '" + gongsi + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_chuhuofang> getList_chaxun(string gongsi,string beizhu)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "select * from yh_jinxiaocun_chuhuofang where gongsi = '" + gongsi + "' and beizhu like '%"+ beizhu +"%'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql);
                return result.ToList();
            }
        }

        public int delete(int id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_chuhuofang where _id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int add(List<yh_jinxiaocun_chuhuofang> list)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                foreach (yh_jinxiaocun_chuhuofang item in list)
                {
                    sql += "insert into yh_jinxiaocun_chuhuofang(beizhu,lianxidizhi,lianxifangshi,finduser,gongsi) values ('" + item.beizhu + "','" + item.lianxidizhi + "','" + item.lianxifangshi + "','" + item.finduser + "','" + item.gongsi + "');";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int update(string beizhu, string lianxidizhi, string lianxifangshi,string id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE yh_jinxiaocun_chuhuofang SET beizhu = '" + beizhu + "',lianxidizhi = '" + lianxidizhi + "',lianxifangshi = '" + lianxifangshi + "'  WHERE _id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}