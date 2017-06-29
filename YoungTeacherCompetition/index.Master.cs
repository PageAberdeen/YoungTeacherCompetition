using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace ComputerBS
{
    public partial class index : System.Web.UI.MasterPage
    {
        private static string ticket = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取地址栏中的ticket参数值
                ticket = Request.QueryString["ticket"];
                if (ticket != "" && ticket != null)
                {
                    //加载页面时验证是否登录
                    ValidateAction();
                }
                if (Session["User"]!=null)
                {
                    UserInfo info=(UserInfo)Session["User"];
                    string value = "<span class='user_face'><a  href='frmExit.aspx' class='loginBtn'/>" + info.UserName + "</a></span>";
                    ChangeType.Text = value;
                 }
                else
                {
                    string CurrentLink = "http://lzyun.doule.net/index.php?r=portal/user/login&service=http://" + Request.Url.Authority+"/Index.aspx";
                
                    string value = "<a href='" + CurrentLink + "' class='loginBtn' id='login_btn' >登录</a>";
                    ChangeType.Text = value;
                    string url = Request.Url.ToString();
                    if (!String.Equals(url.ToLower(), CurrentLink.ToLower()))
                    {
                         Response.Redirect(CurrentLink,true);  
                    };
                }
            }
        }
        private void ValidateAction()
        {
            if (ticket != "" && ticket != null)
            {
                string url = "http://lzyun.doule.net:20114/aamif/ticketValidate?ticket=" + ticket;
                //Response.Write("<script>alert('" + url + "')</script>"); //后台弹出url地址测试

                //XDocument oXDoc = XDocument.Load(url);
                //创建XDocument对象，并根据url请求返回数据,返回的是xml数据
                string userid = UrlHtmlUtil.getuserid(url);
                if (userid != "")
                {
                    Session["userid"] = userid;
                
                    if (Session!=null)
                    {
                        userid=Session["userid"].ToString();
                    }
                    //请求用户信息的url地址
                    string url2 = "http://lzyun.doule.net:20107/aam/rest/user/getuserinfo/" + userid + "?token=" + ticket;
                    //根据URL请求返回获取用户信息数据
                    JObject ja = UrlHtmlUtil.getHtmlJsonByUrl(url2);
                    string usernanme = ja["userinfo"]["name"].ToString();
                    Session["userinfo"] = ja;  //将请求返回的用户信息对象存放到Session["userinfo"]
                    string userID = ((JObject)Session["userinfo"])["userinfo"]["account"].ToString();

                    if (Session["User"] == null)
                    {
                        UrlHtmlUtil.GetUserInfo(userID);
                    }
                }

            }
        }


    }
}