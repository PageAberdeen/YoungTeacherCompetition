using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerBS
{
    //用户表
    public class UserInfo
    {
        private int _UserNo, _SchoolInfoID, _ReviewID, _SchoolGroupID, _DistrictID;
        private string _UserAccountID, _UserID, _UserName, _UserRole;

        public int UserNo
        {
            get { return _UserNo; }
            set { _UserNo = value; }
        }
        public int SchoolGroupID
        {
            get { return _SchoolGroupID; }
            set { _SchoolGroupID = value; }
        }
        public int DistrictID
        {
            get { return _DistrictID; }
            set { _DistrictID = value; }
        }
        public int SchoolInfoID
        {
            get { return _SchoolInfoID; }
            set { _SchoolInfoID = value; }
        }
        public int ReviewID
        {
            get { return _ReviewID; }
            set { _ReviewID = value; }
        }
        public string UserAccountID
        {
            get { return _UserAccountID; }
            set { _UserAccountID = value; }
        }

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string UserRole
        {
            get { return _UserRole; }
            set { _UserRole = value; }
        } 
        
    }

    //参赛信息表
    public class EnrolInfo
    {
        private int _EnrollID, _EnrolSubject, _SchoolID;
        private string _EnrolName, _EnrolSex, _EnrolBirthday, _EnrolWorkYear;
        private string _EnrolTel, _EnrolTeacherTitle, _EntriesName, _EntriesURL;
        private string _SubjectName, _SchoolName;
        public int EnrollID
        {
            get { return _EnrollID; }
            set { _EnrollID = value; }
        }
        public int EnrolSubject
        {
            get { return _EnrolSubject; }
            set { _EnrolSubject = value; }
        }
        public int SchoolID
        {
            get { return _SchoolID; }
            set { _SchoolID = value; }
        }
        public string SubjectName
        {
            get { return _SubjectName; }
            set { _SubjectName = value; }
        }

        public string SchoolName
        {
            get { return _SchoolName; }
            set { _SchoolName = value; }
        }

        public string EnrolName
        {
            get { return _EnrolName; }
            set { _EnrolName = value; }
        }

        public string EnrolSex
        {
            get { return _EnrolSex; }
            set { _EnrolSex = value; }
        }
        public string EnrolBirthday
        {
            get { return _EnrolBirthday; }
            set { _EnrolBirthday = value; }
        }
        public string EnrolWorkYear
        {
            get { return _EnrolWorkYear; }
            set { _EnrolWorkYear = value; }
        }
        public string EnrolTel
        {
            get { return _EnrolTel; }
            set { _EnrolTel = value; }
        }

        public string EnrolTeacherTitle
        {
            get { return _EnrolTeacherTitle; }
            set { _EnrolTeacherTitle = value; }
        }
        public string EntriesName
        {
            get { return _EntriesName; }
            set { _EntriesName = value; }
        }
        public string EntriesURL
        {
            get { return _EntriesURL; }
            set { _EntriesURL = value; }
        }

    }
}