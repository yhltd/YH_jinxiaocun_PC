using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

namespace Web
{
    public partial class frmNav : System.Web.UI.Page
    {
        private string servename;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie1 = Request.Cookies["adminCook"];

            if (cookie1 != null && cookie1["AdminIS"].ToString() != "")
            {
                servename = cookie1["AdminIS"].ToString();
              
            }


            //if (Session["AdminIS"] != null)
            //    servename = Session["AdminIS"].ToString();

            if (servename == "true")
                myspan.Style.Add("display", "none");
            else
                myspan2.Style.Add("display", "none");

        }
    }
}