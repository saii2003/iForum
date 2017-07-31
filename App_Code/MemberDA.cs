using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Security.Authentication;

/// <summary>
/// 會員資料存取
/// </summary>

namespace iFourms
{
    public class MemberDA:DBbase
    {
        public string M_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string RegTime { get; set; }
        public string RegIP { get; set; }
        public bool uValidate { get; set; }

        #region 註冊
        public int Register(string Username, string Password, string Nickname, string Gender, DateTime Birthday, string Email,DateTime RegTime,string RegIP,string ValidateCode)
        {

            SqlCommand cmd = getSqlCommand("INSERT INTO Members(Username,Password,Nickname,Gender,Birthday,Email,Icon,RegTime,RegIP,ValidateCode) VALUES (@Username,@Password,@Nickname,@Gender,@Birthday,@Email,@Icon,@RegTime,@RegIP,@ValidateCode)");
            cmd.Parameters.AddWithValue("Username", Username);
            cmd.Parameters.AddWithValue("Password", Password);
            cmd.Parameters.AddWithValue("Nickname", Nickname);
            cmd.Parameters.AddWithValue("Gender", Gender);
            cmd.Parameters.AddWithValue("Birthday", Birthday);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Icon", "0.png");
            cmd.Parameters.AddWithValue("RegTime", RegTime);
            cmd.Parameters.AddWithValue("RegIP", RegIP);
            cmd.Parameters.AddWithValue("ValidateCode", ValidateCode);

            int result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;
        }
        #endregion

        #region 登入
        public bool Login(string Username, string Password)
        {
            bool allow = false;//登入許可
            SqlDataReader dr;
            SqlCommand cmd = getSqlCommand("SELECT * FROM Members WHERE Username=@Username AND Password=@Password");
            cmd.Parameters.AddWithValue("Username", Username);
            cmd.Parameters.AddWithValue("Password", Password);

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                allow = true;
                while (dr.Read())
                {
                    this.M_ID = dr["M_ID"].ToString();
                    this.Username = dr["Username"].ToString();
                    this.Nickname = dr["Nickname"].ToString();
                    this.Email = dr["Email"].ToString();
                    this.RegTime = dr["RegTime"].ToString();
                    this.RegIP = dr["RegIP"].ToString();
                    this.uValidate = Convert.ToBoolean(dr["Validate"].ToString());
                }
            }
            dr.Close();
            Dispose();
            cmd.Dispose();
            return allow;
        }
        #endregion

        #region 忘記密碼
        public int ForgetPassword(string Username,string Email,string ValidateCode)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Members SET ValidateCode=@ValidateCode WHERE Username=@Username AND Email=@Email");
            cmd.Parameters.AddWithValue("Username", Username);
            cmd.Parameters.AddWithValue("ValidateCode", ValidateCode);
            cmd.Parameters.AddWithValue("Email", Email);
            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;
        }
        #endregion

        #region 設定密碼
        public int setPassword(string Password,string ValidCode)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Members SET Password=@Password,ValidateCode=@Valid WHERE ValidateCode=@ValidateCode");
            cmd.Parameters.AddWithValue("Password", Password);
            cmd.Parameters.AddWithValue("Valid", 0);
            cmd.Parameters.AddWithValue("ValidateCode",ValidCode);
            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;
        }
        #endregion

        #region 變更密碼
        public int change_pw(string username, string old_pw, string new_pw)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Members SET Password=@new_pw WHERE Username=@username AND Password=@old_pw");
            cmd.Parameters.AddWithValue("new_pw", new_pw);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("old_pw", old_pw);
            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;
        }
        #endregion

        #region 會員資料修改
        public int editMemberData(string username, string nickname, string email)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Members SET Nickname=@Nickname,Email=@Email WHERE Username=@Username");
            cmd.Parameters.AddWithValue("Username", username);
            cmd.Parameters.AddWithValue("Nickname", nickname);
            cmd.Parameters.AddWithValue("Email", email);
            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;
        }
        #endregion

        #region 會員帳號驗證
        public int Validate(string ValidateCode)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Members SET Validate=@Validate,ValidateCode=@ValidCode WHERE ValidateCode=@ValidateCode");
            cmd.Parameters.AddWithValue("Validate", true);
            cmd.Parameters.AddWithValue("ValidCode", 0);
            cmd.Parameters.AddWithValue("ValidateCode", ValidateCode);

            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;

        }
        #endregion

        #region 上傳圖示
        public int upload(string username,string Icon)
        {
            int result = 0;
            SqlCommand cmd = getSqlCommand("UPDATE Members SET Icon=@Icon WHERE Username=@Username");
            cmd.Parameters.AddWithValue("@Icon", Icon);
            cmd.Parameters.AddWithValue("@Username", username);
            result = cmd.ExecuteNonQuery();
            Dispose();
            cmd.Dispose();
            return result;

        }
        #endregion

        #region 會員文章
        public DataTable getMemArticle(string mid)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = getSqlCommand("SELECT * FROM Article WHERE M_ID=@mid");
            cmd.Parameters.AddWithValue("mid", mid);
            dt.Load(cmd.ExecuteReader());
            cmd.Dispose();
            Dispose();
            return dt;
            
        }
        #endregion

        #region 帳號是否重複
        public bool checkUsername(string username)
        {
            bool result = false;
            SqlDataReader dr;
            SqlCommand cmd = getSqlCommand("Select Username From Members Where Username=@username");
            cmd.Parameters.AddWithValue("username", username);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                result = true;
            }
            dr.Dispose();
            cmd.Dispose();
            Dispose();
            return result;
        }
        #endregion
    }
}