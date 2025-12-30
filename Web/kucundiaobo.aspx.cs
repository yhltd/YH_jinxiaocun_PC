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
    public partial class kucundiaobo : System.Web.UI.Page
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
                        string warehouse = Request["warehouse"] == null ? "A仓库" : Request["warehouse"].ToString();
                        result = getNewSp(warehouse);
                        break;
                    case "checkOrder":
                        result = checkOrderId(Request["order_id"]);
                        break;
                    case "gongguoList":
                        result = getGongHuoList();
                        break;
                    case "insert":
                        result = insert_db(Request["infos"].ToString());
                        break;
                    case "warehouseList":
                        result = getWarehouseList();
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

        // 添加获取仓库列表的方法
        public static string getWarehouseList()
        {
            try
            {
                // 使用我们刚才创建的 CangKuModel
                CangKuModel cangKuModel = new CangKuModel();
                List<yh_jinxiaocun_cangku> warehouses = cangKuModel.getList(user.gongsi);

                // 提取仓库名称列表
                List<string> warehouseNames = new List<string>();
                foreach (var warehouse in warehouses)
                {
                    if (!string.IsNullOrEmpty(warehouse.cangku))
                    {
                        warehouseNames.Add(warehouse.cangku);
                    }
                }

                // 如果没有仓库，返回空数组
                if (warehouseNames.Count == 0)
                {
                    warehouseNames.Add(""); // 空选项
                }

                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(warehouseNames);
            }
            catch (Exception ex)
            {
                // 记录错误并返回空数组
                return "[]";
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

        public static string getNewSp(string warehouse)
        {
            try
            {
                JinChuModel jinChuModel = new JinChuModel();
                List<JinChuZiLiaoItem> list = jinChuModel.getSetStockDetailDB(user.gongsi, warehouse);
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Serialize(list);
            }
            catch
            {
                return string.Empty;
            }
        }



        public string insert_db(string list)
        {
            try
            {
                // 1. 创建 items 对象并反序列化 JSON
                items infoList = new items();
                JavaScriptSerializer js = new JavaScriptSerializer();
                infoList = js.Deserialize<items>(list);

                // 2. 提取仓库信息
                string rwarehouse = "";
                string cwarehouse = "";

                if (infoList != null)
                {
                    var data = js.Deserialize<Dictionary<string, object>>(list);
                    if (data.ContainsKey("Rwarehouse"))
                        rwarehouse = data["Rwarehouse"].ToString();
                    if (data.ContainsKey("Cwarehouse"))
                        cwarehouse = data["Cwarehouse"].ToString();
                }

                // 3. 调用数据模型方法执行入库操作
                MingxiModel mingXiModel = new MingxiModel();
                int result = mingXiModel.addDB(infoList, user.gongsi, user.name, "调拨入库", "调拨出库", rwarehouse, cwarehouse);

                // 4. 返回结果
                return result.ToString();
            }
            catch
            {
                // 异常时返回空字符串
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