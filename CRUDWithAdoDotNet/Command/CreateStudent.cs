using CRUDWithAdoDotNet.Models;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Command;

internal class CreateStudent
{
    public static void Run(string connectionString)
    {

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter date of birth [MM/DD/YYYY]: ");
        string dob = Console.ReadLine();



        using (SqlConnection conn = new SqlConnection(connectionString))
        {

            string createQuery = "INSERT INTO tblStudents (Id, Name, Email, Dob) VALUES (@Id, @Name, @Email, @Dob)";

            SqlCommand cmd = new SqlCommand(createQuery, conn);

            var newStudent = Student.Create(name, email, dob);
            cmd.Parameters.AddWithValue("@Id", newStudent.Id);
            cmd.Parameters.AddWithValue("@Name", newStudent.Name);
            cmd.Parameters.AddWithValue("@Email", newStudent.Email);
            cmd.Parameters.AddWithValue("@Dob", newStudent.Dob);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                Console.WriteLine("\nStudent Created Successfully!\n");
            }
            else
            {
                Console.WriteLine("\nStudent Cannot Create!\n");
            }
        }

    }
}
