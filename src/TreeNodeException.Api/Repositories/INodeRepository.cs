namespace TreeNodeException.Api.Repositories;

public interface INodeRepository
{
    Task<Node> GetNodeByIdAndNameAsync(int id, string nodeName);
    Task<Node> GetNodeChildrenByIdAndNameAsync(int id, string nodeName);
    Task<Node> GetNodeByParentIdAndNameAsync(int parentId, string nodeName);
    Task AddNodeAsync(Node node);
    Task UpdateNodeAsync(Node node);
    Task DeleteNodeAsync(Node node);
}