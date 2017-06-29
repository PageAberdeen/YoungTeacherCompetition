using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace ComputerBS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }
        protected void Application_Disposed(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("userid");
            if (cookie.Value!= null)
            {
                string url = "http://lzyun.doule.net:20107/aam/rest/account/logout/" + cookie.Value.ToString() + "?token=" + Request.QueryString["ticket"];
                Response.Redirect(url,true);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            WriteLogTest.WriteLog(ex.Message);
            Server.ClearError();
            //StringBuilder Builder = new StringBuilder();
            //Builder.Append("<script language=’javascript’ >");
            //Builder.AppendFormat("var a=window.location+'/ErrorPage.aspx';");
            //Builder.AppendFormat("window.location.href=a;");
            //Builder.Append("</script>");
            //Response.Write(Builder.ToString());
            //ScriptManager.(this, this.GetType(),"提示", Builder.ToString(), false);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", Builder.ToString()); 
            //Response.Redirect("~/ErrorPage.aspx");
        }

    }
}