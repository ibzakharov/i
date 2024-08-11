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

    public async Task<Node> GetNodeWithChildByIdAsync(int id)
    {
        var node = await _context.Nodes
            .Include(n => n.Child)
            .FirstOrDefaultAsync(n => n.NodeId == id);

        if (node == null)
            return null;

        await LoadChildrenAsync(node);
        return node;
    }

    private async Task LoadChildrenAsync(Node node)
    {
        if (node.Child != null && node.Child.Count > 0)
        {
            foreach (var child in node.Child)
            {
                await _context.Entry(child).Collection(c => c.Child).LoadAsync();
                await LoadChildrenAsync(child); // рекурсивная загрузка
            }
        }
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

    public async Task DeleteNodeAsync(int id)
    {
        var node = await GetNodeByIdAsync(id);
        if (node != null)
        {
            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();
        }
    }
}