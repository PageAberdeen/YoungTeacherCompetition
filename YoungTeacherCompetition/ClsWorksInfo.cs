using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerBS
{
    public class ClsWorksInfo
    {
        public int EnrollID;         //主键
        public string EntriesName;   //作品名称
        public string EnrolName;     //作者
        public string DistrictName;  //学区
        public string SchoolName;    //学校
        public string SchoolGroupName;//学段
        public string EntriesTime;   //作品上传时间
        public string EntriesURL;    //作品链接
        public int  UserNo;          //评审人
        public string EnrolScore;    //作品得分
        public string EnrolComment;  //评语
        public string AuditStatus;   //审核状态
        public string EnrolTime;     //审核时间
        public int Index;            //当前选中行
        public int Count;            //数组长度
    }
}