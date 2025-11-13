using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.JxcServer;
using MySql.Data.MySqlClient; 

namespace Web.Server
{
    public class JinHuoModel
    {

        //public List<string> getGongHuo(string gs_name)
        //{
        //    using (ServerEntities sen = new ServerEntities())
        //    {
        //        var gongsiParam = new MySqlParameter("@gongsi", gs_name);

        //        string sql = "select beizhu from yh_jinxiaocun_jinhuofang where gongsi = @gongsi";

        //        var result = sen.Database.SqlQuery<yh_jinxiaocun_jinhuofang>(sql, gongsiParam);
        //        List<yh_jinxiaocun_jinhuofang> list = result.ToList();
        //        List<string> beizhuList = new List<string>();
        //        foreach (yh_jinxiaocun_jinhuofang jin in list)
        //        {
        //            beizhuList.Add(jin.beizhu);
        //        }
        //        return beizhuList;
        //    }
        //}
        public List<string> getGongHuo(string gs_name)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["shujuku"] != null)
            {
                int shujukuValue = (int)HttpContext.Current.Session["shujuku"];

                if (shujukuValue == 0) // MySQL
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
                else if (shujukuValue == 1) // SQL Server
                {
                    using (yh_jinxiaocun_excelEntities3 sen = new yh_jinxiaocun_excelEntities3())
                    {
                        var gongsiParam = new System.Data.SqlClient.SqlParameter("@gongsi", gs_name);
                        string sql = "select beizhu from yh_jinxiaocun_jinhuofang_mssql where gongsi = @gongsi";
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

            // 默认使用MySQL数据库
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