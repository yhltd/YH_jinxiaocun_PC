using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ServerEntity;

namespace Web.Server
{
    public class JinChuModel
    {

        public List<JinChuZiLiaoItem> getSetStockDetail(string gongsi)
        {
            List<zl_and_jc_info> list = new List<zl_and_jc_info>();

            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);

                string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '入库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                return result.ToList();
            }
        }


        public List<JinChuZiLiaoItem> getOutStockDetail(string gongsi)
        {

            List<zl_and_jc_info> list = new List<zl_and_jc_info>();

            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);

                string sql = "select *,IFNULL((select sum(CASE mxtype WHEN '出库' THEN cpsl ELSE (cpsl*-1) END) as cpsl from yh_jinxiaocun_mingxi where cpname = j.name and gs_name = @gongsi),0) as maxNum from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<JinChuZiLiaoItem>(sql, gongsiParam);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_jichuziliao> getList(string gongsi) {
            List<zl_and_jc_info> list = new List<zl_and_jc_info>();

            using (ServerEntities sen = new ServerEntities())
            {
                var gongsiParam = new MySqlParameter("@gongsi", gongsi);

                string sql = "select * from yh_jinxiaocun_jichuziliao as j where gs_name = @gongsi";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_jichuziliao>(sql, gongsiParam);
                return result.ToList();
            }
        }

        public int delete(int id) {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM Yh_JinXiaoCun_jichuziliao WHERE id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int add(List<yh_jinxiaocun_jichuziliao> list) {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                foreach (yh_jinxiaocun_jichuziliao item in list)
                {
                    sql += "insert into Yh_JinXiaoCun_jichuziliao(sp_dm,name,lei_bie,dan_wei,shou_huo,gong_huo,zh_name,gs_name) values ('" + item.sp_dm + "','" + item.name + "','" + item.lei_bie + "','" + item.dan_wei + "','" + item.shou_huo + "','" + item.gong_huo + "','" + item.zh_name + "','" + item.gs_name + "');";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int update(string sp_dm, string name, string lei_bie, string dan_wei, string shou_huo, string gong_huo, string id)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE Yh_JinXiaoCun_jichuziliao SET sp_dm = '" + sp_dm + "',name = '" + name + "',lei_bie = '" + lei_bie + "' ,dan_wei = '" + dan_wei + "' ,shou_huo = '" + shou_huo + "' ,gong_huo = '" + gong_huo + "' WHERE id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}