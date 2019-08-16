using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class frmMain : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlGenericControl frame1;
     
        public List<clsuserinfo> NewsList;



        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl frame1 = (HtmlControl)this.FindControl("frame1");

        }

    }
}