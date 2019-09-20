using clsBuiness;
using SDZdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Myadmin
{
    public partial class changepassword : System.Web.UI.Page
    {
        public string alterinfo1;
        List<clsuserinfo> userlist_Server;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            clsAllnew BusinessHelp = new clsAllnew();
            userlist_Server = new List<clsuserinfo>();
            string strSelect = "select * from Yh_JinXiaoCun_user where name='" + textBox6.Text.Trim() + "' and mi_bao='" + textBox1.Text.Trim() + "'";

            userlist_Server = BusinessHelp.findUser(strSelect);
            if (userlist_Server.Count == 0)
            {
                alterinfo1 = "请填写正确的密保！";
                return;
            }
            alterinfo1 = "";
          //  userlist_Server = new List<clsuserinfo>();
            clsuserinfo item = new clsuserinfo();
            
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {

                alterinfo1 = "请填写完整信息然后创建！";
                return;


            }
            if (textBox4.Text.Trim() != textBox5.Text.Trim())
            {

                alterinfo1 = "两次输入的用户密码不一致，请重新输入！";
                return;

            }
           
            item.name = textBox6.Text.Trim();
            item.password = textBox5.Text.Trim();
            foreach (clsuserinfo item_11 in userlist_Server)
            {
                item.Order_id = item_11.Order_id;
            }

            userlist_Server.Add(item);

            BusinessHelp.changeUserpassword_Server(userlist_Server);


            alterinfo1 = "密码修改成功！";


        }

        protected void button2_Click(object sender, EventArgs e)
        {

        }



    }
}