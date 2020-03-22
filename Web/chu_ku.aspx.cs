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
    public partial class chu_ku : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.CheckBox ck;
        //protected List<ku_cun> dd = new List<ku_cun>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Session["username"] != null && Session["gs_name"] != null)
                {
                    List<zl_and_jc_info> jc = selectjichuziliao(Session["username"].ToString(), Session["gs_name"].ToString());
                    Session["jichu"] = jc;
                    this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
                    bt_select_Click(sender, e);
                }
                else 
                {
                    Response.Write("<script>alert('请登录！'); location='/Myadmin/Login.aspx';</script>");
                }
                clsAllnew allbewn = new clsAllnew();

                allbewn.inputcookvalue("出库"); 
                
            }
            catch (Exception ex) { throw; }
            
            //dd = select_kc(Session["username"].ToString(), Session["gs_name"].ToString());
            //rpt_list.DataSource = dd;//设定数据源
            //rpt_list.DataBind();//绑定数据
           
        }
        protected List<ku_cun> selectkc(string zh_name, string gs_name, string spdm)
        {

            List<ku_cun> list = new List<ku_cun>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.seletrkc(zh_name, gs_name, spdm);

            return list;
        }
        public void update_kc(string id, string sl)
        {
            clsAllnew bun = new clsBuiness.clsAllnew();
            bun.update_kc(id, sl);
        }
        protected void rk_pd(object sender, EventArgs e)
        {
            
            try
            {
                if (Context.Request["tj_pd"].ToString() == "tj_true")
                {
                    ming_xi_info mxi = new ming_xi_info();
                    int check_num = 0;
                    for (int i = 0; i < select_kc(Session["username"].ToString(), Session["gs_name"].ToString()).Count; i++)
                    {
                        string name = Request["Checkbox_bd" + i];
                        List<ku_cun> list = select_kc(Session["username"].ToString(), Session["gs_name"].ToString());
                        if (name == null)
                        {

                        }
                        else
                        {
                            if (Convert.ToInt32(name) == i)
                            {
                                List<ku_cun> selectlist = selectkc(Session["username"].ToString(), Session["gs_name"].ToString(), Context.Request["ck_spdm" + i].ToString());
                                check_num = ck_update_cs(list[i].Id, (Convert.ToInt32(list[i].Shu_liang) - Convert.ToInt32(Request["ck_sl" + i])).ToString());
                                List<ming_xi_info> list_mx = new List<ming_xi_info>();
                                mxi.Cpname = Context.Request["ck_name" + i].ToString();
                                mxi.Openid = "2";
                                mxi.Cpsj = Context.Request["ck_dj" + i];
                                mxi.Cpsl = Convert.ToInt32(Request["ck_sl" + i]).ToString();
                                mxi.Orderid = Context.Request["orderid"].ToString();
                                mxi.Gongsi = Context.Request["gongsi"].ToString();
                                mxi.shou_h = Context.Request["shou_h"].ToString();
                                mxi.Shijian = Context.Request["shijian"].ToString();
                                mxi.Mxtype = "出库";
                                mxi.Cplb = Context.Request["cp_lb" + i].ToString();
                                mxi.zh_name = Session["username"].ToString();
                                mxi.gs_name = Session["gs_name"].ToString();
                                mxi.sp_dm = Context.Request["ck_spdm" + i].ToString();
                                mxi.Id = Context.Request["ck_id" + i].ToString();
                                list_mx.Add(mxi);
                                kc_t_mx(list_mx);
                                int sl = Convert.ToInt32(selectlist[0].Shu_liang) - Convert.ToInt32(Context.Request["ck_sl" + i].ToString());
                                update_kc(Context.Request["ck_spdm" + i].ToString(), sl.ToString());


                            }
                            else
                            {

                            }
                        }

                    }

                    // Response.Write(" <script>alert('出库成功');</script>");
                    Response.Write(" <script>alert('出库成功'); location='chu_ku.aspx';</script>");
                    bt_select_Click(sender, e);

                }
            }
            catch (Exception ex) { throw; }
           
        }

        public int ck_update_cs(string id, string cpsl)
        { 
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int i = buiness.update_kc(id,cpsl);
            return i;
        }
     
        protected void bt_select_Click(object sender, EventArgs e)
        {
            
            try
            {

                    List<ku_cun> list = select_kc(Session["username"].ToString(), Session["gs_name"].ToString());
                    //Session rk_session = 
                    Session["ck_sp_select"] = list;
                
                
            }
            catch (Exception ex) { throw; }
            
           
            
        }

        public List<ku_cun> select_kc(string zh_name, string gs_name)
        {

            List<ku_cun> list = new List<ku_cun>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.select_kc(zh_name, gs_name);

            return list;
        }

        public void kc_t_mx(List<ming_xi_info> list) {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.buindess_addinput_ku(list);
        }
        public List<zl_and_jc_info> selectjichuziliao(string zh, string gs)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<zl_and_jc_info> list = buiness.select_jczl(zh, gs);
            return list;
        }

    }
}