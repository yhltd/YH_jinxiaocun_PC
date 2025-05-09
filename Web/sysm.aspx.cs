﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class sysm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getInstruction();
        }

        /// <summary>
        /// 下载使用说明
        /// </summary>
        private void getInstruction()
        {
            try
            {
                //清除缓冲区流中的所有内容输出
                Response.Clear();
                Response.ClearContent();
                //清除缓冲区流中的所有头
                Response.ClearHeaders();
                //设置流内容类型
                Response.ContentType = "application/octet-stream";
                //设置下载方式=>附件
                Response.AddHeader("Content-Disposition", "attachment;filename= 云合未来进销存管理系统_使用说明.rar");
                //获取文件的绝对路径
                string filename = Server.MapPath("download/ 云合未来进销存管理系统_使用说明.rar");
                //将文件直接写入HTTP响应输出流
                Response.TransmitFile(filename);
            }
            catch
            {
                //清除缓冲区流中的所有内容输出
                Response.Clear();
                Response.ClearContent();
                Response.Write("<script>alert('下载失败，请稍后再试。')</script>");
            }
            finally
            {
                //结束
                Response.End();
            }
        }
    }
}