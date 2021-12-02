using System;
using ERPsystem.DB;

namespace ERPsystem
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var model = PurchaseDB.ProductRow();

                this.ProductList.DataSource = model;
                this.ProductList.DataBind();
            }
        }
    }
}