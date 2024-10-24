namespace LibrarySystem.Domain.Exceptions;

public class IdNullException : Exception
{
    public IdNullException() : base()
    {
        Console.WriteLine("You must provide ID");
    }

}
