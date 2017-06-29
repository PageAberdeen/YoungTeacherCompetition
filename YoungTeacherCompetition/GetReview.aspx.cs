using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class GetReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.labPage.Text = "1";
                //int wid = Convert.ToInt32(Request.QueryString["wid"].ToString());
                GetBindDop();
                contrlRepeater();
            }
        }
        private void GetBindDop()
        {
            GetGroup.DataSource = BingGetType("");
            GetGroup.DataTextField = "GroupName";
            GetGroup.DataValueField = "GroupID";
            GetGroup.DataBind();
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
            }
            return rdt;
        }
        protected void GetGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItemCollection listc = GetGroup.Items;
            ListItem list = listc.FindByText(GetGroup.Text.Trim());
            CategoryIdList.DataSource = GetCategory(GetGroup.Text.Trim());
            CategoryIdList.DataTextField = "CategoryName";
            CategoryIdList.DataValueField = "CategoryID";
            CategoryIdList.DataBind();
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
            //int wid = Convert.ToInt32(Request.QueryString["wid"].ToString().Trim());
            int groupId = 0;
            if (GetGroup.Text!="")
            {
                groupId=Convert.ToInt32(GetGroup.Text);
            }
            int cateId = 0;
            if (CategoryIdList.Text!="")
            {
                cateId = Convert.ToInt32(CategoryIdList.Text);
            }
            string userid = "1";
            DataTable getTable = GetAllByValue(groupId,cateId,userid);
            DataTable pageDt = RepeirTable(getTable);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = pageDt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 8;
            pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
            GetDataView.DataSource = pds;
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
            GetDataView.DataBind();
        }
        public DataTable GetScorce(int wid)
        {
            try
            {
                string sql = "select * from Scorce where WID=" + wid;
                DataTable dt = DbHelperSQL.Query(sql).Tables[0];
                DataTable wdt = DbHelperSQL.Query("select * from Works where WID=" + wid).Tables[0];
                int groupid = Convert.ToInt32(wdt.Rows[0]["GroupID"]);
                DataTable gdt = GetCategory(groupid.ToString());
                string groupName = "";
                string CateName = "";
                for (int i = 0; i < gdt.Rows.Count; i++)
                {
                    if (groupid.ToString().Equals(gdt.Rows[i]["GroupID"].ToString().Trim()))
                    {
                        if (wdt.Rows[0]["CategoryID"].ToString().Trim().Equals(gdt.Rows[i]["CategoryID"].ToString().Trim()))
                        {
                            groupName = gdt.Rows[i]["GroupName"].ToString().Trim();
                            CateName = gdt.Rows[i]["CategoryName"].ToString().Trim();
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataTable GetAllByValue(int GroupID,int CategoryID,string SetExpertID) {
            //string sql = "select * from Scorce where SetExpertID='" + SetExpertID + "'";
            //DataTable sdt = DbHelperSQL.Query(sql).Tables[0];
            //Dictionary<int, string> list = new Dictionary<int, string>();
            ////string[] str = new string[sdt.Rows.Count];
            //for (int i = 0; i < sdt.Rows.Count; i++)
            //{
            //    list.Add(Convert.ToInt32(sdt.Rows[i]["WID"]), sdt.Rows[i]["ScorceNub"].ToString().Trim());
            //}
            //StringBuilder str=new StringBuilder();
            //int[] array = new int[list.Keys.Count];
            //list.Keys.CopyTo(array,0);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (i < array.Length - 1)
            //    {
            //        str.Append(array[i] + ",");
            //    }
            //    else
            //    {
            //        str.Append(array[i]);
            //    }
            //}
            //string sqlstr = "select * from Works where WID in ("+str.ToString()+")";
            //if (GroupID!=0)
            //{
            //    sqlstr+=" and GroupID="+GroupID;
            //}
            //if (CategoryID!=0)
            //{
            //    sqlstr += " and CategoryID=" + CategoryID;
            //}
            //DataTable wdt = DbHelperSQL.Query(sqlstr).Tables[0];
            //wdt.Columns.Add("SorceNub",typeof(string));
            //for (int j = 0; j < wdt.Rows.Count; j++)
            //{
            //    if (list.ContainsKey(Convert.ToInt32(wdt.Rows[j]["WID"])))
            //    {
            //        wdt.Rows[j]["SorceNub"] = list[Convert.ToInt32(wdt.Rows[j]["WID"])].ToString();
            //    }
            //}
            string sql = "select * from Works w,Scorce s where w.WID=s.WID and s.SetExpertID in (select SetExpertID from Scorce where SetExpertID='" + SetExpertID + "')";
            if (GroupID != 0)
            {
                sql += " and GroupID=" + GroupID;
            }
            if (CategoryID != 0)
            {
                sql += " and CategoryID=" + CategoryID;
            }
            //sql += " w.WReview='1'";//已审核条件判断
            DataTable wdt = DbHelperSQL.Query(sql).Tables[0];
            return wdt;
        }

        protected void CategoryIdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            contrlRepeater();
        }
        public DataTable RepeirTable(DataTable dt) {
            DataTable groupdt = BingGetType("");
            DataTable Categorydt = GetCategory("");
            dt.Columns.Add("GroupName", typeof(string));
            dt.Columns.Add("CategoryName", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < Categorydt.Rows.Count; j++)
                {
                    if (dt.Rows[i]["CategoryID"].ToString().Trim().Equals(Categorydt.Rows[j]["CategoryID"].ToString().Trim()))
                    {
                        dt.Rows[i]["GroupName"] = Categorydt.Rows[j]["GroupName"].ToString();
                        dt.Rows[i]["CategoryName"] = Categorydt.Rows[j]["CategoryName"].ToString();
                        break;
                    }
                }
                if ("0".Equals(dt.Rows[i]["WReview"].ToString().Trim()))
                {
                    dt.Rows[i]["WReview"] = "未审核";
                }
                else
                {
                    dt.Rows[i]["WReview"] = "已审核";
                }
            }
            return dt;
        }
    }
}