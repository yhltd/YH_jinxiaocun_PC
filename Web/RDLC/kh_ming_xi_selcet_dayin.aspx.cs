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
    public partial class kh_ming_xi_selcet_dayin : System.Web.UI.Page
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
                ReportViewer4.LocalReport.ReportPath = @"RDLC/Report4.rdlc";
                //假数据
                List<ming_xi_info> OnlineShow_datas1 = new List<ming_xi_info>();
                if (Session["printList"] != null) {
                    OnlineShow_datas1 = (List<ming_xi_info>)Session["printList"];

                    //绑定数据
                    ReportDataSource rds = new ReportDataSource("DataSet1", OnlineShow_datas1);
                    //这个地方的DataSet2是你定义的dataset,dts是你定义的datatable
                    ReportViewer4.LocalReport.DataSources.Clear();
                    ReportViewer4.LocalReport.DataSources.Add(rds);
                    ReportViewer4.LocalReport.Refresh();


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