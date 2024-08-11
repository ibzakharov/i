using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public interface ITreeRepository
{
    Task<IEnumerable<Node>> GetAllTreesAsync();
    Task<Node> GetTreeByIdAsync(int id);
    Task AddTreeAsync(Node tree);
    Task UpdateTreeAsync(Node tree);
    Task DeleteTreeAsync(int id);
}