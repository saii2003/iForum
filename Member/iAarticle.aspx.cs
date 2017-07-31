using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Member
{
    public partial class iAarticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                MemberBL bl = new MemberBL();
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    iArticleGrid.DataSource = bl._getMemArticle(Request.Cookies[HttpContext.Current.User.Identity.Name.ToString()].Values["id"].ToString());
                    iArticleGrid.DataBind();
                }
                else
                {
                    Response.Redirect("~/Forum/index.aspx");
                }
            }
        }
    }
}