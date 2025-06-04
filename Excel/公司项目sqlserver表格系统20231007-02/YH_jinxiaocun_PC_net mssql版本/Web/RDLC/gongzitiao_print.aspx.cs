using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Personnel.HrModel;

namespace Web.RDLC
{
    public partial class gongzitiao_print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getPrint();
            }
        }
        public void getPrint()
        {
            ReportViewer2.LocalReport.ReportPath = @"RDLC/Report2.rdlc";
            //假数据
            List<gongzi_gongzimingxi> list = new List<gongzi_gongzimingxi>();
            if (Session["printList"] != null)
            {
                list = (List<gongzi_gongzimingxi>)Session["printList"];

                //绑定数据
                ReportDataSource rds = new ReportDataSource("DataSet2", list);
                //这个地方的DataSet2是你定义的dataset,dts是你定义的datatable
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportViewer2.LocalReport.DataSources.Add(rds);
                ReportViewer2.LocalReport.Refresh();


                JavaScriptSerializer js = new JavaScriptSerializer();
            }

        }
    }
}