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

    public async Task<IEnumerable<Tree>> GetAllTreesAsync()
    {
        return await _context.Trees.Include(t => t.Nodes).ToListAsync();
    }

    public async Task<Tree> GetTreeByIdAsync(int id)
    {
        return await _context.Trees.Include(t => t.Nodes)
            .FirstOrDefaultAsync(t => t.TreeID == id);
    }

    public async Task<Tree> AddTreeAsync(Tree tree)
    {
        _context.Trees.Add(tree);
        await _context.SaveChangesAsync();
        return tree;
    }

    public async Task UpdateTreeAsync(Tree tree)
    {
        _context.Entry(tree).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTreeAsync(int id)
    {
        var tree = await _context.Trees.FindAsync(id);
        if (tree != null)
        {
            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();
        }
    }
}