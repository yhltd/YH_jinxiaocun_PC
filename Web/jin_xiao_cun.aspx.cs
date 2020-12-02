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
    public partial class jin_xiao_cun : System.Web.UI.Page
    {
        private static ServicePage page = new ServicePage();

        protected void Page_Load(object sender, EventArgs e)
        {
            page.countPage = this.getCountPage();

            if (Session["username"] == null && Session["gs_name"] == null) 
            {
                Response.Write("<script>alert('请登录！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
            else
            {
                shuaxin();
            }
            
        }

       

        protected void jxc_load(object sender, EventArgs e)
        {
            shuaxin();
        }

        private void shuaxin() {
            try
            {
                clsAllnew buiness = new clsBuiness.clsAllnew();
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                page.nowPage = 1;
                List<jxc_z_info> list = buiness.jxc_z_select(username, gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
            }
            catch (Exception ex) { throw; }
        }

        protected void toExcel(object sender, EventArgs e)
        {
            List<jxc_z_info> gtlist = Session["jxc_z_select"] as List<jxc_z_info>;
            StringWriter sw = new StringWriter();
            if (gtlist != null)
            {
                sw.WriteLine("商品代码\t商品名称\t商品类别\t期初数量\t期初金额\t进货数量\t进货金额\t出库数量\t出库金额\t结存\t结存金额\t边缘存量");

                foreach (jxc_z_info dr in gtlist)
                {

                    sw.WriteLine(dr.code + "\t" + dr.name + "\t" + dr.type + "\t" + dr.num1 + "\t" + dr.price1 + "\t" + dr.num2 + "\t" + dr.price2 + "\t" + dr.num3 + "\t" + dr.price3 + "\t" + dr.num4 + "\t" + dr.price4 + "\t" + dr.stock);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=进销存.xls");

                Response.ContentType = "application/ms-excel";

                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

                Response.Write(sw);

                Response.End();
                Response.Write(" <script>alert('保存成功'); location='ming_xi.aspx';</script>");
            }
            else
            {
                Response.Write(" <script>alert('保存失败'); location='ming_xi.aspx';</script>");
            }
        }

        protected void jxc_select(object sender, EventArgs e)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            string username = Session["username"].ToString();
            string gongsi = Session["gs_name"].ToString();
            string code = Context.Request["code"];
            string time_start = Context.Request["time_start"];
            string time_end = Context.Request["time_end"];
            List<jxc_z_info> list = buiness.jxc_select(username, gongsi, code, time_start, time_end);
            Session["jxc_z_select"] = list;
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
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                clsAllnew buiness = new clsBuiness.clsAllnew();
                List<jxc_z_info> list = buiness.jxc_z_select(username, gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
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
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                clsAllnew buiness = new clsBuiness.clsAllnew();
                List<jxc_z_info> list = buiness.jxc_z_select(username, gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
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
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                clsAllnew buiness = new clsBuiness.clsAllnew();
                List<jxc_z_info> list = buiness.jxc_z_select(username, gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
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
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                clsAllnew buiness = new clsBuiness.clsAllnew();
                List<jxc_z_info> list = buiness.jxc_z_select(username, gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
            }
        }

        public int getCountPage()
        {
            try
            {
                clsAllnew buiness = new clsBuiness.clsAllnew();
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                int allCount = buiness.get_jxc_PageCount(username, gongsi);
                return (int)Math.Ceiling(Convert.ToDouble((float)allCount / (float)page.pageCount));
            }
            catch (Exception ex) { throw; }
        }
    }
}