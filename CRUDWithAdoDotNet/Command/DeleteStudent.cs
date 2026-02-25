using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Command;

internal class DeleteStudent
{
    public static void Run(string connectionString)
    {
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM tblStudents WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("\nStudent Deleted Successfully!\n");
            else
                Console.WriteLine("\nStudent Not Found.\n");
        }
    }
}
