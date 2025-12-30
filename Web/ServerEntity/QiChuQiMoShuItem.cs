using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.ServerEntity
{
    public class QiChuQiMoShuItem
    {
        // 基础信息
        public int id { get; set; }
        public string sp_dm { get; set; }      // 商品代码
        public string name { get; set; }       // 商品名称
        public string lei_bie { get; set; }    // 商品类别
        public string mark1 { get; set; }      // 图片

        // 价格信息
        public decimal unit_price { get; set; }  // 售价 (cpsj)

        // 期初数据（起始日期）
        public decimal qichu_shuliang { get; set; }    // 期初数量
        public decimal qichu_jine { get; set; }        // 期初金额

        // 期末数据（截止日期）
        public decimal qimo_shuliang { get; set; }     // 期末数量
        public decimal qimo_jine { get; set; }         // 期末金额
    }
}