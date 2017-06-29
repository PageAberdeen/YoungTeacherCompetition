using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class UpFile : System.Web.UI.Page
    {
        private static string EnrollID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               EnrollID =  Request.QueryString["EnrollID"].ToString().Trim();
            }
        } 


        protected void btUpFile_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (FileUp1.HasFile)
                {
                    string filePath = Path.GetFullPath(FileUp1.PostedFile.FileName);
         
                    if (filePath != "")
                    {
                        string savePath = Server.MapPath("~/Fileupload/");//指定上传文件在服务器上的保存路径
                        //检查服务器上是否存在这个物理路径，如果不存在则创建
                        if (!System.IO.Directory.Exists(savePath))
                        {
                            System.IO.Directory.CreateDirectory(savePath);
                        }
                        string worksName=FileUp1.FileName;
                        string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + worksName;

                        savePath = savePath + fileName;                       
                        FileUp1.SaveAs(savePath);
                        if (System.IO.File.Exists(savePath))
                        {
                             if (UrlHtmlUtil.AddEnrolEntries(EnrollID, worksName,"Fileupload/" + fileName))
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show", "<script>alert('上传成功！')</script>", false);
                                string iframe = "~/FrmFillMatchInfo.aspx"; 
                                Response.Redirect(iframe);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show", "<script>alert('上传失败！')</script>", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show", "<script>alert('请先选择导入文件后，再执行导入！谢谢！')</script>", false);

                    }
                }
            }
            catch (Exception)
            {
            }
        }

    }
}