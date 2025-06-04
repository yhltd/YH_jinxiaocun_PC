using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.finance.web.view
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpRuntime.Cache.Get("msg") != null)
                {
                    msg.Text = HttpRuntime.Cache.Get("msg").ToString();
                }
            }
        }
    }
}