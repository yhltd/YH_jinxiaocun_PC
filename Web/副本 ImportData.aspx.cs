using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ImportData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.Style.Add("display", "none");

        }

        
      
        protected void UploadButton_Click(object sender, EventArgs e)
        {
              // 设置文件保存目录
            string appPath = Request.PhysicalApplicationPath + @"Uploads\";
            if (!System.IO.Directory.Exists(appPath)) System.IO.Directory.CreateDirectory(appPath);
 
            if (FileUpload1.HasFile)
            {
                String fileName = FileUpload1.FileName;
                string savePath = appPath + Server.HtmlEncode(FileUpload1.FileName);    // 生成保存路径
 
                FileUpload1.SaveAs(savePath);                                           // 保存文件

                txrearchID.Text = "" + savePath;        
            }
            else
            {
                txrearchID.Text = "";
            }
 
        }

        protected void vcButton_Click(object sender, EventArgs e)
        {

        }
    }
}