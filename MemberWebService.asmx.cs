using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;


namespace iFourms
{
    /// <summary>
    /// MemberWebService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class MemberWebService : System.Web.Services.WebService
    {
        [WebMethod]    
        public string check_username(string username)
        {
            MemberBL bl = new MemberBL();
            string message = string.Empty;

            if (bl._checkUsername(username) == true)
            {
                message = "帳號已經使用過!";
            }
            else
            {
                message = "帳號尚未使用過!";
            }
            return message;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<string> getSearchTitle(string articletitle)
        {
            ForumBL bl = new ForumBL();
            return bl._getSearch(articletitle);
        }
    }
}