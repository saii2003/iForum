using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Web.Security;
using System.Security;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data;

/// <summary>
/// 會員商業邏輯
/// </summary>

namespace iFourms
{
    public class MemberBL
    {
        public string _M_ID { get; set; }
        public string _Username { get; set; }
        public string _Nickname { get; set; }
        public string _Gender { get; set; }
        public DateTime _Birthday { get; set; }
        public string _Email { get; set; }
        public string _RegTime { get; set; }
        public string _RegIP { get; set; }

        #region 註冊
        public int Register(string Username, string Password, string Nickname, string Gender, DateTime Birthday, string Email)
        {
            int Result = 0;
            MemberDA da = new MemberDA();
            string ValidateCode = getVaildateCode(20);//註冊驗證碼
            DateTime RegTime = DateTime.Now;//註冊時間
            string RegIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();//取得Client端IP
            string ValidateUrl = "http://" + HttpContext.Current.Request.Url.Host + "/Member/Validate.aspx" + "?v=" + ValidateCode;

            if (da.Register(Username, Password, Nickname, Gender, Birthday, Email, RegTime, RegIP, ValidateCode) > 0)
            {
                //string Subject = "iForum會員註冊驗證信";
                //string Body = Username + "恭喜您已經註冊成功，請點擊下面超連結進行會員驗證：<br/>" + "<a href=" + ValidateUrl + ">" + ValidateUrl + "</a>";
                //SendMail(Email, Subject, Body);
                Result = 1;//註冊成功
            }
            return Result;
        }
        #endregion

        #region 登入
        public bool _Login(string Username, string Password,double expireTime)
        {
            bool allow = false;
            MemberDA da = new MemberDA();
            
            if (da.Login(Username, Password))
            {
                
                if (da.uValidate == true)//會員驗證是否通過
                {
                    this._M_ID = da.M_ID;
                    this._Username = da.Username;
                    this._Nickname = da.Nickname;
                    this._Email = da.Email;
                    this._RegTime = da.RegTime;
                    this._RegIP = da.RegIP;

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        da.Username,//註冊會員帳號
                        DateTime.Now,//起始時間
                        DateTime.Now.AddMinutes(expireTime),//到期時間
                        false,
                        "Login",
                        FormsAuthentication.FormsCookiePath);
                    //加密
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    allow = true;
                    
                   
        
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('您的帳號驗證尚未通過!');</script>");
                    allow = false;//會員驗證未通過
                }

            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('您輸入的資料有誤，請重新輸入!');</script>");
            }
            return  allow;
        }
        #endregion

        #region 新會員驗證
        public int Validate(string ValidateCode)
        {
            MemberDA da = new MemberDA();
            return da.Validate(ValidateCode);
        }
        #endregion

        #region 忘記密碼
        public int ForgetPassword(string Username,string Email)
        {
            int Result = 0;
            MemberDA da = new MemberDA();
            string ValidCode = getVaildateCode(20);//驗證碼
            string ValidateUrl = "http://" + HttpContext.Current.Request.Url.Host + "/Member/NewPassword.aspx" + "?v=" + ValidCode;

            if (da.ForgetPassword(Username, Email, ValidCode) > 0)
            {
                string Subject = "iForum會員設定新密碼";
                string Body = "請點擊下面超連結設定新密碼：<br/>" + "<a href=" + ValidateUrl + ">" + ValidateUrl + "</a>";
                SendMail(Email, Subject, Body);
                Result = 1;
            }
            return Result;
        }
        #endregion

        #region 設定新密碼
        public int setPassword(string Password, string ValidCode)
        {
            MemberDA da = new MemberDA();
            return da.setPassword(Password, ValidCode);
        }
        #endregion

        #region 變更密碼
        public void change_pw(string username, string old_pw, string new_pw)
        {
            MemberDA da = new MemberDA();
            if (da.change_pw(username, old_pw, new_pw) > 0)
            {
                HttpContext.Current.Response.Write("<script>alert('變更成功!');</script>");
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('變更失敗!');</script>");
            }
        }
        #endregion

