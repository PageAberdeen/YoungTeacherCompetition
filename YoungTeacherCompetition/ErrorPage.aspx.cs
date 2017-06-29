using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Text = "抱歉，操作过程中发生错误，请点击返回首页！";
            Server.ClearError();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }
    }
}