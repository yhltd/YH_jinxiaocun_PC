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
    public partial class jin_xiao_cun : System.Web.UI.Page
    {
        private int count_row;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null && Session["gs_name"] == null) 
            {
                Response.Write("<script>alert('请登录！');location='/Myadmin/Login.aspx';</script>");
            }
            
        }

        protected void toExcel(object sender, EventArgs e)
        {
            List<jxc_z_info> gtlist = Session["jxc_z_select"] as List<jxc_z_info> ;
            StringWriter sw=new StringWriter();
            if (gtlist != null)
            {
                sw.WriteLine("商品代码\t商品名称\t商品类别\t期初数量\t期初单价\t期初金额\t进货数量\t进货单价\t进货金额\t出库数量\t出库单价\t出库金额\t结存\t结存单价\t结存金额\t边缘存量");

                foreach (jxc_z_info dr in gtlist)
                {

                    sw.WriteLine(dr.Sp_dm + "\t" + dr.Name + "\t" + dr.Lei_bie + "\t" + dr.Cpsl_3 + "\t" + dr.Cpsj_3 + "\t" + dr.Cpje_3 + "\t" + dr.Cpsl_1 + "\t" + dr.Cpsj_1 + "\t" + dr.Cpje_1 + "\t" + dr.Cpsl_2 + "\t" + dr.Cpsj_2 + "\t" + dr.Cpje_2 + "\t" + dr.jc_jc + "\t" + dr.jc_dj + "\t" + dr.jc_je + "\t" + dr.yl_tx);

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

        protected void jxc_load(object sender, EventArgs e)
        {
            
            try
            {

                    List<jxc_z_info> list = jxc_z_select(Session["username"].ToString(), Session["gs_name"].ToString());
                    for (int i = 0; i < list.Count; i++)
                    {

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
                        list[i].yl_tx = "25";
                    }
                    Session["jxc_z_select"] = list;
                
                
            }
            catch (Exception ex) { throw; }
          
        }

        protected void time_select(object sender, EventArgs e)
        {
            
            try
            {

                string spdm = Context.Request["sp_dm"].ToString();
                string spmc = Context.Request["sp_mc"].ToString();
                List<jxc_z_info> list = new List<jxc_z_info>();
                list = jxc_z_select_where(Context.Request["time_qs"].ToString(), Context.Request["time_jz"].ToString(), Session["username"].ToString(), Session["gs_name"].ToString(), spdm,spmc);
               
                for (int i = 0; i < list.Count; i++)
                {


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
                    list[i].yl_tx = "25";
                }
                Session["jxc_z_select"] = list;
            }
            catch (Exception ex) { throw; }
            
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

        public List<jxc_z_info> jxc_z_select_where(string time_qs, string time_jz, string zh_name, string gs_name,string spdm ,string spmc)
        {
            clsAllnew buiness = new clsBuiness.clsAllnew();
            List<jxc_z_info> list = buiness.jxc_z_select_where(time_qs, time_jz, zh_name, gs_name,spdm,spmc);
            return list;
        }
    }
}