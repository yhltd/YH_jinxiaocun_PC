﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Personnel
{
    public partial class changepwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a;
            a = Request.QueryString.ToString();
            if(a!="1"){
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>MyFun();</script>");
            }
        }
    }
}