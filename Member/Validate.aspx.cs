using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iFourms;

namespace iFourms.Member
{
    public partial class Validate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MemberBL bl = new MemberBL();
                if (Request.QueryString["v"] != null)
                {
                    if (bl.Validate(Request.QueryString["v"].ToString()) > 0)
                    {
                        Response.Write("<script>alert('帳號驗證成功!');</script>");
                    }
                }
                else
                {
                    Response.Redirect("../index.aspx");
                }
            }

        }
    }
}