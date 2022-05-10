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
                ReportViewer1.LocalReport.ReportPath = @"RDLC/Report1.rdlc";
                //假数据
                List<rc_ku_info> OnlineShow_datas1 = new List<rc_ku_info>();
                rc_ku_info item = new rc_ku_info();
                item.Orderid = "id001";
                item.Sp_dm = "Sp_dm001";
                OnlineShow_datas1.Add(item);

                //绑定数据
                ReportDataSource rds = new ReportDataSource("DataSet2", OnlineShow_datas1);
                //这个地方的DataSet2是你定义的dataset,dts是你定义的datatable
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();


                JavaScriptSerializer js = new JavaScriptSerializer();
                //return js.Serialize(null);
            }
            catch
            {
                //return string.Empty;
            }

        }
    }
}