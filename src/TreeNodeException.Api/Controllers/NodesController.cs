using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeNodeException.Api.Dtos;
using TreeNodeException.Api.Repositories;

[Route("api/nodes")]
[ApiController]
public class NodesController : ControllerBase
{
    private readonly INodeRepository _nodeRepository;
    private readonly IMapper _mapper;

    public NodesController(INodeRepository nodeRepository, IMapper mapper)
    {
        _nodeRepository = nodeRepository;
        _mapper = mapper;
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<NodeDto>>> GetNodes()
    // {
    //     var nodes = await _nodeRepository.GetAllNodesAsync();
    //     var nodesDto = _mapper.Map<IEnumerable<NodeDto>>(nodes);
    //     return Ok(nodesDto);
    // }

    [HttpGet("{id}")]
    public async Task<ActionResult<NodeDto>> GetNode(int id)
    {
        var node = await _nodeRepository.GetNodeByIdAsync(id);
        if (node == null)
        {
            return NotFound();
        }

        var nodeDto = _mapper.Map<NodeDto>(node);
        return Ok(nodeDto);
    }

    [HttpGet("{id}/child")]
    public async Task<ActionResult<NodeChildDto>> GetNodeChild(int id)
    {
        var node = await _nodeRepository.GetNodeWithChildByIdAsync(id);
        if (node == null)
        {
            return NotFound();
        }

        var nodeDto = _mapper.Map<NodeChildDto>(node);
        return Ok(nodeDto);
    }

    [HttpPost]
    public async Task<ActionResult<NodeDto>> CreateNode(NodeDto nodeDto)
    {
        var node = _mapper.Map<Node>(nodeDto);
        await _nodeRepository.AddNodeAsync(node);
        return CreatedAtAction(nameof(GetNode), new { id = node.NodeId }, _mapper.Map<NodeDto>(node));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNode(int id, NodeDto nodeDto)
    {
        if (id != nodeDto.NodeId)
        {
            return BadRequest();
        }

        var node = await _nodeRepository.GetNodeByIdAsync(id);
        if (node == null)
        {
            return NotFound();
        }

        _mapper.Map(nodeDto, node);
        await _nodeRepository.UpdateNodeAsync(node);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNode(int id)
    {
        var node = await _nodeRepository.GetNodeByIdAsync(id);
        if (node == null)
        {
            return NotFound();
        }

        await _nodeRepository.DeleteNodeAsync(node);
        return NoContent();
    }
}