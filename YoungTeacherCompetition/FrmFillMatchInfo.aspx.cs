﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ComputerBS
{
    public partial class FrmFillMatchInfo : System.Web.UI.Page
    {
        public static string myDistrictName;
        public static string mySchoolName;
        public static string mySchoolID;
        public static string myIndexID;
        private static string UserNo;
        private static EnrolInfo updateEnrolInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserNo = UrlHtmlUtil.GetUserNo();
                updateEnrolInfo = new EnrolInfo();
                BindDataToSchoolList(UserNo);//绑定学校下拉列表
                BindDataByReview();                
                BindDataToSubjectList();//绑定学科下拉列表  
            }
            
             
        }

        private void BindDataByReview()
        {
            DataTable dt = UrlHtmlUtil.GetTEnrolInfo(UserNo);//传申报人ID进去，返回对应的填写参赛信息
            GridViewData.DataSource = dt;
            GridViewData.DataBind();

            
            if (dt.Rows.Count>0)
            {   
                
                if (Convert.ToInt16(dt.Rows[0]["IsFirst"])==1)
                {
                    this.showMyInfo.Style.Add("display", "block");  
                }
                
            }
            
        }
        private void initText()
        {
            Tbx_Name.Text = "";
            Tbx_Birthday.Text = "";
            Tbx_Title.Text = "";
            Tbx_WorkYear.Text = "";
            Tbx_Tel.Text = "";
        }
        protected void Btn_MyInfoOK_Click(object sender, EventArgs e)
        {
            //这里修改状态
            if (UrlHtmlUtil.UpdateIsFirst(false,UserNo))
            {
                this.showMyInfo.Style.Add("display", "none");               
            }
             
        }

        private void BindDataToSubjectList()
        {
            string TextField = "SubjectName";
            string ValueField = "SubjectID";
            UrlHtmlUtil.BindDataToList(DropList_Subject, UrlHtmlUtil.GetSubjectInfo(""), TextField, ValueField);

        }
        private void BindDataToSchoolList(string myUserNo)
        {
            string TextField = "SchoolName";
            string ValueField = "SchoolID";
            DataTable dt = UrlHtmlUtil.GetSchoolInfo2(myUserNo,3);//参数：用户主键ID，2表示高中组
            myDistrictName = dt.Rows[0]["DistrictName"].ToString().Trim();
            mySchoolName = dt.Rows[0]["SchoolName"].ToString().Trim();
            UrlHtmlUtil.BindDataToList(DropList_School, dt, TextField, ValueField);
 
        }

        private void UpdateBtnShow(bool UpdateShow)
        {
            if (UpdateShow)
	        {
                this.Btn_Submit.Style.Add("display", "none");
                this.Btn_Update.Style.Add("display", "block");
            }
            else
            {
                this.Btn_Submit.Style.Add("display", "block");
                this.Btn_Update.Style.Add("display", "none");
            }
        }
        

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            EnrolInfo myEnrolInfo = new EnrolInfo();
            myEnrolInfo.SchoolID = Convert.ToInt32(DropList_School.Text);//学校ID
            myEnrolInfo.EnrolName = Tbx_Name.Text.Trim();//姓名
            myEnrolInfo.EnrolSex = DropList_Sex.SelectedItem.Text;//性别
            myEnrolInfo.EnrolBirthday = Tbx_Birthday.Text.Trim();//出生年月
            myEnrolInfo.EnrolTeacherTitle = Tbx_Title.Text.Trim();//职称
            myEnrolInfo.EnrolSubject = Convert.ToInt32(DropList_Subject.Text);//学科
            myEnrolInfo.EnrolWorkYear = Tbx_WorkYear.Text.Trim();//教龄
            myEnrolInfo.EnrolTel = Tbx_Tel.Text.Trim();//联系电话
            if (UrlHtmlUtil.AddEnrolInfo(myEnrolInfo))
            {
                initText();
                Response.Write("<script>alert('添加成功!')</script>");
                BindDataByReview();
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            EnrolInfo myEnrolInfo = new EnrolInfo();
            myEnrolInfo.EnrollID = Convert.ToInt32(myIndexID);
            myEnrolInfo.SchoolID = Convert.ToInt32(DropList_School.Text);//学校ID
            myEnrolInfo.EnrolName = Tbx_Name.Text.Trim();//姓名
            myEnrolInfo.EnrolSex = DropList_Sex.SelectedItem.Text;//性别
            myEnrolInfo.EnrolBirthday = Tbx_Birthday.Text.Trim();//出生年月
            myEnrolInfo.EnrolTeacherTitle = Tbx_Title.Text.Trim();//职称
            myEnrolInfo.EnrolSubject = Convert.ToInt32(DropList_Subject.Text);//学科
            myEnrolInfo.EnrolWorkYear = Tbx_WorkYear.Text.Trim();//教龄
            myEnrolInfo.EnrolTel = Tbx_Tel.Text.Trim();//联系电话
            if (UrlHtmlUtil.UpdateEnrolInfo(myEnrolInfo))
            {
                initText();
                UpdateBtnShow(false);
                Response.Write("<script>alert('修改成功!')</script>");
                BindDataByReview();
            }
        }
        protected void GridViewData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridViewData.PageIndex = e.NewPageIndex;
                BindDataByReview();
            }
            catch (Exception)
            {


            }
        }


        protected void deleteEnroll(object sender, EventArgs e)
        {
            LinkButton txt = (LinkButton)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            string EnrollID = GridViewData.Rows[row.DataItemIndex].Cells[0].Text.Trim();
            if (UrlHtmlUtil.DeleteEnrolInfo(EnrollID))
            {
                Response.Write("<script>alert('删除成功!')</script>");
                BindDataByReview();  
            }
        }
        protected void updateEnroll(object sender, EventArgs e)
        {
            LinkButton txt = (LinkButton)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            string EnrollID = GridViewData.Rows[row.DataItemIndex].Cells[0].Text;
            string EnrolName= GridViewData.Rows[row.DataItemIndex].Cells[1].Text;
            string EnrolSex= GridViewData.Rows[row.DataItemIndex].Cells[2].Text;
            string EnrolBirthday= GridViewData.Rows[row.DataItemIndex].Cells[3].Text;
            string EnrolWorkYear= GridViewData.Rows[row.DataItemIndex].Cells[4].Text;
            string EnrolTel= GridViewData.Rows[row.DataItemIndex].Cells[5].Text;
            string EnrolTeacherTitle= GridViewData.Rows[row.DataItemIndex].Cells[6].Text;
            string SubjectName= GridViewData.Rows[row.DataItemIndex].Cells[7].Text.Trim();
            string SchoolName = GridViewData.Rows[row.DataItemIndex].Cells[8].Text.Trim();
            myIndexID = EnrollID;
            updateEnrolInfo.EnrollID = Convert.ToInt32(EnrollID);
            updateEnrolInfo.EnrolName = EnrolName;
            updateEnrolInfo.EnrolSex = EnrolSex;
            updateEnrolInfo.EnrolBirthday = EnrolBirthday;
            updateEnrolInfo.EnrolWorkYear = EnrolWorkYear;
            updateEnrolInfo.EnrolTel = EnrolTel;
            updateEnrolInfo.EnrolTeacherTitle = EnrolTeacherTitle;
            updateEnrolInfo.SubjectName = SubjectName;
            updateEnrolInfo.SchoolName = SchoolName;
            UpdateBtnShow(true);
            AddDatetoShow();

        }
        private void AddDatetoShow()
        {
            DropList_School.Items.FindByText(updateEnrolInfo.SchoolName).Selected = true; 
            Tbx_Name.Text = updateEnrolInfo.EnrolName;//姓名
            DropList_Sex.SelectedItem.Text = updateEnrolInfo.EnrolSex;//性别
            Tbx_Birthday.Text = updateEnrolInfo.EnrolBirthday;//出生年月
            Tbx_Title.Text = updateEnrolInfo.EnrolTeacherTitle;//职称
            DropList_Subject.Items.FindByText(updateEnrolInfo.SubjectName.Trim()).Selected = true;
            Tbx_WorkYear.Text = updateEnrolInfo.EnrolWorkYear;//教龄
            Tbx_Tel.Text = updateEnrolInfo.EnrolTel;//联系电话
        }

        protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }

        protected void btUpFile_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (FileUp1.HasFile)
            //    {
            //        string fileName = FileUp1.FileName;
            //        string filePath = Path.GetFullPath(FileUp1.PostedFile.FileName);

            //        if (filePath != "")
            //        {
            //            string savePath = Server.MapPath("~/Fileupload/");//指定上传文件在服务器上的保存路径
            //            //检查服务器上是否存在这个物理路径，如果不存在则创建
            //            if (!System.IO.Directory.Exists(savePath))
            //            {
            //                System.IO.Directory.CreateDirectory(savePath);
            //            }
            //            savePath = savePath + FileUp1.FileName;
            //            string WfileName = savePath;//路径名                       
            //            FileUp1.SaveAs(savePath);
            //            if (System.IO.File.Exists(savePath))
            //            {

            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show", "<script>alert('上传成功！')</script>", false);
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show", "<script>alert('上传失败！')</script>", false);
            //            }
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "show", "<script>alert('请先选择导入文件后，再执行导入！谢谢！')</script>", false);

            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

    }
}