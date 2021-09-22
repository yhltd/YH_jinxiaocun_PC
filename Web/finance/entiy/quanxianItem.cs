using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.finance.model;

namespace Web.finance.entiy
{
    /// <author>
    /// dai
    /// </author>
    public class quanxianItem : quanxian
    {
        //行号
        public Int64 rownum { get; set; }

        public quanxian getParent()
        {
            quanxian quanxian = new quanxian();
            quanxian.id = this.id;
            quanxian.kmzz_add = this.kmzz_add;
            quanxian.kmzz_delete = this.kmzz_delete;
            quanxian.kmzz_update = this.kmzz_update;
            quanxian.kmzz_select = this.kmzz_select;
            quanxian.kzxm_add = this.kzxm_add;
            quanxian.kzxm_delete = this.kzxm_delete;
            quanxian.kzxm_update = this.kzxm_update;
            quanxian.kzxm_select = this.kzxm_select;
            quanxian.bmsz_add = this.bmsz_add;
            quanxian.bmsz_delete = this.bmsz_delete;
            quanxian.bmsz_update = this.bmsz_update;
            quanxian.bmsz_select = this.bmsz_select;
            quanxian.zhgl_add = this.zhgl_add;
            quanxian.zhgl_delete = this.zhgl_delete;
            quanxian.zhgl_update = this.zhgl_update;
            quanxian.zhgl_select = this.zhgl_select;
            quanxian.pzhz_add = this.pzhz_add;
            quanxian.pzhz_delete = this.pzhz_delete;
            quanxian.pzhz_update = this.pzhz_update;
            quanxian.pzhz_select = this.pzhz_select;
            quanxian.znkb_select = this.znkb_select;
            quanxian.xjll_select = this.xjll_select;
            quanxian.zcfz_select = this.zcfz_select;
            quanxian.lysy_select = this.lysy_select;
            quanxian.jjtz_add = this.jjtz_add;
            quanxian.jjtz_delete = this.jjtz_delete;
            quanxian.jjtz_update = this.jjtz_update;
            quanxian.jjtz_select = this.jjtz_select;
            quanxian.jjzz_add = this.jjzz_add;
            quanxian.jjzz_delete = this.jjzz_delete;
            quanxian.jjzz_update = this.jjzz_update;
            quanxian.jjzz_select = this.jjzz_select;

            return quanxian;
        }
    }
}