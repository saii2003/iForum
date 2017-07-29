using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Forum
{
    public partial class reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if(Request.QueryString["aid"] == null || HttpContext.Current.User.Identity.IsAuthenticated == false)
                {
                    Response.Redirect("~/Member/login.aspx");
                }
            
        }

        protected void replybutton_Click(object sender, EventArgs e)
        {
            
            ForumBL bl = new ForumBL();

            HttpCookie cookie = Request.Cookies[HttpContext.Current.User.Identity.Name];
            if (bl._insertMessage(Request.QueryString["aid"].ToString(), cookie.Values["id"], HttpUtility.HtmlEncode(re.Text), HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString()) > 0)
            {
                Response.Write("<script>alert('回覆成功!');location.replace('articledetail.aspx?aid=" + Request.QueryString["aid"].ToString() + "');</script>");
            }
            else
            {
                Response.Write("<script>alert('回覆失敗!');</script>");
            }
        }
    }
}