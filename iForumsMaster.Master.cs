using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace iFourms
{
    public partial class iForumsMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.Year.ToString();
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                
                welcome.Text = "Hi," + HttpContext.Current.User.Identity.Name.ToString() + "歡迎";
                iforumlogin.Text = "登出";

                iforumregister.Text = "個人中心";
                iforumregister.PostBackUrl = "~/Member/profile.aspx";
            }
            else
            {
                welcome.Text = "Hi,歡迎到來iForum";
                iforumlogin.Text = "登入";
                iforumlogin.PostBackUrl = "~/Member/login.aspx";

                iforumregister.Text = "註冊";
                iforumregister.PostBackUrl = "~/Member/Register.aspx";
       
            }
            
        }

        protected void iforumlogin_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Response.Cookies[HttpContext.Current.User.Identity.Name.ToString()].Expires = DateTime.Now.AddYears(-1);
                Response.Redirect("~/Member/login.aspx");
            }
        }
    }
}