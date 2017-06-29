using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class frmExit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myExit_Click();       
        }

        private void myExit_Click()
        {
            //UrlHtmlUtil.MsgBoxExit("您确定要退出登录吗？");
            // string url = "http://lzyun.doule.net:20107/aam/rest/account/logout/" + Session["userid"] + "?token=" + ticket;
            //string url =  "http://lzyun.doule.net/index.php?r=portal/user/logout";
            string url = "http://lzyun.doule.net/index.php?r=center/person/index";
            //WebRequest request = WebRequest.Create(url);
            //WebResponse response = request.GetResponse();
            //Stream s = response.GetResponseStream();
            //StreamReader sr = new StreamReader(s, Encoding.GetEncoding("gb2312"));
            //string str = sr.ReadToEnd();
            //try
            //{ }
            //finally
            //{
            //    sr.Dispose();
            //    sr.Close();
            //    s.Dispose();
            //    s.Close();

            //}
            Session["User"] = null;
            DelCookeis();
            Response.Redirect(url, true);

        }

        public void DelCookeis()
        {
            foreach (string cookiename in Request.Cookies.AllKeys)
            {
                HttpCookie cookies = Request.Cookies[cookiename];
                if (cookies != null)
                {
                    //cookies.Value = "";
                    cookies.Expires = DateTime.Today.AddDays(-1);
                    Response.Cookies.Add(cookies);
                    Request.Cookies.Remove(cookiename);
                }
            }
        }
      
    }
}