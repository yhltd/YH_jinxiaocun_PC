using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class ZhengLiModel
    {

        public List<yh_jinxiaocun_zhengli> getList(string gongsi)
        {
            using (ServerEntities sen = new ServerEntities())
            { 
                string sql = "select * from yh_jinxiaocun_zhengli where gs_name = '" + gongsi + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_zhengli>(sql);
                return result.ToList();
            }
        }

        public int delete(int id) {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "delete from yh_jinxiaocun_zhengli where id = '"+ id +"'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int add(List<yh_jinxiaocun_zhengli> list)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                foreach (yh_jinxiaocun_zhengli item in list)
                {
                    sql += "insert into Yh_JinXiaoCun_zhengli(sp_dm,name,lei_bie,dan_wei,zh_name,gs_name) values ('" + item.sp_dm + "','" + item.name + "','" + item.lei_bie + "','" + item.dan_wei + "','" + item.zh_name + "','" + item.gs_name + "');";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int update(string sp_dm, string name, string lei_bie, string dan_wei, string id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE Yh_JinXiaoCun_zhengli SET sp_dm = '" + sp_dm + "',name = '" + name + "',lei_bie = '" + lei_bie + "' ,dan_wei = '" + dan_wei + "' WHERE id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}