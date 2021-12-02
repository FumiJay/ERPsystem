using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ERPsystem.DB
{
    public class DBbase
    {
        public const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=ERP;Integrated Security=true";

        public static DataTable GetDataTable(string dbCommand, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(dbCommand, connection);
                command.Parameters.AddRange(parameters.ToArray());

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();

                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public object GetScale(string dbCommand, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(dbCommand, connection);

                List<SqlParameter> parameters2 = new List<SqlParameter>();
                foreach (var item in parameters)
                {
                    parameters2.Add(new SqlParameter(item.ParameterName, item.Value));
                }

                command.Parameters.AddRange(parameters2.ToArray());

                try
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static int ExecuteNonQuery(string dbCommand, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(dbCommand, connection);

                List<SqlParameter> parameters2 = new List<SqlParameter>();
                foreach (var item in parameters)
                {
                    parameters2.Add(new SqlParameter(item.ParameterName, item.Value));
                }

                command.Parameters.AddRange(parameters2.ToArray());

                connection.Open();
                SqlTransaction sqlTransaction = connection.BeginTransaction();
                command.Transaction = sqlTransaction;

                try
                {
                    int totalChange = command.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    return totalChange;

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();

                    throw;
                }
            }
        }
    }
}