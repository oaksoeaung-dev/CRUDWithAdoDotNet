using CRUDWithAdoDotNet.Services;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Command;

internal class DeleteStudent
{
    public static void Run()
    {
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();

        string query = "DELETE FROM tblStudents WHERE Id=@Id";

        var service = new AdoDotNetService();

        var result = service.Set(query,
            new SqlParameter("@Id", id)
            );

        if (result > 0)
        {
            Console.WriteLine("\nStudent Deleted Successfully!\n");
        }
        else
        {
            Console.WriteLine("\nStudent Not Found.\n");
        }
    }
}