        #region 寄發電子郵件
        public void SendMail(string toMail,string Subject,string Body)
        {
            MailMessage Mail = new MailMessage();
            Mail.From = new MailAddress("your mail acount");
            Mail.To.Add(toMail);
            Mail.Subject = Subject;
            Mail.Body = Body;
            Mail.IsBodyHtml = true;

            SmtpClient Smtp = new SmtpClient();
            Smtp.Host = "your mail host";
            Smtp.Port = 25;
            Smtp.Credentials = new NetworkCredential("your mail account", "your mail password");

            Smtp.Send(Mail);
        }
        #endregion

        #region 驗證碼
        public string getVaildateCode(int Count)
        {
            string[] Code = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
                                ,"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o"
                                ,"p","q","r","s","t","u","v","w","x","y","z"};
            string VaildateCode = string.Empty;
            Random rd = new Random();

            for (int i = 1; i <= Count; i++)
            {
                VaildateCode += Code[rd.Next(Code.Count())];
            }
            return VaildateCode;

        }
        #endregion

        #region 圖片驗證碼
        public void getValidCodeImage()
        {
            string validcode = getVaildateCode(5);//驗證碼
            HttpContext.Current.Session["code"] = validcode;
            Bitmap img = new Bitmap((validcode.Length * 22), 40);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.White);//圖層背景白色

            Random rd = new Random();

            for (int i = 0; i <= 15; i++)
            {
                int x1 = rd.Next(img.Width);
                int x2 = rd.Next(img.Width);
                int y1 = rd.Next(img.Height);
                int y2 = rd.Next(img.Height);
                g.DrawLine(new Pen(Color.Gold, 2f), x1, y1, x2, y2);
            }

            Font font = new Font("Times New Roman", 20, FontStyle.Bold);
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, 70, 40), Color.Silver, ColorTranslator.FromHtml("#8BB24B"), 5f, true);
            g.DrawString(validcode, font, brush, 2, 2);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/jpeg";
            HttpContext.Current.Response.BinaryWrite(ms.GetBuffer());
            g.Dispose();
            img.Dispose();
            HttpContext.Current.Response.End();
            
        }
        #endregion

        #region 上傳個人圖示
        public void upload_Icon(FileUpload file,string folderName)
        {
            MemberDA da = new MemberDA();
            
            string path = HttpContext.Current.Server.MapPath(".") + @"\Icon" + @"\" + folderName + @"\";//建立路徑
            string fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);//建立會員資料夾
            }

            bool allow = false;//是否允許上傳
            string[] allowExtension = { ".jpeg", ".gif", ".png", "jpg" };

            //判斷允許的副檔名
            if (file.HasFile)
            {
                for (int i = 0; i < allowExtension.Length; i++)
                {
                    if (fileExtension == allowExtension[i])
                    {
                        allow = true;
                    }
                }


                if (allow)
                {
                    
                    if (da.upload(folderName, "1" + fileExtension) > 0)
                    {
                        file.SaveAs(path + "1" + fileExtension);
                        HttpContext.Current.Response.Write("<script>alert('上傳成功!');</script>");
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>alert('上傳失敗!');</script>");
                    }
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('副檔名格式錯誤!');</script>");
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('請選擇上傳檔案!');</script>");
            }


        }
        #endregion

        #region 變更個人資料
        public bool _editMemberData(string username, string nickname, string email)
        {
            bool result = false;
            MemberDA da = new MemberDA();
            if (da.editMemberData(username, nickname, email) > 0)
            {
                result = true;
                HttpContext.Current.Response.Write("<script>alert('編輯成功!'); location.href(/profile.aspx);</script>");
            }
            else
            {
                result = false;
                HttpContext.Current.Response.Write("<script>alert('編輯失敗!');</script>");
            }
            return result;
        }
        #endregion

        #region 取得會員個人文章
        public DataTable _getMemArticle(string mid)
        {
            MemberDA da= new MemberDA();
            return da.getMemArticle(mid);
        }
        #endregion

        #region 帳號是否重複
        public bool _checkUsername(string username)
        {
            MemberDA da = new MemberDA();
            return da.checkUsername(username);
        }
        #endregion
    }
}