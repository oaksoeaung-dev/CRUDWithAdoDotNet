using CRUDWithAdoDotNet.Models;
using CRUDWithAdoDotNet.Services;
using System.Data;

namespace CRUDWithAdoDotNet.Queries;

internal class GetAllStudents
{
    public static List<Student> Run(string connectionString)
    {
        var students = new List<Student>();
        string query = "SELECT * FROM tblStudents";

        var service = new AdoDotNetService();
        var dataTable = service.Get(query);

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
        return students;
    }
}
