namespace CRUDWithAdoDotNet.Exceptions;

internal class StudentException(string message) : Exception(message)
{
    public static StudentException Throw(string message) => throw new StudentException(message);
}