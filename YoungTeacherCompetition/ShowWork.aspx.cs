using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerBS
{
    public partial class ShowWork : System.Web.UI.Page
    {
        private static string UserNo;
        private static int EnrollID;
        public static ClsWorksInfo[] ClsWorksInfoArr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserNo = UrlHtmlUtil.GetUserNo();
                EnrollID = Convert.ToInt32(Request.QueryString["EnrollID"]);
                
                
                if (UrlHtmlUtil.GetUserRole().Equals("管理员"))
	            {
                    ClsWorksInfoArr[0].Index = FindIndex(EnrollID); 
                    DataTable dt = UrlHtmlUtil.GetWorksInfo(EnrollID);
                    JumpInterface(GetDataFullTable(dt));
                    adminRole(true, dt);
	            }
                else
	            {
                    ClsWorksInfoArr[0].Index = FindIndex(EnrollID, Convert.ToInt32(UserNo));                    
                    GetWorksInfo(EnrollID, UserNo);
                    
	            }
                ShowPageUpAndNext();
                
            }
        }

        private void adminRole(bool isadmin,DataTable mydt)
        {
            Score.Value = "";
            Comment.Value = "";

            this.pingshen.Style.Add("display", "none");
            this.pingshen1.Style.Add("display", "none");
            this.pingshen2.Style.Add("display", "none");
            this.pingshen3.Style.Add("display", "none");
            string UserID, myScore, Time, myComment;
            if (isadmin)
            {
                AuditStatus.Visible = false;
                for (int i = 0; i < mydt.Rows.Count; i++)
                {
                    
                    UserID = mydt.Rows[i]["UserID"].ToString().Trim();
                    myScore = mydt.Rows[i]["EnrolScore"].ToString().Trim();
                    Time = mydt.Rows[i]["EnrolTime"].ToString().Trim();
                    myComment = mydt.Rows[i]["EnrolComment"].ToString().Trim();
                         
                    if (i==0)
                    {
                        this.pingshen1.Style.Add("display", "block");
                        Lab_UserID1.Text = UserID;
                        Lab_EnrolScore1.Text = myScore;
                        EnrolTime1.Text = Time;
                        Lab_EnrolComment1.Text = myComment;
                    }
                    else if (i==1)
                    {
                        this.pingshen2.Style.Add("display", "block");
                        Lab_UserID2.Text = UserID;
                        Lab_EnrolScore2.Text = myScore;
                        EnrolTime2.Text = Time;
                        Lab_EnrolComment2.Text = myComment;    
                    }
                    else if (i==2)
                    {
                        this.pingshen3.Style.Add("display", "block");
                        Lab_UserID3.Text = UserID;
                        Lab_EnrolScore3.Text = myScore;
                        EnrolTime3.Text = Time;
                        Lab_EnrolComment3.Text = myComment; 
                    }
                    else
                    {
                        break;
                    }
                }
                
                          
            }
            else
            {
                AuditStatus.Visible = true;
                UserID = mydt.Rows[0]["UserID"].ToString().Trim();
                myScore = mydt.Rows[0]["EnrolScore"].ToString().Trim();
                Time = mydt.Rows[0]["EnrolTime"].ToString().Trim();
                myComment = mydt.Rows[0]["EnrolComment"].ToString().Trim();
                Lab_UserID1.Text = UserID;
                Lab_EnrolScore1.Text = myScore;
                EnrolTime1.Text = Time;
                Lab_EnrolComment1.Text = myComment;
                if (string.IsNullOrEmpty(Time))
                {
                    this.pingshen.Style.Add("display", "block");
                }
                else
                {
                    this.pingshen1.Style.Add("display", "block");
                }

                

            }

        }

        //根据ID 找到当前数组位置
        private int FindIndex(int id, int myUserNo)
        {
            int RetIndex = 0;
            for (int i = 0; i < ClsWorksInfoArr.Length; i++)
            {
                if (id == ClsWorksInfoArr[i].EnrollID)
                {
                    if (myUserNo == ClsWorksInfoArr[i].UserNo)
                    {
                        RetIndex = i;
                        break;  
                    }
                    
                }
            }
            return RetIndex;
        }
        private int FindIndex(int id)
        {
            int RetIndex = 0;
            for (int i = 0; i < ClsWorksInfoArr.Length; i++)
            {
                if (id == ClsWorksInfoArr[i].EnrollID)
                {
                   RetIndex = i;
                   break;                  

                }
            }
            return RetIndex;
        }
        private void ShowPageUpAndNext()
        {
            this.Btn_up.Visible = true;
            this.Btn_next.Visible = true;
            //只有1条记录，上下翻页隐藏
            if (ClsWorksInfoArr[0].Count == 1)
            {
                this.Btn_up.Visible = false;
                this.Btn_next.Visible = false;
            }
            else
            {
                //第一个  上一页隐藏
                if (ClsWorksInfoArr[0].Index == 0)
                {
                    this.Btn_up.Visible = false;
                }//最后一个  下一页隐藏
                else if (ClsWorksInfoArr[0].Index == (ClsWorksInfoArr[0].Count - 1))
                {
                    this.Btn_next.Visible = false;
                }
            }

        }

        public void GetWorksInfo(Int32 myEnrollID,string myUserNo)
        {
            DataTable dt = UrlHtmlUtil.GetWorksInfo(myEnrollID, myUserNo);
            JumpInterface(GetDataFullTable(dt));
            adminRole(false, dt);
        }
        //上一页事件
        protected void Btn_up_Click(object sender, EventArgs e)
        {
            //已经做了限制，这里再限制
            if (ClsWorksInfoArr[0].Index > 0)
            {
                ClsWorksInfoArr[0].Index -= 1;//选择上一个
                FullData(ClsWorksInfoArr, ClsWorksInfoArr[0].Index);
                ShowPageUpAndNext();//按钮显示控制 
            }

        }
        private void FullData(ClsWorksInfo[] data, int i)
        {
            Int32 myEnrolid = data[i].EnrollID;
            EnrollID = myEnrolid;
            if (UrlHtmlUtil.GetUserRole().Equals("管理员"))
            {
                DataTable dt = UrlHtmlUtil.GetWorksInfo(myEnrolid);
                JumpInterface(GetDataFullTable(dt));
                adminRole(true, dt);
            }
            else
            {
                GetWorksInfo(myEnrolid, UserNo);
            }


            //EntriesName.Text = data[i].EntriesName.Trim();     //作品名称
            //EnrolName.Text = data[i].EnrolName.Trim();         //作者
            //DistrictName.Text = data[i].DistrictName.Trim();   //学区
            //SchoolName.Text = data[i].SchoolName.Trim();       //学校
            //SchoolGroupName.Text = data[i].SchoolGroupName.Trim();//学段
            //EntriesTime.Text = data[i].EntriesTime.Trim();     //作品上传时间
            //filePath = data[i].EntriesURL.Trim();              //作品链接            
            ////Lab_EnrolScore1.Text = data[i].EnrolScore.Trim();       //作品得分
            //// Lab_EnrolComment.Text = data[i].EnrolComment.Trim();   //评语
            //AuditStatus.Text = "状态：" + data[i].AuditStatus.Trim();     //审核状态
            ////EnrolTime1.Text = data[i].EnrolTime.Trim();         //审核时间 


        }

        public string GetDataFullTable(DataTable dt)
        {
            int iCount = dt.Rows.Count - 1;
            string filePath = "";
            if (dt.Rows.Count > 0)
            {
                EntriesName.Text = dt.Rows[iCount]["EntriesName"].ToString().Trim();    //作品名称
                EnrolName.Text = dt.Rows[iCount]["EnrolName"].ToString().Trim();         //作者
                DistrictName.Text = dt.Rows[iCount]["DistrictName"].ToString().Trim();   //学区
                SchoolName.Text = dt.Rows[iCount]["SchoolName"].ToString().Trim();       //学校
                SchoolGroupName.Text = dt.Rows[iCount]["SchoolGroupName"].ToString().Trim();//学段
                SubjectName.Text = dt.Rows[iCount]["SubjectName"].ToString().Trim();     //学科
                EntriesTime.Text = dt.Rows[iCount]["EntriesTime"].ToString().Trim();     //作品上传时间
                filePath = dt.Rows[iCount]["EntriesURL"].ToString().Trim().Trim();              //作品链接            
                //Lab_EnrolScore1.Text = dt.Rows[iCount]["EnrolScore"].ToString().Trim();      //作品得分
                //Lab_EnrolComment.Text = dt.Rows[iCount]["EnrolComment"].ToString().Trim();   //评语
                AuditStatus.Text ="状态：" + dt.Rows[iCount]["AuditStatus"].ToString().Trim();     //审核状态
                //EnrolTime1.Text = dt.Rows[iCount]["EnrolTime"].ToString().Trim();        //审核时间 
                
            }
            
            return filePath;
        }

        public void JumpInterface(string file)
        {
            if (file.EndsWith(".flv") || file.EndsWith(".mp4") || file.EndsWith(".swf"))
            {
                string iframe = "<iframe id='MyIframe' frameborder=0  marginheight=0 marginwidth=0 width='722' height='482' src='ShowVideo.aspx?FilePath=" + file + "' ></iframe>";
                ReplaceByIframe.Text = iframe;
            }
            else
            {

            }

        }

        protected void Btn_next_Click(object sender, EventArgs e)
        {
            //已经做了限制，这里再限制
            if (ClsWorksInfoArr[0].Index < (ClsWorksInfoArr[0].Count - 1))
            {
                ClsWorksInfoArr[0].Index += 1;//选择下一个
                FullData(ClsWorksInfoArr, ClsWorksInfoArr[0].Index);
                ShowPageUpAndNext();//按钮显示控制 
            }
        }



        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string CommentText = Comment.Value;
            string ScoreText = Score.Value;
            if (UrlHtmlUtil.AddEntriesInfoScore(EnrollID, UserNo, ScoreText, CommentText))
            {
                Response.Write("<script language=javascript>alert('评分成功！');</script>");
                GetWorksInfo(EnrollID, UserNo);
            }
        }


        
    }
}