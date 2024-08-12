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

    // public async Task<IEnumerable<Node>> GetAllTreesAsync()
    // {
    //     return await _context.Nodes
    //         .Where(t => t.ParentId == null)
    //         .ToListAsync();
    // }

    public async Task<Tree> GetTreeChildrenByIdAsync(int id)
    {
        var tree = await _context.Trees
            .Include(t => t.Nodes)
            .FirstOrDefaultAsync(t => t.TreeId == id);

        foreach (var node in tree.Nodes)
        {
            await NodeHelper.LoadChildrenAsync(node, _context);
        }

        return tree;
    }

    public async Task<Tree> GetTreeByIdAsync(int id)
    {
        return await _context.Trees
            .FirstOrDefaultAsync(t => t.TreeId == id);
    } 
    
    public async Task<Tree> GetTreeByNameAsync(string treeName)
    {
        return await _context.Trees
            .FirstOrDefaultAsync(t => t.TreeName == treeName);
    }

    public async Task<Tree> CreateTreeAsync(string treeName)
    {
        var tree = new Tree()
        {
            TreeName = treeName
        };
        _context.Trees.Add(tree);
        await _context.SaveChangesAsync();
        return tree;
    }

    public async Task UpdateTreeAsync(Tree tree)
    {
        _context.Entry(tree).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTreeAsync(Tree tree)
    {
        _context.Trees.Remove(tree);
        await _context.SaveChangesAsync();
    }
}