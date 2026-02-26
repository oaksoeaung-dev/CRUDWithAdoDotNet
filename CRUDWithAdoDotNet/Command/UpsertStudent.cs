using CRUDWithAdoDotNet.Models;
using CRUDWithAdoDotNet.Services;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Command;

internal class UpsertStudent
{
    public static void Run(string id = null)
    {

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter date of birth [MM/DD/YYYY]: ");
        string dob = Console.ReadLine();


        var service = new AdoDotNetService();

        string createQuery = "INSERT INTO tblStudents (Id, Name, Email, Dob) VALUES (@Id, @Name, @Email, @Dob)";
        string updateQuery = "UPDATE tblStudents SET Name = @Name, Email = @Email, Dob = @Dob WHERE Id = @Id";

        Student student;

        if (id != null)
        {
            student = Student.Update(id, name, email, dob);

        }
        else
        {
            student = Student.Create(name, email, dob);
        }

        var result = service.Set(id != null ? updateQuery : createQuery,
            new SqlParameter("@Id", student.Id),
            new SqlParameter("@Name", student.Name),
            new SqlParameter("@Email", student.Email),
            new SqlParameter("@Dob", student.Dob)
            );

        if (result > 0)
        {
            Console.WriteLine("\nSuccess!\n");
        }
        else
        {
            Console.WriteLine("\nFail!\n");
        }
    }
}
