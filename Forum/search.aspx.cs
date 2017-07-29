using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iFourms.Forum
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["q"] == null)
            {
                Response.Redirect("~/Forum/index.aspx");
            }
            else
            {
                string current_page = Request.QueryString["page"] == null ? "1" : Request.QueryString["page"];
                ForumBL bl = new ForumBL();
                DataList1.DataSource = bl._searchArticle(Request.QueryString["q"].ToString(), current_page);
                DataList1.DataBind();

                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    if (((Label)DataList1.Items[i].FindControl("Label2")).Text.Length > 50)
                    {
                        ((Label)DataList1.Items[i].FindControl("Label2")).Text = ((Label)DataList1.Items[i].FindControl("Label2")).Text.Substring(1, 50) + "....";
                    }
                }
                Label1.Text = DataList1.Items.Count.ToString();

                Page p = new Page();
                p.getIndexPage(page_panel, DataList1.Items.Count, 10, Convert.ToInt32(current_page), "index.aspx?page={0}");
            }
        }

        protected void DataList1_DataBinding(object sender, EventArgs e)
        {

        }
    }
}