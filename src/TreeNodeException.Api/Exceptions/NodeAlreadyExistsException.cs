namespace TreeNodeException.Api.Exceptions;

public class NodeAlreadyExistsException : SecureException
{
    public NodeAlreadyExistsException()
    {
    }

    public NodeAlreadyExistsException(string message) : base(message)
    {
    }

    public NodeAlreadyExistsException(string message, Exception inner) : base(message, inner)
    {
    }

    public static NodeAlreadyExistsException Throw()
    {
        throw new NodeAlreadyExistsException("Node already exists");
    }
}