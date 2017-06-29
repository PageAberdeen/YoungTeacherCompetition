using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ComputerBS
{
    public class DBHelper
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>数据集合</returns>
        public DataSet GetDataSet(string sql) {
            DataSet ds=DbHelperSQL.Query(sql);
            return ds;
        }
        #region Works数据操作
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="groupId">分组id</param>
        /// <param name="CategoryId">活动类别id</param>
        /// <param name="PageNub">页码</param>
        /// <returns>作品数据集合</returns>

        public DataSet GetWorks(int groupId, int CategoryId, int PageNub)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select * from Works where 1=1");
            if (groupId>=0&&groupId!=null)
            {
                str.AppendFormat(" and GroupId={0}",groupId);
            }
            if (CategoryId >= 0 && CategoryId != null)
            {
                str.AppendFormat(" and CategoryId={0}", CategoryId);
            }
            if (PageNub >= 0 && PageNub!=null)
            {
                str.AppendFormat(" and WID>(select MAX(WID) WID from (select top {0} WID from Works order by WID) s) order by WID", PageNub * 8);
            }
            return DbHelperSQL.Query(str.ToString());
        }
        /// <summary>
        /// 带参数获取作品
        /// </summary>
        /// <param name="groupId">组id</param>
        /// <param name="CategoryId">活动id</param>
        /// <param name="PageNub">页码</param>
        /// <returns>作品信息集合</returns>
        public DataSet GetWorksPara(int groupId, int CategoryId, int PageNub)
        {
            StringBuilder str = new StringBuilder();
            str.Append("select * from Works where 1=1");
            SqlParameter[] para = null;
            if (groupId >= 0 && groupId != null)
            {
                str.AppendFormat(" and GroupId=@GroupId", groupId);
                SqlParameter pr = new SqlParameter("@GroupId",SqlDbType.Int);
                para[0] = pr;
            }
            if (CategoryId >= 0 && CategoryId != null)
            {
                str.AppendFormat(" and CategoryId=@CategoryId", CategoryId);
                SqlParameter pr = new SqlParameter("@CategoryId", SqlDbType.Int);
                para[1] = pr;
            }
            if (PageNub >= 0 && PageNub != null)
            {
                str.AppendFormat(" and WID>(select MAX(WID) WID from (select top {0} WID from Works order by WID) s) order by WID", PageNub * 8);
            }
            return DbHelperSQL.Query(str.ToString(),para);
        }
        public DataSet GetWorksById(int wid) {
            string sql = "select WFileName from Works where WID=@WID";
            SqlParameter[] para = { new SqlParameter("@WID",SqlDbType.Int) };
            para[0].Value = wid;
            return DbHelperSQL.Query(sql,para);
        }
        public string GetWorksStringById(int wid)
        {
            string sql = "select WFileName,WPackageName from Works where WID=@WID";
            SqlParameter[] para = { new SqlParameter("@WID", SqlDbType.Int) };
            para[0].Value = wid;
            DataSet ds=DbHelperSQL.Query(sql, para);
            DataTable dt = ds.Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string str = dt.Rows[0]["WPackageName"].ToString();
            //}
            string WPackageName = dt.Rows[0]["WPackageName"].ToString();
            return WPackageName;
        }
        /// <summary>
        /// 根据选择页码查询数据
        /// </summary>
        /// <param name="TopStartIndex">开始页</param>
        /// <param name="TopStopIndex">结束页</param>
        /// <param name="sqlstr">其他条件语句</param>
        /// <returns></returns>
        public DataSet GetWorks(int TopStartIndex,int TopStopIndex,string sqlstr) {
            StringBuilder sql = new StringBuilder();
            if (TopStartIndex==0)
            {
                sql.AppendFormat("select top {0} * from Works order by WID",TopStopIndex);
            }
            else
            {
                sql.AppendFormat("select top {0} * from Works where WID not in(select top {1} WID from Works order by WID)",TopStopIndex,TopStartIndex);
            }
            if (!string.IsNullOrEmpty(sqlstr))
            {
                sql.AppendFormat(" and {0}", sqlstr);
            }
            return DbHelperSQL.Query(sql.ToString());
        }
        /// <summary>
        /// 根据选择页码查询数据--带参数
        /// </summary>
        /// <param name="TopStartIndex">开始页</param>
        /// <param name="TopStopIndex">结束页</param>
        /// <param name="sqlstr">其他条件语句</param>
        /// <returns></returns>
        public DataSet GetWorksPara(int TopStartIndex, int TopStopIndex, string sqlstr)
        {
            StringBuilder sql = new StringBuilder();
            SqlParameter[] para = null;
            if (TopStartIndex == 0)
            {
                sql.Append("select top @TopStopIndex * from Works order by WID");
                SqlParameter pr = new SqlParameter("@TopStopIndex",SqlDbType.Int);
                pr.Value = TopStartIndex;
                para[0] = pr;
            }
            else
            {
                //sql.AppendFormat("select top {0} * from Works where WID not in(select top {1} WID from Works order by WID) order by WID", TopStopIndex, TopStartIndex);
                sql.Append("select top @TopStopIndex * from Works where WID not in(select top @TopStartIndex WID from Works order by WID) order by WID");
                SqlParameter pr1 = new SqlParameter("@TopStopIndex", SqlDbType.Int);
                pr1.Value = TopStopIndex;
                SqlParameter pr2 = new SqlParameter("@TopStartIndex", SqlDbType.Int);
                pr2.Value = TopStartIndex;
                para[0] = pr1;
                para[1] = pr2;
            }
            if (!string.IsNullOrEmpty(sqlstr))
            {
                sql.Append(" and @str");
                SqlParameter pr = new SqlParameter("@str",SqlDbType.VarChar);
                pr.Value = sqlstr;
                para[para.Length] = pr;
            }
            return DbHelperSQL.Query(sql.ToString(),para);
        }
        public int InsertWorks(string WName,string WUserName,string WuserClass,string WpackageName,string Wnote,string WfileName,string Wreview,int GroupId,int CategoryId) {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Works(WAddDate,WName,WUserName,WUserClass,WPackageName,WNote,WFileName,WReview,GroupID,CategoryID) values(");
            sql.AppendFormat("GetDate(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8})",WName,WUserName,WuserClass,WpackageName,Wnote,WfileName,Wreview,GroupId,CategoryId);
            return DbHelperSQL.ExecuteSql(sql.ToString());
            //if (!string.IsNullOrEmpty(AddDate.ToString()))
            //{
            //    sql.AppendFormat("'{0}'",AddDate);
            //}
            //if (!string.IsNullOrEmpty(WName))
            //{
            //    sql.AppendFormat("'{0}'",WName);
            //}
            //if (!string.IsNullOrEmpty(WUserName))
            //{
            //    sql.AppendFormat("'{0}'",WUserName);
            //}
            //if (!string.IsNullOrEmpty(WuserClass))
            //{
            //    sql.AppendFormat("'{0}'",WuserClass);
            //}
        }
        /// <summary>
        /// 带参数的插入方式
        /// </summary>
        /// <param name="WName">作品名称</param>
        /// <param name="WUserName">作者</param>
        /// <param name="WuserClass">作者班级</param>
        /// <param name="WpackageName">作品上传名称-包名称</param>
        /// <param name="Wnote">作品描述</param>
        /// <param name="WfileName">文件名称</param>
        /// <param name="Wreview">是否已经评审0为未评审，1为已评审</param>
        /// <param name="GroupId">作品所在分组id</param>
        /// <param name="CategoryId">作品所在活动类别id</param>
        /// <returns></returns>
        public int InsertWorksPara(string WName, string WUserName, string WuserClass, string WpackageName, string Wnote, string WfileName, string Wreview, int GroupId, int CategoryId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Works(WAddDate,WName,WUserName,WUserClass,WPackageName,WNote,WFileName,WReview,GroupID,CategoryID) values(GetDate(),@WName,@WUserName,@WUserClass,@WPackageName,@WNote,@WFileName,@WReview,@GroupID,@CategoryID)");
            SqlParameter[] para = {
                  new SqlParameter("@WName",SqlDbType.VarChar),
                  new SqlParameter("@WUserName",SqlDbType.VarChar),
                  new SqlParameter("@WUserClass",SqlDbType.VarChar),
                  new SqlParameter("@WPackageName",SqlDbType.VarChar),
                  new SqlParameter("@WNote",SqlDbType.VarChar),
                  new SqlParameter("@WFileName",SqlDbType.VarChar),
                  new SqlParameter("@WReview",SqlDbType.VarChar,3),
                  new SqlParameter("@GroupID",SqlDbType.Int),
                  new SqlParameter("@CategoryID",SqlDbType.Int)
                  };
            para[0].Value = WName;
            para[1].Value = WUserName;
            para[2].Value = WuserClass;
            para[3].Value = WpackageName;
            para[4].Value = Wnote;
            para[5].Value = WfileName;
            para[6].Value = Wreview;
            para[7].Value = GroupId;
            para[8].Value = CategoryId;
            return DbHelperSQL.ExecuteSql(sql.ToString(),para);
        }
        #endregion
        #region 评分记录操作方法
        public DataSet SelectScorce(int Wid) {
            string sql = "select * from Scorce where WID="+Wid;
            return DbHelperSQL.Query(sql);
        }

        public DataSet SelectScorcePara(int Wid)
        {
            string sql = "select * from Scorce where WID=@ID";
            SqlParameter[] para ={new SqlParameter("@ID",SqlDbType.Int)};
            para[0].Value = Wid;
            return DbHelperSQL.Query(sql,para);
        }
        /// <summary>
        /// 评委给分--带参
        /// </summary>
        /// <param name="ScorceNub">分数</param>
        /// <param name="SetExpertId">评委id</param>
        /// <param name="SetExpertName">评委姓名之类的</param>
        /// <param name="Wid">作品id</param>
        /// <param name="WexpertNote">评委评语</param>
        /// <returns>受影响的行</returns>
        public static int InsertScorce(int ScorceNub,string SetExpertId,string SetExpertName,int Wid,string WexpertNote)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Scorce(ScorceNub,SetExpertId,SetExpertName,WID,WExpertNote,ScorceDate) values(");
            sql.Append("@ScorceNub,@SetExpertId,@SetExpertName,@Wid,@WexpertNote,GetDate())");
            SqlParameter[] para = {
                    new SqlParameter("@ScorceNub",SqlDbType.Int),
                    new SqlParameter("@SetExpertId",SqlDbType.VarChar,20),
                    new SqlParameter("@SetExpertName",SqlDbType.VarChar),
                    new SqlParameter("@Wid",SqlDbType.Int),
                    new SqlParameter("@WexpertNote",SqlDbType.VarChar)
                                  };
            para[0].Value = ScorceNub;
            para[1].Value = SetExpertId;
            para[2].Value = SetExpertName;
            para[3].Value = Wid;
            para[4].Value = WexpertNote;
            return DbHelperSQL.ExecuteSql(sql.ToString(),para);
        }
        #endregion
        public int InsertCatagoryGroup(string CategoryName, int GroupID, string GroupName)
        {
            string sql = "insert into CatagoryGroup(CategoryName,GroupID,GroupName) values(@CategoryName,@GroupID,@GroupName)";
            SqlParameter[] para = {
                new SqlParameter("@CategoryName",SqlDbType.VarChar),
                new SqlParameter("@GroupID",SqlDbType.Int),
                new SqlParameter("@GroupName",SqlDbType.VarChar)
                                  };
            para[0].Value = CategoryName;
            para[1].Value = GroupID;
            para[2].Value = GroupName;
            return DbHelperSQL.ExecuteSql(sql,para);
        }
        /// <summary>
        /// 查询分组和活动
        /// </summary>
        /// <param name="CategoryID">活动id</param>
        /// <param name="CategoryName">活动名称</param>
        /// <param name="GroupID">分组id</param>
        /// <param name="GroupName">分组名称</param>
        /// <returns>组和活动信息</returns>
        public DataSet SelectCatagoryGroup(int CategoryID,string CategoryName, int GroupID, string GroupName)
        {
            StringBuilder sql = new StringBuilder();
            SqlParameter[] para = null;
            int i = 0;
            sql.Append("select * from CatagoryGroup where 1=1");
            if (CategoryID!=null&&CategoryID>0)
            {
                sql.Append(" and CategoryID=@CategoryID");
                para[i] = new SqlParameter("@CategoryID",SqlDbType.Int);
                para[i].Value = CategoryID;
                i++;
            }
            if (!String.IsNullOrEmpty(CategoryName))
            {
                sql.Append(" and CategoryName like '%'@CategoryName'%'");
                para[i] = new SqlParameter("@CategoryName", SqlDbType.VarChar);
                para[i].Value = CategoryName;
                i++;
            }
            if (GroupID!=null&&GroupID>0)
            {
                sql.Append(" and GroupID=@GroupID");
                para[i] = new SqlParameter("@GroupID", SqlDbType.Int);
                para[i].Value = GroupID;
                i++;
            }
            if (!string.IsNullOrEmpty(GroupName))
            {
                sql.Append(" and GroupName like '%'@GroupName'%'");
                para[i] = new SqlParameter("@GroupName", SqlDbType.VarChar);
                para[i].Value = GroupName;
                i++;
            }
            return DbHelperSQL.Query(sql.ToString(),para);
        }
        public DataSet GetUser(string UserAccountId) {
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from UserInfo where UserAccountID like @UserAccountId");
            SqlParameter[] para = { new SqlParameter("@UserAccountId",SqlDbType.VarChar) };
            para[0].Value = UserAccountId;
            return DbHelperSQL.Query(sql.ToString(),para);
        }
        public  DataTable GetCategory(string gropId)
        {
            string sql = "select * from CatagoryGroup";
            if (!string.IsNullOrEmpty(gropId))
            {
                sql += " where GroupID='" + gropId + "'"; ;
            }
            DataTable dt = DbHelperSQL.Query(sql, null).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["CategoryName"] = dt.Rows[i]["CategoryName"].ToString().Trim();
                dt.Rows[i]["GroupID"] = dt.Rows[i]["GroupID"].ToString().Trim();
                dt.Rows[i]["CategoryID"] = dt.Rows[i]["CategoryID"].ToString().Trim();
            }
            return dt;
        }
    }
}