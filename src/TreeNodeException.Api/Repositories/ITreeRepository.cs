using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public interface ITreeRepository
{
    // Task<IEnumerable<Node>> GetAllTreesAsync();  
    // Task<IEnumerable<Node>> GetAllTreeNodesAsync();
    Task<Tree> GetTreeByIdAsync(int id);
    Task<Tree> CreateTreeAsync(string treeName);
    Task UpdateTreeAsync(Tree tree);
    Task DeleteTreeAsync(Tree tree);
    Task<Tree> GetTreeByNameAsync(string treeName);

    Task<Tree> GetTreeChildrenByIdAsync(int id);
}