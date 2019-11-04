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

namespace Web
{
    public partial class ming_xi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Session["username"] == null && Session["gs_name"] == null)
                {
                    Response.Write("<script>alert('请登录！');location='/Myadmin/Login.aspx';</script>");
                }
                else
                {
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

                    sw.WriteLine(dr.Orderid + "\t" + dr.sp_dm + "\t" + dr.Cpname + "\t" + dr.Cplb + "\t" + dr.Cpjg + "\t" + dr.Cpsl + "\t" + dr.Mxtype + "\t" + dr.Shijian + "\t" + dr.Gongsi + "\t" + dr.shou_h);

                }

                sw.Close();

                Response.AddHeader("Content-Disposition", "attachment; filename=明细.xls");

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
        protected void bt_select_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<ming_xi_info> list = ming_xi_select(Session["username"].ToString(), Session["gs_name"].ToString());
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }
            
           

        }

        public List<ming_xi_info> ming_xi_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ming_xi_select(zh_name, gs_name);
            return list;
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                Session["dq_ye_mx_dd"] = 0;
                List<ming_xi_info> list = fen_ye(0, 4);
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }
            
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                int dang_qian = Convert.ToInt32(Session["dq_ye_mx_dd"]);
                List<ming_xi_info> list = fen_ye(dang_qian - 1, 4);
                Session["dq_ye_mx_dd"] = dang_qian - 1;
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }
            

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                int dang_qian = Convert.ToInt32(Session["dq_ye_mx_dd"]);
                List<ming_xi_info> list = fen_ye(dang_qian + 1, 4);
                Session["dq_ye_mx_dd"] = dang_qian + 1;
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }
            


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                Session["dq_ye_mx_dd"] = select_row().Count - 1;
                List<ming_xi_info> list = fen_ye(select_row().Count - 1, 4);
                Session["ming_xi_select_dd"] = list;
            }
            catch (Exception ex) { throw; }
            
        }

        public List<ming_xi_info> fen_ye(int y_c, int e_c)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.ru_ku_fenye(y_c, e_c, Session["username"].ToString(), Session["gs_name"].ToString());
            return list;
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