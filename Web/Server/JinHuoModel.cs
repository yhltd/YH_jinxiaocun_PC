using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class JinHuoModel
    {

        public List<string> getGongHuo(string gs_name)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gs_name);

                string sql = "select beizhu from yh_jinxiaocun_jinhuofang where gongsi = @gongsi";

                var result = sen.Database.SqlQuery<yh_jinxiaocun_jinhuofang>(sql, gongsiParam);
                List<yh_jinxiaocun_jinhuofang> list = result.ToList();
                List<string> beizhuList = new List<string>();
                foreach (yh_jinxiaocun_jinhuofang jin in list)
                {
                    beizhuList.Add(jin.beizhu);
                }
                return beizhuList;
            }
        }
    }
}