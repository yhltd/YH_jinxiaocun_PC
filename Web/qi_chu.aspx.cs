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

namespace Web
{
    public partial class qi_chu : System.Web.UI.Page
    {
        private int row_count;
        protected void Page_Load(object sender, EventArgs e)
        {

        
                //this.Button1.Attributes.Add("onclick", "javascript:return confirm('要提交吗?');");

            this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");



            List<qi_chu_info> list = select_row(Session["username"].ToString(), Session["gs_name"].ToString());
            row_count = list.Count;
            if (Convert.ToInt32(Session["dq_ye_qc"]) == 0)
            {
                Session["dq_ye_qc"] = 0;
            }
        }

        protected void bt_select_Click(object sender, EventArgs e)
        {
            List<qi_chu_info> list = select_chuku(Session["username"].ToString(), Session["gs_name"].ToString());
            //Session rk_session = 
            Session["qi_chu_select"] = list;


        }

        public List<qi_chu_info> select_chuku(string zh_name, string gs_name)
        {

            List<qi_chu_info> list = new List<qi_chu_info>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.ck_sp_select(zh_name, gs_name);

            return list;
        }


        protected void shou_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_qc"] = 0;
            List<qi_chu_info> list = fen_ye(0, 1);
            Session["qi_chu_select"] = list;
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_qc"]);
            List<qi_chu_info> list = fen_ye(dang_qian, 1);
            Session["dq_ye_qc"] = dang_qian - 1;
            Session["qi_chu_select"] = list;

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye_qc"]);
            List<qi_chu_info> list = fen_ye(dang_qian + 1, 1);
            Session["dq_ye_qc"] = dang_qian + 1;
            Session["qi_chu_select"] = list;


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye_qc"] = select_row(Session["username"].ToString(), Session["gs_name"].ToString()).Count - 1;
            List<qi_chu_info> list = fen_ye(select_row(Session["username"].ToString(), Session["gs_name"].ToString()).Count - 1, 1);
            Session["qi_chu_select"] = list;
        }

        public List<qi_chu_info> fen_ye(int y_c, int e_c)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<qi_chu_info> list = buiness.ming_xi_fenye(y_c, e_c, Session["username"].ToString(), Session["gs_name"].ToString());
            return list;
        }

        public List<qi_chu_info> select_row(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<qi_chu_info> list = buiness.qi_chu_select_row(zh_name, gs_name);
            return list;
        }
        protected void xxx(object sender, EventArgs e)
        {

        }

        protected void qc_tj(object sender, EventArgs e)
        {
   
            if (Context.Request["tj_pd"].ToString() == "tj_true")
            {
                qi_chu_info qci = new qi_chu_info();
                for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                {
                    List<qi_chu_info> list_qc = new List<qi_chu_info>();
                    qci.Cpid = Context.Request["cpid" + i].ToString();
                    qci.Cpname = Context.Request["cpname" + i].ToString();
                    qci.Cplb = Context.Request["cplb" + i].ToString();
                    qci.Cpsj = Context.Request["cpsj" + i].ToString();
                    qci.Cpsl = Context.Request["cpsl" + i].ToString();
                    qci.zh_name = Session["username"].ToString();
                    qci.gs_name = Session["gs_name"].ToString();
                    list_qc.Add(qci);
                    add_qichu(list_qc);
                }
                for (int i = 0; i < row_count; i++)
                {
                    update_qichu(Context.Request["cpid_cs" + i].ToString(), Context.Request["cpname_cs" + i].ToString(), Context.Request["cplb_cs" + i].ToString(), Context.Request["cpsj_cs" + i].ToString(), Context.Request["cpsl_cs" + i].ToString());
                }
                Response.Write(" <script>alert('提交成功'); location='qi_chu.aspx';</script>");
            }
            
        }
        public void add_qichu(List<qi_chu_info> list)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.add_qichu(list);

        }

        public int update_qichu(string cpid, string cpname, string cplb, string cpsj, string cpsl)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.update_qichu(cpid, cpname, cplb, cpsj, cpsl);
            return isrun;

        }



        protected void del_qichu(object sender, EventArgs e)
        {
            List<qi_chu_info> list = select_row(Session["username"].ToString(), Session["gs_name"].ToString());
            for (int i = 0; i < row_count; i++)
            {
                string name = Request["Checkbox_bd" + i];

                if (name == null)
                {

                }
                else
                {
                    if (Convert.ToInt32(name) == i)
                    {
                        del_qichu_ff(list[i].Cpid);
                        Response.Write(" <script>alert('删除成功'); location='qi_chu.aspx';</script>");
                    }
                }
            }
        }

        public int del_qichu_ff(string cpid)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.del_qichu_ff(cpid);
            return isrun;

        }
    }
}