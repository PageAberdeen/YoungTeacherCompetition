using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ComputerBS
{
    public partial class ShowBestWorks : System.Web.UI.Page
    {
        private static string UserNo;
        private static ClsFindText FindTextRecord = new ClsFindText();
        public static ClsWorksInfo[] ClsWorksInfoArr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FindTextRecord.AuditStatus = "";
                FindTextRecord.District = "0";
                FindTextRecord.School = "0";
                FindTextRecord.SchoolGroup = "0";
                FindTextRecord.Subject = "0";

                if (UrlHtmlUtil.GetUserRole().Equals("评审人"))
                {
                    UserNo = UrlHtmlUtil.GetUserNo();
                    adminRole(false);
                    BindDataToDropList_District();//学区
                    BindDataToDropList_School();//学校
                    BindDataToDropList_SchoolGroup();//学段
                    BindDataToDropList_Subject();//学科
                    BindDataByReview(UserNo);
                }
                else if (UrlHtmlUtil.GetUserRole().Equals("管理员"))
                {
                    adminRole(true);
                    UserNo = UrlHtmlUtil.GetUserNo();
                    BindDataToDropList_District();//学区
                    BindDataToDropList_School();//学校
                    BindDataToDropList_SchoolGroup();//学段
                    BindDataToDropList_Subject();//学科
                    DataTable dt = UrlHtmlUtil.GetTEnrolInfoByReview(UserNo, true);//传评审人ID进去，返回对应评审信息
                    GridViewData.DataSource = dt;
                    GridViewData.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        FullDataToclsClsWorksArr(dt);
                    } 
                }
                else
                {
                    UrlHtmlUtil.MsgBox("您不具备评审人权限！");
                }
            
                
            }
            
        }
        private void adminRole(bool isadmin)
        {
            if (isadmin)
            {
                this.inputtext.Style.Add("display", "inline-block");
                liSubject.Style.Add("display", "block");
                //this.outdata.Style.Add("display", "block");
                this.names.Style.Add("display", "inline-block");
                But_outdata.Visible = true;
            }
            else
            {
                this.inputtext.Style.Add("display", "none");
                liSubject.Style.Add("display", "none");
                //this.outdata.Style.Add("display", "none");
                this.names.Style.Add("display", "none");
                But_outdata.Visible = false;
            }

        }
        private void BindDataByReview(string myUserNo)
        {
           DataTable dt = UrlHtmlUtil.GetTEnrolInfoByReview(myUserNo,false);//传评审人ID进去，返回对应评审信息
           GridViewData.DataSource = dt;
           GridViewData.DataBind();
           if (dt.Rows.Count>0)
           {
               FullDataToclsClsWorksArr(dt);
           } 

        }

        private void FullDataToclsClsWorksArr(DataTable mydt)
        {
            int iEnd = mydt.Rows.Count;
            ClsWorksInfoArr = new ClsWorksInfo[iEnd];
            for (int i = 0; i < iEnd; i++)
            {
                ClsWorksInfo ClsWorksInfoRecord = new ClsWorksInfo();
                ClsWorksInfoRecord.EnrollID = Convert.ToInt32(mydt.Rows[i]["EnrollID"]); //主键 1      
                ClsWorksInfoRecord.EntriesName = mydt.Rows[i]["EntriesName"].ToString().Trim();   //作品名称
                ClsWorksInfoRecord.EnrolName = mydt.Rows[i]["EnrolName"].ToString().Trim();     //作者
                ClsWorksInfoRecord.DistrictName = mydt.Rows[i]["DistrictName"].ToString().Trim();  //学区
                ClsWorksInfoRecord.SchoolName = mydt.Rows[i]["SchoolName"].ToString().Trim();    //学校
                ClsWorksInfoRecord.SchoolGroupName = mydt.Rows[i]["SchoolGroupName"].ToString().Trim();//学段
                ClsWorksInfoRecord.EntriesTime = mydt.Rows[i]["EntriesTime"].ToString().Trim();   //作品上传时间
                ClsWorksInfoRecord.EntriesURL = mydt.Rows[i]["EntriesURL"].ToString().Trim();    //作品链接
                ClsWorksInfoRecord.UserNo = 0;
                if (!string.IsNullOrEmpty(mydt.Rows[i]["UserID"].ToString().Trim()))
	            {
                    ClsWorksInfoRecord.UserNo = Convert.ToInt32(mydt.Rows[i]["UserID"]);          //评审人 主键 2
	            }
                    
                
                ClsWorksInfoRecord.EnrolScore = mydt.Rows[i]["EnrolScore"].ToString().Trim();    //作品得分
                ClsWorksInfoRecord.EnrolComment = mydt.Rows[i]["EnrolComment"].ToString().Trim();  //评语
                ClsWorksInfoRecord.AuditStatus = mydt.Rows[i]["AuditStatus"].ToString().Trim();   //审核状态
                ClsWorksInfoRecord.EnrolTime = mydt.Rows[i]["EnrolTime"].ToString().Trim();     //审核时间
                ClsWorksInfoRecord.Index = 0;            //当前选中行
                ClsWorksInfoRecord.Count = iEnd;            //数组长度

                ClsWorksInfoArr[i] = ClsWorksInfoRecord;
            }

            ShowWork.ClsWorksInfoArr = ClsWorksInfoArr;
        }

        private void BindDataToDropList_District()
        {
            string TextField = "DistrictName";
            string ValueField = "DistrictID";
            UrlHtmlUtil.BindDataToList2(DropList_District, UrlHtmlUtil.GetDistrictInfo(""), TextField, ValueField);

        }
        private void BindDataToDropList_School()
        {
            string TextField = "SchoolName";
            string ValueField = "SchoolID";
            UrlHtmlUtil.BindDataToList2(DropList_School, UrlHtmlUtil.GetSchoolInfo("","",""), TextField, ValueField);

        }
        private void BindDataToDropList_SchoolGroup()
        {
            string TextField = "SchoolGroupName";
            string ValueField = "SchoolGroupID";
            UrlHtmlUtil.BindDataToList2(DropList_SchoolGroup, UrlHtmlUtil.GetSchoolGroup(""), TextField, ValueField);

        }
        private void BindDataToDropList_Subject()
        {
            string TextField = "SubjectName";
            string ValueField = "SubjectID";
            UrlHtmlUtil.BindDataToList2(DropList_Subject, UrlHtmlUtil.GetSubjectInfo(""), TextField, ValueField);

        }

        protected void GridViewData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewData.PageIndex = e.NewPageIndex;
                BindDataByReview(UserNo);
            }
            catch (Exception)
            {


            }
        }

        protected void GridViewData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string stock = e.Row.Cells[9].Text;
                if ("未审核".Equals(stock))
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                }
                
            }
        }

        protected void But_outdata_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (UrlHtmlUtil.GetUserRole().Equals("管理员"))
            {
                //参数：传送筛选条件查询全部记录
                dt = UrlHtmlUtil.PrintEnrollInfo(FindTextRecord);
                EportAllDataToExcel(dt);
            }
            else
            {
                UrlHtmlUtil.ShowMess("您不具备该权限！");
            }
            
        }

        private static void EportAllDataToExcel(DataTable dt)
        {
            System.Web.UI.WebControls.DataGrid dgExport = null;
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            System.IO.StringWriter strWrite = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;
            if (dt.Rows.Count > 0)
            {
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "utf-8";
                curContext.Response.AddHeader("Content-Disposition", "attachment;filename=1.xls");
                strWrite = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWrite);

                dgExport = new System.Web.UI.WebControls.DataGrid();
                dgExport.DataSource = dt.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();

                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWrite);
                curContext.Response.Flush();
                curContext.Response.End();
            }
        }



        protected void DropListSelectedIndexChanged(object sender, EventArgs e)
        {
            DropListFillData((DropDownList)sender);
        }

        private bool DropListFillData(DropDownList dp)
        {
            string sText = dp.Text;
            string sName = dp.ID.ToString().Trim();
            if ("DropList_District".Equals(sName))//学区
            {
                FindTextRecord.District = sText;
            }
            else if ("DropList_School".Equals(sName))//学校
	        {
                FindTextRecord.School = sText;
	        }
            else if ("DropList_SchoolGroup".Equals(sName))//学段
	        {
                FindTextRecord.SchoolGroup = sText;
	        }
            else if ("DropList_Subject".Equals(sName))//学科
	        {
                FindTextRecord.Subject = sText;
	        }
            else if ("DropList_AuditStatus".Equals(sName))//评审状态
	        {
                if (sText.Equals("全部"))
                {
                    sText = "";  
                }
                FindTextRecord.AuditStatus = sText;
	        }
            else
	        {
                UrlHtmlUtil.ShowMess("请添加该控件的事件绑定！");
                return false;
	        }
            if (UrlHtmlUtil.GetUserRole().Equals("评审人"))
            {
                DataTable dt = UrlHtmlUtil.GetTEnrolInfoByReview(UserNo, false,FindTextRecord);//传评审人ID进去，返回对应评审信息
                GridViewData.DataSource = dt;
                GridViewData.DataBind();
                if (dt.Rows.Count > 0)
                {
                    FullDataToclsClsWorksArr(dt);
                } 
            }
            else if (UrlHtmlUtil.GetUserRole().Equals("管理员"))
            {
                DataTable dt = UrlHtmlUtil.GetTEnrolInfoByReview(UserNo, true, FindTextRecord);//传评审人ID进去，返回对应评审信息
                GridViewData.DataSource = dt;
                GridViewData.DataBind();
                if (dt.Rows.Count > 0)
                {
                    FullDataToclsClsWorksArr(dt);
                } 
            }
            else
            {
                UrlHtmlUtil.ShowMess("您不具备该权限！");
            }

            return true;
        }

        protected void Btn_Select_Click(object sender, EventArgs e)
        {
            string sValue = inputtext.Value.ToString().Trim();
            if (string.IsNullOrEmpty(sValue))
            {
                UrlHtmlUtil.ShowMess("请先输入搜索关键字！");
            }
            else
            {
               DataTable dt = UrlHtmlUtil.selectEnrolInfoByKeyword(sValue);
               GridViewData.DataSource = dt;
               GridViewData.DataBind();
               if (dt.Rows.Count > 0)
               {
                   FullDataToclsClsWorksArr(dt);
               }
            }
        }



    }
}