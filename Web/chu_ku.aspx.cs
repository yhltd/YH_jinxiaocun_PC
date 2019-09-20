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
            this.Button1.Attributes.Add("onclick", "javascript:pd_tj_ff();");
            //dd = select_kc(Session["username"].ToString(), Session["gs_name"].ToString());
            //rpt_list.DataSource = dd;//设定数据源
            //rpt_list.DataBind();//绑定数据
           
        }

        protected void rk_pd(object sender, EventArgs e)
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
                            check_num = ck_update_cs(list[i].Id, (Convert.ToInt32(list[i].Shu_liang) - Convert.ToInt32(Request["ck_sl" + i])).ToString());
                            List<ming_xi_info> list_mx = new List<ming_xi_info>();
                            mxi.Cpname = Context.Request["ck_name" + i].ToString();
                            mxi.Openid = "2";
                            mxi.Cpsj = Context.Request["ck_dj" + i];
                            mxi.Cpsl = (Convert.ToInt32(list[i].Shu_liang) - Convert.ToInt32(Request["ck_sl" + i])).ToString();
                            mxi.Orderid = Context.Request["orderid"].ToString();
                            mxi.Gongsi = Context.Request["gongsi"].ToString();
                            mxi.shou_h = Context.Request["shou_h"].ToString();
                            mxi.Shijian = Context.Request["shijian"].ToString();
                            mxi.Id = Context.Request["ck_id" + i].ToString();
                            list_mx.Add(mxi);
                            kc_t_mx(list_mx);
                        }
                    }

                }
                if (check_num > 0)
                {
                    // Response.Write(" <script>alert('出库成功');</script>");
                    Response.Write(" <script>alert('出库成功'); location='chu_ku.aspx';</script>");
                }
            }
        }

        public int ck_update_cs(string id, string cpsl)
        { 
            clsAllnew buiness = new clsBuiness.clsAllnew();
            int i = buiness.update_kc(id,cpsl);
            return i;
        }
     
        protected void bt_select_Click(object sender, EventArgs e)
        {
            List<ku_cun> list = select_kc(Session["username"].ToString(), Session["gs_name"].ToString());
            //Session rk_session = 
            Session["ck_sp_select"] = list;
           
            
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
            buiness.add_kucun_t_mx(list);
        }
      

    }
}