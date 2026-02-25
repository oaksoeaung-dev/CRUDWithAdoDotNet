using CRUDWithAdoDotNet.Models;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Queries;

internal class GetStudentById
{
    public static Student Run(string connectionString)
    {
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM tblStudents WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DateTime dobDateTime = DateTime.Parse(reader["Dob"].ToString());
                DateOnly dob = DateOnly.FromDateTime(dobDateTime);

                return new()
                {
                    Id = reader["Id"].ToString()!,
                    Name = reader["Name"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Dob = dob
                };

            }
            return null;
        }
    }
}
