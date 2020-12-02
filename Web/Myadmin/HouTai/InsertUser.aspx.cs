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
    public partial class InsertUser : System.Web.UI.Page
    {
        protected clsAllnew can;
        private string type;
        private string id;
        private string gongsi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["type"] != null)
                {
                    type = Request["type"].ToString();
                    if (type == "update")
                    {
                        id = Request["id"].ToString();
                        gongsi = Request["gs"].ToString();
                        can = new clsAllnew();
                        userTable ut = can.selectUser(gongsi).Find(f => f.name.Equals(id) && f.gongsi.Equals(gongsi));
                        Name.Text = ut.name;
                        Pwd.Text = ut.password;
                        Qrpwd.Text = ut.password;
                        if (ut.AdminIS.Equals("true"))
                        {
                            quanxian.Items[0].Selected = true;
                        }
                        else 
                        {
                            quanxian.Items[1].Selected = true;
                        }
                    }
                }
            }
        }

        protected void queren_Click(object sender, EventArgs e)
        {
            try
            {
                string type ="";
                if (Request["type"] != null)
                {
                    type = Request["type"].ToString();
                }
                if (!type.Equals(string.Empty) && type.Equals("insert"))
                {
                    if (Pwd.Text.Equals(Qrpwd.Text))
                    {
                        can = new clsAllnew();
                        userTable ut = new userTable();
                        ut.name = Name.Text;
                        ut.password = Pwd.Text;
                        ut._id = Name.Text;
                        if (Session["gs_name"] != null)
                        {
                            ut.gongsi = Session["gs_name"].ToString();
                        }
                        if (quanxian.Items[quanxian.SelectedIndex].Text.Equals("管理员"))
                        {
                            ut.AdminIS = "true";
                        }
                        else
                        {
                            ut.AdminIS = "false";
                        }

                        int pd = can.add_User(ut);
                        if (pd > 0)
                        {
                            Response.Write("<script>alert('添加成功！');layer.close(layer.index);</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('两次密码输入不一致')</script>");
                    }
                }
                else 
                {
                    if (Pwd.Text.Equals(Qrpwd.Text))
                    {
                        can = new clsAllnew();
                        userTable ut = new userTable();
                        ut._id = id;
                        ut.name = Name.Text;
                        ut.password = Pwd.Text;
                        ut._id = Name.Text;
                        if (Session["gs_name"] != null)
                        {
                            ut.gongsi = Session["gs_name"].ToString();
                        }
                        if (quanxian.Items[quanxian.SelectedIndex].Text.Equals("管理员"))
                        {
                            ut.AdminIS = "true";
                        }
                        else
                        {
                            ut.AdminIS = "false";
                        }
                        int pd = can.up_User(ut);
                        if (pd > 0)
                        {
                            Response.Write("<script>alert('修改成功！');layer.close(layer.index);</script>");
                        }
                    }
                    else 
                    {
                        Response.Write("<script>alert('两次密码输入不一致')</script>");
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}