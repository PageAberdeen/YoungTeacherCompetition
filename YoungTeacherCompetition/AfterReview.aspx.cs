using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class AfterReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.labPage.Text = "1";
                int wid = Convert.ToInt32(Request.QueryString["wid"].ToString());
                contrlRepeater();
            }
        }

        protected void DownFile_Click(object sender, EventArgs e)
        {
            try
            {
                int wid = Convert.ToInt32(Request.QueryString["wid"].ToString());
                DBHelper db = new DBHelper();
                string WPackageName = db.GetWorksStringById(wid);
                //string WPackageName = db.GetWorksStringById(3);
                string fileName = WPackageName;//客户端保存的文件名
                string ServicePath = "~/Fileupload/" + fileName;
                string filePath = Server.MapPath(ServicePath);//路径
                //以字符流的形式下载文件
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开
                Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch (Exception)
            {
               
            }

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
        private DataTable BingGetType(string Type)
        {
            string sql = "select * from CatagoryGroup";
            if (!String.IsNullOrEmpty(Type))
            {
                sql = sql + " where GroupName='" + Type + "'";
            }
            sql += " order by GroupID";
            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
            DataRow dr = dt.NewRow();
            dr["GroupName"] = "-请选择-";
            dr["GroupID"] = "0";
            dt.Rows.InsertAt(dr, 0);
            DataTable rdt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["GroupID"].ToString().Trim();
                //string name = dt.Rows[i]["GroupName"].ToString().Trim();
                if (rdt.Rows.Count != 0)
                {
                    bool add = true;
                    foreach (DataRow item in rdt.Rows)
                    {
                        string test = item["GroupID"].ToString().Trim();
                        if (item["GroupID"].ToString().Trim().Equals(id))
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                    {
                        rdt.Rows.Add(dt.Rows[i].ItemArray);
                    }
                }
                else
                {
                    rdt.Rows.Add(dt.Rows[i].ItemArray);
                }
                //dt.Rows[i]["GroupID"] = dt.Rows[i]["GroupID"].ToString().Trim();
                //dt.Rows[i]["GroupName"] = dt.Rows[i]["GroupName"].ToString().Trim();
            }
            return rdt;
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
            AllReview.DataSource = pds;
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
            if (pageDt.Rows.Count>0)
            {
                AllReview.DataBind();
            }
            
        }
    }
}