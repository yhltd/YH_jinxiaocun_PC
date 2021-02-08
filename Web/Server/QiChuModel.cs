using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Server
{
    public class QiChuModel
    {

        public List<yh_jinxiaocun_qichushu> getQiChu(string gs_name)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                var gsParam = new MySqlParameter("@gs", gs_name);
                string sql = "select * from yh_jinxiaocun_qichushu where gs_name = @gs";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql, gsParam);
                return result.ToList();
            }
        }

        public int add_qichu(List<qi_chu_info> qci)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "";
                foreach (qi_chu_info item in qci)
                {
                    sql += "insert into Yh_JinXiaoCun_qichushu(_openid,cpid,cpjg,cpjj,cplb,cpname,cpsj,cpsl,mxtype,shijian,zh_name,gs_name) values ('" + item.Openid + "','" + item.Cpid + "','" + item.Cpjg + "','" + item.Cpjj + "','" + item.Cplb + "','" + item.Cpname + "','" + item.Cpsj + "','" + item.Cpsl + "','" + item.Mxtype + "','" + item.Shijian + "','" + item.zh_name + "','" + item.gs_name + "');";
                }
                return sen.Database.ExecuteSqlCommand(sql);
            }

        }

        public int update_qichu(string id, string cpid, string cpname, string cplb, string cpsj, string cpsl)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "UPDATE Yh_JinXiaoCun_qichushu SET cpid = '" + cpid + "',cplb = '" + cplb + "',cpname = '" + cpname + "',cpsj = '" + cpsj + "' ,cpsl = '" + cpsl + "' WHERE _id = '" + id + "'";
                return sen.Database.ExecuteSqlCommand(sql);
            }
        }

        public int del_qichu_ff(int cpid)
        {
            using (ServerEntities sen = new ServerEntities())
            {
                string sql = "DELETE FROM Yh_JinXiaoCun_qichushu WHERE _id = '" + cpid + "'";
                return sen.Database.ExecuteSqlCommand(sql); ;
            }

        }

        public List<yh_jinxiaocun_qichushu> ming_xi_fenye(int yi_c, int er_c, string gs_name)
        {
            using (ServerEntities sen = new ServerEntities()) {
                string sql = "select * from Yh_JinXiaoCun_qichushu where gs_name = '" + gs_name + "' limit " + yi_c + "," + er_c + "";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql);
                return result.ToList();
            }
        }

        public List<yh_jinxiaocun_qichushu> qi_chu_select_row(string gs_name)
        {
            using (ServerEntities sen = new ServerEntities()) {
                string sql = "SELECT cpid FROM Yh_JinXiaoCun_qichushu where gs_name = '" + gs_name + "'";
                var result = sen.Database.SqlQuery<yh_jinxiaocun_qichushu>(sql);
                return result.ToList();
            }
        }
    }
}
