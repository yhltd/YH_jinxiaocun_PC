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

namespace Web
{
    public partial class ming_xi : System.Web.UI.Page
    {
        private static ServicePage page = new ServicePage();
        private static clsuserinfo user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (clsuserinfo)Session["user"];
            page.countPage = this.getCountPage();

            try
            {
                if (user == null)
                {
                    Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
                }
                else
                {
                    if (Session["ming_xi_select_dd"] == null)
                    {
                        this.ming_xi_select(user.name, user.gongsi);
                    }
                    if (Convert.ToInt32(Session["dq_ye_mx_dd"]) == 0)
                    {
                        Session["dq_ye_mx_dd"] = 0;
                    }
                }
            }
            catch (Exception ex) { throw; }


        }
        protected void toExcel(object sender, EventArgs e)
        {

            List<ming_xi_info> gtlist = Session["ming_xi_select_dd"] as List<ming_xi_info>;
            if (gtlist != null)
            {
                StringWriter sw = new StringWriter();

                sw.WriteLine("订单号\t商品代码\t商品名称\t商品类别\t价格\t数量\t明细类型\t时间\t公司名\t收货方");

                foreach (ming_xi_info dr in gtlist)
                {

                    sw.WriteLine(dr.Orderid + "\t" + dr.sp_dm + "\t" + dr.Cpname + "\t" + dr.Cplb + "\t" + dr.Cpsj + "\t" + dr.Cpsl + "\t" + dr.Mxtype + "\t" + dr.Shijian + "\t" + dr.gs_name + "\t" + dr.shou_h);

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
                ming_xi_select(Session["username"].ToString(), Session["gs_name"].ToString());
            }
            catch (Exception ex) { throw; }



        }

        public int getCountPage()
        {
            try
            {
                clsAllnew buiness = new clsBuiness.clsAllnew();
                int allCount = buiness.getPageCount(user.name, user.gongsi);
                return (int)Math.Ceiling(Convert.ToDouble((float)allCount / (float)page.pageCount));
            }
            catch (Exception ex) { throw; }
        }

        public void ming_xi_select(string zh_name, string gs_name)
        {
            try
            {
                clsAllnew buiness = new clsBuiness.clsAllnew();
                List<ming_xi_info> list = buiness.ming_xi_select(zh_name, gs_name, page.getLimit1(), page.getLimit2());
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }

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
                this.ming_xi_select(user.name, user.gongsi);
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
                this.ming_xi_select(user.name, user.gongsi);
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
                this.ming_xi_select(user.name, user.gongsi);
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
                this.ming_xi_select(user.name, user.gongsi);
                Response.Write("<script language=javascript>window.location.href=document.URL;</script>");
            }
        }

        public List<ming_xi_info> select_row()
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ru_ku_select_row();
            return list;
        }

        protected void rq_select(object sender, EventArgs e)
        {

            try
            {
                List<ming_xi_info> list = ri_qi_select(Context.Request["time_qs"].ToString(), Context.Request["time_jz"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }

        }

        public List<ming_xi_info> ri_qi_select(string time_qs, string time_jz, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ri_qi_select(time_qs, time_jz, zh_name, gs_name);
            return list;
        }
    }
}