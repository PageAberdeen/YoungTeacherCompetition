using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class ShowInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str=Request.QueryString["ID"];
            //DataBindToLabel(str);
            //Response.Write("<script>alert('"+str+"');</script>");
        }

        private void DataBindToLabel(string str)
        {
            try
            {
                string sql = "select * from ActiveInfo where InfoID=" + str;
                DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
                Text.Text = dt.Rows[0]["InfoValue"].ToString();
                //LabelTitle.Text = dt.Rows[0]["InfoText"].ToString();
                //Response.Write("<script>var str=String(window.location);alert(str);</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('无此数据');</script>");
                //资源接口，
            }
            
        }
    }
}