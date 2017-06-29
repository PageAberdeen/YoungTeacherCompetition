using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class Active : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listDataBind();
        }

        private void listDataBind()
        {
            //DataTable dt=DbHelperSQL.Query("select * from ActiveInfo",null).Tables[0];
            //ActiveInfoList.DataSource = dt;
            //ActiveInfoList.DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            try
            {
                string WPackageName = "活动动态——关于举办第十八届全国中小学电脑制作活动的通知.docx";
                //string WPackageName = db.GetWorksStringById(3);

                string fileName = WPackageName;//客户端保存的文件名
                string strPath = Server.MapPath("/") + "DownFile//" + fileName;
                DownloadFile(strPath, fileName);
            }
            catch (Exception)
            {

            }
        }
        public void DownloadFile(string path, string name)
        {
            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                Response.Clear();
                Response.Charset = "GB2312";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                // 添加头信息，为"文件下载/另存为"对话框指定默认文件名
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(name));
                // 添加头信息，指定文件大小，让浏览器能够显示下载进度
                Response.AddHeader("Content-Length", file.Length.ToString());
                // 指定返回的是一个不能被客户端读取的流，必须被下载
                Response.ContentType = "application/ms-excel";
                // 把文件流发送到客户端
                Response.WriteFile(file.FullName);
                // 停止页面的执行
                //Response.End(); 
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('系统出现以下错误://n" + ex.Message + "!//n请尽快与管理员联系.')</script>");
            }
        }
    }
}