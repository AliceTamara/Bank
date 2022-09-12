namespace Bank.Exceptions;

public class InvalidAccountNumberException : Exception
{
    public InvalidAccountNumberException(string message) : base(message)
    {

    }
}