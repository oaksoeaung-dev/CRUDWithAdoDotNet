using CRUDWithAdoDotNet.Models;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Queries;

internal class GetAllStudents
{
    public static List<Student> Run(string connectionString)
    {
        var students = new List<Student>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM tblStudents";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dobDateTime = DateTime.Parse(reader["Dob"].ToString());
                DateOnly dob = DateOnly.FromDateTime(dobDateTime);

                students.Add(new()
                {
                    Id = reader["Id"].ToString()!,
                    Name = reader["Name"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Dob = dob
                });

            }
            return students;
        }
    }
}
