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
            
            try
            {
                this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
                bt_select_Click(sender, e);
                string act = Request["act"] == null ? "" : Request["act"].ToString();
                if (Session["username"] != null && Session["gs_name"] != null)
                {
                    if (act.Equals("PostUser"))
                    {
                        selectNameAndLebie(Request["id"].ToString());
                    }
            
                        List<zl_and_jc_info> jc = selectjichuziliao(Session["username"].ToString(), Session["gs_name"].ToString());
                        Session["jichu"] = jc;
                    
                    List<qi_chu_info> list = select_row(Session["username"].ToString(), Session["gs_name"].ToString());
                    row_count = list.Count;
                    if (Convert.ToInt32(Session["dq_ye_qc"]) == 0)
                    {
                        Session["dq_ye_qc"] = 0;
                    }
                }
                else
                {
                    Response.Write(" <script>alert('请登录'); location='../Myadmin/login.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
                //this.Button1.Attributes.Add("onclick", "javascript:return confirm('要提交吗?');");

            
          
        }

        protected void bt_select_Click(object sender, EventArgs e)
        {
            
            try {
                if (Session["username"] != null && Session["gs_name"] != null)
                {
                    List<qi_chu_info> list = select_chuku(Session["username"].ToString(), Session["gs_name"].ToString());

                    Session["qi_chu_select"] = list;
                }
                else
                {
                    Response.Write(" <script>alert('请登录'); location='../Myadmin/login.aspx';</script>");
                }
            }
            catch (Exception ex) 
            {
                
                throw;
            }
           

        }

        public List<qi_chu_info> select_chuku(string zh_name, string gs_name)
        {

            List<qi_chu_info> list = new List<qi_chu_info>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.ck_sp_select(zh_name, gs_name);

            return list;
        }
        public List<zl_and_jc_info> selectjichuziliao(string zh, string gs)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<zl_and_jc_info> list = buiness.select_jczl(zh, gs);
            return list;
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            
            try 
            {
                Session["dq_ye_qc"] = 0;
                List<qi_chu_info> list = fen_ye(0, 1);
                Session["qi_chu_select"] = list;
            }
            catch (Exception ex) { throw; }
            
        }
        public void selectNameAndLebie(object id)
        {
            zl_and_jc_info zl = new zl_and_jc_info();
            List<zl_and_jc_info> getlist = HttpContext.Current.Session["jichu"] as List<zl_and_jc_info>;
            for (int li = 0; li < getlist.Count; li++)
            {
                if (getlist[li].sp_dm.Equals(id))
                {

                    zl.name = getlist[li].name;
                    zl.lei_bie = getlist[li].lei_bie;

                }
            }
            //return json
            //return zl;
            //Context.Response.ContentType = "text/plain";
            Response.Write("[{\"name\":\"" + zl.name + "\",\"leibie\":\"" + zl.lei_bie + "\",\"company\":\"无用户\"}]");
            //Response.Write(JSONObj);
            //一定要加，不然前端接收失败
            Response.End();
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            
            try {
                int dang_qian = Convert.ToInt32(Session["dq_ye_qc"]);
                List<qi_chu_info> list = fen_ye(dang_qian, 1);
                Session["dq_ye_qc"] = dang_qian - 1;
                Session["qi_chu_select"] = list;
            }
            catch (Exception ex) { throw; }
            

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            
            try {
                int dang_qian = Convert.ToInt32(Session["dq_ye_qc"]);
                List<qi_chu_info> list = fen_ye(dang_qian + 1, 1);
                Session["dq_ye_qc"] = dang_qian + 1;
                Session["qi_chu_select"] = list;
            }
            catch (Exception ex) { throw; }
            


        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                Session["dq_ye_qc"] = select_row(Session["username"].ToString(), Session["gs_name"].ToString()).Count - 1;
                List<qi_chu_info> list = fen_ye(select_row(Session["username"].ToString(), Session["gs_name"].ToString()).Count - 1, 1);
                Session["qi_chu_select"] = list;
            }
            catch (Exception ex) { throw; }
            
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
            
            try
            {
                if (Context.Request["tj_pd"].ToString() == "tj_true")
                {
                    qi_chu_info qci = new qi_chu_info();
                    for (int i = 1; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - row_count); i++)
                    {
                        if (Context.Request["cpid" + i] != null)
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
                    }
                    for (int i = 0; i < row_count; i++)
                    {
                        update_qichu(Context.Request["cpid_cs" + i].ToString(), Context.Request["cpname_cs" + i].ToString(), Context.Request["cplb_cs" + i].ToString(), Context.Request["cpsj_cs" + i].ToString(), Context.Request["cpsl_cs" + i].ToString());
                    }
                    Response.Write(" <script>alert('提交成功'); location='qi_chu.aspx';</script>");
                }
            }
            catch (Exception ex) { throw; }
            
            
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
            
            try
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
            catch (Exception ex) { throw; }
            
        }

        public int del_qichu_ff(string cpid)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int isrun = buiness.del_qichu_ff(cpid);
            return isrun;

        }
    }
}