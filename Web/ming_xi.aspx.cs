using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SDZdb;
using System.ComponentModel;
using System.Configuration;
using Order.Common;
using clsBuiness;
using System.Reflection;
using System.IO;
using Web.jxc_service;
using Web.Server;

namespace Web
{
    public partial class ming_xi : System.Web.UI.Page
    {
        private static ServicePage page = new ServicePage();
        private static yh_jinxiaocun_user user;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
            }

            if (user != null)
            {
                try
                {
                    page.countPage = this.getCountPage();
                    List<yh_jinxiaocun_mingxi> list = Session["ming_xi_select_dd"] as List<yh_jinxiaocun_mingxi>;
                    if (list == null)
                    {
                        this.ming_xi_select(user.gongsi);
                    }
                    if (Convert.ToInt32(Session["dq_ye_mx_dd"]) == 0)
                    {
                        Session["dq_ye_mx_dd"] = 0;
                    }
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }

            page.nowPage = 1;
            ming_xi_select(user.gongsi);
        }
        protected void toExcel(object sender, EventArgs e)
        {

            List<yh_jinxiaocun_mingxi> list = ri_qi_select(string.Empty, string.Empty, user.gongsi);
            if (list != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("订单号\t商品代码\t商品名称\t商品类别\t价格\t数量\t明细类型\t时间\t公司名\t收货方");

                foreach (yh_jinxiaocun_mingxi mingxi in list)
                {

                    sw.WriteLine(mingxi.orderid + "\t" + mingxi.sp_dm + "\t" + mingxi.cpname + "\t" + mingxi.cplb + "\t" + mingxi.cpsj + "\t" + mingxi.cpsl + "\t" + mingxi.mxtype + "\t" + mingxi.shijian + "\t" + mingxi.gongsi + "\t" + mingxi.shou_h);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=明细.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
            }
            else
            {
                Response.Write(" <script>alert('保存失败'); location='ming_xi.aspx';</script>");
            }

        }
        protected void bt_select_Click(object sender, EventArgs e)
        {

            try
            {
                page.nowPage = 1;
                ming_xi_select(user.gongsi);
            }
            catch
            {
                Session["ming_xi_select_dd"] = null;
            }
        }

        protected void shuaxin()
        {

            try
            {
                page.nowPage = 1;
                ming_xi_select(user.gongsi);
            }
            catch
            {
                Session["ming_xi_select_dd"] = null;
            }
        }

        public int getCountPage()
        {
            MingxiModel mingxi = new MingxiModel();
            int allCount = mingxi.getPageCount(user.gongsi);
            return (int)Math.Ceiling(Convert.ToDouble((float)allCount / (float)page.pageCount));
        }

        public void ming_xi_select(string gs_name)
        {
            MingxiModel buiness = new MingxiModel();
            Session["ming_xi_select_dd"] = buiness.ming_xi_select(gs_name, page.getLimit1(), page.getLimit2());
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
            }
            else
            {
                page.nowPage = 1;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
            }
            else
            {
                page.nowPage--;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            if (page.countPage < (page.nowPage + 1))
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
            }
            else
            {
                page.nowPage++;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }

        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == page.countPage)
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
            }
            else
            {
                page.nowPage = page.countPage;
                this.ming_xi_select(user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        protected void rq_select(object sender, EventArgs e)
        {

            try
            {
                Session["ming_xi_select_dd"] = ri_qi_select(Context.Request["time_qs"].ToString(), Context.Request["time_jz"].ToString(), user.gongsi);
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }

        }

        public List<yh_jinxiaocun_mingxi> ri_qi_select(string time_qs, string time_jz, string gs_name)
        {
            if (time_qs.Equals(string.Empty))
            {
                time_qs = "1999-01-01";
            }
            if (time_jz.Equals(string.Empty))
            {
                time_jz = "2999-12-31";
            }

            MingxiModel mingxi = new MingxiModel();
            return mingxi.ri_qi_select(time_qs, time_jz, gs_name);
        }

        protected void del_mingxi(object sender, EventArgs e)
        {
            MingxiModel mingxi = new MingxiModel();
            Boolean result = true;
            try
            {
                List<yh_jinxiaocun_mingxi> list = Session["ming_xi_select_dd"] as List<yh_jinxiaocun_mingxi>;
                for (int i = 0; i < list.Count; i++)
                {
                    string name = Request["Checkbox_bd" + i];
                    if (name != null)
                    {
                        if (Convert.ToInt32(name) == i)
                        {
                            result = mingxi.del_mingxi(list[i]._id) > 0;
                        }
                    }
                }
                if (result)
                {
                    shuaxin();
                    Response.Write("<script>alert('删除成功');</script>");
                }
            }
            catch
            {
                Response.Write(" <script>alert('网络错误，请稍后再试！');</script>");
            }
        }
    }
}