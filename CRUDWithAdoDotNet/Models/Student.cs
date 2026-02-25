using CRUDWithAdoDotNet.Exceptions;
using System.Text.RegularExpressions;

namespace CRUDWithAdoDotNet.Models;

public class Student
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public DateOnly Dob { get; set; }
    public Student()
    {

    }

    public Student(string id, string name, string email, DateOnly dob)
    {
        Id = id;
        Name = name;
        Email = email;
        Dob = dob;
    }

    public Student(string name, string email, DateOnly dob)
    {
        Name = name;
        Email = email;
        Dob = dob;
    }

    public static Student Create(string name, string email, string dob)
    {
        if (string.IsNullOrEmpty(name))
            StudentException.Throw("Name cannot be empty");

        if (string.IsNullOrEmpty(email))
            StudentException.Throw("Email cannot be empty");

        if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.IgnoreCase))
            StudentException.Throw("Invalid email address");

        if (!DateOnly.TryParse(dob, out DateOnly dobResult))
            StudentException.Throw("Invalid date of birth");

        return new(name, email, dobResult);
    }

    public static Student Update(string id, string name, string email, string dob)
    {
        if (string.IsNullOrEmpty(id))
            StudentException.Throw("Id cannot be empty");

        if (string.IsNullOrEmpty(name))
            StudentException.Throw("Name cannot be empty");

        if (string.IsNullOrEmpty(email))
            StudentException.Throw("Email cannot be empty");

        if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.IgnoreCase))
            StudentException.Throw("Invalid email address");

        if (!DateOnly.TryParse(dob, out DateOnly dobResult))
            StudentException.Throw("Invalid date of birth");

        return new(id, name, email, dobResult);
    }
}
