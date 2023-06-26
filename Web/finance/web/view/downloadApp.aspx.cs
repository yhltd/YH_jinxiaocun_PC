using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.finance.web.view
{
    public partial class downloadApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getInstruction();
        }

        /// <summary>
        /// 下载使用说明
        /// </summary>
        private void getInstruction() {
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
                Response.AddHeader("Content-Disposition", "attachment;filename=app-debug.apk");
                //获取文件的绝对路径
                string filename = Server.MapPath("download/app-debug.apk");
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