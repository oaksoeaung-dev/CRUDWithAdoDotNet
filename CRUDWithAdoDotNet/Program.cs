using CRUDWithAdoDotNet.Command;
using CRUDWithAdoDotNet.Queries;

string connectionString = "Server=KONOHA\\SQLEXPRESS;Database=School;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=true";



while (true)
{
    try
    {
        Console.WriteLine("1. Get student by Id");
        Console.WriteLine("2. Get all students");
        Console.WriteLine("3. Create a new student");
        Console.WriteLine("4. Update a student");
        Console.WriteLine("5. Delete a student");
        Console.WriteLine("6. Exit");
        Console.WriteLine();
        Console.Write("Choose option: ");

        var inputOption = Console.ReadKey().KeyChar.ToString();
        Console.WriteLine();

        if (!int.TryParse(inputOption, out int option))
        {
            throw new Exception("Invalid option");
        }

        switch (option)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("\n===== Get Student By Id =====\n");
                var getStudent = GetStudentById.Run(connectionString);
                if (getStudent != null)
                {
                    Console.WriteLine($"\nID: {getStudent.Id} | Name: {getStudent.Name} | Email: {getStudent.Email} | Date of Birth: {getStudent.Dob}\n");
                }
                else
                {
                    Console.WriteLine("\nStudent Not Found!\n");
                }
                Console.WriteLine();
                Console.Write("Press any key to go back to menu!");
                Console.ReadKey();
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("\n===== Get all students =====\n");
                var students = GetAllStudents.Run(connectionString);
                if (students.Count == 0)
                {
                    Console.WriteLine("There is no record.");
                }
                else
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id} | Name: {student.Name} | Email: {student.Email} | Date of Birth: {student.Dob}");
                    }
                }
                Console.WriteLine();
                Console.Write("Press any key to go back to menu!");
                Console.ReadKey();
                Console.Clear();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("\n===== Create a new student =====\n");
                UpsertStudent.Run();
                Console.WriteLine();
                Console.Write("Press any key to go back to menu!");
                Console.ReadKey();
                Console.Clear();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("\n===== Update a student =====\n");

                Console.Write("Enter Id: ");
                string id = Console.ReadLine();

                UpsertStudent.Run(id);
                Console.WriteLine();
                Console.Write("Press any key to go back to menu!");
                Console.ReadKey();
                Console.Clear();
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("\n===== Delete a student =====\n");
                DeleteStudent.Run();
                Console.WriteLine();
                Console.Write("Press any key to go back to menu!");
                Console.ReadKey();
                Console.Clear();
                break;
            case 6:
                Console.Clear();
                Console.WriteLine("\n***** Goodbye! *****\n");
                return;
            default:
                throw new Exception("Invalid option");
        }
    }
    catch (Exception e)
    {
        Console.Clear();
        Console.WriteLine($"Error: {e.Message}\n");
        Console.WriteLine("Try Again!\n");
    }
}