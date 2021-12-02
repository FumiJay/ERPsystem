using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ERPsystem.Models;

namespace ERPsystem.DB
{
    public class PurchaseDB : DBbase
    {
        public new const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=ERP;Integrated Security=true";

        public List<PurChaseModel> ViewGroup( out int totalSize, int currentSize = 1, int pageSize = 8)
        {
            string Query =
                $@"
                    SELECT TOP {8} * FROM
                    (
                    SELECT 
                    [PurchaseDetail].Purchase_ID
                    , COUNT([ProductList].Product_Class) AS 'Purchase_Class'
                    ,SUM([PurchaseDetail].Product_Quantity) AS 'Purchase_Quantity'
                    ,[PurchaseDetail].ArriveTime AS 'ArriveTime'
                    ,SUM([ProductList].Price * [PurchaseDetail].Product_Quantity) AS 'Purchase_Price'
                    ,ROW_NUMBER() OVER(ORDER BY[PurchaseDetail].Purchase_ID DESC) AS ROWNUM
                    ,[PurchaseDetail].Isdelete
                    FROM[PurchaseDetail]
                    JOIN[ProductList] ON[PurchaseDetail].Product_ID = [ProductList].Product_ID
                    WHERE [PurchaseDetail].Isdelete = 'false'
                    GROUP BY[PurchaseDetail].Purchase_ID,[PurchaseDetail].ArriveTime,[PurchaseDetail].Isdelete
                    ) a
                    WHERE ROWNUM > {pageSize * (currentSize - 1)}";

            string countQuery =
                $@"
                    SELECT 
                        COUNT (Purchase_ID)
                    FROM PurchaseDetail
                ";

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            var dt = DBbase.GetDataTable(Query, dbParameters);

            List<PurChaseModel> list = new List<PurChaseModel>();

            foreach (DataRow dr in dt.Rows)
            {
                PurChaseModel model = new PurChaseModel();
                model.Purchase_ID = (string)dr["Purchase_ID"];
                model.Purchase_Class = (int)dr["Purchase_Class"];
                model.Product_Quantity = (int)dr["Purchase_Quantity"];
                model.ArriveTime = (DateTime)dr["ArriveTime"];
                model.Purchase_Price = (decimal)dr["Purchase_Price"];

                list.Add(model);
            }

            int? totalSize2 = this.GetScale(countQuery, dbParameters) as int?;
            totalSize = (totalSize2.HasValue) ? totalSize2.Value : 0;

            return list;
        }

        public static DataTable ProductRow()
        {
            string queryString =
                $@" SELECT * FROM ProductList
                    ORDER BY Product_ID;";

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Product_ID", "Product_ID");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}