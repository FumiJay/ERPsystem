using System.Data;
using System.Web;

namespace ERPsystem.LoginManager
{
    public class LoginHelper
    {
        private const string _SessionKey = "Logined";
        private const string _SessionAccount = "Account";
        private const string _SessionSid = "Staff_ID";
        private const string _sessionLevel = "Staff_Level";

        public static bool Haslogined()
        {
            bool? val = HttpContext.Current.Session[_SessionKey] as bool?;

            if (val.HasValue && val.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool tryLogin(string Account, string Password)
        {
            if (Haslogined())
            {
                return true;
            }

            DataTable dt = DBAccount.AccountCheck(Account);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            string DBpwd = dt.Rows[0].Field<string>("Password");
            string DBName = dt.Rows[0].Field<string>("Staff_Name");
            string DBsid = dt.Rows[0].Field<int>("Staff_ID").ToString();
            string Level = dt.Rows[0].Field<int>("Staff_Level").ToString();

            bool isPasswordRight = string.Compare(DBpwd, Password.Trim()) == 0;

            if (isPasswordRight)
            {
                HttpContext.Current.Session[_SessionKey] = true;
                HttpContext.Current.Session[_SessionAccount] = DBName;
                HttpContext.Current.Session[_SessionSid] = DBsid;
                HttpContext.Current.Session[_sessionLevel] = Level;

                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Logout()
        {
            if (!Haslogined())
            {
                return;
            }
            else
            {
                HttpContext.Current.Session.Remove(_SessionKey);
                HttpContext.Current.Session.Remove(_SessionAccount);
                HttpContext.Current.Session.Remove(_SessionSid);
                HttpContext.Current.Session.Remove(_sessionLevel);
            }
        }
        public static string GetUserName()
        {
            if (!Haslogined())
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session[_SessionAccount] as string;
            }
        }
    }
}