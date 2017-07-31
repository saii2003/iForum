using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Forum 資料存取
/// </summary>

namespace iFourms
{
    public class ForumDA:DBbase
    {
        #region 新增文章
        public int insertArticle(string m_ID, string title, string classID, DateTime createTime, string createIP, string contents, int hit)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("INSERT INTO Article(M_ID,Title,ClassID,CreateTime,CreateIP,Contents,Hit) VALUES (@M_ID,@Title,@ClassID,@CreateTime,@CreateIP,@Contents,@Hit)");
            cmd.Parameters.AddWithValue("M_ID", m_ID);
            cmd.Parameters.AddWithValue("Title", title);
            cmd.Parameters.AddWithValue("ClassID", classID);
            cmd.Parameters.AddWithValue("CreateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("CreateIP", createIP);
            cmd.Parameters.AddWithValue("Contents", contents);
            cmd.Parameters.AddWithValue("hit", 0);

            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;

        }
        #endregion

        #region 取的Article Data
        public DataTable getArticleData(string current_page)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("Select * From(Select Row_Number() Over(order by Article.CreateTime desc) as RowNum,Members.Username,Members.M_ID,Article.A_ID,Article.Title,Article.Hit,Article.CreateTime,Class.ClassName From Members,Article,Class Where Members.M_ID = Article.M_ID AND Class.C_ID = Article.ClassID) as newt Where RowNum BETWEEN ((@current_page - 1)*10+1) AND ((@current_page - 1)*10+10)");
            cmd.Parameters.AddWithValue("current_page", current_page);
            dt.Load(cmd.ExecuteReader());
            Dispose();
            cmd.Dispose();
            dt.Dispose();
            return dt;
        }
        #endregion

