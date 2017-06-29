using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class ShowAllWorks : System.Web.UI.Page
    {
        private static string UserNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserNo = UrlHtmlUtil.GetUserNo();
        }
        private void BindDataByReview()
        {
            DataTable dt = UrlHtmlUtil.GetTEnrolInfo(UserNo);//传评审人ID进去，返回对应评审信息
            GridViewData.DataSource = dt;
            GridViewData.DataBind();

        }


        protected void GridViewData_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewData.PageIndex = e.NewPageIndex;
                //BindDataByReview();
            }
            catch (Exception)
            {


            }
        }
      



    }
}