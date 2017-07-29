using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Forum
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mid"] == null)
            {
                Response.Redirect("~/Forum/index.aspx");
            }
            else
            {
                ForumBL bl = new ForumBL();
                DetailsView1.DataSource = bl._getprofile(Request.QueryString["mid"].ToString());
                DetailsView1.DataBind();
               
                ForumBL bl2 = new ForumBL();
                ((Label)DetailsView1.FindControl("count")).Text = bl2._getM_ArticleCount(Request.QueryString["mid"].ToString()).ToString();

                ForumBL bl3 = new ForumBL();
                GridView1.DataSource = bl3._getSelfArticle(Request.QueryString["mid"].ToString());
                GridView1.DataBind();
            }
        }
    }
}