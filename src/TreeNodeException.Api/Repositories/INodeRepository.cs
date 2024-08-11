namespace TreeNodeException.Api.Repositories;

public interface INodeRepository
{
    Task<Node> GetNodeByIdAsync(int id);
    Task<Node> GetNodeWithChildByIdAsync(int id);
    Task AddNodeAsync(Node node);
    Task UpdateNodeAsync(Node node);
    Task DeleteNodeAsync(Node node);
}