namespace TreeNodeException.Api.Exceptions;

public class NodeDuplicateNameException : SecureException
{
    public NodeDuplicateNameException()
    {
    }

    public NodeDuplicateNameException(string message) : base(message)
    {
    }

    public NodeDuplicateNameException(string message, Exception inner) : base(message, inner)
    {
    }

    public static NodeDuplicateNameException Throw()
    {
        throw new NodeDuplicateNameException("Duplicate node name");
    }
}