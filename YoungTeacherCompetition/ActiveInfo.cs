using System;
using System.Collections.Generic;
using System.Web;

namespace ComputerBS
{
    public class ActiveInfo
    {
        private string _InfoID;

        public string InfoID
        {
            get { return _InfoID; }
            set { _InfoID = value; }
        }
        private string _InfoText;

        public string InfoText
        {
            get { return _InfoText; }
            set { _InfoText = value; }
        }
        private string _InfoYear;

        public string InfoYear
        {
            get { return _InfoYear; }
            set { _InfoYear = value; }
        }
        private string _InfoTime;

        public string InfoTime
        {
            get { return _InfoTime; }
            set { _InfoTime = value; }
        }
    }
}