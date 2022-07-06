using Microsoft.Reporting.WebForms;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.RDLC
{
    public partial class frm_ReportForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getruku_print();
            }
        }

        //rdlc 
        public void getruku_print()
        {
            try
            {
                ReportViewer2.LocalReport.ReportPath = @"RDLC/Report1.rdlc";
                //假数据
                List<rukuPrint> OnlineShow_datas1 = new List<rukuPrint>();
                if (Session["printList"] != null) {
                    OnlineShow_datas1 = (List<rukuPrint>)Session["printList"];

                    //绑定数据
                    ReportDataSource rds = new ReportDataSource("DataSet2", OnlineShow_datas1);
                    //这个地方的DataSet2是你定义的dataset,dts是你定义的datatable
                    ReportViewer2.LocalReport.DataSources.Clear();
                    ReportViewer2.LocalReport.DataSources.Add(rds);
                    ReportViewer2.LocalReport.Refresh();


                    JavaScriptSerializer js = new JavaScriptSerializer();
                }
                
                
                

                
                //return js.Serialize(null);
            }
            catch
            {
                //return string.Empty;
            }

        }
    }
}