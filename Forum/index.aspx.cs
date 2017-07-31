using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;


namespace iFourms.Forum
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                fastcontent.Enabled = true;
                fastbutton.Enabled = true;
                fasttitle.Enabled = true;
                Panel1.Visible = false;
                
            }
            else
            {
                fastcontent.Enabled = false;
                fastbutton.Enabled = false;
                fasttitle.Enabled = false;
            }
            string current_page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"];
         
            ForumBL bl = new ForumBL();
            articleGrid.DataSource = bl._getArticleData(current_page);
            articleGrid.DataBind();
            Label1.Text = bl._getArticleCount().ToString();        
            
            Page p = new Page();
            p.getIndexPage(page_panel, bl._getArticleCount(), 10, Convert.ToInt32(current_page), "index.aspx?page={0}");

        }
        protected void fastbutton_Click(object sender, EventArgs e)
        {
            ForumBL bl = new ForumBL();
            if(bl._insertArticle(Request.Cookies[HttpContext.Current.User.Identity.Name].Values["id"].ToString(),fasttitle.Text,fastdrop.SelectedItem.Value,fastcontent.Text)>0)
            {
                Response.Write("<script>alert('發文成功!');location.replace('index.aspx');</script>");
                
            }
        }
        protected void articleGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ForumBL bl = new ForumBL();
            ForumBL bl1 = new ForumBL();
            ForumBL bl2 = new ForumBL();
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string aid = ((Label)e.Row.Cells[0].FindControl("aid")).Text;
                ((Label)e.Row.Cells[3].FindControl("reply")).Text = bl._getMessageCount(aid).ToString();

                ((HyperLink)e.Row.Cells[4].FindControl("replyuser")).Text = bl2._get_LastMessage(aid);
                ((HyperLink)e.Row.Cells[4].FindControl("replyuser")).NavigateUrl = "~/Forum/articledetail.aspx?aid=" + aid +"#pb";
                if (string.IsNullOrEmpty(((HyperLink)e.Row.Cells[4].FindControl("replyuser")).Text))
                {
                    ((HyperLink)e.Row.Cells[4].FindControl("replyuser")).Text = ((HyperLink)e.Row.Cells[2].FindControl("username")).Text + "<br/>" + ((Label)e.Row.Cells[2].FindControl("createtime")).Text;
                    ((HyperLink)e.Row.Cells[4].FindControl("replyuser")).NavigateUrl = "~/Forum/articledetail.aspx?aid=" + aid +"#pb";
                }               
            } 
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(search.Text))
            {
                Response.Write("<script>alert('請輸入查詢字串!');</script>");
            }
            else
            {
                Response.Redirect("~/Forum/search.aspx?q=" + search.Text);
            }
        }

    }
}