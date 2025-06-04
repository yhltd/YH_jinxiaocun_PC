using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Server;

namespace Web.ServerEntity
{
    public class MingXiItem : yh_jinxiaocun_mingxi
    {
        public int ruku_num { get; set; }
        public decimal ruku_price { get; set; }
        public int chuku_num { get; set; }
        public decimal chuku_price { get; set; }
    }
}