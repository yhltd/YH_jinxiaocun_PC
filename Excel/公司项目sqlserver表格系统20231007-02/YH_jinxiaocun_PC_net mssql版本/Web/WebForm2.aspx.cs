using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode;

namespace Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<clsQQquninfo> ClaimReport_Server;
        protected void Page_Load(object sender, EventArgs e)
        {
            binddata();
            NewMethod();
        }

        private void NewMethod()
        {
            gvList.DataSource = ClaimReport_Server;
            gvList.DataBind();
        }
        public List<clsQQquninfo> binddata()
        {
             ClaimReport_Server = new List<clsQQquninfo>();

            clsQQquninfo ITEM = new clsQQquninfo();
            ITEM.ORG_NAME = "DDD";
            ITEM.TOTAL_EXPENSENS = "KJL";

            ClaimReport_Server.Add(ITEM);

            return ClaimReport_Server;
        
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ClaimReport_Server = new List<clsQQquninfo>();

            clsQQquninfo ITEM = new clsQQquninfo();
            ITEM.ORG_NAME = "DDSDSDD";
            ITEM.TOTAL_EXPENSENS = "KSD,SMDSKKJL";

            ClaimReport_Server.Add(ITEM);
            NewMethod();
        }
    }
}