using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class TfrmShowText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UrlHtmlUtil.GetUserRole().Equals("申报人"))
                {
                    JumpInterface(UrlHtmlUtil.GetSchoolGroupID());
                }
                else
                {
                    UrlHtmlUtil.MsgBox("您不具备申报人权限！");
                }
                
            }
        }
         

        public void JumpInterface(string mySchoolGroupID)
        {
            string iframe;
            if (mySchoolGroupID.Equals("2"))//初中组
            {
                //iframe = "<iframe id='MyIframe'  style='padding:0;margin:0'src='ErrorPage.aspx'></iframe>";
                iframe = "~/FrmFillMatchInfo2.aspx";  
            }
            else
            {
                iframe = "~/FrmFillMatchInfo.aspx"; 
                //iframe = "<iframe id='MyIframe'  style='padding:0;margin:0'src='FrmFillMatchInfo.aspx'></iframe>";
            }
            //ReplaceByIframe.Text = iframe;
            Response.Redirect(iframe);
        }
    }
}