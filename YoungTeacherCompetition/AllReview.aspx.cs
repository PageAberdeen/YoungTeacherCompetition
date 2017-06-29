using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class AllReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListBind();
                this.labPage.Text = "1";
                this.contrlRepeater(); 
            }
            
        }

        private void getTest()
        {
            DataSet ds = DbHelperSQL.Query("select *,(select top 1 s.ScorceNub from Scorce s where s.WID=w.WID order by s.ScorceDate desc) ScorceNub  from Works w");
            ReviewDataWorks.DataSource = ds.Tables[0].DefaultView;
            ReviewDataWorks.DataBind();
        }
        //绑定组别下拉框数据
        public void DropDownListBind()
        {

            DataSet ds = DbHelperSQL.Query("select GroupID,GroupName from CatagoryGroup group by GroupID,GroupName");
            ddlt_Area.DataTextField = "GroupName";
            ddlt_Area.DataValueField = "GroupID";
            ddlt_Area.DataSource = ds.Tables[0].DefaultView;
            ddlt_Area.DataBind();
            ddlt_Area.Items.Insert(0, new ListItem("全部组别", "0"));
        }

        protected void ddlt_T_zptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据组别和作品类别查询对应作品信息和分数
            DataSet ds = DbHelperSQL.Query(" select *,(select top 1 s.ScorceNub from Scorce s where s.WID=w.WID order by s.ScorceDate desc) ScorceNub  from Works w where GroupID= " + ddlt_Area.SelectedValue + " and CategoryID=" + ddlt_T_zptype.SelectedValue);
            if(ds != null && ds.Tables[0].Rows.Count>0)
            {
                //重新绑定明细数据
                this.labPage.Text = "1";
                this.contrlRepeater(); 
            }
        }

        //groupID是组别ID，CategoryID是作品ID
        protected DataTable getWorksInfo(string groupID, string CategoryID)
        {
            string sql = " select *,(select top 1 s.ScorceNub from Scorce s where s.WID=w.WID order by s.ScorceDate desc) ScorceNub  from Works w ";
            if (!string.IsNullOrEmpty(groupID)&&!"0".Equals(groupID))
            {
                sql += "  where GroupID= " + ddlt_Area.SelectedValue ;
                if (!string.IsNullOrEmpty(CategoryID) && !"0".Equals(CategoryID))
                {
                    sql += "  and CategoryID=" + ddlt_T_zptype.SelectedValue;
                }
            }
            DataSet workDS = DbHelperSQL.Query(sql);
            DataTable dt = workDS.Tables[0];
            return dt;
        }

        protected void ddlt_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = DbHelperSQL.Query("select CategoryID,CategoryName from CatagoryGroup where GroupID = " + ddlt_Area.SelectedValue);
            ddlt_T_zptype.DataTextField = "CategoryName";
            ddlt_T_zptype.DataValueField = "CategoryID";
            ddlt_T_zptype.DataSource = ds.Tables[0].DefaultView;
            ddlt_T_zptype.DataBind();
            labPage.Text = "1";
            this.contrlRepeater(); 
            //getWorksInfo(ddlt_Area.SelectedValue, ddlt_T_zptype.SelectedValue);
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
            string groupID = ddlt_Area.SelectedValue;
            string zptypeID= ddlt_T_zptype.SelectedValue;
            DataTable pageDt = getWorksInfo(groupID,zptypeID);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = pageDt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 6;
            pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;
            ReviewDataWorks.DataSource = pds;
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
            ReviewDataWorks.DataBind();
        }
    }
}