namespace TreeNodeException.Api.Repositories;

public interface ITreeRepository
{
    Task<Node> CreateTreeAsync(string treeName);
    Task<Node> GetTreeByNameAsync(string treeName);
    Task<Node> GetTreeChildrenByNameAsync(string treeName);
}