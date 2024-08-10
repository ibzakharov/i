using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public interface ITreeRepository
{
    Task<IEnumerable<Tree>> GetAllTreesAsync();
    Task<Tree> GetTreeByIdAsync(int id);
    Task<Tree> AddTreeAsync(Tree tree);
    Task UpdateTreeAsync(Tree tree);
    Task DeleteTreeAsync(int id);
}