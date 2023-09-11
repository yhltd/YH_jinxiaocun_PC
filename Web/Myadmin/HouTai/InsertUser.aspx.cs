using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using clsBuiness;
using SDZdb;
using Web.Server;
namespace Web.Myadmin.HouTai
{
    public partial class InsertUser : System.Web.UI.Page
    {
        private static yh_jinxiaocun_user user;

        private string type;
        private string id;
        private string gongsi;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (yh_jinxiaocun_user)Session["user"];
            if (user.AdminIS.Equals("false"))
            {
                Response.Redirect("~/wqx.aspx");
            }
            if (user == null)
            {
                Response.Write("<script>alert('请登录！'); window.parent.location.href='/Myadmin/Login.aspx';</script>");
            }
            else
            {
                if (Request["type"] != null)
                {
                    type = Request["type"].ToString();
                    Name.ReadOnly = type == "update";
                    if (Name.ReadOnly)

                    {
                        id = Request["id"].ToString();
                        gongsi = user.gongsi;
                        UserModel u = new UserModel();
                        yh_jinxiaocun_user ut = u.getList(gongsi).Find(f => f._id.Equals(id) && f.gongsi.Equals(gongsi));
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
                UserModel u = new UserModel();
                string type = "";
                if (Request["type"] != null)
                {
                    type = Request["type"].ToString();
                }
                if (!Session["userNum"].ToString().Equals(""))
                {
                    int thisNum = Convert.ToInt32(Session["userNum"].ToString());
                    UserModel s = new UserModel();
                    List<yh_jinxiaocun_user> list = s.getUserNum(user.gongsi);
                    int count = Convert.ToInt32(list[0]._id);
                    if (count >= thisNum)
                    {
                        Response.Write("<script>alert('已有账号数量过多，请删除无用账号后再试！');</script>");
                        return;
                    }
                }
                if (!type.Equals(string.Empty) && type.Equals("insert"))
                {
                    if (Request.Form["Pwd"].ToString().Equals(Request.Form["Qrpwd"].ToString()))
                    {
                        yh_jinxiaocun_user uer = new yh_jinxiaocun_user();
                        uer.name = Request.Form["Name"];
                        uer.password = Request.Form["Pwd"];
                        uer._id = Request.Form["Name"];
                        uer.Btype = Request.Form["Name"];
                        uer.gongsi = user.gongsi;
                        //uer.AdminIS= Request.Form["quanxian"];
                        if (quanxian.Items[quanxian.SelectedIndex].Text.Equals("管理员"))
                        {

                            uer.AdminIS = "true";
                        }
                        else
                        {
                            uer.AdminIS = "false";
                        }

                        int pd = u.add(uer);
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
                   
                        if (Request.Form["Pwd"].ToString().Equals(Request.Form["Qrpwd"].ToString()))
                        {
                            yh_jinxiaocun_user uer = new yh_jinxiaocun_user();
                            uer._id = Request.Form["Name"];
                            uer.name = Request.Form["Name"];
                            uer.password = Request.Form["Pwd"];
                            uer.Btype = Request.Form["Name"];
                            uer.gongsi = user.gongsi;
                            //uer.AdminIS = "false";
                            String quanxianis = Request.Form["quanxian"];
                            if (quanxianis.Equals("管理员"))
                            {

                                uer.AdminIS = "true";
                            }
                            else
                            {
                                uer.AdminIS = "false";
                            }
                            int pd = u.update(uer);
                           
                            if (pd > 0)
                            {
                                
                                Response.Write("<script>alert('修改成功！');layer.close(layer.index);</script>");
                                //Response.Redirect("../HouTai/InsertUser.aspx");
                                //Response.Write("<script>layer.opener==null;layer.close();</script>");
                                
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('两次密码输入不一致')</script>");
                        }
                    }                 
                }
                catch
                {
                    yh_jinxiaocun_user uer = new yh_jinxiaocun_user();
  
                    Response.Write("<script>alert('错误！');</script>");
                   
                }  
        }
        
    }
}