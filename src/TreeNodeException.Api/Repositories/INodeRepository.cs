using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public interface INodeRepository
{
    Task<IEnumerable<Node>> GetNodesByTreeIdAsync(int treeId);
    Task<Node> GetNodeByIdAsync(int id);
    Task<Node> AddNodeAsync(Node node);
    Task UpdateNodeAsync(Node node);
    Task DeleteNodeAsync(int id);
}