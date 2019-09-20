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
            this.dj_row.Attributes.Add("onclick", "javascript:pd_tj_ff();");

            List<ming_xi_info> list = kc_id_select();
            kc_id = list[0].Id;
            if (Convert.ToInt32(Session["dq_ye"]) == 0)
            {
                Session["dq_ye"] = 0;
            }

        }

        public bool select_rk()
        {
            bool check = false;
            clsAllnew BusinessHelp = new clsAllnew();


            return check;
        }



        protected void bt_select_Click(object sender, EventArgs e)
        {
            List<ming_xi_info> list = select_ruku(Session["username"].ToString(), Session["gs_name"].ToString());
            //Session rk_session = 
            Session["ru_ku_select"] = list;


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
        protected void bt_add_Click(object sender, EventArgs e)
        {
            //if (Context.Request["orderid"].ToString() == null)
            //{
                if (Context.Request["tj_pd"].ToString() == "tj_true")
                {
                    ku_cun kc = new ku_cun();
                    ming_xi_info mxi = new ming_xi_info();
                    for (int i = 0; i < (Convert.ToInt32(Context.Request["row_i"].ToString()) - 1); i++)
                    {
                        List<ku_cun> list_kc = new List<ku_cun>();
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
                        list_kc.Add(kc);
                        add_kc(list_kc);

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
                        list.Add(mxi);
                        insert_ruku(list);

                        if (i == (Convert.ToInt32(Context.Request["row_i"].ToString()) - 2))
                        {
                            Response.Write(" <script>alert('入库成功'); location='ru_ku.aspx';</script>");
                        }
                    }



                    //for (int i = 0; i < (Convert.ToInt32(Context.Request["row_i"].ToString())-1); i++)
                    //{

                    //    if (list.Count == (Convert.ToInt32(Context.Request["row_i"].ToString()) - 1))
                    //    {
                    //        insert_ruku(list);


                    //        Response.Write(" <script>alert('入库成功'); location='ru_ku.aspx';</script>");
                    //    }
                    //}
                }
            //}
            //else 
            //{
            //    Response.Write(" <script>alert('请输入订单号');</script>");            
            //}

        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye"] = 0;
            List<ming_xi_info> list = fen_ye(0, 1);
            Session["ru_ku_select"] = list;
        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye"]);
            List<ming_xi_info> list = fen_ye(dang_qian, 1);
            Session["dq_ye"] = dang_qian - 1;
            Session["ru_ku_select"] = list;
        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {
            int dang_qian = Convert.ToInt32(Session["dq_ye"]);
            List<ming_xi_info> list = fen_ye(dang_qian + 1, 1);
            Session["dq_ye"] = dang_qian + 1;
            Session["ru_ku_select"] = list;

        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {
            Session["dq_ye"] = select_row().Count - 1;
            List<ming_xi_info> list = fen_ye(select_row().Count - 1, 1);
            Session["ru_ku_select"] = list;
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

        public List<ming_xi_info> kc_id_select()
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<ming_xi_info> list = buiness.kc_id_select();
            return list;
        }

    }
}