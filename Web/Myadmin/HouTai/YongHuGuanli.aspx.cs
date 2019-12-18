using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clsBuiness;
using SDZdb;
namespace Web.Myadmin.HouTai
{
    public partial class YongHuGuanli : System.Web.UI.Page
    {
        clsAllnew can = new clsAllnew();
        protected List<userTable> YongHutable;
        //protected Repeater UserRep;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectUser();
                string act = Request["act"] == null ? "" : Request["act"].ToString();
                if (act.Equals("PostUser"))
                {
                    string id = Request["id"] == null ? "" : Request["id"].ToString();
                    string gongsi = Request["gongsi"] == null ? "" : Request["gongsi"].ToString();
                    delete(id, gongsi);
                }
            }
        }
        public void delete(string id, string gongsi)
        {
            try
            {
                int i = can.del_Usertable(id, gongsi);
                if (i > 0)
                {
                    Response.Write("[{\"endtext\":\"删除成功\"}]");
                    SelectUser();
                }
                else
                {
                    Response.Write("[{\"endtext\":\"删除失败\"}]");
                }
                //Response.Write(JSONObj);
                //一定要加，不然前端接收失败
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void SelectUser()
        {
            if (Session["username"] != null && !Session["gs_name"].ToString().Equals(string.Empty))
            {
                List<userTable> list = can.selectUser().FindAll(f => f.gongsi != null && f.gongsi.Equals(Session["gs_name"].ToString()));
                //YongHutable = list;
                YongHutable = new List<userTable>();
                foreach (userTable ut in list)
                {
                    userTable addut = new userTable();
                    addut._id = ut._id;
                    addut.Btype = ut.Btype;
                    addut.Createdate = ut.Createdate;
                    addut._openid = ut._openid;
                    addut.gongsi = ut.gongsi;
                    addut.jigoudaima = ut.jigoudaima;
                    addut.name = ut.name;
                    addut.password = ut.password;
                    addut.mi_bao = ut.mi_bao;
                    if (ut.AdminIS != null && ut.AdminIS.Equals("true"))
                    {
                        addut.AdminIS = "管理员";
                    }
                    else
                    {
                        addut.AdminIS = "普通用户";
                    }
                    YongHutable.Add(addut);
                }
                UserFor.DataSource = YongHutable;
                UserFor.DataBind();
            }
        }

        protected void BTN_ShuaXing_Click(object sender, EventArgs e)
        {
            try
            {
                SelectUser();
                Response.Write("<script>alert('刷新成功！')</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void BTN_Insert_Click(object sender, EventArgs e)
        {


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_DELETE_Click(object sender, EventArgs e)
        {
            //try 
            //{
            //    string id = Request["delid"];
            //    string gongsi = Request["delgongsi"];
            //}
            //catch (Exception ex) 
            //{

            //}
        }
    }
}