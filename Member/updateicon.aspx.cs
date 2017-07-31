using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace iFourms.Member
{
    public partial class updateicon : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            MemberBL bl = new MemberBL();
            bl.upload_Icon(fileupdate, HttpContext.Current.User.Identity.Name.ToString());

        }
    }
}