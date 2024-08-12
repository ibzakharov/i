using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeNodeException.Api.Dtos;
using TreeNodeException.Api.Exceptions;
using TreeNodeException.Api.Repositories;

namespace TreeNodeException.Api.Controllers;

[Route("api/tree")]
[ApiController]
public class TreeController : ControllerBase
{
    private readonly ITreeRepository _treeRepository;
    private readonly INodeRepository _nodeRepository;
    private readonly IMapper _mapper;

    public TreeController(ITreeRepository treeRepository,
        INodeRepository nodeRepository,
        IMapper mapper)
    {
        _treeRepository = treeRepository;
        _nodeRepository = nodeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreeDto>>> GetTrees()
    {
        var nodes = await _treeRepository.GetAllTreesAsync();
        return Ok(_mapper.Map<IEnumerable<TreeDto>>(nodes));
    }

    [HttpGet("nodes")]
    public async Task<ActionResult<IEnumerable<TreeNodesDto>>> GetTreeNodes()
    {
        var nodes = await _treeRepository.GetAllTreeNodesAsync();
        return Ok(_mapper.Map<IEnumerable<TreeNodesDto>>(nodes));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TreeDto>> GetTree(int id)
    {
        var tree = await _treeRepository.GetTreeByIdAsync(id);

        if (tree == null)
        {
            throw TreeNotFoundException.Throw();
        }

        return Ok(_mapper.Map<TreeDto>(tree));
    }

    [HttpGet("{id}/nodes")]
    public async Task<ActionResult<TreeNodesDto>> GetTreeNodes(int id)
    {
        var tree = await _nodeRepository.GetNodeWithChildByIdAsync(id);

        if (tree == null)
        {
            throw TreeNotFoundException.Throw();
        }

        return Ok(_mapper.Map<TreeNodesDto>(tree));
    }

    [HttpPost]
    public async Task<ActionResult<TreeDto>> PostTree(ModifyTreeDto nodeDto)
    {
        var node = _mapper.Map<Node>(nodeDto);
        await _nodeRepository.AddNodeAsync(node);

        return CreatedAtAction(nameof(GetTree), new { id = node.NodeId }, _mapper.Map<TreeDto>(node));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTree(int id, ModifyTreeDto nodeDto)
    {
        var node = await _treeRepository.GetTreeByIdAsync(id);

        if (node == null)
        {
            throw TreeNotFoundException.Throw();
        }

        _mapper.Map(nodeDto, node);
        await _nodeRepository.UpdateNodeAsync(node);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTree(int id)
    {
        var node = await _nodeRepository.GetNodeByIdAsync(id);
        if (node == null)
        {
            throw TreeNotFoundException.Throw();
        }

        await _nodeRepository.DeleteNodeAsync(node);

        return NoContent();
    }
}