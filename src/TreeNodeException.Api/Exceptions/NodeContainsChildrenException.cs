namespace TreeNodeException.Api.Exceptions;

public class NodeContainsChildrenException : SecureException
{
    public NodeContainsChildrenException()
    {
    }

    public NodeContainsChildrenException(string message) : base(message)
    {
    }

    public NodeContainsChildrenException(string message, Exception inner) : base(message, inner)
    {
    }

    public static NodeContainsChildrenException Throw()
    {
        throw new NodeContainsChildrenException($"You have to delete all children nodes first");
    }
}