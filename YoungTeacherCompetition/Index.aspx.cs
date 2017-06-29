using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class Index : System.Web.UI.Page
    {

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            ListDataBin();
        }
        private void ListDataBin()
        {
            //DataTable dt = DbHelperSQL.Query("select * from ActiveInfo", null).Tables[0];
            //List<string> list = new List<string>();
            DataTable p = new DataTable();
            p.Columns.Add("PicPath",typeof(string));
            DataRow dr = p.NewRow();
            dr["PicPath"] = "../Image/3.jpg";
            p.Rows.Add(dr);
            DataRow dr1 = p.NewRow();
            dr1["PicPath"] = "../Image/4.jpg";
            p.Rows.Add(dr1);
            HtmlGenericControl li = new HtmlGenericControl();
            for (int i = 0; i < p.Rows.Count; i++)
            {
                li.InnerHtml += "<li><a href='#'><img src='" + p.Rows[i]["PicPath"] + "'/></a></li>";
                
            }
            Pic.Controls.Add((Control)li);
            
        }
    }
}