using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class ShowCase : System.Web.UI.Page
    {
        DataTable Alldt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BinDataWhenEmpty();
                this.labPage.Text = "1"; 
                this.contrlRepeater(); 
            }
        }
        private void BinDataWhenEmpty() {
            DataTable dt = GetWorksInfo("");
            Alldt = dt;
            DataTable getDt = dt.Clone();
            DataRowCollection dc =dt.Rows;
            if (dt.Rows.Count>8)
            {
                for (int i = 0; i < 8; i++)
                {
                    getDt.Rows.Add(dc[i].ItemArray);
                }
                Works.DataSource = getDt;
            }
            else
            {
                Works.DataSource = dt;
            }
            Works.DataBind();
        }
        public DataTable GetWorksInfo(string t) {
            
            string sql = "select * from Works";
            if (!string.IsNullOrEmpty(t)&&!"0".Equals(t))
            {
                sql += " where GroupID='" + t + "'"; ;
            }
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["WID"] = dt.Rows[i]["WID"].ToString().Trim();
                //dt.Rows[i]["WAddDate"] = dt.Rows[i]["WAddDate"].ToString().Trim();
                string tesg = dt.Rows[i]["WName"].ToString().Trim();
                dt.Rows[i]["WName"] = dt.Rows[i]["WName"].ToString().Trim();
                dt.Rows[i]["WUserName"] = dt.Rows[i]["WUserName"].ToString().Trim();
                //dt.Rows[i]["CategoryID"] = dt.Rows[i]["CategoryID"];
                //dt.Rows[i]["GroupID"] = dt.Rows[i]["GroupID"];
            }
            return dt;
        }

        protected void ChangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItemCollection list = ChangeType.Items;
            string str=list[1].Text;
            string str1 = list[1].Value;
            ListItem li = ChangeType.Items.FindByValue(ChangeType.Text);
            string value = "";
            if (li.Value!="0")
            {
                value = li.Value;
            }
            DataTable dt = GetWorksInfo(value);
            Alldt = dt;
            this.labPage.Text = "1";
            contrlRepeater();
            //DataTable getDt = dt.Clone();
            //if (dt.Rows.Count > 8)
            //{
            //    for (int i = 0; i < 8; i++)
            //    {
            //        getDt.Rows.Add(dt.Rows[i].ItemArray);
            //    }
            //    Works.DataSource = getDt;
            //}
            //else
            //{
            //    Works.DataSource = dt;
            //}
            //Works.DataBind();
        }
        public DataTable GetPageTable(int nowPage,int nextPage) {
            DataTable dt=new DataTable();
            return dt;
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
            string value = ChangeType.SelectedValue;
            DataTable pageDt = GetWorksInfo(value);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource =pageDt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 8;
            pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
            Works.DataSource = pds;
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
           Works.DataBind();
        }      
    }
}