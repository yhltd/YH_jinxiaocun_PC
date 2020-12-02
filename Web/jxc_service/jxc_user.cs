using MySql.Data.MySqlClient;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Web.jxc_service
{
    public class jxc_user
    {
        private static string sqlStr = "";
        private Order.Common.MySqlHelper ms = null;

        public jxc_user()
        {
            sqlStr = ConfigurationManager.AppSettings["服务器_jxc"].ToString();
        }

        public int loginAndGetUser(string name, string pwd, string company)
        {
            string sql = "select * from yh_jinxiaocun_user where name = '" + name + "' and password = '" + pwd + "' and gongsi = '" + company + "'";
            ms = new Order.Common.MySqlHelper(sqlStr);
            MySqlDataReader read = ms.ExecuteReader(sql);
            if (read.HasRows)
            {
                clsuserinfo user = new clsuserinfo();
                while (read.Read())
                {
                    user.Order_id = read["_id"].ToString();
                    user.AdminIS = read["AdminIS"].ToString();
                    user.Btype = read["Btype"].ToString();
                    user.Createdate = read["Createdate"].ToString();
                    user.gongsi = read["gongsi"].ToString();
                    user.jigoudaima = read["jigoudaima"].ToString();
                    user.name = read["name"].ToString();
                    user.password = read["password"].ToString();
                    user.mibao = read["mi_bao"].ToString();
                    user.denglushijian = DateTime.Now.ToString();
                }
                if (user.Btype.Equals("锁定"))
                {
                    return -1;
                }
                System.Web.HttpContext.Current.Session["user"] = user;
            }

            return read.HasRows ? 1 : 0;
        }
    }
}