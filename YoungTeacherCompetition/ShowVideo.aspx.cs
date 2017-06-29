using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class ShowVideo : System.Web.UI.Page
    {
        public  static string FilePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetWork();
            }
        }
        public string GetWork()
        {
            FilePath = Request.QueryString["FilePath"];
            string strUrl = "http://" + Request.Url.Authority + "/" + FilePath;
            return strUrl;
        }
    }
}