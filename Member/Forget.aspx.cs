using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;

namespace iFourms.Member
{
    public partial class Forget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MemberBL bl = new MemberBL();
            if (bl.ForgetPassword(AntiXss.HtmlEncode(Username.Text), Email.Text) > 0)
            {
                Response.Write("<script>alert('已將新密碼設定送到您的信箱!');location.href='index.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('您輸入資料有誤請重新輸入!');</script>");
            }
        }
    }
}