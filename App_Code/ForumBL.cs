using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Forum商業邏輯
/// </summary>

namespace iFourms
{
    public class ForumBL
    {
        #region 取的Article Data
        public DataTable _getArticleData(string current_page)
        {
            ForumDA da = new ForumDA();
            return da.getArticleData(current_page);
        }
        #endregion

        #region 取得發文者資料
        public DataTable _getProfileDetail(string aid)
        {
            ForumDA da = new ForumDA();
            return da.getProfileDetail(aid);

        }
        #endregion

        #region 取的總文章數
        public int _getArticleCount()
        {
            ForumDA da = new ForumDA();
            return da.getArticleCount();

        }
        #endregion

        #region 取的回覆數
        public int _getMessageCount(string aid)
        {
            ForumDA da = new ForumDA();
            return da.getMessageCount(aid);

        }
        #endregion

        #region 新增文章
        public int _insertArticle(string mid,string title, string classID, string contents)
        {
            ForumDA da = new ForumDA();
            return da.insertArticle(mid, title, classID, DateTime.Now,HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(), contents, 0);

        }
        #endregion


        #region 取的留言資料
        public DataTable _getMessageDetail(string aid, string current_page)
        {
            ForumDA da = new ForumDA();

            return da.getMessageDetail(aid, current_page);

        }
        #endregion

        #region 取得個人文章數
        public int _getM_ArticleCount(string mid)
        {
            ForumDA da = new ForumDA();
            return da.getM_ArticleCount(mid);

        }
        #endregion

        #region 取得最後回覆
        public string _get_LastMessage(string aid)
        {
            ForumDA da = new ForumDA();
            return da.get_LastMessage(aid);

        }
        #endregion

        #region 新增回文
        public int _insertMessage(string a_ID, string m_ID, string contents, string createIP)
        {
            ForumDA da = new ForumDA();
            return da.insertMessage(a_ID, m_ID, contents, createIP);

        }
        #endregion

        #region 取得個人資訊
        public DataTable _getprofile(string mid)
        {
            ForumDA da = new ForumDA();
            return da.getprofile(mid);

        }
        #endregion

        #region 取得個人文章
        public DataTable _getSelfArticle(string mid)
        {
            ForumDA da = new ForumDA();
            return da.getSelfArticle(mid);
        }
        #endregion

        #region 搜尋文章
        public DataTable _searchArticle(string title, string current_page)
        {
            ForumDA da = new ForumDA();
            return da.searchArticle(title, current_page);
        }
        #endregion

        #region autocomplete搜尋文章
        public List<string> _getSearch(string title)
        {
            ForumDA da = new ForumDA();
            return da.getSearch(title);
        }
        #endregion
















        #region 分頁
        public void getPage(Panel panel,decimal total_data,decimal page_size,decimal current_page,string url,string aid)
        {
            /* panel 存放分頁
             * total_data 全部資料
             * page_size 一頁顯示幾筆資料
             * current_page 目前所在頁面
             * url 超連結
             * aid 文章id */
     
            decimal total_page = total_data / page_size;//共有多少分頁數

            if (current_page > 1)
            {
                //第一頁
                LinkButton first = new LinkButton();
                first.Text = "第一頁";
                first.CssClass = "first";
                first.PostBackUrl = string.Format(url, aid, "1");
                panel.Controls.Add(first);

                //上一頁
                LinkButton pre = new LinkButton();
                pre.Text = "上一頁";
                pre.CssClass = "pre";
                pre.PostBackUrl = string.Format(url, aid, current_page - 1);
                panel.Controls.Add(pre);
            }

            if (total_data <= page_size)
            {
                total_page = 1;
            }
            else
            {
                if (total_page > Math.Truncate(total_page))
                {
                    total_page = Math.Truncate(total_page) + 1;
                }
                else
                {
                    total_page = total_data / page_size;
                }
            }

            decimal view_page = current_page / 10; //一次顯示10個分頁數

            if (view_page <= 1)
            {
                view_page = 1;
            }
            else
            {
                if (view_page > Math.Truncate(view_page))
                {
                    view_page = Math.Truncate(view_page) + 1;
                }
                else
                {
                    view_page = current_page / 10;
                }
            }

            for (int i = Convert.ToInt32(view_page); i <= Convert.ToInt32(view_page); i++)
            {
                if (current_page <= total_page)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        if (((i - 1) * 10) + j <= total_page)
                        {
                            LinkButton num = new LinkButton();
                            num.ID = "num" + (((i - 1) * 10) + j).ToString();
                            num.CssClass = "num";
                            if (Convert.ToString((((i - 1) * 10) + j)) == current_page.ToString())
                            {
                                num.CssClass = "current_num";
                            }
                            num.Text = (((i - 1) * 10) + j).ToString();
                            num.PostBackUrl = string.Format(url, aid, (((i - 1) * 10) + j).ToString());
                            panel.Controls.Add(num);
                        }
                    }
                }
            
            }

            if (current_page < total_page)
            {
                LinkButton next = new LinkButton();
                next.Text = "下一頁";
                next.CssClass = "next";
                next.PostBackUrl = string.Format(url, aid, current_page + 1);
                panel.Controls.Add(next);

                //分頁最後一頁
                LinkButton last = new LinkButton();
                last.Text = "最後一頁";
                last.CssClass = "last";
                last.PostBackUrl = string.Format(url, aid, total_page);
                panel.Controls.Add(last);
            }
        }
        #endregion
    }
}