using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class ShouHuoModel
    {
        public List<string> getShouHuo(string gs_name)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gs_name);

                string sql = "select beizhu from yh_jinxiaocun_chuhuofang where gongsi = @gongsi";

                var result = sen.Database.SqlQuery<yh_jinxiaocun_chuhuofang>(sql, gongsiParam);
                List<yh_jinxiaocun_chuhuofang> list = result.ToList();
                List<string> beizhuList = new List<string>();
                foreach (yh_jinxiaocun_chuhuofang chu in list)
                {
                    beizhuList.Add(chu.beizhu);
                }
                return beizhuList;
            }
        }
    }
}