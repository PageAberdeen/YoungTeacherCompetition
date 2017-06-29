using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace ComputerBS
{
    //请求接口获取数据
    public class UrlHtmlUtil
    {
        #region  string getuserid(string url) 根据url请求获取xml数据，获取到的数据为userid
        public static string getuserid(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            XmlNameTable xnt = doc.NameTable;
            XmlNamespaceManager nsp = new XmlNamespaceManager(doc.NameTable);
            //返回的XML中使用到了sml前缀，因此需要添加命名空间管理
            nsp.AddNamespace("cas", "http://www.whty.aam.com");
            XmlNodeList a = root.SelectNodes("child::cas:authenticationSuccess/cas:user", nsp);
            //cas:user节点为用户ID，将用户ID保存到session中
            string userid = "";
            if (a.Count>0)
            {
                userid=a[0].InnerText;
            }
            return userid;
        }
        #endregion

        //根据url请求获取用户信息的json串，并解析json，返回JObject类型的
        public static JObject getHtmlJsonByUrl(String urlTemp)
        {

            HttpWebRequest request = WebRequest.Create(urlTemp) as HttpWebRequest;
            HttpWebResponse  response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            //读取到用户信息
            string resultJson = reader.ReadToEnd();
            //Newtonsoft.Json.Linq.JArray ja = (Newtonsoft.Json.Linq.JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(resultJson); //用这种方法解析json会报错，所以这里不用
            JObject infoJObject = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(resultJson); //用这种方法来解析json
            return infoJObject;
         }

        public static string GetUserNo()
        {
            HttpSessionState Session = HttpContext.Current.Session; ;
            return ((UserInfo)Session["User"]).UserNo.ToString();
        }
        public static string GetUserID()
        {
            HttpSessionState Session = HttpContext.Current.Session; ;
            return ((UserInfo)Session["User"]).UserID.ToString();
        }
        public static string GetSchoolGroupID()
        {
            HttpSessionState Session = HttpContext.Current.Session; ;
            return ((UserInfo)Session["User"]).SchoolGroupID.ToString();
        }
        public static string GetUserRole()
        {
            HttpSessionState Session = HttpContext.Current.Session; ;
            return ((UserInfo)Session["User"]).UserRole.ToString().Trim();
        }

        public static void MsgBox(string strMsg)
        {
            string StrScript;
            StrScript = "<script language=javascript>alert('" + strMsg + "');window.location = 'Index.aspx';</script>";
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }
        public static void MsgBoxExit(string strMsg)
        {
            string StrScript;
            StrScript = "<script language=javascript>alert('" + strMsg + "');window.location = 'frmExit.aspx';</script>";
            System.Web.HttpContext.Current.Response.Write(StrScript);
        }

        #region JsonSerialize

        /// <summary>  
        ///   序列化json,存到Dictionary中
        /// </summary>  
        /// <param name="object">json字符串</param>  
        /// <returns></returns>  
        public static Dictionary<string,object> JsonSerialize(string json)
        {
            try
            {
                //new一个应用程序的序列化和反序列化对象
                var serializer = new JavaScriptSerializer();
                Dictionary<string, object> jsonObj = (Dictionary<string, object>)serializer.DeserializeObject(json);
                return jsonObj;
                //return serializer.Serialize(@object);  
            }
            catch
            {
                return null;
            }
        }

        #endregion  
        public static string GetUrlFromPage() {
            StringBuilder str = new StringBuilder();
            str.Append("<script>");
            str.Append("function () {var currentHost=window.location;var clientPath = 'http://lzyun.doule.net/index.php?r=portal/user/login&service=' + currentHost;window.location.href = clientPath;})");
            str.Append("</script>");
            return str.ToString();
            //function () {
            //        var currentHost=window.location;
            //        var clientPath = "http://lzyun.doule.net/index.php?r=portal/user/login&service=" + currentHost;
            //        window.location.href = clientPath;
            //    });
        }
        public static void GetUserInfo(string userId)
        {
            string sql = "select [UserNo],[UserAccountID],[UserID],[UserName],[UserRole],[SchoolInfoID],[ReviewID],[SchoolGroupID],[DistrictID]" +
                         " FROM TUserInfo where UserAccountID='" + userId + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                UserInfo info = new UserInfo();
                string UserAccountID = dt.Rows[0]["UserAccountID"].ToString().Trim();
                string UserID = dt.Rows[0]["UserID"].ToString().Trim();
                string UserName = dt.Rows[0]["UserName"].ToString().Trim();
                string UserRole = dt.Rows[0]["UserRole"].ToString().Trim();

                int SchoolInfoID = Convert.ToInt32(dt.Rows[0]["SchoolInfoID"]);
                int ReviewID = Convert.ToInt32(dt.Rows[0]["ReviewID"]);
                int UserNo = Convert.ToInt32(dt.Rows[0]["UserNo"]);
                int SchoolGroupID = Convert.ToInt32(dt.Rows[0]["SchoolGroupID"]);
                int DistrictID = Convert.ToInt32(dt.Rows[0]["DistrictID"]);

                info.UserAccountID = UserAccountID;
                info.UserID = UserID;
                info.UserName = UserName;
                info.UserRole = UserRole;
                info.SchoolInfoID = SchoolInfoID;
                info.ReviewID = ReviewID;
                info.UserNo = UserNo;
                info.SchoolGroupID = SchoolGroupID;
                info.DistrictID = DistrictID;
                HttpSessionState session = HttpContext.Current.Session; ;
                session["User"] = info;
            }
        }

        public static DataTable GetSchoolInfo2(string myUserNo,int GroupID)
        {
            StringBuilder sql=new StringBuilder();
            sql.Append("SELECT b.SchoolID,b.SchoolName,c.DistrictName ");
            sql.Append("FROM dbo.TUserInfo a,dbo.TSchoolInfo b,dbo.TDistrictInfo c ");
            if (GroupID==2)//初中组算法，关联区
	        {		        
                sql.Append(" WHERE a.DistrictID=c.DistrictID AND c.DistrictID=b.DistrictID AND a.SchoolGroupID=b.SchoolGroupID");
	            
            }else
	        {
                sql.Append(" WHERE a.SchoolInfoID=b.SchoolID AND c.DistrictID=b.DistrictID");
                
	        }
            sql.AppendFormat(" AND a.UserNo={0}",myUserNo);

            DataTable dt = DbHelperSQL.Query(sql.ToString(), null).Tables[0];
            DataRow dr = dt.NewRow();

            DataTable rdt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["SchoolID"].ToString().Trim();
                dt.Rows[i]["SchoolName"] = dt.Rows[i]["SchoolName"].ToString().Trim();
                dt.Rows[i]["DistrictName"] = dt.Rows[i]["DistrictName"].ToString().Trim();
                if (rdt.Rows.Count != 0)
                {
                    bool add = true;
                    foreach (DataRow item in rdt.Rows)
                    {
                        string test = item["SchoolID"].ToString().Trim();
                        if (item["SchoolID"].ToString().Trim().Equals(id))
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

        //参数： 学校ID ，学区ID ，学段ID
        public static DataTable GetSchoolInfo(string SchoolID, string DistrictID, string SchoolGroupID)
        {
            string sql = "select SchoolID,SchoolName from TSchoolInfo where 1=1";
            if (!String.IsNullOrEmpty(SchoolID))
            {
                sql = sql + " and SchoolID='" + SchoolID + "'";
            }
            if (!String.IsNullOrEmpty(DistrictID))
            {
                sql = sql + " and DistrictID='" + DistrictID + "'";
            }
            if (!String.IsNullOrEmpty(SchoolGroupID))
            {
                sql = sql + " and SchoolGroupID='" + SchoolGroupID + "'";
            }
            sql += " order by SchoolID";

            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
            DataRow dr = dt.NewRow();

            DataTable rdt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["SchoolID"].ToString().Trim();
                dt.Rows[i]["SchoolName"] = dt.Rows[i]["SchoolName"].ToString().Trim();
                if (rdt.Rows.Count != 0)
                {
                    bool add = true;
                    foreach (DataRow item in rdt.Rows)
                    {
                        string test = item["SchoolID"].ToString().Trim();
                        if (item["SchoolID"].ToString().Trim().Equals(id))
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

        public static DataTable GetTEnrolInfo(string ReviewID)//高中组 申报人对应的填写信息
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT EnrollID,EnrolName,EnrolSex,EnrolBirthday,EnrolWorkYear,EnrolTel,EnrolTeacherTitle,c.SubjectName,d.SchoolName,EntriesName,EntriesURL,b.IsFirst,e.DistrictName,d.SchoolID ");
            sql.Append(" FROM TEnrolInfo a,TUserInfo b,TSubject c,TSchoolInfo d,TDistrictInfo e ");
            sql.Append(" WHERE d.[SchoolID]=b.SchoolInfoID AND a.SchoolID=d.SchoolID AND a.EnrolSubject=c.SubjectID  AND e.DistrictID=d.DistrictID");
            if (!String.IsNullOrEmpty(ReviewID))
            {
                sql.AppendFormat(" AND b.UserNo={0}", Convert.ToInt32(ReviewID));
            }
            sql.Append(" ORDER BY a.EnrollID");


            DataTable dt; 
            try
            {
                dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static DataTable GetTEnrolInfo2(string ReviewID)//初中组 申报人对应的填写信息
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT EnrollID,EnrolName,EnrolSex,EnrolBirthday,EnrolWorkYear,EnrolTel,EnrolTeacherTitle,c.SubjectName,d.SchoolName,EntriesName,EntriesURL,b.IsFirst,e.DistrictName,d.SchoolID,e.DistrictID,b.SchoolGroupID ");
            sql.Append(" FROM TEnrolInfo a,TUserInfo b,TSubject c,TSchoolInfo d,TDistrictInfo e ");
            sql.Append(" WHERE b.DistrictID=d.DistrictID AND d.DistrictID=e.DistrictID AND c.SubjectID=a.EnrolSubject AND a.SchoolID=d.SchoolID AND b.SchoolGroupID=d.SchoolGroupID");
            if (!String.IsNullOrEmpty(ReviewID))
            {
                sql.AppendFormat(" AND b.UserNo={0}", Convert.ToInt32(ReviewID));
            }
            sql.Append(" ORDER BY a.EnrollID");


            DataTable dt;
            try
            {
                dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static DataTable GetTEnrolInfoByReview(string myUserNo,bool isAdmin)//评审人评审信息
        {
            StringBuilder sql = new StringBuilder();
            DataTable dt;
            try
            {
                if (isAdmin)//是管理员查询全部
                {
                    sql.Clear();
                    sql.Append("SELECT a.EnrollID,a.EntriesName,a.EnrolName,a.EnrolSex,d.DistrictName,b.SchoolName,");
                    sql.Append("e.SchoolGroupName,a.EntriesTime,c.EnrolScore,c.EnrolComment,c.UserID,a.EntriesURL,");
                    sql.Append("(CASE  c.AuditStatus WHEN 1 THEN '已审核' ELSE '未审核' END) as AuditStatus,c.EnrolTime,s.SubjectName");
                    sql.Append(" FROM TEnrolInfo a JOIN TSchoolInfo b ON a.SchoolID=b.SchoolID ");
                    sql.Append(" JOIN TDistrictInfo d ON d.DistrictID=b.DistrictID");
                    sql.Append(" JOIN TSubject s ON s.SubjectID=a.EnrolSubject");
                    sql.Append(" JOIN TSchoolGroup e ON e.SchoolGroupID=b.SchoolGroupID");
                    sql.Append(" LEFT JOIN (SELECT g.* FROM (SELECT EnrolInfoID,max(EntriesID) as EntriesID ");
                    sql.Append(" FROM dbo.TEntriesInfo  GROUP BY ");
                    sql.Append(" EnrolInfoID)as f LEFT JOIN TEntriesInfo g ON f.EntriesID=g.EntriesID) c ");
                    sql.Append("  ON c.EnrolInfoID=a.EnrollID"); 
                    sql.Append(" AND a.EntriesName IS NOT NULL;");

                    dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
                }
                else
                {
                    sql.Clear();
                    sql.Append("SELECT  a.UserNo,a.SchoolGroupID,b.ReviewMode,b.AllIDstr ");
                    sql.Append("FROM dbo.TUserInfo a,dbo.TReview b ");
                    sql.Append("WHERE a.ReviewID=b.ReviewID ");
                    if (!String.IsNullOrEmpty(myUserNo))
                    {
                        sql.AppendFormat(" AND a.UserNo={0}", Convert.ToInt32(myUserNo));
                    }
                    sql.Append(" ORDER BY a.UserNo;");

                    dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        string ReviewMode = dt.Rows[0]["ReviewMode"].ToString().Trim();//评审方式

                        //按学科评审直接关联 TReviewGroup 表 关联用户名
                        string UserID = GetUserID();  

                        //按学校和学区评审会使用到AllIDstr SchoolGroupID 
                        string AllIDstr = dt.Rows[0]["AllIDstr"].ToString().Trim();    //评审关联ID
                        string SchoolGroupID = dt.Rows[0]["SchoolGroupID"].ToString().Trim();    //按区县评审会使用
                        sql.Clear();//先清空原先的SQL语句
                        /*
                         * 这里分为两种评审方式
                         *    1、按学校 
                         *    2、按区县
                         *    3、按学科
                         */
                        sql.Append("SELECT a.EnrollID,a.EntriesName,a.EnrolName,a.EnrolSex,d.DistrictName,b.SchoolName,");
                        sql.Append("e.SchoolGroupName,a.EntriesTime,c.EnrolScore,c.EnrolComment,c.UserID,a.EntriesURL,");
                        sql.Append("(CASE  c.AuditStatus WHEN 1 THEN '已审核' ELSE '未审核' END) as AuditStatus,c.EnrolTime,s.SubjectName");
                        sql.Append(" FROM TEnrolInfo a JOIN TSchoolInfo b ON a.SchoolID=b.SchoolID ");
                        sql.Append(" JOIN TSubject s ON s.SubjectID=a.EnrolSubject");
                        sql.Append(" JOIN TDistrictInfo d ON d.DistrictID=b.DistrictID");
                        sql.Append(" JOIN TSchoolGroup e ON e.SchoolGroupID=b.SchoolGroupID");
                        sql.AppendFormat(" LEFT JOIN (SELECT * from  dbo.TEntriesInfo where UserID={0}) as c ON c.EnrolInfoID=a.EnrollID", myUserNo);
                        if ("学区".Equals(ReviewMode))
                        {
                            //学区的评审方式逻辑
                            sql.AppendFormat("  WHERE b.SchoolGroupID = {0}  AND b.DistrictID in ({1}) ", SchoolGroupID, AllIDstr);
                        }
                        else if ("学校".Equals(ReviewMode))
                        {
                            //按学校评审
                            sql.AppendFormat("  WHERE b.SchoolID in ({0}) ", AllIDstr);
                            
                        }
                        else if ("学科".Equals(ReviewMode))
                        {
                            
                        }
                        else
                        {
                            throw new Exception("不存在【" + ReviewMode + "】这种评审方式！");
                        }
                        //sql.AppendFormat(" AND c.UserID = {0} ", myUserNo);
                        sql.Append(" AND a.EntriesName IS NOT NULL;");

                        dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
                    }
                    else
                    {
                        throw new Exception("该用户不具备评审权限！");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static DataTable GetWorksInfo(Int32 myEnrollID, string myUserID)//评审人评审信息
        {
            StringBuilder sql = new StringBuilder();
            DataTable dt;
            try
            {
               sql.Append("SELECT a.EnrollID,a.EntriesName,a.EnrolName,a.EnrolSex,d.DistrictName,b.SchoolName,");
               sql.Append("e.SchoolGroupName,a.EntriesTime,c.EnrolScore,c.EnrolComment,c.UserID,a.EntriesURL,");
               sql.Append("(CASE  c.AuditStatus WHEN 1 THEN '已审核' ELSE '未审核' END) as AuditStatus,c.EnrolTime,s.SubjectName");
               sql.Append(" FROM TEnrolInfo a JOIN TSchoolInfo b ON a.SchoolID=b.SchoolID ");
               sql.Append(" JOIN TSubject s ON s.SubjectID=a.EnrolSubject");
               sql.Append(" JOIN TDistrictInfo d ON d.DistrictID=b.DistrictID");
               sql.Append(" JOIN TSchoolGroup e ON e.SchoolGroupID=b.SchoolGroupID");
               sql.Append(" LEFT JOIN ");
               sql.AppendFormat(" (SELECT * FROM TEntriesInfo f where f.EnrolInfoID = {0} AND f.UserID = {1} ) c",myEnrollID,myUserID);
               sql.Append("  ON c.EnrolInfoID=a.EnrollID");
               sql.AppendFormat(" WHERE a.EnrollID = {0} ",  myEnrollID);
               sql.Append(" AND a.EntriesName IS NOT NULL;");

               dt = DbHelperSQL.Query(sql.ToString()).Tables[0];
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }
        public static DataTable GetWorksInfo(Int32 myEnrollID)//管理员获取作品评审信息
        {
            StringBuilder sql = new StringBuilder();
            DataTable dt;
            try
            {
                sql.Append("SELECT a.EnrollID,a.EntriesName,a.EnrolName,a.EnrolSex,d.DistrictName,b.SchoolName,");
                sql.Append("e.SchoolGroupName,a.EntriesTime,c.EnrolScore,c.EnrolComment,c.UserID,a.EntriesURL,");
                sql.Append("(CASE  c.AuditStatus WHEN 1 THEN '已审核' ELSE '未审核' END) as AuditStatus,c.EnrolTime,s.SubjectName");
                sql.Append(" FROM TEnrolInfo a JOIN TSchoolInfo b ON a.SchoolID=b.SchoolID ");
                sql.Append(" JOIN TSubject s ON s.SubjectID=a.EnrolSubject");
                sql.Append(" JOIN TDistrictInfo d ON d.DistrictID=b.DistrictID");
                sql.Append(" JOIN TSchoolGroup e ON e.SchoolGroupID=b.SchoolGroupID");
                sql.Append(" LEFT JOIN dbo.TEntriesInfo c ON c.EnrolInfoID=a.EnrollID");
                sql.AppendFormat(" WHERE a.EnrollID = {0} ", myEnrollID);
                sql.Append(" AND a.EntriesName IS NOT NULL;");

                dt = DbHelperSQL.Query(sql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static bool AddEntriesInfoScore(Int32 myEnrollID, string myUserID, string Score, string Comment)
        {
            string EntriesTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into [TEntriesInfo] (");
            sql.Append("EnrolInfoID,UserID,EnrolScore,EnrolComment,AuditStatus,EnrolTime)");
            sql.AppendFormat("  select {0},{1},'{2}','{3}',{4},'{5}' ", myEnrollID, myUserID, Score, Comment, 1, EntriesTime);
            sql.Append(" where not exists (select * from [TEntriesInfo] b where ");
            sql.AppendFormat(" b.EnrolInfoID = {0} and UserID = {1});", myEnrollID, myUserID);
            try
            {
                DbHelperSQL.ExecuteSqlInsert(sql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public static DataTable GetSubjectInfo(string SubjectID)
        {
            string sql = "select SubjectID,SubjectName from TSubject where 1=1";
            if (!String.IsNullOrEmpty(SubjectID))
            {
                sql = sql + " and SubjectID='" + SubjectID + "'";
            }
            sql += " order by SubjectID";

            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
            DataRow dr = dt.NewRow();           
            DataTable rdt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["SubjectID"].ToString().Trim();
                dt.Rows[i]["SubjectName"] = dt.Rows[i]["SubjectName"].ToString().Trim();
                if (rdt.Rows.Count != 0)
                {
                    bool add = true;
                    foreach (DataRow item in rdt.Rows)
                    {
                        string test = item["SubjectID"].ToString().Trim();
                        if (item["SubjectID"].ToString().Trim().Equals(id))
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

        public static DataTable GetSchoolGroup(string SchoolGroupID)
        {
            string sql = "select SchoolGroupID,SchoolGroupName from [TSchoolGroup] where 1=1";
            if (!String.IsNullOrEmpty(SchoolGroupID))
            {
                sql = sql + " and SchoolGroupID=" + SchoolGroupID + "";
            }
            sql += " order by SchoolGroupID";

            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
            DataRow dr = dt.NewRow();
            DataTable rdt = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["SchoolGroupID"].ToString().Trim();
                dt.Rows[i]["SchoolGroupName"] = dt.Rows[i]["SchoolGroupName"].ToString().Trim();
                if (rdt.Rows.Count != 0)
                {
                    bool add = true;
                    foreach (DataRow item in rdt.Rows)
                    {
                        string test = item["SchoolGroupID"].ToString().Trim();
                        if (item["SchoolGroupID"].ToString().Trim().Equals(id))
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


        public static DataTable GetDistrictInfo(string DistrictID)
        {
            string sql = "select DistrictID,DistrictName from [TDistrictInfo] where 1=1";
            if (!String.IsNullOrEmpty(DistrictID))
            {
                sql = sql + " and DistrictID='" + DistrictID + "'";
            }
            sql += " order by DistrictID";

            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];            
            DataTable rdt = dt.Clone();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["DistrictID"].ToString().Trim();
                dt.Rows[i]["DistrictName"] = dt.Rows[i]["DistrictName"].ToString().Trim();
                if (rdt.Rows.Count != 0)
                {
                    bool add = true;
                    foreach (DataRow item in rdt.Rows)
                    {
                        string test = item["DistrictID"].ToString().Trim();
                        if (item["DistrictID"].ToString().Trim().Equals(id))
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


        public static bool AddEnrolInfo(EnrolInfo Info)
        {
            string sql = "insert into TEnrolInfo (EnrolName,EnrolSex,EnrolBirthday,EnrolWorkYear,EnrolTel,EnrolTeacherTitle,EnrolSubject,SchoolID)";
                   sql +=  " values('"+Info.EnrolName+"','"+Info.EnrolSex+"','"+Info.EnrolBirthday+"','"+Info.EnrolWorkYear+"','"+Info.EnrolTel+"','"+Info.EnrolTeacherTitle+"',"+Info.EnrolSubject+","+Info.SchoolID+")"; 
            try
            {
                DbHelperSQL.ExecuteSqlInsert(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
          
            return true;
        }
        public static bool AddEnrolEntries(string EnrollID, string EntriesName, string EntriesURL)
        {
            string EntriesTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            StringBuilder sql = new StringBuilder();
            sql.Append("update [TEnrolInfo] SET ");
            sql.AppendFormat(" EntriesName = '{0}',EntriesURL = '{1}',", EntriesName, EntriesURL);
            sql.AppendFormat(" EntriesTime = '{0}' ", EntriesTime);
            sql.AppendFormat(" WHERE EnrollID = {0};", EnrollID);
            try
            {
                DbHelperSQL.ExecuteSqlInsert(sql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public static bool DeleteEnrolInfo(string EnrollID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM [TEnrolInfo] WHERE EnrollID={0};", EnrollID);
             
            try
            {
                DbHelperSQL.ExecuteSqlInsert(sql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }
        public static bool UpdateEnrolInfo(EnrolInfo Info)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE [TEnrolInfo] SET ");
            sql.AppendFormat(" EnrolName='{0}',", Info.EnrolName);            
            sql.AppendFormat(" EnrolSex='{0}',", Info.EnrolSex);
            sql.AppendFormat(" EnrolBirthday='{0}',", Info.EnrolBirthday);
            sql.AppendFormat(" EnrolWorkYear='{0}',", Info.EnrolWorkYear);
            sql.AppendFormat(" EnrolTel='{0}',", Info.EnrolTel);
            sql.AppendFormat(" EnrolTeacherTitle='{0}',", Info.EnrolTeacherTitle);
            sql.AppendFormat(" EnrolSubject={0},", Info.EnrolSubject);
            sql.AppendFormat(" SchoolID={0} ", Info.SchoolID);
            sql.AppendFormat(" WHERE EnrollID={0};",Info.EnrollID);
            
            try
            {
                DbHelperSQL.ExecuteSqlInsert(sql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public static bool UpdateIsFirst(bool IsFirst,string UserNo)
        {
            int IsFirstID=0;
            if (IsFirst)
	        {
		       IsFirstID=1;
	        }
            StringBuilder sql = new StringBuilder();
            string  sqlstr="UPDATE [TUserInfo] SET IsFirst={0} WHERE UserNo = {1};";
            sql.AppendFormat(sqlstr, IsFirstID, UserNo);
            try
            {
                DbHelperSQL.ExecuteSqlInsert(sql.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public static void BindDataToList2(DropDownList DropList, DataTable Dt, string TextField, string ValueField)
        {
            DropList.DataSource = Dt;
            DropList.DataTextField = TextField;
            DropList.DataValueField = ValueField;
            DropList.DataBind();
            DropList.Items.Insert(0, new ListItem("全部", "0"));
        }
        public static void BindDataToList(DropDownList DropList, DataTable Dt, string TextField, string ValueField)
        {
            DropList.DataSource = Dt;
            DropList.DataTextField = TextField;
            DropList.DataValueField = ValueField;
            DropList.DataBind();
        }
        public static void ClearUserInfo(string usrid) {
            StringBuilder str = new StringBuilder();
            str.Append("<script>");
            str.Append("function () {var currentHost=window.location;var clientPath = 'http://lzyun.doule.net:20107/aam/rest/account/logout/' + currentHost;window.location.href = clientPath;})");
            str.Append("</script>");
            //return str.ToString();
        }
        public static bool UserClearOut(String urlTemp)
        {

            HttpWebRequest request = WebRequest.Create(urlTemp) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            //读取到用户信息
            string resultJson = reader.ReadToEnd();
            //Newtonsoft.Json.Linq.JArray ja = (Newtonsoft.Json.Linq.JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(resultJson); //用这种方法解析json会报错，所以这里不用
            //JObject infoJObject = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(resultJson); //用这种方法来解析json
            if (resultJson.Contains("success"))
            {
                return true;
            }
            else
            {
                return false;
            }
            //return infoJObject;
        }

    }
}