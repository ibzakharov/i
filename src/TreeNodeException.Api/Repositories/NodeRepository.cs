using Microsoft.EntityFrameworkCore;
using TreeNodeException.Api.Models;

namespace TreeNodeException.Api.Repositories;

public class NodeRepository : INodeRepository
{
    private readonly ApplicationDbContext _context;

    public NodeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Node>> GetNodesByTreeIdAsync(int treeId)
    {
        return await _context.Nodes.Where(n => n.TreeID == treeId).ToListAsync();
    }

    public async Task<Node> GetNodeByIdAsync(int id)
    {
        return await _context.Nodes.FindAsync(id);
    }

    public async Task<Node> AddNodeAsync(Node node)
    {
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
        return node;
    }

    public async Task UpdateNodeAsync(Node node)
    {
        _context.Entry(node).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNodeAsync(int id)
    {
        var node = await _context.Nodes.FindAsync(id);
        if (node != null)
        {
            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();
        }
    }
}