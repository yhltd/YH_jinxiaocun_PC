using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Order.Common;
using clsBuiness;
using System.Reflection;
using System.Web.Services;
using System.Web.Script.Serialization;
using Web.jxc_service;
using System.Collections;
using SDZdb;
using Web.Server;
using Web.ServerEntity;

namespace Web
{
    public partial class ru_ku : System.Web.UI.Page
    {
        public string ConStr;
        public string ConStrPIC;
        public string rev_servename;
        protected int sb;

        private static yh_jinxiaocun_user user;

        private string act, result;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];

            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
            }

        if(user != null)
            {
                act = Request["act"] == null ? "" : Request["act"].ToString();
                result = string.Empty;
                switch (act)
                {
                    case "newSp":
                        result = getNewSp();
                        break;
                    case "checkOrder":
                        result = checkOrderId(Request["order_id"]);
                        break;
                    case "gongguoList":
                        result = getGongHuoList();
                        break;
                    case "insert":
                        result = insert_ruku(Request["infos"].ToString());
                        break;
                }
                if (!result.Equals(string.Empty)) {
                    Response.Clear();
                    Response.Write(result);
                    Response.End();
                }
            }
            else {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
        }

        public static string checkOrderId(string order_id)
        {
            try
            {
                MingxiModel mingXiModel = new MingxiModel();
                string result = mingXiModel.checkOrder_id(order_id, user.gongsi);
                return result;
            }
            catch {
                return "500";
            }
        }

        public static string getNewSp()
        {
            try
            {
                JinChuModel jinChuModel = new JinChuModel();
                List<JinChuZiLiaoItem> list = jinChuModel.getSetStockDetail(user.gongsi);
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(list);
            }
            catch
            {
                return string.Empty;
            }
        }
     


        public string insert_ruku(string list)
        {
            try
            {
                items infoList = new items();
                JavaScriptSerializer js = new JavaScriptSerializer();
                infoList = js.Deserialize<items>(list);
                MingxiModel mingXiModel = new MingxiModel();
                int result = mingXiModel.add(infoList, user.gongsi, user.name, "入库");
                return result.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string getGongHuoList()
        {
            try
            {
                JinHuoModel jinHuoModel = new JinHuoModel();
                List<string> gonghuo = jinHuoModel.getGongHuo(user.gongsi);
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(gonghuo);
            }
            catch
            {
                return string.Empty;
            }
            
        }

        protected void shou_ye_Click(object sender, EventArgs e)
        {

        }

        protected void shang_ye_Click(object sender, EventArgs e)
        {

        }

        protected void xia_ye_Click(object sender, EventArgs e)
        {

        }

        protected void mo_ye_Click(object sender, EventArgs e)
        {

        }


        protected void toExcel(object sender, EventArgs e)
        {

            List<rukuPrint> OnlineShow_datas1 = new List<rukuPrint>();
            int id = 0;
            for (int i = 1; i < (Convert.ToInt32(Context.Request["hangshu"].ToString())); i++)
            {
                //item.Name = Response.  ;//.ToString();
                JinChuModel jinchu = new JinChuModel();
                
                if (Request.Form["check" + i] == "true")
                {
                    rukuPrint item = new rukuPrint();
                    id = Convert.ToInt32(Request.Form["checkbox" + i]);
                    List<yh_jinxiaocun_jichuziliao> list = jinchu.getListById(user.gongsi, id);
                    item.Cpname = list[0].name;
                    item.sp_dm = list[0].sp_dm;
                    item.Cpsl = Context.Request["num"+i].ToString();
                    item.Cpsj = Context.Request["price" + i].ToString();
                    item.Cplb = list[0].lei_bie;
                    item.Mxtype = list[0].dan_wei;
                    OnlineShow_datas1.Add(item);
                }
            }
            Session["printList"] = OnlineShow_datas1;

            Response.Redirect("./RDLC/frm_ReportForm.aspx");

        }
    }
}