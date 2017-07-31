using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using iFourms;

namespace iFourms.Member
{
    public partial class new_pw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["v"] == null)
                {
                    Response.Redirect("../index.aspx");
                }
            }
        }
        protected void enter_Click(object sender, EventArgs e)
        { 
            MemberBL bl = new MemberBL();
            if (bl.setPassword(FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5"), Request.QueryString["v"].ToString()) > 0)
            {
                Response.Write("<script>alert('密碼修改成功。');location.href(../index.aspx);</script>");
            }
            else
            {
                Response.Write("<script>alert('密碼修改失敗，請重新輸入。');");
            }
        }
    }
}