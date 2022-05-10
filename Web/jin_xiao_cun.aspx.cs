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
    public partial class jin_xiao_cun : System.Web.UI.Page
    {
        private static ServicePage page = new ServicePage();

        private static yh_jinxiaocun_user user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            
            if (user == null)
            {
                Response.Write("<script>alert('请登录！');window.parent.location.href='../Myadmin/Login.aspx';</script>");
            }
            
            else
            {
                try
                {
                    page.countPage = this.getCountPage();
                    shuaxin();
                    lblCurrentPage.Text = page.nowPage.ToString();
                }
                catch
                {
                    Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
                }
              
            }
        }

        protected void jxc_load(object sender, EventArgs e)
        {
            try
            {
                shuaxin();
            }
            catch
            {
                Response.Write("<script>alert('网络错误，请稍后再试！');</script>");
            }
        }

        private void shuaxin() {
            StockModel stock = new StockModel();
            page.nowPage = 1;
            Session["jxc_z_select"] = stock.jxc_z_select(user.gongsi, page.getLimit1(), page.getLimit2());
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

                    sw.WriteLine(dr.sp_dm + "\t" + dr.name + "\t" + dr.lei_bie + "\t" + dr.jq_cpsl + "\t" + dr.jq_price + "\t" + dr.mx_ruku_cpsl + "\t" + dr.mx_ruku_price + "\t" + dr.mx_chuku_cpsl + "\t" + dr.mx_chuku_price + "\t" + dr.jc_sl + "\t" + dr.jc_price + "\t" + dr.stock);

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
            StockModel stock = new StockModel();
            string code = Context.Request["code"];
            string time_start = Context.Request["time_start"] == "" ? "1999-01-01" : Context.Request["time_start"];
            string time_end = Context.Request["time_end"] == "" ? "2999-01-01" : Context.Request["time_end"];
            time_start = txtCompletionTime.Text.ToString();
            time_end = txttime_end.Text.ToString();

            Session["jxc_z_select"] = stock.jxc_select(user.gongsi, code, time_start, time_end);
          
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage = 1;
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                StockModel stock = new StockModel();
                List<jxc_z_info> list = stock.jxc_z_select(gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }
        protected void shang_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == 1)
            {
                Response.Write("<script>alert('已经是第一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage--;
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                StockModel stock = new StockModel();
                List<jxc_z_info> list = stock.jxc_z_select(gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }
        protected void xia_ye_Click(object sender, EventArgs e)
        {
            if (page.countPage < (page.nowPage + 1))
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage++;
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                StockModel stock = new StockModel();
                List<jxc_z_info> list = stock.jxc_z_select(gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }
        protected void mo_ye_Click(object sender, EventArgs e)
        {
            if (page.nowPage == page.countPage)
            {
                Response.Write("<script>alert('已经是最后一页');</script>");
                lblCurrentPage.Text = page.nowPage.ToString();
            }
            else
            {
                page.nowPage = page.countPage;
                string username = Session["username"].ToString();
                string gongsi = Session["gs_name"].ToString();
                StockModel stock = new StockModel();
                List<jxc_z_info> list = stock.jxc_z_select(gongsi, page.getLimit1(), page.getLimit2());
                Session["jxc_z_select"] = list;
                lblCurrentPage.Text = page.nowPage.ToString();
            }
        }

        public int getCountPage()
        {
            StockModel stock = new StockModel();
            int allCount = stock.get_jxc_PageCount(user.gongsi);
            return (int)Math.Ceiling(Convert.ToDouble((float)allCount / (float)page.pageCount));
        }

        protected void txtCompletionTime_TextChanged(object sender, EventArgs e)
        {
  
        }

    }
}