using Microsoft.Data.SqlClient;
using System.Data;

namespace HMDB
{
    internal class DatabaseConnection
    {
        public SqlConnection getConnection()
        { 
            String connectionString = "Server=localhost\\SQLEXPRESS;Database=HMDB;User Id=ZZZZ;Password=Zzzzzzz1;TrustServerCertificate=True;"; 
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
         
        public DataSet getData(String query)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connection.Close();
            return ds;
        }

        public void setData(String query, String message)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            connection.Close(); 
        }
    }
}
