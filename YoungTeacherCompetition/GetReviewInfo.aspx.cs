using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class GetReviewInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    int wid = Convert.ToInt32(Request.QueryString["wid"]);
                    string sql = "select GroupID from Works where WID=" + wid;
                    //sql += " and GroupID in (" + ((UserInfo)Session["User"]).GroupID + ")";
                    DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        this.labPage.Text = "1";
                        contrlRepeater();
                    }
                    else
                    {
                        Response.Write("<script>alert('不属于该组!')</script>");
                        Response.Redirect("ShowWork.aspx?wid="+wid);
                    }
                }
                else
                {
                    string url = "http://lzyun.doule.net/index.php?r=portal/user/login&service=" + Request.Url.AbsoluteUri;
                    Response.Redirect(url, true);
                }
             }
        }
        protected void lbtnFirstPage_Click(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            this.contrlRepeater();
        }

        protected void lbtnpritPage_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) - 1);
            this.contrlRepeater();
        }

        protected void lbtnNextPage_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text) + 1);
            this.contrlRepeater();
        }

        protected void lbtnDownPage_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.LabCountPage.Text;
            this.contrlRepeater();
        }
        //Repeater分页控制显示方法 
        public void contrlRepeater()
        {
            int wid =Convert.ToInt32(Request.QueryString["wid"].ToString().Trim());
            DataTable pageDt = GetScorce(wid);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = pageDt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 8;
            pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
            CanGetReview.DataSource = pds;
            LabCountPage.Text = pds.PageCount.ToString();
            labPage.Text = (pds.CurrentPageIndex + 1).ToString();
            this.lbtnpritPage.Enabled = true;
            this.lbtnFirstPage.Enabled = true;
            this.lbtnNextPage.Enabled = true;
            this.lbtnDownPage.Enabled = true;
            if (pds.CurrentPageIndex < 1)
            {
                this.lbtnpritPage.Enabled = false;
                this.lbtnFirstPage.Enabled = false;
            }
            if (pds.CurrentPageIndex == pds.PageCount - 1)
            {
                this.lbtnNextPage.Enabled = false;
                this.lbtnDownPage.Enabled = false;
            }
            CanGetReview.DataBind();
        }
        public DataTable GetScorce(int wid) {
            try
            {
                string sql = "select * from Scorce where WID=" + wid;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                DataTable wdt = DbHelperSQL.Query("select * from Works where WID="+wid).Tables[0];
                int groupid = Convert.ToInt32(wdt.Rows[0]["GroupID"]);
                DataTable gdt = GetCategory(groupid.ToString());
                string groupName = "";
                string CateName = "";
                for (int i = 0; i < gdt.Rows.Count; i++)
                {
                    if (groupid.ToString().Equals(gdt.Rows[i]["GroupID"].ToString().Trim())){
                        if (wdt.Rows[0]["CategoryID"].ToString().Trim().Equals(gdt.Rows[i]["CategoryID"].ToString().Trim()))
                        {
                            groupName = gdt.Rows[i]["GroupName"].ToString().Trim();
                            CateName = gdt.Rows[i]["CategoryName"].ToString().Trim();
                        }
                    }
                }
                GroupType.Text = groupName;
                CateType.Text = CateName;
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private DataTable GetCategory(string gropId)
        {
            string sql = "select * from CatagoryGroup";
            if (!string.IsNullOrEmpty(gropId))
            {
                sql += " where GroupID='" + gropId + "'"; ;
            }
            ListItemCollection listIt1 = new ListItemCollection();
            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["CategoryName"] = dt.Rows[i]["CategoryName"].ToString().Trim();
                dt.Rows[i]["GroupID"] = dt.Rows[i]["GroupID"].ToString().Trim();
                dt.Rows[i]["CategoryID"] = dt.Rows[i]["CategoryID"].ToString().Trim();
            }
            return dt;
        }
        //提交分数
        protected void ConfirmValue_Click(object sender, EventArgs e)
        {
            //string sco = CountSum.Text.Trim();
            string sco = tGetScorce.Value;
            int realSco = 0;
            if (sco!=null&&sco.ToString()!="")
            {
                int tsco = Convert.ToInt32(sco);
                if (tsco <= 100 && tsco >= 0)
                {
                    realSco = tsco;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "提示", "alert('请输入分值范围为0-100');", true);
                    return;
                }
            }
            string TextValue = Smohan_textbq.Value.Trim();
            if (TextValue.ToString().Trim()=="")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "提示", "alert('请输入对该作品的评论');", true);
                return;
            }
            int ScorceNub = realSco;
            UserInfo info=(UserInfo)Session["User"];//获取用户
            string SetExpertID = info.UserID.ToString();
            string SetExpertName =info.UserName;
            int WID = Convert.ToInt32(Request.QueryString["wid"]);
            string WExpertNote = TextValue;
            string sqlselect = "select * from Scorce where SetExpertID='"+SetExpertID+"' and WID="+WID;
            bool canInsert = DbHelperSQL.Exists(sqlselect); ;
            if (!canInsert)
            {
                int type = DBHelper.InsertScorce(ScorceNub, SetExpertID, SetExpertName, WID, WExpertNote);
                if (type == 1)
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "提示", "alert('您对该作品打分成功！');", true);
                    GetScorce(WID);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "提示", "alert('抱歉，您的打分失败，请重试！');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "提示", "alert('您已经对该作品进行打分，请勿重复打分');", true);
                return;
            }

            //str.Append("<script>");
            //str.Append("$('#ConfirmValue').on('click', function() {");
            //str.Append("art.tips({");
            //str.Append("type: 1,");
            //str.Append("content: '发表成功！',");
            //str.Append("time: '2000',");           
            //str.Append(" lock: true");            
            //str.Append("})");   
            //str.Append("});");
            //str.Append("</script>");
            //ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "123", "alert('提示信息');", true);
        }

        protected void InsertBt_Click(object sender, EventArgs e)
        {
            //string scorce=ScorceText.Text.Trim();
            //LGetScorce.Text = scorce;
            //Response.Write("<script>alert('show')</script>");
        }

        protected void DownFileY_Click(object sender, EventArgs e)
        {
            try
            {
                //int wid = Convert.ToInt32(Request.QueryString["wid"].ToString());
                //DBHelper db = new DBHelper();
                //string WPackageName = db.GetWorksStringById(wid);
                ////string WPackageName = db.GetWorksStringById(3);
                //string fileName = WPackageName;//客户端保存的文件名
                //string ServicePath = "~/Fileupload/" + fileName;
                //string filePath = Server.MapPath(ServicePath);//路径
                ////以字符流的形式下载文件
                //FileStream fs = new FileStream(filePath, FileMode.Open);
                //byte[] bytes = new byte[(int)fs.Length];
                //fs.Read(bytes, 0, bytes.Length);
                //fs.Close();
                //Response.ContentType = "application/octet-stream";
                ////通知浏览器下载文件而不是打开
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                //Response.BinaryWrite(bytes);
                //Response.Flush();
                //Response.End();
                int wid = Convert.ToInt32(Request.QueryString["wid"].ToString());
                DBHelper db = new DBHelper();
                string WPackageName = db.GetWorksStringById(wid);
                string fileName = WPackageName;//客户端保存的文件名
                string strPath = Server.MapPath("/") + "Fileupload//" + fileName;
                DownloadFile(strPath, fileName);
            }
            catch (Exception)
            {

            }
        }
        public void DownloadFile(string path, string name)
        {
            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                Response.Clear();
                Response.Charset = "GB2312";
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                // 添加头信息，为"文件下载/另存为"对话框指定默认文件名
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(name));
                // 添加头信息，指定文件大小，让浏览器能够显示下载进度
                Response.AddHeader("Content-Length", file.Length.ToString());
                // 指定返回的是一个不能被客户端读取的流，必须被下载
                Response.ContentType = "application/ms-excel";
                // 把文件流发送到客户端
                Response.WriteFile(file.FullName);
                // 停止页面的执行
                //Response.End(); 
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('系统出现以下错误://n" + ex.Message + "!//n请尽快与管理员联系.')</script>");
            }
        }
    }
}