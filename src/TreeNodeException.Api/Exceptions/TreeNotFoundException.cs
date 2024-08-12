namespace TreeNodeException.Api.Exceptions;

public class TreeNotFoundException : SecureException
{
    public TreeNotFoundException()
    {
    }

    public TreeNotFoundException(string message) : base(message)
    {
    }

    public TreeNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public static TreeNotFoundException Throw()
    {
        throw new TreeNotFoundException("Tree not found");
    }
}