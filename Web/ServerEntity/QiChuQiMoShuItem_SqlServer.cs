using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.ServerEntity
{
    public class QiChuQiMoShuItem_SqlServer
    {
        public int id { get; set; }
        public string sp_dm { get; set; }
        public string name { get; set; }
        public string lei_bie { get; set; }
        public string mark1 { get; set; }
        public string qichu_shuliang { get; set; }  // 接收 varchar
        public string qichu_jine { get; set; }       // 接收 varchar
        public string qimo_shuliang { get; set; }    // 接收 varchar
        public string qimo_jine { get; set; }        // 接收 varchar
    }
}