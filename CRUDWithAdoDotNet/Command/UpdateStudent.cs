using CRUDWithAdoDotNet.Models;
using Microsoft.Data.SqlClient;

namespace CRUDWithAdoDotNet.Command;

internal class UpdateStudent
{
    public static void Run(string connectionString)
    {
        Console.Write("Enter Id: ");
        string id = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter date of birth [MM/DD/YYYY]: ");
        string dob = Console.ReadLine();



        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string updateQuery = "UPDATE tblStudents SET Name = @Name, Email = @Email, Dob = @Dob WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(updateQuery, conn);

            var updateStudent = Student.Update(id, name, email, dob);
            cmd.Parameters.AddWithValue("@Id", updateStudent.Id);
            cmd.Parameters.AddWithValue("@Name", updateStudent.Name);
            cmd.Parameters.AddWithValue("@Email", updateStudent.Email);
            cmd.Parameters.AddWithValue("@Dob", updateStudent.Dob);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                Console.WriteLine("\nStudent Updated Successfully!\n");
            }
            else
            {
                Console.WriteLine("\nStudent Not Found.!\n");
            }
        }

    }
}
