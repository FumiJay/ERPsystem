using System;
using ERPsystem.LoginManager;

namespace ERPsystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginHelper.Haslogined())
            {
                string targetUrl = "~/Purchase.aspx?User=" + LoginHelper.GetUserName();

                Response.Redirect(targetUrl);  //如果已登入跳轉至首頁
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string account = this.Accouunt.Text;
            string passowrd = this.password.Text;

            bool logined = LoginHelper.tryLogin(account, passowrd);

            if (logined)
            {
                string targetUrl = "~/Purchase.aspx?User=" + LoginHelper.GetUserName();

                Response.Redirect(targetUrl);
            }
            else
            {
                Response.Write("<script>alert('帳號或密碼錯誤，請重新登入!')</script>");
            }
        }
    }
}