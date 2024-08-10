using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreeNodeException.Api.Models;
using TreeNodeException.Api.Repositories;
using TreeNodeException.Dtos;

namespace TreeNodeException.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NodesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly INodeRepository _nodeRepository;

    public NodesController(ApplicationDbContext context, 
        IMapper mapper,
        INodeRepository nodeRepository)
    {
        _context = context;
        _mapper = mapper;
        _nodeRepository = nodeRepository;
    }

    // [HttpGet("tree/{treeId}")]
    // public async Task<ActionResult<IEnumerable<Node>>> GetNodesByTree(int treeId)
    // {
    //     return await _context.Nodes.Where(n => n.TreeID == treeId).ToListAsync();
    // }
    //
    [HttpGet("{id}")]
    public async Task<ActionResult<NodeDTO>> GetNode(int id)
    {
        var node = await _nodeRepository.GetNodeByIdAsync(id);
        if (node == null)
        {
            return NotFound();
        }
        var nodeDto = _mapper.Map<NodeDTO>(node);
        return Ok(nodeDto);
    }
    
    // [HttpPost]
    // public async Task<ActionResult<Node>> PostNode(Node node)
    // {
    //     _context.Nodes.Add(node);
    //     await _context.SaveChangesAsync();
    //
    //     return CreatedAtAction(nameof(GetNode), new { id = node.NodeID }, node);
    // }   
    
    [HttpPost("new-node")]
    public async Task<ActionResult<NodeDTO>> PostNewNode(Modify nodeDto)
    {
        // Проверить TreeId
        var find = await _context.Trees.FirstOrDefaultAsync(p => p.TreeID == nodeDto.TreeID);
        if (find == null)
        {
            return NotFound();
        }
        
        var node = _mapper.Map<Node>(nodeDto);
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();

        var createdNodeDto = _mapper.Map<NodeDTO>(node);
        return CreatedAtAction(nameof(GetNode), new { id = node.NodeID }, createdNodeDto);
    } 
    
    // [HttpPost("new-child-node")]
    // public async Task<ActionResult<Node>> PostNewNode(int treeId, int parentNodeId)
    // {
    //     var find = await _context.Nodes.FirstOrDefaultAsync(p => p.ParentNodeID == parentNodeId && p.TreeID == treeId);
    //     if (find == null)
    //     {
    //         return NotFound();
    //     }
    //     
    //     var node = new Node
    //     {
    //         TreeID = treeId,
    //         ParentNodeID = parentNodeId
    //     };
    //
    //     _context.Nodes.Add(node);
    //     await _context.SaveChangesAsync();
    //
    //     return CreatedAtAction(nameof(GetNode), new { id = node.NodeID }, node);
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutNode(int id, Node node)
    // {
    //     if (id != node.NodeID)
    //     {
    //         return BadRequest();
    //     }
    //
    //     _context.Entry(node).State = EntityState.Modified;
    //
    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!NodeExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }
    //
    //     return NoContent();
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteNode(int id)
    // {
    //     var node = await _context.Nodes.FindAsync(id);
    //     if (node == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     _context.Nodes.Remove(node);
    //     await _context.SaveChangesAsync();
    //
    //     return NoContent();
    // }
    //
    // private bool NodeExists(int id)
    // {
    //     return _context.Nodes.Any(e => e.NodeID == id);
    // }
}