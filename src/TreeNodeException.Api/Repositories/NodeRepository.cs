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

    public async Task<Node> GetNodeByIdAndNameAsync(int id, string nodeName)
    {
        return await _context.Nodes
            .FirstOrDefaultAsync(n => n.NodeId == id && n.Name == nodeName);
    }

    public async Task<Node> GetNodeChildrenByIdAndNameAsync(int id, string nodeName)
    {
        return await _context.Nodes.Where(n => n.NodeId == id && n.Name == nodeName)
            .Include(t => t.Children)
            .FirstOrDefaultAsync();
    }

    public async Task<Node> GetNodeByParentIdAndNameAsync(int parentId, string nodeName)
    {
        return await _context.Nodes
            .FirstOrDefaultAsync(n => n.ParentId == parentId && n.Name == nodeName);
    }

    public async Task AddNodeAsync(Node node)
    {
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNodeAsync(Node node)
    {
        _context.Nodes.Update(node);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNodeAsync(Node node)
    {
        _context.Nodes.Remove(node);
        await _context.SaveChangesAsync();
    }
}