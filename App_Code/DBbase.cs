using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 資料庫基本連線設定
/// </summary>
namespace iFourms
{
    public class DBbase
    {
        private SqlConnection publicConnect = null;//公用連線

        public DBbase()
        {
            publicConnect = getConnect();
        }

        #region 取得連線
        public SqlConnection getConnect()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["iForumConnectionString"].ConnectionString);
            conn.Open();
            return conn;
        }
        #endregion

        #region 取得sqlcommed
        public SqlCommand getSqlCommand(string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, publicConnect);
            return cmd;
        }
        #endregion 

        #region 釋放連線資源
        public void Dispose()
        {
            if (publicConnect.State == ConnectionState.Open)
            {
                publicConnect.Close();
                publicConnect.Dispose();   
            }
        }
        #endregion 

    }
}