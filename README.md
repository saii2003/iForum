# iForum目錄檔案說明

![index text](https://saii2003.github.io/Introduction/intro_forum/image/1.jpg)

<pre><code>使用技術及系統</code></pre>
- 網路空間：somee.com
- 系統：Windows 2012 IIS8
- 後端技術：ASP.NET C#
- 前端技術：HTML、CSS、jQuery
- 資料庫：MSSQL 2008
- 架構：Web Form

<pre><code>### App_Code</code></pre>
- DBbase.cs ：資料庫連線基本設定
- ForumBL.ce ：論壇頁面的商業邏輯
- ForumDA.cs ：論壇頁面的資料存取
- ForumBL.ce ：會員頁面的商業邏輯
- ForumDA.cs ：會員頁面的資料存取
- Page.cs :分頁

<pre><code>### Forum</code></pre>
- articledetail.aspx ：論壇文章內容頁面
- index.aspx ：論壇首頁
- profile.aspx ：個人頁面
- reply.aspx ：文章回覆頁面
- search.aspx ：文章查詢頁面

<pre><code>### Member</code></pre>
- Forget.aspx ：忘記密碼首頁
- Register.aspx ：註冊首頁
- Validate.aspx ：驗證碼
- changepw.aspx ：更變密碼首頁
- iAarticle.aspx ：個人文章首頁
- login.aspx ：登入首頁
- myself.aspx ：個人資料首頁
- new_pw.aspx ：取得新密碼
- profile.aspx ：個人檔案
- updateicon.aspx ：上傳icon

<pre><code>### root</code></pre>
- MemberMaster.Master ：會員主版頁面
- iForumsMaster.Master ：論壇主版頁面
- validcode.aspx ：驗證碼
