using ERPsystem.DB;
using System.Text.RegularExpressions;
using System.Web;

namespace ERPsystem.LoginManager
{
    public class DetailHelp
    {
        public static string checkPurchase_ID(string Purchase_ID)
        {
            string label;

            if (Purchase_ID == null || Purchase_ID.Length == 0)
                label = "單據編號不能為空";
            else if (Purchase_ID.Length != 8 || !Regex.IsMatch(Purchase_ID, @"^ASN[-]{1}[0-9]{4}$"))
                label = "單據編號格式不正確";
            else if (HttpContext.Current.Request.QueryString["Purchase_ID"] == null && PurchaseManager.PurchaseCheck(Purchase_ID) != null)
                label = "進貨單號重覆，請再確認後修改";
            else
                label = string.Empty;
            return label;
        }
    }
}