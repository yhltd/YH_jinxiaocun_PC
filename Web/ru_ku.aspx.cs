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
    public partial class ru_ku : System.Web.UI.Page
    {
        public string ConStr;
        public string ConStrPIC;
        public string rev_servename;
        protected int sb;

        private string kc_id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null && Session["gs_name"] != null)
            {
                string act = Request["act"] == null ? "" : Request["act"].ToString();

                try
                {
                    if (act.Equals("PostUser"))
                    {
                        selectNameAndLebie(Request["id"].ToString());
                    }

                    List<zl_and_jc_info> jc = selectjichuziliao(Session["username"].ToString(), Session["gs_name"].ToString());
                    Session["jichu"] = jc;


                    this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");
                    List<ming_xi_info> list = kc_id_select();
                    if (list.Count > 0)
                    {
                        kc_id = list[0].Id;
                    }
                    if (Convert.ToInt32(Session["dq_ye"]) == 0)
                    {
                        Session["dq_ye"] = 0;
                    }
                }
                catch (Exception ex) { throw; }

            }
            else 
            {
                Response.Write("<script>alert('请登录！'); location='/Myadmin/Login.aspx';</script>");
            }
            

        }
         //[System.Web.Services.WebMethod()]
        public void selectNameAndLebie(object id) 
        {
            zl_and_jc_info zl = new zl_and_jc_info();
            List<zl_and_jc_info> getlist = HttpContext.Current.Session["jichu"] as List<zl_and_jc_info>;
            for (int li = 0; li < getlist.Count; li++) 
            {
                if (getlist[li].sp_dm!=null&&getlist[li].sp_dm.Equals(id)) 
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
        public bool select_rk()
        {
            bool check = false;
            clsAllnew BusinessHelp = new clsAllnew();


            return check;
        }

        protected void bt_addemprt_Click(object sender, EventArgs e)
        {


            Session["ru_ku_select"] = null;


        }

        protected void bt_select_Click(object sender, EventArgs e)
        {
            
            try
            {

                    List<ming_xi_info> list = select_ruku(Session["username"].ToString(), Session["gs_name"].ToString());
                    //Session rk_session = 
                    Session["ru_ku_select"] = list;
                
            }
            catch (Exception ex) { throw; }
            


        }
        public List<ming_xi_info> select_ruku(string zh_name, string gs_name)
        {
            string ru_dh = Context.Request["ru_cx"].ToString();
            List<ming_xi_info> list = new List<ming_xi_info>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.ru_ku_select(ru_dh, zh_name, gs_name);
            return list;
        }
        public void insert_ruku(List<ming_xi_info> mxif)
        {

            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.buindess_addinput_ku(mxif);

            //MySqlHelper.ExecuteSql(sql, ConStr);
        }

        public void add_kc(List<ku_cun> kc)
        {

            clsAllnew buiness = new clsBuiness.clsAllnew();
            buiness.add_kucun(kc);

            //MySqlHelper.ExecuteSql(sql, ConStr);
        }
        public void update_kc(string id ,string sl) {
            clsAllnew bun = new clsBuiness.clsAllnew();
            bun.update_kc(id, sl);
        }
        protected List<ku_cun> select_kc(string zh_name, string gs_name,string spdm)
        {

            List<ku_cun> list = new List<ku_cun>();
            clsAllnew buiness = new clsBuiness.clsAllnew();
            list = buiness.seletrkc(zh_name, gs_name,spdm);

            return list;
        }
        protected void bt_add_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Context.Request["tj_pd"].ToString() == "tj_true")
                {
                    ku_cun kc = new ku_cun();
                    ming_xi_info mxi = new ming_xi_info();
                    for (int i = 0; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - 1); i++)
                    {
                        if (Context.Request["sp_name" + i] != null)
                        {
                            List<ku_cun> list_kc = new List<ku_cun>();
                            List<ku_cun> selectkc = new List<ku_cun>();
                            selectkc = select_kc(Session["username"].ToString(), Session["gs_name"].ToString(), Context.Request["sp_dm" + i].ToString()) as List<ku_cun>;
                            if (selectkc.Count <= 0)
                            {
                                kc.Name = Context.Request["sp_name" + i].ToString();
                                kc.Sp_dm = Context.Request["sp_dm" + i].ToString();
                                kc.Lei_bie = Context.Request["sp_cplb" + i].ToString();
                                kc.Shou_jia = Context.Request["sp_cpsj" + i].ToString();
                                kc.Shu_liang = Context.Request["sp_cpsl" + i].ToString();
                                kc.Bei_zhu = Context.Request["sp_bz" + i].ToString();
                                kc.Dan_hao = Context.Request["orderid"].ToString();
                                kc.Gong_huo = Context.Request["gongsi"].ToString();
                                kc.Shou_huo = Context.Request["shou_h"].ToString();
                                kc.Ri_qi = Context.Request["shijian"].ToString();
                                kc.Id = mxi.Id = (Convert.ToInt32(kc_id) + i + 1).ToString();
                                kc.zh_name = Session["username"].ToString();
                                kc.gs_name = Session["gs_name"].ToString();
                                kc.Mx_lb = "入库";
                                list_kc.Add(kc);
                                add_kc(list_kc);

                            }
                            else
                            {
                                int sl = Convert.ToInt32(Context.Request["sp_cpsl" + i].ToString()) + Convert.ToInt32(selectkc[0].Shu_liang);
                                update_kc(Context.Request["sp_dm" + i].ToString(), sl.ToString());
                            }

                            //明细！！！！！
                            List<ming_xi_info> list = new List<ming_xi_info>();
                            mxi.Cpname = Context.Request["sp_name" + i].ToString();
                            mxi.sp_dm = Context.Request["sp_dm" + i].ToString();
                            mxi.Cplb = Context.Request["sp_cplb" + i].ToString();
                            mxi.Cpsj = Context.Request["sp_cpsj" + i].ToString();
                            mxi.Cpsl = Context.Request["sp_cpsl" + i].ToString();
                            mxi.Orderid = Context.Request["orderid"].ToString();
                            mxi.Gongsi = Context.Request["gongsi"].ToString();
                            mxi.shou_h = Context.Request["shou_h"].ToString();
                            mxi.Shijian = Context.Request["shijian"].ToString();
                            mxi.Openid = "1";
                            mxi.Id = (Convert.ToInt32(kc_id) + i + 1).ToString();
                            mxi.zh_name = Session["username"].ToString();
                            mxi.gs_name = Session["gs_name"].ToString();
                            mxi.Mxtype = "入库";
                            list.Add(mxi);
                            insert_ruku(list);

                        }

                        if (i == (Convert.ToInt32(Context.Request["row_i"].ToString()) - 2))
                        {
                            Response.Write(" <script>alert('入库成功'); location='ru_ku.aspx';</script>");
                        }
                    }



                  
                }
            }
            catch (Exception ex) { throw; }
                


        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                Session["dq_ye"] = 0;
                List<ming_xi_info> list = fen_ye(0, 4);
                Session["ru_ku_select"] = list;
            }
            catch (Exception ex) { throw; }
            
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                int dang_qian = Convert.ToInt32(Session["dq_ye"]);
                List<ming_xi_info> list = fen_ye(dang_qian, 4);
                Session["dq_ye"] = dang_qian - 1;
                Session["ru_ku_select"] = list;
            }
            catch (Exception ex) { throw; }
            
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            
            try
            {
                int dang_qian = Convert.ToInt32(Session["dq_ye"]);
                List<ming_xi_info> list = fen_ye(dang_qian + 1, 4);
                Session["dq_ye"] = dang_qian + 1;
                Session["ru_ku_select"] = list;
            }
            catch (Exception ex) { throw; }
            

        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
           
            try
            {
                Session["dq_ye"] = select_row().Count - 1;
                List<ming_xi_info> list = fen_ye(select_row().Count - 1, 4);
                Session["ru_ku_select"] = list;
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
        public List<zl_and_jc_info> selectjichuziliao(string zh,string gs) 
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<zl_and_jc_info> list = buiness.select_jczl(zh,gs);
            return list;
        }
        public List<ming_xi_info> kc_id_select()
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.kc_id_select();
            return list;
        }

    }
}