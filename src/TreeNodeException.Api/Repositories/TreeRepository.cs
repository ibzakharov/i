using Microsoft.EntityFrameworkCore;
using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public class TreeRepository : ITreeRepository
{
    private readonly ApplicationDbContext _context;

    public TreeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Node>> GetAllTreesAsync()
    {
        return await _context.Nodes
            .Where(t => t.ParentId == null)
            .ToListAsync();
    }

    public async Task<IEnumerable<Node>> GetAllTreeNodesAsync()
    {
        var nodes = await _context.Nodes
            .Where(t => t.ParentId == null)
            .Include(n => n.Child)
            .ToListAsync();

        foreach (var node in nodes)
        {
            await NodeHelper.LoadChildrenAsync(node, _context);
        }

        return nodes;
    }
    
    public async Task<Node> GetTreeByIdAsync(int id)
    {
        return await _context.Nodes
            .Where(t => t.ParentId == null)
            .FirstOrDefaultAsync(t => t.NodeId == id);
    }
}