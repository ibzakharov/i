namespace TreeNodeException.Api.Exceptions;

public class SecureException : Exception
{
    public SecureException()
    {
    }

    public SecureException(string message) : base(message)
    {
    }

    public SecureException(string message, Exception inner) : base(message, inner)
    {
    }
}