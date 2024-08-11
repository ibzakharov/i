using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public interface ITreeRepository
{
    Task<IEnumerable<Node>> GetAllTreesAsync();  
    
    Task<IEnumerable<Node>> GetAllTreeNodesAsync();
    Task<Node> GetTreeByIdAsync(int id);
}