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
    public partial class test_jxc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void jxc_load(object sender, EventArgs e)
        {
            //List<jxc_z_info> list = jxc_z_select();

            //Session["jxc_z_info11"] = list;
        }

        //public List<jxc_z_info> jxc_z_select()
        //{
        //    //clsAllnew buiness = new clsBuiness.clsAllnew();
        //    //List<jxc_z_info> list = buiness.jxc_z_select();
        //    //return list;
        //}
    }
}