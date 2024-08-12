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

    public async Task<Node> GetNodeByIdAsync(int id)
    {
        return await _context.Nodes
            .FirstOrDefaultAsync(n => n.NodeId == id);
    }

    public async Task<Node> GetNodeByNameAsync(int treeId, string nodeName)
    {
        return await _context.Nodes
            .FirstOrDefaultAsync(n => n.TreeId == treeId && n.Name == nodeName);
    }

    public async Task<Node> GetNodeWithChildByIdAsync(int id)
    {
        var node = await _context.Nodes
            .Include(n => n.Children)
            .FirstOrDefaultAsync(n => n.NodeId == id);

        if (node == null)
            return null;

        await NodeHelper.LoadChildrenAsync(node, _context);
        return node;
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