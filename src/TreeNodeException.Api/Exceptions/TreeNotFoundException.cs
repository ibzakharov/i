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

    public static TreeNotFoundException Throw(string treeName)
    {
        throw new TreeNotFoundException($"Tree with Name = {treeName} was not found");
    }
}