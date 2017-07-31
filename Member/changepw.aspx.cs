using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Member
{
    public partial class changepw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Forum/index.aspx");
                }
            }
        }

        protected void changepwbutton_Click(object sender, EventArgs e)
        {
            MemberBL bl = new MemberBL();
            if (password.Text == repassword.Text)
            {
                bl.change_pw(HttpContext.Current.User.Identity.Name.ToString(), FormsAuthentication.HashPasswordForStoringInConfigFile(oldpassword.Text, "MD5"), FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"));
            }
            else
            {
                Response.Write("<script>alert('新密碼確認新密碼需一致!');</script>");
            }
        }
    }
}