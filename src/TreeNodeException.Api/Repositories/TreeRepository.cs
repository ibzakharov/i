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

    public async Task<Node> GetTreeByIdAsync(int id)
    {
        return await _context.Nodes
            // .Include(t => t.ParentNode)
            .FirstOrDefaultAsync(t => t.NodeId == id);
    }
    
    public async Task AddTreeAsync(Node node)
    {
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateTreeAsync(Node node)
    {
        _context.Entry(node).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteTreeAsync(int id)
    {
        var tree = await _context.Nodes.FindAsync(id);
        if (tree != null)
        {
            _context.Nodes.Remove(tree);
            await _context.SaveChangesAsync();
        }
    }
}