using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ComputerBS
{
    public class WriteLogTest
    {
        public static void WriteLog(string conten)
        {
            //string txtPath = System.Windows.Forms.Application.ExecutablePath + "\\Log.txt";
            //string str = System.Windows.Forms.Application.ExecutablePath;
            string txtPath = "";
            try
            {
                txtPath = System.Web.HttpContext.Current.Server.MapPath("") + "\\Log.txt";
            }
            catch (Exception e)
            {
                txtPath = System.Environment.CurrentDirectory + "\\Log.txt";
            }

            if (!File.Exists(txtPath))
            {
                //FileStream fs = new FileStream(txtPath, FileMode.OpenOrCreate);
                using (FileStream fileRead = new FileStream(txtPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fileRead, System.Text.Encoding.Default))
                    {
                        sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：  ---------  " + conten);
                        sw.WriteLine(""); //输出空行   
                        sw.Close();
                    }
                }

            }
            else
            {
                //获取文件对象大小
                FileInfo fileInfo = new FileInfo(txtPath);
                if (fileInfo.Length > 5120)
                {
                    fileInfo.MoveTo(GetNewFileName(txtPath));
                    //fileInfo.Create(txtPath);
                    FileStream fs = new FileStream(txtPath, FileMode.Create);
                }

                StreamWriter sw = new StreamWriter(txtPath, true, System.Text.Encoding.Default);

                sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：  ---------  " + conten);
                sw.WriteLine(""); //输出空行   
                sw.Close();
            }
            //FileStream fs = new FileStream(txtPath, FileMode.OpenOrCreate);

        }
        public static string GetNewFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;
            //文件后缀名
            string extenstion = fileName.Substring(fileName.LastIndexOf(".") + 1);
            string name = fileName.Substring(0, fileName.LastIndexOf(".")) + "(" + DateTime.Now.ToString("yyyyMMddHHmmss") + ")";
            string newFileName = name + "." + extenstion;
            return newFileName;
        }
    }
}