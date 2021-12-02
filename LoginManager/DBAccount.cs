using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace ERPsystem.LoginManager
{
    public class DBAccount
    {
        public static DataTable AccountCheck(string account)
        {
            string connectionstring = "Data Source=localhost\\SQLExpress;Initial Catalog=ERP;Integrated Security=true";

            string querystring = @"SELECT  * from StaffList where Account = @Account;";

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(querystring, con);
                command.Parameters.AddWithValue("@Account", account);

                try
                {
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    reader.Close();

                    return dt;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);

                    return null;
                }
            }
        }
    }
}