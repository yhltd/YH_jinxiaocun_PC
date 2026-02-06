using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.scheduling.model
{
    public class WorkDetailDTO
    {
        // work_detail 字段
        public int Id { get; set; }
        public System.DateTime kaishishijian { get; set; }
        public Nullable<int> charu { get; set; }
        public string dingdanleixing { get; set; }
        public Nullable<System.DateTime> jiezhishijian { get; set; }

        // order_gongxu 字段
        public Nullable<int> gongxushuliang { get; set; }

        // module_info 字段
        public string gongxumingcheng { get; set; }
        public Nullable<double> gongxuxiaolv { get; set; }

        // order_info 字段
        public string dingdanhao { get; set; }
        public string dingdanmingcheng { get; set; }
    }
}