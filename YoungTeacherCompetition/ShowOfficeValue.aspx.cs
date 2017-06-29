//using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Office.Interop.PowerPoint;
using Microsoft.CSharp;
using Microsoft.Office;
using System.Runtime.InteropServices;
using System.IO;

namespace ComputerBS
{
    public partial class ShowOfficeValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filepath = Request.QueryString["FilePath"].ToString().Trim();
                //string filepath = "Fileupload/JY5501007-2017关于发动机零部件二维码后续事宜的会议纪要.doc";
                //string test = "http://" + Request.Url.Authority;
                //string pathFile = test + filepath;
                ChangeFileToPDF(filepath);
            }
        }

        private void ChangeFileToPDF(string filepath)
        {
            try
            {
                string PDFPath = Server.MapPath("/PDF/");//指定上传文件在服务器上的保存路径
                //检查服务器上是否存在这个物理路径，如果不存在则创建
                if (!System.IO.Directory.Exists(PDFPath))
                {
                    System.IO.Directory.CreateDirectory(PDFPath);
                }
                string str = "";
                if (filepath.EndsWith(".xls")||filepath.EndsWith(".doc")||filepath.EndsWith(".ppt")||filepath.EndsWith(".xlsx")||filepath.EndsWith(".docx")||filepath.EndsWith(".pptx"))
                {
                    string[] strs=filepath.Split('.');
                    for (int i = 0; i < strs.Length-1; i++)
                    {
                        str += strs[i];
                    }
                    str += ".pdf";
                }
                str=str.Replace("Fileupload/", "");
                string isFile = "/PDF/" + str;
                //string urlFile = "http://" + Request.Url.Authority + "/PDF/"+str;
                //string inFile = "http://" + Request.Url.Authority + "/PDF/";
                string CheckFile = Server.MapPath("PDF/") + str;
                //Response.Write("<script>alert('" + urlFile + "')</script>");
                //Response.Write("<script>alert('" + isFile + "')</script>");
                //if (!File.Exists(@CheckFile))
                //{
                //    bool t = false;
                //    if (filepath.EndsWith(".doc")||filepath.EndsWith(".docx"))
                //    {
                //        t = Office2PDFHelper.DOCConvertToPDF(MapPath(filepath), MapPath(isFile));
                //    }
                //    if (filepath.EndsWith(".xls")||filepath.EndsWith(".xlsx"))
                //    {
                //        t = Office2PDFHelper.XLSConvertToPDF(MapPath(filepath), MapPath(isFile));
                //    }
                //    if (filepath.EndsWith(".ppt")||filepath.EndsWith(".pptx"))
                //    {
                //        t = Office2PDFHelper.PPTConvertToPDF(MapPath(filepath), MapPath(isFile));
                //    }
                //    if (t)
                //    {
                //        string file = isFile;
                //        OpenPDF(file);
                //    }
                //    else
                //    {
                //        StrValue.Text = "";
                //    }
                //}
                //else
                //{
                    string file = isFile;
                    OpenPDF(file);
                //}
                //string str = "JY5501007-2017关于发动机零部件二维码后续事宜的会议纪要.pdf";
            }
            catch (Exception)
            {
                Response.Write("该文件无法打开！");
            }
            
        }
        public void OpenPDF(string file)
        {
            try
            {
                string pdfPath = Server.MapPath("~"+file);
                FileStream fs = File.Open(pdfPath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
                if (fs.Length > 0)
                {
                    byte[] bfBuf = new byte[fs.Length];
                    bfBuf.Initialize();
                    fs.Read(bfBuf, 0, (int)fs.Length);
                    Response.ContentType = "application/PDF";
                    Response.OutputStream.Write(bfBuf, 0, bfBuf.Length);//以流的形式显示在网页上
                    // Response.ContentType = 
                    // Response.BinaryWrite(bfBuf);
                    Response.End();
                    fs.Close();
                }
            }catch(Exception){
            }
            finally
            {
                Response.Write("无法显示该数据!");
            }
        }
    }
}