        #region 取的總文章數
        public int getArticleCount()
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("Select Count(*) From Article");
            result = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            Dispose();
            return result;      
        }
        #endregion

        #region 取的回覆數
        public int getMessageCount(string aid)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("Select Count(*) From Message Where A_ID=@aid");
            cmd.Parameters.AddWithValue("aid",aid);
            result = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            Dispose();
            return result;

        }
        #endregion

        #region 取得發文者資料
        public DataTable getProfileDetail(string aid)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("SELECT Members.M_ID,Members.Username,Members.Icon,Members.RegTime,Article.Title,Article.A_ID,Article.Contents,Article.CreateTime as acreatetime,Class.ClassName FROM Members,Article,Class WHERE Members.M_ID = Article.M_ID AND Article.ClassID = Class.C_ID AND  Article.A_ID =@aid");
            cmd.Parameters.AddWithValue("aid", aid);
            dt.Load(cmd.ExecuteReader());
            dt.Dispose();
            cmd.Dispose();
            Dispose();
            return dt;

        }
        #endregion

        #region 取的留言資料
        public DataTable getMessageDetail(string aid,string current_page)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("Select * From(Select Row_Number() Over(order by Message.Mg_ID) as RowNum,Members.Username,Members.M_ID,Members.RegTime,Members.Icon,Message.CreateTime,Message.Contents From Members,Message Where Members.M_ID = Message.M_ID AND Message.A_ID=@aid) as newt Where RowNum BETWEEN ((@current_page - 1)*10+1) AND ((@current_page - 1)*10+10)");
            cmd.Parameters.AddWithValue("aid", aid);
            cmd.Parameters.AddWithValue("current_page", current_page);
            dt.Load(cmd.ExecuteReader());
            dt.Dispose();
            cmd.Dispose();
            Dispose();
            return dt;

        }

        #endregion

        #region 取得個人文章數
        public int getM_ArticleCount(string mid)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("SELECT Count(*) FROM Article WHERE M_ID=@mid");
            cmd.Parameters.AddWithValue("mid", mid);
            result = Convert.ToInt32(cmd.ExecuteScalar());
            Dispose();
            cmd.Dispose();
            return result;

        }
        #endregion

        #region 取得最後回覆
        public string get_LastMessage(string aid)
        {
            string result = "";
            SqlDataReader dr;
            SqlCommand cmd = getSqlCommand("SELECT Members.Username,Message.CreateTime,Message.A_ID FROM Members,Message WHERE Members.M_ID = Message.M_ID AND Message.A_ID = @aid Order by Message.CreateTime ASC");
            cmd.Parameters.AddWithValue("aid", aid);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    result = dr["Username"].ToString() + "<br/>" + Convert.ToDateTime(dr["CreateTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            dr.Dispose();
            cmd.Dispose();
            Dispose();
            return result;

        }
        #endregion

        #region 取的最後發表
        public DataTable getLastMessage()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("SELECT Message. FROM Message,Members,Article WHERE Members.M_ID=Message.M_ID AND Article.A_ID = Message.A_ID DEC");
            dt.Load(cmd.ExecuteReader());
            cmd.Dispose();
            Dispose();
            return dt;
        }
        #endregion

        #region 編輯文章
        public int updateArticle(int a_ID,string title,string contents)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Article SET Title=@title,Contents=@contents WHERE A_ID=@a_ID");
            cmd.Parameters.AddWithValue("Title", title);
            cmd.Parameters.AddWithValue("Contents", contents);
            cmd.Parameters.AddWithValue("A_ID", a_ID);
            result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            Dispose();
            return result;
        }
        #endregion 刪除文章

        #region 刪除文章
        public int deleteArticle(int a_ID)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("DELETE FROM Article WHERE A_id=a_ID");
            cmd.Parameters.AddWithValue("A_ID", a_ID);

            result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            Dispose();
            return result;
        }
        #endregion

        #region 新增回文
        public int insertMessage(string a_ID,string m_ID,string contents,string createIP)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("INSERT INTO Message(A_ID,M_ID,Contents,CreateTime,CreateIP) VALUES (@A_ID,@M_ID,@Contents,@CreateTime,@CreateIP)");
            cmd.Parameters.AddWithValue("A_ID", a_ID);
            cmd.Parameters.AddWithValue("M_ID", m_ID);
            cmd.Parameters.AddWithValue("Contents", contents);
            cmd.Parameters.AddWithValue("CreateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("CreateIP", createIP);

            result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            Dispose();

            return result;

        }
        #endregion

        #region 取的所有文章
        public DataTable getArticle()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("SELECT * From Article WHERE CreatTime DEC");
            dt.Load(cmd.ExecuteReader());
            Dispose();
            cmd.Dispose();
            return dt;
        }
        #endregion

        #region 取得個人資訊
        public DataTable getprofile(string mid)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("Select * From Members Where M_ID=@mid");
            cmd.Parameters.AddWithValue("mid", mid);
            dt.Load(cmd.ExecuteReader());
            dt.Dispose();
            cmd.Dispose();
            Dispose();
            return dt;
            
        }
        #endregion

        #region 取得個人文章
        public DataTable getSelfArticle(string mid)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("Select * From Article Where M_ID=@mid");
            cmd.Parameters.AddWithValue("mid", mid);
            dt.Load(cmd.ExecuteReader());
            dt.Dispose();
            cmd.Dispose();
            Dispose();
            return dt;

        }
        #endregion

        #region 搜尋文章
        public DataTable searchArticle(string title,string current_page)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("Select * From(Select Row_Number() Over(order by Article.CreateTime) as RowNum,A_ID,Title,Contents,CreateTime From Article Where Title like '%' + @title + '%') as newt Where RowNum BETWEEN ((@current_page - 1)*10+1) AND ((@current_page - 1)*10+10)");
            cmd.Parameters.AddWithValue("title", title);
            cmd.Parameters.AddWithValue("current_page", current_page);
            dt.Load(cmd.ExecuteReader());
            Dispose();
            cmd.Dispose();
            dt.Dispose();
            return dt;
        }
        #endregion

        #region autocomplete
        public List<string> getSearch(string title)
        {
            List<string> articleTitle = new List<string>();
            SqlCommand cmd = getSqlCommand("Select title From Article Where title Like '%'+@title+'%'");
            cmd.Parameters.AddWithValue("@title", title);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                articleTitle.Add(dr.GetString(0));
            }
            cmd.Dispose();
            Dispose();
            return articleTitle;
         
        }
        #endregion


    }
}