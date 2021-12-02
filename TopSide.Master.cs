using System;
using System.Web;
using ERPsystem.LoginManager;

namespace ERPsystem
{
    public partial class TopSide : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginHelper.Haslogined())
            {
                this.LoginInfo.Text = "歡迎 : " + HttpContext.Current.Session["Account"] as string;
                this.Login.Visible = false;
                this.Logout.Visible = true;
                this.Product.Visible = true;

                if (Convert.ToInt32(HttpContext.Current.Session["Level"]) <= 1)
                {
                    this.Purchase.Visible = true;
                }
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect("Purchase.aspx");
        }
    }
}