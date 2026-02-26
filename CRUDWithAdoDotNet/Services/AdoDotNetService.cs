using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDWithAdoDotNet.Services;

internal class AdoDotNetService
{
    private readonly string connectionString = "Server=KONOHA\\SQLEXPRESS;Database=School;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=true";

    public DataTable Get(string query, params SqlParameter[] sqlParameters)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            if (sqlParameters != null)
                cmd.Parameters.AddRange(sqlParameters);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }

    public int Set(string query, params SqlParameter[] sqlParameters)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);

            if (sqlParameters != null)
                cmd.Parameters.AddRange(sqlParameters);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
