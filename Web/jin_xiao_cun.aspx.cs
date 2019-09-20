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
    public partial class jin_xiao_cun : System.Web.UI.Page
    {
        private int count_row;
        protected void Page_Load(object sender, EventArgs e)
        {

            //List<jxc_z_info> list = jxc_z_select();
            //count_row = list.Count;
        }

        protected void jxc_load(object sender, EventArgs e)
        {

            List<jxc_z_info> list = jxc_z_select(Session["username"].ToString(), Session["gs_name"].ToString());
             for (int i = 0; i < list.Count; i++)
            {
                list[i].Cpje_1 = (Convert.ToInt32(list[i].Cpsj_1) * Convert.ToInt32(list[i].Cpsl_1)).ToString();
                if (list[i].Cpsj_2 == "" )
                {
                    list[i].Cpje_2 = "0";
                }
                else {
                    list[i].Cpje_2 = (Convert.ToInt32(list[i].Cpsj_2) * Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }
               
                list[i].Cpje_3 = (Convert.ToInt32(list[i].Cpsj_3) * Convert.ToInt32(list[i].Cpsl_3)).ToString();


                if (list[i].Cpsl_3 == "")
                {
                    list[i].jc_jc = (0 + Convert.ToInt32(list[i].Cpsl_1) - Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }
                else if (list[i].Cpsl_1 == "")
                {
                    list[i].jc_jc = (Convert.ToInt32(list[i].Cpsl_3) + 0 - Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }
                else if (list[i].Cpsl_2 == "")
                {
                    list[i].jc_jc = (Convert.ToInt32(list[i].Cpsl_3) + Convert.ToInt32(list[i].Cpsl_1) - 0).ToString();
                }
                else 
                {
                    list[i].jc_jc = (Convert.ToInt32(list[i].Cpsl_3) + Convert.ToInt32(list[i].Cpsl_1) - Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }


                 
                if (Convert.ToInt32(list[i].jc_jc) >= 0)
                {
                    if (list[i].Cpje_3 == "")
                    {
                        list[i].jc_je = (0 + Convert.ToInt32(list[i].Cpje_1) - Convert.ToInt32(list[i].Cpje_2)).ToString();
                    }
                    else if (list[i].Cpje_1 == "")
                    {
                        list[i].jc_je = (Convert.ToInt32(list[i].Cpje_3) + 0 - Convert.ToInt32(list[i].Cpje_2)).ToString();
                    }
                    else if (list[i].Cpje_2 == "")
                    {
                        list[i].jc_je = (Convert.ToInt32(list[i].Cpje_3) + Convert.ToInt32(list[i].Cpje_1) - 0).ToString();
                    }
                    else
                    {
                        list[i].jc_je = (Convert.ToInt32(list[i].Cpje_3) + Convert.ToInt32(list[i].Cpje_1) - Convert.ToInt32(list[i].Cpje_2)).ToString();
                    }
                }
                else 
                {
                    list[i].jc_je = "0";
                }



                if (Convert.ToInt32(list[i].jc_jc) > 0)
                {
                    list[i].jc_dj = (Convert.ToInt32(list[i].jc_je) / Convert.ToInt32(list[i].jc_jc)).ToString();
                }
                else
                {
                    list[i].jc_dj = "0";
                }
             }
            Session["jxc_z_select"] = list;
            ////期初

            //List<jxc_1_info> list = jxc_1_select();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i].Cpje = (Convert.ToInt32(list[i].Cpsj) * Convert.ToInt32(list[i].Cpsl)).ToString();
            //}
            //Session["jxc_1_select"] = list;

            ////入库
            //List<jxc_2_info> list2 = jxc_2_select();
            //for (int i = 0; i < list2.Count; i++)
            //{
            //    list2[i].Cpje = (Convert.ToInt32(list2[i].Cpsj) * Convert.ToInt32(list2[i].Cpsl)).ToString();
            //}
            //Session["jxc_2_select"] = list2;


            ////出库
            //List<jxc_3_info> list3 = jxc_3_select();
            //for (int i = 0; i < list3.Count; i++)
            //{
            //    list3[i].Cpje = (Convert.ToInt32(list3[i].Cpsj) * Convert.ToInt32(list3[i].Cpsl)).ToString();
            //}
            //Session["jxc_3_select"] = list3;

            ////结存
            //List<jxc_4_info> list4 = jxc_4_select();
            //for (int i = 0; i < list4.Count; i++)
            //{
            //    list4[i].Cpjc = (Convert.ToInt32(list[i].Cpsl) + Convert.ToInt32(list2[i].Cpsl) - Convert.ToInt32(list3[i].Cpsl)).ToString();

            //    list4[i].Cpje = (Convert.ToInt32(list[i].Cpje) + Convert.ToInt32(list2[i].Cpje) - Convert.ToInt32(list3[i].Cpje)).ToString();
            //    if (Convert.ToInt32(list4[i].Cpjc) > 0)
            //    {
            //        list4[i].Cpsj = (Convert.ToInt32(list4[i].Cpje) / Convert.ToInt32(list4[i].Cpjc)).ToString();
            //    }
            //    else {
            //        list4[i].Cpsj ="0";
            //    }
            //}
            //Session["jxc_4_select"] = list4;

        }

        protected void time_select(object sender, EventArgs e)
        {
            List<jxc_z_info> list = jxc_z_select_where(Context.Request["time_qs"].ToString(), Context.Request["time_jz"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString());
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Cpje_1 = (Convert.ToInt32(list[i].Cpsj_1) * Convert.ToInt32(list[i].Cpsl_1)).ToString();
                if (list[i].Cpsj_2 == "")
                {
                    list[i].Cpje_2 = "0";
                }
                else
                {
                    list[i].Cpje_2 = (Convert.ToInt32(list[i].Cpsj_2) * Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }

                list[i].Cpje_3 = (Convert.ToInt32(list[i].Cpsj_3) * Convert.ToInt32(list[i].Cpsl_3)).ToString();


                if (list[i].Cpsl_3 == "")
                {
                    list[i].jc_jc = (0 + Convert.ToInt32(list[i].Cpsl_1) - Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }
                else if (list[i].Cpsl_1 == "")
                {
                    list[i].jc_jc = (Convert.ToInt32(list[i].Cpsl_3) + 0 - Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }
                else if (list[i].Cpsl_2 == "")
                {
                    list[i].jc_jc = (Convert.ToInt32(list[i].Cpsl_3) + Convert.ToInt32(list[i].Cpsl_1) - 0).ToString();
                }
                else
                {
                    list[i].jc_jc = (Convert.ToInt32(list[i].Cpsl_3) + Convert.ToInt32(list[i].Cpsl_1) - Convert.ToInt32(list[i].Cpsl_2)).ToString();
                }



                if (Convert.ToInt32(list[i].jc_jc) >= 0)
                {
                    if (list[i].Cpje_3 == "")
                    {
                        list[i].jc_je = (0 + Convert.ToInt32(list[i].Cpje_1) - Convert.ToInt32(list[i].Cpje_2)).ToString();
                    }
                    else if (list[i].Cpje_1 == "")
                    {
                        list[i].jc_je = (Convert.ToInt32(list[i].Cpje_3) + 0 - Convert.ToInt32(list[i].Cpje_2)).ToString();
                    }
                    else if (list[i].Cpje_2 == "")
                    {
                        list[i].jc_je = (Convert.ToInt32(list[i].Cpje_3) + Convert.ToInt32(list[i].Cpje_1) - 0).ToString();
                    }
                    else
                    {
                        list[i].jc_je = (Convert.ToInt32(list[i].Cpje_3) + Convert.ToInt32(list[i].Cpje_1) - Convert.ToInt32(list[i].Cpje_2)).ToString();
                    }
                }
                else
                {
                    list[i].jc_je = "0";
                }



                if (Convert.ToInt32(list[i].jc_jc) > 0)
                {
                    list[i].jc_dj = (Convert.ToInt32(list[i].jc_je) / Convert.ToInt32(list[i].jc_jc)).ToString();
                }
                else
                {
                    list[i].jc_dj = "0";
                }
            }
            Session["jxc_z_select"] = list;
        }
        public List<jxc_4_info> jxc_4_select()
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<jxc_4_info> list = buiness.jxc_4_select();
           

            return list;
        }

        public List<jxc_z_info> jxc_z_select(string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<jxc_z_info> list = buiness.jxc_z_select(zh_name, gs_name);
            return list;
        }

        public List<jxc_z_info> jxc_z_select_where(string time_qs, string time_jz, string zh_name, string gs_name)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<jxc_z_info> list = buiness.jxc_z_select_where(time_qs, time_jz, zh_name, gs_name);
            return list;
        }
    }
}