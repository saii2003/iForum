using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Member
{
    public partial class profile : System.Web.UI.Page
    {
        MemberBL bl = new MemberBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    HttpCookie cookie = Request.Cookies[HttpContext.Current.User.Identity.Name];
                    profileid.Text = cookie.Values["id"].ToString();
                    profileusername.Text = cookie.Values["username"].ToString();
                    profilenickname.Text = cookie.Values["nickname"].ToString();
                    profileemail.Text = cookie.Values["email"].ToString();
                    profileregtime.Text = cookie.Values["regtime"].ToString();
                    profileregip.Text = cookie.Values["regip"].ToString();
                }
                else
                {
                    Response.Redirect("~/Forum/index.aspx");
                }
            }
        }

        protected void meditbutton_Click(object sender, EventArgs e)
        {
            if (bl._editMemberData(HttpContext.Current.User.Identity.Name, profilenickname.Text, profileemail.Text))
            {
                HttpCookie cookie = Response.Cookies[HttpContext.Current.User.Identity.Name];
                cookie.Values["id"] = profileid.Text;
                cookie.Values["username"] = profileusername.Text;
                cookie.Values["nickname"] = profilenickname.Text;
                cookie.Values["email"] = profileemail.Text;
                cookie.Values["regtime"] = profileregtime.Text;
                cookie.Values["regip"] = profileregip.Text;
                Response.Cookies.Add(cookie);
            }

        }
    }
}