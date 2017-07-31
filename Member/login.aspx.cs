using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iFourms;
using Microsoft.Security.Application;
using System.Security;
using System.Web.Security;

namespace iFourms.Member
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //如果有已登入，先簽出。
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Member/login.aspx");
                }
            }
        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {
            MemberBL bl = new MemberBL();
            if (logincheck.Checked == true)
            {
                if (string.Compare(Session["code"].ToString(), code.Text, true) == 0)
                {

                    if (bl._Login(AntiXss.UrlEncode(username.Text), FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"), 43200))
                    {
                        HttpCookie cookie = new HttpCookie(username.Text);
                        cookie.Values["id"] = bl._M_ID;
                        cookie.Values["username"] = bl._Username;
                        cookie.Values["nickname"] = bl._Nickname;
                        cookie.Values["email"] = bl._Email;
                        cookie.Values["regtime"] = bl._RegTime;
                        cookie.Values["regip"] = bl._RegIP;
                        cookie.Expires = DateTime.Now.AddMinutes(43200);
                        Response.Cookies.Add(cookie);
                        Response.Redirect("../Forum/index.aspx");
                    }
                }
                else
                {
                    error.Text = "驗證碼錯誤!";
                }
            }
            else
            {
                if (string.Compare(Session["code"].ToString(), code.Text, true) == 0)
                {
                    if (bl._Login(AntiXss.UrlEncode(username.Text), FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"), 1440))
                    {

                        HttpCookie cookie = new HttpCookie(username.Text);
                        cookie.Values["id"] = bl._M_ID;
                        cookie.Values["username"] = bl._Username;
                        cookie.Values["nickname"] = bl._Nickname;
                        cookie.Values["email"] = bl._Email;
                        cookie.Values["regtime"] = bl._RegTime;
                        cookie.Values["regip"] = bl._RegIP;
                        cookie.Expires = DateTime.Now.AddMinutes(1440);
                        Response.Cookies.Add(cookie);
                        Response.Redirect("../Forum/index.aspx");
                    }
                }
                else
                {
                    error.Text = "驗證碼錯誤!";
                }
            }
        }

        protected void logincancel_Click(object sender, EventArgs e)
        {
            username.Text = "";
            password.Text = "";
            code.Text = "";

        }
    }
}