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

    public async Task<Node> GetTreeByNameAsync(string treeName)
    {
        return await _context.Nodes
            .Where(n => n.ParentId == null && n.Name == treeName)
            .FirstOrDefaultAsync();
    }

    public async Task<Node> GetTreeChildrenByNameAsync(string treeName)
    {
        var node = await _context.Nodes.Where(n => n.ParentId == null && n.Name == treeName)
            .Include(t => t.Children)
            .FirstOrDefaultAsync();

        if (node != null)
        {
            await LoadChildrenAsync(node);
        }

        return node;
    }

    public async Task<Node> CreateTreeAsync(string treeName)
    {
        var tree = new Node()
        {
            Name = treeName
        };
        _context.Nodes.Add(tree);
        await _context.SaveChangesAsync();
        return tree;
    }

    private async Task LoadChildrenAsync(Node node)
    {
        if (node.Children.Count > 0)
        {
            foreach (var child in node.Children)
            {
                await _context.Entry(child).Collection(c => c.Children).LoadAsync();
                await LoadChildrenAsync(child); // рекурсивная загрузка
            }
        }
    }
}