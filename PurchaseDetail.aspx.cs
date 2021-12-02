using System;
using ERPsystem.Models;
using ERPsystem.DB;
using System.Collections.Generic;
using ERPsystem.LoginManager;
using System.Linq;
using System.Data;

namespace ERPsystem
{
    public partial class PurchaseDetail : System.Web.UI.Page
    {
        static int TotalPrice = 0;
        static List<PurChaseModel> PurchaseTemp = new List<PurChaseModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoginHelper.Haslogined())
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                var model = PurchaseDB.ProductRow();

                this.Product_List.DataSource = model;
                this.Product_List.DataBind();

                PurchaseManager.ProductList(ref ProducrSelect);
            }
            else
            {
                if (this.PurchaseID.Text == string.Empty || this.dateinpu.Text == string.Empty)
                {
                    Response.Write("<script>alert('進貨編號和到貨日期必須先行輸入才可輸入商品')</script>");
                }
            }
            this.ErrMess.Text = string.Empty;
        }

        #region UpdateMode
        //private bool IsUpdateMode() //檢驗是否為更新模式
        //{
        //    string qsID = Request.QueryString["Purchase_ID"]; //抓取網址的QueryString["Purchase_ID"]

        //    if (!string.IsNullOrEmpty(qsID))
        //    {
        //        DataTable model = PurchaseDB.PurchaseDetail(qsID);
        //        List<PurChaseModel> PurChaseModels = new List<PurChaseModel>();

        //        foreach (DataRow item in model.Rows)
        //        {
        //            TotalPrice += Convert.ToInt32(item["Product_Quantity"]) * Convert.ToInt32(item["Price"]);

        //            PurChaseModel PurChasemm = new PurChaseModel();
        //            PurChasemm.Product_ID = item["Product_ID"].ToString();
        //            PurChasemm.Product_Name = item["Product_Name"].ToString();
        //            PurChasemm.Product_Quantity += Convert.ToInt32(item["Product_Quantity"]);
        //            PurChasemm.Price = Convert.ToDecimal(item["Price"]);
        //            PurChaseModels.Add(PurChasemm);

        //            this.PurchaseID.Text = item["Purchase_ID"].ToString();
        //            this.dateinpu.Text = Convert.ToDateTime(item["ArriveTime"]).ToString("yyyy-MM-dd");


        //            if (model == null)
        //                Response.Redirect("Purchase.aspx");

        //            this.Purchase_Detail.DataSource = PurChaseModels;
        //            this.Purchase_Detail.DataBind();
        //            this.Price.Text = $"總金額:{TotalPrice}元";
        //        }
        //        return true; //過的話把TRUE回傳給這函式
        //    }
        //    return false; //沒過回傳false
        //}
        #endregion

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            var Qty = this.ProductQTY.Text;
            var Price = this.ProducrSelect.Text;

            int Number;
            if (Qty == null || !int.TryParse(Qty, out Number))
            {
                this.ErrMess.Text = "進貨數量欄位不能為空或不是數字";
            }
            else if (Price == "請選擇")
            {
                this.ErrMess.Text = "進貨商品欄位不能為空";
            }
            else
            {
                PurChaseModel TempPurchase = new PurChaseModel();
                string[] product = this.ProducrSelect.SelectedValue.Split(',');
                TotalPrice += Convert.ToInt32(product[2]) * Convert.ToInt32(Qty);

                TempPurchase.Purchase_ID = this.PurchaseID.Text;
                TempPurchase.ArriveTime = Convert.ToDateTime(this.dateinpu.Text.Trim());
                TempPurchase.Product_ID = product[0];
                TempPurchase.Product_Name = product[1];
                TempPurchase.Price = Convert.ToDecimal(product[2]);
                TempPurchase.Product_Quantity = Convert.ToInt32(Qty);
                TempPurchase.Purchase_Price = TotalPrice;

                PurchaseTemp.Add(TempPurchase);

                var Query = from item in PurchaseTemp
                            group item by new { item.Product_ID, item.Product_Name, item.Price } into Purchase_Class
                            select new
                            {
                                Product_ID = Purchase_Class.Key.Product_ID,
                                Product_Name = Purchase_Class.Key.Product_Name,
                                Price = Purchase_Class.Key.Price,
                                Product_Quantity = Purchase_Class.Sum(X => X.Product_Quantity)
                            };

                this.Purchase_Detail.DataSource = Query.ToList();
                this.Purchase_Detail.DataBind();

                this.Price.Text = $"總金額為:{TotalPrice}元";

            }
        }
        protected void Insert_btn_Click(object sender, EventArgs e)
        {
            //案件標號正規化
            string IupuPurchase_ID = this.PurchaseID.Text;
            this.ErrMess.Text = DetailHelp.checkPurchase_ID(IupuPurchase_ID);

            if (this.ErrMess.Text == string.Empty)
            {
                var Query = from item in PurchaseTemp
                            group item by new { item.Purchase_ID, item.ArriveTime, item.Product_ID, item.Product_Name} into Purchase_Class
                            select new
                            {
                                Purchase_ID = Purchase_Class.Key.Purchase_ID,
                                Product_ID = Purchase_Class.Key.Product_ID,
                                Product_Name = Purchase_Class.Key.Product_Name,
                                Price = Purchase_Class.Sum(X => X.Price * X.Product_Quantity),
                                ArriveTime = Purchase_Class.Key.ArriveTime,
                                Product_Quantity = Purchase_Class.Sum(X => X.Product_Quantity),
                                Purchase_Class = Purchase_Class.Key.Product_ID.Count()
                            };

                using (var context = new DBModels.DBModel())
                {
                    foreach (var item in Query)
                    {
                        var NewOder = new DBModels.PurchaseDetail()
                        {
                            Purchase_ID = item.Purchase_ID,
                            ArriveTime = (DateTime)item.ArriveTime,
                            Product_ID = item.Product_ID,
                            Product_Quantity = item.Product_Quantity,
                            Purchase_Class = item.Purchase_Class,
                            Isdelete = false
                        };

                        context.PurchaseDetails.Add(NewOder);
                    }
                    context.SaveChanges();
                    PurchaseTemp.Clear();
                }

                Response.Redirect("Purchase.aspx");
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            PurchaseTemp.Clear();
            TotalPrice = 0;
            this.Price.Text = $"總金額為:{TotalPrice}元";

            this.Purchase_Detail.DataSource = PurchaseTemp;
            this.Purchase_Detail.DataBind();
        }
    }
}