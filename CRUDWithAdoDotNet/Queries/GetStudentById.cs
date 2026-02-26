using CRUDWithAdoDotNet.Models;
using CRUDWithAdoDotNet.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUDWithAdoDotNet.Queries;

internal class GetStudentById
{
    public static Student Run(string connectionString)
    {
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();

        var students = new List<Student>();
        string query = "SELECT * FROM tblStudents WHERE Id = @Id";

        var service = new AdoDotNetService();
        var dataTable = service.Get(query, new SqlParameter("@Id", id));

        foreach (DataRow row in dataTable.Rows)
        {
            DateTime dobDateTime = DateTime.Parse(row["Dob"].ToString());
            DateOnly dob = DateOnly.FromDateTime(dobDateTime);

            students.Add(new()
            {
                Id = row["Id"].ToString()!,
                Name = row["Name"].ToString()!,
                Email = row["Email"].ToString()!,
                Dob = dob
            });
        }
        return students.FirstOrDefault();
    }
}
