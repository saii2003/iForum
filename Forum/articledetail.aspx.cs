using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Forum
{
    public partial class articledetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["aid"] == null)
            {
                Response.Redirect("~/Forum/index.aspx");
            }
            else
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                }
                string aid = Request.QueryString["aid"].ToString();
                string current_page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"];

                if (Convert.ToInt32(current_page) > 1)
                {
                    panel.Visible = false;
                }
                else
                {
                    panel.Visible = true;
                }

                ForumBL bl = new ForumBL();
                DetailsView1.DataSource = bl._getProfileDetail(Request.QueryString["aid"].ToString());
                DetailsView1.DataBind();

                ForumBL bl1 = new ForumBL();
                DetailsView2.DataSource = bl1._getProfileDetail((Request.QueryString["aid"].ToString()));
                DetailsView2.DataBind();

                ForumBL bl2 = new ForumBL();
                DetailsView3.DataSource = bl2._getProfileDetail((Request.QueryString["aid"].ToString()));
                DetailsView3.DataBind();

                ForumBL bl3 = new ForumBL();
                Label mid = (Label)DetailsView1.FindControl("mid");
                Label icount = (Label)DetailsView1.FindControl("icount");
                icount.Text = bl3._getM_ArticleCount(mid.Text.ToString()).ToString();

                ForumBL bl4 = new ForumBL();
                Page p = new Page();
                DataList1.DataSource = bl4._getMessageDetail(aid, current_page);
                DataList1.DataBind();

                ForumBL bl5 = new ForumBL();
                int count = Convert.ToInt32(bl5._getMessageCount(Request.QueryString["aid"].ToString()));

                ForumBL bl6 = new ForumBL();
                //設定樓數
                int i = 2;
                for (int j = 0; j < DataList1.Items.Count; j++)
                {

                    int f = (Convert.ToInt32(current_page) - 1) * 10 + i;
                    ((Label)DataList1.Items[j].FindControl("Label12")).Text = f.ToString() + "樓";
                        
                    i++;
                    string id = ((Label)DataList1.Items[j].FindControl("Label6")).Text;
                    ((Label)DataList1.Items[j].FindControl("Label8")).Text = bl._getM_ArticleCount(id).ToString();

                }

                p.getPage(page_panel, bl._getMessageCount(aid), 10, Convert.ToInt32(current_page), "~/Forum/articledetail.aspx?aid={0}&page={1}", aid);
            }
            
        }
        protected void fastbutton_Click(object sender, EventArgs e)
        {
            ForumBL bl = new ForumBL();  
            HttpCookie cookie = Request.Cookies[HttpContext.Current.User.Identity.Name];
            string current_page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"];
            if (bl._insertMessage(Request.QueryString["aid"].ToString(), cookie.Values["id"],fastcontent.Text, HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString()) > 0)
            {
                Response.Write("<script>alert('回覆成功!');location.replace('articledetail.aspx?aid=" + Request.QueryString["aid"] + "&page=" + current_page + "');</script>");
            }
        }
        protected void rbutton_Click(object sender, EventArgs e)
        {
            rbutton.PostBackUrl = "~/Forum/reply.aspx?aid=" + Request.QueryString["aid"].ToString();
        }
    }
}