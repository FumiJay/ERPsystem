using ERPsystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ERPsystem.DB
{
    public class PurchaseManager
    {
        #region InsertPurchase

        public static void TakeOrder(List<PurChaseModel> model)
        {
            string queryString =
                $@" INSERT INTO PurchaseDetail
                    (Purchase_ID,Product_ID,Product_Quantity,Purchase_Class,ArriveTime,Isdelete)
                    VALUES
                    (@Purchase_ID,@Product_ID,@Product_Quantity,Purchase_Class,@ArriveTime,@Isdelete)
                  ";

            foreach (var item in model)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter ("@Purchase_ID",item.Purchase_ID),
                    new SqlParameter ("@Product_ID",item.Product_ID),
                    new SqlParameter ("@Product_Quantity",item.Product_Quantity),
                    new SqlParameter ("@Purchase_Class",item.Purchase_Class),
                    new SqlParameter ("@ArriveTime",item.ArriveTime),
                    new SqlParameter ("@Isdelete",false)
                };

                DBbase.ExecuteNonQuery(queryString, parameters);
            }
        }

        #endregion

        #region Purchase_IDCheck
        public static PurChaseModel PurchaseCheck(string Purchase_ID)
        {
            string queryString = $@"SELECT Purchase_ID 
                                    FROM [PurchaseDetail]
                                    WHERE Purchase_ID = @Purchase_ID AND Isdelete = 'false'
                                   ";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
               new SqlParameter("@Purchase_ID", Purchase_ID)
            };

            PurChaseModel model = null;
            var dt = DBbase.GetDataTable(queryString, parameters);

            if (dt.Rows.Count != 0)
            {
                model = new PurChaseModel();
                model.Purchase_ID = (string)dt.Rows[0]["Purchase_ID"];
            }
            return model;
        }

        #endregion

        #region 刪除
        public static DataTable Delete(string Purchase_ID)
        {
            string queryString =
                $@" 
                    UPDATE [PurchaseDetail]
                    SET Isdelete = @Isdelete
                    WHERE Purchase_ID = @Purchase_ID
                  ";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Purchase_ID", Purchase_ID),
                new SqlParameter("@Isdelete", true)
            };

            var dt = DBbase.GetDataTable(queryString, parameters);
            return dt;
        }
        #endregion

        #region 資料庫連動下拉式選單

        public const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=ERP;Integrated Security=true";

        public static void ProductList(ref DropDownList Productlist)
        {
            string queryString = $@"SELECT Product_ID,Product_Name,Price,CONCAT(Product_ID,',',Product_Name,',',Price) AS 'BBB'
                                    FROM ProductList";

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Productlist.DataSource = dt;
                        Productlist.DataTextField = "Product_Name";
                        Productlist.DataValueField = "BBB";
                        Productlist.DataBind();

                        Productlist.Items.Insert(0, "請選擇");
                        Productlist.SelectedIndex = 0;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion
    }
}