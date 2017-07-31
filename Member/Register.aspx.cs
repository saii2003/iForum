using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.Security.Application;



namespace iFourms.Member
{
    public partial class Register : System.Web.UI.Page
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
                 if (!string.IsNullOrEmpty(Username.Text) && !string.IsNullOrEmpty(Password.Text) && !string.IsNullOrEmpty(rePassword.Text) && !string.IsNullOrEmpty(Nickname.Text) && !string.IsNullOrEmpty(birthday1.Text) && !string.IsNullOrEmpty(Email.Text))
                 {
                     if (AntiXss.HtmlEncode(Password.Text) == AntiXss.HtmlEncode(rePassword.Text))
                     {
                         if (bl.Register(AntiXss.HtmlEncode(Username.Text), AntiXss.HtmlEncode(FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5")), AntiXss.HtmlEncode(Nickname.Text), Gender.SelectedValue.ToString(), Convert.ToDateTime(birthday1.Text), Email.Text) > 0)
                         {
                             Server.Transfer("~/Member/success.aspx");
                         }
                     }
                     else
                     {
                         Response.Write("<script>alert('密碼和確定密碼必須一致!');</script>");
                     }
                 }
                 else
                 {
                     Response.Write("<script>alert('資料填寫不齊全!');</script>");
                 }

                
            

            
        }
    }
}